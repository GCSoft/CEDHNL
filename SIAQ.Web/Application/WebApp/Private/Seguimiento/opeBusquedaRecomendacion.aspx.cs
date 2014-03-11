using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
    public partial class opeBusquedaRecomendacion : System.Web.UI.Page
    {

        // Rutinas del programador
        private void selectFuncionario() {

            BPFuncionario oBPFuncionario = new BPFuncionario();
            ENTFuncionario oENTFuncionario = new ENTFuncionario();
            ENTResponse oENTResponse = new ENTResponse();

            // Transacción
            try
            {

                oENTResponse = oBPFuncionario.searchFuncionario(oENTFuncionario);

                // validación de error
                if (oENTResponse.GeneratesException)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
                    return;
                }

                // Mensaje base de datos
                if (oENTResponse.sMessage != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
                    return;
                }

                // Llenado de control
                this.cboDefensor.DataTextField = "Nombre";
                this.cboDefensor.DataValueField = "FuncionarioId";
                this.cboDefensor.DataSource = oENTResponse.dsResponse.Tables[1];
                this.cboDefensor.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
            }
        }

        private void selectMedioComunicacion() {

            BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
            ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();
            ENTResponse oENTResponse = new ENTResponse();

            // Transacción
            try {

                oENTResponse = oBPMedioComunicacion.searchcatMedioComunicacion(oENTMedioComunicacion);

                // validación de error
                if (oENTResponse.GeneratesException) {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
                    return;
                }

                // Mensaje base de datos
                if (oENTResponse.sMessage != "") {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
                    return;
                }

                // Llenado de control
                this.cboFormaContacto.DataTextField = "Nombre";
                this.cboFormaContacto.DataValueField = "MedioComunicacionId";
                this.cboFormaContacto.DataSource = oENTResponse.dsResponse.Tables[1];
                this.cboFormaContacto.DataBind();

            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
            }
        }

        // Eventos de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validación. Solo la primera vez que se ejecuta la página
            if (this.Page.IsPostBack) { return; }

            // Lógica de la página
            try {

                // Llenado de controles
                selectFuncionario();
                selectMedioComunicacion();
                
                this.gvApps.DataSource = null;
                this.gvApps.DataBind();
            }
            catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroRecomendacion.ClientID + "');", true);
            }
            
        }
    }
}