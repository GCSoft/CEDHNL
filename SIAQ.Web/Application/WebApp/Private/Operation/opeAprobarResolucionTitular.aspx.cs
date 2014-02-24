using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAprobarResolucionTitular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.gvAutoridades.DataSource = null;
            this.gvAutoridades.DataBind();

            this.gvCiudadano.DataSource = null;
            this.gvCiudadano.DataBind();
        }
    }
}