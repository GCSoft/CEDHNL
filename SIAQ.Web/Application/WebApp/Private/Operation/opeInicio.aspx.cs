// Referencias
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// Referencias manuales
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeInicio : BPPage
    {

		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			if (Page.IsPostBack) { return; }
		}

		protected void imgBuscarSol_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("../Quejas/QueBusquedaSolicitudes.aspx");
		}

		protected void imgRegistrarSol_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("opeRegistroSolicitud.aspx?key=0|1");
		}

		protected void imgRegistrarVis_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("opeRegistroVisita.aspx?key=0|1");
		}

    }
}