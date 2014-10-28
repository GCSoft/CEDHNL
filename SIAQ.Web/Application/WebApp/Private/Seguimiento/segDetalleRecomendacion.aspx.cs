/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    segDetalleRecomendacion
' Autor:		Ruben.Cobos
' Fecha:		14-Septiembre-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segDetalleRecomendacion : System.Web.UI.Page
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

		void CheckDeleteLinkComentario(){
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Si es Funcionario y el expediente está asignado a el puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (SessionEntity.idRol == 11 && Int32.Parse(this.hddFuncionarioId.Value) == SessionEntity.FuncionarioId){
					if (Int32.Parse(this.hddEstatusId.Value) == 10 || Int32.Parse(this.hddEstatusId.Value) == 11 ){

						foreach (RepeaterItem repItem in repComentarios.Items){
							LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
							oLinkButton.Visible = true;
						}

					}
				}

				// Si es Administrador puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (SessionEntity.idRol == 1 || SessionEntity.idRol == 2){
					if (Int32.Parse(this.hddEstatusId.Value) == 10 || Int32.Parse(this.hddEstatusId.Value) == 11 ){

						foreach (RepeaterItem repItem in repComentarios.Items){
							LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
							oLinkButton.Visible = true;
						}

					}
				}

				// Si no es un comentario del módulo de seguimientos hay que denegar la eliminación
				foreach (RepeaterItem repItem in repComentarios.Items){

					HiddenField oHiddenField = (HiddenField)repItem.FindControl("hddModuloId");
					if ( oHiddenField.Value != "4"  ){

						LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
						oLinkButton.Visible = false;
					}

				}

			}catch(Exception ex){
				throw(ex);
			}
		}

		void DeleteRecomendacionComentario(Int32 ComentarioId) {
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				
				// Formulario
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTSeguimiento.ModuloId = 4; // Visitadurías
				oENTSeguimiento.ComentarioId = ComentarioId;

				// Transacción
				oENTResponse = oBPSeguimiento.DeleteRecomendacionComentario(oENTSeguimiento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertRecomendacionComentario() {
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Validaciones
				if (this.ckeComentario.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un comentario")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTSeguimiento.ModuloId = 4; // Seguimiento
				oENTSeguimiento.UsuarioId = SessionEntity.idUsuario;
				oENTSeguimiento.Comentario = this.ckeComentario.Text.Trim();
				oENTSeguimiento.MedidaPreventiva = Int16.Parse((this.chkMedidaPreventiva.Checked ? 1 : 0).ToString());

				// Transacción
				oENTResponse = oBPSeguimiento.InsertRecomendacionComentario(oENTSeguimiento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

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

				// Campos ocultos
				this.hddEstatusId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusId"].ToString();
				this.hddExpedienteId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteId"].ToString();
				this.hddFuncionarioId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioId"].ToString();

				// Encabezado
				this.lblEncabezado.Text = "Detalle de " + ( oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "recomendación" : "acuerdo de no responsabilidad" );
				this.lblNumero.Text = (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "Recomendación" : "Acuerdo") + " Número";

				// Formulario
				this.RecomendacionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["RecomendacionNumero"].ToString();
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();

				this.TipoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Tipo"].ToString();
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

				// Puntos Resolutivos
				this.gvPuntosResolutivos.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvPuntosResolutivos.DataBind();

				// Documentos
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados al Expediente";
				}else{

					this.SinDocumentoLabel.Text = "";
					this.dlstDocumentoList.DataSource = oENTResponse.dsResponse.Tables[3];
					this.dlstDocumentoList.DataBind();
				}

				// Asuntos
				if (oENTResponse.dsResponse.Tables[4].Rows.Count == 0){

				    this.SinComentariosLabel.Text = "<br /><br />No hay asuntos para este Recomendacion";
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
			            this.SeguimientoPanel.Visible = true;
			            this.DocumentoPanel.Visible = true;
			            this.DiligenciaPanel.Visible = true;
			            this.pnlEnviarAtencion.Visible = true;
			            break;

			        case 2:	// Administrador
			            this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
			            this.AsignarPanel.Visible = true;
			            this.SeguimientoPanel.Visible = true;
			            this.DocumentoPanel.Visible = true;
			            this.DiligenciaPanel.Visible = true;
			            this.pnlEnviarAtencion.Visible = true;
			            break;

			        case 10:	// Seguimiento - Secretaria
			            this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
			            this.AsignarPanel.Visible = true;
			            this.SeguimientoPanel.Visible = false;
			            this.DocumentoPanel.Visible = false;
			            this.DiligenciaPanel.Visible = false;
			            this.pnlEnviarAtencion.Visible = false;
			            break;

			        case 11:	// Seguimiento - Defensor
			            this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = false;
			            this.AsignarPanel.Visible = false;
			            this.SeguimientoPanel.Visible = true;
			            this.DocumentoPanel.Visible = true;
			            this.DiligenciaPanel.Visible = true;
			            this.pnlEnviarAtencion.Visible = true;
			            break;

			        case 12:	// Seguimiento - Director
			            this.InformacionPanel.Visible = true;
						this.AgregrarInformacionPanel.Visible = true;
			            this.AsignarPanel.Visible = true;
			            this.SeguimientoPanel.Visible = false;
			            this.DocumentoPanel.Visible = false;
			            this.DiligenciaPanel.Visible = false;
			            this.pnlEnviarAtencion.Visible = false;
			            break;

			        default:
			            this.InformacionPanel.Visible = false;
						this.AgregrarInformacionPanel.Visible = false;
			            this.AsignarPanel.Visible = false;
			            this.SeguimientoPanel.Visible = false;
			            this.DocumentoPanel.Visible = false;
			            this.DiligenciaPanel.Visible = false;
			            this.pnlEnviarAtencion.Visible = false;
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
			    if (idRol == 11 && Int32.Parse(this.hddFuncionarioId.Value) != FuncionarioId) {
			        this.SeguimientoPanel.Visible = false;
			        this.DocumentoPanel.Visible = false;
			        this.DiligenciaPanel.Visible = false;
			        this.pnlEnviarAtencion.Visible = false;
			    }

				// Si aun no se ha agregado un número de recomendación no se puede operar
				if ( this.RecomendacionNumero.Text.Trim() == "" ){
					this.AsignarPanel.Visible = false;
					this.SeguimientoPanel.Visible = false;
					this.DocumentoPanel.Visible = false;
					this.DiligenciaPanel.Visible = false;
					this.pnlEnviarAtencion.Visible = false;
				}

				// Si ya se asignó un funcionario ya no podrá agregar el número de recomendación
				if( Int32.Parse(this.hddFuncionarioId.Value) != 0 ){
					this.AgregrarInformacionPanel.Visible = false;
				}

			    // Si el expediente está en estatus de confirmación de cierre no se podrá operar
			    if ( Int32.Parse(this.hddEstatusId.Value) == 8 ){
					this.AgregrarInformacionPanel.Visible = false;
			        this.AsignarPanel.Visible = false;
			        this.SeguimientoPanel.Visible = false;
			        this.DocumentoPanel.Visible = false;
			        this.DiligenciaPanel.Visible = false;
			        this.pnlEnviarAtencion.Visible = false;
			    }

			}catch (Exception ex){
			    throw(ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			ENTSession SessionEntity = new ENTSession();
			String sKey;

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
				this.hddRecomendacionId.Value = sKey.ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
				this.SenderId.Value = sKey.ToString().Split(new Char[] { '|' })[1];

                switch (this.SenderId.Value){
					case "1":
						this.Sender.Value = "segBusquedaRecomendacion.aspx";
                        break;

					case "2":
						this.Sender.Value = "segListadoRecomendaciones.aspx";
						break;

					case "3":
						this.Sender.Value = "segListadoRecomendacionesEnProceso.aspx";
						break;

                    default:
                        this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
                        return;
                }

				// Consultar detalle de la Solicitud de Quejas
				SelectRecomendacion();

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				//// Seguridad
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

		protected void gvPuntosResolutivos_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvPuntosResolutivos_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvPuntosResolutivos, ref this.hddSort, e.SortExpression);

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
				DeleteRecomendacionComentario(Int32.Parse(e.CommandArgument.ToString()));

				// Consultar el expediente
				SelectRecomendacion();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}


		// Opciones de Menu (en orden de aparición)

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			try {

				// Actualizar la recomendación
				SelectRecomendacion();

			}catch (Exception ex) {
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void AgregrarInformacionButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segAgregrarInformacion.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segAsignarDefensor.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segSeguimientoRecomendacion.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void DocumentoButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segAgregarDocumento.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segDiligenciaSeguimiento.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void EnviarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segEnviarRecomendacion.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		// Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertRecomendacionComentario();

				// Actualizar el expediente
				SelectRecomendacion();

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