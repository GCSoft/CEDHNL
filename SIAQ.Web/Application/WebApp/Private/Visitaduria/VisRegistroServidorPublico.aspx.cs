/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VisRegistroServidorPublico
' Autor:	Ruben.Cobos
' Fecha:	24-Agosto-2014
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
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
	public partial class VisRegistroServidorPublico : System.Web.UI.Page
	{

		// Utilerías
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();
		
		
		// Funciones del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}


		// Rutinas del programador

		void InsertServidorPublico() { 
			ENTServidorPublico oENTServidorPublico = new ENTServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			BPServidorPublico oBPServidorPublico = new BPServidorPublico();

			try
			{

				// Validaciones
				ValidateForm();
				
				// Formulario
				oENTServidorPublico.ColoniaId = Int32.Parse( this.ddlColonia.SelectedItem.Value );
				oENTServidorPublico.EscolaridadId = Int32.Parse(this.ddlEscolaridad.SelectedItem.Value);
				oENTServidorPublico.EstadoCivilId = Int32.Parse(this.ddlEstadoCivil.SelectedItem.Value);
				oENTServidorPublico.NacionalidadId = Int32.Parse(this.ddlNacionalidad.SelectedItem.Value);
				oENTServidorPublico.OcupacionId = Int32.Parse(this.ddlOcupacion.SelectedItem.Value);
				oENTServidorPublico.SexoId = Int32.Parse(this.ddlSexo.SelectedItem.Value);
				oENTServidorPublico.Nombre = this.txtNombre.Text.Trim();
				oENTServidorPublico.ApellidoPaterno = this.txtApellidoPaterno.Text.Trim();
				oENTServidorPublico.ApellidoMaterno = this.txtApellidoMaterno.Text.Trim();
				oENTServidorPublico.Calle = this.txtCalle.Text.Trim();
				oENTServidorPublico.Edad = Int32.Parse(this.txtEdad.Text);
				oENTServidorPublico.Telefono = this.txtTelefono.Text.Trim();
				oENTServidorPublico.CorreoElectronico = this.txtCorreoElectronico.Text.Trim();

				oENTServidorPublico.AutoridadId = Int32.Parse( this.ddlAutoridadNivel1.SelectedItem.Value );
				if (this.ddlAutoridadNivel2.SelectedItem.Value != "0") { oENTServidorPublico.AutoridadId = Int32.Parse(this.ddlAutoridadNivel2.SelectedItem.Value); }
				if (this.ddlAutoridadNivel3.SelectedItem.Value != "0") { oENTServidorPublico.AutoridadId = Int32.Parse(this.ddlAutoridadNivel3.SelectedItem.Value); }

				// Transacción
				oENTResponse = oBPServidorPublico.InsertServidorPublico(oENTServidorPublico);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Obtener el id generado
				this.hddServidorPublicoId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ServidorPublicoId"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectAutoridadNivel1(){
			BPAutoridad oBPAutoridad = new BPAutoridad();

			try
			{

				// Formulario
				oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = 0;
				oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
				
				// Transacción
				oBPAutoridad.SelectNivelesAutoridad();

				// Validaciones
				if (oBPAutoridad.ErrorId != 0) { throw new Exception(oBPAutoridad.ErrorDescription); }

				// Llenado de controles
				if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
					this.ddlAutoridadNivel1.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0];
					this.ddlAutoridadNivel1.DataTextField = "Nombre";
					this.ddlAutoridadNivel1.DataValueField = "AutoridadId";
					this.ddlAutoridadNivel1.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectAutoridadNivel2(){
			BPAutoridad oBPAutoridad = new BPAutoridad();

			try
			{

				// Formulario
				oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(this.ddlAutoridadNivel1.SelectedValue);
				oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
				
				// Transacción
				oBPAutoridad.SelectNivelesAutoridad();

				// Validaciones
				if (oBPAutoridad.ErrorId != 0) { throw new Exception(oBPAutoridad.ErrorDescription); }

				// Llenado de controles
				if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
					this.ddlAutoridadNivel2.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[1];
					this.ddlAutoridadNivel2.DataTextField = "Nombre";
					this.ddlAutoridadNivel2.DataValueField = "AutoridadId";
					this.ddlAutoridadNivel2.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectAutoridadNivel3(){
			BPAutoridad oBPAutoridad = new BPAutoridad();

			try
			{

				// Formulario
				oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlAutoridadNivel1.SelectedValue);
				oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = Convert.ToInt32(ddlAutoridadNivel2.SelectedValue);
				
				// Transacción
				oBPAutoridad.SelectNivelesAutoridad();

				// Validaciones
				if (oBPAutoridad.ErrorId != 0) { throw new Exception(oBPAutoridad.ErrorDescription); }

				// Llenado de controles
				if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
					this.ddlAutoridadNivel3.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[2];
					this.ddlAutoridadNivel3.DataTextField = "Nombre";
					this.ddlAutoridadNivel3.DataValueField = "AutoridadId";
					this.ddlAutoridadNivel3.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectColonia(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Transacción
				oBPCiudadano.ENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
				oBPCiudadano.SelectComboColonia();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlColonia.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlColonia.DataTextField = "Nombre";
					ddlColonia.DataValueField = "ColoniaId";
					ddlColonia.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectEscolaridad(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Transacción
				oBPCiudadano.SelectComboEscolaridad();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlEscolaridad.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlEscolaridad.DataTextField = "Nombre";
					ddlEscolaridad.DataValueField = "EscolaridadId";
					ddlEscolaridad.DataBind();
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		void SelectEstado(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Formulario
				oBPCiudadano.ENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);

				// Transacción
				oBPCiudadano.SelectComboEstado();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlEstado.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlEstado.DataTextField = "Nombre";
					ddlEstado.DataValueField = "EstadoId";
					ddlEstado.DataBind();
				}

			 }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectEstadoCivil(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Transacción
				oBPCiudadano.SelectComboEstadoCivil();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlEstadoCivil.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlEstadoCivil.DataTextField = "Nombre";
					ddlEstadoCivil.DataValueField = "EstadoCivilId";
					ddlEstadoCivil.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectMunicipio(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Formulario
				oBPCiudadano.ENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);

				// Transacción
				oBPCiudadano.SelectComboCiudad();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlCiudad.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlCiudad.DataTextField = "Nombre";
					ddlCiudad.DataValueField = "CiudadId";
					ddlCiudad.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectNacionalidad(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Transacción
				oENTResponse = oBPCiudadano.SelectComboNacionalidad(oENTCiudadano);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }
				
				// Llenado de control
				this.ddlNacionalidad.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlNacionalidad.DataTextField = "Nombre";
				this.ddlNacionalidad.DataValueField = "NacionalidadId";
				this.ddlNacionalidad.DataBind();

				this.ddlNacionalidad.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectOcupacion(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{
				
				// Transacción
				oBPCiudadano.SelectComboOcupacion();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlOcupacion.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlOcupacion.DataTextField = "Nombre";
					ddlOcupacion.DataValueField = "OcupacionId";
					ddlOcupacion.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectPais(){
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {

                // Transacción
				oENTResponse = oBPCiudadano.SelectComboPais(oENTCiudadano);

				// Validaciones
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Llenado de control
                this.ddlPais.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlPais.DataTextField = "Nombre";
				this.ddlPais.DataValueField = "PaisId";
				this.ddlPais.DataBind();

				this.ddlPais.Items.Insert(0, new ListItem("[Seleccione]", "0"));

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		void SelectSexo(){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{
				// Transacción
				oBPCiudadano.SelectComboSexo();

				// Validaciones
				if (oBPCiudadano.ErrorId != 0) { throw new Exception(oBPCiudadano.ErrorDescription); }

				// Llenado de controles
				if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){
					ddlSexo.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
					ddlSexo.DataTextField = "Nombre";
					ddlSexo.DataValueField = "SexoId";
					ddlSexo.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectServidorPublico_ForEdit() {
			ENTServidorPublico oENTServidorPublico = new ENTServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			BPServidorPublico oBPServidorPublico = new BPServidorPublico();

			try
			{
				
				// Formulario
				oENTServidorPublico.ServidorPublicoId = Int32.Parse( this.hddServidorPublicoId.Value );

				// Transacción
				oENTResponse = oBPServidorPublico.SelectServidorPublicoByID(oENTServidorPublico);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Obtener el formulario
				this.txtNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
				this.txtApellidoPaterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ApellidoPaterno"].ToString();
				this.txtApellidoMaterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ApellidoMaterno"].ToString();
				this.txtEdad.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Edad"].ToString();
				this.txtCalle.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Calle"].ToString();
				this.txtTelefono.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Telefono"].ToString();
				this.txtCorreoElectronico.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CorreoElectronico"].ToString();

				this.ddlSexo.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["SexoId"].ToString();
				this.ddlNacionalidad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["NacionalidadId"].ToString();
				this.ddlOcupacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["OcupacionId"].ToString();
				this.ddlEscolaridad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EscolaridadId"].ToString();
				this.ddlEstadoCivil.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoCivilId"].ToString();

				this.ddlPais.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["PaisId"].ToString();
				SelectEstado();

				this.ddlEstado.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoId"].ToString();
				SelectMunicipio();

				this.ddlCiudad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadId"].ToString();
				SelectColonia();

				this.ddlColonia.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["ColoniaId"].ToString();

				this.ddlAutoridadNivel1.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel1Id"].ToString();
				SelectAutoridadNivel2();

				this.ddlAutoridadNivel2.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel2Id"].ToString();
				SelectAutoridadNivel3();

				this.ddlAutoridadNivel3.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel3Id"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateServidorPublico() { 
			ENTServidorPublico oENTServidorPublico = new ENTServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			BPServidorPublico oBPServidorPublico = new BPServidorPublico();

			try
			{

				// Validaciones
				ValidateForm();
				
				// Formulario
				oENTServidorPublico.ServidorPublicoId = Int32.Parse( this.hddServidorPublicoId.Value );
				oENTServidorPublico.ColoniaId = Int32.Parse( this.ddlColonia.SelectedItem.Value );
				oENTServidorPublico.EscolaridadId = Int32.Parse(this.ddlEscolaridad.SelectedItem.Value);
				oENTServidorPublico.EstadoCivilId = Int32.Parse(this.ddlEstadoCivil.SelectedItem.Value);
				oENTServidorPublico.NacionalidadId = Int32.Parse(this.ddlNacionalidad.SelectedItem.Value);
				oENTServidorPublico.OcupacionId = Int32.Parse(this.ddlOcupacion.SelectedItem.Value);
				oENTServidorPublico.SexoId = Int32.Parse(this.ddlSexo.SelectedItem.Value);
				oENTServidorPublico.Nombre = this.txtNombre.Text.Trim();
				oENTServidorPublico.ApellidoPaterno = this.txtApellidoPaterno.Text.Trim();
				oENTServidorPublico.ApellidoMaterno = this.txtApellidoMaterno.Text.Trim();
				oENTServidorPublico.Calle = this.txtCalle.Text.Trim();
				oENTServidorPublico.Edad = Int32.Parse(this.txtEdad.Text);
				oENTServidorPublico.Telefono = this.txtTelefono.Text.Trim();
				oENTServidorPublico.CorreoElectronico = this.txtCorreoElectronico.Text.Trim();

				oENTServidorPublico.AutoridadId = Int32.Parse(this.ddlAutoridadNivel1.SelectedItem.Value);
				if (this.ddlAutoridadNivel2.SelectedItem.Value != "0") { oENTServidorPublico.AutoridadId = Int32.Parse(this.ddlAutoridadNivel2.SelectedItem.Value); }
				if (this.ddlAutoridadNivel3.SelectedItem.Value != "0") { oENTServidorPublico.AutoridadId = Int32.Parse(this.ddlAutoridadNivel3.SelectedItem.Value); }

				// Transacción
				oENTResponse = oBPServidorPublico.UpdateServidorPublico(oENTServidorPublico);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void ValidateForm() {
			Int16 iTemp;

			try { 

				if (String.IsNullOrEmpty(this.txtNombre.Text)){ throw(new Exception("El campo [Nombre] es requerido")); }
				if (String.IsNullOrEmpty(this.txtApellidoPaterno.Text)){ throw(new Exception("El campo [Apellido Paterno] es requerido")); }

				if (this.ddlPais.SelectedValue == "0") { throw (new Exception("El campo [País] es requerido")); }
				if (this.ddlEstado.SelectedValue == "0") { throw (new Exception("El campo [Estado] es requerido")); }
				if (this.ddlCiudad.SelectedValue == "0") { throw (new Exception("El campo [Ciudad] es requerido")); }
				if (this.ddlColonia.SelectedValue == "0") { throw (new Exception("El campo [Colonia] es requerido")); }
				if (String.IsNullOrEmpty(this.txtCalle.Text)) { throw (new Exception("El campo [Calle y Número] es requerido")); }

				if( this.txtEdad.Text.Trim() == "" ){

					this.txtEdad.Text = "0";

				}else{

					if (Int16.TryParse(this.txtEdad.Text, out iTemp)){
						this.txtEdad.Text = iTemp.ToString();
					}else {
						throw(new Exception("El campo [Edad] solo acepta datos numéricos"));
						
					}

				}

				if (this.ddlSexo.SelectedValue == "0"){ throw(new Exception("El campo [Sexo] es requerido")); }
				if (this.ddlNacionalidad.SelectedValue == "0"){ throw(new Exception("El campo [Nacionalidad] es requerido")); }
				if (this.ddlEscolaridad.SelectedValue == "0") { throw (new Exception("El campo [Escolaridad] es requerido")); }
				if (this.ddlOcupacion.SelectedValue == "0"){ throw(new Exception("El campo [Ocupación] es requerido")); }
				if (this.ddlEstadoCivil.SelectedValue == "0"){ throw(new Exception("El campo [Estado Civil] es requerido")); }
				if (String.IsNullOrEmpty(this.txtTelefono.Text)) { throw (new Exception("El campo [Teléfono] es requerido")); }

				if (this.ddlAutoridadNivel1.SelectedValue == "0") { throw (new Exception("Es necesario seleccionar por lo menos el primer nivel de la Autoridad asociada al Servidor Público")); }
				
			}catch(Exception ex){ 
				throw(ex);
			}
		}

		
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 4) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddExpedienteId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId_Level1.Value = sKey.Split(new Char[] { '|' })[1];
				this.SenderId_Level2.Value = sKey.Split(new Char[] { '|' })[2];

				// Obtener hddServidorPublicoId
				this.hddServidorPublicoId.Value = sKey.Split(new Char[] { '|' })[3];

				// Llenado de controles
				SelectPais();
				SelectSexo();
				SelectNacionalidad();
				SelectEscolaridad();
				SelectOcupacion();
				SelectEstadoCivil();

				SelectAutoridadNivel1();
				SelectAutoridadNivel2();
				SelectAutoridadNivel3();

				// Configurar wucFastCatalog's
				this.wucFastCatalogPais.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoPais, true);
				this.wucFastCatalogEstado.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoEstado, false);
				this.wucFastCatalogCiudad.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevoMunicipio, false);
				this.wucFastCatalogColonia.SetCatalogType(Include.WebUserControls.wucFastCatalog.FastCatalogTypes.NuevaColonia, false);

				// Consulta de servidor público
				if (this.hddServidorPublicoId.Value != "0") {
 
					SelectServidorPublico_ForEdit();

					// Habilitar wucFastCatalog's
					this.wucFastCatalogEstado.Enabled = true;
					this.wucFastCatalogCiudad.Enabled = true;
					this.wucFastCatalogColonia.Enabled = true;
				}
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
		}

		protected void btnAceptar_Click(object sender, EventArgs e){
			ENTExpedienteComparecencia oENTExpedienteComparecencia;
			ENTSession oENTSession = new ENTSession();

			DataRow rowServidorPublico;

			String sKey = "";

			try
            {

				// Determinar el tipo de transacción
				if (this.hddServidorPublicoId.Value == "0"){

					InsertServidorPublico();
				}else {

					UpdateServidorPublico();
				}

				// Çonfiguración y regreso
				switch (this.SenderId_Level2.Value) {
					case "1":

						// Obtener la sesión
						oENTSession = (ENTSession)this.Session["oENTSession"];
						oENTExpedienteComparecencia = (ENTExpedienteComparecencia)oENTSession.Entity;

						// Registrar los cambios
						if ( oENTExpedienteComparecencia.tblServidorPublico.Select("ServidorPublicoId=" + this.hddServidorPublicoId.Value).Length > 0 ){
							oENTExpedienteComparecencia.tblServidorPublico.Rows.Remove(oENTExpedienteComparecencia.tblServidorPublico.Select("ServidorPublicoId=" + this.hddServidorPublicoId.Value)[0]);
						}
						rowServidorPublico = oENTExpedienteComparecencia.tblServidorPublico.NewRow();
						rowServidorPublico["ServidorPublicoId"] = this.hddServidorPublicoId.Value;
						rowServidorPublico["NombreCompleto"] = this.txtNombre.Text + " " + this.txtApellidoPaterno.Text + " " + this.txtApellidoMaterno.Text;
						rowServidorPublico["AutoridadAgrupada"] = "(N1) - " + this.ddlAutoridadNivel1.SelectedItem.Text;
						if (this.ddlAutoridadNivel2.SelectedIndex > 0) { rowServidorPublico["AutoridadAgrupada"] = rowServidorPublico["AutoridadAgrupada"].ToString() + "<br />(N2) - " + this.ddlAutoridadNivel2.SelectedItem.Text; }
						if (this.ddlAutoridadNivel3.SelectedIndex > 0) { rowServidorPublico["AutoridadAgrupada"] = rowServidorPublico["AutoridadAgrupada"].ToString() + "<br />(N3) - " + this.ddlAutoridadNivel3.SelectedItem.Text; }
						oENTExpedienteComparecencia.tblServidorPublico.Rows.Add(rowServidorPublico);

						// Actualizar la sesión
						oENTSession.Entity = oENTExpedienteComparecencia;
						this.Session["oENTSession"] = oENTSession;

						// Regreso
						sKey = this.hddExpedienteId.Value + "|" + this.SenderId_Level1.Value;
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("visComparecencia.aspx?key=" + sKey, false);
						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				switch (this.SenderId_Level2.Value) {
					case "1":

						sKey = this.hddExpedienteId.Value + "|" + this.SenderId_Level1.Value;
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("visComparecencia.aspx?key=" + sKey, false);
						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
		}

		protected void ddlAutoridadNivel1_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

                // Consulta de combo en cascada
                SelectAutoridadNivel2();
                SelectAutoridadNivel3();

                // Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlAutoridadNivel2.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
        }

        protected void ddlAutoridadNivel2_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

                // Consulta de combo en cascada
                SelectAutoridadNivel3();

                // Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlAutoridadNivel3.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
        }

		protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e){
			try
			{

				// Llenado de combos en cascada
				SelectEstado();
				SelectMunicipio();
				SelectColonia();

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
				SelectMunicipio();
				SelectColonia();

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
				SelectColonia();

				// Habilitar/Inhabilitar el control de Colonia
				this.wucFastCatalogColonia.Enabled = (this.ddlCiudad.SelectedIndex == 0 ? false : true);

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


		// Eventos de wucFastCatalog

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
			try
			{

				// Recálculo de Paises
				SelectPais();

				// Limpiar combos de cascada descendentes
				this.ddlEstado.Items.Clear();
				this.ddlCiudad.Items.Clear();
				this.ddlColonia.Items.Clear();

				// Seleccionar Items
				this.ddlPais.SelectedValue = this.wucFastCatalogPais.ItemCreatedID.ToString();

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
			try
			{

				// Recálculo de Estados
				SelectEstado();

				// Limpiar combos de cascada descendentes
				this.ddlCiudad.Items.Clear();
				this.ddlColonia.Items.Clear();

				// Seleccionar Items
				this.ddlEstado.SelectedValue = this.wucFastCatalogEstado.ItemCreatedID.ToString();

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
			try
			{

				// Recálculo de Ciudades
				SelectMunicipio();

				// Limpiar combos de cascada descendentes
				this.ddlColonia.Items.Clear();

				// Seleccionar Items
				this.ddlCiudad.SelectedValue = this.wucFastCatalogCiudad.ItemCreatedID.ToString();

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
				SelectColonia();

				// Seleccionar el nuevo Item Creado
				this.ddlColonia.SelectedValue = this.wucFastCatalogColonia.ItemCreatedID.ToString();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlColonia.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
			}
		}


	}
}