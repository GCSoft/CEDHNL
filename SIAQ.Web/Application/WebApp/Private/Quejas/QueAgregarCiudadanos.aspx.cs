/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAgregarCiudadanos
' Autor:	Ruben.Cobos
' Fecha:	17-Julio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueAgregarCiudadanos : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();

		//Variables Globales 
		string AllDefault = "-- Todos --";
		public string _SolicitudId;


		// Funciones del programador

		void AgregaCiudadanoASolicitud(String CiudadanoId)
		{
			BPCiudadano BPCiudadano = new BPCiudadano();

			try
			{

				BPCiudadano.ENTCiudadano.CiudadanoId = int.Parse(CiudadanoId);
				BPCiudadano.ENTCiudadano.SolicitudId = int.Parse(hddSolicitudId.Value);
				BPCiudadano.ENTCiudadano.TipoCiudadanoId = 1; // estos valores los debe de traer un checkbox, se han declarado solo para pruebas

				BPCiudadano.AgregarCiudadanoSolicitud();

				SelectSolicitud();

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		void SelectSolicitud(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Detalle(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Ciudadanos
				gvCiudadanosAgregados.DataSource = oENTResponse.dsResponse.Tables[2];
				gvCiudadanosAgregados.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			gvCiudadanoGridRowCommand(e);
		}

		private void gvCiudadanoGridRowCommand(GridViewCommandEventArgs e)
		{
			string CiudadanoId = string.Empty;

			// Ciudadano seleccionado
			CiudadanoId = e.CommandArgument.ToString();

			switch (e.CommandName.ToString())
			{
				case "Agregar":
					AgregaCiudadanoASolicitud(CiudadanoId);
					break;

			}

		}

		protected void gvCiudadanoAgregados_RowCommand(object sender, GridViewCommandEventArgs e)
		{

			string CiudadanoId = string.Empty;
			int SolicitudId = int.Parse(hddSolicitudId.Value);
			CiudadanoId = e.CommandArgument.ToString();

			switch (e.CommandName.ToString())
			{
				case "Eliminar":

					BPCiudadano BPCiudadano = new BPCiudadano();

					BPCiudadano.ENTCiudadano.CiudadanoId = int.Parse(CiudadanoId);
					BPCiudadano.ENTCiudadano.SolicitudId = SolicitudId;

					BPCiudadano.EliminarCiudadanoSolicitud();

					SelectSolicitud();
					break;

				case "SelectCiudadano":

					Response.Redirect("/Application/WebApp/Private/Operation/opeDetalleCiudadano.aspx?s=" + CiudadanoId);

					break;


			}
		}

		protected void QuickSearchButton_Click(object sender, EventArgs e)
		{
			BuscarCiudadano("", "", "", "", 0, 0, 0, 0, txtNombre.Text.Trim());
		}

		protected void SearchButton_Click(object sender, EventArgs e)
		{
			BuscarCiudadano(TextBoxNombre.Text.Trim(), TextBoxPaterno.Text.Trim(), TextBoxMaterno.Text.Trim(), TextBoxCalle.Text.Trim(), int.Parse(BuscadorListaPais.SelectedValue), int.Parse(BuscadorListaEstado.SelectedValue), int.Parse(BuscadorListaCiudad.SelectedValue), int.Parse(BuscadorListaColonia.SelectedValue), "");
		}

		protected void BusquedaRapida_Click(object sender, EventArgs e)
		{
			VerBusquedaRapida();
		}

		protected void BusquedaAvanzada_Click(object sender, EventArgs e)
		{
			VerBusquedaAvanzada();
		}

		protected void Page_Load(object sender, EventArgs e)
		{

			// Validaciones
			if (Page.IsPostBack) { return; }
			if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
			if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 3) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

			// Obtener ExpedienteId
			this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

			// Obtener Sender
			this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

			// Lógica de la página
			SelectPais();
			SelectEstado();
			SelectCiudad();
			SelectColonia();

			gvCiudadano.DataSource = null;
			gvCiudadano.DataBind();

			gvCiudadanosAgregados.DataSource = null;
			gvCiudadanosAgregados.DataBind();

			try
			{

				// Tomar la solicitud
				_SolicitudId = hddSolicitudId.Value;

				// consultar la carátula
				SelectSolicitud();

				// Tomar el ciudadano (en este caso viene de Registro de ciudadano)
				if (this.Request.QueryString["c"] != null)
				{
					AgregaCiudadanoASolicitud(this.Request.QueryString["c"].ToString());
				}

			}
			catch (Exception Exception)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
			}

		}

		protected void BuscarCiudadano(string Nombre, string Paterno, string Materno, string Calle, int PaisId, int EstadoId, int CiudadId, int ColoniaId, string CampoBusqueda)
		{
			BPCiudadano BPCiudadano = new BPCiudadano();

			BPCiudadano.ENTCiudadano.Nombre = Nombre;
			BPCiudadano.ENTCiudadano.ApellidoPaterno = Paterno;
			BPCiudadano.ENTCiudadano.ApellidoMaterno = Materno;
			BPCiudadano.ENTCiudadano.CiudadId = CiudadId;
			BPCiudadano.ENTCiudadano.EstadoId = EstadoId;
			BPCiudadano.ENTCiudadano.PaisId = PaisId;
			BPCiudadano.ENTCiudadano.ColoniaId = ColoniaId;
			BPCiudadano.ENTCiudadano.Calle = Calle;
			BPCiudadano.ENTCiudadano.CampoBusqueda = CampoBusqueda;

			BPCiudadano.BuscarCiudadano();

			if (BPCiudadano.ErrorId == 0)
			{
				if (BPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
				{
					gvCiudadano.DataSource = BPCiudadano.ENTCiudadano.ResultData;
					gvCiudadano.DataBind();
				}


				else
				{
					gvCiudadano.DataSource = null;
					gvCiudadano.DataBind();
				}
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

		protected void VerBusquedaRapida()
		{

			pnlBusqedaAvanzada.Visible = false;
			pnlBusquedaSimple.Visible = true;
		}

		protected void VerBusquedaAvanzada()
		{

			pnlBusqedaAvanzada.Visible = true;
			pnlBusquedaSimple.Visible = false;
		}

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e)
		{

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "';");

			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e)
		{
			DataTable tblCiudadano = null;
			DataView viewCiudadano = null;

			try
			{

				// Obtener DataTable y DataView del GridView
				tblCiudadano = utilFunction.ParseGridViewToDataTable(this.gvCiudadano, true);
				viewCiudadano = new DataView(tblCiudadano);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewCiudadano.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvCiudadano.DataSource = viewCiudadano;
				this.gvCiudadano.DataBind();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e)
		{
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void btnNuevoCiudadano_Click(object sender, EventArgs e)
		{
			string sSolicitudId = hddSolicitudId.Value;
			Response.Redirect("~/Application/WebApp/Private/Operation/opeRegistroCiudadano.aspx?acs=" + sSolicitudId);
		}

	}
}