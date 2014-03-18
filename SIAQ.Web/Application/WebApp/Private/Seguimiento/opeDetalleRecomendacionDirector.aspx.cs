using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
    public partial class opeDetalleRecomendacionDirector : BPPage
    {

        #region "Atributos"
        #endregion

        #region "Propiedades"
        #endregion

        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string recomendacionId = GetRawQueryParameter("recomendacionId");

                // Llenar detalle
                LlenarDetalleRecomendacion(recomendacionId);
                // Llenar grd
                SelectRecomendaciones(recomendacionId);
            }
        }

        #region "Botones"

        protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void AsignarDefensorButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ConfirmarCierreButton_Click(object sender, ImageClickEventArgs e)
        {

        }


        protected void cmdGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Grid"

        protected void gvRecomendaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvRecomendaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvRecomendaciones_Sorting(object sender, GridViewSortEventArgs e)
        {

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
            BPRecomendacion.SelectCiudadanoRecomendacionDirector();

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
            BPRecomendacion.SelectDetalleRecomendacionDirector();

            if (BPRecomendacion.ErrorId == 0)
            {
                if (BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    SolicitudLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["ExpedienteId"].ToString();
                    EstatusaLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                    ObservacionesLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                }
            }
        }

        #endregion

    }
}