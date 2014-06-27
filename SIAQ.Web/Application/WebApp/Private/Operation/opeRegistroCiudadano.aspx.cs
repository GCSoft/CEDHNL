using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeRegistroCiudadano : System.Web.UI.Page
    {

		// Funciones del programador

		Int32 AniosTranscurridos (DateTime dtFecha) {
			DateTime dtNow = DateTime.Now;
			DateTime dtDiff;

			TimeSpan tsDate;

			try
			{

				// Restar fechas
				tsDate = dtNow - dtFecha;

				// En base al afecha inicial determinar el resultado de la diferencia
				dtDiff = DateTime.MinValue + tsDate;

				// Regresar los años transcurridos a partir de la fecha
				return dtDiff.Day - 1;

			}catch (Exception ex) {
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
               hdnCiudadanoId.Value = ciudadanoId;
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

            if (!String.IsNullOrEmpty(ciudadanoId)) { ObtenerDetalleCiudadano(Convert.ToInt32(ciudadanoId)); }

            // Foco
			ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);

        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Eventos

        #region "Botones"

         protected void btnGuardar_Click(object sender, EventArgs e){
            try
            {

               // Transacción
               if (String.IsNullOrEmpty(hdnCiudadanoId.Value)){
                  AgregarCiudadano();
               }else{
                  ModificarCiudadano(Convert.ToInt32(hdnCiudadanoId.Value));
               }

            }catch (Exception ex){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

         protected void btnRegresar_Click(object sender, EventArgs e){

            // Si la pantalla fue invocada desde la pantalla de agregar ciudadanos a la solicitud (opeAgregarCiudadanosSol) regresar pasándo el CiudadanoId generado
            if (this.hddSolicitudId.Value != ""){

               Response.Redirect("~/Application/WebApp/Private/Operation/opeAgregarCiudadanosSol.aspx?s=" + this.hddSolicitudId.Value, false);
            }else{

               Response.Redirect("~/Application/WebApp/Private/Operation/opeBusquedaCiudadano.aspx");
            }
            
         }

        #endregion

        #region "DropDownList"


        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e){
            try
            {
                ComboEstados();
                ComboCiudades();
                ComboColonia();

               // Foco
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlEstado.ClientID + "');", true);

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

        protected void ddlPaisOrigen_SelectedIndexChanged(object sender, EventArgs e){
            try
            {
                ComboEstadosOrigen();
                ComboCiudadesOrigen();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlEstadoOrigen.ClientID + "');", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page
                       , this.GetType()
                       , Convert.ToString(Guid.NewGuid())
                       , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                      , true);
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e){
            try
            {
                ComboCiudades();
                ComboColonia();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCiudad.ClientID + "');", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page
                       , this.GetType()
                       , Convert.ToString(Guid.NewGuid())
                       , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                      , true);
            }
        }

        protected void ddlEstadoOrigen_SelectedIndexChanged(object sender, EventArgs e){
            try
            {
                ComboCiudadesOrigen();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCiudadOrigen.ClientID + "');", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page
                       , this.GetType()
                       , Convert.ToString(Guid.NewGuid())
                       , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                      , true);
            }
        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

                ComboColonia();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlColonia.ClientID + "');", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page
                       , this.GetType()
                       , Convert.ToString(Guid.NewGuid())
                       , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                      , true);
            }
        }

        #endregion

        #endregion

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

        private void AgregarCiudadano(){
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DateTime dtFechaNacimiento;

            try
            {
                //Validaciones 
                if (String.IsNullOrEmpty(txtNombre.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es requerido', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
                   return;
                }
                if (String.IsNullOrEmpty(txtApellidoPaterno.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Apellido Paterno] es requerido', 'Fail', true); focusControl('" + this.txtApellidoPaterno.ClientID + "');", true);
                   return;
                }
                if (ddlSexo.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Sexo] es requerido', 'Fail', true); focusControl('" + this.ddlSexo.ClientID + "');", true);
                   return;
                }
                if (ddlNacionalidad.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nacionalidad] es requerido', 'Fail', true); focusControl('" + this.ddlNacionalidad.ClientID + "');", true);
                   return;
                }
                if (ddlOcupacion.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ocupación] es requerido', 'Fail', true); focusControl('" + this.ddlOcupacion.ClientID + "');", true);
                   return;
                }
                if (ddlEscolaridad.SelectedValue == "0"){
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Escolaridad] es requerido', 'Fail', true); focusControl('" + this.ddlEscolaridad.ClientID + "');", true);
                   return;
                }
                if (ddlEstadoCivil.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado Civil] es requerido', 'Fail', true); focusControl('" + this.ddlEstadoCivil.ClientID + "');", true);
                   return;
                }
                if (String.IsNullOrEmpty(txtTelefonoPrincipal.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Teléfono Principal] es requerido', 'Fail', true); focusControl('" + this.txtTelefonoPrincipal.ClientID + "');", true);
                   return;
                }
                if (ddlPais.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País] es requerido', 'Fail', true); focusControl('" + this.ddlPais.ClientID + "');", true);
                   return;
                }
                if (ddlEstado.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado] es requerido', 'Fail', true); focusControl('" + this.ddlEstado.ClientID + "');", true);
                   return;
                }
                if (ddlCiudad.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es requerido', 'Fail', true); focusControl('" + this.ddlCiudad.ClientID + "');", true);
                   return;
                }
                if (ddlColonia.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Colonia] es requerido', 'Fail', true); focusControl('" + this.ddlColonia.ClientID + "');", true);
                   return;
                }
                if (String.IsNullOrEmpty(txtNombreCalle.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre Calle] es requerido', 'Fail', true); focusControl('" + this.txtNombreCalle.ClientID + "');", true);
                   return;
                }
                if (this.ddlFormaEnterarse.SelectedValue == "0"){
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Forma de Enterarse] es requerido', 'Fail', true); focusControl('" + this.ddlFormaEnterarse.ClientID + "');", true);
                   return;
                }
                if (ddlPaisOrigen.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País de Origen] es requerido', 'Fail', true); focusControl('" + this.ddlPaisOrigen.ClientID + "');", true);
                   return;
                }
                if (ddlEstadoOrigen.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado de Origen] es requerido', 'Fail', true); focusControl('" + this.ddlEstadoOrigen.ClientID + "');", true);
                   return;
                }
                if (ddlCiudadOrigen.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad de origen] es requerido', 'Fail', true); focusControl('" + this.ddlCiudadOrigen.ClientID + "');", true);
                   return;
                }

				// Obtener fecha de nacimiento del ciudadano
				dtFechaNacimiento = DateTime.Now;
				if (this.txtEdad.Text.Trim() != "") { this.txtEdad.Text = "0"; }
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

                if (String.IsNullOrEmpty(txtDependientesEconomicos.Text)){
                    oENTCiudadano.DependientesEconomicos = 0;
                }else{
                    oENTCiudadano.DependientesEconomicos = Convert.ToByte(txtDependientesEconomicos.Text);
                }

                oENTCiudadano.MedioComunicacionId = Convert.ToInt32(ddlFormaEnterarse.SelectedValue);
                //Domicilio
                oENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);
                oENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
                oENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
                oENTCiudadano.ColoniaId = Convert.ToInt32(ddlColonia.SelectedValue);
                oENTCiudadano.Calle = txtNombreCalle.Text;
                oENTCiudadano.NumeroExterior = txtNumExterior.Text;
                oENTCiudadano.NumeroInterior = txtNumInterior.Text;

                if (String.IsNullOrEmpty(txtAniosResidiendo.Text)){
                    oENTCiudadano.AniosResidiendoNL = 0;
                }else{
                    oENTCiudadano.AniosResidiendoNL = Convert.ToByte(txtAniosResidiendo.Text);
                }

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

                   Response.Redirect("~/Application/WebApp/Private/Operation/opeAgregarCiudadanosSol.aspx?s=" + this.hddSolicitudId.Value + "&c=" + oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString(), false);
                }else{

                   Limpiar();
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Ciudadano agregado con éxito','Success',true);", true);
                }

                
            }catch (Exception ex){
                throw (ex);
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

        private void ModificarCiudadano(int CiudadanoId)
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DateTime dtFechaNacimiento;

            try
            {
                //Validaciones 
               if (String.IsNullOrEmpty(txtNombre.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre] es requerido', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
                   return;
                }
                if (String.IsNullOrEmpty(txtApellidoPaterno.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Apellido Paterno] es requerido', 'Fail', true); focusControl('" + this.txtApellidoPaterno.ClientID + "');", true);
                   return;
                }
                if (ddlSexo.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Sexo] es requerido', 'Fail', true); focusControl('" + this.ddlSexo.ClientID + "');", true);
                   return;
                }
                if (ddlNacionalidad.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nacionalidad] es requerido', 'Fail', true); focusControl('" + this.ddlNacionalidad.ClientID + "');", true);
                   return;
                }
                if (ddlOcupacion.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ocupación] es requerido', 'Fail', true); focusControl('" + this.ddlOcupacion.ClientID + "');", true);
                   return;
                }
                if (ddlEscolaridad.SelectedValue == "0"){
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Escolaridad] es requerido', 'Fail', true); focusControl('" + this.ddlEscolaridad.ClientID + "');", true);
                   return;
                }
                if (ddlEstadoCivil.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado Civil] es requerido', 'Fail', true); focusControl('" + this.ddlEstadoCivil.ClientID + "');", true);
                   return;
                }
                if (String.IsNullOrEmpty(txtTelefonoPrincipal.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Teléfono Principal] es requerido', 'Fail', true); focusControl('" + this.txtTelefonoPrincipal.ClientID + "');", true);
                   return;
                }
                if (ddlPais.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País] es requerido', 'Fail', true); focusControl('" + this.ddlPais.ClientID + "');", true);
                   return;
                }
                if (ddlEstado.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado] es requerido', 'Fail', true); focusControl('" + this.ddlEstado.ClientID + "');", true);
                   return;
                }
                if (ddlCiudad.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad] es requerido', 'Fail', true); focusControl('" + this.ddlCiudad.ClientID + "');", true);
                   return;
                }
                if (ddlColonia.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Colonia] es requerido', 'Fail', true); focusControl('" + this.ddlColonia.ClientID + "');", true);
                   return;
                }
                if (String.IsNullOrEmpty(txtNombreCalle.Text)) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Nombre Calle] es requerido', 'Fail', true); focusControl('" + this.txtNombreCalle.ClientID + "');", true);
                   return;
                }
               if (this.ddlFormaEnterarse.SelectedValue == "0"){
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Forma de Enterarse] es requerido', 'Fail', true); focusControl('" + this.ddlFormaEnterarse.ClientID + "');", true);
                   return;
                }
                if (ddlPaisOrigen.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [País de Origen] es requerido', 'Fail', true); focusControl('" + this.ddlPaisOrigen.ClientID + "');", true);
                   return;
                }
                if (ddlEstadoOrigen.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Estado de Origen] es requerido', 'Fail', true); focusControl('" + this.ddlEstadoOrigen.ClientID + "');", true);
                   return;
                }
                if (ddlCiudadOrigen.SelectedValue == "0") {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo [Ciudad de origen] es requerido', 'Fail', true); focusControl('" + this.ddlCiudadOrigen.ClientID + "');", true);
                   return;
                }

				// Obtener fecha de nacimiento del ciudadano
				dtFechaNacimiento = DateTime.Now;
				if (this.txtEdad.Text.Trim() != "") { this.txtEdad.Text = "0"; }
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
                if (String.IsNullOrEmpty(txtDependientesEconomicos.Text))
                {
                    oENTCiudadano.DependientesEconomicos = 0;
                }
                else
                {
                    oENTCiudadano.DependientesEconomicos = Convert.ToByte(txtDependientesEconomicos.Text);
                }

                oENTCiudadano.MedioComunicacionId = Convert.ToInt32(ddlFormaEnterarse.SelectedValue);
                //Domicilio
                oENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);
                oENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
                oENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
                oENTCiudadano.ColoniaId = Convert.ToInt32(ddlColonia.SelectedValue);
                oENTCiudadano.Calle = txtNombreCalle.Text;
                oENTCiudadano.NumeroExterior = txtNumExterior.Text;
                oENTCiudadano.NumeroInterior = txtNumInterior.Text;
                if (String.IsNullOrEmpty(txtAniosResidiendo.Text))
                {
                    oENTCiudadano.AniosResidiendoNL = 0;
                }
                else
                {
                    oENTCiudadano.AniosResidiendoNL = Convert.ToByte(txtAniosResidiendo.Text);
                }

                //Info de origen
                oENTCiudadano.PaisOrigenId = Convert.ToInt32(ddlPaisOrigen.SelectedValue);
                oENTCiudadano.EstadoOrigenId = Convert.ToInt32(ddlEstadoOrigen.SelectedValue);
                oENTCiudadano.CiudadOrigenId = Convert.ToInt32(ddlCiudadOrigen.SelectedValue);

                //Transacción 
                oENTResponse = oBPCiudadano.UpdateCiudadano(oENTCiudadano);

                //Validación 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Ciudadano modificado con éxito','Success',true);"
                    , true);

                Limpiar();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
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

						this.txtEdad.Text = AniosTranscurridos(DateTime.Parse(oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["FechaNacimiento"].ToString())).ToString();

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