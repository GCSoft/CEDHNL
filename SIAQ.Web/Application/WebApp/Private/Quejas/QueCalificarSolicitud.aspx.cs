/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueCalificarSolicitud
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
	public partial class QueCalificarSolicitud : System.Web.UI.Page
	{

		string AllDefault = "-- Seleccione --";
		Function utilFunction = new Function();

		public string _SolicitudId;


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

				// Datos de calificación
				this.CalificacionList.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString();
				this.FundamentoBox.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}


		#region "Events"
		protected void AgregarButton_Click(object sender, EventArgs e)
		{
			AgregarCanalizacion(int.Parse(CanalizadoList.SelectedValue), CanalizadoList.SelectedItem.Text);
		}

		protected void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void CalificacionList_SelectedIndexChanged(Object sender, EventArgs e)
		{
			CalificacionListSelectedIndexChanged();
		}

		protected void CierreList_SelectedIndexChanged(Object sender, EventArgs e)
		{
			CierreListSelectedIndexChanged();
		}

		protected void GuardarCalificacionSol_Click(object sender, EventArgs e)
		{
			GuardarCalificacionSol();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			PageLoad();
		}
		#endregion

		#region "Methods"
		private void AgregarCanalizacion(int CanalizacionId, string NombreCanalizacion)
		{
			DataRow Row = null;
			DataTable CanalizacionTable = null;

			if (ValidarCanalizacion(CanalizacionId))
			{
				CanalizacionTable = utilFunction.ParseGridViewToDataTable(this.CanalizacionGrid, false);

				Row = CanalizacionTable.NewRow();

				Row["TipoOrientacionId"] = CanalizacionId;
				Row["Nombre"] = NombreCanalizacion;

				CanalizacionTable.Rows.Add(Row);

				CanalizacionGrid.DataSource = CanalizacionTable;
				CanalizacionGrid.DataBind();

				CeldaGrid.Visible = true;
			}
		}

		private void GuardarCalificacionSol()
		{
			ENTSession SessionEntity = new ENTSession();

			SessionEntity = (ENTSession)Session["oENTSession"];

			if (this.CalificacionList.SelectedValue == "0")
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Calificacion es obligatorio ', 'Fail', true); focusControl('" + this.CalificacionList.ClientID + "');", true);
				return;
			}

			if (this.CierreList.SelectedValue != "0")
			{

				if (this.CanalizadoList.SelectedValue == "0")
				{
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Fail', true); focusControl('" + this.CanalizadoList.ClientID + "');", true);
					return;
				}

				if (this.FundamentoBox.Text == "")
				{
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Fail', true); focusControl('" + this.CanalizadoList.ClientID + "');", true);
					return;
				}
			}

			GuardarCalificacionSol(SessionEntity.idUsuario, int.Parse(hddSolicitudId.Value), FundamentoBox.Text, int.Parse(CanalizadoList.SelectedValue), int.Parse(CalificacionList.SelectedValue), int.Parse(CierreList.SelectedValue));
		}

		private void GuardarCalificacionSol(int IdUsuarioInsert, int SolicitudId, string Fundamento, int CanalizacionId, int CalificacionId, int CierreOrientacionId)
		{

			BPSolicitud BPSolicitud = new BPSolicitud();

			BPSolicitud.SolicitudEntity.idUsuarioInsert = IdUsuarioInsert;
			BPSolicitud.SolicitudEntity.SolicitudId = SolicitudId;
			BPSolicitud.SolicitudEntity.Fundamento = Fundamento;
			BPSolicitud.SolicitudEntity.CanalizacionId = CanalizacionId;
			BPSolicitud.SolicitudEntity.CalificacionId = CalificacionId;
			BPSolicitud.SolicitudEntity.CierreOrientacionId = CierreOrientacionId;

			BPSolicitud.GuardarCalificacionSol();
			if (BPSolicitud.ErrorId == 0)
			{
				Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
			}
			else
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + BPSolicitud.ErrorDescription + "', 'Error', true);", true);
		}

		private void LimpiarCampos()
		{
			CalificacionList.SelectedIndex = 0;
			CierreList.SelectedIndex = 0;
			CeldaCanalizado.Visible = false;

			CalificacionList.Focus();
		}

		private void CalificacionListSelectedIndexChanged()
		{
			// ToDo: solo se debe mostrar esta información cuando la calificación es una orientación
			if (int.Parse(CalificacionList.SelectedValue) == 3)
			{
				CeldaCierre.Visible = true;
			}
			else
			{
				CeldaCierre.Visible = false;
				CeldaCanalizado.Visible = false;
			}
		}

		private void CierreListSelectedIndexChanged()
		{
			// ToDo: solo se debe mostrar esta información cuando la calificación es una orientación
			if (int.Parse(CalificacionList.SelectedValue) == 3)
				CeldaCanalizado.Visible = true;
			else
				CeldaCanalizado.Visible = false;
		}

		private void PageLoad(){

			// Validaciones
			if (Page.IsPostBack) { return; }
			if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
			if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

			// Obtener ExpedienteId
			this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

			// Obtener Sender
			this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];



			SelectCalificacion();
			SelectOrientacion();
			SelectCanalizacion();

			try
			{


				_SolicitudId = hddSolicitudId.Value;

				// consultar la carátula
				SelectSolicitud();

			}catch (Exception Exception){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
			}
		}

		private void SelectCalificacion()
		{
			BPCalificacion BPCalificacion = new BPCalificacion();

			CalificacionList.DataValueField = "CalificacionId";
			CalificacionList.DataTextField = "Nombre";

			CalificacionList.DataSource = BPCalificacion.SelectCalificacion();
			CalificacionList.DataBind();
			CalificacionList.Items.Insert(0, new ListItem(AllDefault, "0"));
		}

		private void SelectCanalizacion()
		{
			BPCanalizacion BPCanalizacion = new BPCanalizacion();

			CanalizadoList.DataValueField = "CanalizacionId";
			CanalizadoList.DataTextField = "Nombre";

			CanalizadoList.DataSource = BPCanalizacion.SelectCanalizacion();
			CanalizadoList.DataBind();
			CanalizadoList.Items.Insert(0, new ListItem(AllDefault, "0"));
		}

		private void SelectOrientacion()
		{
			BPTipoOrientacion BPTipoOrientacion = new BPTipoOrientacion();

			CierreList.DataValueField = "TipoOrientacionId";
			CierreList.DataTextField = "Nombre";

			CierreList.DataSource = BPTipoOrientacion.SelectTipoOrientacion();
			CierreList.DataBind();
			CierreList.Items.Insert(0, new ListItem(AllDefault, "0"));
		}

		private bool ValidarCanalizacion(int CanalizacionId)
		{
			if (CanalizacionId == 0)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Debe seleccionar una opción de canalización', 'Error', true);", true);
				return false;
			}

			foreach (GridViewRow Row in CanalizacionGrid.Rows)
			{
				if (CanalizacionId.ToString() == CanalizacionGrid.DataKeys[Row.DataItemIndex]["TipoOrientacionId"].ToString())
				{
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Esta opción de canalización ya ha sido seleccionada', 'Error', true);", true);
					return false;
				}
			}

			return true;
		}
		#endregion

	}
}