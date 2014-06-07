using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        const string ModuloId = "95DF4FFE-7DBE-4272-B0E9-CFAD4D9596D3";
        Function utilFunction = new Function();

        #region "Events"
            protected void DocumentoGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
            {
                DocumentoGridRowCommand(e);
            }

            protected void DocumentoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                DocumentoGridRowDataBound(e);
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

        #region "Methods"
            private void DeleteRepositorio(string RepositorioId)
            {
                DeleteRepositorio(RepositorioId, int.Parse(SolicitudIdHidden.Value));
            }

            private void DeleteRepositorio(string RepositorioId, int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.RepositorioId = RepositorioId;
                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.DeleteRepositorioSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    SelectDocumento(int.Parse(SolicitudIdHidden.Value));

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

            private void DocumentoGridRowDataBound(GridViewRowEventArgs e)
            {
                HyperLink DocumentoLink;
                Image DocumentoImage;
                DataRowView DataRow;

                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                    return;

                DocumentoImage = (Image)e.Row.FindControl("DocumentoImage");
                DocumentoLink = (HyperLink)e.Row.FindControl("DocumentoLink");

                DataRow = (DataRowView)e.Row.DataItem;

                DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
                DocumentoLink.NavigateUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=" + DataRow["SolicitudId"].ToString();
            }

            private int GetExpedienteParameter()
            {
                try
                {
                    return int.Parse(Request.QueryString["expId"].ToString());
                }
                catch
                {
                    return 0;
                }
            }

            private void PageLoad()
            {
                int ExpedienteId = 0;

                if (Page.IsPostBack)
                    return;

                ExpedienteId = GetExpedienteParameter();

                SelectTipoDocumento();
                SelectExpediente(ExpedienteId);
                SelectDocumento(int.Parse(SolicitudIdHidden.Value));

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
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

                SaveDocumento(int.Parse(SolicitudIdHidden.Value), SessionEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
            }

            private void SaveDocumento(int SolicitudId, int idUsuarioInsert, string Nombre, string Descripcion, FileUpload DocumentoFile)
            {
                BPDocumento RepositorioProcess = new BPDocumento();

                RepositorioProcess.DocumentoEntity.ModuloId = ModuloId;
                RepositorioProcess.DocumentoEntity.TipoDocumentoId = TipoDocumentoList.SelectedValue;
                RepositorioProcess.DocumentoEntity.SolicitudId = SolicitudId;
                RepositorioProcess.DocumentoEntity.idUsuarioInsert = idUsuarioInsert;
                RepositorioProcess.DocumentoEntity.Nombre = Nombre;
                RepositorioProcess.DocumentoEntity.Descripcion = Descripcion;
                RepositorioProcess.DocumentoEntity.FileUpload = DocumentoFile;

                RepositorioProcess.SaveRepositorioSE();

                if (RepositorioProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectDocumento(int.Parse(SolicitudIdHidden.Value));

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', true);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(RepositorioProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectDocumento(int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.SelectRepositorioSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    DocumentoGrid.DataSource = DocumentoProcess.DocumentoEntity.ResultData;
                    DocumentoGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + DocumentoProcess.ErrorDescription + "', 'Error', true);", true);
            }

            private void SelectExpediente(int ExpedienteId)
            {
                ENTSession UsuarioEntity = new ENTSession();

                UsuarioEntity = (ENTSession)Session["oENTSession"];

                SelectExpediente(ExpedienteId, UsuarioEntity.FuncionarioId);
            }

            private void SelectExpediente(int ExpedienteId, int FuncionarioId)
            {
                BPExpediente BPExpediente = new BPExpediente();
                ENTExpediente oENTExpediente = new ENTExpediente();

                oENTExpediente.ExpedienteId = ExpedienteId;
                oENTExpediente.FuncionarioId = FuncionarioId;

                BPExpediente.SelectDetalleExpediente(oENTExpediente);

                if (BPExpediente.ErrorId == 0)
                {
                    // Detalle 
                    if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ExpedienteIdLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                        CalificacionLlabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Calificacion"].ToString();
                        EstatusaLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                        VisitadorLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Visitador"].ToString();
                        FormaContactoLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["FormaContacto"].ToString();
                        TipoSolicitudLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["TipoSolicitud"].ToString();
                        ObservacionesLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                        LugarHechosLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["LugarHechos"].ToString();
                        DireccionHechos.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

                        SolicitudIdHidden.Value = oENTExpediente.ResultData.Tables[0].Rows[0]["SolicitudId"].ToString();
                    }

                    //Fechas
                    if (oENTExpediente.ResultData.Tables[1].Rows.Count > 0)
                    {
                        FechaRecepcionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
                        FechaAsignacionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
                        FechaGestionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
                        FechaModificacionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString();
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(BPExpediente.ErrorDescription) + "', 'Error', true);", true);
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