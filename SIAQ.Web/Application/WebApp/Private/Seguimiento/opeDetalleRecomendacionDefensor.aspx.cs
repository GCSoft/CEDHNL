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
    public partial class opeDetalleRecomendacionDefensor : System.Web.UI.Page
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
                string recomendacionId = GetRawQueryParameter("recomendacionId");
                //string recomendacionId = "1";

                // Llenar detalle
                LlenarDetalleRecomendacion(recomendacionId);
                // Llenar grd
                SelectRecomendaciones(recomendacionId);
            }
        }

        #region "Botones"


        protected void gvRecomendaciones_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableRecomendacion = null;
            DataView ViewRecomendacion = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableRecomendacion = utilFunction.ParseGridViewToDataTable(gvRecomendaciones, false);
                ViewRecomendacion = new DataView(TableRecomendacion);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewRecomendacion.Sort = hddSort.Value;

                //Vaciar datos
                gvRecomendaciones.DataSource = ViewRecomendacion;
                gvRecomendaciones.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvRecomendaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string RecomendacionId = String.Empty;

            RecomendacionId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Editar":
                    // TO DO: Esta pantalla redireccionará a la pantalla de seguimiento de la cual aún no se tiene bosquejo
                    Response.Redirect("~/Application/WebApp/Private/Seguimiento/opeDetalleRecomendacionDefensor.aspx?recomendacionId=" + RecomendacionId);
                    break;
            }
        }

        protected void gvRecomendaciones_RowDataBound(object sender, GridViewRowEventArgs e)
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
                sNumeroRecomendacion = gvRecomendaciones.DataKeys[e.Row.RowIndex]["RecomendacionId"].ToString();

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

        protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Application/WebApp/Private/Seguimiento/opeLstRecDefensor.aspx");
        }

        protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void NotificacionesButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void CerrarExpedienteButton_Click(object sender, ImageClickEventArgs e)
        {
            string recomendacionId = hdnRecomendacionId.Value;

            if (String.IsNullOrEmpty(recomendacionId))
            {
                recomendacionId = GetRawQueryParameter("recomendacionId");
            }

            Response.Redirect("~/Application/WebApp/Private/Seguimiento/opeConfirmarCierreExpediente.aspx?recomendacionId=" + recomendacionId);
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            
        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Application/WebApp/Private/Seguimiento/opeLstRecDefensor.aspx");
        }

        #endregion

        #endregion

        #region Funciones

        public string GetRawQueryParameter(string parameterName)
        {
            string raw = Request.RawUrl;
            int startQueryIdx = raw.IndexOf('?');
            if (startQueryIdx < 0)
                return null;

            int nameLength = parameterName.Length + 1;
            int startIdx = raw.IndexOf(parameterName + "=", startQueryIdx);
            if (startIdx < 0)
                return null;

            startIdx += nameLength;
            int endIdx = raw.IndexOf('&', startIdx);
            if (endIdx < 0)
                endIdx = raw.Length;

            return raw.Substring(startIdx, endIdx - startIdx);
        }

        private void SelectRecomendaciones(string recomendacionId)
        {
            BPRecomendacion BPRecomendacion = new BPRecomendacion();

            BPRecomendacion.RecomendacionEntity.RecomendacionId = Convert.ToInt32(recomendacionId);
            BPRecomendacion.SelectDetalleRecomendacionGrid();

            if (BPRecomendacion.ErrorId == 0)
            {
                if (BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvRecomendaciones.DataSource = BPRecomendacion.RecomendacionEntity.ResultData;
                    gvRecomendaciones.DataBind();
                }
            }
            else
            {
                gvRecomendaciones.DataSource = null;
                gvRecomendaciones.DataBind();
            }
        }

        private void LlenarDetalleRecomendacion(string recomendacionId)
        {
            BPRecomendacion BPRecomendacion = new BPRecomendacion();

            BPRecomendacion.RecomendacionEntity.RecomendacionId = Convert.ToInt32(recomendacionId);
            BPRecomendacion.SelectDetalleRecomendacion();

            if (BPRecomendacion.ErrorId == 0)
            {
                if (BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    SolicitudLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["ExpedienteNumero"].ToString();
                    EstatusaLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                    DefensorLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Defensor"].ToString();
                    NumSolicitudLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["NumSolicitud"].ToString();
                    ObservacionesLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                }
            }
        }

        #endregion

    }
}