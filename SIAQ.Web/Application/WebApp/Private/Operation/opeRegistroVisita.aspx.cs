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
                //SelectFuncionario();
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