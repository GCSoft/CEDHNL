/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAtencionVictimas
' Autor:	JJ
' Fecha:	15-Septiembre-2014
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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueAtencionVictimas : System.Web.UI.Page
	{
		
		// Utilerías
        GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

        // Rutinas del programador
        #region Rutinas del programador

        void SelectSolicitud(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Detalle(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();

				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}
        #endregion

        // Eventos de la página
        #region Eventos de la página

        protected void Page_Load(object sender, EventArgs e){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener SolicitudId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Carátula
				SelectSolicitud();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

        protected void btnAgregarAtencion_Click(object sender, EventArgs e)
        {
            try
            {

                // Transacción
                //InsertAtencionVictima();

                // Limpiar el formulario
                //ClearForm();

                // Actualizar pantalla
                SelectSolicitud();

                // Foco
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
            }
        }

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

        protected void gvAtencionVictimas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String CiudadanoId = "";
            String strCommand = "";

            try
            {

                // Opción seleccionada
                strCommand = e.CommandName.ToString();

                // Se dispara el evento RowCommand en el ordenamiento
                if (strCommand == "Sort") { return; }

                // Obtener CiudadanoId
                CiudadanoId = e.CommandArgument.ToString();

                // Transacción
                switch (strCommand)
                {

                    case "Editar":
                        Response.Redirect("../Operation/opeRegistroAtencion.aspx?s=" + CiudadanoId + "&key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
                        break;

                    case "Eliminar":

                        // Eliminar el ciudadano de la solicitud
                        //DeleteSolicitudCiudadano(Int32.Parse(CiudadanoId));

                        // Limpiar el formulario
                        //ClearForm();

                        // Actualizar pantalla
                        SelectSolicitud();

                        // Foco
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.AfectadoLabel.ClientID + "'); }", true);

                        break;

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.AfectadoLabel.ClientID + "'); }", true);
            }
        }

        protected void gvAtencionVictimas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgDelete = null;
            ImageButton imgEdit = null;

            String sCiudadanoId = "";
            String sUsuarioId = "";
            String sNombreCiudadano = "";

            String sToolTip = "";
            String sImagesAttributes = "";

            //try
            //{

            //    // Validación de que sea fila 
            //    if (e.Row.RowType != DataControlRowType.DataRow)
            //    {
            //        oENTSession = (ENTSession)Session["oENTSession"];
            //        return;
            //    }

            //    // Obtener imagenes
            //    imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
            //    imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

            //    // DataKeys
            //    sCiudadanoId = gvAtencionVictimas.DataKeys[e.Row.RowIndex]["AtencionDetalleId"].ToString();
            //    sUsuarioId = gvAtencionVictimas.DataKeys[e.Row.RowIndex]["AtencionId"].ToString();

            //    // Si el usuario que está consultando es Funcionario no se permite que elimine ciudadanos que él no haya registrado
            //    if (oENTSession.idRol == 5 && oENTSession.idUsuario.ToString() != sUsuarioId)
            //    {

            //        imgDelete.Visible = false;

            //        // Tooltip Editar
            //        sToolTip = "Editar ciudadano [" + sNombreCiudadano + "]";
            //        imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
            //        imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            //        imgEdit.Attributes.Add("style", "curosr:hand;");

            //        // Atributos Over
            //        sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
            //        e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

            //        // Atributos Out
            //        sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
            //        e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            //    }
            //    else
            //    {

            //        // Tooltip Editar
            //        sToolTip = "Editar ciudadano [" + sNombreCiudadano + "]";
            //        imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
            //        imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            //        imgEdit.Attributes.Add("style", "curosr:hand;");

            //        // Tooltip Eliminar
            //        sToolTip = "Eliminar de la Solicitud a [" + sNombreCiudadano + "]";
            //        imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
            //        imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
            //        imgDelete.Attributes.Add("style", "cursor:hand;");

            //        // Atributos Over
            //        sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
            //        sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
            //        e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

            //        // Atributos Out
            //        sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
            //        sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
            //        e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        protected void gvAtencionVictimas_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {

                gcCommon.SortGridView(ref this.gvAtencionVictimas, ref this.hddSort, e.SortExpression);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        #endregion

        // Rutinas del popup

        // Eventos del popup
        #region Eventos del popup

        protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                // Cancelar transacción
                //ClearActionPanel();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (this.hddDiligenciaId.Value == "0")
            //    {

            //        InsertSolicitudDiligencia();
            //    }
            //    else
            //    {

            //        UpdateSolicitudDiligencia(this.hddDiligenciaId.Value);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    this.lblActionMessage.Text = ex.Message;
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlFuncionario.ClientID + "');", true);
            //}
        }


        #endregion
    }
}