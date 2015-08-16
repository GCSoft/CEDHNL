/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catFuncionario
' Autor:		Ruben.Cobos
' Fecha:		06-Abril-2014
'
' Descripción:
'           Catálogo de funcionarios de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// Referencias manuales
using GCUtility.Function;
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Catalog
{
	public partial class catFuncionario : BPPage
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

		// Enumeraciones
		private enum FuncionarioActionTypes { InsertFuncionario, UpdateFuncionario }


		// Rutinas del programador

		private void ClearActionPanel(){
			try
			{

				// Limpiar formulario
				this.ddlActionPuesto.SelectedIndex = 0;
				this.ddlActionTitulo.SelectedIndex = 0;
				this.wucBusquedaUsuario.UsuarioID = 0;
				this.wucBusquedaUsuario.Area = "";
				this.wucCalendar.SetCurrentDate();

				// Estado incial de controles
				this.pnlAction.Visible = false;
				this.lblActionTitle.Text = "";
				this.btnAction.Text = "";
				this.lblActionMessage.Text = "";
				this.hddFuncionario.Value = "";

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void DeleteFuncionario(Int32 idFuncionario){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario oBPFuncionario = new BPFuncionario();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = idFuncionario;

				// Transacción
				oENTResponse = oBPFuncionario.DeleteFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Funcionario eliminado con éxito!');", true);

				// Actualizar datos
				SelectFuncionario();

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void InsertFuncionario(){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario oBPFuncionario = new BPFuncionario();

			try
			{

				// Formulario
				oENTFuncionario.idUsuario = this.wucBusquedaUsuario.UsuarioID;
				oENTFuncionario.TituloId = Int16.Parse(this.ddlActionTitulo.SelectedValue);
				oENTFuncionario.PuestoId = Int16.Parse(this.ddlActionPuesto.SelectedValue);
				oENTFuncionario.FechaIngreso = this.wucCalendar.BeginDate;

				// Transacción
				oENTResponse = oBPFuncionario.InsertFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectFuncionario();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Funcionario creado con éxtito!'); focusControl('" + this.ddlArea.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectArea(){
			ENTArea oENTArea = new ENTArea();
			ENTResponse oENTResponse = new ENTResponse();

			BPArea oBPArea = new BPArea();

			try
			{

				// Formulario
				oENTArea.sNombre = "";
				oENTArea.tiActivo = 1;
				oENTArea.tiVisitaduria = 2;
				oENTArea.tiVisita = 1;

				// Transacción
				oENTResponse = oBPArea.SelectArea(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Llenado de combo
				this.ddlArea.DataTextField = "sNombre";
				this.ddlArea.DataValueField = "idArea";
				this.ddlArea.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlArea.DataBind();

				// Agregar Item de selección
				this.ddlArea.Items.Insert(0, new ListItem("[Todas]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectFuncionario(){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario oBPFuncionario = new BPFuncionario();
			String sMessage = "";

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = 0;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = Int32.Parse(this.ddlArea.SelectedItem.Value);
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = this.txtNombre.Text;

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { sMessage = "alert('" + oENTResponse.sMessage + "');"; }

				// Llenado de controles
				this.gvFuncionario.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvFuncionario.DataBind();

				// Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectFuncionario_ForEdit(Int32 idFuncionario){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario oBPFuncionario = new BPFuncionario();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = idFuncionario;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = 0;
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				this.lblActionMessage.Text = oENTResponse.sMessage;

				// Llenado de formulario
				this.ddlActionPuesto.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["PuestoId"].ToString();
				this.ddlActionTitulo.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["TituloId"].ToString();
				this.wucBusquedaUsuario.UsuarioID = Int32.Parse(oENTResponse.dsResponse.Tables[1].Rows[0]["idUsuario"].ToString());
				this.wucBusquedaUsuario.Area = oENTResponse.dsResponse.Tables[1].Rows[0]["sArea"].ToString();
				this.wucCalendar.SetDate = oENTResponse.dsResponse.Tables[1].Rows[0]["dtFechaIngreso"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectPuesto(){
			ENTPuesto oENTPuesto = new ENTPuesto();
			ENTResponse oENTResponse = new ENTResponse();

			BPPuesto oBPPuesto = new BPPuesto();

			try
			{

				// Formulario
				oENTPuesto.PuestoId = 0;
				oENTPuesto.Nombre = "";

				// Transacción
				oENTResponse = oBPPuesto.SelectPuesto(oENTPuesto);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Llenado de combo
				this.ddlActionPuesto.DataTextField = "Nombre";
				this.ddlActionPuesto.DataValueField = "PuestoId";
				this.ddlActionPuesto.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlActionPuesto.DataBind();

				// Agregar Item de selección
				this.ddlActionPuesto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectTitulo(){
			ENTTitulo oENTTitulo = new ENTTitulo();
			ENTResponse oENTResponse = new ENTResponse();

			BPTitulo oBPTitulo = new BPTitulo();

			try
			{

				// Formulario
				oENTTitulo.TituloId = 0;
				oENTTitulo.Nombre = "";

				// Transacción
				oENTResponse = oBPTitulo.SelectTitulo(oENTTitulo);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Llenado de combo
				this.ddlActionTitulo.DataTextField = "Nombre";
				this.ddlActionTitulo.DataValueField = "TituloId";
				this.ddlActionTitulo.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlActionTitulo.DataBind();

				// Agregar Item de selección
				this.ddlActionTitulo.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SetPanel(FuncionarioActionTypes FuncionarioActionType, Int32 idItem = 0){
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddFuncionario.Value = idItem.ToString();

				// Detalle de acción
				switch (FuncionarioActionType){
					case FuncionarioActionTypes.InsertFuncionario:
						this.lblActionTitle.Text = "Nuevo Funcionario";
						this.btnAction.Text = "Crear Funcionario";

						break;

					case FuncionarioActionTypes.UpdateFuncionario:
						this.lblActionTitle.Text = "Edición de Funcionario";
						this.btnAction.Text = "Actualizar Funcionario";
						SelectFuncionario_ForEdit(idItem);
						break;

					default:
						throw (new Exception("Opción inválida"));
				}

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "WAFocus ('" + this.ddlActionPuesto.ClientID + "'); ", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void UpdateFuncionario(Int32 idFuncionario){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario oBPFuncionario = new BPFuncionario();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = idFuncionario;
				oENTFuncionario.idUsuario = this.wucBusquedaUsuario.UsuarioID;
				oENTFuncionario.TituloId = Int16.Parse(this.ddlActionTitulo.SelectedValue);
				oENTFuncionario.PuestoId = Int16.Parse(this.ddlActionPuesto.SelectedValue);
				oENTFuncionario.FechaIngreso = this.wucCalendar.BeginDate;

				// Transacción
				oENTResponse = oBPFuncionario.UpdateFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectFuncionario();

				// Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Información actualizada con éxito!'); focusControl('" + this.ddlArea.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void ValidateActionForm(){
			try
			{

				// Puesto
				if (this.ddlActionPuesto.SelectedIndex == 0) { throw new Exception("* El campo [Puesto] es requerido"); }

				// Título
				if (this.ddlActionTitulo.SelectedIndex == 0) { throw new Exception("* El campo [Título] es requerido"); }

				// Usuario
				if (this.wucBusquedaUsuario.UsuarioID == 0) { throw new Exception("* Es necesario seleccionar un usuario para convertirlo en funcionario"); }

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }

			// Lógica de la página
			try
			{

				// Llenado de controles
				SelectArea();
				SelectFuncionario();
				SelectPuesto();
				SelectTitulo();

				// Estado inicial del formulario
				ClearActionPanel();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlArea.ClientID + "');", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
		}

		protected void btnAction_Click(object sender, EventArgs e){
			try
			{

				// Validar formulario
				ValidateActionForm();

				// Determinar acción
				if (this.hddFuncionario.Value == "0"){

					InsertFuncionario();
				}else{

					UpdateFuncionario(Int32.Parse(this.hddFuncionario.Value));
				}

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionPuesto.ClientID + "');", true);
			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
			{

				// Filtrar información
				SelectFuncionario();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
		}

		protected void btnNuevo_Click(object sender, EventArgs e){
			try
			{

				// Nuevo registro
				SetPanel(FuncionarioActionTypes.InsertFuncionario);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
		}

		protected void gvFuncionario_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgAction = null;

			String idFuncionario = "";
			String sNombre = "";

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
				idFuncionario = this.gvFuncionario.DataKeys[e.Row.RowIndex]["FuncionarioId"].ToString();
				sNombre = this.gvFuncionario.DataKeys[e.Row.RowIndex]["sFullName"].ToString();

				// Tooltip Edición
				sTootlTip = "Editar Funcionario [" + sNombre + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
				sTootlTip = "Eliminar Funcionario [" + sNombre + "]";
				imgAction.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgAction.Attributes.Add("onmouseout", "tooltip.hide();");
				imgAction.Attributes.Add("style", "cursor:hand;");

				// Imagen del botón [imgAction]
				imgAction.ImageUrl = "../../../../Include/Image/Buttons/Delete.png";

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvFuncionario_RowCommand(object sender, GridViewCommandEventArgs e){
			Int32 idFuncionario = 0;

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
				idFuncionario = Int32.Parse(this.gvFuncionario.DataKeys[intRow]["FuncionarioId"].ToString());

				// Acción
				switch (strCommand){
					case "Editar":
						SetPanel(FuncionarioActionTypes.UpdateFuncionario, idFuncionario);
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

					case "Eliminar":
						DeleteFuncionario(idFuncionario);
						break;

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
		}

		protected void gvFuncionario_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvFuncionario, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
		}

		protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Cancelar transacción
				ClearActionPanel();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
		}

	}
}