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
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeBusquedaExpedientes : BPPage
    {
        // Rutinas del programador

        Function utilFunction = new Function();

        private void clear()
        {
            this.txtNumeroExpediente.Text = "";
            this.txtQuejoso.Text = "";
            this.ddlEstatus.SelectedValue = "0";
            this.ddlVisitador.SelectedValue = "0";
            txtNumeroExpediente.Focus();
        }

        private void selectExpediente(int Tipo)
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTExpediente.Numero = this.txtNumeroExpediente.Text.Trim();
                oENTExpediente.Ciudadano = this.txtQuejoso.Text.Trim();
                oENTExpediente.EstatusId = Int32.Parse(this.ddlEstatus.SelectedValue);
                oENTExpediente.FuncionarioId = Int32.Parse(this.ddlVisitador.SelectedValue);

                // Transacción 
                oENTResponse = oBPExpediente.searchExpediente(oENTExpediente);

                // Validacion de error en consulta
                if (oENTResponse.GeneratesException)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    return;
                }

                // Validación mendaje de base de datos
                if (oENTResponse.sMessage != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    this.gvApps.DataSource = null;
                    this.gvApps.DataBind();
                    return;
                }


                // Llenado de controles

                if (Tipo == 0)
                {
                    this.gvApps.DataSource = oENTResponse.dsResponse.Tables[1];
                    this.gvApps.DataBind();
                }
                else
                {
                    this.gvApps.DataSource = oENTResponse.dsResponse.Tables[2];
                    this.gvApps.DataBind();
                    clear();
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
            }

        }

        private void selectEstatusVisitaduria()
        {
            BPEstatus oBPEstatus = new BPEstatus();

            oBPEstatus.selectEstatusVisitaduria();

            if (oBPEstatus.ErrorId == 0)
            {
                if (oBPEstatus.EstatusEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    ddlEstatus.DataSource = oBPEstatus.EstatusEntity.ResultData;
                    ddlEstatus.DataTextField = "Nombre";
                    ddlEstatus.DataValueField = "EstatusId";
                    ddlEstatus.DataBind();
                }
            }
            else
            {
                ddlEstatus.DataSource = null;
                ddlEstatus.DataTextField = "Nombre";
                ddlEstatus.DataValueField = "EstatusId";
                ddlEstatus.DataBind();
            }
        }

        private void selectVisitador()
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();

            // transacción
            try
            {
                oENTExpediente.ExpedienteId = 0; //Porque no queremos hacer ninguna excepcion de funcionario, muestra todos
                oBPExpediente.SelectFuncionario_Asignar(oENTExpediente);

                if (oBPExpediente.ErrorId == 0)
                {
                    if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlVisitador.DataSource = oENTExpediente.ResultData;
                        ddlVisitador.DataTextField = "NombreFuncionario";
                        ddlVisitador.DataValueField = "FuncionarioId";
                        ddlVisitador.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);

            }
        }

        // Eventos de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) { return; }

            try
            {
                selectEstatusVisitaduria();
                selectVisitador();
                selectExpediente(1);
            }
            catch (Exception ex)
            { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true); }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            selectExpediente(1);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rolId = 0;
            string ExpedienteId = String.Empty;
            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];

            ExpedienteId = e.CommandArgument.ToString();

            rolId = oENTSession.idRol;

            switch (e.CommandName.ToString())
            {
                case "Editar":

                    if (rolId == 9)
                    {
                        Response.Redirect("~/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?expId=" + ExpedienteId);
                    }
                    else
                    {
                        Response.Redirect("~/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?expId=" + ExpedienteId);
                    }

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
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

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