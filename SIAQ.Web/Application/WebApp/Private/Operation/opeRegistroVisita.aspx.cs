using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeRegistroVisita : System.Web.UI.Page
    {
        string AllDefault = "[Seleccione]";

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ddlArea.SelectedValue == "0" || ddlFuncionario.SelectedValue == "0" || ddlMotivo.SelectedValue == "0" || DescriptionBox.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Se deben de llenar todo los campos para poder guardar', 'Success', true); focusControl('" + this.DescriptionBox.ClientID + "');", true);

            }

            else {

                GuardarVisita();
            }
              
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        protected void PageLoad()
        {
            if (!Page.IsPostBack)
            {
                //Fechas
                DateTime Time = DateTime.Now;
                string Fecha = "dd-MM-yyyy";
                string Hora = "HH:mm tt";
                txtBoxFecha.Text = Time.ToString(Fecha);
                txtBoxHora.Text = Time.ToString(Hora);
                //Consultas para los DropdownList
                SelectArea();
                SelectFuncionario();
                SelectMotivo();
            }

        }


            protected void SelectArea(){

                BPArea BPArea = new BPArea();

                ddlArea.DataValueField = "idArea";
                ddlArea.DataTextField = "sNombre";

                ddlArea.DataSource = BPArea.SelectArea();
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            protected void SelectFuncionario(){

                BPFuncionario BPFuncionario = new BPFuncionario();
                
                ddlFuncionario.DataValueField = "FuncionarioId";
                ddlFuncionario.DataTextField = "Nombre";

                ddlFuncionario.DataSource = BPFuncionario.SelectFuncionario();
                ddlFuncionario.DataBind();
                ddlFuncionario.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            protected void GuardarVisita(){

                BPVisita BPVisita = new BPVisita();

                BPVisita.ENTVisita.AreaId = Int32.Parse(ddlArea.SelectedValue);
                BPVisita.ENTVisita.MotivoId = Int32.Parse(ddlMotivo.SelectedValue);
                BPVisita.ENTVisita.FuncionarioId = Int32.Parse(ddlFuncionario.SelectedValue);
                BPVisita.ENTVisita.UsuarioIdInsert = 0;//pendiente "verrificar como usan el id de ususario en el sistema"
                BPVisita.ENTVisita.Observaciones = DescriptionBox.Text;

                BPVisita.GuardarVisita();
                if (BPVisita.ErrorId == 0) {

                    ResetearCampos();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Guardado con éxito', 'Success', true); focusControl('" + this.DescriptionBox.ClientID + "');", true);
                }
                else {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Problema al intentar de guardar la visita', 'Success', true); focusControl('" + this.DescriptionBox.ClientID + "');", true);
                }
            
            }

            protected void ResetearCampos() { 
            
            ddlArea.SelectedIndex = 0;
            ddlMotivo.SelectedIndex = 0;
            ddlFuncionario.SelectedIndex = 0;
            DescriptionBox.Text = "";
            }    

            protected void SelectMotivo(){

                BPMotivo BPMotivo = new BPMotivo();
                ddlMotivo.DataValueField = "MotivoId";
                ddlMotivo.DataTextField = "Nombre";

                ddlMotivo.DataSource = BPMotivo.SelectMotivo();
                ddlMotivo.DataBind();
                ddlMotivo.Items.Insert(0, new ListItem(AllDefault, "0"));
            }
    }
}