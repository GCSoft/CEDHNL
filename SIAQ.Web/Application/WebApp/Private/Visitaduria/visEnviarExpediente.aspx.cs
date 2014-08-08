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
    public partial class visEnviarExpediente : System.Web.UI.Page
    {
        const int ExpedienteEnviadoEstatus = 12;
		GCJavascript gcJavascript = new GCJavascript();

        #region "Events"
            protected void EnviarButton_Click(object sender, EventArgs e)
            {
                EnviarExpediente(int.Parse(ExpedienteIdHidden.Value));
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void EnviarExpediente(int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();

                ExpedienteProcess.ExpedienteEntity.ExpedienteId = ExpedienteId;
                ExpedienteProcess.ExpedienteEntity.EstatusId = ExpedienteEnviadoEstatus;

                ExpedienteProcess.UpdateExpedienteEstatus();

                if (ExpedienteProcess.ErrorId == 0)
                {
                    EnviarButton.Enabled = false;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('El expediente ha sido enviado para su revisión');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ExpedienteProcess.ErrorDescription) + "');", true);
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

                SelectExpediente(ExpedienteId);

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
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
        #endregion
    }
}