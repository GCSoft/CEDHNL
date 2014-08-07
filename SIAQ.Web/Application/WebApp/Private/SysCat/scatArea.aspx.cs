/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatArea
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Áreas de la CEDH de la aplicación
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
	public partial class scatArea : BPPage
	{

		// Utilerías
		GCEncryption gcEncryption = new GCEncryption();
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

		// Enumeraciones
		private enum AreaActionTypes { DeleteArea, InsertArea, ReactivateArea, UpdateArea }


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
				this.hddArea.Value = "";

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void ExportArea()
		{
			String sKey = "";

			try
			{

				// Formulario (sNombre|tiActivo)
				sKey = this.txtNombre.Text + "|" + this.ddlStatus.SelectedItem.Value;

				// Encriptar la llave
				sKey = gcEncryption.EncryptString(sKey, true);

				// Llamada a rutina del lado del cliente
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "CallAsyncFame('ExcelMaker/xlsArea.aspx', '" + sKey + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void InsertArea()
		{
			ENTArea oENTArea = new ENTArea();
			ENTResponse oENTResponse = new ENTResponse();

			BPArea oBPArea = new BPArea();

			try
			{

				// Formulario
				oENTArea.sDescripcion = this.txtActionDescripcion.Text.Trim();
				oENTArea.sNombre = this.txtActionNombre.Text.Trim();
				oENTArea.tiVisitaduria = Int16.Parse(this.ddlActionSistema.SelectedValue);
				oENTArea.tiVisita = Int16.Parse(this.ddlActionSistema.SelectedValue);
				oENTArea.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
				oENTResponse = oBPArea.InsertArea(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectArea();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Área creado con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectArea()
		{
			ENTArea oENTArea = new ENTArea();
			ENTResponse oENTResponse = new ENTResponse();

			BPArea oBPArea = new BPArea();
			String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try
			{

				// Formulario
				oENTArea.sNombre = this.txtNombre.Text;
				oENTArea.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);
				oENTArea.tiVisitaduria = 2;
				oENTArea.tiVisita = 2;

				// Transacción
				oENTResponse = oBPArea.SelectArea(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sMessage) + "', 'Warning', false);"; }

				// Llenado de controles
				this.gvArea.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvArea.DataBind();

				// Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectArea_ForEdit(Int32 idArea)
		{
			ENTArea oENTArea = new ENTArea();
			ENTResponse oENTResponse = new ENTResponse();

			BPArea oBPArea = new BPArea();

			try
			{

				// Formulario
				oENTArea.idArea = idArea;
				oENTArea.sNombre = "";
				oENTArea.tiActivo = 2;
				oENTArea.tiVisitaduria = 2;
				oENTArea.tiVisita = 2;

				// Transacción
				oENTResponse = oBPArea.SelectArea(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				this.lblActionMessage.Text = oENTResponse.sMessage;

				// Llenado de formulario
				this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
				this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
				this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();
				this.ddlActionSistema.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiSistema"].ToString();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void SelectSistema_Action()
		{
			try
			{

				// Opciones de DropDownList
				this.ddlActionSistema.Items.Insert(0, new ListItem("[Seleccione]", "2"));
				this.ddlActionSistema.Items.Insert(1, new ListItem("Si", "1"));
				this.ddlActionSistema.Items.Insert(2, new ListItem("No", "0"));

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

		private void SetPanel(AreaActionTypes AreaActionType, Int32 idItem = 0)
		{
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddArea.Value = idItem.ToString();

				// Detalle de acción
				switch (AreaActionType)
				{
					case AreaActionTypes.InsertArea:
						this.lblActionTitle.Text = "Nueva Área";
						this.btnAction.Text = "Crear Área";

						break;

					case AreaActionTypes.UpdateArea:
						this.lblActionTitle.Text = "Edición de Área";
						this.btnAction.Text = "Actualizar Área";
						SelectArea_ForEdit(idItem);
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

		private void UpdateArea(Int32 idArea)
		{
			ENTArea oENTArea = new ENTArea();
			ENTResponse oENTResponse = new ENTResponse();

			BPArea oBPArea = new BPArea();

			try
			{

				// Formulario
				oENTArea.idArea = idArea;
				oENTArea.sDescripcion = this.txtActionDescripcion.Text.Trim();
				oENTArea.sNombre = this.txtActionNombre.Text.Trim();
				oENTArea.tiVisitaduria = Int16.Parse(this.ddlActionSistema.SelectedValue);
				oENTArea.tiVisita = Int16.Parse(this.ddlActionSistema.SelectedValue);
				oENTArea.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

				// Transacción
				oENTResponse = oBPArea.UpdateArea(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectArea();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void UpdateArea_Estatus(Int32 idArea, AreaActionTypes AreaActionType)
		{
			ENTArea oENTArea = new ENTArea();
			ENTResponse oENTResponse = new ENTResponse();

			BPArea oBPArea = new BPArea();

			try
			{

				// Formulario
				oENTArea.idArea = idArea;
				switch (AreaActionType)
				{
					case AreaActionTypes.DeleteArea:
						oENTArea.tiActivo = 0;
						break;
					case AreaActionTypes.ReactivateArea:
						oENTArea.tiActivo = 1;
						break;
					default:
						throw new Exception("Opción inválida");
				}

				// Transacción
				oENTResponse = oBPArea.UpdateArea_Estatus(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Actualizar datos
				SelectArea();

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

				// Sistema
				if (this.ddlActionSistema.SelectedIndex == 0) { throw new Exception("* El campo [Sistema] es requerido"); }

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
				SelectSistema_Action();
				SelectStatus_Action();
				SelectStatus();
				SelectArea();

				// Estado inicial del formulario
				ClearActionPanel();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnAction_Click(object sender, EventArgs e)
		{
			try
			{

				// Validar formulario
				ValidateActionForm();

				// Determinar acción
				if (this.hddArea.Value == "0")
				{

					InsertArea();
				}
				else
				{

					UpdateArea(Int32.Parse(this.hddArea.Value));
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
				SelectArea();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnExportar_Click(object sender, EventArgs e)
		{
			try
			{

				// Exportar información
				ExportArea();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnNuevo_Click(object sender, EventArgs e)
		{
			try
			{

				// Nuevo registro
				SetPanel(AreaActionTypes.InsertArea);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvArea_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			ImageButton imgEdit = null;
			ImageButton imgAction = null;

			String idArea = "";
			String sNombreArea = "";
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
				idArea = this.gvArea.DataKeys[e.Row.RowIndex]["idArea"].ToString();
				tiActivo = this.gvArea.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
				sNombreArea = this.gvArea.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

				// Tooltip Edición
				sTootlTip = "Editar Área [" + sNombreArea + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
				sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Área [" + sNombreArea + "]";
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

		protected void gvArea_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			Int32 idArea = 0;

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
				idArea = Int32.Parse(this.gvArea.DataKeys[intRow]["idArea"].ToString());

				// Reajuste de Command
				if (strCommand == "Action")
				{
					strCommand = (this.gvArea.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
				}

				// Acción
				switch (strCommand)
				{
					case "Editar":
						SetPanel(AreaActionTypes.UpdateArea, idArea);
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
					case "Eliminar":
						UpdateArea_Estatus(idArea, AreaActionTypes.DeleteArea);
						break;
					case "Reactivar":
						UpdateArea_Estatus(idArea, AreaActionTypes.ReactivateArea);
						break;
				}

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvArea_Sorting(object sender, GridViewSortEventArgs e)
		{
			try
			{

				gcCommon.SortGridView(ref this.gvArea, ref this.hddSort, e.SortExpression);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

	}
}