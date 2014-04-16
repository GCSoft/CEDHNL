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
        string AllDefault = "-- Seleccione --";

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
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string sSolicitudId = SolicitudIdHidden.Value;
            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + sSolicitudId);
        }
        #endregion

        #region "Methods"
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
        /*
        * solo cuando se seleccione la opción de Orientación
        * se van a mostrar los campos Cierre de orientación y Canalizado
        */
        public void Orientacion_OnSelectedIndexChanged(Object sender, EventArgs e)
        {

            if (int.Parse(ddlCierre.SelectedValue) != 0)
            {

                CeldaCanalizado.Visible = true;
                CeldaFundamento.Visible = true;
            }

            else
            {

                CeldaCanalizado.Visible = false;
                CeldaFundamento.Visible = false;
            }

        }

        protected void SelectCalificacion()
        {

            BPCalificacion BPCalificacion = new BPCalificacion();

            ddlCalificacion.DataValueField = "CalificacionId";
            ddlCalificacion.DataTextField = "Nombre";

            ddlCalificacion.DataSource = BPCalificacion.SelectCalificacion();
            ddlCalificacion.DataBind();
            ddlCalificacion.Items.Insert(0, new ListItem(AllDefault, "0"));


        }
        protected void SelectOrientacion()
        {

            BPTipoOrientacion BPTipoOrientacion = new BPTipoOrientacion();

            ddlCierre.DataValueField = "TipoOrientacionId";
            ddlCierre.DataTextField = "Nombre";

            ddlCierre.DataSource = BPTipoOrientacion.SelectTipoOrientacion();
            ddlCierre.DataBind();
            ddlCierre.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectCanalizacion()
        {

            BPCanalizacion BPCanalizacion = new BPCanalizacion();

            ddlCanalizado.DataValueField = "CanalizacionId";
            ddlCanalizado.DataTextField = "Nombre";

            ddlCanalizado.DataSource = BPCanalizacion.SelectCanalizacion();
            ddlCanalizado.DataBind();
            ddlCanalizado.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void GuardarCalificacionSol()
        {

            ENTSession SessionEntity = new ENTSession();

            SessionEntity = (ENTSession)Session["oENTSession"];

            if (this.ddlCalificacion.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Calificacion es obligatorio ', 'Fail', true); focusControl('" + this.ddlCalificacion.ClientID + "');", true);
                return;
            }

            if (this.ddlCierre.SelectedValue != "0")
            {

                if (this.ddlCanalizado.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Fail', true); focusControl('" + this.ddlCanalizado.ClientID + "');", true);
                    return;
                }

                if (this.TextBoxFundamento.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Fail', true); focusControl('" + this.ddlCanalizado.ClientID + "');", true);
                    return;
                }
            }

            GuardarCalificacionSol(SessionEntity.idUsuario, int.Parse(SolicitudIdHidden.Value), TextBoxFundamento.Text, int.Parse(ddlCanalizado.SelectedValue), int.Parse(ddlCalificacion.SelectedValue), int.Parse(ddlCierre.SelectedValue));
        }

        protected void GuardarCalificacionSol(int IdUsuarioInsert, int SolicitudId, string Fundamento, int CanalizacionId, int CalificacionId, int CierreOrientacionId)
        {

            BPSolicitud BPSolicitud = new BPSolicitud();

            BPSolicitud.SolicitudEntity.idUsuarioInsert = IdUsuarioInsert;
            BPSolicitud.SolicitudEntity.SolicitudId = SolicitudId;
            BPSolicitud.SolicitudEntity.Fundamento = Fundamento;
            BPSolicitud.SolicitudEntity.CanalizacionId = CanalizacionId;
            BPSolicitud.SolicitudEntity.CalificacionId = CalificacionId;
            BPSolicitud.SolicitudEntity.CierreOrientacionId = CierreOrientacionId;

            BPSolicitud.GuardarCalificacionSol();
            if (BPSolicitud.ErrorId == 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La Calificacion se ha dado de alta correctamente ', 'Success', true);", true);
                LimpiarCampos();
                Button1.Enabled = false;
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + BPSolicitud.ErrorDescription + "', 'Error', true);", true);

        }

        protected void LimpiarCampos()
        {
            ddlCalificacion.SelectedIndex = 0;
            ddlCierre.SelectedIndex = 0;
            CeldaCanalizado.Visible = false;
            CeldaFundamento.Visible = false;

            ddlCalificacion.Focus();
        }

        #endregion

    }
}