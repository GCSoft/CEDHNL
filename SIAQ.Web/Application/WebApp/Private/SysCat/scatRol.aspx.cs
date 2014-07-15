/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	scatRol
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Catálogo de Sistema de Roles de la aplicación
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
   public partial class scatRol : BPPage
   {

      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      // Enumeraciones
      private enum RolActionTypes { DeleteRol, InsertRol, ReactivateRol, UpdateRol }

      
      // Rutinas del programador

      private void ClearActionPanel(){
         DataTable tblSubMenu = null;

         try
         {

            // Limpiar formulario
            this.txtActionNombre.Text = "";
            this.txtActionDescripcion.Text = "";
            this.ddlActionStatus.SelectedIndex = 0;
            this.ddlActionMenu.SelectedIndex = 0;

            // Limpiar grid
            if (this.ViewState["tblSubMenu"] != null){

               tblSubMenu = (DataTable)this.ViewState["tblSubMenu"];
               for (int i = 1; i < tblSubMenu.Rows.Count; i++){ tblSubMenu.Rows[i]["tiSelected"] = tblSubMenu.Rows[i]["tiRequired"]; }
               this.ViewState["tblSubMenu"] = tblSubMenu;
               this.ViewState["tblSubMenu_Filtered"] = tblSubMenu;
            }

            // Estado incial de controles
            this.pnlAction.Visible = false;
            this.lblActionTitle.Text = "";
            this.btnAction.Text = "";
            this.lblActionMessage.Text = "";
            this.hddRol.Value = "";

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void ExportRol(){
         String sKey = "";
			
			try{

            // Formulario (sNombre|tiActivo)
            sKey = this.txtNombre.Text + "|" + this.ddlStatus.SelectedItem.Value;
				
				// Encriptar la llave
				sKey = utilEncryption.EncryptString(sKey, true);
				
				// Llamada a rutina del lado del cliente
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "CallAsyncFame('ExcelMaker/xlsRol.aspx', '" + sKey + "');", true);
			
			}catch (Exception ex){
				throw (ex);
			}
      }

      private void InsertRol(){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();

         DataTable tblSelected;
         DataRow rowSelected;

			try{

            // Formulario
            oENTRol.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTRol.sNombre = this.txtActionNombre.Text.Trim();
            oENTRol.tiActivo = Int16.Parse(this.ddlActionStatus.SelectedValue);

            // Listado de SubMenús asociados
            tblSelected = (DataTable)this.ViewState["tblSubMenu"];
            oENTRol.tblSubMenu = new DataTable("tblSubMenu");
            oENTRol.tblSubMenu.Columns.Add("idSubMenu", typeof(Int32));

            foreach (DataRow rowCurrentSelected in tblSelected.Select("tiSelected = 1")){
               rowSelected = oENTRol.tblSubMenu.NewRow();
               rowSelected["idSubMenu"] = rowCurrentSelected["idSubMenu"];
               oENTRol.tblSubMenu.Rows.Add(rowSelected);
            }

            // Transacción
            oENTResponse = oBPRol.InsertRol(oENTRol);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectRol();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Rol creado con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

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
            oENTMenu.tiActivo = 1;

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
            this.ddlActionMenu.Items.Insert(0, new ListItem("[Todos]", "0"));

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectRol(){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();
         String sMessage = "tinyboxToolTipMessage_ClearOld();";

			try{

            // Formulario
            oENTRol.sNombre = this.txtNombre.Text;
            oENTRol.tiActivo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

				// Transacción
				oENTResponse = oBPRol.SelectRol(oENTRol);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

            // Llenado de controles
            this.gvRol.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvRol.DataBind();

            // Mensaje al usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SelectRol_ForEdit(Int32 idRol){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();

         DataTable tblSubMenu = null;

			try{

            // Formulario
            oENTRol.idRol = idRol;
            oENTRol.sNombre = "";
            oENTRol.tiActivo = 2;

            // Transacción
            oENTResponse = oBPRol.SelectRol(oENTRol);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            this.lblActionMessage.Text = oENTResponse.sMessage;

            // Llenado de formulario
            this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
            this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["sDescripcion"].ToString();
            this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["tiActivo"].ToString();
            this.ddlActionMenu.SelectedIndex = 0;

            // SubMenus asociados al Rol
            tblSubMenu = (DataTable)this.ViewState["tblSubMenu"];
            foreach (DataRow rowAssociated in oENTResponse.dsResponse.Tables[3].Rows ){

               if (tblSubMenu.Select("idSubMenu = " + rowAssociated["idSubMenu"]).Length == 1){
                  tblSubMenu.Select("idSubMenu = " + rowAssociated["idSubMenu"])[0]["tiSelected"] = "1";
               }
            }

            // Actualizar ViewState
            this.ViewState["tblSubMenu"] = tblSubMenu;
            this.ViewState["tblSubMenu_Filtered"] = this.ViewState["tblSubMenu"];

            // Llenado de controles
            this.gvActionSubMenu.DataSource = tblSubMenu;
            this.gvActionSubMenu.DataBind();

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

      private void SelectSubMenu_ForViewState(){
         ENTSubMenu oENTSubMenu = new ENTSubMenu();
			ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession;

			BPSubMenu oBPSubMenu = new BPSubMenu();

         DataTable tblSubMenu = null;
         DataRow rowSubMenu = null;

			try{

            // Información de Sesión
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Formulario
            oENTSubMenu.idRol = oENTSession.idRol;
            oENTSubMenu.idSubMenu = 0;
            oENTSubMenu.idMenu = 0;
            oENTSubMenu.sNombre = "";
            oENTSubMenu.tiActivo = 1;

				// Transacción
				oENTResponse = oBPSubMenu.SelectSubMenu(oENTSubMenu);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);", true); }

            // Definición del DataTable
            tblSubMenu = new DataTable("tblSubMenu");
            tblSubMenu.Columns.Add("idMenu", typeof(Int32));
            tblSubMenu.Columns.Add("idSubMenu", typeof(Int32));
            tblSubMenu.Columns.Add("sNombreMenu", typeof(String));
            tblSubMenu.Columns.Add("sNombreSubMenu", typeof(String));
            tblSubMenu.Columns.Add("tiSelected", typeof(Int32));
            tblSubMenu.Columns.Add("tiRequired", typeof(Int32));

            // Llenado de DataTable
            foreach(DataRow rowCurrentSubMenu in oENTResponse.dsResponse.Tables[1].Rows ){
               
               rowSubMenu = tblSubMenu.NewRow();
               rowSubMenu["idMenu"]          = rowCurrentSubMenu["idMenu"];
               rowSubMenu["idSubMenu"]       = rowCurrentSubMenu["idSubMenu"];
               rowSubMenu["sNombreMenu"]     = rowCurrentSubMenu["sNombreMenu"];
               rowSubMenu["sNombreSubMenu"]  = rowCurrentSubMenu["sNombreSubMenu"];
               rowSubMenu["tiSelected"]      = rowCurrentSubMenu["tiRequired"];
               rowSubMenu["tiRequired"]      = rowCurrentSubMenu["tiRequired"];
               tblSubMenu.Rows.Add(rowSubMenu);
            }

            // Almacenar en ViewState
            this.ViewState["tblSubMenu"] = tblSubMenu;
            this.ViewState["tblSubMenu_Filtered"] = this.ViewState["tblSubMenu"];

            // Llenado de controles
            this.gvActionSubMenu.DataSource = tblSubMenu;
            this.gvActionSubMenu.DataBind();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void SetPanel(RolActionTypes RolActionType, Int32 idItem = 0){
         try
         {

            // Acciones comunes
            this.pnlAction.Visible = true;
            this.hddRol.Value = idItem.ToString();

            // Detalle de acción
            switch (RolActionType){
               case RolActionTypes.InsertRol:
                  this.lblActionTitle.Text = "Nuevo Rol";
                  this.btnAction.Text = "Crear Rol";
                  
                  break;

               case RolActionTypes.UpdateRol:
                  this.lblActionTitle.Text = "Edición de Rol";
                  this.btnAction.Text = "Actualizar Rol";
                  SelectRol_ForEdit(idItem);
                  break;

               default:
                  throw (new Exception("Opción inválida"));
            }

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void UpdateRol(Int32 idRol){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();

         DataTable tblSelected;
         DataRow rowSelected;

			try{

            // Formulario
            oENTRol.idRol        = idRol;
            oENTRol.sDescripcion = this.txtActionDescripcion.Text.Trim();
            oENTRol.sNombre      = this.txtActionNombre.Text.Trim();
            oENTRol.tiActivo     = Int16.Parse(this.ddlActionStatus.SelectedValue);

            // Listado de SubMenús asociados
            tblSelected = (DataTable)this.ViewState["tblSubMenu"];
            oENTRol.tblSubMenu = new DataTable("tblSubMenu");
            oENTRol.tblSubMenu.Columns.Add("idSubMenu", typeof(Int32));

            foreach (DataRow rowCurrentSelected in tblSelected.Select("tiSelected = 1")){
               rowSelected = oENTRol.tblSubMenu.NewRow();
               rowSelected["idSubMenu"] = rowCurrentSelected["idSubMenu"];
               oENTRol.tblSubMenu.Rows.Add(rowSelected);
            }

            // Transacción
            oENTResponse = oBPRol.UpdateRol(oENTRol);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            // Transacción exitosa
            ClearActionPanel();

            // Actualizar grid
            SelectRol();

            // Mensaje de usuario
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Rol actualizado con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void UpdateRol_Estatus(Int32 idRol, RolActionTypes RolActionType){
         ENTRol oENTRol = new ENTRol();
			ENTResponse oENTResponse = new ENTResponse();

			BPRol oBPRol = new BPRol();

			try{

            // Formulario
            oENTRol.idRol = idRol;
            switch (RolActionType){
               case RolActionTypes.DeleteRol:
                  oENTRol.tiActivo = 0;
                  break;
               case RolActionTypes.ReactivateRol:
                  oENTRol.tiActivo = 1;
                  break;
               default:
                  throw new Exception("Opción inválida");
            }

				// Transacción
            oENTResponse = oBPRol.UpdateRol_Estatus(oENTRol);

				// Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != ""){throw (new Exception(oENTResponse.sMessage));}

				// Actualizar datos
            SelectRol();

			}catch (Exception ex){
            throw (ex);
			}
      }

      private void ValidateActionForm(){
         try
         {

            // Nombre
            if (this.txtActionNombre.Text.Trim() == "") { throw new Exception("* El campo [Nombre] es requerido"); }

            // Estatus
            if (this.ddlActionStatus.SelectedIndex == 0) { throw new Exception("* El campo [Estatus] es requerido"); }

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
            SelectStatus_Action();
            SelectRol();
            SelectMenu_Action();
            SelectSubMenu_ForViewState();

            // Estado inicial del formulario
            ClearActionPanel();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
         }
      }

      protected void btnAction_Click(object sender, EventArgs e){
         try{

            // Validar formulario
            ValidateActionForm();

            // Determinar acción
            if (this.hddRol.Value == "0"){

               InsertRol();
            }else{

               UpdateRol(Int32.Parse(this.hddRol.Value));
            }

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectRol();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
         }
      }

      protected void btnExportar_Click(object sender, EventArgs e){
         try{

            // Exportar información
            ExportRol();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
         }
      }

      protected void btnNuevo_Click(object sender, EventArgs e){
         try{

            // Nuevo registro
            SetPanel(RolActionTypes.InsertRol);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
         }
      }

      protected void chkActionIncluir_Changed(object sender, EventArgs e){
         GridViewRow oGridViewRow = null;
         CheckBox oCheckBox = null;
         String idSubMenu = "";

         DataTable tblSubMenu = (DataTable)this.ViewState["tblSubMenu"];
         DataTable tblSubMenu_Filtered = (DataTable)this.ViewState["tblSubMenu_Filtered"];
			
			try
			{

            // Controles
            oCheckBox = (CheckBox)sender;
            oGridViewRow = (GridViewRow)oCheckBox.NamingContainer;

            // Datakeys
            idSubMenu = this.gvActionSubMenu.DataKeys[oGridViewRow.RowIndex]["idSubMenu"].ToString();

            // Actualizar DataTables
            tblSubMenu.Select("idSubMenu=" + idSubMenu)[0]["tiSelected"] = (oCheckBox.Checked ? 1 : 0);
            tblSubMenu_Filtered.Select("idSubMenu=" + idSubMenu)[0]["tiSelected"] = (oCheckBox.Checked ? 1 : 0);

            // Actualizar ViewState
            this.ViewState["tblSubMenu"] = tblSubMenu;
            this.ViewState["tblSubMenu_Filtered"] = tblSubMenu_Filtered;

            // Actualizar grid
            this.gvActionSubMenu.DataSource = tblSubMenu_Filtered;
            this.gvActionSubMenu.DataBind();

            // Foco al checkbox pulsado
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + oCheckBox.ClientID + "');", true);

			}catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
			}
      }

      protected void ddlActionMenu_SelectedIndexChanged(object sender, EventArgs e){
         DataTable tblSubMenu = (DataTable)this.ViewState["tblSubMenu"];
         DataTable tblSubMenu_Filtered = (DataTable)this.ViewState["tblSubMenu_Filtered"];

         DataRow rowSubMenu_Filtered = null;
         
         try{

            // Depurar DataTable de filtrado
            tblSubMenu_Filtered.Rows.Clear();

            // Filtrar
            if(this.ddlActionMenu.SelectedIndex == 0){

               tblSubMenu_Filtered = tblSubMenu;

            }else{

               foreach(DataRow rowCurrentSubMenu in tblSubMenu.Select("idMenu=" + this.ddlActionMenu.SelectedValue ) ){
                  rowSubMenu_Filtered = tblSubMenu_Filtered.NewRow();
                  rowSubMenu_Filtered["idMenu"]          = rowCurrentSubMenu["idMenu"];
                  rowSubMenu_Filtered["idSubMenu"]       = rowCurrentSubMenu["idSubMenu"];
                  rowSubMenu_Filtered["sNombreMenu"]     = rowCurrentSubMenu["sNombreMenu"];
                  rowSubMenu_Filtered["sNombreSubMenu"]  = rowCurrentSubMenu["sNombreSubMenu"];
                  rowSubMenu_Filtered["tiSelected"]      = rowCurrentSubMenu["tiSelected"];
                  rowSubMenu_Filtered["tiRequired"]      = rowCurrentSubMenu["tiRequired"];
                  tblSubMenu_Filtered.Rows.Add(rowSubMenu_Filtered);
               }

            }

            // Actualizar ViewState
            this.ViewState["tblSubMenu_Filtered"] = tblSubMenu_Filtered;

            // Actualizar grid
            this.gvActionSubMenu.DataSource = tblSubMenu_Filtered;
            this.gvActionSubMenu.DataBind();

         }catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
         }
      }

      protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e){
         try{

            // Filtrar información
            SelectRol();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
         }
      }

      protected void gvActionSubMenu_RowDataBound(object sender, GridViewRowEventArgs e){
			CheckBox oCheckBox = null;
         String idSubMenu = "";
         String tiSelected = "";
         String tiRequired = "";

			// Validación de que sea fila
			if (e.Row.RowType != DataControlRowType.DataRow) { return; }

         // Datakeys
         idSubMenu = this.gvActionSubMenu.DataKeys[e.Row.RowIndex]["idSubMenu"].ToString();
         tiSelected = this.gvActionSubMenu.DataKeys[e.Row.RowIndex]["tiSelected"].ToString();
         tiRequired = this.gvActionSubMenu.DataKeys[e.Row.RowIndex]["tiRequired"].ToString();

         // CheckBox
         oCheckBox = (CheckBox)e.Row.FindControl("chkActionIncluir");

         // Estado de CheckBox y Opciones requeridas
         if(tiSelected == "1"){ oCheckBox.Checked = true; }
         if(tiRequired == "1") { oCheckBox.Checked = true; oCheckBox.Enabled = false; }

         // Seguridad
         if (idSubMenu == "1" || idSubMenu == "2"){ oCheckBox.Checked = false; oCheckBox.Enabled = false; }

         // Sombra en fila Over
         e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action';");

         /// Sombra en fila Out
         e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action';");

		}
      
		protected void gvActionSubMenu_Sorting(object sender, GridViewSortEventArgs e){
         DataTable tblSubMenu_Filtered = (DataTable)this.ViewState["tblSubMenu_Filtered"];
			DataView viewSubMenu_Filtered = new DataView(tblSubMenu_Filtered);
			
			try
			{

				// Determinar ordenamiento
            this.hddSortAction.Value = (this.hddSortAction.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
            viewSubMenu_Filtered.Sort = this.hddSortAction.Value;

				// Vaciar datos
				this.gvActionSubMenu.DataSource = viewSubMenu_Filtered;
				this.gvActionSubMenu.DataBind();

			}catch (Exception ex){
            this.lblActionMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
			}
		}

      protected void gvRol_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
         ImageButton imgAction = null;

         String idRol = "";
         String sNombreRol = "";
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
            idRol = this.gvRol.DataKeys[e.Row.RowIndex]["idRol"].ToString();
            tiActivo = this.gvRol.DataKeys[e.Row.RowIndex]["tiActivo"].ToString();
            sNombreRol = this.gvRol.DataKeys[e.Row.RowIndex]["sNombre"].ToString();

            // Seguridad
            if(idRol == "1"){

               imgEdit.Visible = false;
               imgAction.Visible = false;
            }else{

               // Tooltip Edición
               sTootlTip = "Editar Rol [" + sNombreRol + "]";
               imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
               imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
               imgEdit.Attributes.Add("style", "cursor:hand;");

               // Tooltip Action
               sTootlTip = (tiActivo == "1" ? "Eliminar" : "Reactivar") + " Rol [" + sNombreRol + "]";
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
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvRol_RowCommand(object sender, GridViewCommandEventArgs e){
         Int32 idRol = 0;

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
				idRol = Int32.Parse(this.gvRol.DataKeys[intRow]["idRol"].ToString());

            // Reajuste de Command
            if (strCommand == "Action"){
               strCommand = (this.gvRol.DataKeys[intRow]["tiActivo"].ToString() == "0" ? "Reactivar" : "Eliminar");
            }

				// Acción
				switch (strCommand){
					case "Editar":
                  SetPanel(RolActionTypes.UpdateRol, idRol);
                  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;
               case "Eliminar":
                  UpdateRol_Estatus(idRol, RolActionTypes.DeleteRol);
                  break;
               case "Reactivar":
                  UpdateRol_Estatus(idRol, RolActionTypes.ReactivateRol);
                  break;
				}
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvRol_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblRol = null;
			DataView viewRol = null;
			
			try{

				// Obtener DataTable y DataView del GridView
				tblRol = utilFunction.ParseGridViewToDataTable(this.gvRol, true);
				viewRol = new DataView(tblRol);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewRol.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvRol.DataSource = viewRol;
				this.gvRol.DataBind();
				
			}catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" +  this.txtNombre.ClientID + "');", true);
			}

		}

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try{

            // Cancelar transacción
            ClearActionPanel();

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

   }
}