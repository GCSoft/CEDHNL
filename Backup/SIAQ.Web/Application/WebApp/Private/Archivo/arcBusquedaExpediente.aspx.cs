/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	arcBusquedaExpediente
' Autor:	Ruben.Cobos
' Fecha:	11-Junio-2014
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
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Archivo
{
	public partial class arcBusquedaExpediente : BPPage
	{


		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void SelectArchivo(){
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.SolicitudNumero = this.txtSolicitudNumero.Text.Trim();
				oENTArchivoExpediente.ExpedienteNumero = this.txtExpedienteNumero.Text.Trim();
				oENTArchivoExpediente.idUsuario = Int32.Parse(this.ddlUsuario.SelectedItem.Value);
				oENTArchivoExpediente.UbicacionExpedienteId = Int32.Parse(this.ddlUbicacionExpediente.SelectedItem.Value);
				oENTArchivoExpediente.FechaDesde = this.wucBeginDate.BeginDate;
				oENTArchivoExpediente.FechaHasta = this.wucEndDate.EndDate;

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectArchivo_Filtro(oENTArchivoExpediente);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.gvArchivo.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvArchivo.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectUbicacionExpediente(){
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.UbicacionExpedienteId = 0;
				oENTArchivoExpediente.Nombre = "";
				oENTArchivoExpediente.Ubicacion = 1; // Sólo ubicaciones

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectUbicacionExpediente(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Llenado de combo
				this.ddlUbicacionExpediente.DataTextField = "Nombre";
				this.ddlUbicacionExpediente.DataValueField = "UbicacionExpedienteId";
				this.ddlUbicacionExpediente.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlUbicacionExpediente.DataBind();

				// Agregar Item de selección
				this.ddlUbicacionExpediente.Items.Insert(0, new ListItem("[Todas]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectUsuario(){
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			BPUsuario oBPUsuario = new BPUsuario();

			try
			{

				// Formulario
				oENTUsuario.idRol = 0;
				oENTUsuario.idArea = 0;
				oENTUsuario.sEmail = "";
				oENTUsuario.sNombre = "";
				oENTUsuario.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlUsuario.DataTextField = "sFullName";
				this.ddlUsuario.DataValueField = "idUsuario";
				this.ddlUsuario.DataSource = oENTResponse.dsResponse.Tables[3];
				this.ddlUsuario.DataBind();

				// Opción todos
				this.ddlUsuario.Items.Insert(0, new ListItem("[Todos]", "0"));

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

				// Llenado de controles
				SelectUsuario();
				SelectUbicacionExpediente();

                // Estado inicial
				this.gvArchivo.DataSource = null;
				this.gvArchivo.DataBind();

				DateTime dtDesde = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
				DateTime dtHasta = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
				this.wucBeginDate.SetDate = dtDesde.ToString();
				this.wucEndDate.SetDate = dtHasta.ToString();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtSolicitudNumero.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtSolicitudNumero.ClientID + "'); }", true);
            }
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
            {

                // Obtener Expedientes
				SelectArchivo();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtSolicitudNumero.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtSolicitudNumero.ClientID + "'); }", true);
            }
		}

		protected void gvArchivo_RowCommand(object sender, GridViewCommandEventArgs e){
			String ArchivoId;
			String strCommand = "";
			Int32 intRow = 0;

			String sKey = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				ArchivoId = this.gvArchivo.DataKeys[intRow]["ArchivoId"].ToString();

				// Acción
				switch (strCommand){
					case "Editar":
						
						// Llave encriptada
						sKey = ArchivoId + "|1";
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("arcDetalleExpediente.aspx?key=" + sKey, false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtSolicitudNumero.ClientID + "'); }", true);
			}
		}

		protected void gvArchivo_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;

			String ExpedienteNumero = "";
			String sImagesAttributes = "";
			String sToolTip = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

				// DataKeys
				ExpedienteNumero = gvArchivo.DataKeys[e.Row.RowIndex]["ExpedienteNumero"].ToString();

				// Tooltip Editar Expediente
				sToolTip = "Detalle de archivo [" + ExpedienteNumero + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "curosr:hand;");

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

		protected void gvArchivo_Sorting(object sender, GridViewSortEventArgs e){
			try
            {

				gcCommon.SortGridView(ref this.gvArchivo, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtSolicitudNumero.ClientID + "'); }", true);
			}
		}

	}
}