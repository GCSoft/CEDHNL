/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatSubMenu
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de Sub-SubMenús de la aplicación
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
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.SysCat
{
   public partial class scatSubMenu : BPPage
   {
      
      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      // Enumeraciones
      private enum SubMenuActionTypes { DeleteSubMenu, InsertSubMenu, ReactivateSubMenu, UpdateSubMenu }

      
      // Rutinas del programador

      private void ClearActionPanel(){
         try
         {

            // Limpiar formulario
            this.ddlActionMenu.SelectedIndex = 0;
            this.txtActionNombre.Text = "";
            this.txtActionDescripcion.Text = "";
            this.txtActionPageName.Text = "";
            this.txtActionURL.Text = "";
            this.ddlActionStatus.SelectedIndex = 0;
            this.ddlActionRequired.SelectedIndex = 0;

            // Estado incial de controles
            this.pnlAction.Visible = false;
            this.lblActionTitle.Text = "";
            this.btnAction.Text = "";
            this.lblActionMessage.Text = "";
            this.hddSubMenu.Value = "";

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void ExportSubMenu(){
         String sKey = "";
			
			try{

            // Formulario (idMenu|sNombre|tiActivo)
            sKey = this.ddlMenu.SelectedItem.Value + "|" + this.txtNombre.Text + "|" + this.ddlStatus.SelectedItem.Value;
				
				// Encriptar la llave
				sKey = utilEncryption.EncryptString(sKey, true);
				
				// Llamada a rutina del lado del cliente
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "CallAsyncFame('ExcelMaker/xlsSubMenu.aspx', '" + sKey + "');", true);
			
			}catch (Exception ex){
				throw (ex);
			}
      }

      private void InsertSubMenu(){
         ENTSubMenu oENTSubMenu = new ENTSubMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPSubMenu oBPSubMenu = new BPSubMenu();

			try{

            // Formulario
            oENTSubMenu.idMenu         = Int32.Parse(this.ddlActionMenu.SelectedValue);
            oENTSubMenu.sDescripcion   = this.txtActionDescripcion.Text.Trim();
            oENTSubMenu.sNombre        = this.txtActionNombre.Text.Trim();
            oENTSubMenu.sPageName      = this.txtActionPageName.Text.Trim();
            oENTSubMenu.sURL           = this.txtActionURL.Text.Trim();
            oENTSubMenu.tiActivo       = Int16.Parse(this.ddlActionStatus.SelectedValue);
            oENTSubMenu.tiRequired     = Int16.Parse(this.ddlActionRequired.SelectedValue);

				// Transacción
            oENTResponse = oBPSubMenu.InsertSubMenu(oENTSubMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectSubMenu();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Menú creado con éxito! Recuerde agregarlo en los roles de los clientes.', 'Success', true); focusControl('" + this.ddlMenu.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectRequired_Action(){
         try
         {

            // Opciones de DropDownList
            this.ddlActionRequired.Items.Insert(0, new ListItem("[Seleccione]", "2"));
            this.ddlActionRequired.Items.Insert(1, new ListItem("Si", "1"));
            this.ddlActionRequired.Items.Insert(2, new ListItem("No", "0"));

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void SelectMenu(){
         ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();

			try{

            // Formulario
            oENTMenu.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPMenu.SelectMenu(oENTMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
				this.ddlMenu.DataTextField = "sNombre";
				this.ddlMenu.DataValueField = "idMenu";
				this.ddlMenu.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlMenu.DataBind();

				// Agregar Item de selección
				this.ddlMenu.Items.Insert(0, new ListItem("[Todos]", "0"));

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectMenu_Action(){
         ENTMenu oENTMenu = new ENTMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPMenu oBPMenu = new BPMenu();

			try{

            // Formulario
            oENTMenu.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPMenu.SelectMenu(oENTMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Llenado de combo
            this.ddlActionMenu.DataTextField = "sNombre";
            this.ddlActionMenu.DataValueField = "idMenu";
            this.ddlActionMenu.DataSource = oENTResponse.dsResponse.Tables[1];
            this.ddlActionMenu.DataBind();

				// Agregar Item de selección
            this.ddlActionMenu.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectSubMenu(){
         ENTSubMenu oENTSubMenu = new ENTSubMenu();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPSubMenu oBPSubMenu = new BPSubMenu();
         String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try{

            // Información de Sesión
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTSubMenu.idRol = oENTSession.idRol;
            oENTSubMenu.idSubMenu = 0;
            oENTSubMenu.idMenu = Int32.Parse(this.ddlMenu.SelectedItem.Value);
            oENTSubMenu.sNombre = this.txtNombre.Text;
            oENTSubMenu.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPSubMenu.SelectSubMenu(oENTSubMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

            // Llenado de controles
            this.gvSubMenu.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvSubMenu.DataBind();

            // Mensaje al usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectSubMenu_ForEdit(Int32 idSubMenu){
         ENTSubMenu oENTSubMenu = new ENTSubMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPSubMenu oBPSubMenu = new BPSubMenu();

			try{

            // Formulario
            oENTSubMenu.idSubMenu = idSubMenu;
            oENTSubMenu.idMenu = 0;
            oENTSubMenu.sNombre = "";
            oENTSubMenu.tiActivo = 2;

				// Transacción
				oENTResponse = oBPSubMenu.SelectSubMenu(oENTSubMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            this.lblActionMessage.Text = oENTResponse.sMessage;

            // Llenado de formulario
            this.ddlActionMenu.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["idMenu"].ToString();
            this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombreSubMenu"].ToString();
            this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.txtActionPageName.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sPageName"].ToString();
            this.txtActionURL.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sURL"].ToString();
            this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();
            this.ddlActionRequired.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiRequired"].ToString();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectStatus(){
         try
         {

            // Opciones de DropDownList
            this.ddlStatus.Items.Insert(0, new ListItem("[Todos]", "2"));
            this.ddlStatus.Items.Insert(1, new ListItem("Activos", "1"));
            this.ddlStatus.Items.Insert(2, new ListItem("Inactivos", "0"));

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void SelectStatus_Action(){
         try
         {

            // Opciones de DropDownList
            this.ddlActionStatus.Items.Insert(0, new ListItem("[Seleccione]", "2"));
            this.ddlActionStatus.Items.Insert(1, new ListItem("Activo", "1"));
            this.ddlActionStatus.Items.Insert(2, new ListItem("Inactivo", "0"));

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void SetPanel(SubMenuActionTypes SubMenuActionType, Int32 idItem = 0){
         try
         {

            // Acciones comunes
            this.pnlAction.Visible = true;
            this.hddSubMenu.Value = idItem.ToString();

            // Detalle de acción
            switch (SubMenuActionType){
               case SubMenuActionTypes.InsertSubMenu:
                  this.lblActionTitle.Text = "Nuevo SubMenú";
                  this.btnAction.Text = "Crear SubMenú";
                  
                  break;

               case SubMenuActionTypes.UpdateSubMenu:
                  this.lblActionTitle.Text = "Edición de SubMenú";
                  this.btnAction.Text = "Actualizar SubMenú";
                  SelectSubMenu_ForEdit(idItem);
                  break;

               default:
                  throw (new Exception("Opción inválida"));
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionMenu.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateSubMenu(Int32 idSubMenu){
         ENTSubMenu oENTSubMenu = new ENTSubMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPSubMenu oBPSubMenu = new BPSubMenu();

			try{

            // Formulario
            oENTSubMenu.idSubMenu      = idSubMenu;
            oENTSubMenu.idMenu         = Int32.Parse(this.ddlActionMenu.SelectedValue);
            oENTSubMenu.sDescripcion   = this.txtActionDescripcion.Text.Trim();
            oENTSubMenu.sNombre        = this.txtActionNombre.Text.Trim();
            oENTSubMenu.sPageName      = this.txtActionPageName.Text.Trim();
            oENTSubMenu.sURL           = this.txtActionURL.Text.Trim();
            oENTSubMenu.tiActivo       = Int16.Parse(this.ddlActionStatus.SelectedValue);
            oENTSubMenu.tiRequired     = Int16.Parse(this.ddlActionRequired.SelectedValue);

				// Transacción
            oENTResponse = oBPSubMenu.UpdateSubMenu(oENTSubMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectSubMenu();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + this.ddlMenu.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdateSubMenu_Estatus(Int32 idSubMenu, SubMenuActionTypes SubMenuActionType){
         ENTSubMenu oENTSubMenu = new ENTSubMenu();
			ENTResponse oENTResponse = new ENTResponse();

			BPSubMenu oBPSubMenu = new BPSubMenu();

			try{

            // Formulario
            oENTSubMenu.idSubMenu = idSubMenu;
            switch (SubMenuActionType){
               case SubMenuActionTypes.DeleteSubMenu:
                  oENTSubMenu.tiActivo = 0;
                  break;
               case SubMenuActionTypes.ReactivateSubMenu:
                  oENTSubMenu.tiActivo = 1;
                  break;
               default:
                  throw new Exception("Opción inválida");
            }

				// Transacción
            oENTResponse = oBPSubMenu.UpdateSubMenu_Estatus(oENTSubMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Actualizar datos
            SelectSubMenu();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void ValidateActionForm(){
         try
         {

            // Menú
            if (this.ddlActionMenu.SelectedIndex == 0) { throw new Exception("* El campo [Menú] es requerido"); }

            // Nombre
            if(this.txtActionNombre.Text.Trim() == ""){ throw new Exception("* El campo [Nombre] es requerido"); }

            // ASPX
            if (this.txtActionPageName.Text.Trim() == "") { throw new Exception("* El campo [ASPX] es requerido"); }

            // URL
            if (this.txtActionURL.Text.Trim() == "") { throw new Exception("* El campo [URL] es requerido"); }

            // Estatus
            if (this.ddlActionStatus.SelectedIndex == 0) { throw new Exception("* El campo [Estatus] es requerido"); }

            // Requerido
            if (this.ddlActionRequired.SelectedIndex == 0) { throw new Exception("* El campo [Requerido] es requerido"); }

         }catch (Exception ex){
            throw (ex);
         }
      }


      // Eventos de la página
      
      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) { return; }

         // Lógica de la página
         try{

            // Llenado de controles
            SelectStatus();
            SelectMenu();
            SelectSubMenu();

            SelectStatus_Action();
            SelectMenu_Action();
            SelectRequired_Action();

            // Estado inicial del formulario
            ClearActionPanel();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlMenu.ClientID + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
         }
      }

      protected void btnAction_Click(object sender, EventArgs e){
         try{

            // Validar formulario
            ValidateActionForm();

            // Determinar acción
            if (this.hddSubMenu.Value == "0"){

               InsertSubMenu();
            }else{

               UpdateSubMenu(Int32.Parse(this.hddSubMenu.Value));
            }

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionMenu.ClientID + "');", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectSubMenu();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
         }
      }

      protected void btnExportar_Click(object sender, EventArgs e){
         try{

            // Exportar información
            ExportSubMenu();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
         }
      }

      protected void btnNuevo_Click(object sender, EventArgs e){
         try{

            // Nuevo registro
            SetPanel(SubMenuActionTypes.InsertSubMenu);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
         }
      }

      protected void gvSubMenu_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
         ImageButton imgAction = null;

         String idSubMenu = "";
         String sNombreMenu = "";
         String sNombreSubMenu = "";
         String tiActivo = "";

         String sImagesAttributes = "";
         String sTootlTip = "";
			
			try{

            // Validación de que sea fila
            if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
            imgAction = (ImageButton)e.Row.FindControl("imgAction");

				// Datakeys
            idSubMenu = this.gvSubMenu.DataKeys[e.Row.RowIndex]["idSubMenu"].ToString();
            tiActivo = this.gvSubMenu.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
            sNombreMenu = this.gvSubMenu.DataKeys[e.Row.RowIndex]["sNombreMenu"].ToString();
            sNombreSubMenu = this.gvSubMenu.DataKeys[e.Row.RowIndex]["sNombreSubMenu"].ToString();

            // Tooltip Edición
            sTootlTip = "Editar SubMenú [" + sNombreMenu + "/" + sNombreSubMenu + "]";
            imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
            imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Action
            sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " SubMenú [" + sNombreMenu + "/" + sNombreSubMenu + "]";
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
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvSubMenu_RowCommand(object sender, GridViewCommandEventArgs e){
         Int32 idSubMenu = 0;

			String strCommand = "";
			Int32 intRow = 0;
			
			try{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				idSubMenu = Int32.Parse(this.gvSubMenu.DataKeys[intRow]["idSubMenu"].ToString());

            // Reajuste de Command
            if (strCommand == "Action"){
               strCommand = (this.gvSubMenu.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
            }

				// Acción
				switch (strCommand){
					case "Editar":
                  SetPanel(SubMenuActionTypes.UpdateSubMenu, idSubMenu);
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
               case "Eliminar":
                  UpdateSubMenu_Estatus(idSubMenu, SubMenuActionTypes.DeleteSubMenu);
                  break;
               case "Reactivar":
                  UpdateSubMenu_Estatus(idSubMenu, SubMenuActionTypes.ReactivateSubMenu);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
			}
		}

		protected void gvSubMenu_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblRegionesTelcel = null;
			DataView viewRegionesTelcel = null;
			
			try{

				// Obtener DataTable y DataView del GridView
				tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvSubMenu, true);
				viewRegionesTelcel = new DataView(tblRegionesTelcel);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRegionesTelcel.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvSubMenu.DataSource = viewRegionesTelcel;
				this.gvSubMenu.DataBind();
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
			}

		}

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try{

            // Cancelar transacción
            ClearActionPanel();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlMenu.ClientID + "');", true);
         }
      }

   }
}