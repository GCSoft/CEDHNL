/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    QueBusquedaSolicitudes
' Autor:		Ruben.Cobos
' Fecha:		17-Julio-2014
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
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueBusquedaSolicitudes : BPPage
	{
		
		// Utilerías
        Function utilFunction = new Function();

		// Variables publicas
		String dtBeginDate;
		String dtEndDate;


		// Rutinas del programador

		void RecoveryForm(){
			ENTSession oENTSession = new ENTSession();
			BPSolicitud oBPSolicitud;

            try
            {

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones
				if (oENTSession.Entity == null) { return; }
				if (oENTSession.Entity.GetType().Name != "BPSolicitud") { return; }

                // Obtener Formulario
				oBPSolicitud = (BPSolicitud)oENTSession.Entity;

				// Vaciar formulario
				this.txtNumeroSolicitud.Text = oBPSolicitud.SolicitudEntity.Numero.ToString();
				this.txtCiudadano.Text = oBPSolicitud.SolicitudEntity.Nombre;
				this.ddlFormaContacto.SelectedValue = oBPSolicitud.SolicitudEntity.FormaContactoId.ToString();
				this.ddlFuncionario.SelectedValue = oBPSolicitud.SolicitudEntity.FuncionarioId.ToString();
				this.wucBeginDate.SetDateTime = oBPSolicitud.SolicitudEntity.FechaDesde;
				this.wucEndDate.SetDateTime = oBPSolicitud.SolicitudEntity.FechaHasta;

				dtBeginDate = oBPSolicitud.SolicitudEntity.FechaDesde.ToString();
				dtEndDate = oBPSolicitud.SolicitudEntity.FechaHasta.ToString();
				
				// Liberar el formulario en la sesión
				oENTSession.Entity = null;
				this.Session["oENTSession"] = oENTSession;

				// Realcular
				SelectSolicitud(true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No fue posible recuperar el formulario: " + utilFunction.JSClearText(ex.Message) + "', 'Warning', false);", true);
            }
		}

		void SaveForm(){
			ENTSession oENTSession = new ENTSession();
			BPSolicitud BPSolicitud = new BPSolicitud();

            try
            {

                // Formulario
				BPSolicitud.SolicitudEntity.Numero = this.txtNumeroSolicitud.Text.Trim();
				BPSolicitud.SolicitudEntity.Nombre = this.txtCiudadano.Text.Trim();
				BPSolicitud.SolicitudEntity.FormaContactoId = Int32.Parse(this.ddlFormaContacto.SelectedValue);
				BPSolicitud.SolicitudEntity.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				BPSolicitud.SolicitudEntity.FechaDesde = DateTime.Parse(this.wucBeginDate.BeginDate);
				BPSolicitud.SolicitudEntity.FechaHasta = DateTime.Parse(this.wucEndDate.EndDate);

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

                // Guardar el formulario en la sesión
				oENTSession.Entity = BPSolicitud;
				this.Session["oENTSession"] = oENTSession;

            }catch (Exception ex){
                throw (ex);
            }
		}

		void SelectFormaContacto(){
			BPFormaContacto BPFormaContacto = new BPFormaContacto();

			ddlFormaContacto.DataTextField = "Nombre";
			ddlFormaContacto.DataValueField = "FormaContactoId";

			ddlFormaContacto.DataSource = BPFormaContacto.SelectFormaContacto();
			ddlFormaContacto.DataBind();
			ddlFormaContacto.Items.Insert(0, new ListItem("[Todos]", "0"));
		}

		void SelectFuncionario(){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			BPFuncionario BPFuncionario = new BPFuncionario();

			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario.SelectFuncionarioBusqueda();

			ddlFuncionario.DataValueField = "FuncionarioId";
			ddlFuncionario.DataTextField = "Nombre";

			ddlFuncionario.DataSource = BPFuncionario.FuncionarioEntity.ResultData.Tables[1];
			ddlFuncionario.DataBind();
			ddlFuncionario.Items.Insert(0, new ListItem("[Todos]", "0"));
		}

		void SelectSolicitud( Boolean Recovery){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			ENTSession oSession = (ENTSession)Session["oENTSession"];

			try
			{

				// Formulario
				oENTQueja.Numero = this.txtNumeroSolicitud.Text.Trim();
				oENTQueja.Nombre = this.txtCiudadano.Text.Trim();
				oENTQueja.FormaContactoId = Int32.Parse(this.ddlFormaContacto.SelectedValue);
				oENTQueja.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				oENTQueja.FechaDesde = (Recovery ? dtBeginDate : this.wucBeginDate.BeginDate);
				oENTQueja.FechaHasta = (Recovery ? dtEndDate : this.wucEndDate.EndDate);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Filtro(oENTQueja);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', true);", true); }

				// Llenado de control
				this.gvSolicitud.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvSolicitud.DataBind();


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
				SelectFormaContacto();
				SelectFuncionario();

				// Estado inicial del formulario
				this.gvSolicitud.DataSource = null;
				this.gvSolicitud.DataBind();

				DateTime dtDesde = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
				DateTime dtHasta = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12), 23, 59, 59);
				this.wucBeginDate.SetDate = dtDesde.ToString();
				this.wucEndDate.SetDate = dtHasta.ToString();

				// Recuperar el formulario
				RecoveryForm();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNumeroSolicitud.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNumeroSolicitud.ClientID + "'); }", true);
            }
		}

		protected void cmdBuscar_Click(object sender, EventArgs e){
			try
			{

				// Buscar solicitudes
				SelectSolicitud(false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNumeroSolicitud.ClientID + "'); }", true);
			}
		}

        protected void gvSolicitud_RowCommand(object sender, GridViewCommandEventArgs e){
			String SolicitudId = "";
			String strCommand = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener SolicitudId
				SolicitudId = e.CommandArgument.ToString();

				// Guardar formulario
				SaveForm();

				// Canalizar la página
				switch (strCommand){
					case "Editar":
						this.Response.Redirect("QueDetalleSolicitud.aspx?key=" + SolicitudId + "|2", false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNumeroSolicitud.ClientID + "'); }", true);
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
            DataTable tblData = null;
            DataView viewData = null;

            try
            {

                // Obtener DataTable y DataView del GridView
                tblData = utilFunction.ParseGridViewToDataTable(this.gvSolicitud, false);
                viewData = new DataView(tblData);

                // Determinar ordenamiento
                this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                // Ordenar vista
                viewData.Sort = this.hddSort.Value;

                // Vaciar datos
                this.gvSolicitud.DataSource = viewData;
                this.gvSolicitud.DataBind();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNumeroSolicitud.ClientID + "'); }", true);
            }
        }

	}
}