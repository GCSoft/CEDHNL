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
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
    public partial class opeDetalleRecomendacionDirector : System.Web.UI.Page
    {

        #region "Atributos"

        Function utilFunction = new Function();

        #endregion

        #region "Propiedades"
        #endregion

        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string recomendacionId = GetRawQueryParameter("recomendacionId");
                hdnRecomendacionId.Value = recomendacionId;

                // Llenar detalle
                LlenarDetalleRecomendacion(recomendacionId);
                // Llenar grd
                SelectRecomendaciones(recomendacionId);
            }
        }

        #region "Botones"

        protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Application/WebApp/Private/Seguimiento/opeLstRecDirector.aspx");
        }

        protected void AsignarDefensorButton_Click(object sender, ImageClickEventArgs e)
        {
            string recomendacionId = hdnRecomendacionId.Value;

            if (String.IsNullOrEmpty(hdnRecomendacionId.Value))
            {
                recomendacionId = GetRawQueryParameter("recomendacionId");
            }

            Response.Redirect("/Application/WebApp/Private/Seguimiento/opeAsignarDefensorDirector.aspx?recomendacionId=" + recomendacionId);
        }

        protected void ConfirmarCierreButton_Click(object sender, ImageClickEventArgs e)
        {
            string recomendacionId = hdnRecomendacionId.Value;

            if (String.IsNullOrEmpty(hdnRecomendacionId.Value))
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
            Response.Redirect("~/Application/WebApp/Private/Seguimiento/opeLstRecDirector.aspx");
        }

        #endregion

        #region "Grid"

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            String sNumeroRecomendacion = "";
            String sImagesAttributes = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //DataKeys
                sNumeroRecomendacion = gvApps.DataKeys[e.Row.RowIndex]["RecomendacionId"].ToString();

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

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

        #region "Funciones"

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
                    gvApps.DataSource = BPRecomendacion.RecomendacionEntity.ResultData;
                    gvApps.DataBind();
                }
            }
            else
            {
                gvApps.DataSource = null;
                gvApps.DataBind();
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