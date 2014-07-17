﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using GCSoft.Utilities.Common;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeRegistroCiudadano : System.Web.UI.Page
    {

		// Utilerías
		Function utilFunction = new Function();

		
		// Funciones del programador

		Boolean ValidateForm() {
			Int16 iTemp;

			// Validaciones

			#region "Información general"
				
				if (String.IsNullOrEmpty(this.txtNombre.Text)){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
					return false;
				}
				if (String.IsNullOrEmpty(this.txtApellidoPaterno.Text)){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Apellido Paterno] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.txtApellidoPaterno.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlSexo.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Sexo] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlSexo.ClientID + "'); }", true);
					return false;
				}
				if( this.txtEdad.Text.Trim() == "" ){

					this.txtEdad.Text = "0";

				}else{

					if (Int16.TryParse(this.txtEdad.Text, out iTemp)){
						this.txtEdad.Text = iTemp.ToString();
					}else {
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Edad] solo acepta datos numéricos', 'Fail', true); function pageLoad(){ focusControl('" + this.txtEdad.ClientID + "'); }", true);
						return false;
					}

				}
				if (this.ddlNacionalidad.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nacionalidad] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlNacionalidad.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlOcupacion.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ocupación] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlOcupacion.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlEscolaridad.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Escolaridad] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlEscolaridad.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlEstadoCivil.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado Civil] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlEstadoCivil.ClientID + "'); }", true);
					return false;
				}
				if (String.IsNullOrEmpty(this.txtTelefonoPrincipal.Text)){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Teléfono Principal] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.txtTelefonoPrincipal.ClientID + "'); }", true);
					return false;
				}
				if( this.txtDependientesEconomicos.Text.Trim() == "" ){

					this.txtDependientesEconomicos.Text = "0";

				}else{

					if (Int16.TryParse(this.txtDependientesEconomicos.Text, out iTemp)){
						this.txtDependientesEconomicos.Text = iTemp.ToString();
					}else {
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Dependientes económicos] solo acepta datos numéricos', 'Fail', true); function pageLoad(){ focusControl('" + this.txtDependientesEconomicos.ClientID + "'); }", true);
						return false;
					}

				}
				if (this.ddlFormaEnterarse.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Forma de Enterarse] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFormaEnterarse.ClientID + "'); }", true);
					return false;
				}
				
			#endregion

			#region "Domicilio"

				if (this.ddlPais.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlPais.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlEstado.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlEstado.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlCiudad.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCiudad.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlColonia.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Colonia] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);
					return false;
				}
				if (String.IsNullOrEmpty(this.txtNombreCalle.Text)){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre Calle] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombreCalle.ClientID + "'); }", true);
					return false;
				}
				if( this.txtAniosResidiendo.Text.Trim() == "" ){

					this.txtAniosResidiendo.Text = "0";

				}else{

					if (Int16.TryParse(this.txtAniosResidiendo.Text, out iTemp)){
						this.txtAniosResidiendo.Text = iTemp.ToString();
					}else {
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Años residiendo en NL] solo acepta datos numéricos', 'Fail', true); function pageLoad(){ focusControl('" + this.txtAniosResidiendo.ClientID + "'); }", true);
						return false;
					}

				}
				
			#endregion

			#region "Información de origen"

				if (this.ddlPaisOrigen.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País de Origen] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlPaisOrigen.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlEstadoOrigen.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado de Origen] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlEstadoOrigen.ClientID + "'); }", true);
					return false;
				}
				if (this.ddlCiudadOrigen.SelectedValue == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad de origen] es requerido', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCiudadOrigen.ClientID + "'); }", true);
					return false;
				}

			#endregion

			// Formulario correcto
			return true;

		}


		// Rutinas del programador

		private void AgregarCiudadano(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DateTime dtFechaNacimiento;

			try
			{
				
				//Validaciones 
				if (ValidateForm() == false) { return; }

				// Obtener fecha de nacimiento del ciudadano
				dtFechaNacimiento = DateTime.Now;
				dtFechaNacimiento = dtFechaNacimiento.AddYears(Int32.Parse(this.txtEdad.Text.Trim()) * -1);

				//Asignación de parametros 
				//Info general
				oENTCiudadano.Nombre = txtNombre.Text;
				oENTCiudadano.ApellidoPaterno = txtApellidoPaterno.Text;
				oENTCiudadano.ApellidoMaterno = txtApellidoMaterno.Text;
				oENTCiudadano.SexoId = Convert.ToInt32(ddlSexo.SelectedValue);
				oENTCiudadano.FechaNacimiento = dtFechaNacimiento;
				oENTCiudadano.NacionalidadId = Convert.ToInt32(ddlNacionalidad.SelectedValue);
				oENTCiudadano.OcupacionId = Convert.ToInt32(ddlOcupacion.SelectedValue);
				oENTCiudadano.EscolaridadId = Convert.ToInt32(ddlEscolaridad.SelectedValue);
				oENTCiudadano.EstadoCivilId = Convert.ToInt32(ddlEstadoCivil.SelectedValue);
				oENTCiudadano.TelefonoPrincipal = txtTelefonoPrincipal.Text;
				oENTCiudadano.TelefonoOtro = txtOtroTelefono.Text;
				oENTCiudadano.CorreoElectronico = txtCorreoElectronico.Text;
				oENTCiudadano.DependientesEconomicos = (String.IsNullOrEmpty(txtDependientesEconomicos.Text) ? Convert.ToByte(0) : Convert.ToByte(txtDependientesEconomicos.Text) );
				oENTCiudadano.MedioComunicacionId = Convert.ToInt32(ddlFormaEnterarse.SelectedValue);

				//Domicilio
				oENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);
				oENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
				oENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
				oENTCiudadano.ColoniaId = Convert.ToInt32(ddlColonia.SelectedValue);
				oENTCiudadano.Calle = txtNombreCalle.Text;
				oENTCiudadano.NumeroExterior = txtNumExterior.Text;
				oENTCiudadano.NumeroInterior = txtNumInterior.Text;
				oENTCiudadano.AniosResidiendoNL = (String.IsNullOrEmpty(txtAniosResidiendo.Text) ? Convert.ToByte(0) : Convert.ToByte(txtAniosResidiendo.Text));

				//Info de origen
				oENTCiudadano.PaisOrigenId = Convert.ToInt32(ddlPaisOrigen.SelectedValue);
				oENTCiudadano.EstadoOrigenId = Convert.ToInt32(ddlEstadoOrigen.SelectedValue);
				oENTCiudadano.CiudadOrigenId = Convert.ToInt32(ddlCiudadOrigen.SelectedValue);

				//Transacción 
				oENTResponse = oBPCiudadano.InsertCiudadano(oENTCiudadano);

				//Validación 
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Si la pantalla fue invocada desde la pantalla de agregar ciudadanos a la solicitud (opeAgregarCiudadanosSol) regresar pasándo el CiudadanoId generado
				if (this.hddSolicitudId.Value != ""){

					Response.Redirect("opeAgregarCiudadanosSol.aspx?s=" + this.hddSolicitudId.Value + "&c=" + oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString(), false);
				}else{

					Limpiar();
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Ciudadano agregado con éxito', 'Success', false);", true);
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		private void ModificarCiudadano(int CiudadanoId){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DateTime dtFechaNacimiento;

			try
			{

				//Validaciones 
				if (ValidateForm() == false) { return; }

				// Obtener fecha de nacimiento del ciudadano
				dtFechaNacimiento = DateTime.Now;
				dtFechaNacimiento = dtFechaNacimiento.AddYears(Int32.Parse(this.txtEdad.Text.Trim()) * -1);

				//Asignación de parametros
				//Info general
				oENTCiudadano.CiudadanoId = CiudadanoId;
				oENTCiudadano.Nombre = txtNombre.Text;
				oENTCiudadano.ApellidoPaterno = txtApellidoPaterno.Text;
				oENTCiudadano.ApellidoMaterno = txtApellidoMaterno.Text;
				oENTCiudadano.SexoId = Convert.ToInt32(ddlSexo.SelectedValue);
				oENTCiudadano.FechaNacimiento = dtFechaNacimiento;
				oENTCiudadano.NacionalidadId = Convert.ToInt32(ddlNacionalidad.SelectedValue);
				oENTCiudadano.OcupacionId = Convert.ToInt32(ddlOcupacion.SelectedValue);
				oENTCiudadano.EscolaridadId = Convert.ToInt32(ddlEscolaridad.SelectedValue);
				oENTCiudadano.EstadoCivilId = Convert.ToInt32(ddlEstadoCivil.SelectedValue);
				oENTCiudadano.TelefonoPrincipal = txtTelefonoPrincipal.Text;
				oENTCiudadano.TelefonoOtro = txtOtroTelefono.Text;
				oENTCiudadano.CorreoElectronico = txtCorreoElectronico.Text;
				oENTCiudadano.DependientesEconomicos = (String.IsNullOrEmpty(txtDependientesEconomicos.Text) ? Convert.ToByte(0) : Convert.ToByte(txtDependientesEconomicos.Text));
				oENTCiudadano.MedioComunicacionId = Convert.ToInt32(ddlFormaEnterarse.SelectedValue);

				//Domicilio
				oENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);
				oENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
				oENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
				oENTCiudadano.ColoniaId = Convert.ToInt32(ddlColonia.SelectedValue);
				oENTCiudadano.Calle = txtNombreCalle.Text;
				oENTCiudadano.NumeroExterior = txtNumExterior.Text;
				oENTCiudadano.NumeroInterior = txtNumInterior.Text;
				oENTCiudadano.AniosResidiendoNL = (String.IsNullOrEmpty(txtAniosResidiendo.Text) ? Convert.ToByte(0) : Convert.ToByte(txtAniosResidiendo.Text));

				//Info de origen
				oENTCiudadano.PaisOrigenId = Convert.ToInt32(ddlPaisOrigen.SelectedValue);
				oENTCiudadano.EstadoOrigenId = Convert.ToInt32(ddlEstadoOrigen.SelectedValue);
				oENTCiudadano.CiudadOrigenId = Convert.ToInt32(ddlCiudadOrigen.SelectedValue);

				//Transacción 
				oENTResponse = oBPCiudadano.UpdateCiudadano(oENTCiudadano);

				//Validación 
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
            
			if (Page.IsPostBack) { return; }

			String ciudadanoId = null;

			// Valores por default
			this.hdnCiudadanoId.Value = String.Empty;
			this.hddSolicitudId.Value = "";

			// Determinar de donde viene la página
			if(Request.QueryString["s"] != null){

				ciudadanoId = Request.QueryString["s"].ToString();
				this.hdnCiudadanoId.Value = ciudadanoId;
			}

			if (Request.QueryString["acs"] != null){
               
				// La página viene de de la pantalla de agregar un ciudadano a una solicitud (opeAgregarCiudadanosSol)
				this.hddSolicitudId.Value = Request.QueryString["acs"].ToString();
			}
            

			// Rutina de la página
			ComboEscolaridad();
			ComboEstadoCivil();
			ComboSexo();
			ComboOcupacion();
			ComboFormaContacto();
			ComboNacionalidad();
			ComboPaises();
			ComboPaisesOrigen();

			// Configurar wucFastCatalog's
			this.wucFastCatalogPais.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoPais, true);
			this.wucFastCatalogEstado.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoEstado, false);
			this.wucFastCatalogCiudad.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoMunicipio, false);
			this.wucFastCatalogColonia.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevaColonia, false);

			this.wucFastCatalogPaisOrigen.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoPais, true);
			this.wucFastCatalogEstadoOrigen.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoEstado, false);
			this.wucFastCatalogCiudadOrigen.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoMunicipio, false);

			// Modo Edición
			if (!String.IsNullOrEmpty(ciudadanoId)) {

				ObtenerDetalleCiudadano(Convert.ToInt32(ciudadanoId));

				// Habilitar wucFastCatalog's
				this.wucFastCatalogEstado.Enabled = true;
				this.wucFastCatalogCiudad.Enabled = true;
				this.wucFastCatalogColonia.Enabled = true;

				this.wucFastCatalogEstadoOrigen.Enabled = true;
				this.wucFastCatalogCiudadOrigen.Enabled = true;
			}

			// Foco
			ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);

        }

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				if (String.IsNullOrEmpty(hdnCiudadanoId.Value)){

					AgregarCiudadano();

				}else{

					ModificarCiudadano(Convert.ToInt32(hdnCiudadanoId.Value));
					Response.Redirect("opeBusquedaCiudadano.aspx");

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			if (this.hddSolicitudId.Value != ""){

				Response.Redirect("opeAgregarCiudadanosSol.aspx?s=" + this.hddSolicitudId.Value, false);
			}else{

				Response.Redirect("opeBusquedaCiudadano.aspx");
			}
		}


		// Eventos [Domicilio] de DropDownList en cascada (ordenados por precedencia)

		protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e){
			try
			{

				// Llenado de combos en cascada
				ComboEstados();
				ComboCiudades();
				ComboColonia();

				// Habilitar/Inhabilitar el control de Estado
				this.wucFastCatalogEstado.Enabled = (this.ddlPais.SelectedIndex == 0 ? false : true);
				this.wucFastCatalogCiudad.Enabled = (this.ddlEstado.SelectedIndex == 0 ? false : true);
				this.wucFastCatalogColonia.Enabled = (this.ddlCiudad.SelectedIndex == 0 ? false : true);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstado.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e){
			try
			{

				// Llenado de combos en cascada
				ComboCiudades();
				ComboColonia();

				// Habilitar/Inhabilitar el control de Ciudad
				this.wucFastCatalogCiudad.Enabled = (this.ddlEstado.SelectedIndex == 0 ? false : true);
				this.wucFastCatalogColonia.Enabled = (this.ddlCiudad.SelectedIndex == 0 ? false : true);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudad.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e){
			try
			{

				// Llenado de combos en cascada
				ComboColonia();

				// Habilitar/Inhabilitar el control de Colonia
				this.wucFastCatalogColonia.Enabled = (this.ddlCiudad.SelectedIndex == 0 ? false : true);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		// Eventos [Información de Origen] de DropDownList en cascada (ordenados por precedencia)

		protected void ddlPaisOrigen_SelectedIndexChanged(object sender, EventArgs e){
			try
			{

				// Llenado de combos en cascada
				ComboEstadosOrigen();
				ComboCiudadesOrigen();

				// Habilitar/Inhabilitar el control de Estado
				this.wucFastCatalogEstadoOrigen.Enabled = (this.ddlPaisOrigen.SelectedIndex == 0 ? false : true);
				this.wucFastCatalogCiudadOrigen.Enabled = (this.ddlEstadoOrigen.SelectedIndex == 0 ? false : true);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstadoOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}
		
		protected void ddlEstadoOrigen_SelectedIndexChanged(object sender, EventArgs e){
			try
			{

				// Llenado de combos en cascada
				ComboCiudadesOrigen();

				// Habilitar/Inhabilitar el control de Ciudad
				this.wucFastCatalogCiudadOrigen.Enabled = (this.ddlEstadoOrigen.SelectedIndex == 0 ? false : true);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudadOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		// Eventos [Domicilio] de wucFastCatalog (ordenados por precedencia)

		protected void wucFastCatalogEstado_Click(){
			try
			{

				// Pais asociado al estado
				this.wucFastCatalogEstado.PaisID = Int32.Parse(this.ddlPais.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudad_Click(){
			try
			{

				// Estado asociado al estado
				this.wucFastCatalogCiudad.EstadoID = Int32.Parse(this.ddlEstado.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogColonia_Click(){
			try
			{

				// Ciudad asociado al estado
				this.wucFastCatalogColonia.MunicipioID = Int32.Parse(this.ddlCiudad.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		
		protected void wucFastCatalogPais_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlPais.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogEstado_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstado.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudad_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudad.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogColonia_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		protected void wucFastCatalogPais_ItemCreated(){
			String sPaisOrigenValue = "";

			try
			{

				// Obtener el valor del pais origen seleccionado
				sPaisOrigenValue = this.ddlPaisOrigen.SelectedValue;

				// Recálculo de Paises
				ComboPaises();
				ComboPaisesOrigen();

				// Limpiar combos de cascada descendentes
				this.ddlEstado.Items.Clear();
				this.ddlCiudad.Items.Clear();
				this.ddlColonia.Items.Clear();

				// Seleccionar Items
				this.ddlPais.SelectedValue = this.wucFastCatalogPais.ItemCreatedID.ToString();
				this.ddlPaisOrigen.SelectedValue = sPaisOrigenValue;

				// Habilitar/Inhabilitar controles de FastCatalog
				this.wucFastCatalogEstado.Enabled = true;
				this.wucFastCatalogCiudad.Enabled = false;
				this.wucFastCatalogColonia.Enabled = false;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstado.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogEstado_ItemCreated(){
			String sEstadoOrigenValue = "";

			try
			{

				// Obtener el valor del estado origen seleccionado
				sEstadoOrigenValue = this.ddlEstadoOrigen.SelectedValue;

				// Recálculo de Estados
				ComboEstados();
				ComboEstadosOrigen();

				// Limpiar combos de cascada descendentes
				this.ddlCiudad.Items.Clear();
				this.ddlColonia.Items.Clear();

				// Seleccionar Items
				this.ddlEstado.SelectedValue = this.wucFastCatalogEstado.ItemCreatedID.ToString();
				this.ddlEstadoOrigen.SelectedValue = sEstadoOrigenValue;

				// Habilitar/Inhabilitar controles de FastCatalog
				this.wucFastCatalogCiudad.Enabled = true;
				this.wucFastCatalogColonia.Enabled = false;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudad.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudad_ItemCreated(){
			String sCiudadOrigenValue = "";

			try
			{

				// Obtener el valor de la ciudad origen seleccionada
				sCiudadOrigenValue = this.ddlCiudadOrigen.SelectedValue;

				// Recálculo de Ciudades
				ComboCiudades();
				ComboCiudadesOrigen();

				// Limpiar combos de cascada descendentes
				this.ddlColonia.Items.Clear();

				// Seleccionar Items
				this.ddlCiudad.SelectedValue = this.wucFastCatalogCiudad.ItemCreatedID.ToString();
				this.ddlCiudadOrigen.SelectedValue = sCiudadOrigenValue;

				// Habilitar/Inhabilitar controles de FastCatalog
				this.wucFastCatalogColonia.Enabled = true;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogColonia_ItemCreated(){
			try
			{

				// Recálculo de Colonias
				ComboColonia();

				// Seleccionar el nuevo Item Creado
				this.ddlColonia.SelectedValue = this.wucFastCatalogColonia.ItemCreatedID.ToString();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		// Eventos [Domicilio] de wucFastCatalog (ordenados por precedencia)

		protected void wucFastCatalogEstadoOrigen_Click(){
			try
			{

				// Pais Origen asociado al estado
				this.wucFastCatalogEstadoOrigen.PaisID = Int32.Parse(this.ddlPaisOrigen.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudadOrigen_Click(){
			try
			{

				// Estado Origen asociado al estado
				this.wucFastCatalogCiudadOrigen.EstadoID = Int32.Parse(this.ddlEstadoOrigen.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		protected void wucFastCatalogPaisOrigen_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlPaisOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogEstadoOrigen_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstadoOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudadOrigen_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudadOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		protected void wucFastCatalogPaisOrigen_ItemCreated(){
			String sPaisValue = "";

			try
			{

				// Obtener el valor del pais seleccionado
				sPaisValue = this.ddlPais.SelectedValue;

				// Recálculo de Paises
				ComboPaises();
				ComboPaisesOrigen();

				// Limpiar combos de cascada descendentes
				this.ddlEstadoOrigen.Items.Clear();
				this.ddlCiudadOrigen.Items.Clear();

				// Seleccionar Items
				this.ddlPaisOrigen.SelectedValue = this.wucFastCatalogPais.ItemCreatedID.ToString();
				this.ddlPais.SelectedValue = sPaisValue;

				// Habilitar/Inhabilitar controles de FastCatalog
				this.wucFastCatalogEstadoOrigen.Enabled = true;
				this.wucFastCatalogCiudadOrigen.Enabled = false;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstadoOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogEstadoOrigen_ItemCreated(){
			String sEstadoValue = "";

			try
			{

				// Obtener el valor del estado seleccionado
				sEstadoValue = this.ddlEstado.SelectedValue;

				// Recálculo de Estados
				ComboEstados();
				ComboEstadosOrigen();

				// Limpiar combos de cascada descendentes
				this.ddlCiudadOrigen.Items.Clear();

				// Seleccionar Items
				this.ddlEstadoOrigen.SelectedValue = this.wucFastCatalogEstadoOrigen.ItemCreatedID.ToString();
				this.ddlEstado.SelectedValue = sEstadoValue;

				// Habilitar/Inhabilitar controles de FastCatalog
				this.wucFastCatalogCiudadOrigen.Enabled = true;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudadOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudadOrigen_ItemCreated(){
			String sCiudadValue = "";

			try
			{

				// Obtener el valor de la ciudad seleccionado
				sCiudadValue = this.ddlCiudad.SelectedValue;

				// Recálculo de Ciudades
				ComboCiudades();
				ComboCiudadesOrigen();

				// Seleccionar Items
				this.ddlCiudadOrigen.SelectedValue = this.wucFastCatalogCiudadOrigen.ItemCreatedID.ToString();
				this.ddlCiudad.SelectedValue = sCiudadValue;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudadOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


        #region Funciones

        private void ComboEscolaridad()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboEscolaridad();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEscolaridad.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEscolaridad.DataTextField = "Nombre";
                        ddlEscolaridad.DataValueField = "EscolaridadId";
                        ddlEscolaridad.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboEstadoCivil()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboEstadoCivil();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEstadoCivil.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEstadoCivil.DataTextField = "Nombre";
                        ddlEstadoCivil.DataValueField = "EstadoCivilId";
                        ddlEstadoCivil.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboSexo()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboSexo();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlSexo.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlSexo.DataTextField = "Nombre";
                        ddlSexo.DataValueField = "SexoId";
                        ddlSexo.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboOcupacion()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboOcupacion();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlOcupacion.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlOcupacion.DataTextField = "Nombre";
                        ddlOcupacion.DataValueField = "OcupacionId";
                        ddlOcupacion.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboFormaContacto()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboFormaContacto();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlFormaEnterarse.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlFormaEnterarse.DataTextField = "Nombre";
                        ddlFormaEnterarse.DataValueField = "FormaContactoId";
                        ddlFormaEnterarse.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboColonia()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
                oBPCiudadano.SelectComboColonia();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlColonia.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlColonia.DataTextField = "Nombre";
                        ddlColonia.DataValueField = "ColoniaId";
                        ddlColonia.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboNacionalidad()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oENTResponse = oBPCiudadano.SelectComboNacionalidad(oENTCiudadano);
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ddlNacionalidad.DataSource = oENTResponse.dsResponse.Tables[1];
                ddlNacionalidad.DataTextField = "Nombre";
                ddlNacionalidad.DataValueField = "NacionalidadId";
                ddlNacionalidad.DataBind();

                ddlNacionalidad.Items.Insert(0, new ListItem("[Seleccione]", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                   , true);
            }
        }

        private void ComboPaises()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oENTResponse = oBPCiudadano.SelectComboPais(oENTCiudadano);
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ddlPais.DataSource = oENTResponse.dsResponse.Tables[1];
                ddlPais.DataTextField = "Nombre";
                ddlPais.DataValueField = "PaisId";
                ddlPais.DataBind();

                ddlPais.Items.Insert(0, new ListItem("[Seleccione]", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                   , true);
            }
        }

        private void ComboPaisesOrigen()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oENTResponse = oBPCiudadano.SelectComboPais(oENTCiudadano);
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ddlPaisOrigen.DataSource = oENTResponse.dsResponse.Tables[1];
                ddlPaisOrigen.DataTextField = "Nombre";
                ddlPaisOrigen.DataValueField = "PaisId";
                ddlPaisOrigen.DataBind();

                ddlPaisOrigen.Items.Insert(0, new ListItem("[Seleccione]", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                   , true);
            }
        }

        private void ComboEstados()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);
                oBPCiudadano.SelectComboEstado();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEstado.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEstado.DataTextField = "Nombre";
                        ddlEstado.DataValueField = "EstadoId";
                        ddlEstado.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboEstadosOrigen()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.PaisId = Convert.ToInt32(ddlPaisOrigen.SelectedValue);
                oBPCiudadano.SelectComboEstado();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEstadoOrigen.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEstadoOrigen.DataTextField = "Nombre";
                        ddlEstadoOrigen.DataValueField = "EstadoId";
                        ddlEstadoOrigen.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboCiudades()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
                oBPCiudadano.SelectComboCiudad();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlCiudad.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlCiudad.DataTextField = "Nombre";
                        ddlCiudad.DataValueField = "CiudadId";
                        ddlCiudad.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void ComboCiudadesOrigen()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.EstadoId = Convert.ToInt32(ddlEstadoOrigen.SelectedValue);
                oBPCiudadano.SelectComboCiudad();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlCiudadOrigen.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlCiudadOrigen.DataTextField = "Nombre";
                        ddlCiudadOrigen.DataValueField = "CiudadId";
                        ddlCiudadOrigen.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = String.Empty;
            txtApellidoPaterno.Text = String.Empty;
            txtApellidoMaterno.Text = String.Empty;
            ddlSexo.SelectedIndex = 0;
			this.txtEdad.Text = "0";
            ddlNacionalidad.SelectedIndex = 0;
            ddlOcupacion.SelectedIndex = 0;
            ddlEscolaridad.SelectedIndex = 0;
            ddlEstadoCivil.SelectedIndex = 0;
            txtTelefonoPrincipal.Text = String.Empty;
            txtOtroTelefono.Text = String.Empty;
            txtCorreoElectronico.Text = String.Empty;
            txtDependientesEconomicos.Text = String.Empty;
            ddlFormaEnterarse.SelectedIndex = 0;

            ComboPaises();
            ComboPaisesOrigen();
            ComboEstados();
            ComboEstadosOrigen();
            ComboCiudades();
            ComboCiudadesOrigen();
            ComboColonia();

            txtNombreCalle.Text = String.Empty;
            txtNumExterior.Text = String.Empty;
            txtNumInterior.Text = String.Empty;
            txtAniosResidiendo.Text = String.Empty;

            hdnCiudadanoId.Value = String.Empty;

            txtNombre.Focus();

        }

        public string GetRawQueryParameter(string parameterName)
        {
            string raw = Request.RawUrl;
            int startQueryIdx = raw.IndexOf('?');
            if (startQueryIdx < 0)
                return null;

            int nameLength = parameterName.Length + 1;
            int startIdx = raw.IndexOf(parameterName + "=", startQueryIdx);
            if (startIdx < 0)
                return null;

            startIdx += nameLength;
            int endIdx = raw.IndexOf('&', startIdx);
            if (endIdx < 0)
                endIdx = raw.Length;

            return raw.Substring(startIdx, endIdx - startIdx);
        }

        private void ObtenerDetalleCiudadano(int ciudadanoId)
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.CiudadanoId = ciudadanoId;
                oBPCiudadano.SelectDetalleCiudadano();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        txtNombre.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Nombre"].ToString();
                        txtApellidoPaterno.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["ApellidoPaterno"].ToString();
                        txtApellidoMaterno.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["ApellidoMaterno"].ToString();
                        ddlSexo.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["SexoId"].ToString();
						this.txtEdad.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Anios"].ToString();
                        ddlNacionalidad.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["NacionalidadId"].ToString();
                        ddlOcupacion.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["OcupacionId"].ToString();
                        ddlEscolaridad.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["EscolaridadId"].ToString();
                        ddlEstadoCivil.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["EstadoCivilId"].ToString();
                        txtTelefonoPrincipal.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["TelefonoPrincipal"].ToString();
                        txtOtroTelefono.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["TelefonoOtro"].ToString();
                        txtCorreoElectronico.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["CorreoElectronico"].ToString();
                        txtDependientesEconomicos.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["DependientesEconomicos"].ToString();
                        ddlFormaEnterarse.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["MedioComunicacionId"].ToString();
                        ddlPais.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["PaisId"].ToString();
                        ComboEstados();
                        ddlEstado.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["EstadoId"].ToString();
                        ComboCiudades();
                        ddlCiudad.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["CiudadId"].ToString();
                        ComboColonia();
                        ddlColonia.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["ColoniaId"].ToString();
                        txtNombreCalle.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Calle"].ToString();
                        txtNumExterior.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["NumeroExterior"].ToString();
                        txtNumInterior.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["NumeroInterior"].ToString();
                        txtAniosResidiendo.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["AniosResidiendoNL"].ToString();
                        ddlPaisOrigen.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["PaisOrigenId"].ToString();
                        ComboEstadosOrigen();
                        ddlEstadoOrigen.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["EstadoOrigenId"].ToString();
                        ComboCiudadesOrigen();
                        ddlCiudadOrigen.SelectedValue = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["CiudadOrigenId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "','Fail',true);"
                    , true);
            }
        }

        #endregion


    }
}