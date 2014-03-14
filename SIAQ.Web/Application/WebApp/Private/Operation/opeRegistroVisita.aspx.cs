﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeRegistroVisita : System.Web.UI.Page
    {

      // Utilerías
      Function utilFunction = new Function();
       
        string AllDefault = "[Seleccione]";

        protected void GuardarButton_Click(object sender, EventArgs e){

           // Validaciones
           if (this.ddlArea.SelectedValue == "0"){
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Área es obligatorio ', 'Success', true); focusControl('" + this.ddlArea.ClientID + "');", true);
              return;
           }

           if (this.ddlFuncionario.SelectedValue == "0"){
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Funcionario es obligatorio ', 'Success', true); focusControl('" + this.ddlFuncionario.ClientID + "');", true);
              return;
           }

           if (this.ddlMotivo.SelectedValue == "0"){
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Motivo es obligatorio ', 'Success', true); focusControl('" + this.ddlMotivo.ClientID + "');", true);
              return;
           }

           if (DescriptionBox.Text == ""){
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo Detalle de visita es obligatorio ', 'Success', true); focusControl('" + this.DescriptionBox.ClientID + "');", true);
              return;
           }

           // Transacción
           ENTSession SessionEntity = new ENTSession();

           SessionEntity = (ENTSession)Session["oENTSession"];
           GuardarVisita(SessionEntity.idUsuario);
              
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Application/WebApp/Private/Home/AppIndex.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        protected void PageLoad()
        {
            if (!Page.IsPostBack)
            {
                
                //Consultas para los DropdownList
                SelectArea();
                SelectFuncionario();
                SelectMotivo();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlArea.ClientID + "');", true);
            }

        }

        protected void SelectArea(){
            ENTArea oENTArea = new ENTArea();
			   ENTResponse oENTResponse = new ENTResponse();

			   BPArea oBPArea = new BPArea();
            String sMessage = "tinyboxToolTipMessage_ClearOld();";

			   try{

               // Parámetros de consulta
               oENTArea.idArea = 0;
               oENTArea.sNombre = "";
               oENTArea.tiActivo = 1;
               oENTArea.tiSistema = 0;

				   // Transacción
				   oENTResponse = oBPArea.SelectArea(oENTArea);

				   // Validaciones
               if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

               // Mensaje de la BD
               if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

               // Llenado de controles
               this.ddlArea.DataValueField = "idArea";
               this.ddlArea.DataTextField = "sNombre";

               this.ddlArea.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlArea.DataBind();
               this.ddlArea.Items.Insert(0, new ListItem(AllDefault, "0"));

               // Mensaje al usuario
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

			   }catch (Exception ex){
               throw (ex);
			   }


        }

        protected void SelectFuncionario(){
            
            BPFuncionario BPFuncionario = new BPFuncionario();
                
            ddlFuncionario.DataValueField = "FuncionarioId";
            ddlFuncionario.DataTextField = "Nombre";

            ddlFuncionario.DataSource = BPFuncionario.SelectFuncionario();
            ddlFuncionario.DataBind();
            ddlFuncionario.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void GuardarVisita(int UsuarioIdInsert){
            BPVisita BPVisita = new BPVisita();

            BPVisita.ENTVisita.AreaId = Int32.Parse(ddlArea.SelectedValue);
            BPVisita.ENTVisita.MotivoId = Int32.Parse(ddlMotivo.SelectedValue);
            BPVisita.ENTVisita.FuncionarioId = Int32.Parse(ddlFuncionario.SelectedValue);
            BPVisita.ENTVisita.UsuarioIdInsert = UsuarioIdInsert;
            BPVisita.ENTVisita.Observaciones = DescriptionBox.Text;

            BPVisita.GuardarVisita();

            if (BPVisita.ErrorId == 0) {
                ResetearCampos();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Visita registrada con éxito', 'Success', true); focusControl('" + this.ddlArea.ClientID + "');", true);
            }
            else {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Problema al intentar de guardar la visita', 'Success', true); focusControl('" + this.ddlArea.ClientID + "');", true);
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