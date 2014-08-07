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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Archivo
{
	public partial class arcDetalleExpediente : System.Web.UI.Page
	{
		

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();


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
				oENTArchivoExpediente.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);
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

		void SelectedExpediente() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectArchivoExpedienteDetalle(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.ExpedientePrestado.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ArchivoExpedienteId"].ToString();

				// Formulario
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusArchivoNombre"].ToString();
				this.UsuarioNombreRecibeLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["UsuarioNombreRecibe"].ToString();
				this.UbicacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Ubicacion"].ToString();
				this.ComentariosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Comentarios"].ToString();

				this.FechaPrestamoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaPrestamo"].ToString();

				// Grid
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvCiudadano.DataBind();

				// Documentos
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados a la solicitud";
				}else{

					this.SinDocumentoLabel.Text = "";
					this.dlstDocumentoList.DataSource = oENTResponse.dsResponse.Tables[3];
					this.dlstDocumentoList.DataBind();
				}

				// Comentarios
				if (oENTResponse.dsResponse.Tables[4].Rows.Count == 0){

					this.SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
				}else{

					this.SinComentariosLabel.Text = "";
					this.repComentarios.DataSource = oENTResponse.dsResponse.Tables[4];
					this.repComentarios.DataBind();
					this.ComentarioTituloLabel.Text = oENTResponse.dsResponse.Tables[4].Rows.Count.ToString() + " comentarios";
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetPermisos() {
			try
            {

				// Opciones visibles
				this.InformacionPanel.Visible = true;
				this.AsignarPanel.Visible = (this.ExpedientePrestado.Value == "0" ? true : false);
				this.LiberarPanel.Visible = (this.ExpedientePrestado.Value == "0" ? false : true);

            }catch (Exception ex){
				throw(ex);
            }
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				switch (this.SenderId.Value){
					case "1": // Invocado desde [Búsqueda de Expedientes]
						this.Sender.Value = "arcBusquedaExpediente.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Consultar detalle de expediente
				SelectedExpediente();

				// Seguridad
				SetPermisos();


            }catch (Exception ex){
				this.AsignarPanel.Visible = false;
				this.LiberarPanel.Visible = false;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}

		protected void dlstDocumentoList_ItemDataBound(Object sender, DataListItemEventArgs e){
			Label DocumentoLabel;
			Image DocumentoImage;
			DataRowView DataRow;

			try
			{

				// Validación de que sea Item 
				if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

				// Obtener controles
				DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
				DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");
				DataRow = (DataRowView)e.Item.DataItem;

				// Configurar imagen
				DocumentoLabel.Text = DataRow["NombreDocumento"].ToString();

				DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
				DocumentoImage.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
				DocumentoImage.Attributes.Add("onmouseout", "this.style.cursor='auto'");
				DocumentoImage.Attributes.Add("onclick", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=0" + "');");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			try
            {

				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		protected void lnkAgregarComentario_Click(object sender, EventArgs e){
			this.lblActionMessage.Text = "";
			this.ckeComentario.Text = "";
			this.ckeComentario.Focus();
			this.pnlAction.Visible = true;
		}


		// Opciones de Menu

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("arcAsignarExpediente.aspx?key=" + this.ExpedienteIdHidden.Value.ToString() + "|" + this.SenderId.Value.ToString());
		}

		protected void LiberarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("arcLiberarExpediente.aspx?key=" + this.ExpedienteIdHidden.Value.ToString() + "|" + this.SenderId.Value.ToString());
		}

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			try {

				// Actualizar el expediente
				SelectedExpediente();

			}catch (Exception ex) {
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		
		// Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertArchivoComentario();

				// Actualizar el expediente
				SelectedExpediente();

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