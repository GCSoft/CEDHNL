using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visSeguimientoExpediente : System.Web.UI.Page
    {
        #region "Events"
            protected void AgregarButton_Click(object sender, EventArgs e)
            {
                MostrarPanel();
            }

            protected void GuardarButton_Click(object sender, EventArgs e)
            {

            }

            protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
            {
                OcultarPanel();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void MostrarPanel()
            {
                pnlAction.Visible = true;
            }

            private void OcultarPanel()
            {
                pnlAction.Visible = false;
            }

            private void PageLoad()
            {
                if (Page.IsPostBack)
                    return;

                SeguimientoGrid.DataSource = null;
                SeguimientoGrid.DataBind();
            }
        #endregion
    }
}