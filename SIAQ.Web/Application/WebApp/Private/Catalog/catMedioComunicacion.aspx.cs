/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	catMedioComunicacion
' Autor:	Daniel.Chavez
' Fecha:	31-Mayo-2014
'
' Descripción:
'           Catálogo de MedioComunicacion de la aplicación
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
	public partial class catMedioComunicacion : BPPage
	{

        // Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

        // Enumeraciones
        private enum MedioComunicacionActionTypes { DeleteMedioComunicacion, InsertMedioComunicacion, ReactivateMedioComunicacion, UpdateMedioComunicacion }

        
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
                this.hddMedioComunicacion.Value = "";

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void insertMedioComunicacion()
        {
            BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
            ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formilario
                oENTMedioComunicacion.Nombre = this.txtActionNombre.Text.Trim();
                oENTMedioComunicacion.Descripcion = this.txtActionDescripcion.Text.Trim();


                // Transacción
                oENTResponse = oBPMedioComunicacion.insertcatMedioComunicacion(oENTMedioComunicacion);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar Grid
                selectMedioComunicacion();

                // Mensaje al usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Lugar creado con éxito!'); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }
        }

        private void selectMedioComunicacion()
        {
            BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
            ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();
            ENTResponse oENTResponse = new ENTResponse();

            String sMessage = "";

            try
            {

                // Formulario
                oENTMedioComunicacion.Nombre = this.txtNombre.Text.Trim();


                // Transacción
                oENTResponse = oBPMedioComunicacion.selectcatMedioComunicacion(oENTMedioComunicacion);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { sMessage = "alert('" + oENTResponse.sMessage + "');"; }

                // Llenado de controles
                this.gvMedioComunicacion.DataSource = oENTResponse.dsResponse.Tables[1];
                this.gvMedioComunicacion.DataBind();

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

            }
            catch (Exception ex) { throw (ex); }

        }

        private void selectMedioComunicacion_ForEdit(Int32 MedioComunicacionId)
        {
            BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
            ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTMedioComunicacion.MedioComunicacionId = MedioComunicacionId;
                oENTMedioComunicacion.Nombre = this.txtActionNombre.Text.Trim();


                // Transacción
                oENTResponse = oBPMedioComunicacion.selectcatMedioComunicacion(oENTMedioComunicacion);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                this.lblActionMessage.Text = oENTResponse.sMessage;

                // Llenado de controles
                this.txtActionNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
                this.txtActionDescripcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Descripcion"].ToString();



            }
            catch (Exception ex) { throw (ex); }

        }

        private void SetPanel(MedioComunicacionActionTypes MedioComunicacionActionTypes, Int32 MedioComunicacionId = 0)
        {
            try
            {

                // Acciones comunes
                this.pnlAction.Visible = true;
                this.hddMedioComunicacion.Value = MedioComunicacionId.ToString();

                // Detalle de acción
                switch (MedioComunicacionActionTypes)
                {
                    case MedioComunicacionActionTypes.InsertMedioComunicacion:
                        this.lblActionTitle.Text = "Nuevo Medio de Comunicación";
                        this.btnAction.Text = "Crear Medio";

                        break;

                    case MedioComunicacionActionTypes.UpdateMedioComunicacion:
                        this.lblActionTitle.Text = "Edición Medio de Comunicación";
                        this.btnAction.Text = "Actualizar Medio";
                        selectMedioComunicacion_ForEdit(MedioComunicacionId);

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

        private void updateMedioComunicacion(Int32 MedioComunicacionId)
        {
            BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
            ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTMedioComunicacion.MedioComunicacionId = MedioComunicacionId;
                oENTMedioComunicacion.Nombre = this.txtActionNombre.Text.Trim();
                oENTMedioComunicacion.Descripcion = this.txtActionDescripcion.Text.Trim();


                // Transacción
                oENTResponse = oBPMedioComunicacion.updatecatMedioComunicacion(oENTMedioComunicacion);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Transacción exitosa
                ClearActionPanel();

                // Actualizar grid
                selectMedioComunicacion();

                // Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Información actualizada con éxito!'); focusControl('" + this.txtNombre.ClientID + "');", true);

            }
            catch (Exception ex) { throw (ex); }

        }

        
		// Eventos de la pagina
		
		protected void Page_Load(object sender, EventArgs e)
		{
            // Validación. Solo la primera vez que se ejecuta la página
            if (this.Page.IsPostBack) { return; }

            // Lógica de la página
            try
            {

                // Llenado de controles
                selectMedioComunicacion();

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
                if (this.hddMedioComunicacion.Value == "0")
                {

                    insertMedioComunicacion();
                }
                else
                {

                    updateMedioComunicacion(Int32.Parse(this.hddMedioComunicacion.Value));
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
                selectMedioComunicacion();

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
                SetPanel(MedioComunicacionActionTypes.InsertMedioComunicacion);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvMedioComunicacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Int32 MedioComunicacionId = 0;

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
                MedioComunicacionId = Int32.Parse(this.gvMedioComunicacion.DataKeys[intRow]["MedioComunicacionId"].ToString());

                // Reajuste de Command
                //if (strCommand == "Action")
                //{

                //    strCommand = (this.gvLugar.DataKeys[intRow]["Activo"].ToString() == "0" ? "Reactivar" : "Eliminar");
                //}

                // Acción
                switch (strCommand)
                {
                    case "Editar":
                        SetPanel(MedioComunicacionActionTypes.UpdateMedioComunicacion, MedioComunicacionId);
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
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvMedioComunicacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            //ImageButton imgAction = null;

            String MedioComunicacionId = "";
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
                MedioComunicacionId = this.gvMedioComunicacion.DataKeys[e.Row.RowIndex]["MedioComunicacionId"].ToString();
                sNombre = this.gvMedioComunicacion.DataKeys[e.Row.RowIndex]["Nombre"].ToString();


                // Tooltip Edición
                sTootlTip = "Editar Medio [" + sNombre + "]";
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

        protected void gvMedioComunicacion_Sorting(object sender, GridViewSortEventArgs e){
            try
			{

				gcCommon.SortGridView(ref this.gvMedioComunicacion, ref this.hddSort, e.SortExpression);

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