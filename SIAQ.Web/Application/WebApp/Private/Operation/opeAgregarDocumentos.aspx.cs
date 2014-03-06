using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarDocumentos : System.Web.UI.Page
    {
        public string _SolicitudId;

        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                GuardarDocumento();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region
            private void PageLoad()
            {
                int SolicitudId = 0;

                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                        SelectDocumento(SolicitudId);

                        _SolicitudId = SolicitudId.ToString();
                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            private void GuardarDocumento()
            {

            }

            private void SelectDocumento(int SolicitudId)
            {

            }
        #endregion
    }
}