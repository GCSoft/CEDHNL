/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catPais
' Autor:		Daniel.Chavez
' Fecha:		27-Mayo-2014
'
' Descripción:
'           Catálogo de Países de la aplicación
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
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Catalog
{
	public partial class catPais : System.Web.UI.Page
	{


		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();

		// Enumeraciones
		private enum PaisActionTypes { DeletePais, InsertPais, ReactivatePais, UpdatePais }

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
				this.hddPais.Value = "";

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void selectPais()
		{
			BPPais oBPPais = new BPPais();
			ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try
			{

				// Formulario
				oENTPais.Nombre = this.txtNombre.Text.Trim();
				oENTPais.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPPais.SelectPais(oENTPais);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true)"; }

				// Llenado de controles
				this.gvPais.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvPais.DataBind();

				// Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}
			catch (Exception ex) { throw (ex); }

		}

		private void selectPais_ForEdit(Int32 PaisId)
		{

			BPPais oBPPais = new BPPais();
			ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTPais.PaisId = PaisId;
				oENTPais.Nombre = this.txtActionNombre.Text.Trim();
				oENTPais.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPPais.SelectPais(oENTPais);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				this.lblActionMessage.Text = oENTResponse.sMessage;

				// Llenado de formulario
				this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
				this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();
				this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();

			}
			catch (Exception ex) { throw (ex); }

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

		private void SetPanel(PaisActionTypes PaisActionTypes, Int32 idItem = 0)
		{
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddPais.Value = idItem.ToString();

				// Detalle de acción
				switch (PaisActionTypes)
				{
					case PaisActionTypes.InsertPais:
						this.lblActionTitle.Text = "Nuevo País";
						this.btnAction.Text = "Crear País";

						break;

					case PaisActionTypes.UpdatePais:
						this.lblActionTitle.Text = "Edición de País";
						this.btnAction.Text = "Actualizar País";
						selectPais_ForEdit(idItem);
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

		private void updatePais_Estatus(PaisActionTypes PaisActionTypes, Int32 PaisId)
		{

			BPPais oBPPais = new BPPais();
			ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTPais.PaisId = PaisId;

				switch (PaisActionTypes)
				{
					case PaisActionTypes.DeletePais:
						oENTPais.Activo = 0;
						break;
					case PaisActionTypes.ReactivatePais:
						oENTPais.Activo = 1;
						break;

				}

				// Transacción
				oENTResponse = oBPPais.updatecatPais_Estatus(oENTPais);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje Base de Datos
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Actualizar datos
				selectPais();

			}
			catch (Exception ex) { throw (ex); }

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

		private void InsertPais()
		{
			BPPais oBPPais = new BPPais();
			ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTPais.Nombre = this.txtActionNombre.Text.Trim();
				oENTPais.Descripcion = this.txtActionDescripcion.Text.Trim();
				oENTPais.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPPais.insertcatPais(oENTPais);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				selectPais();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('País creado con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex) { throw (ex); }

		}

		private void UpdatePais(Int32 PaisId)
		{
			BPPais oBPPais = new BPPais();
			ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTPais.PaisId = PaisId;
				oENTPais.Nombre = this.txtActionNombre.Text.Trim();
				oENTPais.Descripcion = this.txtActionDescripcion.Text.Trim();
				oENTPais.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPPais.updatecatPais(oENTPais);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				selectPais();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex) { throw (ex); }
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
				selectPais();

				// Estado inicial del formulario
				ClearActionPanel();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}

		}

		protected void gvPais_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			ImageButton imgEdit = null;
			ImageButton imgAction = null;

			String paisId = "";
			String sNombre = "";
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
				paisId = this.gvPais.DataKeys[e.Row.RowIndex]["PaisId"].ToString();
				sNombre = this.gvPais.DataKeys[e.Row.RowIndex]["Nombre"].ToString();
				tiActivo = this.gvPais.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();

				// Tooltip Edición
				sTootlTip = "Editar Pais [" + sNombre + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
				sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar" + "País [" + sNombre + "]");
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
			catch (Exception ex) { throw (ex); }

		}

		protected void gvPais_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			Int32 PaisId = 0;

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
				PaisId = Int32.Parse(this.gvPais.DataKeys[intRow]["PaisId"].ToString());

				// Reajuste de Command
				if (strCommand == "Action")
				{
					strCommand = (this.gvPais.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
				}

				// Acción
				switch (strCommand)
				{

					case "Editar":
						SetPanel(PaisActionTypes.UpdatePais, PaisId);
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
					case "Eliminar":
						updatePais_Estatus(PaisActionTypes.DeletePais, PaisId);
						break;
					case "Reactivar":
						updatePais_Estatus(PaisActionTypes.ReactivatePais, PaisId);
						break;

				}

			}
			catch (Exception ex)
			{ ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true); }

		}

		protected void gvPais_Sorting(object sender, GridViewSortEventArgs e)
		{
			DataTable tblRegionesTelcel = null;
			DataView viewRegionesTelcel = null;

			try
			{

				// Obtener DataTable y DataView del GridView
				tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvPais, true);
				viewRegionesTelcel = new DataView(tblRegionesTelcel);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRegionesTelcel.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvPais.DataSource = viewRegionesTelcel;
				this.gvPais.DataBind();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			try
			{

				// Filtrar información
				selectPais();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnNuevo_Click(object sender, EventArgs e)
		{
			try
			{

				// Nuevo registro
				SetPanel(PaisActionTypes.InsertPais);

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnExportar_Click(object sender, EventArgs e)
		{

		}

		protected void btnAction_Click(object sender, EventArgs e)
		{
			try
			{

				// Validar formulario
				ValidateActionForm();

				// Determinar acción
				if (this.hddPais.Value == "0")
				{

					InsertPais();
				}
				else
				{

					UpdatePais(Int32.Parse(this.hddPais.Value));
				}

			}
			catch (Exception ex)
			{
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
			}
		}


	}
}