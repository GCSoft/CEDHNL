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
    public partial class visSeguimientoExpediente : System.Web.UI.Page
    {
        // Utilerías
        Function utilFunction = new Function();

        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                SaveExpedienteSeguimiento();
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
                SelectTipoSeguimiento();

                SelectExpedienteSeguimiento();

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
            }

            private void ResetForm()
            {
                FechaBox.SetCurrentDate();
                TipoSeguimientoIdList.SelectedIndex = 0;
                SeguimientoBox.Text = "";
            }

            private void SaveExpedienteSeguimiento()
            {
                int ExpedienteSeguimientoId = 0;
                int ExpedienteId = 0;
                int TipoSeguimientoId = 0;
                string Fecha = string.Empty;
                string Detalle = string.Empty;

                ExpedienteSeguimientoId = int.Parse(ExpedienteSeguimientoIdHidden.Value);
                ExpedienteId = int.Parse(ExpedienteIdHidden.Value);
                TipoSeguimientoId = int.Parse(TipoSeguimientoIdList.SelectedValue);
                Fecha = FechaBox.DisplayDate;
                Detalle = SeguimientoBox.Text.Trim();

                SaveExpedienteSeguimiento(ExpedienteSeguimientoId, ExpedienteId, TipoSeguimientoId, Fecha, Detalle);
            }

            private void SaveExpedienteSeguimiento(int ExpedienteSeguimientoId, int ExpedienteId, int TipoSeguimientoId, string Fecha, string Detalle)
            {
                BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = ExpedienteSeguimientoId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = ExpedienteId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.TipoSeguimientoId = TipoSeguimientoId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.Fecha = Fecha;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.Detalle = Detalle;

                ExpedienteSeguimientoProcess.SaveExpedienteSeguimiento();

                if (ExpedienteSeguimientoProcess.ErrorId == 0)
                {
                    ResetForm();
                    //SelectExpedienteSeguimiento
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteSeguimientoProcess.ErrorDescription) + "', 'Error', true);", true);
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

            private void SelectExpedienteSeguimiento()
            {
                SeguimientoGrid.DataSource = null;
                SeguimientoGrid.DataBind();
            }

            private void SelectTipoSeguimiento()
            {
                ENTTipoSeguimiento oENTTipoSeguimiento = new ENTTipoSeguimiento();
                ENTResponse oENTResponse = new ENTResponse();
                BPTipoSeguimiento oBPTipoSeguimiento = new BPTipoSeguimiento();

                try
                {
                    // Formulario
                    oENTTipoSeguimiento.TipoSeguimientoId = 0;
                    oENTTipoSeguimiento.Nombre = "";

                    // Transacción
                    oENTResponse = oBPTipoSeguimiento.SelectTipoSeguimiento(oENTTipoSeguimiento);

                    // Validaciones
                    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                    // Mensaje de la BD
                    if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);", true); }

                    // Llenado de combo
                    TipoSeguimientoIdList.DataTextField = "Nombre";
                    TipoSeguimientoIdList.DataValueField = "TipoSeguimientoId";
                    TipoSeguimientoIdList.DataSource = oENTResponse.dsResponse.Tables[1];
                    TipoSeguimientoIdList.DataBind();

                    // Agregar Item de selección
                    this.TipoSeguimientoIdList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        #endregion
    }
}