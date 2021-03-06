﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueDetalleSolicitud
' Ajuste:	Ruben.Cobos
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
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueDetalleSolicitud : System.Web.UI.Page
	{
		

		// Utilerías

		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void CheckDeleteLinkComentario(){
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Si es Funcionario y el expediente está asignado a el puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (SessionEntity.idRol == 5 && Int32.Parse(this.hddFuncionarioId.Value) == SessionEntity.FuncionarioId){
					if (Int32.Parse(this.hddEstatusId.Value) != 4){

						foreach (RepeaterItem repItem in repComentarios.Items){
							LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
							oLinkButton.Visible = true;
						}

					}
				}

				// Si es Administrador puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (SessionEntity.idRol == 1 || SessionEntity.idRol == 2){
					if (Int32.Parse(this.hddEstatusId.Value) != 4){

						foreach (RepeaterItem repItem in repComentarios.Items){
							LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
							oLinkButton.Visible = true;
						}

					}
				}

			}catch(Exception ex){
				throw(ex);
			}
		}

		void DeleteSolicitudComentario(Int32 ComentarioId) {
			BPQueja oBPQueja = new BPQueja();

			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				
				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.ComentarioId = ComentarioId;

				// Transacción
				oENTResponse = oBPQueja.DeleteSolicitudComentario(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertSolicitudComentario() {
			BPQueja oBPQueja = new BPQueja();

			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Validaciones
				if (this.ckeComentario.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un comentario")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.UsuarioId = SessionEntity.idUsuario;
				oENTQueja.Comentario = this.ckeComentario.Text.Trim();
				oENTQueja.MedidaPreventiva = Int16.Parse((this.chkMedidaPreventiva.Checked ? 1 : 0).ToString());

				// Transacción
				oENTResponse = oBPQueja.InsertSolicitudComentario(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectSolicitud() {
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

				// Campos ocultos
				this.hddEstatusId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusId"].ToString();
				this.hddFuncionarioId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioId"].ToString();
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
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.TipoOrientacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionNombre"].ToString();
				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Cierre de Orientación
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString() != "3" ){
					this.CierreOrientacionLabel.Visible = false;
					this.TipoOrientacionLabel.Visible = false;
				}

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[7].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[7];
					this.grdCanalizacion.DataBind();
				}

				// Calificacion
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.FundamentoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

				// Grid
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvCiudadano.DataBind();

				// Documentos
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados a la solicitud";
				}else{

					this.SinDocumentoLabel.Text = "";
					this.dlstDocumentoList.DataSource = oENTResponse.dsResponse.Tables[3];
					this.dlstDocumentoList.DataBind();
				}

				// Asuntos
				if (oENTResponse.dsResponse.Tables[4].Rows.Count == 0){

					this.SinComentariosLabel.Text = "<br /><br />No hay asuntos para esta solicitud";
					this.repComentarios.DataSource = null;
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = "";
				}else{

					this.SinComentariosLabel.Text = "";
					this.repComentarios.DataSource = oENTResponse.dsResponse.Tables[4];
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = oENTResponse.dsResponse.Tables[4].Rows.Count.ToString() + " asuntos";

					CheckDeleteLinkComentario();

				}


			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetPermisosGenerales(Int32 idRol) {
			try
            {

				// Permisos por rol
				switch (idRol){

					case 1:	// System Administrator
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.CiudadanoPanel.Visible = true;
						this.AtencionVictimasPanel.Visible = true;
						this.CalificarPanel.Visible = true;
						this.AutoridadPanel.Visible = true;
						this.DiligenciasPanel.Visible = true;
						this.IndicadorPanel.Visible = true;
						this.DocumentoPanel.Visible = true;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = true;
						break;

					case 2:	// Administrador
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.CiudadanoPanel.Visible = true;
						this.AtencionVictimasPanel.Visible = true;
						this.CalificarPanel.Visible = true;
						this.AutoridadPanel.Visible = true;
						this.DiligenciasPanel.Visible = true;
						this.IndicadorPanel.Visible = true;
						this.DocumentoPanel.Visible = true;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = true;
						break;

					case 3:	// Recepción
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.CiudadanoPanel.Visible = true;
						this.AtencionVictimasPanel.Visible = false;
						this.CalificarPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.DiligenciasPanel.Visible = false;
						this.IndicadorPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = false;
						break;

					case 4:	// Quejas - Secretaria
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.CiudadanoPanel.Visible = true;
						this.AtencionVictimasPanel.Visible = false;
						this.CalificarPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.DiligenciasPanel.Visible = false;
						this.IndicadorPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = false;
						break;

					case 5:	// Quejas - Funcionario
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = false;
						this.AsignarPanel.Visible = false;
						this.CiudadanoPanel.Visible = true;
						this.AtencionVictimasPanel.Visible = true;
						this.CalificarPanel.Visible = true;
						this.AutoridadPanel.Visible = true;
						this.DiligenciasPanel.Visible = true;
						this.IndicadorPanel.Visible = true;
						this.DocumentoPanel.Visible = true;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = true;
						break;

					case 6:	// Quejas - Director
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.CiudadanoPanel.Visible = false;
						this.AtencionVictimasPanel.Visible = false;
						this.CalificarPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.DiligenciasPanel.Visible = false;
						this.IndicadorPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = false;
						break;

					default:
						this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = false;
						this.AsignarPanel.Visible = false;
						this.CiudadanoPanel.Visible = false;
						this.AtencionVictimasPanel.Visible = false;
						this.CalificarPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.DiligenciasPanel.Visible = false;
						this.IndicadorPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = false;
						break;

				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		void SetPermisosParticulares(Int32 idRol, Int32 FuncionarioId) {
			try
            {

				// Si es Funcionario pero el expediente no está asignado a él no lo podrá operar
				if (idRol == 5 && Int32.Parse(this.hddFuncionarioId.Value) != FuncionarioId) {
					this.AgregrarInformacionPanel.Visible = false;
					this.CiudadanoPanel.Visible = false;
					this.AtencionVictimasPanel.Visible = false;
					this.CalificarPanel.Visible = false;
					this.AutoridadPanel.Visible = false;
					this.DiligenciasPanel.Visible = false;
					this.IndicadorPanel.Visible = false;
					this.DocumentoPanel.Visible = false;
					this.EnviarPanel.Visible = false;
				}

				// Si no es Secretaria o Director y el expediente ya está asignado a un funcionario no puede agregar información
				if (idRol != 1 && idRol != 2 && idRol != 4 && idRol != 6 && Int32.Parse(this.hddFuncionarioId.Value) != 0){
					this.AgregrarInformacionPanel.Visible = false;
				}

				// Si es Secretaria y el expediente ya está asignado a un funcionario no puede agregar ciudadanos
				if (idRol == 3 && Int32.Parse(this.hddFuncionarioId.Value) != 0) {
					this.CiudadanoPanel.Visible = false;
				}

				// Si es Secretaria y el expediente ya está asignado a un funcionario no puede agregar ciudadanos
				if (idRol == 4 && Int32.Parse(this.hddFuncionarioId.Value) != 0) {
					this.CiudadanoPanel.Visible = false;
				}

				// Si es Funcionario y el expediente está asignado a el puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (idRol == 5 && Int32.Parse(this.hddFuncionarioId.Value) == FuncionarioId) {
					if (Int32.Parse(this.hddEstatusId.Value) != 4) { 
						
						this.lnkAgregarComentario.Visible = true;
					}
				}

				// Si es Administrador puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (idRol == 1 || idRol == 2) {
					if (Int32.Parse(this.hddEstatusId.Value) != 4) { 
						
						this.lnkAgregarComentario.Visible = true;
					}
				}

				//// Si la calificación no es Queja ( CalficacionId = 2 ) o Medidas Cautelares ( CalficacionId = 8 ) no puede agregar autoridades y voces
				//if ( this.hddCalificacionId.Value != "2" && this.hddCalificacionId.Value != "8" ) {
				//    this.AutoridadPanel.Visible = false;
				//}

				// El expiente no se podrá operar en los siguientes Estatus (de Solicitud):
				// 4  - Pendiente de aprobar Queja
				// 5  - Por asignar a funcionario de Visitadurías
				// 22 - Cerrada como Orientación
				// 23 - Proyecto Aprobado
				// 24 - Por asignar a funcionario de DORC
				if ( Int32.Parse(this.hddEstatusId.Value) == 4 || Int32.Parse(this.hddEstatusId.Value) == 5|| Int32.Parse(this.hddEstatusId.Value) == 22  || Int32.Parse(this.hddEstatusId.Value) == 23 || Int32.Parse(this.hddEstatusId.Value) == 24 ){
					this.AgregrarInformacionPanel.Visible = false;
					this.AsignarPanel.Visible = false;
					this.CiudadanoPanel.Visible = false;
					this.AtencionVictimasPanel.Visible = false;
					this.CalificarPanel.Visible = false;
					this.AutoridadPanel.Visible = false;
					this.DiligenciasPanel.Visible = false;
					this.IndicadorPanel.Visible = false;
					this.DocumentoPanel.Visible = false;
					this.EnviarPanel.Visible = false;
				}

            }catch (Exception ex){
				throw(ex);
            }
		}

		
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			ENTSession SessionEntity = new ENTSession();

            try
            {

                // Validaciones
                if (Page.IsPostBack) { return; }
                if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
                if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener AtencionId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
                this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

                switch (this.SenderId.Value){
					case "1": // Invocado desde [Listado de Solicitudes]
						this.Sender.Value = "QueListadoSolicitudes.aspx";
                        break;

					case "2": // // Invocado desde [Búsqueda de Solicitudes]
						this.Sender.Value = "QueBusquedaSolicitudes.aspx";
						break;

					case "3": // // Invocado desde [Registrar solicitud ]
						this.Sender.Value = "../Operation/opeRegistroSolicitud.aspx?key=0|0";
						break;

					case "4": // // Invocado desde [Solicitudes en Proceso]
						this.Sender.Value = "QueListadoSolicitudesEnProceso.aspx";
						break;

                    default:
                        this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
                        return;
                }

                // Obtener sesión
                SessionEntity = (ENTSession)Session["oENTSession"];

                // Consultar detalle de la Solicitud de Quejas
				SelectSolicitud();

                // Seguridad
                SetPermisosGenerales(SessionEntity.idRol);
                SetPermisosParticulares(SessionEntity.idRol, SessionEntity.FuncionarioId);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
            Response.Redirect(this.Sender.Value);
        }

		protected void dlstDocumentoList_ItemDataBound(Object sender, DataListItemEventArgs e){
			Label DocumentoLabel;
            Image DocumentoImage;
            DataRowView DataRow;

			String DocumentoId = "";
			String sKey = "";

            try
            {

                // Validación de que sea Item 
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

                // Obtener controles
                DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
                DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");
                DataRow = (DataRowView)e.Item.DataItem;

				// Id del documento
				DocumentoId = DataRow["DocumentoId"].ToString();
				sKey = gcEncryption.EncryptString(DocumentoId, true);

                // Configurar imagen
				DocumentoLabel.Text = DataRow["NombreDocumentoCorto"].ToString();

				DocumentoImage.ImageUrl = "~/Include/Image/Icon/" + DataRow["Icono"].ToString();
				DocumentoImage.ToolTip = DataRow["NombreDocumento"].ToString();
                DocumentoImage.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                DocumentoImage.Attributes.Add("onmouseout", "this.style.cursor='auto'");
				DocumentoImage.Attributes.Add("onclick", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?key=" + sKey + "');");

            }catch (Exception ex){
                throw (ex);
            }
        }

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void lnkAgregarComentario_Click(object sender, EventArgs e){
            this.lblActionMessage.Text = "";
            this.ckeComentario.Text = "";
            this.ckeComentario.Focus();
            this.pnlAction.Visible = true;
        }

		protected void lnkEliminarComentario_Click(object sender, CommandEventArgs  e){
			try
            {

				// Eliminar el comentario
				DeleteSolicitudComentario(Int32.Parse(e.CommandArgument.ToString()));

				// Consultar el expediente
				SelectSolicitud();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}


		// Opciones de Menu (por orden de aparación)

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			try
            {

				// Consultar el expediente
				SelectSolicitud();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void AgregrarInformacionButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAgregrarInformacion.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAsignarFuncionario.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void CiudadanoButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAgregarCiudadanos.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value + "|0");
		}

		protected void AtencionVictimasButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAtencionVictimas.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void CalificarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueCalificarSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void AutoridadButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAgregarAutoridadSenalada.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void DiligenciaPanel_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueDiligenciaSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void IndicadorButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAgregarIndicadores.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void DocumentoButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueAgregarDocumentos.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void ImprimirButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueImprimirSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}
		
		protected void EnviarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueEnviarSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}


		// Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertSolicitudComentario();

				// Actualizar el expediente
				SelectSolicitud();

				// Ocultar el panel
				this.pnlAction.Visible = false;

			}catch (Exception ex) {
				this.lblActionMessage.Text = ex.Message;
				this.ckeComentario.Focus();
			}
		}
		
		protected void CloseWindowButton_Click(object sender, ImageClickEventArgs e){
			this.pnlAction.Visible = false;
        }

	}
}