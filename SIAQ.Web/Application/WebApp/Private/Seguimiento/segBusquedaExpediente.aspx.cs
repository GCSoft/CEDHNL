/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segBusquedaExpediente
' Autor:	Ruben.Cobos
' Fecha:	02-Junio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segBusquedaExpediente : BPPage
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		private void SelectDefensor(){
			BPFuncionario oBPFuncionario = new BPFuncionario();
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = 0;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = 0;
				oENTFuncionario.idRol = 11;			// Seguimiento - Defensor
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

				// Llenado de control
				this.ddlDefensor.DataTextField = "sFullName";
				this.ddlDefensor.DataValueField = "FuncionarioId";
				this.ddlDefensor.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlDefensor.DataBind();

				// Opción todos
				this.ddlDefensor.Items.Insert(0, new ListItem("[Todos]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void SelectRecomendacionesSeguimientos(){

			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Estado inicial del grid
			this.gvExpediente.DataSource = null;
			this.gvExpediente.DataBind();

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.Numero = this.txtExpediente.Text.Trim();
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.Quejoso = this.txtQuejoso.Text.Trim();
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.FuncionarioId = Int32.Parse(this.ddlDefensor.SelectedItem.Value);

			// Transacción
			BPSeguimientoRecomendacion.SelectRecomendacionesSeguimientos_Filtro();

			// Validaciones
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

			// Listado de recomendaciones
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
			{

				this.gvExpediente.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData;
				this.gvExpediente.DataBind();
			}else {

				// Sin resultados
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No se encontraron expedientes', 'Warning', false);", true);
			}

		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
            try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }

				// Llenado de controles
				SelectDefensor();

                // Estado inicial
				this.gvExpediente.DataSource = null;
				this.gvExpediente.DataBind();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
            }
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
            {

                // Obtener Expedientes
				SelectRecomendacionesSeguimientos();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
            }
		}

		protected void gvExpediente_RowCommand(object sender, GridViewCommandEventArgs e){
			String ExpedienteId;

			String strCommand = "";
			Int32 intRow = 0;

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
						this.Response.Redirect("segDetalleExpediente.aspx?key=" + ExpedienteId + "|2", false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
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
				sNumero = gvExpediente.DataKeys[e.Row.RowIndex]["Numero"].ToString();

				// Tooltip Editar Expediente
				sToolTip = "Detalle de expediente [" + sNumero + "]";
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
			DataTable TableAutoridad = null;
			DataView ViewAutoridad = null;

			try
			{
				//Obtener DataTable y View del GridView
				TableAutoridad = utilFunction.ParseGridViewToDataTable(gvExpediente, false);
				ViewAutoridad = new DataView(TableAutoridad);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				ViewAutoridad.Sort = hddSort.Value;

				//Vaciar datos
				this.gvExpediente.DataSource = ViewAutoridad;
				this.gvExpediente.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtExpediente.ClientID + "');", true);
			}
		}

	}
}