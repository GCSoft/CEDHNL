/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catLugarHechos
' Autor:	Daniel.Chavez
' Fecha:	31-Mayo-2014
'
' Descripción:
'           Catálogo de LugarDiligencia de la aplicación
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
	public partial class catLugarHechos : System.Web.UI.Page
	{

        // Utilerías
        Function utilFunction = new Function();
        Encryption utilEncryption = new Encryption();

        // Enumeraciones
        private enum LugarHechosActionTypes { DeleteLugarHechos, InsertLugarHechos, ReactivateLugarHechos, UpdateLugarHechos }

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
                this.hddLugarHechos.Value = "";

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void insertLugarHechos()
        {
            BPLugarHechos oBPLugarHechos = new BPLugarHechos();
            ENTLugarHechos oENTLugarHechos = new ENTLugarHechos();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formilario
                oENTLugarHechos.Nombre = this.txtActionNombre.Text.Trim();
                oENTLugarHechos.Descripcion = this.txtActionDescripcion.Text.Trim();


                // Transacción
                oENTResponse = oBPLugarHechos.insertLugarHechos(oENTLugarHechos);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar Grid
                selectcatLugarHechos();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Lugar creado con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }
        }

        private void selectcatLugarHechos()
        {
            BPLugarHechos oBPLugarHechos = new BPLugarHechos();
            ENTLugarHechos oENTLugarHechos = new ENTLugarHechos();
            ENTResponse oENTResponse = new ENTResponse();

            String sMessage = "tinyboxToolTipMessage_ClearOld();";

            try
            {

                // Formulario
                oENTLugarHechos.Nombre = this.txtNombre.Text.Trim();


                // Transacción
                oENTResponse = oBPLugarHechos.SelectcatLugarHechos(oENTLugarHechos);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true)"; }

                // Llenado de controles
                this.gvLugarHechos.DataSource = oENTResponse.dsResponse.Tables[1];
                this.gvLugarHechos.DataBind();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

            }
            catch (Exception ex) { throw (ex); }

        }

        private void selectcatLugarHechos_ForEdit(Int32 LugarHechosId)
        {
            BPLugarHechos oBPLugarHechos = new BPLugarHechos();
            ENTLugarHechos oENTLugarHechos = new ENTLugarHechos();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTLugarHechos.LugarHechosId = LugarHechosId;
                oENTLugarHechos.Nombre = this.txtActionNombre.Text.Trim();


                // Transacción
                oENTResponse = oBPLugarHechos.SelectcatLugarHechos(oENTLugarHechos);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                this.lblActionMessage.Text = oENTResponse.sMessage;

                // Llenado de controles
                this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
                this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();



            }
            catch (Exception ex) { throw (ex); }

        }

        private void SetPanel(LugarHechosActionTypes LugarHechosActionTypes, Int32 LugarHechosId = 0)
        {
            try
            {

                // Acciones comunes
                this.pnlAction.Visible = true;
                this.hddLugarHechos.Value = LugarHechosId.ToString();

                // Detalle de acción
                switch (LugarHechosActionTypes)
                {
                    case LugarHechosActionTypes.InsertLugarHechos:
                        this.lblActionTitle.Text = "Nuevo Lugar de los Hechos";
                        this.btnAction.Text = "Crear Lugar";

                        break;

                    case LugarHechosActionTypes.UpdateLugarHechos:
                        this.lblActionTitle.Text = "Edición de Lugar los Hechos";
                        this.btnAction.Text = "Actualizar Lugar";
                        selectcatLugarHechos_ForEdit(LugarHechosId);

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
                if (this.txtActionNombre.Text.Trim() == "") { throw new Exception("* El campo [Nombre] es requerido"); }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void updateLugarHechos(Int32 LugarHechosId)
        {
            BPLugarHechos oBPLugarHechos = new BPLugarHechos();
            ENTLugarHechos oENTLugarHechos = new ENTLugarHechos();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTLugarHechos.LugarHechosId = LugarHechosId;
                oENTLugarHechos.Nombre = this.txtActionNombre.Text.Trim();
                oENTLugarHechos.Descripcion = this.txtActionDescripcion.Text.Trim();


                // Transacción
                oENTResponse = oBPLugarHechos.updateLugarHechos(oENTLugarHechos);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar grid
                selectcatLugarHechos();

                // Mensaje de usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Información actualizada con éxito!', 'Success', false); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }

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
                selectcatLugarHechos();

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
            try
            {

                // Validar formulario
                ValidateActionForm();

                // Determinar acción
                if (this.hddLugarHechos.Value == "0")
                {

                    insertLugarHechos();
                }
                else
                {

                    updateLugarHechos(Int32.Parse(this.hddLugarHechos.Value));
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
                selectcatLugarHechos();

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
                SetPanel(LugarHechosActionTypes.InsertLugarHechos);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvLugarHechos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 LugarHechosId = 0;

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
                LugarHechosId = Int32.Parse(this.gvLugarHechos.DataKeys[intRow]["LugarHechosId"].ToString());

                // Reajuste de Command
                //if (strCommand == "Action")
                //{

                //    strCommand = (this.gvLugar.DataKeys[intRow]["Activo"].ToString() == "0" ? "Reactivar" : "Eliminar");
                //}

                // Acción
                switch (strCommand)
                {
                    case "Editar":
                        SetPanel(LugarHechosActionTypes.UpdateLugarHechos, LugarHechosId);
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
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }

        }

        protected void gvLugarHechos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            //ImageButton imgAction = null;

            String LugarHechosId = "";
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
                LugarHechosId = this.gvLugarHechos.DataKeys[e.Row.RowIndex]["LugarHechosId"].ToString();
                sNombre = this.gvLugarHechos.DataKeys[e.Row.RowIndex]["Nombre"].ToString();


                // Tooltip Edición
                sTootlTip = "Editar Lugar [" + sNombre + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "cursor:hand;");

                // Tooltip Action
                //sTootlTip = (Activo == "1" ? "Eliminar" : "Reactivar" + "Lugar [" + sNombre + "]");
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

        protected void gvLugarHechos_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable tblRegionesTelcel = null;
            DataView viewRegionesTelcel = null;

            try
            {

                // Obtener DataTable y DataView del GridView
                tblRegionesTelcel = utilFunction.ParseGridViewToDataTable(this.gvLugarHechos, true);
                viewRegionesTelcel = new DataView(tblRegionesTelcel);

                // Determinar ordenamiento
                this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                // Ordenar vista
                viewRegionesTelcel.Sort = this.hddSort.Value;

                // Vaciar datos
                this.gvLugarHechos.DataSource = viewRegionesTelcel;
                this.gvLugarHechos.DataBind();

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