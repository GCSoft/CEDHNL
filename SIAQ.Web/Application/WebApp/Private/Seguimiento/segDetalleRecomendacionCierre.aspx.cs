/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    segDetalleRecomendacionCierre
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
	public partial class segDetalleRecomendacionCierre : System.Web.UI.Page
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

		void AprobarRecomendacion(){
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{
				
			    // Formulario
			    oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.EstatusId = 12; // Expediente cerrado
				oENTSeguimiento.ModuloId = 4; // Seguimientos

			    // Transacción
				oENTResponse = oBPSeguimiento.UpdateRecomendacion_Estatus(oENTSeguimiento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void RechazarRecomendacion(){
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			BPSeguimiento oBPSeguimiento = new BPSeguimiento();

			try
			{
				
			    // Formulario
			    oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTSeguimiento.EstatusId = 10; // Por atender expediente
				oENTSeguimiento.ModuloId = 4; // Seguimientos

			    // Transacción
				oENTResponse = oBPSeguimiento.UpdateRecomendacion_Estatus(oENTSeguimiento);

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

				// Encabezado
				this.lblEncabezado.Text = "Detalle de " + ( oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "recomendación" : "acuerdo de no responsabilidad" );
				this.lblNumero.Text = (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "Recomendación" : "Acuerdo") + " Número";

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

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[7];
				this.gvCiudadano.DataBind();

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

				}

				// Gestion de Documento
				this.gvGestion.DataSource = oENTResponse.dsResponse.Tables[6];
				this.gvGestion.DataBind();

				// Puntos Resolutivos
				this.gvGestionPuntosResolutivos.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvGestionPuntosResolutivos.DataBind();

				// Diligencias
				this.gvDiligencia.DataSource = oENTResponse.dsResponse.Tables[5];
				this.gvDiligencia.DataBind();
				
			}catch (Exception ex){
				throw (ex);
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
            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvGestionPuntosResolutivos.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvGestionPuntosResolutivos.Rows[iRow].FindControl("imgSwapGrid");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                this.gvGestionPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand" : "Collapse") + ".png'; ";
                this.gvGestionPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
                                
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

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvGestionPuntosResolutivos.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvGestionPuntosResolutivos.Rows[iRow].FindControl("imgSwapGrid");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                this.gvGestionPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand" : "Collapse") + ".png'; ";
                this.gvGestionPuntosResolutivos.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

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

				switch (this.SenderId.Value){
					case "1":
						this.Sender.Value = "segListadoRecomendacionesAprobacion.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
                }

				// Carátula
				SelectRecomendacion();

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

		protected void gvDiligencia_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDetail = null;
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String ModuloId = "";
			String FechaDiligencia = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgDetail = (ImageButton)e.Row.FindControl("imgDetail");
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				ModuloId = this.gvDiligencia.DataKeys[e.Row.RowIndex]["ModuloId"].ToString();
				FechaDiligencia = this.gvDiligencia.DataKeys[e.Row.RowIndex]["Fecha"].ToString();

				// Seguridad

				imgEdit.Visible = false;
				imgDelete.Visible = false;
				imgDetail.Visible = false;

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

		protected void gvGestion_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvGestion_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvGestion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvGestionPuntosResolutivos_RowCommand(object sender, GridViewCommandEventArgs e){
			try
			{

			    switch (e.CommandName.ToString())
			    {

			        case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
						swapGrid(Convert.ToInt32(e.CommandArgument.ToString()));
			            break;
			    }

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
        }

		protected void gvGestionPuntosResolutivos_RowDataBound(object sender, GridViewRowEventArgs e){
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
                imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

                // DataKeys
				RecomendacionDetalleId = gvGestionPuntosResolutivos.DataKeys[e.Row.RowIndex]["RecomendacionDetalleId"].ToString();
				NoRecomendacionDetalle = gvGestionPuntosResolutivos.DataKeys[e.Row.RowIndex]["RowNumber"].ToString();                

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse_Over.png'; ";
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse.png'; ";
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

		protected void gvGestionPuntosResolutivos_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvGestionPuntosResolutivos, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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

                foreach (GridViewRow rowTipoAceptacion in this.gvGestionPuntosResolutivos.Rows){
                    swapGridByHeader(rowTipoAceptacion.DataItemIndex, isVisible);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		
		// Opciones de Menu (en orden de aparación)

		protected void AprobarProyectoButton_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Rechazar la aprobación
				AprobarRecomendacion();

				// Regresar al detalle del expediente
				Response.Redirect(this.Sender.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void RechazarProyectoButton_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Rechazar la aprobación
				RechazarRecomendacion();

				// Regresar al detalle del expediente
				Response.Redirect(this.Sender.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


	}
}