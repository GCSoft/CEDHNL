/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VisAcuerdoNoResponsabilidad
' Autor:	Ruben.Cobos
' Fecha:	31-Agosto-2014
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


namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
	public partial class VisAcuerdoNoResponsabilidad : System.Web.UI.Page
	{
		
		// Utilerías
		GCParse gcParse = new GCParse();
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

		void DeleteAcuerdo(String RecomendacionId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			try
			{
				oENTRecomendacion.RecomendacionId = Int32.Parse( RecomendacionId);
				oENTRecomendacion.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTRecomendacion.ModuloId = 3; // Visitadurías

				oENTResponse = oBPRecomendacion.DeleteRecomendacion(oENTRecomendacion);

				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				SelectExpediente();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertAcuerdo(){
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTSession oENTSession;

			String AutoridadId = "";
			RadioButton oRadioButton;

			DataTable tblCommon = null;
			DataRow rowCommon;

			try
			{

			   // Obtener Sesion
			    oENTSession = (ENTSession)this.Session["oENTSession"];

			    // Validaciones de sesión
			    if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear Acuerdos debido a que usted no es un funcionario"); }

				// Obtener la autoridad seleccionada
				foreach (GridViewRow gvRow in this.gvAutoridad.Rows) {

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) {
						AutoridadId = this.gvAutoridad.DataKeys[gvRow.RowIndex]["AutoridadId"].ToString();
					}
				}

			    //Formulario
				oENTRecomendacion.AutoridadId = Convert.ToInt32(AutoridadId);
				oENTRecomendacion.EstatusId = 9; // Por asignar a defensor de Seguimientos
				oENTRecomendacion.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
			    oENTRecomendacion.ModuloId = 3; // Visitadurías
				oENTRecomendacion.FuncionarioId = oENTSession.FuncionarioId;
				oENTRecomendacion.AcuerdoNoResponsabilidad = 1;

				tblCommon = gcParse.GridViewToDataTable(this.gvAutoridadDetalle, false);
				oENTRecomendacion.tblRecomendacionDetalle = new DataTable("tblAcuerdoDetalle");
				oENTRecomendacion.tblRecomendacionDetalle.Columns.Add("Detalle", typeof(String));
				foreach (DataRow oDataRow in tblCommon.Rows){

					rowCommon = oENTRecomendacion.tblRecomendacionDetalle.NewRow();
					rowCommon["Detalle"] = oDataRow["Apartado"];
					oENTRecomendacion.tblRecomendacionDetalle.Rows.Add(rowCommon);
				}

			    //Transacción
				oENTResponse = oBPRecomendacion.InsertRecomendacion(oENTRecomendacion);

			    //Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
			    SelectExpediente();

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void InsertAcuerdo_Local(){
			DataTable tblAutoridadDetalle = null;
			DataRow rowAutoridadDetalle = null;

			Int32 Contador = 0;

			try
			{

				// Obtener el DataTable del grid
				tblAutoridadDetalle = gcParse.GridViewToDataTable(this.gvAutoridadDetalle, false);

				// Nuevo Item
				rowAutoridadDetalle = tblAutoridadDetalle.NewRow();
				rowAutoridadDetalle["RowNumber"] = "0";
				rowAutoridadDetalle["Apartado"] = this.ckeApartado.Text;
				tblAutoridadDetalle.Rows.Add(rowAutoridadDetalle);

				// Reorganizar los RowNumber's
				foreach (DataRow rowReorder in tblAutoridadDetalle.Rows){

					Contador = Contador + 1;
					rowReorder["RowNumber"] = Contador.ToString();
				}

				// Refrescar el Grid
				this.gvAutoridadDetalle.DataSource = tblAutoridadDetalle;
				this.gvAutoridadDetalle.DataBind();

				// Estado del formulario
				this.ckeApartado.Text = "";
				this.lblActionMessage.Text = "";

				// Foco
				this.ckeApartado.Focus();

			}catch (Exception ex){
				throw (ex);
			}
		}

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
				this.hddAreaId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["AreaId"].ToString();
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

				// Acuerdos
				this.gvAcuerdo.DataSource = oENTResponse.dsResponse.Tables[13];
				this.gvAcuerdo.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectExpedienteAutoridad(){
            BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = 0;
				oENTVisitaduria.CalificacionAutoridadId = 2; // No Responsable

				// Consulta de autoridades
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridad(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "'); ", true); }

				// Vaciado de datos
				this.gvAutoridad.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvAutoridad.DataBind();
				
			}catch (Exception ex){
				throw (ex);
			}
        }

		void SelectAcuerdo_Detalle(ref GridView grdDetalle, Int32 RecomendacionId){
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

		void SelectAcuerdo_ForEdit(String RecomendacionId){
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTResponse oENTResponse = new ENTResponse();
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			RadioButton oRadioButton;

			try
			{
			    // Formulario
			    oENTRecomendacion.RecomendacionId = Int32.Parse(RecomendacionId);

			    // Transacción
				oENTResponse = oBPRecomendacion.SelectRecomendacion_ByID(oENTRecomendacion);

			    // Validaciones
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

			    // Mensaje de la BD
			    if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

			    // Llenado de formulario
				foreach (GridViewRow gvRow in this.gvAutoridad.Rows){

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadId"].ToString() == this.gvAutoridad.DataKeys[gvRow.RowIndex]["AutoridadId"].ToString()) { oRadioButton.Checked = true; }
				}


				this.gvAutoridadDetalle.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvAutoridadDetalle.DataBind();

			    // Id a trabajar
			    this.hddRecomendacionId.Value = RecomendacionId.ToString();

				// Estado del formulario
				this.btnAction.Text = "Modificar acuerdo";
				this.lblActionTitle.Text = "Modificar acuerdo";
				this.pnlAction.Visible = true;

				// Foco
				this.ckeApartado.Focus();

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void UpdateAcuerdo() { 
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTSession oENTSession;

			String AutoridadId = "";
			RadioButton oRadioButton;

			DataTable tblCommon = null;
			DataRow rowCommon;

			try
			{

			   // Obtener Sesion
			    oENTSession = (ENTSession)this.Session["oENTSession"];

			    // Validaciones de sesión
			    if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear Acuerdos debido a que usted no es un funcionario"); }

				// Obtener la autoridad seleccionada
				foreach (GridViewRow gvRow in this.gvAutoridad.Rows) {

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) {
						AutoridadId = this.gvAutoridad.DataKeys[gvRow.RowIndex]["AutoridadId"].ToString();
					}
				}

			    //Formulario
				oENTRecomendacion.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTRecomendacion.AutoridadId = Convert.ToInt32(AutoridadId);
				oENTRecomendacion.EstatusId = 9; // Por asignar a defensor de Seguimientos
				oENTRecomendacion.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
			    oENTRecomendacion.ModuloId = 3; // Visitadurías
				oENTRecomendacion.FuncionarioId = oENTSession.FuncionarioId;

				tblCommon = gcParse.GridViewToDataTable(this.gvAutoridadDetalle, false);
				oENTRecomendacion.tblRecomendacionDetalle = new DataTable("tblAcuerdoDetalle");
				oENTRecomendacion.tblRecomendacionDetalle.Columns.Add("Detalle", typeof(String));
				foreach (DataRow oDataRow in tblCommon.Rows){

					rowCommon = oENTRecomendacion.tblRecomendacionDetalle.NewRow();
					rowCommon["Detalle"] = oDataRow["Apartado"];
					oENTRecomendacion.tblRecomendacionDetalle.Rows.Add(rowCommon);
				}

			    //Transacción
				oENTResponse = oBPRecomendacion.UpdateRecomendacion(oENTRecomendacion);

			    //Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Actualizar grid
			    SelectExpediente();

			}catch (Exception ex){
			    throw (ex);
			}
		}

		
		// Rutinas del PopUp

		void ClearActionPanel(String RecomendacionId){
			RadioButton oRadioButton;

            try
            {

                // Limpiar formulario de Nueva Autoridad
				foreach (GridViewRow gvRow in this.gvAutoridad.Rows) {

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					oRadioButton.Checked = false;
				}
				this.ckeApartado.Text = "";
				
				this.gvAutoridadDetalle.DataSource = null;
				this.gvAutoridadDetalle.DataBind();

                // Estado incial de controles
                this.pnlAction.Visible = false;
                this.lblActionMessage.Text = "";

                // Autoridad como parámetro
				this.hddRecomendacionId.Value = RecomendacionId.ToString();

            }catch (Exception ex){
                throw (ex);
            }
        }

		void SwapGrid(int iRow){
            Panel oPanelDetail = new Panel();
            ImageButton oImageSwapGrid = new ImageButton();

            ImageButton imgEdit = null;
			ImageButton imgDelete = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAcuerdo.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAcuerdo.Rows[iRow].FindControl("imgSwapGrid");
				imgEdit = (ImageButton)this.gvAcuerdo.Rows[iRow].FindControl("imgEdit");
				imgDelete = (ImageButton)this.gvAcuerdo.Rows[iRow].FindControl("imgDelete");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                

                //Puntero y Sombra en fila Over
                this.gvAcuerdo.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAcuerdo.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
                                
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
			ImageButton imgDelete = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAcuerdo.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAcuerdo.Rows[iRow].FindControl("imgSwapGrid");
				imgEdit = (ImageButton)this.gvAcuerdo.Rows[iRow].FindControl("imgEdit");
				imgDelete = (ImageButton)this.gvAcuerdo.Rows[iRow].FindControl("imgDelete");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";


                //Puntero y Sombra en fila Over
                this.gvAcuerdo.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAcuerdo.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

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

		void ValidateActionForm(){
			RadioButton oRadioButton;
			Boolean CheckAutoridad = false;

			try
			{

				foreach (GridViewRow gvRow in this.gvAutoridad.Rows) {

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) { CheckAutoridad = true; }
				}
				if ( CheckAutoridad == false ) { throw new Exception("Es necesario incluir por lo menos un Autoridad en el Acuerdo"); }

				if (this.gvAutoridadDetalle.Rows.Count == 0) { throw new Exception("Es necesario incluir por lo menos un Apartado en el Acuerdo"); }

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

				// Llenado de controles
				SelectExpedienteAutoridad();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
            }
		}

		protected void btnNuevaAcuerdo_Click(object sender, EventArgs e){
			try
            {

				//Abrir popup
				ClearActionPanel("0");

				// Leyendas
				this.btnAction.Text = "Crear acuerdo";
				this.lblActionTitle.Text = "Crear acuerdo";

				// Mostrar Panel
				this.pnlAction.Visible = true;

				// Foco
				this.ckeApartado.Focus();
				
            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
            }
		}

		protected void gvAcuerdo_RowCommand(object sender, GridViewCommandEventArgs e){
			try
			{
				
				
				switch (e.CommandName.ToString()){
					case "Editar":
						ClearActionPanel(e.CommandArgument.ToString());
						SelectAcuerdo_ForEdit(e.CommandArgument.ToString());
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

					case "Eliminar":
						DeleteAcuerdo(e.CommandArgument.ToString());
						break;

					case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
						SwapGrid(Convert.ToInt32(e.CommandArgument.ToString()));
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
			}
		}

		protected void gvAcuerdo_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;
			ImageButton imgSwapGrid = null;

			Panel oPanelDetail = null;
			GridView gvAcuerdoDetalle = null;

			String sImagesAttributes = "";
			String sToolTip = "";

			String RecomendacionId = "";
			String NombreAutoridad = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
				imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

				// DataKeys
				RecomendacionId = gvAcuerdo.DataKeys[e.Row.RowIndex]["RecomendacionId"].ToString();
				NombreAutoridad = gvAcuerdo.DataKeys[e.Row.RowIndex]["NombreAutoridad"].ToString();

				// Tooltip Edición
				sToolTip = "Editar acuerdo [" + NombreAutoridad + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Delete
				sToolTip = "Eliminar acuerdo [" + NombreAutoridad + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Expand_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Expand.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				// Tooltip Swap
				sToolTip = "Expander el detalle";
				imgSwapGrid.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Der');");
				imgSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
				imgSwapGrid.Attributes.Add("style", "cursor:hand;");

				// Sólo autoridades
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");

				// Voces Agregadas
				gvAcuerdoDetalle = new GridView();
				gvAcuerdoDetalle = (GridView)e.Row.FindControl("gvAcuerdoDetalle");
				SelectAcuerdo_Detalle(ref gvAcuerdoDetalle, Int32.Parse(RecomendacionId));
				oPanelDetail.Visible = false;

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvAcuerdo_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvAcuerdo, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
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

                foreach (GridViewRow rowVozDetalle in this.gvAcuerdo.Rows){
                    SwapGridByHeader(rowVozDetalle.DataItemIndex, isVisible);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }


		// Eventos del PopUp

		protected void btnAction_Click(object sender, EventArgs e){
			try
            {

				// Validar formulario
				ValidateActionForm();

				// Determinar acción
                if (this.hddRecomendacionId.Value == "0"){

					InsertAcuerdo();
                }else{

					UpdateAcuerdo();
                }

				// Limpiar el panel
				ClearActionPanel("0");

				// Actualizar
				SelectExpediente();

            }catch (Exception ex){
                this.lblActionMessage.Text = ex.Message;
				this.ckeApartado.Focus();
            }
        }

		protected void btnAgregarApartado_Click(object sender, EventArgs e){
			try
			{
				
				// Validación
				if (this.ckeApartado.Text.Trim() == "") { throw new Exception("El campo [Apartado] es requerido"); }

				// Inserción local
				InsertAcuerdo_Local();

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				this.ckeApartado.Focus();
			}
		}

		protected void gvAutoridad_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvAutoridad_Sorting(object sender, GridViewSortEventArgs e){
			String AutoridadId = "";
			RadioButton oRadioButton;

			try
			{

				// Obtener la autoridad seleccionada
				foreach (GridViewRow gvRow in this.gvAutoridad.Rows) {

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (oRadioButton.Checked) {
						AutoridadId = this.gvAutoridad.DataKeys[gvRow.RowIndex]["AutoridadId"].ToString();
					}
				}

				// Ordenar el grid
				gcCommon.SortGridView(ref this.gvAutoridad, ref this.hddSort, e.SortExpression);

				// Marcar Autoridades seleccionada
				foreach (GridViewRow gvRow in this.gvAutoridad.Rows) {

					oRadioButton = (RadioButton)this.gvAutoridad.Rows[gvRow.RowIndex].FindControl("RowSelector");
					if (AutoridadId == this.gvAutoridad.DataKeys[gvRow.RowIndex]["AutoridadId"].ToString()) { oRadioButton.Checked = true; }
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvAutoridadDetalle_RowCommand(object sender, GridViewCommandEventArgs e){
			DataTable tblAutoridadDetalle = null;

			String RowNumber;
			String strCommand = "";

			Int32 intRow = 0;
			Int32 Contador = 0;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				RowNumber = this.gvAutoridadDetalle.DataKeys[intRow]["RowNumber"].ToString();

				// Acción
				switch (strCommand){
					case "Eliminar":

						// Obtener el DataTable del grid
						tblAutoridadDetalle = gcParse.GridViewToDataTable(this.gvAutoridadDetalle, true);

						// Eliminar el Item
						tblAutoridadDetalle.Rows.Remove(tblAutoridadDetalle.Select("RowNumber=" + RowNumber)[0]);

						// Reorganizar los RowNumber's
						foreach (DataRow rowReorder in tblAutoridadDetalle.Rows){

							Contador = Contador + 1;
							rowReorder["RowNumber"] = Contador.ToString();
						}

						// Refrescar el Grid
						this.gvAutoridadDetalle.DataSource = tblAutoridadDetalle;
						this.gvAutoridadDetalle.DataBind();

						// Estado del formulario
						this.ckeApartado.Text = "";
						this.lblActionMessage.Text = "";

						// Foco
						this.ckeApartado.Focus();

						break;
				}

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				this.ckeApartado.Focus();
			}
		}

		protected void gvAutoridadDetalle_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String RowNumber = "";
			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				RowNumber = this.gvAutoridadDetalle.DataKeys[e.Row.RowIndex]["RowNumber"].ToString();

				// Tooltip Eliminar
				sTootlTip = "Eliminar apartado [" + RowNumber + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void imgActionCloseWindow_Click(object sender, ImageClickEventArgs e){
			try
            {

                // Cerrar el panel
                this.pnlAction.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

	}
}