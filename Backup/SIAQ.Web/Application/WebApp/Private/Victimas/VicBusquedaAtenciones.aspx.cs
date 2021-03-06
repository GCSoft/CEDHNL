﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicBusquedaAtenciones
' Autor:	Ruben.Cobos
' Fecha:	02-Junio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCUtility.Function;
using GCUtility.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class VicBusquedaAtenciones : BPPage
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();

		// Variables publicas
		String dtBeginDate;
		String dtEndDate;


		// Rutinas del programador

		private void SelectAtencion(Boolean Recovery){
			BPAtencion oBPAtencion = new BPAtencion();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTAtencion.Numero = this.txtAtencionNumero.Text.Trim();
				oENTAtencion.Quejoso = this.txtQuejoso.Text.Trim();
				oENTAtencion.FuncionarioId = Int32.Parse(this.ddlDoctor.SelectedItem.Value);
				oENTAtencion.FechaDesde = (Recovery ? dtBeginDate : this.wucBeginDate.BeginDate);
				oENTAtencion.FechaHasta = (Recovery ? dtEndDate : this.wucEndDate.EndDate);

				// Transacción
				oENTResponse = oBPAtencion.SelectAtencion_Filtro(oENTAtencion);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.gvAtencion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvAtencion.DataBind();


			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectDoctor(){
			BPFuncionario oBPFuncionario = new BPFuncionario();
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = 0;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = 0;
				oENTFuncionario.idRol = 14;			// Atención a Víctimas - Doctor
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlDoctor.DataTextField = "sFullName";
				this.ddlDoctor.DataValueField = "FuncionarioId";
				this.ddlDoctor.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlDoctor.DataBind();

				// Opción todos
				this.ddlDoctor.Items.Insert(0, new ListItem("[Todos]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Rutinas de recuperación del estado del formulario

		void RecoveryForm(){
			ENTSession oENTSession = new ENTSession();
			ENTAtencion oENTAtencion;

            try
            {

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones
				if (oENTSession.Entity == null) { return; }
				if (oENTSession.Entity.GetType().Name != "ENTAtencion") { return; }

                // Obtener Formulario
				oENTAtencion = (ENTAtencion)oENTSession.Entity;

				// Vaciar formulario
				this.txtAtencionNumero.Text = oENTAtencion.Numero;
				this.txtQuejoso.Text = oENTAtencion.Quejoso;
				this.ddlDoctor.SelectedValue = oENTAtencion.FuncionarioId.ToString();
				this.wucBeginDate.SetDateTime = Convert.ToDateTime( oENTAtencion.FechaDesde);
				this.wucEndDate.SetDateTime = Convert.ToDateTime(oENTAtencion.FechaHasta);

				dtBeginDate = oENTAtencion.FechaDesde.ToString();
				dtEndDate = oENTAtencion.FechaHasta.ToString();
				
				// Liberar el formulario en la sesión
				oENTSession.Entity = null;
				this.Session["oENTSession"] = oENTSession;

				// Realcular
				SelectAtencion(true);

            }catch (Exception ex){
				throw (new Exception("No fue posible recuperar el formulario: " + ex.Message));
            }
		}

		void SaveForm(){
			ENTSession oENTSession = new ENTSession();
			ENTAtencion oENTAtencion = new ENTAtencion();

            try
            {

                // Formulario
				oENTAtencion.Numero = this.txtAtencionNumero.Text.Trim();
				oENTAtencion.Quejoso = this.txtQuejoso.Text.Trim();
				oENTAtencion.FuncionarioId = Int32.Parse(this.ddlDoctor.SelectedItem.Value);
				oENTAtencion.FechaDesde = this.wucBeginDate.BeginDate;
				oENTAtencion.FechaHasta = this.wucEndDate.EndDate;

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

                // Guardar el formulario en la sesión
				oENTSession.Entity = oENTAtencion;
				this.Session["oENTSession"] = oENTSession;

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
				SelectDoctor();

                // Estado inicial
				this.gvAtencion.DataSource = null;
				this.gvAtencion.DataBind();

				DateTime dtDesde = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
				DateTime dtHasta = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
				this.wucBeginDate.SetDate = dtDesde.ToString();
				this.wucEndDate.SetDate = dtHasta.ToString();

				// Recuperar el formulario
				RecoveryForm();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtAtencionNumero.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtAtencionNumero.ClientID + "'); }", true);
            }
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
			{

				// Obtener Atenciones
				SelectAtencion(false);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtAtencionNumero.ClientID + "');", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtAtencionNumero.ClientID + "'); }", true);
			}
		}

		protected void gvAtencion_RowCommand(object sender, GridViewCommandEventArgs e){
			String AtencionId;
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
				AtencionId = this.gvAtencion.DataKeys[intRow]["AtencionId"].ToString();

				// Guardar formulario
				SaveForm();

				// Acción
				switch (strCommand){
					case "Editar":

						// Llave encriptada
						sKey = AtencionId + "|1";
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("VicDetalleAtencion.aspx?key=" + sKey, false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtAtencionNumero.ClientID + "'); }", true);
			}
		}

		protected void gvAtencion_RowDataBound(object sender, GridViewRowEventArgs e){
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
				sNumero = gvAtencion.DataKeys[e.Row.RowIndex]["AtencionNumeroFolio"].ToString();

				// Tooltip Editar Atención
				sToolTip = "Detalle de atención [" + sNumero + "]";
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

		protected void gvAtencion_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvAtencion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtAtencionNumero.ClientID + "'); }", true);
			}
		}

    }
}