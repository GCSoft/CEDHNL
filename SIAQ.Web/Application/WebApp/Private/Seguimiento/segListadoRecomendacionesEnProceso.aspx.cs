/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    segListadoRecomendacionesEnProceso
' Autor:		Ruben.Cobos
' Fecha:		12-Septiembre-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segListadoRecomendacionesEnProceso : BPPage
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void SelectRecomendacion(){
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			ENTSession oSession = (ENTSession)Session["oENTSession"];

			try
			{

				// Formulario
				oENTSeguimiento.UsuarioId = oSession.idUsuario;
				oENTSeguimiento.Nivel = 2;

				// Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacion(oENTSeguimiento);

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


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
			{

				// Validaciones
				if (Page.IsPostBack) { return; }

				// Obtener Recomendaciones
				SelectRecomendacion();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
			}
		}

		protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e){
			try
            {

                // Recargar los Recomendaciones
				SelectRecomendacion();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
            }
		}

		protected void gvRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e){
			String RecomendacionId;
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
				RecomendacionId = this.gvRecomendacion.DataKeys[intRow]["RecomendacionId"].ToString();

				// Acción
				switch (strCommand){
					case "Editar":

						// Llave encriptada
						sKey = RecomendacionId + "|3";
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("segDetalleRecomendacion.aspx?key=" + sKey, false);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
			}
		}

		protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
			String RecomendacionNumero = "";
			String NombreAutoridad = "";
			String sImagesAttributes = "";
			String sToolTip = "";

			ImageButton imgEdit = null;

			try
			{

				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

				// DataKeys
				RecomendacionNumero = gvRecomendacion.DataKeys[e.Row.RowIndex]["RecomendacionNumero"].ToString();
				NombreAutoridad = gvRecomendacion.DataKeys[e.Row.RowIndex]["NombreAutoridad"].ToString();

				// Tooltip Editar Recomendacion
				sToolTip = "Detalle de Recomendacion [" + (RecomendacionNumero == "" ? NombreAutoridad : RecomendacionNumero) + "]";
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

		protected void gvRecomendacion_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvRecomendacion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); ", true);
			}
		}

	}
}