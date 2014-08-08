using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCUtility.Function;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visResolucionExpediente : System.Web.UI.Page
    {
        // Utilerías
		GCJavascript gcJavascript = new GCJavascript();

        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                SaveResolucion();
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

            private void PageLoad()
            {
                int ExpedienteId = 0;

                if (Page.IsPostBack)
                    return;

                ExpedienteId = GetExpedienteParameter();

                SelectExpediente(ExpedienteId);
                SelectTipoResolucion();
                SelectExpedienteResolucion(ExpedienteId);

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
            }

            private void ResetForm()
            {
                TipoResolucionIdList.SelectedIndex = 0;
                DetalleBox.Text = "";
                ExpedienteResolucionIdHidden.Value = "0";
            }

            private void SaveResolucion()
            {
                int ExpedienteResolucionId = 0;
                int ExpedienteId = 0;
                int FuncionarioId = 0;
                int TipoResolucionId = 0;
                string Detalle = string.Empty;
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                ExpedienteResolucionId = int.Parse(ExpedienteResolucionIdHidden.Value);
                ExpedienteId = int.Parse(ExpedienteIdHidden.Value);
                FuncionarioId = SessionEntity.FuncionarioId;
                TipoResolucionId = int.Parse(TipoResolucionIdList.SelectedValue);
                Detalle = DetalleBox.Text.Trim();

                SaveResolucion(ExpedienteResolucionId, ExpedienteId, FuncionarioId, TipoResolucionId, Detalle);
            }

            private void SaveResolucion(int ExpedienteResolucionId, int ExpedienteId, int FuncionarioId, int TipoResolucionId, string Detalle)
            {
                BPExpedienteResolucion ExpedienteResolucionProcess = new BPExpedienteResolucion();

                ExpedienteResolucionProcess.ExpedienteResolucionEntity.ExpedienteResolucionId = ExpedienteResolucionId;
                ExpedienteResolucionProcess.ExpedienteResolucionEntity.ExpedienteId = ExpedienteId;
                ExpedienteResolucionProcess.ExpedienteResolucionEntity.FuncionarioId = FuncionarioId;
                ExpedienteResolucionProcess.ExpedienteResolucionEntity.TipoResolucionId = TipoResolucionId;
                ExpedienteResolucionProcess.ExpedienteResolucionEntity.Detalle = Detalle;

                ExpedienteResolucionProcess.SaveExpedienteResolucion();

                if (ExpedienteResolucionProcess.ErrorId == 0)
                {
                    ResetForm();
                    // Mensaje de que todo se guardó correctamente
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ExpedienteResolucionProcess.ErrorDescription) + "');", true);
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(BPExpediente.ErrorDescription) + "');", true);
            }

            private void SelectExpedienteResolucion(int ExpedienteId)
            {
                BPExpedienteResolucion ExpedienteResolucionProcess = new BPExpedienteResolucion();

                ExpedienteResolucionProcess.ExpedienteResolucionEntity.ExpedienteId = ExpedienteId;

                ExpedienteResolucionProcess.SelectExpedienteResolucion();

                if (ExpedienteResolucionProcess.ErrorId != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ExpedienteResolucionProcess.ErrorDescription) + "');", true);
                    return;
                }

                if (ExpedienteResolucionProcess.ExpedienteResolucionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    // Se llenan los valores de los controles con los de la base de datos
                    TipoResolucionIdList.SelectedValue = ExpedienteResolucionProcess.ExpedienteResolucionEntity.ResultData.Tables[0].Rows[0]["TipoResolucionId"].ToString();
                    DetalleBox.Text = ExpedienteResolucionProcess.ExpedienteResolucionEntity.ResultData.Tables[0].Rows[0]["Detalle"].ToString();
                    ExpedienteResolucionIdHidden.Value = ExpedienteResolucionProcess.ExpedienteResolucionEntity.ResultData.Tables[0].Rows[0]["ExpedienteResolucionId"].ToString();

                    // Se bloquean los controles porque no se le debe de permitir al funcionario modificar la información
                    TipoResolucionIdList.Enabled = false;
                    DetalleBox.Enabled = false;
                    GuardarButton.Enabled = false;
                }
            }

            private void SelectTipoResolucion()
            {
                BPTipoResolucion TipoResolucionProcess = new BPTipoResolucion();

                TipoResolucionProcess.SelectTipoResolucion();

                if (TipoResolucionProcess.ErrorId == 0)
                {
                    TipoResolucionIdList.DataTextField = "Nombre";
                    TipoResolucionIdList.DataValueField = "TipoResolucionId";

                    TipoResolucionIdList.DataSource = TipoResolucionProcess.TipoResolucionEntity.ResultData.Tables[0];
                    TipoResolucionIdList.DataBind();

                    TipoResolucionIdList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(TipoResolucionProcess.ErrorDescription) + "');", true);
            }
        #endregion
    }
}