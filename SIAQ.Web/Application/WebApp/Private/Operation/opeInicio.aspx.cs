using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page.IsPostBack){
                return;
            }
        }

        protected void imgRegistrarVis_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("opeRegistroVisita.aspx");
        }

        protected void imgBuscarSol_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("opeBusquedaSolicitud.aspx");
        }

        protected void imgRegistrarSol_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("opeRegistroSolicitud.aspx");
        }
    }
}