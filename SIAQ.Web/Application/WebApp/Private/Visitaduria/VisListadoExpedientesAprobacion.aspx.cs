/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    VisListadoExpedientesAprobacion
' Autor:		Ruben.Cobos
' Fecha:		04-Agosto-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCUtility.Function;
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
	public partial class VisListadoExpedientesAprobacion : BPPage
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void SelectArea() {
			this.ddlArea.Items.Insert(0, new ListItem("Coordinación Penitenciaria", "10"));
			this.ddlArea.Items.Insert(0, new ListItem("Tercera Visitaduría", "6"));
			this.ddlArea.Items.Insert(0, new ListItem("Segunda Visitaduría", "5"));
			this.ddlArea.Items.Insert(0, new ListItem("Primera Visitaduría", "4"));
			this.ddlArea.Items.Insert(0, new ListItem("[Todas]", "0"));
		}

		void SelectExpediente(){
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			ENTSession oSession = (ENTSession)Session["oENTSession"];

			try
			{

				// Formulario
				oENTVisitaduria.AreaId = Int32.Parse(this.ddlArea.SelectedItem.Value);
				oENTVisitaduria.UsuarioId = oSession.idUsuario;
				oENTVisitaduria.Nivel = 1;

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpediente(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.gvExpediente.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvExpediente.DataBind();

				// Si es Director Inhabilitar panel de consulta de Área
				if ( oSession.idRol == 9) { 
					this.pnlFormulario.Visible = false;
					this.hddAreaVisible.Value = "0";
				}

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
			{

				// Validaciones
				if (Page.IsPostBack) { return; }

				// Llenado de controles
				SelectArea();

				// Obtener Expedientes
				SelectExpediente();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), (this.hddAreaVisible.Value == "0" ? "" : "focusControl('" + this.ddlArea.ClientID + "'); "), true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.hddAreaVisible.Value == "0" ? "" : "focusControl('" + this.ddlArea.ClientID + "'); "), true);
			}
		}

		protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e){
			try
            {

                // Recargar los expedientes
				SelectExpediente();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlArea.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.hddAreaVisible.Value == "0" ? "" : "focusControl('" + this.ddlArea.ClientID + "'); "), true);
            }
		}

		protected void gvExpediente_RowCommand(object sender, GridViewCommandEventArgs e){
			String ExpedienteId;
			String strCommand = "";
			Int32 intRow = 0;

			String sKey = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				ExpedienteId = this.gvExpediente.DataKeys[intRow]["ExpedienteId"].ToString();

				// Acción
				switch (strCommand){
					case "Editar":

						// Llave encriptada
						sKey = ExpedienteId + "|1";
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("VisDetalleExpedienteCierre.aspx?key=" + sKey, false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.hddAreaVisible.Value == "0" ? "" : "focusControl('" + this.ddlArea.ClientID + "'); "), true);
			}
		}

		protected void gvExpediente_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;

			String sNumero = "";
			String sImagesAttributes = "";
			String sToolTip = "";

			try
			{

				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

				// DataKeys
				sNumero = gvExpediente.DataKeys[e.Row.RowIndex]["ExpedienteNumero"].ToString();

				// Tooltip Editar Expediente
				sToolTip = "Detalle de Expediente [" + sNumero + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "curosr:hand;");

				// Atributos Over
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvExpediente_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvExpediente, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.hddAreaVisible.Value == "0" ? "" : "focusControl('" + this.ddlArea.ClientID + "'); "), true);
			}
		}

	}
}