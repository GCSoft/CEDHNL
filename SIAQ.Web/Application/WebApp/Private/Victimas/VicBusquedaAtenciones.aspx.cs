/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicBusquedaAtenciones
' Autor:	Ruben.Cobos
' Fecha:	02-Junio-2014
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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class VicBusquedaAtenciones : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


        protected void Page_Load(object sender, EventArgs e){
            try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }

				// Llenado de controles
			    Fillcbo();

                // Estado inicial
				this.gvApps.DataSource = null;
				this.gvApps.DataBind();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtAtencionId.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAtencionId.ClientID + "');", true);
            }
		}

        /// <summary>
        /// Rutinas de la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Rutinas de la página

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                // Obtener Atenciones
                Buscar();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtAtencionId.ClientID + "');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAtencionId.ClientID + "');", true);
            }
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string AtencionId;

            string strCommand = "";
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
                AtencionId = this.gvApps.DataKeys[intRow]["AtencionId"].ToString();

                // Acción
                switch (strCommand)
                {
                    case "Editar":
                        this.Response.Redirect("VicDetalleAtencion.aspx?key=" + AtencionId + "|2", false);
                        break;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAtencionId.ClientID + "');", true);
            }
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String sNumero = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {

                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                // DataKeys
                sNumero = gvApps.DataKeys[e.Row.RowIndex]["AtencionId"].ToString();

                // Tooltip Editar Atención
                sToolTip = "Detalle de atención [" + sNumero + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvApps_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableAutoridad = null;
            DataView ViewAutoridad = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableAutoridad = utilFunction.ParseGridViewToDataTable(gvApps, false);
                ViewAutoridad = new DataView(TableAutoridad);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewAutoridad.Sort = hddSort.Value;

                //Vaciar datos
                this.gvApps.DataSource = ViewAutoridad;
                this.gvApps.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAtencionId.ClientID + "');", true);
            }
        }

        #endregion
        
        /// <summary>
        /// Rutinas del programador
        /// </summary>
        #region Rutinas del programador

        private void Buscar()
        {

            BPAtencion bss = new BPAtencion();
            ENTAtencion ent = new ENTAtencion();
            ENTSession oSession = (ENTSession)Session["oENTSession"];
            ENTResponse oResponse = new ENTResponse();

            // Estado inicial del grid
            this.gvApps.DataSource = null;
            this.gvApps.DataBind();

            // Asignar valores
            ent.AtencionId = txtAtencionId.Text != "" ? Int32.Parse(txtAtencionId.Text) : 0;
            ent.SolicitudId = txtSolicitudId.Text != "" ? Int32.Parse(txtSolicitudId.Text) : 0;
            ent.NombreCiudadano = txtCiudadano.Text != "" ? txtCiudadano.Text : "";
            ent.DoctorId = Int32.Parse(ddlDoctor.SelectedItem.Value.ToString());
            ent.IdUsuario = oSession.idUsuario;
            ent.Aprobar = 0;

            // Transacción
            oResponse = bss.VicBusquedaAtencion(ent);

            // Validaciones
            if (ent.ErrorId != 0) { throw (new Exception(ent.ErrorString)); }

            // Listado de Atenciones
            if (oResponse.dsResponse.Tables[1].Rows.Count > 0)
            {

                this.gvApps.DataSource = oResponse.dsResponse.Tables[1];
                this.gvApps.DataBind();
            }

        }

        private void Fillcbo()
        {
            // Declaración de variables
            ENTResponse oResponse = new ENTResponse();
            ENTFuncionario ent = new ENTFuncionario();
            BPFuncionario bss = new BPFuncionario();

            try
            {
                // Transacción
                oResponse = bss.searchDoctores(ent);

                if (oResponse.dsResponse.Tables[1].Rows.Count > 0)
                {
                    ddlDoctor.DataSource = oResponse.dsResponse.Tables[1];
                    ddlDoctor.DataValueField = "DoctorId";
                    ddlDoctor.DataTextField = "Nombre";
                    ddlDoctor.DataBind();
                }
            }
            catch (Exception ex) { throw (ex); }
            finally { }
        }

        #endregion

    }
}