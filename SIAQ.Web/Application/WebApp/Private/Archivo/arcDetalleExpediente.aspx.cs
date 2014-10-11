/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	arcDetalleExpediente
' Autor:	Ruben.Cobos
' Fecha:	12-Junio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Archivo
{
	public partial class arcDetalleExpediente : System.Web.UI.Page
	{
		

		// Utilerías
		GCCommon gcCommon = new GCCommon();
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

		void InsertArchivoComentario() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Validaciones
				if (this.ckeComentario.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un comentario")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTArchivoExpediente.ArchivoId = Int32.Parse(this.hddArchivoId.Value);
				oENTArchivoExpediente.idUsuario = SessionEntity.idUsuario;
				oENTArchivoExpediente.Comentario = this.ckeComentario.Text.Trim();

				// Transacción
				oENTResponse = oBPArchivoExpediente.InsertArchivoComentario(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectArchivo() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.ArchivoId = Int32.Parse(this.hddArchivoId.Value);

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectArchivo_Detalle(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddUbicacionExpedienteId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["UbicacionExpedienteId"].ToString();

				// Formulario
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.AreaNombreLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AreaNombre"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.UbicacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["UbicacionExpedienteNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusArchivo"].ToString();

				// Grid
				this.gvHistorial.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvHistorial.DataBind();

				// Comentarios
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinComentariosLabel.Text = "<br /><br />No hay comentarios relacionados al Archivo";
				}else{

					this.SinComentariosLabel.Text = "";
					this.repComentarios.DataSource = oENTResponse.dsResponse.Tables[3];
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = oENTResponse.dsResponse.Tables[3].Rows.Count.ToString() + " comentarios";
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetPermisos() {
			try
            {

				switch(this.hddUbicacionExpedienteId.Value){
					case "0":
						
						this.RecibirPanel.Visible = true;
						this.AsignarPanel.Visible = false;
						this.LiberarPanel.Visible = false;
						this.CambiarUbicacionPanel.Visible = false;
						break;

					case "4":

						this.RecibirPanel.Visible = false;
						this.AsignarPanel.Visible = false;
						this.LiberarPanel.Visible = true;
						this.CambiarUbicacionPanel.Visible = false;
						break;

					default:

						this.RecibirPanel.Visible = false;
						this.AsignarPanel.Visible = true;
						this.LiberarPanel.Visible = false;
						this.CambiarUbicacionPanel.Visible = true;
						break;
				}

            }catch (Exception ex){
				throw(ex);
            }
		}

		void UpdateArchivo_Liberar() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				
				// Formulario
				oENTArchivoExpediente.ArchivoId = Int32.Parse(this.hddArchivoId.Value);

				// Transacción
				oENTResponse = oBPArchivoExpediente.UpdateArchivo_Liberar(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateArchivo_Recibir() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTArchivoExpediente.ArchivoId = Int32.Parse(this.hddArchivoId.Value);
				oENTArchivoExpediente.idUsuario_Recibe = SessionEntity.idUsuario;

				// Transacción
				oENTResponse = oBPArchivoExpediente.UpdateArchivo_Recibir(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
		}



		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey;

			try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddArchivoId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				switch (this.SenderId.Value){
					case "1":
						this.Sender.Value = "arcBusquedaExpediente.aspx";
						break;

					case "2":
						this.Sender.Value = "arcListadoExpediente.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Consultar detalle de archivo
				SelectArchivo();

				// Seguridad
				SetPermisos();

            }catch (Exception ex){
				this.RecibirPanel.Visible = false;
				this.AsignarPanel.Visible = false;
				this.LiberarPanel.Visible = false;
				this.CambiarUbicacionPanel.Visible = false;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}

		protected void gvHistorial_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

				// Atributos Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvHistorial_Sorting(object sender, GridViewSortEventArgs e){
			try
            {

				gcCommon.SortGridView(ref this.gvHistorial, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void lnkAgregarComentario_Click(object sender, EventArgs e){
			this.lblActionMessage.Text = "";
			this.ckeComentario.Text = "";
			this.ckeComentario.Focus();
			this.pnlAction.Visible = true;
		}


		// Opciones de Menu ( en orden de aparación )

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			try {

				// Actualizar el expediente
				SelectArchivo();

			}catch (Exception ex) {
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void RecibirExpedienteButton_Click(object sender, ImageClickEventArgs e){
			try {

				// Recibir el archivo
				UpdateArchivo_Recibir();

				// Actualizar detalle de Archivo
				SelectArchivo();

				// Actualizar la seguridad
				SetPermisos();

			}catch (Exception ex) {
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddArchivoId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("arcAsignarExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void LiberarButton_Click(object sender, ImageClickEventArgs e){
			try {

				// Liberar el archivo
				UpdateArchivo_Liberar();

				// Actualizar detalle de Archivo
				SelectArchivo();

				// Actualizar la seguridad
				SetPermisos();

			}catch (Exception ex) {
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void CambiarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddArchivoId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("arcCambiarUbicacion.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		
		// Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertArchivoComentario();

				// Actualizar el expediente
				SelectArchivo();

				// Ocultar el panel
				this.pnlAction.Visible = false;

			}catch (Exception ex) {
				this.lblActionMessage.Text = ex.Message;
				this.ckeComentario.Focus();
			}
		}
		
		protected void CloseWindowButton_Click(object sender, ImageClickEventArgs e){
			this.pnlAction.Visible = false;
		}

	}
}