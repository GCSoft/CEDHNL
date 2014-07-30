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
        bool IsReadOnly = false;
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

            protected void SeguimientoGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
            {
                SeguimientoGridRowCommand(e);
            }

            protected void SeguimientoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                SeguimientoGridRowDataBound(e);
            }
        #endregion

        #region "Methods"
            private void DeleteExpedienteSeguimiento(int ExpedienteSeguimientoId, int ExpedienteId)
            {
                BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = ExpedienteSeguimientoId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = ExpedienteId;

                ExpedienteSeguimientoProcess.DeleteExpedienteSeguimiento();

                if (ExpedienteSeguimientoProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectExpedienteSeguimiento(ExpedienteId);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteSeguimientoProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void DisableControls()
            {
                GuardarButton.Enabled = false;
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

                ValidarExpediente(ExpedienteId);

                SelectExpediente(ExpedienteId);
                SelectTipoSeguimiento();
                SelectExpedienteSeguimiento(ExpedienteId);

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
            }

            private void ResetForm()
            {
                FechaBox.SetCurrentDate();
                TipoSeguimientoIdList.SelectedIndex = 0;
                SeguimientoBox.Text = "";
                ExpedienteSeguimientoIdHidden.Value = "0";
            }

            private void SaveExpedienteSeguimiento()
            {
                int ExpedienteSeguimientoId = 0;
                int ExpedienteId = 0;
                int FuncionarioId = 0;
                int TipoSeguimientoId = 0;
                string Fecha = string.Empty;
                string Detalle = string.Empty;
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                ExpedienteSeguimientoId = int.Parse(ExpedienteSeguimientoIdHidden.Value);
                ExpedienteId = int.Parse(ExpedienteIdHidden.Value);
                FuncionarioId = SessionEntity.FuncionarioId;
                TipoSeguimientoId = int.Parse(TipoSeguimientoIdList.SelectedValue);
                Fecha = FechaBox.DisplayDate;
                Detalle = SeguimientoBox.Text.Trim();

                SaveExpedienteSeguimiento(ExpedienteSeguimientoId, ExpedienteId, FuncionarioId, TipoSeguimientoId, Fecha, Detalle);
            }

            private void SaveExpedienteSeguimiento(int ExpedienteSeguimientoId, int ExpedienteId, int FuncionarioId, int TipoSeguimientoId, string Fecha, string Detalle)
            {
                BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = ExpedienteSeguimientoId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = ExpedienteId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.FuncionarioId = FuncionarioId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.TipoSeguimientoId = TipoSeguimientoId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.Fecha = Fecha;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.Detalle = Detalle;

                ExpedienteSeguimientoProcess.SaveExpedienteSeguimiento();

                if (ExpedienteSeguimientoProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectExpedienteSeguimiento(ExpedienteId);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteSeguimientoProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SeguimientoGridRowCommand(GridViewCommandEventArgs e)
            {
                int ExpedienteSeguimientoId = 0;

                ExpedienteSeguimientoId = int.Parse(e.CommandArgument.ToString());

                switch (e.CommandName.ToString())
                {
                    case "Editar":
                        SelectExpedienteSeguimiento(ExpedienteSeguimientoId, int.Parse(ExpedienteIdHidden.Value));
                        break;

                    case "Eliminar":
                        DeleteExpedienteSeguimiento(ExpedienteSeguimientoId, int.Parse(ExpedienteIdHidden.Value));
                        break;
                }
            }

            private void SeguimientoGridRowDataBound(GridViewRowEventArgs e)
            {
                ImageButton EliminarButton;

                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                    return;

                EliminarButton = (ImageButton)e.Row.FindControl("EliminarButton");

                if (EliminarButton == null)
                    return;

                if (IsReadOnly)
                    EliminarButton.Enabled = false;
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

            private void SelectExpedienteSeguimiento(int ExpedienteId)
            {
                BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = ExpedienteId;

                ExpedienteSeguimientoProcess.SelectExpedienteSeguimiento();

                if (ExpedienteSeguimientoProcess.ErrorId == 0)
                {
                    SeguimientoGrid.DataSource = ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData;
                    SeguimientoGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteSeguimientoProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectExpedienteSeguimiento(int ExpedienteSeguimientoId, int ExpedienteId)
            {
                BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = ExpedienteSeguimientoId;
                ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = ExpedienteId;

                ExpedienteSeguimientoProcess.SelectExpedienteSeguimiento();

                if (ExpedienteSeguimientoProcess.ErrorId != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteSeguimientoProcess.ErrorDescription) + "', 'Error', true);", true);
                    return;
                }

                if (ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText("No se encontró información de seguimiento para el expediente") + "', 'Error', true);", true);
                    return;
                }

                //FechaBox.SetDate;
                TipoSeguimientoIdList.SelectedValue = ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows[0]["TipoSeguimientoId"].ToString();
                SeguimientoBox.Text = ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows[0]["Detalle"].ToString();

                ExpedienteIdHidden.Value = ExpedienteSeguimientoId.ToString();
                ExpedienteSeguimientoIdHidden.Value = ExpedienteSeguimientoId.ToString();
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
                    if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false);", true); }

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

            private void ValidarExpediente(int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();

                ExpedienteProcess.SelectExpedienteEstatus(ExpedienteId);

                if (ExpedienteProcess.ErrorId != 0)
                {
                    IsReadOnly = true;
                    DisableControls();
                    return;
                }

                if (ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.POR_ASIGNAR_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.POR_ATENDER_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.EN_PROCESO_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.PENDIENTE_APROBAR_ESTATUS)
                {
                    IsReadOnly = true;
                    DisableControls();
                    return;
                }
            }
        #endregion
    }
}