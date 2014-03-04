using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleSolicitud : System.Web.UI.Page
    {
        #region "Events"
            protected void AutoridadButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarAutoridaSenalada.aspx");
            }

            protected void CalificarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeCalificarSolicitud.aspx");
            }

            protected void CiudadanoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarCiudadanosSol.aspx");
            }

            protected void DocumentoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarDocumentos.aspx");
            }

            protected void EnviarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeEnviarSolicitud.aspx");
            }

            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                GuardarSolicitud();
            }

            protected void IndicadorButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarIndicadores.aspx");
            }

            protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx");
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void GuardarSolicitud()
            {

            }

            private void PageLoad()
            {
                int SolicitudId = 0;

                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                        SelectLugarHechos();
                        SelectSolicitud(SolicitudId);
                        SelectCiudadano(SolicitudId);
                        SelectAutoridades(SolicitudId);
                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            private void ResetForm()
            {
                SolicitudLabel.Text = "";
                CalificacionLabel.Text = "";
                EstatusaLabel.Text = "";
                FuncionarioLabel.Text = "";
                ContactoLabel.Text = "";
                TipoSolicitudLabel.Text = "";
                ObservacionesLabel.Text = "";
            }

            private void SelectAutoridades(int SolicitudId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

                SolicitudProcess.SelectSolicitudAutoridad();

                if (SolicitudProcess.ErrorId == 0)
                {
                    this.gvAutoridades.DataSource = null;
                    this.gvAutoridades.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + SolicitudProcess.ErrorDescription + "', 'Fail', true);", true);

                this.gvAutoridades.DataSource = null;
                this.gvAutoridades.DataBind();
            }

            private void SelectCiudadano(int SolicitudId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

                SolicitudProcess.SelectSolicitudCiudadano();

                if (SolicitudProcess.ErrorId == 0)
                {
                    this.gvCiudadano.DataSource = SolicitudProcess.SolicitudEntity.ResultData.Tables[0];
                    this.gvCiudadano.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + SolicitudProcess.ErrorDescription + "', 'Fail', true);", true);
            }

            private void SelectLugarHechos()
            {
                BPLugarHechos LugarProcess = new BPLugarHechos();

                LugarProcess.SelectLugarHechos();

                if (LugarProcess.ErrorId == 0)
                {
                    LugarHechosList.DataValueField = "LugarHechosId";
                    LugarHechosList.DataTextField = "Nombre";

                    LugarHechosList.DataSource = LugarProcess.LugarEntity.ResultData.Tables[0];
                    LugarHechosList.DataBind();

                    LugarHechosList.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + LugarProcess.ErrorDescription + "', 'Fail', true);", true);
            }

            private void SelectSolicitud(int SolicitudId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

                SolicitudProcess.SelectSolicitudDetalle();

                if (SolicitudProcess.ErrorId == 0)
                {
                    SolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                    CalificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreCalificacion"].ToString();
                    EstatusaLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreEstatus"].ToString();
                    FuncionarioLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreFuncionario"].ToString();
                    ContactoLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreContacto"].ToString();
                    TipoSolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreTipoSolicitud"].ToString();
                    ObservacionesLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                }
                else
                {
                    ResetForm();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + SolicitudProcess.ErrorDescription + "', 'Fail', true);", true);
                }
            }
        #endregion
    }
}