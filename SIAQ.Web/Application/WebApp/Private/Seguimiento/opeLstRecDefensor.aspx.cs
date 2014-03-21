using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
    public partial class opeLstRecDefensor : BPPage
    {
        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string usuarioId = "7";

                SelectRecomendacionDefensor(usuarioId);
            }
        }

        #region "GridView"

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string RecomendacionId = String.Empty;

            RecomendacionId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Editar":
                    Response.Redirect("~/Application/WebApp/Private/Seguimiento/opeDetalleRecomendacionDefensor.aspx?recomendacionId=" + RecomendacionId);
                    break;
            }
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            String sNumeroRecomendacion = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                //DataKeys
                sNumeroRecomendacion = gvApps.DataKeys[e.Row.RowIndex]["Recomendacion"].ToString();

                //Tooltip Edición
                sToolTip = "Editar recomendación [" + sNumeroRecomendacion + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvApps_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableRecomendacion = null;
            DataView ViewRecomendacion = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableRecomendacion = utilFunction.ParseGridViewToDataTable(gvApps, false);
                ViewRecomendacion = new DataView(TableRecomendacion);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewRecomendacion.Sort = hddSort.Value;

                //Vaciar datos
                gvApps.DataSource = ViewRecomendacion;
                gvApps.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #endregion

        #endregion

        #region Funciones

        private void SelectRecomendacionDefensor(string usuarioId)
        {
            BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

            BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.FuncionarioId = Int32.Parse(usuarioId);
            BPSeguimientoRecomendacion.SelectRecomendacionDefensor();

            if (BPSeguimientoRecomendacion.ErrorId == 0)
            {
                if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvApps.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData;
                    gvApps.DataBind();
                }
            }
            else
            {
                gvApps.DataSource = null;
                gvApps.DataBind();
            }

        }

        #endregion


    }
}