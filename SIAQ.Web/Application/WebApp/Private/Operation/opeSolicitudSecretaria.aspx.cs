using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeSolicitudSecretaria : System.Web.UI.Page
    {
        // Utilerías
        Function utilFunction = new Function();

        #region "Event"
            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }

            protected void SolicitudGrid_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                SolicitudGridRowCommand(e);
            }

            protected void SolicitudGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                ImageButton imgEdit = null;
                String sNumeroSol = "";
                String sImagesAttributes = "";
                String sTootlTip = "";

                try
                {
                    // Validación de que sea fila
                    if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                    // Obtener imagenes
                    imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                    // Datakeys
                    sNumeroSol = this.SolicitudGrid.DataKeys[e.Row.RowIndex]["NumeroSol"].ToString();

                    // Tooltip Edición
                    sTootlTip = "Editar Solicitud [" + sNumeroSol + "]";
                    imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
                    imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                    imgEdit.Attributes.Add("style", "cursor:hand;");

                    // Atributos Over
                    sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

                    // Puntero y Sombra en fila Over
                    e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                    // Atributos Out
                    sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

                    // Puntero y Sombra en fila Out
                    e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            protected void SolicitudGrid_Sorting(object sender, GridViewSortEventArgs e)
            {
                DataTable tblSolicitud = null;
                DataView viewSolicitud = null;

                try
                {
                    // Obtener DataTable y DataView del GridView
                    tblSolicitud = utilFunction.ParseGridViewToDataTable(this.SolicitudGrid, false);
                    viewSolicitud = new DataView(tblSolicitud);

                    // Determinar ordenamiento
                    this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                    // Ordenar vista
                    viewSolicitud.Sort = this.hddSort.Value;

                    // Vaciar datos
                    this.SolicitudGrid.DataSource = viewSolicitud;
                    this.SolicitudGrid.DataBind();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
                }
            }
        #endregion

        #region "Method"
            private void PageLoad()
            {
                if (!Page.IsPostBack)
                {
                    SelectSolicitud();
                }
            }

            private void SelectSolicitud()
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SelectSolicitudSecretaria();

                if (SolicitudProcess.ErrorId == 0)
                {
                    SolicitudGrid.DataSource = SolicitudProcess.SolicitudEntity.ResultData;
                    SolicitudGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + SolicitudProcess.ErrorDescription + "', 'Error', true);", true);
            }

            private void SolicitudGridRowCommand(GridViewCommandEventArgs e)
            {
                string SolicitudId = string.Empty;

                SolicitudId = e.CommandArgument.ToString();

                switch (e.CommandName.ToString())
                {
                    case "Editar":
                        Response.Redirect(ConfigurationManager.AppSettings["Application.Url.SolicitudDetalle"].ToString() + "?s=" + SolicitudId);
                        break;
                }
            }
        #endregion
    }
}