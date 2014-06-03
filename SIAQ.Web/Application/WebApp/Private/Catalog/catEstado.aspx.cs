/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catEstado
' Autor:	Daniel.Chavez
' Fecha:	29-Mayo-2014
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
	public partial class catEstado : System.Web.UI.Page
	{

        // Utilerías
        Function utilFunction = new Function();
        Encryption utilEncryption = new Encryption();

        // Enumeraciones
        private enum EstadoActionTypes { DeleteEstado, InsertEstado, ReactivateEstado, UpdateEstado }

        // Rutinas del programador
        private void ClearActionPanel()
        {
            try
            {

                // Limpiar formulario
                this.ddlActionPais.SelectedIndex = 0;
                this.txtActionNombre.Text = "";
                this.txtActionDescripcion.Text = "";
                this.ddlActionStatus.SelectedIndex = 0;

                // Estado incial de controles
                this.pnlAction.Visible = false;
                this.lblActionTitle.Text = "";
                this.btnAction.Text = "";
                this.lblActionMessage.Text = "";
                this.hddEstado.Value = "";

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void insertEstado()
        {
            BPEstado oBPEstado = new BPEstado();
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formilario
                oENTEstado.PaisId = Int32.Parse(this.ddlActionPais.SelectedItem.Value);
                oENTEstado.Nombre = this.txtActionNombre.Text.Trim();
                oENTEstado.Descripcion = this.txtActionDescripcion.Text.Trim();
                oENTEstado.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPEstado.insertcatEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar Grid
                selectEstado();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Estado creado con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }
        }

        private void selectEstado() {
            BPEstado oBPEstado = new BPEstado();
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            String sMessage = "tinyboxToolTipMessage_ClearOld();";

            try {

                // Formulario
                oENTEstado.Nombre = this.txtNombre.Text.Trim();
                oENTEstado.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPEstado.SelectEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") {  sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true)"; }

                // Llenado de controles
                this.gvEstado.DataSource = oENTResponse.dsResponse.Tables[1];
                this.gvEstado.DataBind();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

            }
            catch (Exception ex) { throw (ex); }

        }

        private void selectEstado_ForEdit(Int32 EstadoId) {
            BPEstado oBPEstado = new BPEstado();
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();
            
            try
            {

                // Formulario
                oENTEstado.EstadoId = EstadoId;
                oENTEstado.Nombre = this.txtActionNombre.Text.Trim();
                oENTEstado.Activo = Int16.Parse(this.ddlStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPEstado.SelectEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                this.lblActionMessage.Text = oENTResponse.sMessage;

                // Llenado de controles
                this.ddlActionPais.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["PaisId"].ToString();
                this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
                this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();
                this.ddlActionStatus.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["Activo"].ToString();


            }
            catch (Exception ex) { throw (ex); }

        }

        private void selectPais()
        {
            BPPais oBPPais = new BPPais();
            ENTPais oENTPais = new ENTPais();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTPais.Activo = 1;

                // Transacción
                oENTResponse = oBPPais.SelectPais(oENTPais);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Llenado de controles
                this.ddlActionPais.DataTextField = "Nombre";
                this.ddlActionPais.DataValueField = "PaisId";
                this.ddlActionPais.DataSource = oENTResponse.dsResponse.Tables[1];
                this.ddlActionPais.DataBind();

                // Item extra
                this.ddlActionPais.Items.Insert(0, new ListItem("[Seleccionar]","0"));

            }
            catch (Exception ex) { throw (ex); }

        }

        private void SetPanel(EstadoActionTypes EstadoActionTypes, Int32 PaisId = 0, Int32 EstadoId = 0)
        {
            try
            {

                // Acciones comunes
                this.pnlAction.Visible = true;
                this.hddEstado.Value = EstadoId.ToString();

                // Detalle de acción
                switch (EstadoActionTypes)
                {
                    case EstadoActionTypes.InsertEstado:
                        this.lblActionTitle.Text = "Nuevo Estado";
                        this.btnAction.Text = "Crear Estado";
                      
                        break;

                    case EstadoActionTypes.UpdateEstado:
                        this.lblActionTitle.Text = "Edición de Estado";
                        this.btnAction.Text = "Actualizar Estado";
                        selectEstado_ForEdit(EstadoId);

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

        private void updateEstado_Estatus(EstadoActionTypes EstadoActionTypes,Int32 EstadoId)
        {
            BPEstado oBPEstado = new BPEstado();
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            try { 
            
                // Formulario
                oENTEstado.EstadoId = EstadoId;

                switch (EstadoActionTypes) { 
                    case EstadoActionTypes.DeleteEstado:
                        oENTEstado.Activo = 0;
                        break;
                    case EstadoActionTypes.ReactivateEstado:
                        oENTEstado.Activo = 1;
                        break;
                }

                // Transacción
                oENTResponse = oBPEstado.updatecatEstado_Estatus(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Actualizar datos
                selectEstado();
                

            }
            catch (Exception ex) { throw (ex); }

        }

        private void ValidateActionForm()
        {
            try
            {
                // País
                if (this.ddlActionPais.SelectedIndex == 0) { throw new Exception("* El campo [País] es requerido"); }

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

        private void updateEstado(Int32 EstadoId) { 
            BPEstado oBPEstado = new BPEstado();
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            try { 
            
                // Formulario
                oENTEstado.PaisId = Int32.Parse(this.ddlActionPais.SelectedItem.Value);
                oENTEstado.EstadoId = EstadoId;
                oENTEstado.Nombre = this.txtActionNombre.Text.Trim();
                oENTEstado.Descripcion = this.txtActionDescripcion.Text.Trim();
                oENTEstado.Activo = Int16.Parse(this.ddlActionStatus.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPEstado.updatecatEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar grid
                selectEstado();

                // Mensaje de usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }

        }

        // Eventos de la página
		protected void Page_Load(object sender, EventArgs e)
		{
            // Validación. Solo la primera vez que se ejecuta la página
            if (this.Page.IsPostBack) { return; }

            // Lógica de la página
            try {

                // Llenado de controles
                selectPais();
                SelectStatus_Action();
                SelectStatus();
                selectEstado();

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

        protected void btnAction_Click(object sender, EventArgs e)
        {
            try {

                // Validar formulario
                ValidateActionForm();

                // Determinar acción
                if (this.hddEstado.Value == "0")
                {

                    insertEstado();
                }
                else {

                    updateEstado(Int32.Parse(hddEstado.Value));
                }
            }
            catch (Exception ex) {
                lblActionMessage.Text = ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtActionNombre.ClientID + "');", true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try {

                // Filtrar información
                selectEstado();
                
            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            try {

                // Nuevo registro
                SetPanel(EstadoActionTypes.InsertEstado);

            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvEstado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 EstadoId = 0;
            Int32 PaisId = 0;

            String strCommand = "";
            Int32 intRow = 0;

            try {

                // Opción seleccionada
                strCommand = e.CommandName.ToString();

                // Se dispara el evento RowCommand en el ordenamiento
                if (strCommand == "Sort") { return; }

                // Fila
                intRow = Int32.Parse(e.CommandArgument.ToString());

                // Datakeys
                EstadoId = Int32.Parse(this.gvEstado.DataKeys[intRow]["EstadoId"].ToString());
                PaisId = Int32.Parse(this.gvEstado.DataKeys[intRow]["PaisId"].ToString());

                // Reajuste de Command
                if (strCommand == "Action") { 
                
                    strCommand=(this.gvEstado.DataKeys[intRow]["Activo"].ToString()=="0" ? "Reactivar" : "Eliminar");
                }

                // Acción
                switch (strCommand) {
                    case "Editar":
                        SetPanel(EstadoActionTypes.UpdateEstado, PaisId, EstadoId);
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
                        break;
                    case "Eliminar":
                        updateEstado_Estatus(EstadoActionTypes.DeleteEstado, EstadoId);
                        break;
                    case "Reactivar":
                        updateEstado_Estatus(EstadoActionTypes.ReactivateEstado, EstadoId);
                        break;

                }

            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }


        }

        protected void gvEstado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            ImageButton imgAction = null;

            String EstadoId = "";
            String paisId = "";
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
                EstadoId = this.gvEstado.DataKeys[e.Row.RowIndex]["EstadoId"].ToString();
                paisId = this.gvEstado.DataKeys[e.Row.RowIndex]["PaisId"].ToString();
                sNombre = this.gvEstado.DataKeys[e.Row.RowIndex]["Nombre"].ToString();
                Activo = this.gvEstado.DataKeys[e.Row.RowIndex]["Activo"].ToString();

                // Tooltip Edición
                sTootlTip = "Editar Estado [" + sNombre + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "cursor:hand;");

                // Tooltip Action
                sTootlTip = (Activo == "1" ? "Eliminar" : "Reactivar" + "Estado [" + sNombre + "]");
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

        protected void gvEstado_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable tblRegionesTelcel = null;
            DataView viewRegionesTelcel = null;

            try
            {

                // Obtener DataTable y DataView del GridView
                tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvEstado, true);
                viewRegionesTelcel = new DataView(tblRegionesTelcel);

                // Determinar ordenamiento
                this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                // Ordenar vista
                viewRegionesTelcel.Sort = this.hddSort.Value;

                // Vaciar datos
                this.gvEstado.DataSource = viewRegionesTelcel;
                this.gvEstado.DataBind();

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


	}
}