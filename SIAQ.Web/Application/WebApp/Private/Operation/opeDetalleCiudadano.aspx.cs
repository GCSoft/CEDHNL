// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;


namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleCiudadano : System.Web.UI.Page
    {

		// Utilerías
		Function utilFunction = new Function();


		// Rutinas del programador

		void SelectCiudadanoDetalle(){
			BPCiudadano BPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Formulario
				oENTCiudadano.CiudadanoId = Int32.Parse(this.hddCiudadanoId.Value);

				// Transacción
				oENTResponse = BPCiudadano.SelectCiudadano_ByID(oENTCiudadano);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Detalle del ciudadano
				this.lblNombre.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString();
				this.lblApellidoPaterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ApellidoPaterno"].ToString();
				this.lblApellidoMaterno.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ApellidoMaterno"].ToString();
				this.lblSexo.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SexoNombre"].ToString();
				this.lblEdad.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Edad"].ToString().Split(new Char[] { ' ' })[0];
				this.lblNacionalidad.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NacionalidadNombre"].ToString();
				this.lblOcupacion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["OcupacionNombre"].ToString();
				this.lblEscolaridad.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EscolaridadNombre"].ToString();
				this.lblEstadoCivil.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstadoCivilNombre"].ToString();
				this.lblTelefonoPrincipal.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TelefonoPrincipal"].ToString();
				this.lblOtroTelefono.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TelefonoOtro"].ToString();
				this.lblCorreoElectronico.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CorreoElectronico"].ToString();
				this.lblDependientesEconomicos.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DependientesEconomicos"].ToString();
				this.lblFormaEnterarse.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MedioComunicacionNombre"].ToString();
				this.lblPais.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombrePais"].ToString();
				this.lblEstado.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreEstado"].ToString();
				this.lblCiudad.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCiudad"].ToString();
				this.lblColonia.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreColonia"].ToString();
				this.lblCalle.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Calle"].ToString();
				this.lblNoExterior.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NumeroExterior"].ToString();
				this.lblNumInterior.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NumeroInterior"].ToString();
				this.lblAniosResidiendoNL.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AniosResidiendoNL"].ToString();

				// Solicitudes y Expedientes
				this.gvSolicitudes.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvSolicitudes.DataBind();

				// Visitas
				this.gvVisitas.DataSource = oENTResponse.dsResponse.Tables[3];
				this.gvVisitas.DataBind();

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
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 1) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener CiudadanoId
				this.hddCiudadanoId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Información del ciudadano
				SelectCiudadanoDetalle();
				
            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("~/Application/WebApp/Private/Operation/opeBusquedaCiudadano.aspx");
		}

		protected void gvSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{

				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over y Out
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvSolicitudes_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblData = null;
			DataView viewData = null;

			try
			{
				
				// Obtener DataTable y View del GridView
				tblData = utilFunction.ParseGridViewToDataTable(this.gvSolicitudes, false);
				viewData = new DataView(tblData);

				// Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar Vista
				viewData.Sort = hddSort.Value;

				// Vaciar datos
				gvSolicitudes.DataSource = viewData;
				gvSolicitudes.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

        protected void gvVisitas_RowDataBound(object sender, GridViewRowEventArgs e){
            try
            {
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over y Out
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

            }catch (Exception ex){
                throw (ex);
            }
        }

        protected void gvVisitas_Sorting(object sender, GridViewSortEventArgs e){
            DataTable tblData = null;
            DataView viewData = null;

            try
            {
                // Obtener DataTable y View del GridView
                tblData = utilFunction.ParseGridViewToDataTable(this.gvVisitas, false);
                viewData = new DataView(tblData);

                // Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                // Ordenar Vista
                viewData.Sort = hddSort.Value;

                // Vaciar datos
                gvVisitas.DataSource = viewData;
                gvVisitas.DataBind();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

    }
}
