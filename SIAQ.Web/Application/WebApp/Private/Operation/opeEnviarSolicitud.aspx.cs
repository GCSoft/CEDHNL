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
    public partial class opeEnviarSolicitud : System.Web.UI.Page
    {
        public string _SolicitudId;
        Function utilFunction = new Function();

        #region "Events"
        protected void SendButton_Click(object sender, EventArgs e)
        {
            SendSolicitud();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }
        #endregion

        #region "Methods"

        private void PageLoad()
        {
            int SolicitudId = 0;

            if (!this.Page.IsPostBack)
            {
                try
                {
                    SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                    SelectSolicitud(SolicitudId);

                    _SolicitudId = SolicitudId.ToString();
                }
                catch (Exception Exception)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Exception.Message) + "', 'Fail', true);", true);
                }
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

        private void SendSolicitud()
        {

        }

        private void ValidarEnvio(int solicitudId)
        {
            BPSolicitud oBPSolicitud = new BPSolicitud();

            try
            {
                oBPSolicitud.SolicitudEntity.SolicitudId = solicitudId;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion
    }
}