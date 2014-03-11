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
    public partial class opeLstRecDirector : System.Web.UI.Page
    {
        #region Atributos
        #endregion

        #region Propiedades
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // llena grid de recomendaciones 
                SelectRecomendacionesDirector();
            }
        }

        #endregion

        #region Funciones

        /// <summary>
        /// Obtiene las recomendaciones correspondientes al director logeado 
        /// </summary>
        private void SelectRecomendacionesDirector()
        {
            BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

            BPSeguimientoRecomendacion.SelectRecomendacionDirector();

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