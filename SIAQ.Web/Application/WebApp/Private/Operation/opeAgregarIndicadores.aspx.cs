using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarIndicadores : System.Web.UI.Page
    {
        public string _SolicitudId;
        Function utilFunction = new Function();

        #region "Events"
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

                        _SolicitudId = SolicitudId.ToString();

                        SelectIndicadores(_SolicitudId);
                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Exception.Message) + "', 'Fail', true);", true);
                    }
                }
            }

            private void SelectIndicadores(string SolicitudId)
            {

            }
        #endregion
    }
}