/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segAgregrarInformacion
' Autor:	Ruben.Cobos
' Fecha:	03-Octubre-2014
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
	public partial class segGestionPuntoResolutivo : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();


		// Rutinas del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}


		// Funciones el programador

		void SelectEstatusPuntoResolutivo(){
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{

			    // Formulario
				oENTSeguimiento.EstatusPuntoResolutivoId = 0;
				oENTSeguimiento.AcuerdoNoResponsabilidad = 0;
				oENTSeguimiento.Nombre = "";
				oENTSeguimiento.Visible = 1;

			    // Transacción
				oENTResponse = oBPSeguimiento.SelectEstatusPuntoResolutivo(oENTSeguimiento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlPopUpEstatusPuntoResolutivo.DataTextField = "Nombre";
				this.ddlPopUpEstatusPuntoResolutivo.DataValueField = "EstatusPuntoResolutivoId";
				this.ddlPopUpEstatusPuntoResolutivo.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlPopUpEstatusPuntoResolutivo.DataBind();

				// Agregar Item de selección
				this.ddlPopUpEstatusPuntoResolutivo.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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

				// Encabezado y títulos
				this.lblEncabezado.Text = "Gestión de puntos resolutivos de " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "la recomendación" : "el acuerdo de no responsabilidad");
				this.lblNumero.Text = (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "Recomendación" : "Acuerdo") + " Número";
				this.GridLabel.Text = "Puntos resolutivos de " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "la recomendación" : "el acuerdo de no responsabilidad");

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

				// Puntos Resolutivos
				this.gvPuntosResolutivos.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvPuntosResolutivos.DataBind();
				
			}catch (Exception ex){
				throw (ex);
			}
		}



		// Eventos de PopUp de edición estatus de punto resolutivo

		void InsertRecomendacionGestion_PuntoResolutivo(){
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession oENTSession = new ENTSession();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{

				// Validaciones
				if (this.ddlPopUpEstatusPuntoResolutivo.SelectedIndex == 0) { throw (new Exception("Es necesario seleccionar un estatus")); }
				if (this.ckeEstatusPuntoResolutivo.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle")); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Formulario
				oENTSeguimiento.RecomendacionDetalleId = Int32.Parse(this.hddRecomendacionDetalleId.Value);
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.EstatusPuntoResolutivoId = Int16.Parse(this.ddlPopUpEstatusPuntoResolutivo.SelectedItem.Value);
				oENTSeguimiento.ModuloId = 4; // Seguimientos
				oENTSeguimiento.UsuarioId = oENTSession.idUsuario;
				oENTSeguimiento.Fecha = this.calFechaEstatusPuntoResolutivo.DisplayDate;
				oENTSeguimiento.Comentario = this.ckeEstatusPuntoResolutivo.Text.Trim();
				
			    // Transacción
				oENTResponse = oBPSeguimiento.InsertRecomendacionGestion(oENTSeguimiento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }				

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void ShowPopUpEstatusPuntoResolutivo( String RecomendacionDetalleId ){
			try
			{

				// Estado inicial del formulario
				this.hddRecomendacionDetalleId.Value = RecomendacionDetalleId;
				this.calFechaEstatusPuntoResolutivo.SetCurrentDate();
				this.ddlPopUpEstatusPuntoResolutivo.SelectedIndex = 0;
				this.ckeEstatusPuntoResolutivo.Text = "";

				// Foco
				this.ckeEstatusPuntoResolutivo.Focus();

			}catch (Exception ex){
				throw(ex);
			}
		}



		// Eventos Grid Anidado

		void SelectGestionPuntoResolutivo(ref GridView grdDetalle, Int32 RecomendacionDetalleId){
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{

			    // Formulario
				oENTSeguimiento.RecomendacionDetalleId = RecomendacionDetalleId;

			    // Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacionGestion_PuntoResolutivo(oENTSeguimiento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado de detalle
				grdDetalle.DataSource = oENTResponse.dsResponse.Tables[1];
				grdDetalle.DataBind();

			}catch (Exception ex){
			    throw (ex);
			}
        }

		void swapGrid(int iRow){
            Panel oPanelDetail = new Panel();
            ImageButton oImageSwapGrid = new ImageButton();

            ImageButton imgEdit = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvPuntosResolutivos.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvPuntosResolutivos.Rows[iRow].FindControl("imgSwapGrid");
                imgEdit = (ImageButton)this.gvPuntosResolutivos.Rows[iRow].FindControl("EditButton");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                

                //Puntero y Sombra en fila Over
                this.gvPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
                                
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

        void swapGridByHeader(Int32 iRow, Boolean isVisible){
            ImageButton oImageSwapGrid = null;
            Panel oPanelDetail = null;

            ImageButton imgEdit = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvPuntosResolutivos.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvPuntosResolutivos.Rows[iRow].FindControl("imgSwapGrid");
                imgEdit = (ImageButton)this.gvPuntosResolutivos.Rows[iRow].FindControl("EditButton");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";


                //Puntero y Sombra en fila Over
                this.gvPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

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

				// Estado inicial de los controles
				SelectEstatusPuntoResolutivo();
				this.pnlEstatusPuntoResolutivo.Visible = false;

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

		protected void gvPuntosResolutivos_RowCommand(object sender, GridViewCommandEventArgs e){
			try
			{

			    switch (e.CommandName.ToString())
			    {
			        case "Editar": // Editar estatus del punto resolutivo
						ShowPopUpEstatusPuntoResolutivo(e.CommandArgument.ToString());
			            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
			            break;

			        case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
						swapGrid(Convert.ToInt32(e.CommandArgument.ToString()));
			            break;
			    }

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
        }

		protected void gvPuntosResolutivos_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;

            String RecomendacionDetalleId = "";
            String NoRecomendacionDetalle = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            Panel oPanelDetail = null;
            GridView gvGestionPuntoResolutivo = null;
            ImageButton imgSwapGrid = null;

            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("EditButton");
                imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

                // DataKeys
				RecomendacionDetalleId = gvPuntosResolutivos.DataKeys[e.Row.RowIndex]["RecomendacionDetalleId"].ToString();
				NoRecomendacionDetalle = gvPuntosResolutivos.DataKeys[e.Row.RowIndex]["RowNumber"].ToString();                

                // Tooltip Editar RecomendacionDetalle
                sToolTip = "Actualizar Estatus de Punto Resolutivo [" + NoRecomendacionDetalle + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse_Over.png'; ";
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse.png'; ";
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

                // Tooltip Swap (por default está expandida)
                sToolTip = "Ocultar el detalle";
                imgSwapGrid.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Der');");
                imgSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                imgSwapGrid.Attributes.Add("style", "cursor:hand;");

				// Detalle de Puntos resolutivos
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");
				gvGestionPuntoResolutivo = new GridView();
				gvGestionPuntoResolutivo = (GridView)e.Row.FindControl("gvGestionPuntoResolutivo");
				SelectGestionPuntoResolutivo(ref gvGestionPuntoResolutivo, Int32.Parse(RecomendacionDetalleId));
				oPanelDetail.Visible = true;

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

                foreach (GridViewRow rowTipoAceptacion in this.gvPuntosResolutivos.Rows){
                    swapGridByHeader(rowTipoAceptacion.DataItemIndex, isVisible);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }


		// Eventos de PopUp de edición estatus de punto resolutivo

		protected void btnPopUpEstatusPuntoResolutivo_Click(object sender, EventArgs e){
			try
			{

				InsertRecomendacionGestion_PuntoResolutivo();
				this.hddRecomendacionDetalleId.Value = "0";
				SelectRecomendacion();
				this.pnlEstatusPuntoResolutivo.Visible = false;

			}catch (Exception ex){
				this.lblActionMessageEstatusPuntoResolutivo.Text = ex.Message;
				this.ckeEstatusPuntoResolutivo.Focus();
			}
		}

		protected void imgCloseEstatusPuntoResolutivoWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Cancelar transacción
				this.hddRecomendacionDetalleId.Value = "0";
				this.pnlEstatusPuntoResolutivo.Visible = false;

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


	}
}