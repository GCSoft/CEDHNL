/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAtencionVictimas
' Autor:	Ruben.Cobos
' Fecha:	15-Septiembre-2014
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
using System.Drawing;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueAtencionVictimas : System.Web.UI.Page
	{
		
		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();
		GCCommon gcCommon = new GCCommon();

		// Enumeraciones
		private enum ItemActionTypes { Delete, Insert, Update }


		// Variables publicas

		GridView gvAtencionDetalle = null;


		// Rutinas del programador

		void DeleteAtencion( Int32 AtencionId){
			BPAtencion oBPAtencion = new BPAtencion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTAtencion oENTAtencion = new ENTAtencion();

			try
			{

			    // Formulario
				oENTAtencion.AtencionId = AtencionId;

			    // Transacción
				oENTResponse = oBPAtencion.DeleteAtencion(oENTAtencion);

			    // Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
				SelectSolicitud();

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void InsertAtencion(){
			BPAtencion oBPAtencion = new BPAtencion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTSession oENTSession;

			String CiudadanoId = "";
			RadioButton oRadioButton;

			try
			{

			   // Obtener Sesion
			    oENTSession = (ENTSession)this.Session["oENTSession"];

				// Obtener la autoridad seleccionada
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oRadioButton = (RadioButton)this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) {
						CiudadanoId = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
					}
				}

			    //Formulario
				oENTAtencion.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTAtencion.ExpedienteId = 0;
				oENTAtencion.LugarAtencionId = Int32.Parse(this.ddlLugarAtencion.SelectedItem.Value);
				oENTAtencion.ModuloId = 2; // Quejas
				oENTAtencion.TipoDictamenId = Int32.Parse(this.ddlTipoDictamen.SelectedItem.Value);
				oENTAtencion.CiudadanoId = Int32.Parse(CiudadanoId);
				oENTAtencion.IdUsuario = oENTSession.idUsuario;
				oENTAtencion.NumeroOficio = this.txtNumeroOficio.Text.Trim();
				oENTAtencion.Detalle = this.ckeDetalle.Text.Trim();

			    //Transacción
			    oENTResponse = oBPAtencion.InsertAtencion(oENTAtencion);

			    //Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
				SelectSolicitud();

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

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvCiudadano.DataBind();

				// Atenciones
				this.gvAtencion.DataSource = oENTResponse.dsResponse.Tables[8];
				this.gvAtencion.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectLugarAtencion(){
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Formulario
				oENTDictamen.LugarAtencionId = 0;
				oENTDictamen.Nombre = "";

				// Transacción
				oENTResponse = oBPDictamen.SelectLugarAtencion(oENTDictamen);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlLugarAtencion.DataTextField = "Nombre";
				this.ddlLugarAtencion.DataValueField = "LugarAtencionId";
				this.ddlLugarAtencion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlLugarAtencion.DataBind();

				// Agregar Item de selección
				this.ddlLugarAtencion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipoDictamen(){
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Formulario
				oENTDictamen.TipoDictamenId = 0;
				oENTDictamen.Nombre = "";

				// Transacción
				oENTResponse = oBPDictamen.SelectTipoDictamen(oENTDictamen);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlTipoDictamen.DataTextField = "Nombre";
				this.ddlTipoDictamen.DataValueField = "TipoDictamenId";
				this.ddlTipoDictamen.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoDictamen.DataBind();

				// Agregar Item de selección
				this.ddlTipoDictamen.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateAtencion(){
			BPAtencion oBPAtencion = new BPAtencion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTSession oENTSession;

			String CiudadanoId = "";
			RadioButton oRadioButton;

			try
			{

			   // Obtener Sesion
			    oENTSession = (ENTSession)this.Session["oENTSession"];

				// Obtener la autoridad seleccionada
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oRadioButton = (RadioButton)this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) {
						CiudadanoId = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
					}
				}

			    //Formulario
				oENTAtencion.AtencionId = Int32.Parse(this.hddAtencionId.Value);
				oENTAtencion.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTAtencion.ExpedienteId = 0;
				oENTAtencion.LugarAtencionId = Int32.Parse(this.ddlLugarAtencion.SelectedItem.Value);
				oENTAtencion.ModuloId = 2; // Quejas
				oENTAtencion.TipoDictamenId = Int32.Parse(this.ddlTipoDictamen.SelectedItem.Value);
				oENTAtencion.CiudadanoId = Int32.Parse(CiudadanoId);
				oENTAtencion.IdUsuario = oENTSession.idUsuario;
				oENTAtencion.NumeroOficio = this.txtNumeroOficio.Text.Trim();
				oENTAtencion.Detalle = this.ckeDetalle.Text.Trim();

			    //Transacción
				oENTResponse = oBPAtencion.UpdateAtencion(oENTAtencion);

			    //Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
				SelectSolicitud();

			}catch (Exception ex){
			    throw (ex);
			}
		}


		// Rutinas del PopUp

		void ClearActionPanel(){
			try
			{

				// Limpiar formulario
				this.wucFixedDateTime.SetDateTime();
				this.txtNumeroOficio.Text = "";
				this.ddlTipoDictamen.SelectedIndex = 0;
				this.ddlLugarAtencion.SelectedIndex = 0;
				this.ckeDetalle.Text = "";

				// Estado incial de controles
				this.pnlAction.Visible = false;
				this.lblActionTitle.Text = "";
				this.btnAction.Text = "";
				this.lblActionMessage.Text = "";
				this.hddAtencionId.Value = "";

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectAtencion_ForEdit(Int32 AtencionId){
			BPAtencion oBPAtencion = new BPAtencion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTAtencion oENTAtencion = new ENTAtencion();

			RadioButton oRadioButton;

			try
			{

			    //Formulario
				oENTAtencion.AtencionId = AtencionId;

			    //Transacción
				oENTResponse = oBPAtencion.SelectAtencion_Detalle_ById(oENTAtencion);

			    //Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
				this.txtNumeroOficio.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NumeroOficio"].ToString();
				this.ddlTipoDictamen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoDictamenId"].ToString();
				this.ddlLugarAtencion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarAtencionId"].ToString();

				// Ciudadano de la atención
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oRadioButton = (RadioButton)this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("RowSelector");
					oRadioButton.Checked = ( oENTResponse.dsResponse.Tables[2].Select("CiudadanoId=" + this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString() ).Length > 0 ? true : false );
				}

				// Detalle de la atención
				this.ckeDetalle.Text = oENTResponse.dsResponse.Tables[3].Select("Dictamen=0")[0]["Detalle"].ToString();

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void SetPanel(ItemActionTypes ItemType, Int32 idItem){
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddAtencionId.Value = idItem.ToString();

				// Detalle de acción
				switch (ItemType){
					case ItemActionTypes.Insert:

						this.lblActionTitle.Text = "Nueva Atención a Víctima";
						this.btnAction.Text = "Crear Atención a Víctima";
						this.btnAction.Visible = true;
						break;

					case ItemActionTypes.Update:

						this.lblActionTitle.Text = "Edición de Atención a Víctima";
						this.btnAction.Text = "Actualizar Atención a Víctima";
						this.btnAction.Visible = true;
						SelectAtencion_ForEdit( Int32.Parse( idItem.ToString()));
						break;

					default:
						throw (new Exception("Opción inválida"));
				}

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "WAFocus ('" + this.txtNumeroOficio.ClientID + "'); ", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void ValidateActionForm(){
			RadioButton oRadioButton;
			Boolean CheckCiudadano = false;

			try
			{

				if (this.txtNumeroOficio.Text.Trim() == "") { throw new Exception("El campo [No. Oficio] es requerido"); }
				if (this.ddlTipoDictamen.SelectedIndex == 0) { throw new Exception("El campo [Dictamen] es requerido"); }
				if (this.ddlLugarAtencion.SelectedIndex == 0) { throw new Exception("El campo [Lugar de Atención] es requerido"); }
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {
					oRadioButton = (RadioButton)this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) { CheckCiudadano = true; }
				}
				if ( CheckCiudadano == false ) { throw new Exception("Es necesario incluir por lo menos un Ciudadano en la solicitud"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Rutinas del grid Anidado

		void SelectAtencion_Detalle(Int32 AtencionId){
			BPAtencion oBPAtencion = new BPAtencion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTAtencion oENTAtencion = new ENTAtencion();

			try
			{

			    //Formulario
				oENTAtencion.AtencionId = AtencionId;

			    //Transacción
				oENTResponse = oBPAtencion.SelectAtencion_Detalle_ById(oENTAtencion);

			    //Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
				gvAtencionDetalle.DataSource = oENTResponse.dsResponse.Tables[3];
				gvAtencionDetalle.DataBind();

			}catch (Exception ex){
			    throw (ex);
			}
        }

		void SwapGrid(int iRow){
            Panel oPanelDetail = new Panel();
            ImageButton oImageSwapGrid = new ImageButton();

            ImageButton imgEdit = null;
            ImageButton imgBorrar = null;

			String EstatusId = "";
            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAtencion.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAtencion.Rows[iRow].FindControl("imgSwapGrid");
				imgEdit = (ImageButton)this.gvAtencion.Rows[iRow].FindControl("imgEdit");
				imgBorrar = (ImageButton)this.gvAtencion.Rows[iRow].FindControl("imgDelete");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

				// DataKeys
				EstatusId = this.gvAtencion.DataKeys[iRow]["EstatusId"].ToString();

				// Seguridad
				if (EstatusId != "17"){

					// Atributos Over y Out
					this.gvAtencion.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");
					this.gvAtencion.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

				}else{

					// Atributos Over
					sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
					this.gvAtencion.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand" : "Collapse") + ".png'; ";
					this.gvAtencion.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}
                                
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

            ImageButton imgEdit = null;
            ImageButton imgBorrar = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAtencion.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAtencion.Rows[iRow].FindControl("imgSwapGrid");
				imgEdit = (ImageButton)this.gvAtencion.Rows[iRow].FindControl("imgEdit");
				imgBorrar = (ImageButton)this.gvAtencion.Rows[iRow].FindControl("imgDelete");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";


                //Puntero y Sombra en fila Over
                this.gvAtencion.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAtencion.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

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
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener SolicitudId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Carátula
				SelectSolicitud();

				// Estado inicial del formulario
				SelectLugarAtencion();
				SelectTipoDictamen();
				ClearActionPanel();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnNuevo_Click(object sender, EventArgs e){
			try
			{

				// Nuevo registro
				SetPanel(ItemActionTypes.Insert, 0);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void gvAtencion_RowCommand(object sender, GridViewCommandEventArgs e){
			String sCommandName;
			String AtencionId;

			Int32 intRow = 0;

			try
			{
				
			    // Opción seleccionada
			    sCommandName = e.CommandName.ToString();

			    // Se dispara el evento RowCommand en el ordenamiento
			    if (sCommandName == "Sort") { return; }
				if (sCommandName == "SwapGridHeader") { return; }

			    // Fila
			    intRow = Convert.ToInt32(e.CommandArgument.ToString());

			    // DataKeys
			    AtencionId = gvAtencion.DataKeys[intRow]["AtencionId"].ToString();

			    // Acción
			    switch (sCommandName){
			        case "Editar":
						SetPanel(ItemActionTypes.Update, Int32.Parse(AtencionId));
			            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
			            break;

			        case "Borrar":
			            DeleteAtencion(Int32.Parse( AtencionId));
			            break;

					case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
						SwapGrid(Convert.ToInt32(e.CommandArgument.ToString()));
						break;
			    }

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvAtencion_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
            ImageButton imgBorrar = null;

            String AtencionId = "";
			String EstatusId = "";
            String sNoOficio = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            Panel oPanelDetail = null;
            ImageButton imgSwapGrid = null;

            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgBorrar = (ImageButton)e.Row.FindControl("imgDelete");
                imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

                // DataKeys
                AtencionId = gvAtencion.DataKeys[e.Row.RowIndex]["AtencionId"].ToString();
				EstatusId = gvAtencion.DataKeys[e.Row.RowIndex]["EstatusId"].ToString();
				sNoOficio = gvAtencion.DataKeys[e.Row.RowIndex]["NumeroOficioAtencion"].ToString();

				// Seguridad
				if (EstatusId != "17"){

					imgEdit.Visible = false;
					imgBorrar.Visible = false;

					// Atributos Over y Out
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

				}else{

					// Tooltip Editar Atencion
					sToolTip = "Editar Atencion [" + sNoOficio + "]";
					imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
					imgEdit.Attributes.Add("style", "curosr:hand;");

					// Tooltip Borrar Atencion
					sToolTip = "Borrar Atencion [" + sNoOficio + "]";
					imgBorrar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgBorrar.Attributes.Add("onmouseout", "tooltip.hide();");
					imgBorrar.Attributes.Add("style", "cursor:hand;");

					// Atributos Over
					sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Expand_Over.png'; ";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Expand.png'; ";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}

				// Tooltip Swap (por default está expandida)
				sToolTip = "Mostrar el detalle";
				imgSwapGrid.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Der');");
				imgSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
				imgSwapGrid.Attributes.Add("style", "cursor:hand;");

				// Detalle
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");
				gvAtencionDetalle = new GridView();
				gvAtencionDetalle = (GridView)e.Row.FindControl("gvAtencionDetalle");
				SelectAtencion_Detalle( Int32.Parse(AtencionId));
				oPanelDetail.Visible = false;

            }catch (Exception ex){
                throw (ex);
            }
		}

		protected void gvAtencion_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvAtencion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; ");

				// Atributos Out
				e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; ");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			String CiudadanoId = "";
			RadioButton oRadioButton;

			try
			{

				// Obtener la autoridad seleccionada
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oRadioButton = (RadioButton)this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) {
						CiudadanoId = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
					}
				}

				// Ordenar el grid
				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

				// Marcar Autoridades seleccionada
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oRadioButton = (RadioButton)this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (CiudadanoId == this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString()) { oRadioButton.Checked = true; }
				}

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNumeroOficio.ClientID + "');", true);
			}
		}


		// Eventos de PopUp

		protected void btnAction_Click(object sender, EventArgs e){
			try
			{
				
				// Validar formulario
				ValidateActionForm();

				// Determinar acción
                if (this.hddAtencionId.Value == "0"){

					InsertAtencion();
                }else{

					UpdateAtencion();
                }

				// Limpiar el panel
				ClearActionPanel();

				// Actualizar
				SelectSolicitud();

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNumeroOficio.ClientID + "');", true);
			}
		}

		protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Cancelar transacción
				ClearActionPanel();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		// Eventos del grid anidado

		protected void gvAtencionDetalle_RowDataBound(object sender, GridViewRowEventArgs e){
			String Dictamen = "";
			
            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // DataKeys
				Dictamen = gvAtencionDetalle.DataKeys[e.Row.RowIndex]["Dictamen"].ToString();

				// Seguridad
				if (Dictamen == "1"){

					e.Row.Cells[0].BackColor = ColorTranslator.FromHtml("#FCAAAA");
					e.Row.Cells[1].BackColor = ColorTranslator.FromHtml("#FCAAAA");
				}

            }catch (Exception ex){
                throw (ex);
            }
		}

		protected void imgSwapAll_Click(object sender, ImageClickEventArgs e){
            ImageButton imgHeaderSwapGrid = null;
            Boolean isVisible;

            try
            {

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

                foreach (GridViewRow rowVozDetalle in this.gvAtencion.Rows){
                    SwapGridByHeader(rowVozDetalle.DataItemIndex, isVisible);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

	}
}