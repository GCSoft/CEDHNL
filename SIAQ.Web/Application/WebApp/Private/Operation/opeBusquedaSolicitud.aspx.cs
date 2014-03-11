﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using GCSoft.Utilities.Common;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
   public partial class opeBusquedaSolicitud : System.Web.UI.Page
   {

      // Utilerías
      Function utilFunction = new Function();
      
      string AllDefault = "[Todos]";

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Application/WebApp/Private/Operation/opeInicio.aspx");
        }

        protected void gvSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvSolicitudGridRowCommand(e);
        }

        private void gvSolicitudGridRowCommand(GridViewCommandEventArgs e)
        {
            string SolicitudId = string.Empty;

            SolicitudId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Editar":
                    Response.Redirect(ConfigurationManager.AppSettings["Application.Url.SolicitudDetalle"].ToString() + "?s=" + SolicitudId);
                    break;
            }
        }

        protected void gvSolicitud_RowDataBound(object sender, GridViewRowEventArgs e){
           ImageButton imgEdit = null;

           String sNumeroSol = "";

           String sImagesAttributes = "";
           String sTootlTip = "";

           try
           {

              // Validación de que sea fila
              if (e.Row.RowType != DataControlRowType.DataRow) { return; }

              // Obtener imagenes
              imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

              // Datakeys
              sNumeroSol = this.gvSolicitud.DataKeys[e.Row.RowIndex]["NumeroSol"].ToString();

              // Tooltip Edición
              sTootlTip = "Editar Solicitud [" + sNumeroSol + "]";
              imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
              imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
              imgEdit.Attributes.Add("style", "cursor:hand;");

              // Atributos Over
              sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

              // Puntero y Sombra en fila Over
              e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

              // Atributos Out
              sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

              // Puntero y Sombra en fila Out
              e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

           }catch (Exception ex){
              throw (ex);
           }
        }

        protected void gvSolicitud_Sorting(object sender, GridViewSortEventArgs e){
           DataTable tblSolicitud = null;
           DataView viewSolicitud = null;

           try
           {

              // Obtener DataTable y DataView del GridView
              tblSolicitud = utilFunction.ParseGridViewToDataTable(this.gvSolicitud, false);
              viewSolicitud = new DataView(tblSolicitud);

              // Determinar ordenamiento
              this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

              // Ordenar vista
              viewSolicitud.Sort = this.hddSort.Value;

              // Vaciar datos
              this.gvSolicitud.DataSource = viewSolicitud;
              this.gvSolicitud.DataBind();

           }catch (Exception ex){
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNumeroSolicitud.ClientID + "');", true);
           }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            BuscarSolicitud(txtNumeroSolicitud.Text.Trim() , txtCiudadano.Text.Trim());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        protected void BuscarSolicitud(string NumeroSolicitud, string Ciudadano)
        {
            BPSolicitud BPSolicitud = new BPSolicitud();
            if (NumeroSolicitud == "")
                NumeroSolicitud = "0";
            BPSolicitud.SolicitudEntity.Numero = Int32.Parse(NumeroSolicitud);
            BPSolicitud.SolicitudEntity.Nombre = Ciudadano;
            BPSolicitud.SolicitudEntity.FormaContactoId = Int32.Parse(ddlFormaContacto.SelectedValue);
            BPSolicitud.SolicitudEntity.FuncinarioId = Int32.Parse(ddlFuncionario.SelectedValue);

            BPSolicitud.SelectSolicitud();
                         
            if (BPSolicitud.ErrorId == 0)
            {
                if (BPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvSolicitud.DataSource = BPSolicitud.SolicitudEntity.ResultData;
                    gvSolicitud.DataBind();
                }
           
            else
            {
                gvSolicitud.DataSource = null;
                gvSolicitud.DataBind();
             }
            }
        }

        protected void PageLoad(){

            if (!Page.IsPostBack){
                SelectFuncionario();
                SelectFormaContacto();

                // Estado inicial de los controles
                this.gvSolicitud.DataSource = null;
                this.gvSolicitud.DataBind();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNumeroSolicitud.ClientID + "');", true);
            }

            txtNumeroSolicitud.Attributes.Add("onkeypress", "javascript:return NumbersValidator(event);");
        }

        protected void SelectFuncionario()
        {

            BPFuncionario BPFuncionario = new BPFuncionario();

            ddlFuncionario.DataValueField = "FuncionarioId";
            ddlFuncionario.DataTextField = "NombreApellido";
            BPFuncionario.SelectFuncionario();
            if (BPFuncionario.Funcionario.ResultData.Tables[0].Rows.Count > 0)
                ddlFuncionario.DataSource = BPFuncionario.Funcionario.ResultData;
            ddlFuncionario.DataBind();
            ddlFuncionario.Items.Insert(0, new ListItem(AllDefault, "0"));
       }

        protected void SelectFormaContacto() {

            BPFormaContacto BPFormaContacto = new BPFormaContacto();

            ddlFormaContacto.DataTextField = "Nombre";
            ddlFormaContacto.DataValueField = "FormaContactoId";

            ddlFormaContacto.DataSource = BPFormaContacto.SelectFormaContacto();
            ddlFormaContacto.DataBind();
            ddlFormaContacto.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

   }
}