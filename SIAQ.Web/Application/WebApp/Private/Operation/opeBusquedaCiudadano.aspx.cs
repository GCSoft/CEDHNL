using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

// Referencias manuales
using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Configuration;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeBusquedaCiudadano : BPPage
    {

        // Utilerías
        Function utilFunction = new Function();


        // Rutinas del programador

		void RecoveryForm(){
			ENTSession oENTSession = new ENTSession();
			BPCiudadano oBPCiudadano;

            try
            {

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones
				if (oENTSession.Entity == null) { return; }
				if (oENTSession.Entity.GetType().Name != "BPCiudadano") { return; }

                // Obtener Formulario
				oBPCiudadano = (BPCiudadano)oENTSession.Entity;

				// Vaciar formulario
				this.txtNombre.Text = oBPCiudadano.ENTCiudadano.Nombre;
				this.TextBoxPaterno.Text = oBPCiudadano.ENTCiudadano.ApellidoPaterno;
				this.TextBoxMaterno.Text = oBPCiudadano.ENTCiudadano.ApellidoMaterno;
				this.TextBoxCalle.Text = oBPCiudadano.ENTCiudadano.Calle;

				this.BuscadorListaPais.SelectedValue = oBPCiudadano.ENTCiudadano.PaisId.ToString();
				SelectEstado();

				this.BuscadorListaEstado.SelectedValue = oBPCiudadano.ENTCiudadano.EstadoId.ToString();
				SelectCiudad();

				this.BuscadorListaCiudad.SelectedValue = oBPCiudadano.ENTCiudadano.CiudadId.ToString();
				SelectColonia();
				
				this.BuscadorListaColonia.SelectedValue = oBPCiudadano.ENTCiudadano.ColoniaId.ToString();


				// Liberar el formulario en la sesión
				oENTSession.Entity = null;
				this.Session["oENTSession"] = oENTSession;

				// Realcular
				SelectCiudadano();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No fue posible recuperar el formulario: " + utilFunction.JSClearText(ex.Message) + "', 'Warning', false);", true);
            }
		}

		void SaveForm(){
			ENTSession oENTSession = new ENTSession();
			BPCiudadano BPCiudadano = new BPCiudadano();

            try
            {

                // Formulario
				BPCiudadano.ENTCiudadano.Nombre = this.txtNombre.Text.Trim();
				BPCiudadano.ENTCiudadano.ApellidoPaterno = this.TextBoxPaterno.Text.Trim();
				BPCiudadano.ENTCiudadano.ApellidoMaterno = this.TextBoxMaterno.Text.Trim();
				BPCiudadano.ENTCiudadano.CiudadId = Int32.Parse(this.BuscadorListaCiudad.SelectedValue);
				BPCiudadano.ENTCiudadano.EstadoId = Int32.Parse(this.BuscadorListaEstado.SelectedValue);
				BPCiudadano.ENTCiudadano.PaisId = Int32.Parse(this.BuscadorListaPais.SelectedValue);
				BPCiudadano.ENTCiudadano.ColoniaId = Int32.Parse(this.BuscadorListaColonia.SelectedValue);
				BPCiudadano.ENTCiudadano.Calle = this.TextBoxCalle.Text.Trim();
				BPCiudadano.ENTCiudadano.CampoBusqueda = "";

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

                // Guardar el formulario en la sesión
				oENTSession.Entity = BPCiudadano;
				this.Session["oENTSession"] = oENTSession;

            }catch (Exception ex){
                throw (ex);
            }
		}

        void SelectCiudad(){
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            BPCiudad oBPCiudad = new BPCiudad();

			Int32 EstadoId;

            try
            {

				// Estado seleccionado
				EstadoId = Int32.Parse(this.BuscadorListaEstado.SelectedValue);

                // Formulario
                oENTCiudad.CiudadId = 0;
				oENTCiudad.EstadoId = (EstadoId == 0 ? -1 : EstadoId);
                oENTCiudad.Nombre = "";
                oENTCiudad.Activo = 1;

                // Transacción
                oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Llenado de combo
                this.BuscadorListaCiudad.DataTextField = "Nombre";
                this.BuscadorListaCiudad.DataValueField = "CiudadId";
                this.BuscadorListaCiudad.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaCiudad.DataBind();
				BuscadorListaCiudad.Items.Insert(0, new ListItem("[Todos]", "0"));

            }catch (Exception ex){
                throw (ex);
            }
        }

		void SelectCiudadano(){
            BPCiudadano BPCiudadano = new BPCiudadano();

			try
            {

				// Estado inicial del formulario
				this.gvCiudadano.DataSource = null;
				this.gvCiudadano.DataBind();

				// Formulario
				BPCiudadano.ENTCiudadano.Nombre = this.txtNombre.Text.Trim();
				BPCiudadano.ENTCiudadano.ApellidoPaterno = this.TextBoxPaterno.Text.Trim();
				BPCiudadano.ENTCiudadano.ApellidoMaterno = this.TextBoxMaterno.Text.Trim();
				BPCiudadano.ENTCiudadano.CiudadId = Int32.Parse(this.BuscadorListaCiudad.SelectedValue);
				BPCiudadano.ENTCiudadano.EstadoId = Int32.Parse(this.BuscadorListaEstado.SelectedValue);
				BPCiudadano.ENTCiudadano.PaisId = Int32.Parse(this.BuscadorListaPais.SelectedValue);
				BPCiudadano.ENTCiudadano.ColoniaId = Int32.Parse(this.BuscadorListaColonia.SelectedValue);
				BPCiudadano.ENTCiudadano.Calle = this.TextBoxCalle.Text.Trim();
				BPCiudadano.ENTCiudadano.CampoBusqueda = "";

                // Transacción
				BPCiudadano.BuscarCiudadano();

                // Validaciones
				if (BPCiudadano.ErrorId != 0) { throw (new Exception(BPCiudadano.ErrorDescription)); }

                // Llenado de grid
				if (BPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){

					this.gvCiudadano.DataSource = BPCiudadano.ENTCiudadano.ResultData;
					this.gvCiudadano.DataBind();  
                }

            }catch (Exception ex){
                throw (ex);
            }
        }

        void SelectColonia(){
            ENTColonia oENTColonia = new ENTColonia();
            ENTResponse oENTResponse = new ENTResponse();

            BPColonia oBPColonia = new BPColonia();

			Int32 CiudadId;

            try
            {

				// Ciudad seleccionado
				CiudadId = Int32.Parse(this.BuscadorListaCiudad.SelectedValue);

                // Formulario
                oENTColonia.ColoniaId = 0;
				oENTColonia.CiudadId = (CiudadId == 0 ? -1 : CiudadId);
                oENTColonia.Nombre = "";
                oENTColonia.Activo = 1;

                // Transacción
                oENTResponse = oBPColonia.SelectColonia(oENTColonia);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Llenado de combo
                this.BuscadorListaColonia.DataTextField = "Nombre";
                this.BuscadorListaColonia.DataValueField = "ColoniaId";
                this.BuscadorListaColonia.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaColonia.DataBind();
				BuscadorListaColonia.Items.Insert(0, new ListItem("[Todos]", "0"));

            }catch (Exception ex){
                throw (ex);
            }
        }

        void SelectEstado(){
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            BPEstado oBPEstado = new BPEstado();

			Int32 PaisId;

            try
            {

				// Pais seleccionado
				PaisId = Int32.Parse(this.BuscadorListaPais.SelectedValue);

                // Formulario
                oENTEstado.EstadoId = 0;
				oENTEstado.PaisId = (PaisId == 0 ? -1 : PaisId);
                oENTEstado.Nombre = "";
                oENTEstado.Activo = 1;

                // Transacción
                oENTResponse = oBPEstado.SelectEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Llenado de combo
                this.BuscadorListaEstado.DataTextField = "Nombre";
                this.BuscadorListaEstado.DataValueField = "EstadoId";
                this.BuscadorListaEstado.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaEstado.DataBind();
				BuscadorListaEstado.Items.Insert(0, new ListItem("[Todos]", "0"));

            }catch (Exception ex){
                throw (ex);
            }
        }

        void SelectPais(){
            ENTPais oENTPais = new ENTPais();
            ENTResponse oENTResponse = new ENTResponse();

            BPPais oBPPais = new BPPais();

            try
            {

                // Formulario
                oENTPais.PaisId = 0;
                oENTPais.Nombre = "";
                oENTPais.Activo = 1;

                // Transacción
                oENTResponse = oBPPais.SelectPais(oENTPais);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Llenado de combo
                this.BuscadorListaPais.DataTextField = "Nombre";
                this.BuscadorListaPais.DataValueField = "PaisId";
                this.BuscadorListaPais.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaPais.DataBind();

				BuscadorListaPais.Items.Insert(0, new ListItem("[Todos]", "0"));

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

				// Llenado de controles
				SelectPais();
				SelectEstado();
				SelectCiudad();
				SelectColonia();

				// Estado inicial del formulario
				gvCiudadano.DataSource = null;
				gvCiudadano.DataBind();

				// Recuperar el formulario
				RecoveryForm();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e){
            try
            {

				SelectCiudadano();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaCiudad_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

				// Llenado de combos en cascada
                SelectColonia();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.BuscadorListaColonia.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaEstado_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

				// Llenado de combos en cascada
                SelectCiudad();
                SelectColonia();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.BuscadorListaCiudad.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaPais_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

				// Llenado de combos en cascada
                SelectEstado();
                SelectCiudad();
                SelectColonia();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.BuscadorListaEstado.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
			String CiudadanoId = "";
			String strCommand = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener CiudadanoId
				CiudadanoId = e.CommandArgument.ToString();

				// Guardar formulario
				SaveForm();

				// Canalizar la página
				switch (strCommand){
					case "Visita":
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.RegistroVisita"].ToString() + "?key=" + CiudadanoId + "|2");
						break;

					case "Solicitud":
						Response.Redirect("opeRegistroSolicitud.aspx?key=" + CiudadanoId + "|2");
						break;

					case "Consultar":
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.DetalleCiudadano"].ToString() + "?s=" + CiudadanoId);
						break;

					case "Editar":
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.RegistroCiudadano"].ToString() + "?s=" + CiudadanoId);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
        }

        protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgVisita = null;
			ImageButton imgSolicitud = null;
			ImageButton imgConsultar = null;
            ImageButton imgEdit = null;

			String sCiudadanoId = "";
			String sNombreCiudadano = "";

			String sToolTip = "";
			String sImagesAttributes = "";

            try
            {
                
				//Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
				imgVisita = (ImageButton)e.Row.FindControl("imgVisita");
				imgSolicitud = (ImageButton)e.Row.FindControl("imgSolicitud");
				imgConsultar = (ImageButton)e.Row.FindControl("imgConsultar");
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                //DataKeys
                sCiudadanoId = gvCiudadano.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();
                sNombreCiudadano = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

                //Tooltips
				sToolTip = "Agregar visita de [" + sNombreCiudadano + "]";
                imgVisita.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgVisita.Attributes.Add("onmouseout", "tooltip.hide();");
                imgVisita.Attributes.Add("style", "cursor:hand;");

				sToolTip = "Crear solicitud a [" + sNombreCiudadano + "]";
				imgSolicitud.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgSolicitud.Attributes.Add("onmouseout", "tooltip.hide();");
				imgSolicitud.Attributes.Add("style", "cursor:hand;");

				sToolTip = "Consultar ciudadano [" + sNombreCiudadano + "]";
				imgConsultar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgConsultar.Attributes.Add("onmouseout", "tooltip.hide();");
				imgConsultar.Attributes.Add("style", "cursor:hand;");

                sToolTip = "Editar ciudadano [" + sNombreCiudadano + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
				sImagesAttributes = "document.getElementById('" + imgVisita.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSolicitud.ClientID + "').src='../../../../Include/Image/Buttons/AgregarSolicitud_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgConsultar.ClientID + "').src='../../../../Include/Image/Buttons/ConsultarCiudadano_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";

                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
				sImagesAttributes = "document.getElementById('" + imgVisita.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSolicitud.ClientID + "').src='../../../../Include/Image/Buttons/AgregarSolicitud.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgConsultar.ClientID + "').src='../../../../Include/Image/Buttons/ConsultarCiudadano.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";

                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }catch (Exception ex){
                throw (ex);
            }
        }

        protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
            DataTable tblData = null;
            DataView viewData = null;

            try
            {
                // Obtener DataTable y View del GridView
                tblData = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
                viewData = new DataView(tblData);

                // Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                // Ordenar Vista
                viewData.Sort = hddSort.Value;

                // Vaciar datos
                gvCiudadano.DataSource = viewData;
                gvCiudadano.DataBind();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

    }
}