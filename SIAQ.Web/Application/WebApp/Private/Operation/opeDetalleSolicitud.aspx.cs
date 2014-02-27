using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleSolicitud : System.Web.UI.Page
    {
        #region "Events"
            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void PageLoad()
            {
                int SolicitudId = 0;

                if (this.Page.IsPostBack)
                {
                    // ToDo: Hay que recibir el parámetro de la solicitud
                    SolicitudId = 1004;

                    SelectSolicitud(SolicitudId);

                    this.gvCiudadano.DataSource = null;
                    this.gvCiudadano.DataBind();

                    this.gvAutoridades.DataSource = null;
                    this.gvAutoridades.DataBind();
                }
            }

            private void SelectSolicitud(int SolicitudId)
            {

            }
        #endregion
    }
}