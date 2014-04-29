using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class AsignarFuncionario : System.Web.UI.Page
    {
        public string _SolicitudId;
        string AllDefault = "[Seleccione]";
        Function utilFunction = new Function();

        #region "Events"
            protected void RegresarButton_Click(object sender, EventArgs e)
            {
                Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + SolicitudIdHidden.Value);
            }

            protected void SaveButton_Click(object sender, EventArgs e)
            {
                SaveFuncionarioSolicitud(int.Parse(SolicitudIdHidden.Value), int.Parse(FuncionarioList.SelectedValue));
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region
            private void PageLoad()
            {
                int SolicitudId = 0;

                if (!Page.IsPostBack)
                {
                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                        SelectFuncionario();
                        SelectSolicitud(SolicitudId);

                        SolicitudIdHidden.Value = SolicitudId.ToString();
                    }
                    catch(Exception Ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Ex.Message) + "', 'Error', true);", true);
                    }
                }
            }

            private void ResetForm()
            {
                FuncionarioList.SelectedIndex = 0;
            }

            private void SaveFuncionarioSolicitud(int SolicitudId, int FuncionarioId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;
                SolicitudProcess.SolicitudEntity.FuncionarioId = FuncionarioId;

                SolicitudProcess.SaveFuncionarioSolicitud();

                if (SolicitudProcess.ErrorId == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El funcionario fue asignado a la solicitud', 'Success', true);", true);
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Error', true);", true);
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
                    this.FuncionarioList.DataTextField = "sFullName";
                    this.FuncionarioList.DataValueField = "FuncionarioId";

                    this.FuncionarioList.DataSource = oENTResponse.dsResponse.Tables[1];
                    this.FuncionarioList.DataBind();

                    // Agregar Item de selección
                    this.FuncionarioList.Items.Insert(0, new ListItem(AllDefault, "0"));

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
                }
            }

            private void SelectSolicitud(int SolicitudId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

                SolicitudProcess.SelectSolicitudDetalle();

                if (SolicitudProcess.ErrorId == 0)
                {
                    if (SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
                    {
                        SolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                        CalificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreCalificacion"].ToString();
                        EstatusaLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreEstatus"].ToString();
                        FuncionarioLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreFuncionario"].ToString();
                        ContactoLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreContacto"].ToString();
                        TipoSolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreTipoSolicitud"].ToString();
                        ObservacionesLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                        LugarHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreLugarHechos"].ToString();
                        DireccionHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
                }
            }
        #endregion
    }
}