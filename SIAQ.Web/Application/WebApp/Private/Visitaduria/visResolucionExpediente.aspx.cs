using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visResolucionExpediente : System.Web.UI.Page
    {
        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {

            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"

            private void PageLoad()
            {
                if (Page.IsPostBack)
                    return;
            }
        #endregion
    }
}