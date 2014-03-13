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
    public partial class opeDetalleRecomendacionSecretaria : System.Web.UI.Page
    {


        #region Atributo
        #endregion

        #region Propiedades
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string recomendacionId = GetRawQueryParameter("recomendacionId");

                //Llenar lugar hechos
                SelectListaLugarHechos();
                // Llenar detalle
                LlenarDetalleRecomendacion(recomendacionId);
                // Llenar grd
                SelectCiudadanosRecomendacion(recomendacionId);
                // Llenar autoridad
                SelectAutoridadesRecomendacion(recomendacionId);
            }
        }

        #region "Botones"

        protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Application/WebApp/Private/Seguimiento/lstRecSectretarias.aspx");
        }

        protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GenerarCitaButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ConcluirExpButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void AgregarDocButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

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

        private void SelectCiudadanosRecomendacion(string recomendacionId)
        {
            BPRecomendacion BPRecomendacion = new BPRecomendacion();

            BPRecomendacion.RecomendacionEntity.RecomendacionId = Convert.ToInt32(recomendacionId);
            BPRecomendacion.SelectCiudadanoRecomendacionDirector();

            if (BPRecomendacion.ErrorId == 0)
            {
                if (BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvCiudadano.DataSource = BPRecomendacion.RecomendacionEntity.ResultData;
                    gvCiudadano.DataBind();
                }
            }
            else
            {
                gvCiudadano.DataSource = null;
                gvCiudadano.DataBind();
            }
        }

        private void SelectAutoridadesRecomendacion(string recomendacionId)
        {
            BPRecomendacion BPRecomendacion = new BPRecomendacion();

            BPRecomendacion.RecomendacionEntity.RecomendacionId = Convert.ToInt32(recomendacionId);
            BPRecomendacion.SelectAutoridadRecomendacionDirector();

            if (BPRecomendacion.ErrorId == 0)
            {
                if (BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvAutoridades.DataSource = BPRecomendacion.RecomendacionEntity.ResultData;
                    gvAutoridades.DataBind();
                }
            }
            else
            {
                gvAutoridades.DataSource = null;
                gvAutoridades.DataBind();
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
                    CalificacionLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Calificacion"].ToString();
                    EstatusaLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                    VisitadorLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Visitador"].ToString();
                    ContactoLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["FormaContacto"].ToString();
                    TipoSolicitudLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["TipoSolicitud"].ToString();
                    ObservacionesLabel.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                    LugarHechosList.SelectedValue = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["LugarHechosId"].ToString();
                    DireccionHechosBox.Text = BPRecomendacion.RecomendacionEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();
                }
            }
        }

        private void SelectListaLugarHechos()
        {
            BPLugarHechos BPLugarHechos = new BPLugarHechos();

            BPLugarHechos.SelectLugarHechos();

            if (BPLugarHechos.ErrorId == 0)
            {
                if (BPLugarHechos.LugarEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    LugarHechosList.DataSource = BPLugarHechos.LugarEntity.ResultData;
                    LugarHechosList.DataTextField = "Nombre";
                    LugarHechosList.DataValueField = "LugarHechosId";
                    LugarHechosList.DataBind();
                }
            }
            else
            {
                LugarHechosList.DataSource = null;
                LugarHechosList.DataBind();
            }
        }


        #endregion

    }
}