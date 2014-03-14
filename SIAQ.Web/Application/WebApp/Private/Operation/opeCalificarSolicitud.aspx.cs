using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using System.Configuration;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeCalificarSolicitud : System.Web.UI.Page
    {
        string AllDefault = "-- Todos --";
        public string _SolicitudId;

        #region "Events"
            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
            protected void GuardarCalificacionSol_Click(object sender, EventArgs e)
            {
                GuardarCalificacionSol();
            }
        #endregion

        #region
            private void PageLoad()
            {

                int SolicitudId = 0;

                if (!this.Page.IsPostBack)
                {
                    SelectCalificacion();
                    SelectOrientacion();
                    SelectCanalizacion();

                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                        _SolicitudId = SolicitudId.ToString();
                        SolicitudLabel.Text = _SolicitudId;
                        SolicitudIdHidden.Value = _SolicitudId;

                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            protected void SelectCalificacion() {

                BPCalificacion BPCalificacion = new BPCalificacion();

                ddlCalificacion.DataValueField = "CalificacionId";
                ddlCalificacion.DataTextField = "Nombre";

                ddlCalificacion.DataSource = BPCalificacion.SelectCalificacion();
                ddlCalificacion.DataBind();
                ddlCalificacion.Items.Insert(0, new ListItem(AllDefault, "0"));


            }
            protected void SelectOrientacion() {

                BPTipoOrientacion BPTipoOrientacion = new BPTipoOrientacion();

                ddlCierre.DataValueField = "TipoOrientacionId";
                ddlCierre.DataTextField = "Nombre";

                ddlCierre.DataSource = BPTipoOrientacion.SelectTipoOrientacion();
                ddlCierre.DataBind();
                ddlCierre.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            protected void SelectCanalizacion() {

                BPCanalizacion BPCanalizacion = new BPCanalizacion();
                
                ddlCanalizado.DataValueField = "CalificacionId";
                ddlCanalizado.DataTextField = "Nombre";

                ddlCanalizado.DataSource = BPCanalizacion.SelectCanalizacion();
                ddlCanalizado.DataBind();
                ddlCanalizado.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            protected void GuardarCalificacionSol() { 
            
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                   if (this.ddlCalificacion.SelectedValue == "0"){
                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Calificacion es obligatorio ', 'Success', true); focusControl('" + this.ddlCalificacion.ClientID + "');", true);
                      return;
                   }

                   if (this.ddlCanalizado.SelectedValue == "0"){
                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Success', true); focusControl('" + this.ddlCanalizado.ClientID + "');", true);
                      return;
                   }

                   if (this.ddlCierre.SelectedValue == "0"){
                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Cierre de Orientacion es obligatorio ', 'Success', true); focusControl('" + this.ddlCierre.ClientID + "');", true);
                      return;
                   }

                GuardarCalificacionSol(SessionEntity.idUsuario ,int.Parse(SolicitudIdHidden.Value), TextBoxFundamento.Text, int.Parse(ddlCanalizado.SelectedValue) ,int.Parse(ddlCalificacion.SelectedValue) , int.Parse(ddlCierre.SelectedValue) );
            }

            protected void GuardarCalificacionSol(int IdUsuarioInsert , int SolicitudId , string Fundamento , int CanalizacionId , int CalificacionId , int CierreOrientacionId)
            {

            }


        #endregion
    }
}