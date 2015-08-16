/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatMenu
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de Menús de la aplicación
'
' Notas:
'				Hereda de la clase base SIAQ.BusinessProcess.Page.BPPage
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
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.SysCat
{
	public partial class scatMenu : BPPage
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();

		// Enumeraciones
		private enum MenuActionTypes { DeleteMenu, InsertMenu, ReactivateMenu, UpdateMenu }


		// Rutinas del programador

		private void ClearActionPanel()
		{
			try
			{

				// Limpiar formulario
				this.txtActionNombre.Text = "";
				this.txtActionDescripcion.Text = "";
				this.ddlActionStatus.SelectedIndex = 0;

				// Estado incial de controles
				this.pnlAction.Visible = false;
				this.lblActionTitle.Text = "";
				this.btnAction.Text = "";
				this.lblActionMessage.Text = "";
				this.hddMenu.Value = "";

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void ExportMenu()
		{
			String sKey = "";

			try
			{

				// Formulario (sNombre|tiActivo)
				sKey = this.txtNombre.Text + "|" + this.ddlStatus.SelectedItem.Value;

				// Encriptar la llave
				sKey = gcEncryption.EncryptString(sKey, true);

				// Llamada a rutina del lado del cliente
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "CallAsyncFame('ExcelMaker/xlsMenu.aspx', '" + sKey + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void InsertMenu()
		{
			ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();

			try
			{

				// Formulario
				oENTMenu.sDescripcion = this.txtActionDescripcion.Text.Trim();
				oENTMenu.sNombre = this.txtActionNombre.Text.Trim();
				oENTMenu.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
				oENTResponse = oBPMenu.InsertMenu(oENTMenu);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectMenu();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Menú creado con éxito!'); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectMenu()
		{
			ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();
			String sMessage = "";

			try
			{

				// Formulario
				oENTMenu.sNombre = this.txtNombre.Text;
				oENTMenu.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPMenu.SelectMenu(oENTMenu);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { sMessage = "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');"; }

				// Llenado de controles
				this.gvMenu.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvMenu.DataBind();

				// Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectMenu_ForEdit(Int32 idMenu)
		{
			ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();

			try
			{

				// Formulario
				oENTMenu.idMenu = idMenu;
				oENTMenu.sNombre = "";
				oENTMenu.tiActivo = 2;

				// Transacción
				oENTResponse = oBPMenu.SelectMenu(oENTMenu);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				this.lblActionMessage.Text = oENTResponse.sMessage;

				// Llenado de formulario
				this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
				this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
				this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectStatus()
		{
			try
			{

				// Opciones de DropDownList
				this.ddlStatus.Items.Insert(0, new ListItem("[Todos]", "2"));
				this.ddlStatus.Items.Insert(1, new ListItem("Activos", "1"));
				this.ddlStatus.Items.Insert(2, new ListItem("Inactivos", "0"));

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectStatus_Action()
		{
			try
			{

				// Opciones de DropDownList
				this.ddlActionStatus.Items.Insert(0, new ListItem("[Seleccione]", "2"));
				this.ddlActionStatus.Items.Insert(1, new ListItem("Activo", "1"));
				this.ddlActionStatus.Items.Insert(2, new ListItem("Inactivo", "0"));

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SetPanel(MenuActionTypes MenuActionType, Int32 idItem = 0)
		{
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddMenu.Value = idItem.ToString();

				// Detalle de acción
				switch (MenuActionType)
				{
					case MenuActionTypes.InsertMenu:
						this.lblActionTitle.Text = "Nuevo Menú";
						this.btnAction.Text = "Crear Menú";

						break;

					case MenuActionTypes.UpdateMenu:
						this.lblActionTitle.Text = "Edición de Menú";
						this.btnAction.Text = "Actualizar Menú";
						SelectMenu_ForEdit(idItem);
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

		private void UpdateMenu(Int32 idMenu)
		{
			ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();

			try
			{

				// Formulario
				oENTMenu.idMenu = idMenu;
				oENTMenu.sDescripcion = this.txtActionDescripcion.Text.Trim();
				oENTMenu.sNombre = this.txtActionNombre.Text.Trim();
				oENTMenu.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
				oENTResponse = oBPMenu.UpdateMenu(oENTMenu);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectMenu();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Información actualizada con éxito!'); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void UpdateMenu_Estatus(Int32 idMenu, MenuActionTypes MenuActionType)
		{
			ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();

			try
			{

				// Formulario
				oENTMenu.idMenu = idMenu;
				switch (MenuActionType)
				{
					case MenuActionTypes.DeleteMenu:
						oENTMenu.tiActivo = 0;
						break;
					case MenuActionTypes.ReactivateMenu:
						oENTMenu.tiActivo = 1;
						break;
					default:
						throw new Exception("Opción inválida");
				}

				// Transacción
				oENTResponse = oBPMenu.UpdateMenu_Estatus(oENTMenu);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Actualizar datos
				SelectMenu();

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
				if (this.txtActionNombre.Text.Trim() == "") { throw new Exception("* El campo [Nombre] es requerido"); }

				// Estatus
				if (this.ddlActionStatus.SelectedIndex == 0) { throw new Exception("* El campo [Estatus] es requerido"); }

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e)
		{
			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }

			// Lógica de la página
			try
			{

				// Llenado de controles
				SelectStatus_Action();
				SelectStatus();
				SelectMenu();

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
				if (this.hddMenu.Value == "0")
				{

					InsertMenu();
				}
				else
				{

					UpdateMenu(Int32.Parse(this.hddMenu.Value));
				}

			}
			catch (Exception ex)
			{
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			try
			{

				// Filtrar información
				SelectMenu();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnExportar_Click(object sender, EventArgs e)
		{
			try
			{

				// Exportar información
				ExportMenu();

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
				SetPanel(MenuActionTypes.InsertMenu);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvMenu_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			ImageButton imgEdit = null;
			ImageButton imgAction = null;

			String idMenu = "";
			String sNombreMenu = "";
			String tiActivo = "";

			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgAction = (ImageButton)e.Row.FindControl("imgAction");

				// Datakeys
				idMenu = this.gvMenu.DataKeys[e.Row.RowIndex]["idMenu"].ToString();
				tiActivo = this.gvMenu.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
				sNombreMenu = this.gvMenu.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

				// Tooltip Edición
				sTootlTip = "Editar Menú [" + sNombreMenu + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
				sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Menú [" + sNombreMenu + "]";
				imgAction.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgAction.Attributes.Add("onmouseout", "tooltip.hide();");
				imgAction.Attributes.Add("style", "cursor:hand;");

				// Imagen del botón [imgAction]
				imgAction.ImageUrl = "../../../../Include/Image/Buttons/" + (tiActivo == "1" ? "Delete" : "Restore") + ".png";

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (tiActivo == "1" ? "Delete" : "Restore") + "_Over.png';";

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (tiActivo == "1" ? "Delete" : "Restore") + ".png';";

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			Int32 idMenu = 0;

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
				idMenu = Int32.Parse(this.gvMenu.DataKeys[intRow]["idMenu"].ToString());

				// Reajuste de Command
				if (strCommand == "Action")
				{
					strCommand = (this.gvMenu.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
				}

				// Acción
				switch (strCommand)
				{
					case "Editar":
						SetPanel(MenuActionTypes.UpdateMenu, idMenu);
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
					case "Eliminar":
						UpdateMenu_Estatus(idMenu, MenuActionTypes.DeleteMenu);
						break;
					case "Reactivar":
						UpdateMenu_Estatus(idMenu, MenuActionTypes.ReactivateMenu);
						break;
				}

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvMenu_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvMenu, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
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