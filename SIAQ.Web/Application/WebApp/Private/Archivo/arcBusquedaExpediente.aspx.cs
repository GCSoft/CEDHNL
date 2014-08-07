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
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		private void SelectUsuario(){
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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

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

		private void SelectExpedienteArchivo(){
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.idUsuario = Int32.Parse(this.ddlUsuario.SelectedItem.Value);
				oENTArchivoExpediente.Numero = this.txtExpediente.Text.Trim();
				oENTArchivoExpediente.Quejoso = this.txtQuejoso.Text.Trim();

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectArchivoExpedienteFiltro(oENTArchivoExpediente);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

				// Llenado de control
				this.gvExpediente.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvExpediente.DataBind();

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

                // Estado inicial
				this.gvExpediente.DataSource = null;
				this.gvExpediente.DataBind();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
            }
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
            {

                // Obtener Expedientes
				SelectExpedienteArchivo();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
            }
		}

		protected void gvExpediente_RowCommand(object sender, GridViewCommandEventArgs e){
			String ExpedienteId;

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
				ExpedienteId = this.gvExpediente.DataKeys[intRow]["ExpedienteId"].ToString();

				// Acción
				switch (strCommand){
					case "Editar":
						this.Response.Redirect("arcDetalleExpediente.aspx?key=" + ExpedienteId + "|1", false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
			}
		}

		protected void gvExpediente_RowDataBound(object sender, GridViewRowEventArgs e){
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
				sNumero = gvExpediente.DataKeys[e.Row.RowIndex]["Numero"].ToString();

				// Tooltip Editar Expediente
				sToolTip = "Detalle de expediente [" + sNumero + "]";
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

		protected void gvExpediente_Sorting(object sender, GridViewSortEventArgs e){
			try
            {

				gcCommon.SortGridView(ref this.gvExpediente, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
			}
		}

	}
}