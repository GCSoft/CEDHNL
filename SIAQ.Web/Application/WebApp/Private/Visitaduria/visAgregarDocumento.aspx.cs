using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visAgregarDocumento : System.Web.UI.Page
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

                SelectTipoDocumento();

                DocumentoGrid.DataSource = null;
                DocumentoGrid.DataBind();
            }

            private void SelectTipoDocumento()
            {
                BPTipoDocumento TipoDocumentoProcess = new BPTipoDocumento();

                TipoDocumentoProcess.SelectTipoDocumento();

                if (TipoDocumentoProcess.ErrorId == 0)
                {
                    TipoDocumentoList.DataValueField = "TipoDocumentoId";
                    TipoDocumentoList.DataTextField = "Nombre";

                    TipoDocumentoList.DataSource = TipoDocumentoProcess.TipoDocumentoEntity.ResultData;
                    TipoDocumentoList.DataBind();

                    TipoDocumentoList.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + TipoDocumentoProcess.ErrorDescription + "', 'Error', true);", true);
            }
        #endregion
    }
}