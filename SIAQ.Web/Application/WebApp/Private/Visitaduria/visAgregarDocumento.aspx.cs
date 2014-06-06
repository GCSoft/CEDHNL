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
                int ExpedienteId = 0;

                if (Page.IsPostBack)
                    return;

                ExpedienteId = GetExpedienteParameter();

                SelectTipoDocumento();
                SelectExpediente(ExpedienteId);

                DocumentoGrid.DataSource = null;
                DocumentoGrid.DataBind();

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