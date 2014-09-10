/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicAgregarDocumento
' Autor:	Ruben.Cobos
' Fecha:	19-Junio-2014
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
	public partial class VicAgregarDocumento : System.Web.UI.Page
	{
		
		// Constantes
		const string ModuloId = "C14E2903-A657-43AF-8502-8AAD7D565AFC";

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void AdjuntarDocumento() {
			//ENTSession SessionEntity = new ENTSession();
			//BPDocumento RepositorioProcess = new BPDocumento();

			//// Validaciones
			//// if (this.DocumentoFile.HasFile == false ) { throw (new Exception("Es necesario seleccionar un archivo")); }
			//if (this.TipoDocumentoList.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Tipo de Documento")); }
			//if (this.NombreBox.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un nombre del documento")); }

			//// Obtener sesión
			//SessionEntity = (ENTSession)Session["oENTSession"];

			//// Formulario
			//RepositorioProcess.DocumentoEntity.ModuloId = 5; // Victimas?
			//RepositorioProcess.DocumentoEntity.TipoDocumentoId = this.TipoDocumentoList.SelectedValue;
			//RepositorioProcess.DocumentoEntity.SolicitudId = Int32.Parse(this.SolicitudIdHidden.Value);
			//RepositorioProcess.DocumentoEntity.idUsuarioInsert = SessionEntity.idUsuario;
			//RepositorioProcess.DocumentoEntity.Nombre = this.NombreBox.Text.Trim();
			//RepositorioProcess.DocumentoEntity.Descripcion = this.DescripcionBox.Text.Trim();
			//RepositorioProcess.DocumentoEntity.FileUpload = this.DocumentoFile;

			//// Transacción
			//RepositorioProcess.SaveRepositorioSE();

			//// Manejo de errores
			//if (RepositorioProcess.ErrorId != 0) { throw(new Exception(RepositorioProcess.ErrorDescription)); }

			//// Transacción exitosa
			//this.TipoDocumentoList.SelectedIndex = 0;
			//this.NombreBox.Text = "";
			//this.DescripcionBox.Text = "";

			//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('La información fue guardada con éxito!'); focusControl('" + this.DocumentoFile.ClientID + "');", true);
			
		}

		void DeleteRepositorio(string RepositorioId){
			//BPDocumento DocumentoProcess = new BPDocumento();

			//// Formulario
			//DocumentoProcess.DocumentoEntity.RepositorioId = RepositorioId;
			//DocumentoProcess.DocumentoEntity.SolicitudId = Int32.Parse(SolicitudIdHidden.Value);

			//// Transacción
			//DocumentoProcess.DeleteRepositorioSE();

			//// Manejor de errores
			//if (DocumentoProcess.ErrorId != 0) { throw (new Exception(DocumentoProcess.ErrorDescription)); }
			
			//// Transacción exitosa
			//SelectAtencion();
			//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Archivo eliminado con éxito!'); focusControl('" + this.DocumentoFile.ClientID + "');", true);

		}

		void SelectAtencion() {
			BPAtencion oBPAtencion = new BPAtencion();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTAtencion.AtencionId = Int32.Parse(this.hddAtencionId.Value);

				// Transacción
				oENTResponse = oBPAtencion.SelectAtencion_Detalle(oENTAtencion);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.SolicitudIdHidden.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudId"].ToString();

				// Formulario
				this.AtencionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AtencionNumero"].ToString();
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.DoctorLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.FechaAtencionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAtencion"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Grid
				this.grdDocumento.DataSource = oENTResponse.dsResponse.Tables[5];
				this.grdDocumento.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + TipoDocumentoProcess.ErrorDescription + "');", true);
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

				// Obtener AtencionId
				this.hddAtencionId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectAtencion();
				SelectedTipoDocumento();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.DocumentoFile.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.DocumentoFile.ClientID + "');", true);
            }
		}

		protected void btnAgregar_Click(object sender, EventArgs e){
			try
            {

                // Agregar el documento
				AdjuntarDocumento();

				// Refrescar Formulario
				SelectAtencion();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.DocumentoFile.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("VicDetalleAtencion.aspx?key=" + this.hddAtencionId.Value + "|" + this.SenderId.Value, false);
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
			//HyperLink DocumentoLink;
			//Image DocumentoImage;
			//DataRowView DataRow;

			////Validación de que sea fila 
			//if (e.Row.RowType != DataControlRowType.DataRow)
			//    return;

			//DocumentoImage = (Image)e.Row.FindControl("DocumentoImage");
			//DocumentoLink = (HyperLink)e.Row.FindControl("DocumentoLink");

			//DataRow = (DataRowView)e.Row.DataItem;

			//DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
			//DocumentoLink.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=" + DataRow["SolicitudId"].ToString();
		}

	}
}