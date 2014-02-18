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
   public partial class opeBusquedaSolicitud : System.Web.UI.Page
   {
       string AllDefault = "[Seleccione]";

       protected void SearchButton_Click(object sender, EventArgs e)
       {
           BuscarSolicitud(Int32.Parse(txtNumeroSolicitud.Text.Trim()) , txtCiudadano.Text.Trim());
       }

             protected void Page_Load(object sender, EventArgs e)
            {
              PageLoad();
            }

             protected void BuscarSolicitud(Int32 NumeroSolicitud, string Ciudadano)
             {
                 BPSolicitud BPSolicitud = new BPSolicitud();

                 BPSolicitud.SolicitudEntity.SolicitudId = NumeroSolicitud;
                 BPSolicitud.SolicitudEntity.Nombre = Ciudadano;
                 BPSolicitud.SolicitudEntity.MedioComunicacion = Int32.Parse(ddlFormaContacto.SelectedValue);
                 BPSolicitud.SolicitudEntity.FuncinarioId = Int32.Parse(ddlFuncionario.SelectedValue);

                 BPSolicitud.SelectSolicitud();
                         
                 if (BPSolicitud.ErrorId == 0)
                    {
                        if (BPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
                        {
                            gvSolicitud.DataSource = BPSolicitud.SolicitudEntity.ResultData;
                            gvSolicitud.DataBind();
                        }

                     }

                else
                {
                    gvSolicitud.DataSource = null;
                    gvSolicitud.DataBind();
                }
                 



             }
            protected void PageLoad()
            {
                if (!Page.IsPostBack)
                {
                    SelectFuncionario();
                    SelectContacto();
                }

            }


            protected void SelectFuncionario()
            {

                BPFuncionario BPFuncionario = new BPFuncionario();

                ddlFuncionario.DataValueField = "FuncionarioId";
                ddlFuncionario.DataTextField = "Nombre";

                ddlFuncionario.DataSource = BPFuncionario.SelectFuncionario();
                ddlFuncionario.DataBind();
                ddlFuncionario.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            protected void SelectContacto()
            {
                BPMedioComunicacion BPMedioComunicacion = new BPMedioComunicacion();

                ddlFormaContacto.DataTextField = "Nombre";
                ddlFormaContacto.DataValueField = "MedioComunicacionId";

                ddlFormaContacto.DataSource = BPMedioComunicacion.SelectMedioComunicacion();
                ddlFormaContacto.DataBind();
                ddlFormaContacto.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
   }
}