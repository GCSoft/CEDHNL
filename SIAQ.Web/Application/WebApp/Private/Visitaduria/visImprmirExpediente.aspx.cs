/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visImprmirExpediente
' Autor:	Ruben.Cobos
' Fecha:	03-Septiembre-2014
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
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visImprmirExpediente : System.Web.UI.Page
    {
        
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();


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


		// Rutinas del programador

		void SelectExpediente() {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpediente_Detalle(oENTVisitaduria);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddExpedienteId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteId"].ToString();

				// Formulario
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();
				this.AreaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AreaNombre"].ToString();
				this.ResolucionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionNombre"].ToString();

				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaQuejasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaQuejas"].ToString();
				this.FechaVisitaduriasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaVisitadurias"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.TipoOrientacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionNombre"].ToString();
				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();
				this.FundamentoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

				// Cierre de Orientación
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString() != "3" ){
					this.CierreOrientacionLabel.Visible = false;
					this.TipoOrientacionLabel.Visible = false;
				}

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[2].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[2];
					this.grdCanalizacion.DataBind();
				}

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[3];
				this.gvCiudadano.DataBind();

				// Asuntos
				if (oENTResponse.dsResponse.Tables[5].Rows.Count == 0){

					this.SinComentariosLabel.Text = "<br /><br />No hay asuntos para este Expediente";
					this.repComentarios.DataSource = null;
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = "";
				}else{

					this.SinComentariosLabel.Text = "";
					this.repComentarios.DataSource = oENTResponse.dsResponse.Tables[5];
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = oENTResponse.dsResponse.Tables[5].Rows.Count.ToString() + " asuntos";
				}

				// Grupos Minoritarios
				this.chkIndicadores.DataTextField = "Nombre";
				this.chkIndicadores.DataValueField = "IndicadorId";
				this.chkIndicadores.DataSource = oENTResponse.dsResponse.Tables[7];
				this.chkIndicadores.DataBind();

				for (int k = 0; k < this.chkIndicadores.Items.Count; k++) {

					this.chkIndicadores.Items[k].Selected = true;
					this.chkIndicadores.Items[k].Enabled = false;
				}

				// Diligencias
				this.gvDiligencia.DataSource = oENTResponse.dsResponse.Tables[8];
				this.gvDiligencia.DataBind();

				// Gestión
				this.gvSeguimiento.DataSource = oENTResponse.dsResponse.Tables[12];
				this.gvSeguimiento.DataBind();

				// Autoridades y Voces
				this.gvAutoridades.DataSource = oENTResponse.dsResponse.Tables[10];
				this.gvAutoridades.DataBind();

				// Recomendaciones
				this.gvRecomendacion.DataSource = oENTResponse.dsResponse.Tables[11];
				this.gvRecomendacion.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectRecomendacion_Detalle(ref GridView grdDetalle, Int32 RecomendacionId){
            BPRecomendacion oBPRecomendacion = new BPRecomendacion();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTRecomendacion.RecomendacionId = RecomendacionId;

				// Transacción
				oENTResponse = oBPRecomendacion.SelectRecomendacion_ByID(oENTRecomendacion);

				// Errores
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Llenado de control
				grdDetalle.DataSource = oENTResponse.dsResponse.Tables[2];
				grdDetalle.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
        }

		void SelectVoz_Detalle(ref GridView grdDetalle, Int32 AutoridadId){
            BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = AutoridadId;

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridadVoces(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado de control
				grdDetalle.DataSource = oENTResponse.dsResponse.Tables[0];
				grdDetalle.DataBind();

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

				// Obtener ExpedienteId
				this.hddExpedienteId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Carátula
				SelectExpediente();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visDetalleExpediente.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e){
			Panel oPanelDetail = null;
			GridView grdVocesAgregadas = null;
			String AutoridadId = "";

            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // DataKeys
                AutoridadId = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();

				// Sólo autoridades
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");

				// Voces Agregadas
				grdVocesAgregadas = new GridView();
				grdVocesAgregadas = (GridView)e.Row.FindControl("gvVocesDetalle");
				SelectVoz_Detalle(ref grdVocesAgregadas, Int32.Parse(AutoridadId));
				oPanelDetail.Visible = true;

            }catch (Exception ex){
                throw (ex);
            }
        }

		protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
			Panel oPanelDetail = null;
			GridView gvRecomendacionDetalle = null;
			String RecomendacionId = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// DataKeys
				RecomendacionId = gvRecomendacion.DataKeys[e.Row.RowIndex]["RecomendacionId"].ToString();

				// Sólo autoridades
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");

				// Voces Agregadas
				gvRecomendacionDetalle = new GridView();
				gvRecomendacionDetalle = (GridView)e.Row.FindControl("gvRecomendacionDetalle");
				SelectRecomendacion_Detalle(ref gvRecomendacionDetalle, Int32.Parse(RecomendacionId));
				oPanelDetail.Visible = true;

			}catch (Exception ex){
				throw (ex);
			}
		}

    }
}