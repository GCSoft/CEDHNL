/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueImprimirSolicitud
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
	public partial class QueImprimirSolicitud : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();

		
		// Funciones el programador

		void LlenarGridVoces_Detalle(ref GridView grdDetalle, Int32 SolicitudId, Int32 AutoridadId){
            BPSolicitud oBPSolicitud = new BPSolicitud();

            // Estado inicial del grid
            grdDetalle.DataSource = null;
            grdDetalle.DataBind();

            // Transacción
            oBPSolicitud.AutoridadEntity.SolicitudId = SolicitudId;
            oBPSolicitud.AutoridadEntity.AutoridadId = AutoridadId;
            oBPSolicitud.SelectSolicitudAutoridadVoces();

            // Validaciones
            if (oBPSolicitud.ErrorId != 0) { return; }

            // Listado de voces
            if (oBPSolicitud.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                grdDetalle.DataSource = oBPSolicitud.AutoridadEntity.dsResponse;
                grdDetalle.DataBind();
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
				oENTIndicador.Nombre = "";

				// Transacción
				oENTResponse = oBPIndicador.SelectIndicador(oENTIndicador);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Llenado de CheckBoxList
				this.chkIndicador.DataTextField = "Nombre";
				this.chkIndicador.DataValueField = "IndicadorId";
				this.chkIndicador.DataSource = oENTResponse.dsResponse.Tables[1];
				this.chkIndicador.DataBind();


			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectSolicitud_Cierre() {
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Cierre(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddCalificacionId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString();

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();

				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();

				this.TipoOrientacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionNombre"].ToString();
				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[7].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[7];
					this.grdCanalizacion.DataBind();
				}

				// Calificacion
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.FundamentoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvCiudadano.DataBind();

				// Comentarios
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
				}else{

					this.SinComentariosLabel.Text = "";
					this.repComentarios.DataSource = oENTResponse.dsResponse.Tables[3];
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = oENTResponse.dsResponse.Tables[3].Rows.Count.ToString() + " comentarios";
				}

				// Autoridad y voces señaladas
				if(this.hddCalificacionId.Value != "2" && this.hddCalificacionId.Value != "8" ){
					this.pnlAutoridades.Visible = false;
				}else{
					this.gvAutoridades.DataSource = oENTResponse.dsResponse.Tables[4];
					this.gvAutoridades.DataBind();
				}

				// Diligencias
				this.gvDiligencia.DataSource = oENTResponse.dsResponse.Tables[5];
				this.gvDiligencia.DataBind();

				// Seleccionar indicadores asociados a la solicitud
				for (int k = 0; k < this.chkIndicador.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicador.Items[k].Value).Length == 1) {
						this.chkIndicador.Items[k].Selected = true;
						this.chkIndicador.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicador.Items[k].Enabled = false;
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
				SelectSolicitud_Cierre();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e){
			GridView grdVocesAgregadas = null;
            Panel oPanelDetail = null;

			String AutoridadId = "";

            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// DataKeys
				AutoridadId = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();

				// Sólo autoridades
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");

				if (this.hddCalificacionId.Value == "8" ){

					oPanelDetail.Visible = false;
				}else{

					// Voces Agregadas
					grdVocesAgregadas = new GridView();
					grdVocesAgregadas = (GridView)e.Row.FindControl("gvVocesDetalle");
					LlenarGridVoces_Detalle(ref grdVocesAgregadas, Int32.Parse(this.hddSolicitudId.Value), Int32.Parse(AutoridadId));
					oPanelDetail.Visible = true;
				}

            }catch (Exception ex){
                throw (ex);
            }
        }

	}
}