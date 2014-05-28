﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class opeAgregarDocumentosVisitaduria : System.Web.UI.Page
    {
        public string _ExpedienteId;
        Function utilFunction = new Function();

        #region "Events"
        protected void DocumentoGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            DocumentoGridRowCommand(e);
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            SaveDocumento();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Se le agrega una propiedad al formulario de la página para poder subir archivos
            this.Form.Enctype = "multipart/form-data";

            PageLoad();
        }
        #endregion

        #region
        private void DeleteRepositorio(string RepositorioId)
        {
            DeleteRepositorio(RepositorioId, int.Parse(ExpedienteIdHidden.Value), 0);
        }

        private void DeleteRepositorio(string RepositorioId, int SolicitudId, int ExpedienteId)
        {
            BPDocumento DocumentoProcess = new BPDocumento();

            DocumentoProcess.DocumentoEntity.RepositorioId = RepositorioId;
            DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;
            DocumentoProcess.DocumentoEntity.ExpedienteId = ExpedienteId;

            DocumentoProcess.DeleteDocumentoSE();

            if (DocumentoProcess.ErrorId == 0)
            {
                SelectDocumento(int.Parse(ExpedienteIdHidden.Value));

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', true);", true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(DocumentoProcess.ErrorDescription) + "', 'Error', true);", true);
        }

        private void DocumentoGridRowCommand(GridViewCommandEventArgs e)
        {
            string RepositorioId = string.Empty;

            RepositorioId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Eliminar":
                    DeleteRepositorio(RepositorioId);
                    break;
            }
        }

        private void PageLoad()
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    _ExpedienteId = Request.QueryString["s"].ToString();

                    ExpedienteLabel.Text = _ExpedienteId;

                    SelectDocumento(int.Parse(_ExpedienteId));
                    SelectTipoDocumento();

                    ExpedienteIdHidden.Value = _ExpedienteId;
                }
                catch (Exception Exception)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                }
            }
        }

        private void ResetForm()
        {
            NombreBox.Text = "";
            DescripcionBox.Text = "";
        }

        private void SaveDocumento()
        {
            ENTSession SessionEntity = new ENTSession();

            SessionEntity = (ENTSession)Session["oENTSession"];

            SaveDocumento(int.Parse(ExpedienteIdHidden.Value), SessionEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
        }

        private void SaveDocumento(int SolicitudId, int idUsuarioInsert, string Nombre, string Descripcion, FileUpload DocumentoFile)
        {
            BPDocumento DocumentoProcess = new BPDocumento();

            DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;
            DocumentoProcess.DocumentoEntity.idUsuarioInsert = idUsuarioInsert;
            DocumentoProcess.DocumentoEntity.TipoDocumentoId = TipoDocumentoList.SelectedValue;
            DocumentoProcess.DocumentoEntity.Nombre = Nombre;
            DocumentoProcess.DocumentoEntity.Descripcion = Descripcion;
            DocumentoProcess.DocumentoEntity.FileUpload = DocumentoFile;

            DocumentoProcess.SaveDocumentoSE();

            if (DocumentoProcess.ErrorId == 0)
            {
                ResetForm();
                SelectDocumento(int.Parse(ExpedienteIdHidden.Value));

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', true);", true);
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(DocumentoProcess.ErrorDescription) + "', 'Error', true);", true);
        }

        private void SelectDocumento(int SolicitudId)
        {
            BPDocumento DocumentoProcess = new BPDocumento();

            DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

            DocumentoProcess.SelectDocumentoSE();

            if (DocumentoProcess.ErrorId == 0)
            {
                DocumentoGrid.DataSource = DocumentoProcess.DocumentoEntity.ResultData;
                DocumentoGrid.DataBind();
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + DocumentoProcess.ErrorDescription + "', 'Error', true);", true);
        }

        private void SelectTipoDocumento()
        {
            BPTipoDocumento TipoDocumentoProcess = new BPTipoDocumento();

            TipoDocumentoProcess.SelectTipoDocumento();

            if (TipoDocumentoProcess.ErrorId == 0)
            {
                TipoDocumentoList.DataValueField = "TipoDocumentoId";
                TipoDocumentoList.DataTextField = "Nombre";

                TipoDocumentoList.DataSource = TipoDocumentoProcess.TipoDocumentoEntity.ResultData;
                TipoDocumentoList.DataBind();

                TipoDocumentoList.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + TipoDocumentoProcess.ErrorDescription + "', 'Error', true);", true);
        }
        #endregion
    }
}