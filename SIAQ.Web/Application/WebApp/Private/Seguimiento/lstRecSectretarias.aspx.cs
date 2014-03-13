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
    public partial class lstRecSectretarias : System.Web.UI.Page
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
                SelectRecomendacionSecretaria();
            }

        }

        #endregion

        #region Funciones

        private void SelectRecomendacionSecretaria()
        {
            BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

            BPSeguimientoRecomendacion.SelectRecomendacionSecretaria();

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