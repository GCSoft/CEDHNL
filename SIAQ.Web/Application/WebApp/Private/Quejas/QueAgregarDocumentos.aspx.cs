/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAgregarDocumentos
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
	public partial class QueAgregarDocumentos : System.Web.UI.Page
	{


		public string _SolicitudId;
		const string ModuloId = "0AB3107A-3C18-4186-BB76-9DAAD63DBEC4";
		Function utilFunction = new Function();


		void SelectSolicitud()
		{
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
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();

				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		#region "Events"

		protected void btnRegresar_Click(object sender, EventArgs e)
		{
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void DocumentoGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
		{
			DocumentoGridRowCommand(e);
		}

		protected void DocumentoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			DocumentoGridRowDataBound(e);
		}

		protected void GuardarButton_Click(object sender, EventArgs e)
		{
			SaveDocumento();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			// Se le agrega una propiedad al formulario de la página para poder subir archivos
			this.Form.Enctype = "multipart/form-data";

			PageLoad();
		}
		#endregion

		#region
		private void DeleteRepositorio(string RepositorioId)
		{
			DeleteRepositorio(RepositorioId, int.Parse(hddSolicitudId.Value));
		}

		private void DeleteRepositorio(string RepositorioId, int SolicitudId)
		{
			BPDocumento DocumentoProcess = new BPDocumento();

			DocumentoProcess.DocumentoEntity.RepositorioId = RepositorioId;
			DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

			DocumentoProcess.DeleteRepositorioSE();

			if (DocumentoProcess.ErrorId == 0)
			{
				SelectDocumento(int.Parse(hddSolicitudId.Value));

				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', false);", true);
			}
			else
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(DocumentoProcess.ErrorDescription) + "', 'Error', true);", true);
		}

		private void DocumentoGridRowCommand(GridViewCommandEventArgs e)
		{
			string RepositorioId = string.Empty;

			RepositorioId = e.CommandArgument.ToString();

			switch (e.CommandName.ToString())
			{
				case "Eliminar":
					DeleteRepositorio(RepositorioId);
					break;
			}
		}

		private void DocumentoGridRowDataBound(GridViewRowEventArgs e)
		{
			HyperLink DocumentoLink;
			Image DocumentoImage;
			DataRowView DataRow;

			//Validación de que sea fila 
			if (e.Row.RowType != DataControlRowType.DataRow)
				return;

			DocumentoImage = (Image)e.Row.FindControl("DocumentoImage");
			DocumentoLink = (HyperLink)e.Row.FindControl("DocumentoLink");

			DataRow = (DataRowView)e.Row.DataItem;

			DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
			DocumentoLink.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=" + DataRow["SolicitudId"].ToString();
		}

		private void PageLoad(){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				_SolicitudId = this.hddSolicitudId.Value;
				SelectDocumento(int.Parse(_SolicitudId));
				SelectTipoDocumento();

				// Carátula
				SelectSolicitud();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.TipoDocumentoList.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.TipoDocumentoList.ClientID + "'); }", true);
            }	
		}

		private void ResetForm()
		{
			TipoDocumentoList.SelectedIndex = 0;
			NombreBox.Text = "";
			DescripcionBox.Text = "";
		}

		private void SaveDocumento()
		{
			ENTSession SessionEntity = new ENTSession();

			SessionEntity = (ENTSession)Session["oENTSession"];

			SaveDocumento(int.Parse(hddSolicitudId.Value), SessionEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
		}

		private void SaveDocumento(int SolicitudId, int idUsuarioInsert, string Nombre, string Descripcion, FileUpload DocumentoFile)
		{
			BPDocumento RepositorioProcess = new BPDocumento();

			RepositorioProcess.DocumentoEntity.ModuloId = ModuloId;
			RepositorioProcess.DocumentoEntity.TipoDocumentoId = TipoDocumentoList.SelectedValue;
			RepositorioProcess.DocumentoEntity.SolicitudId = SolicitudId;
			RepositorioProcess.DocumentoEntity.idUsuarioInsert = idUsuarioInsert;
			RepositorioProcess.DocumentoEntity.Nombre = Nombre;
			RepositorioProcess.DocumentoEntity.Descripcion = Descripcion;
			RepositorioProcess.DocumentoEntity.FileUpload = DocumentoFile;

			RepositorioProcess.SaveRepositorioSE();

			if (RepositorioProcess.ErrorId == 0)
			{
				ResetForm();
				SelectDocumento(int.Parse(hddSolicitudId.Value));

				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', false);", true);
			}
			else
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(RepositorioProcess.ErrorDescription) + "', 'Error', true);", true);
		}

		private void SelectDocumento(int SolicitudId)
		{
			BPDocumento DocumentoProcess = new BPDocumento();

			DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

			DocumentoProcess.SelectRepositorioSE();

			if (DocumentoProcess.ErrorId == 0)
			{
				DocumentoGrid.DataSource = DocumentoProcess.DocumentoEntity.ResultData;
				DocumentoGrid.DataBind();
			}
			else
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + DocumentoProcess.ErrorDescription + "', 'Error', true);", true);
		}

		private void SelectTipoDocumento()
		{
			BPTipoDocumento TipoDocumentoProcess = new BPTipoDocumento();

			TipoDocumentoProcess.SelectTipoDocumento();

			if (TipoDocumentoProcess.ErrorId == 0)
			{
				TipoDocumentoList.DataValueField = "TipoDocumentoId";
				TipoDocumentoList.DataTextField = "Nombre";

				TipoDocumentoList.DataSource = TipoDocumentoProcess.TipoDocumentoEntity.ResultData;
				TipoDocumentoList.DataBind();

				TipoDocumentoList.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
			}
			else
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + TipoDocumentoProcess.ErrorDescription + "', 'Error', true);", true);
		}
		#endregion


	}
}