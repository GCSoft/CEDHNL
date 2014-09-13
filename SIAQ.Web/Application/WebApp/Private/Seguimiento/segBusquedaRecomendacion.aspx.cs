/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    segBusquedaRecomendacion
' Autor:		Ruben.Cobos
' Fecha:		12-Septiembre-2014
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
	public partial class segBusquedaRecomendacion : BPPage
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();

		// Variables publicas
		String dtBeginDate;
		String dtEndDate;


		// Rutinas del programador

		void SelectEstatus(){
			BPEstatus oBPEstatus = new BPEstatus();

			// Configuración de los controles
			this.ddlEstatus.DataTextField = "Nombre";
			this.ddlEstatus.DataValueField = "EstatusId";

			// Transacción
			oBPEstatus.selectEstatusSeguimientos();

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
				oENTFuncionario.idRol = 11;		// Seguimiento - Defensor
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

		void SelectRecomendacion( Boolean Recovery){
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTSeguimiento.RecomendacionNumero = this.txtRecomendacionNumero.Text.Trim();
				oENTSeguimiento.ExpedienteNumero = this.txtExpedienteNumero.Text.Trim();
				oENTSeguimiento.NombreAutoridad = this.txtNombreAutoridad.Text.Trim();
				oENTSeguimiento.AcuerdoNoResponsabilidad = Int16.Parse(this.ddlTipo.SelectedValue);
				oENTSeguimiento.EstatusId = Int32.Parse(this.ddlEstatus.SelectedValue);
				oENTSeguimiento.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				oENTSeguimiento.FechaDesde = (Recovery ? dtBeginDate : this.wucBeginDate.BeginDate);
				oENTSeguimiento.FechaHasta = (Recovery ? dtEndDate : this.wucEndDate.EndDate);

				// Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacion_Filtro(oENTSeguimiento);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.gvRecomendacion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvRecomendacion.DataBind();


			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipo(){
			try
			{

				this.ddlTipo.Items.Insert(0, new ListItem("[Recomendaciones]", "0"));
				this.ddlTipo.Items.Insert(0, new ListItem("Acuerdos de No responsabilidad", "1"));
				this.ddlTipo.Items.Insert(0, new ListItem("Todos", "2"));


			}catch (Exception ex){
				throw (ex);
			}
		}


		// Rutinas de recuperación del estado del formulario

		void RecoveryForm(){
			ENTSession oENTSession = new ENTSession();
			ENTSeguimiento oENTSeguimiento;

            try
            {

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones
				if (oENTSession.Entity == null) { return; }
				if (oENTSession.Entity.GetType().Name != "ENTSeguimiento") { return; }

                // Obtener Formulario
				oENTSeguimiento = (ENTSeguimiento)oENTSession.Entity;

				// Vaciar formulario
				this.txtRecomendacionNumero.Text = oENTSeguimiento.RecomendacionNumero;
				this.txtExpedienteNumero.Text = oENTSeguimiento.ExpedienteNumero;
				this.txtNombreAutoridad.Text = oENTSeguimiento.NombreAutoridad;
				this.ddlTipo.SelectedValue = oENTSeguimiento.AcuerdoNoResponsabilidad.ToString();
				this.ddlEstatus.SelectedValue = oENTSeguimiento.EstatusId.ToString();
				this.ddlFuncionario.SelectedValue = oENTSeguimiento.FuncionarioId.ToString();
				this.wucBeginDate.SetDateTime = DateTime.Parse(oENTSeguimiento.FechaDesde);
				this.wucEndDate.SetDateTime = DateTime.Parse(oENTSeguimiento.FechaHasta);

				dtBeginDate = oENTSeguimiento.FechaDesde.ToString();
				dtEndDate = oENTSeguimiento.FechaHasta.ToString();
				
				// Liberar el formulario en la sesión
				oENTSession.Entity = null;
				this.Session["oENTSession"] = oENTSession;

				// Realcular
				SelectRecomendacion(true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('No fue posible recuperar el formulario: " + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SaveForm(){
			ENTSession oENTSession = new ENTSession();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();

            try
            {

                // Formulario
				oENTSeguimiento.RecomendacionNumero = this.txtRecomendacionNumero.Text.Trim();
				oENTSeguimiento.ExpedienteNumero = this.txtExpedienteNumero.Text.Trim();
				oENTSeguimiento.NombreAutoridad = this.txtNombreAutoridad.Text.Trim();
				oENTSeguimiento.AcuerdoNoResponsabilidad = Int16.Parse(this.ddlTipo.SelectedValue);
				oENTSeguimiento.EstatusId = Int32.Parse(this.ddlEstatus.SelectedValue);
				oENTSeguimiento.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				oENTSeguimiento.FechaDesde = this.wucBeginDate.BeginDate;
				oENTSeguimiento.FechaHasta = this.wucEndDate.EndDate;

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

                // Guardar el formulario en la sesión
				oENTSession.Entity = oENTSeguimiento;
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
				SelectTipo();
				SelectEstatus();
				SelectFuncionario();

				// Estado inicial del formulario
				this.gvRecomendacion.DataSource = null;
				this.gvRecomendacion.DataBind();

				DateTime dtDesde = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
				DateTime dtHasta = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
				this.wucBeginDate.SetDate = dtDesde.ToString();
				this.wucEndDate.SetDate = dtHasta.ToString();

				// Recuperar el formulario
				RecoveryForm();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtRecomendacionNumero.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtRecomendacionNumero.ClientID + "'); }", true);
            }
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
			{

				// Buscar Recomendaciones
				SelectRecomendacion(false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtRecomendacionNumero.ClientID + "'); }", true);
			}
		}

        protected void gvRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e){
			String RecomendacionId = "";
			String strCommand = "";

			String sKey = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener RecomendacionId
				RecomendacionId = e.CommandArgument.ToString();

				// Guardar formulario
				SaveForm();

				// Canalizar la página
				switch (strCommand){
					case "Editar":

						// Llave encriptada
						sKey = RecomendacionId + "|1";
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("segDetalleRecomendacion.aspx?key=" + sKey, false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtRecomendacionNumero.ClientID + "'); }", true);
			}
        }

        protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
            ImageButton imgEdit = null;

            String RecomendacionNumero = "";
            String sImagesAttributes = "";
            String sTootlTip = "";

            try
            {

                // Validación de que sea fila
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                // Datakeys
				RecomendacionNumero = this.gvRecomendacion.DataKeys[e.Row.RowIndex]["RecomendacionNumero"].ToString();

                // Tooltip Edición
                sTootlTip = "Editar Recomendacion [" + RecomendacionNumero + "]";
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

        protected void gvRecomendacion_Sorting(object sender, GridViewSortEventArgs e){
            try
			{

				gcCommon.SortGridView(ref this.gvRecomendacion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtRecomendacionNumero.ClientID + "'); }", true);
            }
        }

	}
}