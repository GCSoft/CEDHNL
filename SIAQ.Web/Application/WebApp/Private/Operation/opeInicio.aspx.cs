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

		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			if (Page.IsPostBack) { return; }
		}

		protected void imgBuscarSol_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("opeBusquedaSolicitud.aspx");
		}

		protected void imgRegistrarSol_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("opeRegistroSolicitud.aspx?key=0|1");
		}

		protected void imgRegistrarVis_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("opeRegistroVisita.aspx?key=0|1");
		}

    }
}