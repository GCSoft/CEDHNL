/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segEnviarAutoridad
' Autor:	Ruben.Cobos
' Fecha:	28-Octubre-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCUtility.Function;
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segEnviarAutoridad : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();


		// Funciones del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}


		// Rutinas el programador

		void SelectRecomendacion() {
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);

				// Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacion_Detalle(oENTSeguimiento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Encabezados y Títulos dinámicos
				this.lblEncabezado.Text = "Enviar  " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "la recomendación a la Autoridad" : "el acuerdo de no responsabilidad a la Autoridad");
				this.lblNumero.Text = (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "Recomendación" : "Acuerdo") + " Número";
				this.GridLabel.Text = "Gestión de " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "la recomendación" : "el acuerdo de no responsabilidad");
				this.lblActionTitle.Text = "Envío de " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "recomendación" : "acuerdo de no responsabilidad");

				// Formulario
				this.RecomendacionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["RecomendacionNumero"].ToString();
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();

				this.TipoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoNombre"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.NombreAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreAutoridad"].ToString();
				this.PuestoAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["PuestoAutoridad"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaQuejasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaQuejas"].ToString();
				this.FechaVisitaduriasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaVisitadurias"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.NivelesAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Autoridades"].ToString();

				// Grid
				this.gvGestion.DataSource = oENTResponse.dsResponse.Tables[6];
				this.gvGestion.DataBind();

				// Validaciones
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoId"].ToString() != "2"){

					// Si no esta en Proceso no podra enviar el documento a la autoridad
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}else{

					this.btnEnviar.Enabled = true;
					this.btnEnviar.CssClass = "Button_General";
				}

				if (oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoId"].ToString() != "3"){

					// Si no esta en Tiempo De Ser Contestada no podra registrar la respuesta
					this.btnRespuesta.Enabled = false;
					this.btnRespuesta.CssClass = "Button_General_Disabled";
				}else{

					this.btnRespuesta.Enabled = true;
					this.btnRespuesta.CssClass = "Button_General";
				}
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectRespuesta(){
			try
			{

				this.ddlPopUpRespuesta.Items.Insert(0, new ListItem("No Aceptada", "0"));
				this.ddlPopUpRespuesta.Items.Insert(0, new ListItem("Aceptada", "1"));
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateRecomendacion_EnviarAutoridad() {
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession oENTSession = new ENTSession();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{

			    // Validaciones
			    if (this.ckeEnvio.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle en el envío")); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }
				
			    // Formulario
			    oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.ModuloId = 4; // Seguimientos
				oENTSeguimiento.UsuarioId = oENTSession.idUsuario;
				oENTSeguimiento.Fecha = this.calFechaEnvio.DisplayDate;
				oENTSeguimiento.Comentario = this.ckeEnvio.Text.Trim();

			    // Transacción
				oENTResponse = oBPSeguimiento.UpdateRecomendacion_EnvioAutoridad(oENTSeguimiento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void UpdateRecomendacion_EnviarAutoridadCierre() {
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession oENTSession = new ENTSession();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{

			    // Validaciones
			    if (this.ckeRespuesta.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle en el envío")); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }
				
			    // Formulario
			    oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.ModuloId = 4; // Seguimientos
				oENTSeguimiento.UsuarioId = oENTSession.idUsuario;
				oENTSeguimiento.Fecha = this.calFechaRespuesta.DisplayDate;
				oENTSeguimiento.Aceptada = Int16.Parse(this.ddlPopUpRespuesta.SelectedItem.Value);
				oENTSeguimiento.Comentario = this.ckeRespuesta.Text.Trim();

			    // Transacción
				oENTResponse = oBPSeguimiento.UpdateRecomendacion_EnvioAutoridadCierre(oENTSeguimiento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
			    throw (ex);
			}
		}



		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener RecomendacionId
				this.hddRecomendacionId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Carátula
				SelectRecomendacion();

				// Estado incial de los controles
				SelectRespuesta();
				this.calFechaEnvio.SetCurrentDate();
				this.calFechaRespuesta.SetCurrentDate();

				this.ddlPopUpRespuesta.SelectedIndex = 0;

				this.pnlEnvio.Visible = false;
				this.pnlRespuesta.Visible = false;

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnEnviar_Click(object sender, EventArgs e){
			try
            {

				// Mostrar panel de envío
				this.pnlEnvio.Visible = true;
				this.ckeEnvio.Focus();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRespuesta_Click(object sender, EventArgs e){
			try
            {

				// Mostrar panel de envío
				this.pnlRespuesta.Visible = true;
				this.ckeRespuesta.Focus();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segDetalleRecomendacion.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void gvGestion_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }


				// Atributos Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

				// Atributos Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");


			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvGestion_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvGestion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}



		// Eventos de PopUp de envio

		protected void btnPopUpEnviar_Click(object sender, EventArgs e){
			try
			{

				UpdateRecomendacion_EnviarAutoridad();
				SelectRecomendacion();
				this.pnlEnvio.Visible = false;

			}catch (Exception ex){
				this.lblActionMessageEnvio.Text = ex.Message;
				this.ckeEnvio.Focus();
			}
		}

		protected void imgCloseEnvioWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Cancelar transacción
				this.calFechaEnvio.SetCurrentDate();
				this.ckeEnvio.Text = "";
				this.pnlEnvio.Visible = false;

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		// Eventos de PopUp de respuesta

		protected void btnPopUpRespuesta_Click(object sender, EventArgs e){
			try
			{

				UpdateRecomendacion_EnviarAutoridadCierre();
				SelectRecomendacion();
				this.pnlRespuesta.Visible = false;

			}catch (Exception ex){
				this.lblActionMessageRespuesta.Text = ex.Message;
				this.ckeRespuesta.Focus();
			}
		}

		protected void imgCloseRespuestaWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Cancelar transacción
				this.calFechaRespuesta.SetCurrentDate();
				this.ddlPopUpRespuesta.SelectedIndex = 0;
				this.ckeRespuesta.Text = "";
				this.pnlRespuesta.Visible = false;

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

	}
}