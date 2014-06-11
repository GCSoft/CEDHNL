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
    public partial class visComparecencia : System.Web.UI.Page
    {
        // Utilerías
        Function utilFunction = new Function();

        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                SaveComparecencia();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }

            protected void ComparecenciaGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
            {
                ComparecenciaGridRowCommand(e);
            }
        #endregion

        #region "Methods"
            private void ComparecenciaGridRowCommand(GridViewCommandEventArgs e)
            {
                int ExpedienteComparecenciaId = 0;

                ExpedienteComparecenciaId = int.Parse(e.CommandArgument.ToString());

                switch (e.CommandName.ToString())
                {
                    case "Editar":
                        SelectExpedienteComparecencia(ExpedienteComparecenciaId, int.Parse(ExpedienteIdHidden.Value));
                        break;

                    case "Eliminar":
                        DeleteExpedienteComparecencia(ExpedienteComparecenciaId, int.Parse(ExpedienteIdHidden.Value));
                        break;
                }
            }

            private void DeleteExpedienteComparecencia(int ExpedienteComparecenciaId, int ExpedienteId)
            {
                BPExpedienteComparecencia ExpedienteComparecenciaProcess = new BPExpedienteComparecencia();

                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteComparecenciaId = ExpedienteComparecenciaId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteId = ExpedienteId;

                ExpedienteComparecenciaProcess.DeleteExpedienteComparecencia();

                if (ExpedienteComparecenciaProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectExpedienteComparecencia(ExpedienteId);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteComparecenciaProcess.ErrorDescription) + "', 'Error', true);", true);
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
                SelectLugarComparecencia();
                SelectFuncionario();
                SelectTipoComparecencia();
                SelectCiudadano(ExpedienteId);
                SelectExpedienteComparecencia(ExpedienteId);

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
            }

            private void ResetForm()
            {
                FechaBox.SetCurrentDate();
                LugarComparecenciaList.SelectedIndex = 0;
                FuncionarioIdList.SelectedIndex = 0;
                TipoComparecenciaIdList.SelectedIndex = 0;
                CiudadanoIdList.SelectedIndex = 0;
                AsuntoBox.Text = "";
                DetalleBox.Text = "";
                ExpedienteComparecenciaIdHidden.Value = "0";
            }

            private void SaveComparecencia()
            {
                int ExpedienteComparecenciaId = 0;
                int ExpedienteId = 0;
                int LugarComparecenciaId = 0;
                int FuncionarioId = 0;
                int TipoComparecenciaId = 0;
                int CiudadanoId = 0;
                string Fecha = string.Empty;
                string Asunto = string.Empty;
                string Detalle = string.Empty;

                ExpedienteComparecenciaId = int.Parse(ExpedienteComparecenciaIdHidden.Value);
                ExpedienteId = int.Parse(ExpedienteIdHidden.Value);
                Fecha = FechaBox.DisplayDate;
                LugarComparecenciaId = int.Parse(LugarComparecenciaList.SelectedValue);
                FuncionarioId = int.Parse(FuncionarioIdList.SelectedValue);
                TipoComparecenciaId = int.Parse(TipoComparecenciaIdList.SelectedValue);
                CiudadanoId = int.Parse(CiudadanoIdList.SelectedValue);
                Asunto = AsuntoBox.Text.Trim();
                Detalle = DetalleBox.Text.Trim();

                SaveComparecencia(ExpedienteComparecenciaId, ExpedienteId, FuncionarioId, CiudadanoId, LugarComparecenciaId, TipoComparecenciaId, Asunto, Detalle, Fecha);
            }

            private void SaveComparecencia(int ExpedienteComparecenciaId, int ExpedienteId, int FuncionarioId, int CiudadanoId, int LugarComparecenciaId, int TipoComparecenciaId, string Asunto, string Detalle, string Fecha)
            {
                BPExpedienteComparecencia ExpedienteComparecenciaProcess = new BPExpedienteComparecencia();

                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteComparecenciaId = ExpedienteComparecenciaId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteId = ExpedienteId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.FuncionarioId = FuncionarioId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.CiudadanoId = CiudadanoId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.LugarComparecenciaId = LugarComparecenciaId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.TipoComparecenciaId = TipoComparecenciaId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.Asunto = Asunto;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.Detalle = Detalle;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.Fecha = Fecha;

                ExpedienteComparecenciaProcess.SaveExpedienteComparecencia();

                if (ExpedienteComparecenciaProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectExpedienteComparecencia(ExpedienteId);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteComparecenciaProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectCiudadano(int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();
                ENTExpediente ExpedienteEntity = new ENTExpediente();
                ENTResponse ResponseEntity = new ENTResponse();

                ExpedienteEntity.ExpedienteId = ExpedienteId;

                ExpedienteProcess.SelectCiudadanosGrid(ExpedienteEntity);

                if (ExpedienteProcess.ErrorId == 0)
                {
                    CiudadanoIdList.DataTextField = "Nombre";
                    CiudadanoIdList.DataValueField = "CiudadanoId";

                    CiudadanoIdList.DataSource = ExpedienteEntity.ResultData;
                    CiudadanoIdList.DataBind();

                    CiudadanoIdList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ExpedienteProcess.ErrorDescription + "', 'Success', true);", true);
                }
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

            private void SelectExpedienteComparecencia(int ExpedienteId)
            {
                BPExpedienteComparecencia ExpedienteComparecenciaProcess = new BPExpedienteComparecencia();

                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteId = ExpedienteId;

                ExpedienteComparecenciaProcess.SelectExpedienteComparecencia();

                if (ExpedienteComparecenciaProcess.ErrorId == 0)
                {
                    ComparecenciaGrid.DataSource = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0];
                    ComparecenciaGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteComparecenciaProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectExpedienteComparecencia(int ExpedienteComparecenciaId, int ExpedienteId)
            {
                BPExpedienteComparecencia ExpedienteComparecenciaProcess = new BPExpedienteComparecencia();

                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteComparecenciaId = ExpedienteComparecenciaId;
                ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ExpedienteId = ExpedienteId;

                ExpedienteComparecenciaProcess.SelectExpedienteComparecencia();

                if (ExpedienteComparecenciaProcess.ErrorId != 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteComparecenciaProcess.ErrorDescription) + "', 'Error', true);", true);
                    return;
                }

                if (ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText("No se encontró información de seguimiento para el expediente") + "', 'Error', true);", true);
                    return;
                }

                FechaBox.SetDate = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["Fecha"].ToString(); ;
                LugarComparecenciaList.SelectedValue = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["LugarComparecenciaId"].ToString();
                FuncionarioIdList.SelectedValue = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["FuncionarioId"].ToString();
                TipoComparecenciaIdList.SelectedValue = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["TipoComparecenciaId"].ToString();
                CiudadanoIdList.SelectedValue = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["CiudadanoId"].ToString();
                AsuntoBox.Text = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["Asunto"].ToString();
                DetalleBox.Text = ExpedienteComparecenciaProcess.ExpedienteComparecenciaEntity.ResultData.Tables[0].Rows[0]["Detalle"].ToString();

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
                ExpedienteComparecenciaIdHidden.Value = ExpedienteComparecenciaId.ToString();
            }

            private void SelectFuncionario()
            {
                BPFuncionario oBPFuncionario = new BPFuncionario();
                ENTFuncionario oENTFuncionario = new ENTFuncionario();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    // Transacción
                    oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

                    // Validación de error en la consulta
                    if (oENTResponse.GeneratesException)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true);", true);
                        return;
                    }

                    // Mensaje de la base de datos
                    if (oENTResponse.sMessage != "")
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true);", true);

                    //LLenado de control
                    FuncionarioIdList.DataTextField = "sFullName";
                    FuncionarioIdList.DataValueField = "FuncionarioId";

                    FuncionarioIdList.DataSource = oENTResponse.dsResponse.Tables[1];
                    FuncionarioIdList.DataBind();

                    // Agregar Item de selección
                    FuncionarioIdList.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
                }
            }

            private void SelectLugarComparecencia()
            {
                BPLugarComparecencia LugarComparecenciaProcess = new BPLugarComparecencia();

                LugarComparecenciaProcess.SelectLugarComparecencia();

                if (LugarComparecenciaProcess.ErrorId == 0)
                {
                    LugarComparecenciaList.DataTextField = "Nombre";
                    LugarComparecenciaList.DataValueField = "LugarComparecenciaId";

                    LugarComparecenciaList.DataSource = LugarComparecenciaProcess.LugarComparecenciaEntity.ResultData.Tables[0];
                    LugarComparecenciaList.DataBind();

                    LugarComparecenciaList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(LugarComparecenciaProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectTipoComparecencia()
            {
                BPTipoComparecencia TipoComparecenciaProcess = new BPTipoComparecencia();

                TipoComparecenciaProcess.SelectTipoComparecencia();

                if (TipoComparecenciaProcess.ErrorId == 0)
                {
                    TipoComparecenciaIdList.DataTextField = "Nombre";
                    TipoComparecenciaIdList.DataValueField = "TipoComparecenciaId";

                    TipoComparecenciaIdList.DataSource = TipoComparecenciaProcess.TipoComparecenciaEntity.ResultData.Tables[0];
                    TipoComparecenciaIdList.DataBind();

                    TipoComparecenciaIdList.Items.Insert(0, new ListItem("[Seleccione]", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(TipoComparecenciaProcess.ErrorDescription) + "', 'Error', true);", true);
            }
        #endregion
    }
}