using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
    public partial class lstRecSectretarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) { return; }

            this.gvApps.DataSource = null;
            this.gvApps.DataBind();
        }
    }
}