/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	opeAgregarAutoridaSenalada
' Autor:	Ruben.Cobos
' Fecha:	27-Octubre-2013
'
' Modificación:
'           Se reconstruyó la pantalla reutilizando los métodos existentes
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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segListadoExpedienteAprobacion : BPPage
	{
		

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		private void SelectRecomendacionesSeguimientos(){

			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();
			ENTSession oSession = (ENTSession)Session["oENTSession"];

			// Estado inicial del grid
			this.gvExpediente.DataSource = null;
			this.gvExpediente.DataBind();

			// Transacción
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.UsuarioId = oSession.idUsuario;
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.Aprobar = 1;
			BPSeguimientoRecomendacion.SelectRecomendacionesSeguimientos();

			// Validaciones
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

			// Listado de recomendaciones
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count > 0){

			    this.gvExpediente.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData;
			    this.gvExpediente.DataBind();
			}

		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
            try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }

                // Obtener Expedientes
				SelectRecomendacionesSeguimientos();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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
						this.Response.Redirect("segDetalleExpediente.aspx?key=" + ExpedienteId + "|3", false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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
			try
			{

				gcCommon.SortGridView(ref this.gvExpediente, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


	}
}