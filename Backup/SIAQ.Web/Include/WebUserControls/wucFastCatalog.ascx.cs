/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucFastCatalog
' Autor:	Ruben.Cobos
' Fecha:	16-Julio-2014
'
' Descripción:
'           Web User Control para agregar de forma rápida País, Estado, Municipio y Colonia
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
using System.Drawing;

namespace SIAQ.Web.Include.WebUserControls
{
	public partial class wucFastCatalog : System.Web.UI.UserControl
	{


		// Handlers
		public delegate void wucFastCatalogClickEventHandler();
		public delegate void wucFastCatalogCloseEventHandler();
		public delegate void wucFastCatalogItemCreatedEventHandler();

		public event wucFastCatalogClickEventHandler Click;
		public event wucFastCatalogCloseEventHandler Close;
		public event wucFastCatalogItemCreatedEventHandler ItemCreated;


		// Enumeraciones
		public enum FastCatalogTypes { NuevoPais, NuevoEstado, NuevoMunicipio, NuevaColonia }

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();


		// Propiedades

		///<remarks>
		///   <name>wucFastCatalog.MunicipioID</name>
		///   <create>16-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Establece el identificador único del Municipio para una transacción del control</summary>
		public Int32 MunicipioID
		{
			set { this.hddMunicipioId.Value = value.ToString(); }
		}

		///<remarks>
		///   <name>wucFastCatalog.Enabled</name>
		///   <create>16-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Habilita/Deshabilita el estado del control</summary>
		public Boolean Enabled
		{
			
			set 
			{ 

				this.imgAgregar.ImageUrl = (value ? "~/Include/Image/Buttons/FastCatalog_On.png" : "~/Include/Image/Buttons/FastCatalog_Off.png");
				this.imgAgregar.Enabled = value;

				this.pnlControl.BackColor = (value ? Color.White : Color.LightGray);

			}

		}

		///<remarks>
		///   <name>wucFastCatalog.EstadoID</name>
		///   <create>16-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Establece el identificador único del Estado para una transacción del control</summary>
		public Int32 EstadoID
		{
			set { this.hddEstadoId.Value = value.ToString(); }
		}

		///<remarks>
		///   <name>wucFastCatalog.ItemCreatedID</name>
		///   <create>16-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el ID creado con el control</summary>
		public Int32 ItemCreatedID
		{
			get { return Int32.Parse(this.hddItemCreatedID.Value); }
		}

		///<remarks>
		///   <name>wucFastCatalog.PaisID</name>
		///   <create>16-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Establece el identificador único de Pais para una transacción del control</summary>
		public Int32 PaisID
		{
			set { this.hddPaisId.Value = value.ToString(); }
		}


		// Métodos publicos

		///<remarks>
		///   <name>wucFastCatalog.SetCatalogType</name>
		///   <create>16-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Configura el control para el tipo de catálogo a controlar</summary>
		public void SetCatalogType(FastCatalogTypes FastCatalogType, Boolean EnableControl) {

			String sAction = "";
			
			// Tipo de catálogo
			switch (FastCatalogType) {

				case FastCatalogTypes.NuevoPais:
					sAction = "Nuevo Pais";
					break;

				case FastCatalogTypes.NuevoEstado:
					sAction = "Nuevo Estado";
					break;

				case FastCatalogTypes.NuevoMunicipio:
					sAction = "Nuevo Municipio";
					break;

				case FastCatalogTypes.NuevaColonia:
					sAction = "Nueva Colonia";
					break;
				
			}

			// Leyendas
			this.lblActionTitle.Text = sAction;

			// Atributos
			this.imgAgregar.Attributes.Add("onmouseover", "tooltip.show('" + sAction + "', 'Der');");
			this.imgAgregar.Attributes.Add("onmouseout", "tooltip.hide();");

			// Estado del control
			this.imgAgregar.ImageUrl = (EnableControl ? "~/Include/Image/Buttons/FastCatalog_On.png" : "~/Include/Image/Buttons/FastCatalog_Off.png");
			this.imgAgregar.Enabled = EnableControl;
			this.pnlControl.BackColor = (EnableControl ? Color.White : Color.LightGray);
			this.hddFastCatalogType.Value = sAction;

		}


		// Métodos privados

		private void ClearControl(){ 
			try
			{

				this.txtNombre.Text = "";
				this.hddItemCreatedID.Value = "0";
				this.lblMessage.Text = "";

			}catch (Exception ex) {
				throw (ex);
			}
		}

		private void InsertColonia() {
			BPColonia oBPColonia = new BPColonia();
			ENTColonia oENTColonia = new ENTColonia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTColonia.CiudadId = Int32.Parse(this.hddMunicipioId.Value);
				oENTColonia.Nombre = this.txtNombre.Text.Trim();
				oENTColonia.Descripcion = this.txtNombre.Text.Trim();
				oENTColonia.Activo = 1;

				// Transacción
				oENTResponse = oBPColonia.InsertColonia_FastCatalog(oENTColonia);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Id Generado
				this.hddItemCreatedID.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["NewIdentity"].ToString();

			}catch (Exception ex) {
				throw (ex);
			}
		}

		private void InsertEstado() {
			BPEstado oBPEstado = new BPEstado();
			ENTEstado oENTEstado = new ENTEstado();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTEstado.PaisId = Int32.Parse(this.hddPaisId.Value);
				oENTEstado.Nombre = this.txtNombre.Text.Trim();
				oENTEstado.Descripcion = this.txtNombre.Text.Trim();
				oENTEstado.Activo = 1;

				// Transacción
				oENTResponse = oBPEstado.InsertEstado_FastCatalog(oENTEstado);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Id Generado
				this.hddItemCreatedID.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["NewIdentity"].ToString();

			}catch (Exception ex) {
				throw (ex);
			}
		}

		private void InsertMunicipio() {
			BPCiudad oBPCiudad = new BPCiudad();
			ENTCiudad oENTCiudad = new ENTCiudad();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTCiudad.EstadoId = Int32.Parse(this.hddEstadoId.Value);
				oENTCiudad.Nombre = this.txtNombre.Text.Trim();
				oENTCiudad.Descripcion = this.txtNombre.Text.Trim();
				oENTCiudad.Activo = 1;

				// Transacción
				oENTResponse = oBPCiudad.InsertCiudad_FastCatalog(oENTCiudad);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Id Generado
				this.hddItemCreatedID.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["NewIdentity"].ToString();

			}catch (Exception ex) {
				throw (ex);
			}
		}

		private void InsertPais() {
			BPPais oBPPais = new BPPais();
			ENTPais oENTPais = new ENTPais();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTPais.Nombre = this.txtNombre.Text.Trim();
				oENTPais.Descripcion = this.txtNombre.Text.Trim();
				oENTPais.Activo = 1;

				// Transacción
				oENTResponse = oBPPais.InsertPais_FastCatalog(oENTPais);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Id Generado
				this.hddItemCreatedID.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["NewIdentity"].ToString();

			}catch (Exception ex) {
				throw (ex);
			}
		}


		// Eventos del control

		protected void Page_Load(object sender, EventArgs e){
			try {

				// Validaciones
				if (this.IsPostBack) { return; }
                
				// Estado inicial
				this.pnlAction.Visible = false;
                
			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void btnCrear_Click(object sender, EventArgs e){
			try
			{

				// Validaciones
				if (this.txtNombre.Text.Trim() == "") { throw (new Exception("El campo [Nombre] es obligatorio")); }

				// Determinar el tipo de Transacción
				switch (this.hddFastCatalogType.Value) { 

					case "Nuevo Pais":
						InsertPais();
						break;

					case "Nuevo Estado":
						InsertEstado();
						break;

					case "Nuevo Municipio":
						InsertMunicipio();
						break;

					case "Nueva Colonia":
						InsertColonia();
						break;

					default:
						throw(new Exception("Opción inválida"));
				}

				// Esconder control
				this.pnlAction.Visible = false;

				// Generar evento
				if (ItemCreated != null) { ItemCreated(); }

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void imgAgregar_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Liberar ToolTip
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);

				// Validaciones
				if (this.hddFastCatalogType.Value == "") { return; }

				// Generar evento
				if (Click != null) { Click(); }

				// Limpiar formulario
				ClearControl();

				// Mostrar filtro
				this.pnlAction.Visible = true;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);

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

				// Generar evento
				if (Close != null) { Close(); }

			}catch (Exception ex){
				this.lblMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

	}
}