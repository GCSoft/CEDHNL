/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    VicListadoAtenciones
' Autor:		JJGU
' Fecha:		03-Junio-2014
'
' Modificación:
'           Se reconstruyó la pantalla reutilizando los métodos existentes
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
	public partial class VicListadoAtenciones : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {

                    // Validaciones
                    if (Page.IsPostBack) { return; }

                    // Obtener Expedientes
                    Buscar();

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
                }
            }

        /// <summary>
        /// Eventos de la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Eventos de la página

		    protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e){

                String AtencionId;
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
				    AtencionId = this.gvApps.DataKeys[intRow]["AtencionId"].ToString();

				    // Acción
				    switch (strCommand){
					    case "Editar":
						    this.Response.Redirect("VicDetalleVictimas.aspx?key=" + AtencionId, false);
						    break;
				    }

			    }catch (Exception ex){
				    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			    }
		    }

		    protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e){
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

				    // Tooltip Editar Expediente
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

			    }catch (Exception ex){
				    throw (ex);
			    }
		    }

		    protected void gvApps_Sorting(object sender, GridViewSortEventArgs e){
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

			    }catch (Exception ex){
				    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
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
                ent.IdUsuario = oSession.idUsuario;
                ent.Aprobar = 0;

                // Transacción
                oResponse = bss.searchAtencion(ent);

                // Validaciones
                if (ent.ErrorId != 0) { throw (new Exception(ent.ErrorString)); }

                // Listado de Atenciones
                if (oResponse.dsResponse.Tables[1].Rows.Count > 0)
                {

                    this.gvApps.DataSource = oResponse.dsResponse.Tables[1];
                    this.gvApps.DataBind();
                }

            }

        #endregion
    }
}