/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueEnviarSolicitud
' Autor:	Ruben.Cobos
' Fecha:	17-Julio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueEnviarSolicitud : System.Web.UI.Page
	{

		public string _SolicitudId;
		Function utilFunction = new Function();

		void SelectSolicitud()
		{
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Detalle(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		#region "Events"
		protected void SendButton_Click(object sender, EventArgs e)
		{
			try
			{
				string sSolicitudId = hddSolicitudId.Value;
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

		private void PageLoad(){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Carátula
				SelectSolicitud();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
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
				Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);

			}
			catch (Exception ex)
			{
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
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

	}
}