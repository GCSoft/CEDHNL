/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    VisBusquedaExpedientes
' Autor:		Ruben.Cobos
' Fecha:		04-Agosto-2014
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
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
	public partial class VisBusquedaExpedientes : BPPage
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

		// Variables publicas
		String dtBeginDate;
		String dtEndDate;


		// Rutinas del programador

		void RecoveryForm(){
			ENTSession oENTSession = new ENTSession();
			ENTVisitaduria oENTVisitaduria;

            try
            {

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones
				if (oENTSession.Entity == null) { return; }
				if (oENTSession.Entity.GetType().Name != "ENTVisitaduria") { return; }

                // Obtener Formulario
				oENTVisitaduria = (ENTVisitaduria)oENTSession.Entity;

				// Vaciar formulario
				this.txtNumeroExpediente.Text = oENTVisitaduria.Numero.ToString();
				this.txtCiudadano.Text = oENTVisitaduria.Nombre;
				this.ddlEstatus.SelectedValue = oENTVisitaduria.EstatusId.ToString();
				this.ddlFuncionario.SelectedValue = oENTVisitaduria.FuncionarioId.ToString();
				this.wucBeginDate.SetDateTime = DateTime.Parse(oENTVisitaduria.FechaDesde);
				this.wucEndDate.SetDateTime = DateTime.Parse(oENTVisitaduria.FechaHasta);

				dtBeginDate = oENTVisitaduria.FechaDesde.ToString();
				dtEndDate = oENTVisitaduria.FechaHasta.ToString();
				
				// Liberar el formulario en la sesión
				oENTSession.Entity = null;
				this.Session["oENTSession"] = oENTSession;

				// Realcular
				SelectExpediente(true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('No fue posible recuperar el formulario: " + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SaveForm(){
			ENTSession oENTSession = new ENTSession();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();

            try
            {

                // Formulario
				oENTVisitaduria.Numero = this.txtNumeroExpediente.Text.Trim();
				oENTVisitaduria.Nombre = this.txtCiudadano.Text.Trim();
				oENTVisitaduria.EstatusId = Int32.Parse(this.ddlEstatus.SelectedValue);
				oENTVisitaduria.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				oENTVisitaduria.FechaDesde = this.wucBeginDate.BeginDate;
				oENTVisitaduria.FechaHasta = this.wucEndDate.EndDate;

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

                // Guardar el formulario en la sesión
				oENTSession.Entity = oENTVisitaduria;
				this.Session["oENTSession"] = oENTSession;

            }catch (Exception ex){
                throw (ex);
            }
		}

		void SelectEstatus(){
			BPEstatus oBPEstatus = new BPEstatus();

			// Configuración de los controles
			this.ddlEstatus.DataTextField = "Nombre";
			this.ddlEstatus.DataValueField = "EstatusId";

			// Transacción
			oBPEstatus.selectEstatusVisitaduria();

			// Validaciones
			if (oBPEstatus.ErrorId != 0) { throw (new Exception(oBPEstatus.ErrorDescription)); }

			// Llenado
			this.ddlEstatus.DataSource = oBPEstatus.EstatusEntity.ResultData;
			this.ddlEstatus.DataBind();

			// Item Extra
			this.ddlEstatus.Items.Insert(0, new ListItem("[Todos]", "0"));
		}

		void SelectFuncionario(){
			BPFuncionario oBPFuncionario = new BPFuncionario();
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = 0;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = 0;
				oENTFuncionario.idRol = 8;			// Visitaduría - Visitador
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
				this.ddlFuncionario.DataTextField = "sFullName";
				this.ddlFuncionario.DataValueField = "FuncionarioId";
				this.ddlFuncionario.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlFuncionario.DataBind();

				// Opción todos
				this.ddlFuncionario.Items.Insert(0, new ListItem("[Todos]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectExpediente( Boolean Recovery){
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.Numero = this.txtNumeroExpediente.Text.Trim();
				oENTVisitaduria.Nombre = this.txtCiudadano.Text.Trim();
				oENTVisitaduria.EstatusId = Int32.Parse(this.ddlEstatus.SelectedValue);
				oENTVisitaduria.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				oENTVisitaduria.FechaDesde = (Recovery ? dtBeginDate : this.wucBeginDate.BeginDate);
				oENTVisitaduria.FechaHasta = (Recovery ? dtEndDate : this.wucEndDate.EndDate);

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpediente_Filtro(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.gvExpediente.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvExpediente.DataBind();


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
				SelectEstatus();
				SelectFuncionario();

				// Estado inicial del formulario
				this.gvExpediente.DataSource = null;
				this.gvExpediente.DataBind();

				DateTime dtDesde = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
				DateTime dtHasta = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
				this.wucBeginDate.SetDate = dtDesde.ToString();
				this.wucEndDate.SetDate = dtHasta.ToString();

				// Recuperar el formulario
				RecoveryForm();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNumeroExpediente.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNumeroExpediente.ClientID + "'); }", true);
            }
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
			{

				// Buscar Expedientees
				SelectExpediente(false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNumeroExpediente.ClientID + "'); }", true);
			}
		}

        protected void gvExpediente_RowCommand(object sender, GridViewCommandEventArgs e){
			String ExpedienteId = "";
			String strCommand = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener ExpedienteId
				ExpedienteId = e.CommandArgument.ToString();

				// Guardar formulario
				SaveForm();

				// Canalizar la página
				switch (strCommand){
					case "Editar":
						this.Response.Redirect("VisDetalleExpediente.aspx?key=" + ExpedienteId + "|2", false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNumeroExpediente.ClientID + "'); }", true);
			}
        }

        protected void gvExpediente_RowDataBound(object sender, GridViewRowEventArgs e){
            ImageButton imgEdit = null;

            String ExpedienteNumero = "";
            String sImagesAttributes = "";
            String sTootlTip = "";

            try
            {

                // Validación de que sea fila
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                // Datakeys
				ExpedienteNumero = this.gvExpediente.DataKeys[e.Row.RowIndex]["ExpedienteNumero"].ToString();

                // Tooltip Edición
                sTootlTip = "Editar Expediente [" + ExpedienteNumero + "]";
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

        protected void gvExpediente_Sorting(object sender, GridViewSortEventArgs e){
            try
			{

				gcCommon.SortGridView(ref this.gvExpediente, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNumeroExpediente.ClientID + "'); }", true);
            }
        }

	}
}