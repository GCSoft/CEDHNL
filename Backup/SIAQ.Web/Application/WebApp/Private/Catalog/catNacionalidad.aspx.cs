/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catNacionalidad
' Autor:	Daniel.Chavez
' Fecha:	10-Junio-2014
'
' Descripción:
'           Catálogo de Nacionalidad de la aplicación
'
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
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;


namespace SIAQ.Web.Application.WebApp.Private.Catalog
{
	public partial class catNacionalidad : BPPage
	{
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

		// Enumeraciones
		private enum NacionalidadActionTypes { DeleteNacionalidad, InsertNacionalidad, ReactivateNacionalidad, UpdateNacionalidad }


		// Rutinas del programador

		private void ClearActionPanel()
		{
			try
			{

				// Limpiar formulario
				this.txtActionNombre.Text = "";
				this.txtActionDescripcion.Text = "";


				// Estado incial de controles
				this.pnlAction.Visible = false;
				this.lblActionTitle.Text = "";
				this.btnAction.Text = "";
				this.lblActionMessage.Text = "";
				this.hddNacionalidad.Value = "";

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void insertNacionalidad()
		{
			BPNacionalidad oBPNacionalidad = new BPNacionalidad();
			ENTNacionalidad oENTNacionalidad = new ENTNacionalidad();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formilario
				oENTNacionalidad.Nombre = this.txtActionNombre.Text.Trim();
				oENTNacionalidad.Descripcion = this.txtActionDescripcion.Text.Trim();


				// Transacción
				oENTResponse = oBPNacionalidad.insertcatNacionalidad(oENTNacionalidad);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar Grid
				selectNacionalidad();

				// Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Nacionalidad creado con éxito!'); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex) { throw (ex); }
		}

		private void selectNacionalidad()
		{
			BPNacionalidad oBPNacionalidad = new BPNacionalidad();
			ENTNacionalidad oENTNacionalidad = new ENTNacionalidad();
			ENTResponse oENTResponse = new ENTResponse();

			String sMessage = "";

			try
			{

				// Formulario
				oENTNacionalidad.Nombre = this.txtNombre.Text.Trim();


				// Transacción
				oENTResponse = oBPNacionalidad.selectcatNacionalidad(oENTNacionalidad);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { sMessage = "alert('" + oENTResponse.sMessage + "');"; }

				// Llenado de controles
				this.gvNacionalidad.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvNacionalidad.DataBind();

				// Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}
			catch (Exception ex) { throw (ex); }

		}

		private void selectNacionalidad_ForEdit(Int32 NacionalidadId)
		{
			BPNacionalidad oBPNacionalidad = new BPNacionalidad();
			ENTNacionalidad oENTNacionalidad = new ENTNacionalidad();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTNacionalidad.NacionalidadId = NacionalidadId;
				oENTNacionalidad.Nombre = this.txtActionNombre.Text.Trim();


				// Transacción
				oENTResponse = oBPNacionalidad.selectcatNacionalidad(oENTNacionalidad);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				this.lblActionMessage.Text = oENTResponse.sMessage;

				// Llenado de controles
				this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
				this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();



			}
			catch (Exception ex) { throw (ex); }

		}

		private void SetPanel(NacionalidadActionTypes NacionalidadActionTypes, Int32 NacionalidadId = 0)
		{
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddNacionalidad.Value = NacionalidadId.ToString();

				// Detalle de acción
				switch (NacionalidadActionTypes)
				{
					case NacionalidadActionTypes.InsertNacionalidad:
						this.lblActionTitle.Text = "Nueva Nacionalidad";
						this.btnAction.Text = "Crear Nacionalidad";

						break;

					case NacionalidadActionTypes.UpdateNacionalidad:
						this.lblActionTitle.Text = "Edición de Nacionalidad";
						this.btnAction.Text = "Actualizar Nacionalidad";
						selectNacionalidad_ForEdit(NacionalidadId);

						break;

					default:
						throw (new Exception("Opción inválida"));
				}

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void ValidateActionForm()
		{
			try
			{
				// Nombre
				if (this.txtActionNombre.Text.Trim() == "") { throw new Exception("El campo [Nombre] es requerido"); }


			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void updateNacionalidad(Int32 NacionalidadId)
		{
			BPNacionalidad oBPNacionalidad = new BPNacionalidad();
			ENTNacionalidad oENTNacionalidad = new ENTNacionalidad();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTNacionalidad.NacionalidadId = NacionalidadId;
				oENTNacionalidad.Nombre = this.txtActionNombre.Text.Trim();
				oENTNacionalidad.Descripcion = this.txtActionDescripcion.Text.Trim();


				// Transacción
				oENTResponse = oBPNacionalidad.updatecatNacionalidad(oENTNacionalidad);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				selectNacionalidad();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Información actualizada con éxito!'); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex) { throw (ex); }

		}


		// Eventos de la pagina

		protected void Page_Load(object sender, EventArgs e)
		{
			// Validación. Solo la primera vez que se ejecuta la página
			if (this.Page.IsPostBack) { return; }

			// Lógica de la página
			try
			{

				// Llenado de controles
				selectNacionalidad();

				// Estado inicial del formulario
				ClearActionPanel();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}

		}

		protected void btnAction_Click(object sender, EventArgs e)
		{
			try
			{

				// Validar formulario
				ValidateActionForm();

				// Determinar acción
				if (this.hddNacionalidad.Value == "0")
				{

					insertNacionalidad();
				}
				else
				{

					updateNacionalidad(Int32.Parse(this.hddNacionalidad.Value));
				}
			}
			catch (Exception ex)
			{
				lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{

			try
			{

				// Filtrar información
				selectNacionalidad();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}

		}

		protected void btnNuevo_Click(object sender, EventArgs e)
		{

			try
			{

				// Nuevo registro
				SetPanel(NacionalidadActionTypes.InsertNacionalidad);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvNacionalidad_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			Int32 NacionalidadId = 0;

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
				NacionalidadId = Int32.Parse(this.gvNacionalidad.DataKeys[intRow]["NacionalidadId"].ToString());

				// Reajuste de Command
				//if (strCommand == "Action")
				//{

				//    strCommand = (this.gvLugar.DataKeys[intRow]["Activo"].ToString() == "0" ? "Reactivar" : "Eliminar");
				//}

				// Acción
				switch (strCommand)
				{
					case "Editar":
						SetPanel(NacionalidadActionTypes.UpdateNacionalidad, NacionalidadId);
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
					//case "Eliminar":
					//    updateEstado_Estatus(EstadoActionTypes.DeleteEstado, EstadoId);
					//    break;
					//case "Reactivar":
					//    updateEstado_Estatus(EstadoActionTypes.ReactivateEstado, EstadoId);
					//    break;

				}

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvNacionalidad_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			ImageButton imgEdit = null;
			//ImageButton imgAction = null;

			String NacionalidadId = "";
			String sNombre = "";


			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				//imgAction = (ImageButton)e.Row.FindControl("imgAction");

				// Datakeys
				NacionalidadId = this.gvNacionalidad.DataKeys[e.Row.RowIndex]["NacionalidadId"].ToString();
				sNombre = this.gvNacionalidad.DataKeys[e.Row.RowIndex]["Nombre"].ToString();


				// Tooltip Edición
				sTootlTip = "Editar Nacionalidad [" + sNombre + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
				//sTootlTip = (Activo == "1" ? "Eliminar" : "Reactivar" + "Nacionalidad [" + sNombre + "]");
				//imgAction.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				//imgAction.Attributes.Add("onmouseout", "tooltip.hide();");
				//imgAction.Attributes.Add("style", "cursor:hand;");

				// Imagen del botón [imgAction]
				// imgAction.ImageUrl = "../../../../Include/Image/Buttons/" + (Activo == "1" ? "Delete" : "Restore") + ".png";

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				//sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (Activo == "1" ? "Delete" : "Restore") + "_Over.png';";

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				//sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (Activo == "1" ? "Delete" : "Restore") + ".png';";

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}
			catch (Exception ex) { throw (ex); }
		}

		protected void gvNacionalidad_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{

				gcCommon.SortGridView(ref this.gvNacionalidad, ref this.hddSort, e.SortExpression);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}

		}

		protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
		{
			try
			{

				// Cancelar transacción
				ClearActionPanel();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}


	}
}