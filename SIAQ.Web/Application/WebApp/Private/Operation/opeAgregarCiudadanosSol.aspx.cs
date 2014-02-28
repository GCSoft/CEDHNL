// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarCiudadanosSol : System.Web.UI.Page
    {
        // Rutinas del programador


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) { return; }

            this.gvApps.DataSource = null;
            this.gvApps.DataBind();

            this.chkListCiudadanos.Items.Add("Laura Cepeda");
            this.chkListCiudadanos.Items.Add("Lizeth Muriño");
            this.chkListCiudadanos.Items.Add("Laura Cepeda");
            this.chkListCiudadanos.Items.Add("Lizeth Muriño");
            this.chkListCiudadanos.Items.Add("Laura Cepeda");
            this.chkListCiudadanos.Items.Add("Lizeth Muriño");
            this.chkListCiudadanos.Items.Add("Laura Cepeda");
            this.chkListCiudadanos.Items.Add("Lizeth Muriño");
            this.chkListCiudadanos.Items.Add("Laura Cepeda");
            this.chkListCiudadanos.Items.Add("Lizeth Muriño");
        }
    }
}