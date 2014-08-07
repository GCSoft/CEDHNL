/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catColonia
' Autor:	Daniel.Chavez
' Fecha:	09-Junio-2014
'
' Descripción:
'           Catálogo de Colonias de la aplicación
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
   public partial class catColonia : BPPage
   {

       // Utilerías
	   GCCommon gcCommon = new GCCommon();
	   GCJavascript gcJavascript = new GCJavascript();

       // Enumeraciones
       private enum ColoniaActionTypes { DeleteColonia, InsertColonia, ReactivateColonia, UpdateColonia }

       
	   // Rutinas del programador
       
	   private void ClearActionPanel()
       {
           try
           {

               // Limpiar formulario
               this.ddlActionCiudad.SelectedIndex = 0;
               this.txtActionNombre.Text = "";
               this.txtActionDescripcion.Text = "";
               this.ddlActionStatus.SelectedIndex = 0;

               // Estado incial de controles
               this.pnlAction.Visible = false;
               this.lblActionTitle.Text = "";
               this.btnAction.Text = "";
               this.lblActionMessage.Text = "";
               this.hddColonia.Value = "";

           }
           catch (Exception ex)
           {
               throw (ex);
           }
       }

       private void insertColonia()
       {
           BPColonia oBPColonia = new BPColonia();
           ENTColonia oENTColonia = new ENTColonia();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Formilario
               oENTColonia.CiudadId = Int32.Parse(this.ddlActionCiudad.SelectedItem.Value);
               oENTColonia.Nombre = this.txtActionNombre.Text.Trim();
               oENTColonia.Descripcion = this.txtActionDescripcion.Text.Trim();
               oENTColonia.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

               // Transacción
               oENTResponse = oBPColonia.insertcatColonia(oENTColonia);

               // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
               if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

               // Transacción exitosa
               ClearActionPanel();

               // Actualizar Grid
               selectColonia();

               // Mensaje al usuario
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Colonia creado con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

           }
           catch (Exception ex) { throw (ex); }
       }

       private void selectColonia()
       {
           BPColonia oBPColonia = new BPColonia();
           ENTColonia oENTColonia = new ENTColonia();
           ENTResponse oENTResponse = new ENTResponse();

           String sMessage = "tinyboxToolTipMessage_ClearOld();";

           try
           {

               // Formulario
               oENTColonia.Nombre = this.txtNombre.Text.Trim();
               oENTColonia.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

               // Transacción
               oENTResponse = oBPColonia.SelectColonia(oENTColonia);

               // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
               if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sMessage) + "', 'Warning', true)"; }

               // Llenado de controles
               this.gvColonia.DataSource = oENTResponse.dsResponse.Tables[1];
               this.gvColonia.DataBind();

               // Mensaje al usuario
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

           }
           catch (Exception ex) { throw (ex); }

       }

       private void selectColonia_ForEdit(Int32 ColoniaId)
       {
           BPColonia oBPColonia = new BPColonia();
           ENTColonia oENTColonia = new ENTColonia();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Formulario
               oENTColonia.ColoniaId = ColoniaId;
               oENTColonia.Nombre = this.txtActionNombre.Text.Trim();
               oENTColonia.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

               // Transacción
               oENTResponse = oBPColonia.SelectColonia(oENTColonia);

               // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
               this.lblActionMessage.Text = oENTResponse.sMessage;

               // Llenado de controles
               this.ddlActionCiudad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadId"].ToString();
               this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
               this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();
               this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["Activo"].ToString();


           }
           catch (Exception ex) { throw (ex); }

       }

       private void selectCiudad()
       {
           BPCiudad oBPCiudad = new BPCiudad();
           ENTCiudad oENTCiudad = new ENTCiudad();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Formulario
               oENTCiudad.Nombre = this.txtNombre.Text.Trim();
               oENTCiudad.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

               // Transacción
               oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

               // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
               if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

               // Llenado de controles
               this.ddlActionCiudad.DataTextField = "Nombre";
               this.ddlActionCiudad.DataValueField = "CiudadId";
               this.ddlActionCiudad.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlActionCiudad.DataBind();

               // Item extra
               this.ddlActionCiudad.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

           }
           catch (Exception ex) { throw (ex); }

       }

       private void SetPanel(ColoniaActionTypes ColoniaActionTypes, Int32 CiudadId = 0, Int32 ColoniaId = 0)
       {
           try
           {

               // Acciones comunes
               this.pnlAction.Visible = true;
               this.hddColonia.Value = ColoniaId.ToString();

               // Detalle de acción
               switch (ColoniaActionTypes)
               {
                   case ColoniaActionTypes.InsertColonia:
                       this.lblActionTitle.Text = "Nueva Colonia";
                       this.btnAction.Text = "Crear Colonia";

                       break;

                   case ColoniaActionTypes.UpdateColonia:
                       this.lblActionTitle.Text = "Edición de Colonia";
                       this.btnAction.Text = "Actualizar Colonia";
                       selectColonia_ForEdit(ColoniaId);

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

       private void updateColonia_Estatus(ColoniaActionTypes ColoniaActionTypes, Int32 ColoniaId)
       {
           BPColonia oBPColonia = new BPColonia();
           ENTColonia oENTColonia = new ENTColonia();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Formulario
               oENTColonia.ColoniaId = ColoniaId;

               switch (ColoniaActionTypes)
               {
                   case ColoniaActionTypes.DeleteColonia:
                       oENTColonia.Activo = 0;
                       break;
                   case ColoniaActionTypes.ReactivateColonia:
                       oENTColonia.Activo = 1;
                       break;
               }

               // Transacción
               oENTResponse = oBPColonia.updatecatColonia_Estatus(oENTColonia);

               // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
               if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

               // Actualizar datos
               selectColonia();


           }
           catch (Exception ex) { throw (ex); }

       }

       private void updateColonia(Int32 ColoniaId)
       {
           BPColonia oBPColonia = new BPColonia();
           ENTColonia oENTColonia = new ENTColonia();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Formulario
               oENTColonia.CiudadId = Int32.Parse(this.ddlActionCiudad.SelectedItem.Value);
               oENTColonia.ColoniaId = ColoniaId;
               oENTColonia.Nombre = this.txtActionNombre.Text.Trim();
               oENTColonia.Descripcion = this.txtActionDescripcion.Text.Trim();
               oENTColonia.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

               // Transacción
               oENTResponse = oBPColonia.updatecatColonia(oENTColonia);

               // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
               if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

               // Transacción exitosa
               ClearActionPanel();

               // Actualizar grid
               selectColonia();

               // Mensaje de usuario
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

           }
           catch (Exception ex) { throw (ex); }

       }

       private void ValidateActionForm()
       {
           try
           {
               // Ciudad
               if (this.ddlActionCiudad.SelectedIndex == 0) { throw new Exception("* El campo [Ciudad] es requerido"); }

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
          if (this.Page.IsPostBack) { return; }

          // Lógica de la página
          try {
              // Llenado de controles
              SelectStatus_Action();
              SelectStatus();
              selectCiudad();
              selectColonia();

              // Estado inicial del formulario
              ClearActionPanel();

              // Foco
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);


          }
          catch (Exception ex) {
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
              if (this.hddColonia.Value == "0")
              {

                  insertColonia();
              }
              else
              {

                  updateColonia(Int32.Parse(hddColonia.Value));
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
              selectColonia();

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
              SetPanel(ColoniaActionTypes.InsertColonia);

          }
          catch (Exception ex)
          {
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
          }
      }

      protected void gvColonia_RowCommand(object sender, GridViewCommandEventArgs e)
      {
          Int32 ColoniaId = 0;
          Int32 CiudadId = 0;

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
              ColoniaId = Int32.Parse(this.gvColonia.DataKeys[intRow]["ColoniaId"].ToString());
              CiudadId = Int32.Parse(this.gvColonia.DataKeys[intRow]["CiudadId"].ToString());

              // Reajuste de Command
              if (strCommand == "Action")
              {

                  strCommand = (this.gvColonia.DataKeys[intRow]["Activo"].ToString() == "0" ? "Reactivar" : "Eliminar");
              }

              // Acción
              switch (strCommand)
              {
                  case "Editar":
                      SetPanel(ColoniaActionTypes.UpdateColonia,CiudadId, ColoniaId);
                      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
                      break;
                  case "Eliminar":
                      updateColonia_Estatus(ColoniaActionTypes.DeleteColonia, ColoniaId);
                      break;
                  case "Reactivar":
                      updateColonia_Estatus(ColoniaActionTypes.ReactivateColonia, ColoniaId);
                      break;

              }

          }
          catch (Exception ex)
          {
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
          }
      }

      protected void gvColonia_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          ImageButton imgEdit = null;
          ImageButton imgAction = null;

          String ColoniaId = "";
          String CiudadId = "";
          String sNombre = "";
          String Activo = "";

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
              ColoniaId = this.gvColonia.DataKeys[e.Row.RowIndex]["ColoniaId"].ToString();
              CiudadId = this.gvColonia.DataKeys[e.Row.RowIndex]["CiudadId"].ToString();
              sNombre = this.gvColonia.DataKeys[e.Row.RowIndex]["Nombre"].ToString();
              Activo = this.gvColonia.DataKeys[e.Row.RowIndex]["Activo"].ToString();

              // Tooltip Edición
              sTootlTip = "Editar Colonia [" + sNombre + "]";
              imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
              imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
              imgEdit.Attributes.Add("style", "cursor:hand;");

              // Tooltip Action
              sTootlTip = (Activo == "1" ? "Eliminar" : "Reactivar" + "Colonia [" + sNombre + "]");
              imgAction.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
              imgAction.Attributes.Add("onmouseout", "tooltip.hide();");
              imgAction.Attributes.Add("style", "cursor:hand;");

              // Imagen del botón [imgAction]
              imgAction.ImageUrl = "../../../../Include/Image/Buttons/" + (Activo == "1" ? "Delete" : "Restore") + ".png";

              // Atributos Over
              sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
              sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (Activo == "1" ? "Delete" : "Restore") + "_Over.png';";

              // Puntero y Sombra en fila Over
              e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

              // Atributos Out
              sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
              sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgAction.ClientID + "').src='../../../../Include/Image/Buttons/" + (Activo == "1" ? "Delete" : "Restore") + ".png';";

              // Puntero y Sombra en fila Out
              e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

          }
          catch (Exception ex) { throw (ex); }

      }

      protected void gvColonia_Sorting(object sender, GridViewSortEventArgs e){
          try
            {

				gcCommon.SortGridView(ref this.gvColonia, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
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