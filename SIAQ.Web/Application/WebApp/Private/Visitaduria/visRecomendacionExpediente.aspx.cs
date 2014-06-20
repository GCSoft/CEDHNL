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
    public partial class visRecomendacionExpediente : System.Web.UI.Page
    {
        const int EstatusIdRecomendacion = 13;
        Function utilFunction = new Function();

        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                SaveRecomendacion();
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

                RecomendacionGrid.DataSource = null;
                RecomendacionGrid.DataBind();

                ExpedienteId = GetExpedienteParameter();

                SelectExpediente(ExpedienteId);
                SelectTipoRecomendacion();
                SelectRecomendacionExpediente(ExpedienteId);

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
            }

            private void ResetForm()
            {
                TipoRecomendacionList.SelectedIndex = 0;
                RecomendacionBox.Text = "";
            }

            private void SaveRecomendacion()
            {
                ENTSession SessionEntity = new ENTSession();
                BPRecomendacion RecomendacionProcess = new BPRecomendacion();

                SessionEntity = (ENTSession)Session["oENTSession"];

                RecomendacionProcess.RecomendacionEntity.ExpedienteId = int.Parse(ExpedienteIdHidden.Value);
                
                // Identificador del visitador que da de alta la recomendación
                RecomendacionProcess.RecomendacionEntity.FuncionarioId = SessionEntity.FuncionarioId;

                RecomendacionProcess.RecomendacionEntity.TipoRecomendacionId = int.Parse(TipoRecomendacionList.SelectedValue);
                RecomendacionProcess.RecomendacionEntity.EstatusId = EstatusIdRecomendacion;
                RecomendacionProcess.RecomendacionEntity.Anio = int.Parse(DateTime.Now.Year.ToString());
                RecomendacionProcess.RecomendacionEntity.Observaciones = RecomendacionBox.Text.Trim();

                RecomendacionProcess.SaveRecomendacion();

                if (RecomendacionProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectRecomendacionExpediente(int.Parse(ExpedienteIdHidden.Value));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(RecomendacionProcess.ErrorString) + "', 'Error', true);", true);
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

            private void SelectTipoRecomendacion()
            {
                BPTipoRecomendacion TipoRecomendacionProcess = new BPTipoRecomendacion();

                TipoRecomendacionProcess.SelectTipoRecomendacion();

                if (TipoRecomendacionProcess.ErrorId == 0)
                {
                    TipoRecomendacionList.DataTextField = "Nombre";
                    TipoRecomendacionList.DataValueField = "TipoRecomendacionId";

                    TipoRecomendacionList.DataSource = TipoRecomendacionProcess.TipoRecomendacionEntity.ResultData.Tables[0];
                    TipoRecomendacionList.DataBind();

                    TipoRecomendacionList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(TipoRecomendacionProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectRecomendacionExpediente(int ExpedienteId)
            {
                BPRecomendacion RecomendacionProcess = new BPRecomendacion();

                RecomendacionProcess.RecomendacionEntity.ExpedienteId = ExpedienteId;

                RecomendacionProcess.SelectRecomendacionExpediente();

                if (RecomendacionProcess.ErrorId == 0)
                {
                    RecomendacionGrid.DataSource = RecomendacionProcess.RecomendacionEntity.ResultData.Tables[0];
                    RecomendacionGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(RecomendacionProcess.ErrorString) + "', 'Error', true);", true);
            }
        #endregion
    }
}