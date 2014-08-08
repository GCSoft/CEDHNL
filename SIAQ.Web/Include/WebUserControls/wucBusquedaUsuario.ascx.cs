/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucBusquedaUsuario
' Autor:	Ruben.Cobos
' Fecha:	07-Marzo-2014
'
' Descripción:
'           Web User Control de filtro de usuarios
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
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Include.WebUserControls
{
	public partial class wucBusquedaUsuario : System.Web.UI.UserControl
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();


		// Handlers
		public delegate void WUCSelectorCommandEventHandler();
		public event WUCSelectorCommandEventHandler ItemSelected;


		// Propiedades

		///<remarks>
		///   <name>wucBusquedaUsuario.Area</name>
		///   <create>06-Abril-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el Área al que pertenece el Usuaro seleccionado</summary>
		public String Area
		{
			get { return this.hddArea.Value; }
			set { this.hddArea.Value = value; }
		}

		///<remarks>
		///   <name>wucBusquedaUsuario.CanvasID</name>
		///   <create>06-Abril-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el id del Canvas del control</summary>
		public String CanvasID
		{
			get { return this.txtUsuario.ClientID; }
		}

		///<remarks>
		///   <name>wucBusquedaUsuario.UsuarioID</name>
		///   <create>06-Abril-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el id del Usuaro seleccionado</summary>
		public Int32 UsuarioID
		{
			get { return SelfInt32Parse(this.hddUsuarioID.Value); }
			set { this.hddUsuarioID.Value = value.ToString(); }
		}



		// Funciones del programador

		private Int32 SelfInt32Parse(String sItem){
			Int32 iResponse;

			try
			{

				iResponse = Int32.Parse(sItem);

			}catch (Exception){
				iResponse = 0;
			}

			return iResponse;
		}


		// Runtinas del programador

		private void SelectUsuario_ParaFuncionario(){
			BPUsuario oBPUsuario = new BPUsuario();
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			// Limpiar mensajes anteriores
			this.lblMessage.Text = "";

			try
			{

				// Formulario
				oENTUsuario.idRol = 0;
				oENTUsuario.idArea = 0;
				oENTUsuario.sEmail = "";
				oENTUsuario.sNombre = this.txtNombre.Text.Trim();
				oENTUsuario.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario_ParaFuncionario(oENTUsuario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != ""){
					this.lblMessage.Text = oENTResponse.sMessage;
					this.gvUsuario.DataSource = null;
					this.gvUsuario.DataBind();
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
					return;
				}

				// Llenado de contClientees
				this.gvUsuario.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvUsuario.DataBind();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void ShowFilter(){
			try
			{

				// Mostrar filtro
				this.pnlAction.Visible = true;

				// Estado inicial del grid
				this.gvUsuario.DataSource = null;
				this.gvUsuario.DataBind();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la pagina

		protected void Page_Load(object sender, EventArgs e){

			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }

			// Lógica de la página
			try
			{

				// Estado inicial
				this.pnlAction.Visible = false;

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void btnBuscar_Click(object sender, EventArgs e){
			try
			{

				// Buscar Usuarios
				SelectUsuario_ParaFuncionario();

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e){
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
				this.hddUsuarioID.Value = this.gvUsuario.DataKeys[intRow]["idUsuario"].ToString();
				this.hddArea.Value = this.gvUsuario.DataKeys[intRow]["sArea"].ToString();

				// Mostrar nombre
				this.txtUsuario.Text = this.gvUsuario.DataKeys[intRow]["sFullName"].ToString();

				// limpiar formulario
				this.txtNombre.Text = "";

				// Esconder control
				this.pnlAction.Visible = false;

				// Generar evento
				if (ItemSelected != null) { ItemSelected(); }

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void gvUsuario_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgSelectItem = null;
			String sImagesAttributes = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imágen
				imgSelectItem = (ImageButton)e.Row.FindControl("imgSelectItem");

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem.png';";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem_Null.png';";
				e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvUsuario_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvUsuario, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void imgBusqueda_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Mostrar el filtro
				ShowFilter();

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Ocultar filtro
				this.pnlAction.Visible = false;

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

	}
}