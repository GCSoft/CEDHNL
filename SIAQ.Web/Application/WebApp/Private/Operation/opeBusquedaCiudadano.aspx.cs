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


        // Variables
        string AllDefault = "[Todos]";


        // Rutinas del programador

        protected void BuscarCiudadano(string Nombre, string Paterno, string Materno, string Calle, int PaisId, int EstadoId, int CiudadId, int ColoniaId)
        {
            ENTSession oENTSession = new ENTSession();
            BPCiudadano BPCiudadano = new BPCiudadano();

            oENTSession = (ENTSession)this.Session["oENTSession"];

            BPCiudadano.ENTCiudadano.Nombre = Nombre;
            BPCiudadano.ENTCiudadano.ApellidoPaterno = Paterno;
            BPCiudadano.ENTCiudadano.ApellidoMaterno = Materno;
            BPCiudadano.ENTCiudadano.CiudadId = CiudadId;
            BPCiudadano.ENTCiudadano.EstadoId = EstadoId;
            BPCiudadano.ENTCiudadano.PaisId = PaisId;
            BPCiudadano.ENTCiudadano.ColoniaId = ColoniaId;
            BPCiudadano.ENTCiudadano.Calle = Calle;
            BPCiudadano.ENTCiudadano.CampoBusqueda = "";

            BPCiudadano.BuscarCiudadano();

            if (BPCiudadano.ErrorId == 0)
            {
                if (BPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvCiudadano.DataSource = BPCiudadano.ENTCiudadano.ResultData;
                    gvCiudadano.DataBind();

                    oENTSession.dsResultadoBusCiudadano = BPCiudadano.ENTCiudadano.ResultData.Tables[0];
                }
                else
                {
                    gvCiudadano.DataSource = null;
                    gvCiudadano.DataBind();

                    oENTSession.dsResultadoBusCiudadano = null;
                }
            }
        }

        protected void SelectCiudad()
        {
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            BPCiudad oBPCiudad = new BPCiudad();

            try
            {

                // Formulario
                oENTCiudad.CiudadId = 0;
                oENTCiudad.EstadoId = Int32.Parse(this.BuscadorListaEstado.SelectedValue);
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
                BuscadorListaCiudad.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void SelectColonia()
        {
            ENTColonia oENTColonia = new ENTColonia();
            ENTResponse oENTResponse = new ENTResponse();

            BPColonia oBPColonia = new BPColonia();

            try
            {

                // Formulario
                oENTColonia.ColoniaId = 0;
                oENTColonia.CiudadId = Int32.Parse(this.BuscadorListaCiudad.SelectedValue);
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
                BuscadorListaColonia.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void SelectEstado()
        {
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            BPEstado oBPEstado = new BPEstado();

            try
            {

                // Formulario
                oENTEstado.EstadoId = 0;
                oENTEstado.PaisId = Int32.Parse(this.BuscadorListaPais.SelectedValue);
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
                BuscadorListaEstado.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void SelectPais()
        {
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

                BuscadorListaPais.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void PageLoad()
        {

            if (!Page.IsPostBack)
            {
                ENTSession oENTSession = new ENTSession();

                SelectPais();
                SelectEstado();
                SelectCiudad();
                SelectColonia();

                oENTSession = (ENTSession)this.Session["oENTSession"];
                // Verifica si en la variable de sesión de resultado hay algo guardado, si lo hay lo muestra
                if (oENTSession.dsResultadoBusCiudadano != null)
                {
                    gvCiudadano.DataSource = oENTSession.dsResultadoBusCiudadano;
                    gvCiudadano.DataBind();

                    // al llenar la busuqeda anterior se limpia la variable de sesion 
                    oENTSession.dsResultadoBusCiudadano = null;
                }
                else
                {
                    gvCiudadano.DataSource = null;
                    gvCiudadano.DataBind();
                }

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

            }
        }


        // Eventos de la página

        protected void Page_Load(object sender, EventArgs e){
            try
            {

                PageLoad();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                BuscarCiudadano(txtNombre.Text.Trim(), TextBoxPaterno.Text.Trim(), TextBoxMaterno.Text.Trim(), TextBoxCalle.Text.Trim(), int.Parse(BuscadorListaPais.SelectedValue), int.Parse(BuscadorListaEstado.SelectedValue), int.Parse(BuscadorListaCiudad.SelectedValue), int.Parse(BuscadorListaColonia.SelectedValue));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Consulta de colonias
                SelectColonia();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Consulta de ciudades y colonias
                SelectCiudad();
                SelectColonia();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Consulta de estados, ciudades y colonias
                SelectEstado();
                SelectCiudad();
                SelectColonia();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
			ENTSession oENTSession = new ENTSession();
			String CiudadanoId = String.Empty;

			try
			{

				oENTSession = (ENTSession)this.Session["oENTSession"];
				CiudadanoId = e.CommandArgument.ToString();

				switch (e.CommandName.ToString()){
					case "Visita":
						// vuelve a llenar el datatable de busqueda para que al regresar conserve el resultado de la busqueda en el grid
						oENTSession.dsResultadoBusCiudadano = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.RegistroVisita"].ToString() + "?key=" + CiudadanoId + "|2");
						break;

					case "Solicitud":
						// vuelve a llenar el datatable de busqueda para que al regresar conserve el resultado de la busqueda en el grid
						oENTSession.dsResultadoBusCiudadano = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.RegistroVisita"].ToString() + "?s=" + CiudadanoId + "&t=2");
						break;

					case "Consultar":
						// vuelve a llenar el datatable de busqueda para que al regresar conserve el resultado de la busqueda en el grid
						oENTSession.dsResultadoBusCiudadano = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.DetalleCiudadano"].ToString() + "?s=" + CiudadanoId);
						break;

					case "Editar":
						// vuelve a llenar el datatable de busqueda para que al regresar conserve el resultado de la busqueda en el grid
						oENTSession.dsResultadoBusCiudadano = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
						Response.Redirect(ConfigurationManager.AppSettings["Application.Url.RegistroCiudadano"].ToString() + "?s=" + CiudadanoId);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
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
                //Obtener DataTable y View del GridView
                tblData = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
                viewData = new DataView(tblData);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                viewData.Sort = hddSort.Value;

                //Vaciar datos
                gvCiudadano.DataSource = viewData;
                gvCiudadano.DataBind();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

    }
}