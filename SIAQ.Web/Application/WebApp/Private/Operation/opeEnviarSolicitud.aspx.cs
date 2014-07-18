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

					FechaRecepcionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
					FechaAsignacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
					FechaGestionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
					FechaModificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString();

				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
			}
		}

        #region "Events"
        protected void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string sSolicitudId = hdnSolicitudId.Value;
                ValidarEnvio(Convert.ToInt32(sSolicitudId));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "','Fail',true);"
                    , true);
            }
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
                    hdnSolicitudId.Value = SolicitudId.ToString();

                    SelectSolicitud(SolicitudId);
                    _SolicitudId = SolicitudId.ToString();
                }
                catch (Exception Exception)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Exception.Message) + "', 'Fail', true);", true);
                }
            }
        }

        

        private void SendSolicitud(int solicitudId)
        {
            BPSolicitud oBPSolicitud = new BPSolicitud();
            ENTResponse oENTResponse = new ENTResponse();
            ENTSolicitud oENTSolicitud = new ENTSolicitud();

            try
            {
                //Transacción
                oENTSolicitud.SolicitudId = solicitudId;
                oENTResponse = oBPSolicitud.EnviarSolicitud(oENTSolicitud);

                //Validación
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Redireccionar al listado
				Response.Redirect("opeSolicitudFuncionario.aspx", false);

            }catch (Exception ex){
                throw (ex);
            }
        }

        private void ValidarEnvio(int solicitudId)
        {
            BPSolicitud oBPSolicitud = new BPSolicitud();

            try
            {
                oBPSolicitud.SolicitudEntity.SolicitudId = solicitudId;
                oBPSolicitud.ValidarEnviarSolicitud();

                if (oBPSolicitud.ErrorId == 0)
                {
                    if (oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
                    {
                        int iNumeroCiudadanos = Convert.ToInt32(oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows[0]["NumeroCiudadanos"].ToString());
                        int iCalificada = Convert.ToInt32(oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows[0]["Calificada"].ToString());
                        int iNumeroAutoridad = Convert.ToInt32(oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows[0]["NumeroAutoridad"].ToString());
                        string sAutoridadesSinVoz = oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows[0]["AutoridadesSinVoz"].ToString();

                        if (iNumeroCiudadanos == 0)
                        {
                            throw new Exception("No se ha podido realizar el envío, no se han agregado ciudadanos a la solicitud.");
                        }

                        if (iCalificada == 0)
                        {
                            throw new Exception("No se ha podido realizar el envío, no se ha calificado la solicitud.");
                        }

                        if (iNumeroAutoridad == 0)
                        {
                            throw new Exception("No se ha podido realizar el envío, no se han agregado autoridades a la solicitud.");
                        }

                        if (String.IsNullOrEmpty(sAutoridadesSinVoz))
                        {
                            throw new Exception("No se ha podido realizar el envío, no se han agregado voces señaladas a alguna de las autoridades.");
                        }
                        else
                        {
                            if (Convert.ToInt32(sAutoridadesSinVoz) > 0)
                            {
                                throw new Exception("No se ha podido realizar el envío, no se han agregado voces señaladas a alguna de las autoridades.");
                            }
                        }

                        SendSolicitud(solicitudId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        protected void RegresarButton_Click(object sender, EventArgs e)
        {
            string sSolicitudId = hdnSolicitudId.Value;
            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + sSolicitudId);
        }
    }
}