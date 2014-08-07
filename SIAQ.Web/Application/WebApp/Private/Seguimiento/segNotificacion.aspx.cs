/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segNotificacion
' Autor:	Ruben.Cobos
' Fecha:	08-Junio-2014
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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segNotificacion : System.Web.UI.Page
	{
		
		// Constantes
		const string ModuloId = "10c75a08-3ad4-4c44-a809-f3958e0f02b1";

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void AdjuntarDocumento() {
			ENTSession SessionEntity = new ENTSession();
			BPDocumento RepositorioProcess = new BPDocumento();

			// Validaciones
			// if (this.DocumentoFile.HasFile == false ) { throw (new Exception("Es necesario seleccionar un archivo")); }
			if (this.TipoDocumentoList.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Tipo de Documento")); }
			if (this.NombreBox.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un nombre del documento")); }

			// Obtener sesión
			SessionEntity = (ENTSession)Session["oENTSession"];

			// Formulario
			RepositorioProcess.DocumentoEntity.ModuloId = ModuloId;
			RepositorioProcess.DocumentoEntity.TipoDocumentoId = this.TipoDocumentoList.SelectedValue;
			RepositorioProcess.DocumentoEntity.SolicitudId = Int32.Parse(this.SolicitudIdHidden.Value);
			RepositorioProcess.DocumentoEntity.idUsuarioInsert = SessionEntity.idUsuario;
			RepositorioProcess.DocumentoEntity.Nombre = this.NombreBox.Text.Trim();
			RepositorioProcess.DocumentoEntity.Descripcion = this.DescripcionBox.Text.Trim();
			RepositorioProcess.DocumentoEntity.FileUpload = this.DocumentoFile;

			// Transacción
			RepositorioProcess.SaveRepositorioSE();

			// Manejo de errores
			if (RepositorioProcess.ErrorId != 0) { throw(new Exception(RepositorioProcess.ErrorDescription)); }

			// Transacción exitosa
			this.TipoDocumentoList.SelectedIndex = 0;
			this.NombreBox.Text = "";
			this.DescripcionBox.Text = "";

			ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', false); focusControl('" + this.DocumentoFile.ClientID + "');", true);
			
		}

		void DeleteRepositorio(string RepositorioId){
			BPDocumento DocumentoProcess = new BPDocumento();

			// Formulario
			DocumentoProcess.DocumentoEntity.RepositorioId = RepositorioId;
			DocumentoProcess.DocumentoEntity.SolicitudId = Int32.Parse(SolicitudIdHidden.Value);

			// Transacción
			DocumentoProcess.DeleteRepositorioSE();

			// Manejor de errores
			if (DocumentoProcess.ErrorId != 0) { throw (new Exception(DocumentoProcess.ErrorDescription)); }
			
			// Transacción exitosa
			SelectedExpediente();
			ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Archivo eliminado con éxito!', 'Success', false); focusControl('" + this.DocumentoFile.ClientID + "');", true);

		}

		void SelectedExpediente() {
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value );

			// Transacción
			BPSeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

			// No se encontró el expediente
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count == 0){ throw (new Exception("No se encontro el expediente")); }

			// Formulario
			this.ExpedienteNumeroLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["ExpedienteNumero"].ToString();
			this.CalificacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["CalificacionNombre"].ToString();
			this.EstatusLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["EstatusNombre"].ToString();
			this.TipoSolicitudLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["TipoSolicitudNombre"].ToString();
			this.DefensorLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DefensorNombre"].ToString();

			this.FechaRecepcionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaRecepcion"].ToString();
			this.FechaAsignacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaAsignacion"].ToString();
			this.FechaInicioLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaInicioGestion"].ToString();
			this.FechaUltimaLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaUltimaModificacion"].ToString();

			this.ObservacionesLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
			this.LugarHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["LugarHechosNombre"].ToString();
			this.DireccionHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

			// Campos ocultos
			this.SolicitudIdHidden.Value = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["SolicitudId"].ToString();

			// Grid
			this.grdDocumento.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[5];
			this.grdDocumento.DataBind();

		}

		void SelectedTipoDocumento(){
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


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
            {

				// Se le agrega una propiedad al formulario de la página para poder subir archivos
				this.Form.Enctype = "multipart/form-data";

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectedExpediente();
				SelectedTipoDocumento();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.DocumentoFile.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.DocumentoFile.ClientID + "');", true);
            }
		}

		protected void btnAgregar_Click(object sender, EventArgs e){
			try
            {

                // Agregar el documento
				AdjuntarDocumento();

				// Refrescar Formulario
				SelectedExpediente();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.DocumentoFile.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
		}

		protected void grdDocumento_RowCommand(object sender, GridViewCommandEventArgs e){
			string RepositorioId = string.Empty;

			RepositorioId = e.CommandArgument.ToString();

			switch (e.CommandName.ToString())
			{
				case "Eliminar":
					DeleteRepositorio(RepositorioId);
					break;
			}
		}

		protected void grdDocumento_RowDataBound(object sender,GridViewRowEventArgs e){
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

	}
}