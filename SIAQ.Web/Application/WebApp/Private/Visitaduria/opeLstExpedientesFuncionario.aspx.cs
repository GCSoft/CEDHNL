// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

// Referencias manuales
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeLstExpedientesFuncionario : System.Web.UI.Page
    {
        Function utilFunction = new Function();

        // Rutinas del programador
        private void selectExpediente()
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];
            oENTExpediente.FuncionarioId = oENTSession.FuncionarioId;

            oBPExpediente.SelectExpediente_Funcionario(oENTExpediente);

            if (oBPExpediente.ErrorId == 0)
            {
                if (oBPExpediente.ExpedienteEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvApps.DataSource = oBPExpediente.ExpedienteEntity.ResultData;
                    gvApps.DataBind();
                }
                else
                {
                    gvApps.DataSource = null;
                    gvApps.DataBind();
                }
            }
            else
            {
                gvApps.DataSource = null;
                gvApps.DataBind();
            }
        }

        // Eventos de la página
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Page.IsPostBack) { return; }


            selectExpediente();
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ExpedienteId = String.Empty;

            ExpedienteId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Editar":
                    Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeDetalleExpedienteVisitador.aspx?expId=" + ExpedienteId);
                    break;
            }
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            String sNumeroExpediente = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }

                //Decodificar HTML
                string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[2].Text);
                decodedText = Regex.Replace(decodedText, "<[^>]*>", string.Empty);
                e.Row.Cells[2].Text = decodedText;

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                //DataKeys
                sNumeroExpediente = gvApps.DataKeys[e.Row.RowIndex]["Numero"].ToString();

                //Tooltip Edición
                sToolTip = "Editar expediente [" + sNumeroExpediente + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvApps_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableExpediente = null;
            DataView ViewExpediente = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableExpediente = utilFunction.ParseGridViewToDataTable(gvApps, false);
                ViewExpediente = new DataView(TableExpediente);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewExpediente.Sort = hddSort.Value;

                //Vaciar datos
                gvApps.DataSource = ViewExpediente;
                gvApps.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }




    }
}