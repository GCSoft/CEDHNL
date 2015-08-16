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

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeRegistroVisita : BPPage
    {

        // Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCParse gcParse = new GCParse();

		// Servicio
		[System.Web.Script.Services.ScriptMethod()]
		[System.Web.Services.WebMethod]
		public static List<string> GetCitizenList(string prefixText, int count){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();
			ENTResponse oENTResponse = new ENTResponse();

			List<String> ServiceResponse = new List<String>();
			String Item;

			// Errores conocidos:
			//		* El control toma el foco con el metodo JS Focus() sólo si es llamado con la función JS pageLoad() 
			//		* No se pudo encapsular en un WUC
			//		* Si se selecciona un nombre válido, enseguida se borra y se pone uno inválido, el control almacena el ID del nombre válido, se implemento el siguiente Script en la transacción
			//			If Not Exists ( Select 1 From Ciudadano Where CiudadanoId = @CiudadanoId And ( Nombre + ' ' + ApellidoPaterno  + ' ' +  IsNull(ApellidoMaterno, '') = @NombreTemporal ) )
			//				Begin
			//					Set @CiudadanoId = 0
			//				End

			try
			{

				// Formulario
				oENTCiudadano.Nombre = prefixText;

				// Transacción
				oENTResponse = oBPCiudadano.searchCiudadano(oENTCiudadano);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Configuración de arreglo de respuesta
				foreach (DataRow rowCiudadano in oENTResponse.dsResponse.Tables[1].Rows){
					Item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(rowCiudadano["NombreCiudadano"].ToString(), rowCiudadano["CiudadanoId"].ToString());
					ServiceResponse.Add(Item);
				}

			}catch (Exception){
				// Do Nothing
			}

			// Regresar listado de Ciudadanos
			return ServiceResponse;
		}


		// Rutinas del programador

		void Clear(){
			this.wucFixedDateTime.SetDateTime();
			this.ddlArea.SelectedIndex = 0;
			this.ddlUsuario.SelectedIndex = 0;
			this.ddlMotivo.SelectedIndex = 0;
			this.ckeObservaciones.Text = "";

			this.txtCiudadano.Text = "";
			this.hddCiudadanoId.Value = "";

			this.gvCiudadano.DataSource = null;
			this.gvCiudadano.DataBind();
		}

		void InsertVisita(){
			BPVisita BPVisita = new BPVisita();

			ENTResponse oENTResponse = new ENTResponse();
			ENTVisita oENTVisita = new ENTVisita();
			ENTSession oENTSession;

			DataTable tblCiudadano = null;
			DataRow rowCiudadano;

			try
			{

				// Obtener el DataTable del grid
				tblCiudadano = gcParse.GridViewToDataTable(this.gvCiudadano, false);

				// Validaciones
				if (this.ddlArea.SelectedValue == "0") { throw new Exception("El campo [Área] es requerido"); }
				if (this.ddlUsuario.SelectedValue == "0") { throw new Exception("El campo [Usuario] es requerido"); }
				if (this.ddlMotivo.SelectedValue == "0") { throw new Exception("El campo [Motivo] es requerido"); }
				if (tblCiudadano.Rows.Count == 0) { throw (new Exception("Es necesario seleccionar un Ciudadano")); }
				if (this.ckeObservaciones.Text.Trim() == "") { throw new Exception("El campo [Detalle de visita] es requerido"); }

				// Obtener la sesión
				oENTSession = (ENTSession)this.Session["oENTSession"];

				//Formulario
				oENTVisita.AreaId = Int32.Parse(this.ddlArea.SelectedValue);
				oENTVisita.UsuarioId = Int32.Parse(this.ddlUsuario.SelectedValue);
				oENTVisita.MotivoId = Int32.Parse(this.ddlMotivo.SelectedValue);
				oENTVisita.UsuarioIdInsert = oENTSession.idUsuario;
				oENTVisita.Observaciones = this.ckeObservaciones.Text.Trim();

				// Ciudadanoes seleccionadas
				oENTVisita.tblCiudadano = new DataTable("tblCiudadano");
				oENTVisita.tblCiudadano.Columns.Add("CiudadanoId", typeof(Int32));

				foreach(DataRow oDataRow in tblCiudadano.Rows){

					rowCiudadano = oENTVisita.tblCiudadano.NewRow();
					rowCiudadano["CiudadanoId"] = oDataRow["CiudadanoId"];
					oENTVisita.tblCiudadano.Rows.Add(rowCiudadano);
				}

				//Transacción
				oENTResponse = BPVisita.InsertVisita(oENTVisita);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }

				if (oENTResponse.sMessage != ""){
			        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true);
			        return;
			    }

				// Transacción exitosa
				Clear();

				//Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Visita registrada con éxito'); focusControl('" + this.ddlArea.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertVisitaCiudadano_Local(String CiudadanoId, String Foco){
			BPCiudadano BPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DataTable tblCiudadano = null;
			DataRow rowCiudadano = null;

			try
			{

				// Formulario
				oENTCiudadano.CiudadanoId = Int32.Parse(CiudadanoId);

				// Transacción
				oENTResponse = BPCiudadano.SelectCiudadano_ByID(oENTCiudadano);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
					return;
				}

				// Obtener el DataTable del grid
				tblCiudadano = gcParse.GridViewToDataTable(this.gvCiudadano, false);

				// Validación de que no se haya agregado el ciudadano
				if (tblCiudadano.Select("CiudadanoId='" + oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString() + "'").Length > 0) {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Ya ha seleccionado éste ciudadano'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
					return;
				}

				// Nuevo Item
				rowCiudadano = tblCiudadano.NewRow();
				rowCiudadano["CiudadanoId"] = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"];
				rowCiudadano["NombreCompleto"] = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCompleto"];
				rowCiudadano["Edad"] = oENTResponse.dsResponse.Tables[1].Rows[0]["Edad"];
				rowCiudadano["SexoNombre"] = oENTResponse.dsResponse.Tables[1].Rows[0]["SexoNombre"];
				rowCiudadano["TelefonoPrincipal"] = oENTResponse.dsResponse.Tables[1].Rows[0]["TelefonoPrincipal"];
				rowCiudadano["Domicilio"] = oENTResponse.dsResponse.Tables[1].Rows[0]["Domicilio"];
				tblCiudadano.Rows.Add(rowCiudadano);

				// Refrescar el Grid
				this.gvCiudadano.DataSource = tblCiudadano;
				this.gvCiudadano.DataBind();

				// Estado del atosuggest
				this.txtCiudadano.Text = "";
				this.hddCiudadanoId.Value = "";

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + Foco + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectArea(){
            ENTArea oENTArea = new ENTArea();
            ENTResponse oENTResponse = new ENTResponse();

            BPArea oBPArea = new BPArea();
            String sMessage = "";

            try
            {

                // Parámetros de consulta
                oENTArea.idArea = 0;
                oENTArea.sNombre = "";
                oENTArea.tiActivo = 1;
                oENTArea.tiVisitaduria = 2;
				oENTArea.tiVisita = 1;

                // Transacción
                oENTResponse = oBPArea.SelectArea(oENTArea);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Mensaje de la BD
                if (oENTResponse.sMessage != "") { sMessage = "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');"; }

                // Llenado de controles
                this.ddlArea.DataValueField = "idArea";
                this.ddlArea.DataTextField = "sNombre";

                this.ddlArea.DataSource = oENTResponse.dsResponse.Tables[1];
                this.ddlArea.DataBind();
				this.ddlArea.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

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

		void SelectMotivo(){
			BPMotivo BPMotivo = new BPMotivo();
			ddlMotivo.DataValueField = "MotivoId";
			ddlMotivo.DataTextField = "Nombre";

			ddlMotivo.DataSource = BPMotivo.SelectMotivo().Tables[1];
			ddlMotivo.DataBind();
			ddlMotivo.Items.Insert(0, new ListItem("[Seleccione]", "0"));
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String CiudadanoId = "";

			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener CiudadanoId
				CiudadanoId = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				switch (this.SenderId.Value){
					case "0": // Invocado desde [Menú]
						this.Sender.Value = "opeInicio.aspx";
						break;

					case "1": // Invocado desde [Recepción]
						this.Sender.Value = "opeInicio.aspx";
						break;

					case "2": // Invocado desde [Buscar ciudadano]
						this.Sender.Value = "opeBusquedaCiudadano.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Estado inicial
				this.gvCiudadano.DataSource = null;
				this.gvCiudadano.DataBind();

				// Llenado de controles
				SelectArea();
				SelectUsuario();
				SelectMotivo();
				if (CiudadanoId != "0") { 

					InsertVisitaCiudadano_Local(CiudadanoId, this.ddlArea.ClientID); 
				} else {

					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlArea.ClientID + "');", true);
				}
				
            }catch (Exception ex){
				this.btnGuardar.Visible = false;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
            }
		}

		protected void btnAgregarCiudadano_Click(object sender, EventArgs e){
			String CiudadanoId;

			try
			{

				// Obtener información del ciudadano del Autosuggest
				CiudadanoId = this.Request.Form[this.hddCiudadanoId.UniqueID];

				// Normalización
				if (CiudadanoId == "") { CiudadanoId = "0"; }

				// Transacción
				InsertVisitaCiudadano_Local(CiudadanoId, this.txtCiudadano.ClientID);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

        protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Transacción
				InsertVisita();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
        }

		protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
			String CiudadanoId = "";
			String strCommand = "";

			DataTable tblCiudadano = null;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener CiudadanoId
				CiudadanoId = e.CommandArgument.ToString();

				// Transacción
				switch (strCommand){

					case "Eliminar":

						// Obtener el DataTable del grid
						tblCiudadano = gcParse.GridViewToDataTable(this.gvCiudadano, true);

						// Eliminar el Item
						tblCiudadano.Rows.Remove(tblCiudadano.Select("CiudadanoId=" + CiudadanoId)[0]);

						// Refrescar el Grid
						this.gvCiudadano.DataSource = tblCiudadano;
						this.gvCiudadano.DataBind();

						// Foco
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlArea.ClientID + "'); }", true);

						break;

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlArea.ClientID + "');", true);
			}
        }

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String sCiudadanoId = "";
			String sNombreCiudadano = "";

			String sToolTip = "";
			String sImagesAttributes = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				//Obtener imagenes
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				//DataKeys
				sCiudadanoId = gvCiudadano.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();
				sNombreCiudadano = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

				//Tooltips
				sToolTip = "Eliminar de la Solicitud a [" + sNombreCiudadano + "]";
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

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

    }
}