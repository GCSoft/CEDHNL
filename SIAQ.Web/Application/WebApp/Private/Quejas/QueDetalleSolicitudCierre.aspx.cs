/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueDetalleSolicitudCierre
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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueDetalleSolicitudCierre : System.Web.UI.Page
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas el programador

		void RechazarCalificacion(){
			BPQueja oBPQueja = new BPQueja();
			ENTResponse oENTResponse = new ENTResponse();
			ENTQueja oENTQueja = new ENTQueja();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.EstatusId = 3; // En proceso de Queja

				//Transacción
				oENTResponse = oBPQueja.UpdateSolicitudEstatus(oENTQueja);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

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
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

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

				// Documentos
				if (oENTResponse.dsResponse.Tables[8].Rows.Count == 0){

					this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados a la solicitud";
				}else{

					this.SinDocumentoLabel.Text = "";
					this.dlstDocumentoList.DataSource = oENTResponse.dsResponse.Tables[8];
					this.dlstDocumentoList.DataBind();
				}

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
				this.gvAutoridades.DataSource = oENTResponse.dsResponse.Tables[4];
				this.gvAutoridades.DataBind();

				// Diligencias
				this.gvDiligencia.DataSource = oENTResponse.dsResponse.Tables[5];
				this.gvDiligencia.DataBind();

				// Seleccionar indicadores
				for (int k = 0; k < this.chkIndicadorGenero.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorGenero.Items[k].Value).Length == 1) {
						this.chkIndicadorGenero.Items[k].Selected = true;
						this.chkIndicadorGenero.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorGenero.Items[k].Enabled = false;
				}

				for (int k = 0; k < this.chkIndicadorEdad.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorEdad.Items[k].Value).Length == 1) {
						this.chkIndicadorEdad.Items[k].Selected = true;
						this.chkIndicadorEdad.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorEdad.Items[k].Enabled = false;
				}
				
				for (int k = 0; k < this.chkIndicadorActividad.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorActividad.Items[k].Value).Length == 1) {
						this.chkIndicadorActividad.Items[k].Selected = true;
						this.chkIndicadorActividad.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorActividad.Items[k].Enabled = false;
				}

				for (int k = 0; k < this.chkIndicadorCondicion.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorCondicion.Items[k].Value).Length == 1) {
						this.chkIndicadorCondicion.Items[k].Selected = true;
						this.chkIndicadorCondicion.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorCondicion.Items[k].Enabled = false;
				}

				for (int k = 0; k < this.chkIndicadorComunidades.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorComunidades.Items[k].Value).Length == 1) {
						this.chkIndicadorComunidades.Items[k].Selected = true;
						this.chkIndicadorComunidades.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorComunidades.Items[k].Enabled = false;
				}

				for (int k = 0; k < this.chkIndicadorVictimas.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorVictimas.Items[k].Value).Length == 1) {
						this.chkIndicadorVictimas.Items[k].Selected = true;
						this.chkIndicadorVictimas.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorVictimas.Items[k].Enabled = false;
				}

				for (int k = 0; k < this.chkIndicadorTemas.Items.Count; k++) {

					if (oENTResponse.dsResponse.Tables[6].Select("IndicadorId=" + this.chkIndicadorTemas.Items[k].Value).Length == 1) {
						this.chkIndicadorTemas.Items[k].Selected = true;
						this.chkIndicadorTemas.Items[k].Attributes.Add("Style", "color:red;");
					}
					this.chkIndicadorTemas.Items[k].Enabled = false;
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
						this.AprobarCalificacionPanel.Visible = true;
						this.RechazarCalificacionPanel.Visible = true;
						break;

					case 2:	// Administrador
						this.AprobarCalificacionPanel.Visible = true;
						this.RechazarCalificacionPanel.Visible = true;
						break;

					case 3:	// Recepción
						this.AprobarCalificacionPanel.Visible = false;
						this.RechazarCalificacionPanel.Visible = false;
						break;

					case 4:	// Quejas - Secretaria
						this.AprobarCalificacionPanel.Visible = true;
						this.RechazarCalificacionPanel.Visible = true;
						break;

					case 5:	// Quejas - Funcionario
						this.AprobarCalificacionPanel.Visible = false;
						this.RechazarCalificacionPanel.Visible = false;
						break;

					case 6:	// Quejas - Director
						this.AprobarCalificacionPanel.Visible = true;
						this.RechazarCalificacionPanel.Visible = true;
						break;

					default:
						this.AprobarCalificacionPanel.Visible = false;
						this.RechazarCalificacionPanel.Visible = false;
						break;

				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		void SetStyleInItemChecked(){
			try
			{

				for (int k = 0; k < this.chkIndicadorGenero.Items.Count; k++) {
					if (this.chkIndicadorGenero.Items[k].Selected ) { this.chkIndicadorGenero.Items[k].Attributes.Add("Style", "color:red;"); }
				}

				for (int k = 0; k < this.chkIndicadorEdad.Items.Count; k++) {
					if (this.chkIndicadorEdad.Items[k].Selected ) { this.chkIndicadorEdad.Items[k].Attributes.Add("Style", "color:red;"); }
				}

				for (int k = 0; k < this.chkIndicadorActividad.Items.Count; k++) {
					if (this.chkIndicadorActividad.Items[k].Selected ) { this.chkIndicadorActividad.Items[k].Attributes.Add("Style", "color:red;"); }
				}

				for (int k = 0; k < this.chkIndicadorCondicion.Items.Count; k++) {
					if (this.chkIndicadorCondicion.Items[k].Selected ) { this.chkIndicadorCondicion.Items[k].Attributes.Add("Style", "color:red;"); }
				}

				for (int k = 0; k < this.chkIndicadorComunidades.Items.Count; k++) {
					if (this.chkIndicadorComunidades.Items[k].Selected ) { this.chkIndicadorComunidades.Items[k].Attributes.Add("Style", "color:red;"); }
				}

				for (int k = 0; k < this.chkIndicadorVictimas.Items.Count; k++) {
					if (this.chkIndicadorVictimas.Items[k].Selected ) { this.chkIndicadorVictimas.Items[k].Attributes.Add("Style", "color:red;"); }
				}

				for (int k = 0; k < this.chkIndicadorTemas.Items.Count; k++) {
					if (this.chkIndicadorTemas.Items[k].Selected) { this.chkIndicadorTemas.Items[k].Attributes.Add("Style", "color:red;"); }
				}


			}catch (Exception) { 
				// Do Nothing
			}
		}


		// Rutinas de Autoridades y Voces

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

		void SwapGrid(int iRow){
            Panel oPanelDetail = new Panel();
            ImageButton oImageSwapGrid = new ImageButton();

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAutoridades.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("imgSwapGrid");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                

                //Puntero y Sombra en fila Over
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
                                
                // Cambiar estados
                if (oPanelDetail.Visible){

                    oPanelDetail.Visible = false;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Expand.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Mostrar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }else{

                    oPanelDetail.Visible = true;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Collapse.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Ocultar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }

            }catch (Exception ex){
                throw (ex);
            }
        }

        void SwapGridByHeader(Int32 iRow, Boolean isVisible){
            ImageButton oImageSwapGrid = null;
            Panel oPanelDetail = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAutoridades.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("imgSwapGrid");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";


                //Puntero y Sombra en fila Over
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

                // Cambiar estados
                if (isVisible){

                    oPanelDetail.Visible = false;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Expand.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Mostrar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }else{

                    oPanelDetail.Visible = true;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Collapse.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Ocultar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }

            }catch (Exception ex){
                throw (ex);
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
					case "1": // Invocado desde [Listado de Solicitudes pendientes por Aprobar]
						this.Sender.Value = "QueListadoSolicitudesAprobacion.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Consulta de indicadores
				SelectIndicadores();

				// Consultar detalle de la Solicitud de Quejas
				SelectSolicitud_Cierre();

				// Seguridad
				SetPermisosGenerales(SessionEntity.idRol);

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
                DocumentoLabel.Text = DataRow["NombreDocumento"].ToString();

                DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
                DocumentoImage.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                DocumentoImage.Attributes.Add("onmouseout", "this.style.cursor='auto'");
                DocumentoImage.Attributes.Add("onclick", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=0" + "');");

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

		protected void gvDiligencia_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvDiligencia_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvDiligencia, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		// Eventos de la página - Autoridades y Voces Señaladas

		protected void imgSwapAll_Click(object sender, ImageClickEventArgs e){
            ImageButton imgHeaderSwapGrid = null;
            Boolean isVisible;

            try
            {

				// Validaciones
				if (this.hddCalificacionId.Value != "2") { return; }

                // Acceso a la imagen
                imgHeaderSwapGrid = (ImageButton)sender;

                if (imgHeaderSwapGrid.ImageUrl == "~/Include/Image/Buttons/Expand_Header.png"){

                    // Expander todo
                    isVisible = false;
                    imgHeaderSwapGrid.ImageUrl = "~/Include/Image/Buttons/Collapse_Header.png";
                    imgHeaderSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Contraer todos los elementos', 'Der');");
                    imgHeaderSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }else{

                    // Contraer todo
                    isVisible = true;
                    imgHeaderSwapGrid.ImageUrl = "~/Include/Image/Buttons/Expand_Header.png";
                    imgHeaderSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Expandir todos los elementos', 'Der');");
                    imgHeaderSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }

                foreach (GridViewRow rowVozDetalle in this.gvAutoridades.Rows){
                    SwapGridByHeader(rowVozDetalle.DataItemIndex, isVisible);
                }

				// Estilos de Items Seleccionados
				SetStyleInItemChecked();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		protected void gvAutoridades_RowCommand(object sender, GridViewCommandEventArgs e){
            try
            {

                switch (e.CommandName.ToString()){
                    case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
						if (this.hddCalificacionId.Value == "2") { SwapGrid(Convert.ToInt32(e.CommandArgument.ToString())); }
                        break;
                }

				// Estilos de Items Seleccionados
				SetStyleInItemChecked();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e){
            String sImagesAttributes = "";
			String sToolTip = "";

			String AutoridadId = "";

            Panel oPanelDetail = null;
            GridView grdVocesAgregadas = null;
            ImageButton imgSwapGrid = null;

            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// DataKeys
				AutoridadId = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();

                // Obtener imagenes
                imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse_Over.png'; ";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse.png'; ";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

                // Tooltip Swap (por default está expandida)
                sToolTip = "Ocultar el detalle";
                imgSwapGrid.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Der');");
                imgSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                imgSwapGrid.Attributes.Add("style", "cursor:hand;");

				// Sólo autoridades
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");

				if (this.hddCalificacionId.Value != "2" ){

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

        protected void gvAutoridades_Sorting(object sender, GridViewSortEventArgs e){
            try
			{

				gcCommon.SortGridView(ref this.gvAutoridades, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }


		// Opciones de Menu (por orden de aparación)

		protected void AprobarCalificacionButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("QueCrearExpediente.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void RechazarCalificacionButton_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Rechazar la aprobación
				RechazarCalificacion();

				// Regresar al detalle del expediente
				Response.Redirect(this.Sender.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

	}
}