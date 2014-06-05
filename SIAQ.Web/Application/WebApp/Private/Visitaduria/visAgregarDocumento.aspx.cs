using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visAgregarDocumento : System.Web.UI.Page
    {
        Function utilFunction = new Function();

        #region "Events"
            protected void AgregarButton_Click(object sender, EventArgs e)
            {
                MostrarPanel();
            }

            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                SaveDocumento();
            }

            protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
            {
                OcultarPanel();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void MostrarPanel()
            {
                pnlAction.Visible = true;
            }

            private void OcultarPanel()
            {
                pnlAction.Visible = false;
            }

            private void PageLoad()
            {
                string ExpedienteId = string.Empty;

                if (Page.IsPostBack)
                    return;

                try
                {
                    ExpedienteId = Request.QueryString["E"].ToString();
                }
                catch
                {
                    // ToDo: Mostrar error
                    return;
                }

                SelectTipoDocumento();

                DocumentoGrid.DataSource = null;
                DocumentoGrid.DataBind();

                ExpedienteIdHidden.Value = ExpedienteId;
            }

            private void ResetForm()
            {
                TipoDocumentoList.SelectedIndex = 0;
                NombreBox.Text = "";
                DescripcionBox.Text = "";
            }

            private void SaveDocumento()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                SaveDocumento(int.Parse(ExpedienteIdHidden.Value), SessionEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
            }

            private void SaveDocumento(int ExpedienteId, int idUsuarioInsert, string Nombre, string Descripcion, FileUpload DocumentoFile)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.ExpedienteId = ExpedienteId;
                DocumentoProcess.DocumentoEntity.idUsuarioInsert = idUsuarioInsert;
                DocumentoProcess.DocumentoEntity.TipoDocumentoId = TipoDocumentoList.SelectedValue;
                DocumentoProcess.DocumentoEntity.Nombre = Nombre;
                DocumentoProcess.DocumentoEntity.Descripcion = Descripcion;
                DocumentoProcess.DocumentoEntity.FileUpload = DocumentoFile;

                DocumentoProcess.SaveRepositorioSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectDocumento(int.Parse(ExpedienteIdHidden.Value));

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', true);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(DocumentoProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectDocumento(int ExpedienteId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.ExpedienteId = ExpedienteId;

                DocumentoProcess.SelectRepositorioSE();

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