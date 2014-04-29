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
    public partial class AsignarFuncionario : System.Web.UI.Page
    {
        public string _SolicitudId;
        string AllDefault = "[Seleccione]";
        Function utilFunction = new Function();

        #region "Events"
            protected void Page_Load(object sender, EventArgs e)
            {

            }
        #endregion

        #region
            private void PageLoad()
            {
                if (!Page.IsPostBack)
                {
                    SelectFuncionario();
                }
            }

            private void SelectFuncionario()
            {
                BPFuncionario oBPFuncionario = new BPFuncionario();
                ENTFuncionario oENTFuncionario = new ENTFuncionario();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    // Transacción
                    oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

                    // Validación de error en la consulta
                    if (oENTResponse.GeneratesException)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true);", true);
                        return;
                    }

                    // Mensaje de la base de datos
                    if (oENTResponse.sMessage != "")
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true);", true);

                    //LLenado de control
                    this.FuncionarioList.DataTextField = "sFullName";
                    this.FuncionarioList.DataValueField = "FuncionarioId";

                    this.FuncionarioList.DataSource = oENTResponse.dsResponse.Tables[1];
                    this.FuncionarioList.DataBind();

                    // Agregar Item de selección
                    this.FuncionarioList.Items.Insert(0, new ListItem(AllDefault, "0"));

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
                }
            }
        #endregion
    }
}