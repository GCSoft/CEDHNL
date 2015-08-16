/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAgregarIndicadores
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
using GCUtility.Function;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueAgregarIndicadores : System.Web.UI.Page
	{


		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas el programador

		void InsertSolicitudIndicador() {
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			BPQueja oBPQueja = new BPQueja();
			DataRow rowIndicador;

			try
			{
				
				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Indicadores seleccionados
				oENTQueja.tblIndicador = new DataTable("tblIndicador");
				oENTQueja.tblIndicador.Columns.Add("IndicadorId", typeof(Int32));

				// Listado de Indicadores
				for (int k = 0; k < this.chkIndicadorGenero.Items.Count; k++) {

					if(this.chkIndicadorGenero.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorGenero.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				for (int k = 0; k < this.chkIndicadorEdad.Items.Count; k++) {

					if(this.chkIndicadorEdad.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorEdad.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				for (int k = 0; k < this.chkIndicadorActividad.Items.Count; k++) {

					if(this.chkIndicadorActividad.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorActividad.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				for (int k = 0; k < this.chkIndicadorCondicion.Items.Count; k++) {

					if(this.chkIndicadorCondicion.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorCondicion.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				for (int k = 0; k < this.chkIndicadorComunidades.Items.Count; k++) {

					if(this.chkIndicadorComunidades.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorComunidades.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				for (int k = 0; k < this.chkIndicadorVictimas.Items.Count; k++) {

					if(this.chkIndicadorVictimas.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorVictimas.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				for (int k = 0; k < this.chkIndicadorTemas.Items.Count; k++) {

					if(this.chkIndicadorTemas.Items[k].Selected){

						rowIndicador = oENTQueja.tblIndicador.NewRow();
						rowIndicador["IndicadorId"] = this.chkIndicadorTemas.Items[k].Value;
						oENTQueja.tblIndicador.Rows.Add(rowIndicador);
					}
				}

				// Transacción
				oENTResponse = oBPQueja.InsertSolicitudIndicador(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectIndicadores(){
			BPIndicador oBPIndicador = new BPIndicador();
			ENTIndicador oENTIndicador = new ENTIndicador();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTIndicador.IndicadorId = 0;
				oENTIndicador.IndicadorGrupoId = 0;
				oENTIndicador.Nombre = "";

				// Transacción
				oENTResponse = oBPIndicador.SelectIndicador(oENTIndicador);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Listado de Indicadores de Género
				this.chkIndicadorGenero.DataTextField = "IndicadorNombre";
				this.chkIndicadorGenero.DataValueField = "IndicadorId";
				this.chkIndicadorGenero.DataSource = oENTResponse.dsResponse.Tables[2];
				this.chkIndicadorGenero.DataBind();

				// Listado de Indicadores de Edad
				this.chkIndicadorEdad.DataTextField = "IndicadorNombre";
				this.chkIndicadorEdad.DataValueField = "IndicadorId";
				this.chkIndicadorEdad.DataSource = oENTResponse.dsResponse.Tables[3];
				this.chkIndicadorEdad.DataBind();

				// Listado de Indicadores de Actividad
				this.chkIndicadorActividad.DataTextField = "IndicadorNombre";
				this.chkIndicadorActividad.DataValueField = "IndicadorId";
				this.chkIndicadorActividad.DataSource = oENTResponse.dsResponse.Tables[4];
				this.chkIndicadorActividad.DataBind();

				// Listado de Indicadores de Condición
				this.chkIndicadorCondicion.DataTextField = "IndicadorNombre";
				this.chkIndicadorCondicion.DataValueField = "IndicadorId";
				this.chkIndicadorCondicion.DataSource = oENTResponse.dsResponse.Tables[5];
				this.chkIndicadorCondicion.DataBind();

				// Listado de Indicadores de Comunidades
				this.chkIndicadorComunidades.DataTextField = "IndicadorNombre";
				this.chkIndicadorComunidades.DataValueField = "IndicadorId";
				this.chkIndicadorComunidades.DataSource = oENTResponse.dsResponse.Tables[6];
				this.chkIndicadorComunidades.DataBind();

				// Listado de Indicadores de Victimas
				this.chkIndicadorVictimas.DataTextField = "IndicadorNombre";
				this.chkIndicadorVictimas.DataValueField = "IndicadorId";
				this.chkIndicadorVictimas.DataSource = oENTResponse.dsResponse.Tables[7];
				this.chkIndicadorVictimas.DataBind();

				// Listado de Indicadores de Temas
				this.chkIndicadorTemas.DataTextField = "IndicadorNombre";
				this.chkIndicadorTemas.DataValueField = "IndicadorId";
				this.chkIndicadorTemas.DataSource = oENTResponse.dsResponse.Tables[8];
				this.chkIndicadorTemas.DataBind();


			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectSolicitud(){
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
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();

				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Seleccionar indicadores
				for (int k = 0; k < this.chkIndicadorGenero.Items.Count; k++) {
					this.chkIndicadorGenero.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorGenero.Items[k].Value).Length == 0 ? false : true); 
				}

				for (int k = 0; k < this.chkIndicadorEdad.Items.Count; k++) {
					this.chkIndicadorEdad.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorEdad.Items[k].Value).Length == 0 ? false : true); 
				}

				for (int k = 0; k < this.chkIndicadorActividad.Items.Count; k++) {
					this.chkIndicadorActividad.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorActividad.Items[k].Value).Length == 0 ? false : true); 
				}

				for (int k = 0; k < this.chkIndicadorCondicion.Items.Count; k++) {
					this.chkIndicadorCondicion.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorCondicion.Items[k].Value).Length == 0 ? false : true); 
				}

				for (int k = 0; k < this.chkIndicadorComunidades.Items.Count; k++) {
					this.chkIndicadorComunidades.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorComunidades.Items[k].Value).Length == 0 ? false : true); 
				}

				for (int k = 0; k < this.chkIndicadorVictimas.Items.Count; k++) {
					this.chkIndicadorVictimas.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorVictimas.Items[k].Value).Length == 0 ? false : true); 
				}

				for (int k = 0; k < this.chkIndicadorTemas.Items.Count; k++) {
					this.chkIndicadorTemas.Items[k].Selected = (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorTemas.Items[k].Value).Length == 0 ? false : true); 
				}

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
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

				// Consulta de indicadores
				SelectIndicadores();

				// Carátula
				SelectSolicitud();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Asignar el Defensor
				InsertSolicitudIndicador();

				// Regresar al detalle de la solicitud
				Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}


	}
}