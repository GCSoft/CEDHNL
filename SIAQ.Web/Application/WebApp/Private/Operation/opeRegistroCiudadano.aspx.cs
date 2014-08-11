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
    public partial class opeRegistroCiudadano : BPPage
    {

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();

		// Rutinas del programador

		void AgregarCiudadano(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DateTime dtFechaNacimiento;

			try
			{
				
				//Validaciones 
				ValidateForm();

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
				oENTCiudadano.MedioComunicacionId = Convert.ToInt32(ddlMedioComunicacion.SelectedValue);

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

				// Si la pantalla fue invocada desde la pantalla de agregar ciudadanos a la solicitud (../Quejas/QueAgregarCiudadanos.aspx) regresar pasándo el CiudadanoId generado
				if (this.hddSolicitudId.Value != ""){

					Response.Redirect("../Quejas/QueAgregarCiudadanos.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value + "|" + oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString(), false);
				}else{

					Limpiar();
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Ciudadano agregado con éxito');", true);
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void ModificarCiudadano(int CiudadanoId){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DateTime dtFechaNacimiento;

			try
			{

				//Validaciones 
				ValidateForm();

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
				oENTCiudadano.MedioComunicacionId = Convert.ToInt32(ddlMedioComunicacion.SelectedValue);

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

		void SelectMedioComunicacion(){
			BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
			ENTResponse oENTResponse = new ENTResponse();
			ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();

			try
			{

				//Transacción 
				oENTResponse = oBPMedioComunicacion.searchcatMedioComunicacion(oENTMedioComunicacion);

				//Validación 
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Bind
				this.ddlMedioComunicacion.DataTextField = "Nombre";
				this.ddlMedioComunicacion.DataValueField = "MedioComunicacionId";
				this.ddlMedioComunicacion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlMedioComunicacion.DataBind();

				// Item extra
				this.ddlMedioComunicacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}

        }

		void ValidateForm() {
			Int16 iTemp;

			// Validaciones

			#region "Información general"
				
				if (String.IsNullOrEmpty(this.txtNombre.Text)){ throw(new Exception("El campo [Nombre] es requerido")); }
				if (String.IsNullOrEmpty(this.txtApellidoPaterno.Text)){ throw(new Exception("El campo [Apellido Paterno] es requerido")); }
				if (this.ddlSexo.SelectedValue == "0"){ throw(new Exception("El campo [Sexo] es requerido")); }

				if( this.txtEdad.Text.Trim() == "" ){

					this.txtEdad.Text = "0";

				}else{

					if (Int16.TryParse(this.txtEdad.Text, out iTemp)){
						this.txtEdad.Text = iTemp.ToString();
					}else {
						throw(new Exception("El campo [Edad] solo acepta datos numéricos"));
						
					}

				}

				if (this.ddlNacionalidad.SelectedValue == "0"){ throw(new Exception("El campo [Nacionalidad] es requerido")); }
				if (this.ddlOcupacion.SelectedValue == "0"){ throw(new Exception("El campo [Ocupación] es requerido")); }
				if (this.ddlEscolaridad.SelectedValue == "0"){ throw(new Exception("El campo [Escolaridad] es requerido")); }
				if (this.ddlEstadoCivil.SelectedValue == "0"){ throw(new Exception("El campo [Estado Civil] es requerido")); }
				if (String.IsNullOrEmpty(this.txtTelefonoPrincipal.Text)){ throw(new Exception("El campo [Teléfono Principal] es requerido")); }

				if( this.txtDependientesEconomicos.Text.Trim() == "" ){

					this.txtDependientesEconomicos.Text = "0";

				}else{

					if (Int16.TryParse(this.txtDependientesEconomicos.Text, out iTemp)){
						this.txtDependientesEconomicos.Text = iTemp.ToString();
					}else {
						throw(new Exception("El campo [Dependientes económicos] solo acepta datos numéricos"));
						
					}

				}

				if (this.ddlMedioComunicacion.SelectedValue == "0"){ throw(new Exception("El campo [Forma de Enterarse] es requerido")); }
				
			#endregion

			#region "Domicilio"

				if (this.ddlPais.SelectedValue == "0"){ throw(new Exception("El campo [País] es requerido")); }
				if (this.ddlEstado.SelectedValue == "0"){ throw(new Exception("El campo [Estado] es requerido")); }
				if (this.ddlCiudad.SelectedValue == "0"){ throw(new Exception("El campo [Ciudad] es requerido")); }
				if (this.ddlColonia.SelectedValue == "0"){ throw(new Exception("El campo [Colonia] es requerido")); }
				if (String.IsNullOrEmpty(this.txtNombreCalle.Text)){ throw(new Exception("El campo [Nombre Calle] es requerido")); }
				
				if( this.txtAniosResidiendo.Text.Trim() == "" ){

					this.txtAniosResidiendo.Text = "0";

				}else{

					if (Int16.TryParse(this.txtAniosResidiendo.Text, out iTemp)){
						this.txtAniosResidiendo.Text = iTemp.ToString();
					}else {
						throw(new Exception("El campo [Años residiendo en NL] solo acepta datos numéricos"));
						
					}

				}
				
			#endregion

			#region "Información de origen"

				if (this.ddlPaisOrigen.SelectedValue == "0"){ throw(new Exception("El campo [País de Origen] es requerido")); }
				if (this.ddlEstadoOrigen.SelectedValue == "0"){ throw(new Exception("El campo [Estado de Origen] es requerido")); }
				if (this.ddlCiudadOrigen.SelectedValue == "0"){ throw (new Exception("El campo [Ciudad de origen] es requerido")); }

			#endregion

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

			if (Request.QueryString["key"] != null){

				// Obtener ExpedienteId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];
			}
            

			// Rutina de la página
			ComboEscolaridad();
			ComboEstadoCivil();
			ComboSexo();
			ComboOcupacion();
			SelectMedioComunicacion();
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

				SelectCiudadanoDetalle(Convert.ToInt32(ciudadanoId));

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

					if (this.hddSolicitudId.Value != ""){

						Response.Redirect("../Quejas/QueAgregarCiudadanos.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value + "|0", false);
					}else{

						Response.Redirect("opeBusquedaCiudadano.aspx");
					}

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			if (this.hddSolicitudId.Value != ""){

				Response.Redirect("../Quejas/QueAgregarCiudadanos.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value + "|0", false);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		// Eventos [Domicilio] de wucFastCatalog (ordenados por precedencia)

		protected void wucFastCatalogEstado_Click(){
			try
			{

				// Pais asociado al estado
				this.wucFastCatalogEstado.PaisID = Int32.Parse(this.ddlPais.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudad_Click(){
			try
			{

				// Estado asociado al estado
				this.wucFastCatalogCiudad.EstadoID = Int32.Parse(this.ddlEstado.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogColonia_Click(){
			try
			{

				// Ciudad asociado al estado
				this.wucFastCatalogColonia.MunicipioID = Int32.Parse(this.ddlCiudad.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		
		protected void wucFastCatalogPais_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlPais.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogEstado_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstado.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudad_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudad.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogColonia_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		// Eventos [Domicilio] de wucFastCatalog (ordenados por precedencia)

		protected void wucFastCatalogEstadoOrigen_Click(){
			try
			{

				// Pais Origen asociado al estado
				this.wucFastCatalogEstadoOrigen.PaisID = Int32.Parse(this.ddlPaisOrigen.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudadOrigen_Click(){
			try
			{

				// Estado Origen asociado al estado
				this.wucFastCatalogCiudadOrigen.EstadoID = Int32.Parse(this.ddlEstadoOrigen.SelectedItem.Value);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		protected void wucFastCatalogPaisOrigen_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlPaisOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogEstadoOrigen_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlEstadoOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}

		protected void wucFastCatalogCiudadOrigen_Close(){
			try
			{

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCiudadOrigen.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
                    , "alert('" + gcJavascript.ClearText(ex.Message) + "');"
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
            ddlMedioComunicacion.SelectedIndex = 0;

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

        private void SelectCiudadanoDetalle(Int32 CiudadanoId){
			BPCiudadano BPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Formulario
				oENTCiudadano.CiudadanoId = CiudadanoId;

				// Transacción
				oENTResponse = BPCiudadano.SelectCiudadano_ByID(oENTCiudadano);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Detalle del ciudadano
				this.txtNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
				this.txtApellidoPaterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ApellidoPaterno"].ToString();
				this.txtApellidoMaterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ApellidoMaterno"].ToString();
				this.txtEdad.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Edad"].ToString();
				this.txtTelefonoPrincipal.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TelefonoPrincipal"].ToString();
				this.txtOtroTelefono.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TelefonoOtro"].ToString();
				this.txtCorreoElectronico.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CorreoElectronico"].ToString();
				this.txtDependientesEconomicos.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DependientesEconomicos"].ToString();
				this.txtNombreCalle.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Calle"].ToString();
				this.txtNumExterior.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NumeroExterior"].ToString();
				this.txtNumInterior.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NumeroInterior"].ToString();
				this.txtAniosResidiendo.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AniosResidiendoNL"].ToString();

				this.ddlSexo.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["SexoId"].ToString();
				this.ddlNacionalidad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["NacionalidadId"].ToString();
				this.ddlOcupacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["OcupacionId"].ToString();
				this.ddlEscolaridad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EscolaridadId"].ToString();
				this.ddlEstadoCivil.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoCivilId"].ToString();
				this.ddlMedioComunicacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["MedioComunicacionId"].ToString();

				this.ddlPais.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["PaisId"].ToString();
				ComboEstados();

				this.ddlEstado.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoId"].ToString();
				ComboCiudades();

				this.ddlCiudad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadId"].ToString();
				ComboColonia();

				this.ddlColonia.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["ColoniaId"].ToString();


				this.ddlPaisOrigen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["PaisOrigenId"].ToString();
				ComboEstadosOrigen();

				this.ddlEstadoOrigen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoOrigenId"].ToString();
				ComboCiudadesOrigen();

				this.ddlCiudadOrigen.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadOrigenId"].ToString();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
        }

        #endregion


    }
}