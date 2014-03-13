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
    public partial class opeLstRecDefensor : System.Web.UI.Page
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
                string usuarioId = "7";

                SelectRecomendacionDefensor(usuarioId);
            }
        }

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