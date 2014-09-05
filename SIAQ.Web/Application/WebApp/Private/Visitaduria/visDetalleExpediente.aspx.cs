/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    visDetalleExpediente
' Autor:		Ruben.Cobos
' Fecha:		15-Agosto-2014
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
    public partial class visDetalleExpediente : System.Web.UI.Page
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
				if (SessionEntity.idRol == 8 && Int32.Parse(this.hddFuncionarioId.Value) == SessionEntity.FuncionarioId){
					if (Int32.Parse(this.hddEstatusId.Value) == 6 || Int32.Parse(this.hddEstatusId.Value) == 7 ){

						foreach (RepeaterItem repItem in repComentarios.Items){
							LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
							oLinkButton.Visible = true;
						}

					}
				}

				// Si es Administrador puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (SessionEntity.idRol == 1 || SessionEntity.idRol == 2){
					if (Int32.Parse(this.hddEstatusId.Value) == 6 || Int32.Parse(this.hddEstatusId.Value) == 7 ){

						foreach (RepeaterItem repItem in repComentarios.Items){
							LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
							oLinkButton.Visible = true;
						}

					}
				}

				// Si no es un comentario del módulo de visitadurías hay que denegar la eliminación
				foreach (RepeaterItem repItem in repComentarios.Items){

					HiddenField oHiddenField = (HiddenField)repItem.FindControl("hddModuloId");
					if ( oHiddenField.Value != "3"  ){

						LinkButton oLinkButton = (LinkButton)repItem.FindControl("lnkEliminarComentario");
						oLinkButton.Visible = false;
					}

				}

			}catch(Exception ex){
				throw(ex);
			}
		}

		void DeleteExpedienteComentario(Int32 ComentarioId) {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();

			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				
				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.ModuloId = 3; // Visitadurías
				oENTVisitaduria.ComentarioId = ComentarioId;

				// Transacción
				oENTResponse = oBPVisitaduria.DeleteExpedienteComentario(oENTVisitaduria);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertExpedienteComentario() {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();

			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Validaciones
				if (this.ckeComentario.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un comentario")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.ModuloId = 3; // Visitadurías
				oENTVisitaduria.UsuarioId = SessionEntity.idUsuario;
				oENTVisitaduria.Comentario = this.ckeComentario.Text.Trim();
				oENTVisitaduria.MedidaPreventiva = Int16.Parse((this.chkMedidaPreventiva.Checked ? 1 : 0).ToString());

				// Transacción
				oENTResponse = oBPVisitaduria.InsertExpedienteComentario(oENTVisitaduria);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectExpediente(){
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
				this.hddEstatusId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusId"].ToString();
				this.hddFuncionarioId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioId"].ToString();
				this.hddTipoResolucionId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionId"].ToString();

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

				// Documentos
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados al Expediente";
				}else{

					this.SinDocumentoLabel.Text = "";
					this.dlstDocumentoList.DataSource = oENTResponse.dsResponse.Tables[4];
					this.dlstDocumentoList.DataBind();
				}

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

					CheckDeleteLinkComentario();

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
						this.AsignarPanel.Visible = true;
						//this.AcuerdoPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.DocumentoPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.ComparecenciaPanel.Visible = true;
						this.AutoridadPanel.Visible = true;
						this.ResolucionPanel.Visible = true;
						this.RecomendacionPanel.Visible = true;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = true;
						break;

					case 2:	// Administrador
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						//this.AcuerdoPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.DocumentoPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.ComparecenciaPanel.Visible = true;
						this.AutoridadPanel.Visible = true;
						this.ResolucionPanel.Visible = true;
						this.RecomendacionPanel.Visible = true;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = true;
						break;

					case 7:	// Visitaduría - Secretaria
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						//this.AcuerdoPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.SeguimientoPanel.Visible = false;
						this.ComparecenciaPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.ResolucionPanel.Visible = false;
						this.RecomendacionPanel.Visible = false;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = false;
						break;

					case 8:	// Visitaduría - Visitador
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = false;
						//this.AcuerdoPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.DocumentoPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.ComparecenciaPanel.Visible = true;
						this.AutoridadPanel.Visible = true;
						this.ResolucionPanel.Visible = true;
						this.RecomendacionPanel.Visible = true;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = true;
						break;

					case 9:	// Visitaduría - Director
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						//this.AcuerdoPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.SeguimientoPanel.Visible = false;
						this.ComparecenciaPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.ResolucionPanel.Visible = false;
						this.RecomendacionPanel.Visible = false;
						this.ImprimirPanel.Visible = true;
						this.EnviarPanel.Visible = false;
						break;

					default:
						this.InformacionPanel.Visible = false;
						this.AsignarPanel.Visible = false;
						//this.AcuerdoPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.DocumentoPanel.Visible = false;
						this.SeguimientoPanel.Visible = false;
						this.ComparecenciaPanel.Visible = false;
						this.AutoridadPanel.Visible = false;
						this.ResolucionPanel.Visible = false;
						this.RecomendacionPanel.Visible = false;
						this.ImprimirPanel.Visible = false;
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
				if (idRol == 8 && Int32.Parse(this.hddFuncionarioId.Value) != FuncionarioId) {
					//this.AcuerdoPanel.Visible = false;
					this.DiligenciaPanel.Visible = false;
					this.DocumentoPanel.Visible = false;
					this.SeguimientoPanel.Visible = false;
					this.ComparecenciaPanel.Visible = false;
					this.AutoridadPanel.Visible = false;
					this.ResolucionPanel.Visible = false;
					this.RecomendacionPanel.Visible = false;
					this.EnviarPanel.Visible = false;
				}

				// Si el Expediente no está marcado como Recomendación ocultar la opción
				if( this.hddTipoResolucionId.Value != "2" ){
					this.RecomendacionPanel.Visible = false;
				}

				// Si es Funcionario y el expediente está asignado a el puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (idRol == 8 && Int32.Parse(this.hddFuncionarioId.Value) == FuncionarioId) {
					if (Int32.Parse(this.hddEstatusId.Value) != 16) { 
						
						this.lnkAgregarComentario.Visible = true;
					}
				}

				// Si es Administrador puede agregar comentarios siempre y cuando no esté en estatus de confirmación de cierre
				if (idRol == 1 || idRol == 2) {
					if (Int32.Parse(this.hddEstatusId.Value) != 16) { 
						
						this.lnkAgregarComentario.Visible = true;
					}
				}

				// El expediente no se podrá operar en los siguientes Estatus (de Visitadurías):
				// 16 - Pendiente de aprobar cierre
				// 23 - Proyecto Aprobado
				if ( Int32.Parse(this.hddEstatusId.Value) == 16 || Int32.Parse(this.hddEstatusId.Value) == 23 ){
					//this.AcuerdoPanel.Visible = false;
					this.DiligenciaPanel.Visible = false;
					this.DocumentoPanel.Visible = false;
					this.SeguimientoPanel.Visible = false;
					this.ComparecenciaPanel.Visible = false;
					this.AutoridadPanel.Visible = false;
					this.ResolucionPanel.Visible = false;
					this.RecomendacionPanel.Visible = false;
					this.EnviarPanel.Visible = false;
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

				// Obtener AtencionId
				this.hddExpedienteId.Value = sKey.ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
				this.SenderId.Value = sKey.ToString().Split(new Char[] { '|' })[1];

                switch (this.SenderId.Value){
					case "1":
						this.Sender.Value = "VisBusquedaExpedientes.aspx";
                        break;

					case "2":
						this.Sender.Value = "VisListadoExpedientes.aspx";
						break;

					case "3":
						this.Sender.Value = "VisListadoExpedientesEnProceso.aspx";
						break;

                    default:
                        this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
                        return;
                }

				// Consultar detalle de la Solicitud de Quejas
				SelectExpediente();

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

            try
            {

                // Validación de que sea Item 
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

                // Obtener controles
                DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
                DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");
                DataRow = (DataRowView)e.Item.DataItem;

                // Configurar imagen
				DocumentoLabel.Text = DataRow["NombreDocumentoCorto"].ToString();

				DocumentoImage.ImageUrl = "~/Include/Image/Icon/" + DataRow["Icono"].ToString();
				DocumentoImage.ToolTip = DataRow["NombreDocumento"].ToString();
                DocumentoImage.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                DocumentoImage.Attributes.Add("onmouseout", "this.style.cursor='auto'");
				DocumentoImage.Attributes.Add("onclick", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?DocumentoId=" + DataRow["DocumentoId"].ToString() + "');");

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
				DeleteExpedienteComentario(Int32.Parse(e.CommandArgument.ToString()));

				// Consultar el expediente
				SelectExpediente();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}


		// Opciones de Menu (en orden de aparación)

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			try
            {

				// Consultar el expediente
				SelectExpediente();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visAsignarFuncionario.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visDiligenciaExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void DocumentoButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visAgregarDocumento.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visSeguimientoExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void ComparecenciaButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visComparecencia.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void AutoridadButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visAutoridadVoces.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void ResolucionButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visResolucionExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void RecomendacionButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visRecomendacionExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void ImprimirButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visImprmirExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void EnviarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visEnviarExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		
		// Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertExpedienteComentario();

				// Actualizar el expediente
				SelectExpediente();

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