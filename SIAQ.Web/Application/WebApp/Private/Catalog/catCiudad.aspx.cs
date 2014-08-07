/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catCiudad
' Autor:	Daniel.Chavez
' Fecha:	31-Mayo-2014
'
' Descripción:
'           Catálogo de Ciudades de la aplicación
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
	public partial class catCiudad : BPPage
	{

        // Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

        // Enumeraciones
        private enum CiudadActionTypes { DeleteCiudad, InsertCiudad, ReactivateCiudad, UpdateCiudad }

        
		// Rutinas del programador
        
		private void ClearActionPanel()
        {
            try
            {

                // Limpiar formulario
                this.ddlActionEstado.SelectedIndex = 0;
                this.txtActionNombre.Text = "";
                this.txtActionDescripcion.Text = "";
                this.ddlActionStatus.SelectedIndex = 0;

                // Estado incial de controles
                this.pnlAction.Visible = false;
                this.lblActionTitle.Text = "";
                this.btnAction.Text = "";
                this.lblActionMessage.Text = "";
                this.hddCiudad.Value = "";

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void insertCiudad()
        {
            BPCiudad oBPCiudad = new BPCiudad();
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formilario
                oENTCiudad.EstadoId = Int32.Parse(this.ddlActionEstado.SelectedItem.Value);
                oENTCiudad.Nombre = this.txtActionNombre.Text.Trim();
                oENTCiudad.Descripcion = this.txtActionDescripcion.Text.Trim();
                oENTCiudad.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPCiudad.insertcatCiudad(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar Grid
                selectCiudad();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Estado creado con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }
        }

        private void selectCiudad()
        {
            BPCiudad oBPCiudad = new BPCiudad();
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            String sMessage = "tinyboxToolTipMessage_ClearOld();";

            try
            {

                // Formulario
                oENTCiudad.Nombre = this.txtNombre.Text.Trim();
                oENTCiudad.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sMessage) + "', 'Warning', true)"; }

                // Llenado de controles
                this.gvCiudad.DataSource = oENTResponse.dsResponse.Tables[1];
                this.gvCiudad.DataBind();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

            }
            catch (Exception ex) { throw (ex); }

        }

        private void selectCiudad_ForEdit(Int32 CiudadId)
        {
            BPCiudad oBPCiudad = new BPCiudad();
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTCiudad.CiudadId = CiudadId;
                oENTCiudad.Nombre = this.txtActionNombre.Text.Trim();
                oENTCiudad.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                this.lblActionMessage.Text = oENTResponse.sMessage;

                // Llenado de controles
                this.ddlActionEstado.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoId"].ToString();
                this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
                this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();
                this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["Activo"].ToString();


            }
            catch (Exception ex) { throw (ex); }

        }

        private void selectEstado()
        {
            BPEstado oBPEstado = new BPEstado();
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTEstado.Activo = 1;

                // Transacción
                oENTResponse = oBPEstado.SelectEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Llenado de controles
                this.ddlActionEstado.DataTextField = "Nombre";
                this.ddlActionEstado.DataValueField = "EstadoId";
                this.ddlActionEstado.DataSource = oENTResponse.dsResponse.Tables[1];
                this.ddlActionEstado.DataBind();

                // Item extra
                this.ddlActionEstado.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

            }
            catch (Exception ex) { throw (ex); }

        }

        private void SetPanel(CiudadActionTypes CiudadActionTypes, Int32 CiudadId = 0, Int32 EstadoId = 0)
        {
            try
            {

                // Acciones comunes
                this.pnlAction.Visible = true;
                this.hddCiudad.Value = CiudadId.ToString();

                // Detalle de acción
                switch (CiudadActionTypes)
                {
                    case CiudadActionTypes.InsertCiudad:
                        this.lblActionTitle.Text = "Nueva Ciudad";
                        this.btnAction.Text = "Crear Ciudad";

                        break;

                    case CiudadActionTypes.UpdateCiudad:
                        this.lblActionTitle.Text = "Edición de Ciudad";
                        this.btnAction.Text = "Actualizar Ciudad";
                        selectCiudad_ForEdit(CiudadId);

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

        private void updateCiudad_Estatus(CiudadActionTypes CiudadActionTypes, Int32 CiudadId)
        {
            BPCiudad oBPCiudad = new BPCiudad();
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTCiudad.CiudadId = CiudadId;

                switch (CiudadActionTypes)
                {
                    case CiudadActionTypes.DeleteCiudad:
                        oENTCiudad.Activo = 0;
                        break;
                    case CiudadActionTypes.ReactivateCiudad:
                        oENTCiudad.Activo = 1;
                        break;
                }

                // Transacción
                oENTResponse = oBPCiudad.updatecatCiudad_Estatus(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Actualizar datos
                selectCiudad();


            }
            catch (Exception ex) { throw (ex); }

        }

        private void updateCiudad(Int32 CiudadId)
        {
            BPCiudad oBPCiudad = new BPCiudad();
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTCiudad.EstadoId = Int32.Parse(this.ddlActionEstado.SelectedItem.Value);
                oENTCiudad.CiudadId = CiudadId;
                oENTCiudad.Nombre = this.txtActionNombre.Text.Trim();
                oENTCiudad.Descripcion = this.txtActionDescripcion.Text.Trim();
                oENTCiudad.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPCiudad.updatecatCiudad(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar grid
                selectCiudad();

                // Mensaje de usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }

        }

        private void ValidateActionForm()
        {
            try
            {
                // País
                if (this.ddlActionEstado.SelectedIndex == 0) { throw new Exception("* El campo [Estado] es requerido"); }

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
            try
            {

                // Llenado de controles
                
                SelectStatus_Action();
                SelectStatus();
                selectEstado();
                selectCiudad();

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
                if (this.hddCiudad.Value == "0")
                {

                    insertCiudad();
                }
                else
                {

                    updateCiudad(Int32.Parse(hddCiudad.Value));
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
                selectCiudad();

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
                SetPanel(CiudadActionTypes.InsertCiudad);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvCiudad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 EstadoId = 0;
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
                EstadoId = Int32.Parse(this.gvCiudad.DataKeys[intRow]["EstadoId"].ToString());
                CiudadId = Int32.Parse(this.gvCiudad.DataKeys[intRow]["CiudadId"].ToString());

                // Reajuste de Command
                if (strCommand == "Action")
                {

                    strCommand = (this.gvCiudad.DataKeys[intRow]["Activo"].ToString() == "0" ? "Reactivar" : "Eliminar");
                }

                // Acción
                switch (strCommand)
                {
                    case "Editar":
                        SetPanel(CiudadActionTypes.UpdateCiudad, CiudadId, EstadoId);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
                        break;
                    case "Eliminar":
                        updateCiudad_Estatus(CiudadActionTypes.DeleteCiudad, CiudadId);
                        break;
                    case "Reactivar":
                        updateCiudad_Estatus(CiudadActionTypes.ReactivateCiudad, CiudadId);
                        break;

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }

        }

        protected void gvCiudad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            ImageButton imgAction = null;

            String EstadoId = "";
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
                EstadoId = this.gvCiudad.DataKeys[e.Row.RowIndex]["EstadoId"].ToString();
                CiudadId = this.gvCiudad.DataKeys[e.Row.RowIndex]["CiudadId"].ToString();
                sNombre = this.gvCiudad.DataKeys[e.Row.RowIndex]["Nombre"].ToString();
                Activo = this.gvCiudad.DataKeys[e.Row.RowIndex]["Activo"].ToString();

                // Tooltip Edición
                sTootlTip = "Editar Ciudad [" + sNombre + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "cursor:hand;");

                // Tooltip Action
                sTootlTip = (Activo == "1" ? "Eliminar" : "Reactivar" + "Ciudad [" + sNombre + "]");
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

        protected void gvCiudad_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvCiudad, ref this.hddSort, e.SortExpression);

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