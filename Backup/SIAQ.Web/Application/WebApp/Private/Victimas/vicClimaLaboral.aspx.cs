// Referencias
using System;
using System.Collections.Generic;
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

namespace SIAQ.Web.Application.WebApp.Private.Victimas
{
	public partial class vicClimaLaboral : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCParse gcParse = new GCParse();


		// Rutinas del programador

		void Clear(){
			this.wucFixedDateTime.SetDateTime();
			this.ddlUsuario.SelectedIndex = 0;
			this.ckeObservaciones.Text = "";

			this.gvUsuario.DataSource = null;
			this.gvUsuario.DataBind();
		}

		void InsertClimaLaboral(){
			BPAtencion BPAtencion = new BPAtencion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTSession oENTSession;

			DataTable tblUsuario = null;
			DataRow rowUsuario;

			try
			{

			    // Obtener el DataTable del grid
			    tblUsuario = gcParse.GridViewToDataTable(this.gvUsuario, false);

			    // Validaciones
			    if (tblUsuario.Rows.Count == 0) { throw (new Exception("Es necesario seleccionar por lo menos un Usuario")); }
			    if (this.ckeObservaciones.Text.Trim() == "") { throw new Exception("El campo [Observaciones] es requerido"); }

			    // Obtener la sesión
			    oENTSession = (ENTSession)this.Session["oENTSession"];

			    // Formulario
				oENTAtencion.UsuarioIdInsert = oENTSession.idUsuario;
				oENTAtencion.Grupal = Int16.Parse( ( tblUsuario.Rows.Count == 1 ? "0" : "1" ));
			    oENTAtencion.Observaciones = this.ckeObservaciones.Text.Trim();

			    // Usuarioes seleccionadas
			    oENTAtencion.tblUsuario = new DataTable("tblUsuario");
			    oENTAtencion.tblUsuario.Columns.Add("idUsuario", typeof(Int32));

			    foreach(DataRow oDataRow in tblUsuario.Rows){

			        rowUsuario = oENTAtencion.tblUsuario.NewRow();
			        rowUsuario["idUsuario"] = oDataRow["idUsuario"];
			        oENTAtencion.tblUsuario.Rows.Add(rowUsuario);
			    }

			    // Transacción
				oENTResponse = BPAtencion.InsertClimaLaboral(oENTAtencion);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			    // Transacción exitosa
			    Clear();

			    //Mensaje de usuario
			    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Clima laboral registrado con éxito'); focusControl('" + this.ddlUsuario.ClientID + "');", true);

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void InsertClimaLaboralUsuario_Local(){
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			BPUsuario oBPUsuario = new BPUsuario();

			DataTable tblUsuario = null;
			DataRow rowUsuario = null;

			try
			{

				// Validaciones
				if (this.ddlUsuario.SelectedValue == "0") { throw new Exception("Es necesario seleccionar un Usuario"); }

				// Obtener el DataTable del grid
				tblUsuario = gcParse.GridViewToDataTable(this.gvUsuario, false);

				// Validación de que no se haya agregado el Usuario
				if (tblUsuario.Select("idUsuario='" + this.ddlUsuario.SelectedItem.Value + "'").Length > 0){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Ya ha seleccionado éste Usuario'); function pageLoad(){ focusControl('" + this.ddlUsuario.ClientID + "'); }", true);
					return;
				}

				// Formulario
				oENTUsuario.idRol = 0;
				oENTUsuario.idArea = 0;
				oENTUsuario.idUsuario = Int32.Parse(this.ddlUsuario.SelectedItem.Value);
				oENTUsuario.sEmail = "";
				oENTUsuario.sNombre = "";
				oENTUsuario.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Nuevo Item
				rowUsuario = tblUsuario.NewRow();
				rowUsuario["idUsuario"] = oENTResponse.dsResponse.Tables[1].Rows[0]["idUsuario"];
				rowUsuario["sFullName"] = oENTResponse.dsResponse.Tables[1].Rows[0]["sFullName"];
				rowUsuario["sArea"] = oENTResponse.dsResponse.Tables[1].Rows[0]["sArea"];
				rowUsuario["SexoNombre"] = oENTResponse.dsResponse.Tables[1].Rows[0]["SexoNombre"];
				rowUsuario["sEmail"] = oENTResponse.dsResponse.Tables[1].Rows[0]["sEmail"];
				tblUsuario.Rows.Add(rowUsuario);

				// Refrescar el Grid
				this.gvUsuario.DataSource = tblUsuario;
				this.gvUsuario.DataBind();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlUsuario.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectUsuario(){
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			BPUsuario oBPUsuario = new BPUsuario();

			try
			{

				// Formulario
				oENTUsuario.idRol = 0;
				oENTUsuario.idArea = 0;
				oENTUsuario.sEmail = "";
				oENTUsuario.sNombre = "";
				oENTUsuario.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlUsuario.DataTextField = "sFullName";
				this.ddlUsuario.DataValueField = "idUsuario";
				this.ddlUsuario.DataSource = oENTResponse.dsResponse.Tables[3];
				this.ddlUsuario.DataBind();

				// Opción todos
				this.ddlUsuario.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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

				// Estado inicial
				this.gvUsuario.DataSource = null;
				this.gvUsuario.DataBind();

				// Llenado de controles
				SelectUsuario();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlUsuario.ClientID + "');", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlUsuario.ClientID + "');", true);
			}
		}

		protected void btnAgregarUsuario_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				InsertClimaLaboralUsuario_Local();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlUsuario.ClientID + "'); }", true);
			}
		}

        protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Transacción
				InsertClimaLaboral();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlUsuario.ClientID + "');", true);
            }
        }

		protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e){
			String idUsuario = "";
			String strCommand = "";

			DataTable tblUsuario = null;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener idUsuario
				idUsuario = e.CommandArgument.ToString();

				// Transacción
				switch (strCommand){

					case "Eliminar":

						// Obtener el DataTable del grid
						tblUsuario = gcParse.GridViewToDataTable(this.gvUsuario, true);

						// Eliminar el Item
						tblUsuario.Rows.Remove(tblUsuario.Select("idUsuario=" + idUsuario)[0]);

						// Refrescar el Grid
						this.gvUsuario.DataSource = tblUsuario;
						this.gvUsuario.DataBind();

						// Foco
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlUsuario.ClientID + "'); }", true);

						break;

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlUsuario.ClientID + "');", true);
			}
        }

		protected void gvUsuario_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String sidUsuario = "";
			String sNombreUsuario = "";

			String sToolTip = "";
			String sImagesAttributes = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				//Obtener imagenes
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				//DataKeys
				sidUsuario = gvUsuario.DataKeys[e.Row.RowIndex]["idUsuario"].ToString();
				sNombreUsuario = this.gvUsuario.DataKeys[e.Row.RowIndex]["sFullName"].ToString();

				//Tooltips
				sToolTip = "Eliminar a [" + sNombreUsuario + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				//Atributos Over
				sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				//Atributos Out
				sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvUsuario_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvUsuario, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlUsuario.ClientID + "');", true);
			}
		}

	}
}