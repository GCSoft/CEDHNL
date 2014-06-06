/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segDetalleExpediente
' Autor:	Ruben.Cobos
' Fecha:	02-Junio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segDetalleExpediente : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void InsertComentarioSeguimiento() {
			ENTSession SessionEntity = new ENTSession();
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Validaciones
			if (this.ckeComentario.Text.Trim() == "") { throw( new Exception("Es necesario ingresar un comentario")); }

			// Obtener sesión
			SessionEntity = (ENTSession)Session["oENTSession"];

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value.Trim());
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.UsuarioId = SessionEntity.idUsuario;
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.Comentario = this.ckeComentario.Text.Trim();

			// Transacción
			BPSeguimientoRecomendacion.InsertComentarioSeguimiento();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

		}

		void SelectedExpediente() {
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value );

			// Transacción
			BPSeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

			// No se encontró el expediente
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count == 0){ throw (new Exception("No se encontro el expediente")); }

			// Campos ocultos
			this.EstatusIdHidden.Value = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["EstatusId"].ToString();
			this.FuncionarioIdHidden.Value = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FuncionarioId"].ToString();

			// Formulario
			this.ExpedienteNumeroLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["ExpedienteNumero"].ToString();
			this.CalificacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["CalificacionNombre"].ToString();
			this.EstatusLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["EstatusNombre"].ToString();
			this.TipoSolicitudLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["TipoSolicitudNombre"].ToString();
			this.DefensorLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DefensorNombre"].ToString();

			this.FechaRecepcionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaRecepcion"].ToString();
			this.FechaAsignacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaAsignacion"].ToString();
			this.FechaInicioLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaInicioGestion"].ToString();
			this.FechaUltimaLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaUltimaModificacion"].ToString();

			this.ObservacionesLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
			this.LugarHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["LugarHechosNombre"].ToString();
			this.DireccionHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

			// Grid
			this.gvRecomendacion.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[1];
			this.gvRecomendacion.DataBind();

			// Documentos
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[2].Rows.Count == 0) {

				this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados a la solicitud";
			} else {

				this.SinDocumentoLabel.Text = "";
				this.dlstDocumentoList.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[2];
				this.dlstDocumentoList.DataBind();
			}

			// Comentarios
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[3].Rows.Count == 0) {

				this.SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
			} else {

				this.SinComentariosLabel.Text = "";
				this.repComentarios.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[3];
				this.repComentarios.DataBind();
				this.ComentarioTituloLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[3].Rows.Count.ToString() + " comentarios";
			}

		}

		void SetPermisosGenerales(Int32 idRol) {
			try
            {

				// Permisos por rol
				switch (idRol){

					case 1:	// System Administrator
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;

					case 2:	// Administrador
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;

					case 10:	// Seguimiento - Secretaria
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = false;
						this.NotificacionesPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.CerrarExpedientePanel.Visible = false;
						this.ConfirmarCierreExpedientePanel.Visible = false;
						break;

					case 11:	// Seguimiento - Defensor
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = false;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = false;
						break;

					case 12:	// Seguimiento - Director
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = false;
						this.NotificacionesPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.CerrarExpedientePanel.Visible = false;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;

					default:
						this.InformacionPanel.Visible = false;
						this.AsignarPanel.Visible = false;
						this.SeguimientoPanel.Visible = false;
						this.NotificacionesPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.CerrarExpedientePanel.Visible = false;
						this.ConfirmarCierreExpedientePanel.Visible = false;
						break;

				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		void SetPermisosParticulares(Int32 idRol, Int32 FuncionarioId) {
			try
            {

				// Si es Defensor pero el expediente no está asignado a él no lo podrá operar
				if (idRol == 11 && Int32.Parse(this.FuncionarioIdHidden.Value) != FuncionarioId) {
					this.SeguimientoPanel.Visible = false;
					this.NotificacionesPanel.Visible = false;
					this.DiligenciaPanel.Visible = false;
					this.CerrarExpedientePanel.Visible = false;
				}

				// Si es Director y el expediente no está en estatus de confirmación de cierre ocultar dicha opción
				if (idRol == 12 && Int32.Parse(this.EstatusIdHidden.Value) != 8) {
					this.ConfirmarCierreExpedientePanel.Visible = false;
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

				// Obtener ExpedienteId
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				switch (this.SenderId.Value)
				{
					case "1": // Invocado desde [Listado de Expedientes]
						this.Sender.Value = "segListadoExpediente.aspx";
						break;

					case "2": // Invocado desde [Búsqueda de Expedientes]
						this.Sender.Value = "segBusquedaExpediente.aspx";
						break;

					case "3": // Invocado desde [Listado de Expedientes pendientes por aprobar su cierre]
						this.Sender.Value = "segListadoExpedienteAprobacion.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Consultar detalle de expediente
				SelectedExpediente();

				// Seguridad
				SetPermisosGenerales(SessionEntity.idRol);
				SetPermisosParticulares(SessionEntity.idRol, SessionEntity.FuncionarioId);


            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}

		protected void dlstDocumentoList_ItemDataBound(Object sender, DataListItemEventArgs e){
			Label DocumentoLabel;
			Image DocumentoImage;
			DataRowView DataRow;

			try
			{

				// Validación de que sea Item 
				if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

				// Obtener controles
				DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
				DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");
				DataRow = (DataRowView)e.Item.DataItem;

				// Configurar imagen
				DocumentoLabel.Text = DataRow["NombreDocumento"].ToString();

				DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
				DocumentoImage.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
				DocumentoImage.Attributes.Add("onmouseout", "this.style.cursor='auto'");
				DocumentoImage.Attributes.Add("onclick", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=0" + "');");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e){
			String RecomendacionId;

			String strCommand = "";
			Int32 intRow = 0;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				RecomendacionId = this.gvRecomendacion.DataKeys[intRow]["RecomendacionId"].ToString();

				// Acción
				switch (strCommand){
					case "Editar":
						this.Response.Redirect("segSeguimientoRecomendacion.aspx.aspx?key=" + RecomendacionId, false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;

			String sNumero = "";
			String sImagesAttributes = "";
			String sToolTip = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

				// DataKeys
				sNumero = gvRecomendacion.DataKeys[e.Row.RowIndex]["iRow"].ToString();

				// Tooltip Editar Recomendacion
				sToolTip = "Seguimiento de Recomendacion [" + sNumero + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvRecomendacion_Sorting(object sender, GridViewSortEventArgs e){
			DataTable TableAutoridad = null;
			DataView ViewAutoridad = null;

			try
			{
				//Obtener DataTable y View del GridView
				TableAutoridad = utilFunction.ParseGridViewToDataTable(gvRecomendacion, false);
				ViewAutoridad = new DataView(TableAutoridad);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				ViewAutoridad.Sort = hddSort.Value;

				//Vaciar datos
				this.gvRecomendacion.DataSource = ViewAutoridad;
				this.gvRecomendacion.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		protected void lnkAgregarComentario_Click(object sender, EventArgs e){
			this.lblActionMessage.Text = "";
			this.ckeComentario.Text = "";
			this.ckeComentario.Focus();
			this.pnlAction.Visible = true;
		}


		// Opciones de Menu

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("segAsignarDefensor.aspx?key=" + this.ExpedienteIdHidden.Value.ToString() + "|" + this.SenderId.Value.ToString());
		}

		protected void CerrarExpedienteButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void ConfirmarCierreExpedienteButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			try {

				// Actualizar el expediente
				SelectedExpediente();

			}catch (Exception ex) {
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		protected void NotificacionesButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		
		// Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertComentarioSeguimiento();

				// Actualizar el expediente
				SelectedExpediente();

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