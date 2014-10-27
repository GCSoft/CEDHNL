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
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;
using System.IO;
using System.Collections;
using System.Net;
using System.Diagnostics;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segAgregarDocumento : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();


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

		
		// Rutinas el programador

        void DeleteDocumento(Int32 DocumentoId){
			ENTDocumento oENTDocumento = new ENTDocumento();
			ENTResponse oENTResponse = new ENTResponse();

			BPDocumento oBPDocumento = new BPDocumento();

			try
			{

				// Formulario
				oENTDocumento.DocumentoId = DocumentoId;

				// Consultar información del archivo
				oENTResponse = oBPDocumento.SelectDocumento_Path(oENTDocumento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Eliminar físicamente el archivo
				if (File.Exists(oENTResponse.dsResponse.Tables[1].Rows[0]["Ruta"].ToString())) { File.Delete(oENTResponse.dsResponse.Tables[1].Rows[0]["Ruta"].ToString()); }

				// Eliminar la referencia del archivo en la base de datos
				oENTResponse = oBPDocumento.DeleteDocumento(oENTDocumento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Estado inicial del formulario
				this.ckeDescripcion.Text = "";

				// Refrescar el formulario
				SelectRecomendacion();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.fupArchivo.ClientID + "'); }", true);

			}catch ( IOException ioEx){

				throw (ioEx);
			}catch (Exception ex){

				throw (ex);
			}
		}

		void InsertDocumento(){
            ENTDocumento oENTDocumento = new ENTDocumento();
            ENTResponse oENTResponse = new ENTResponse();
            ENTSession oENTSession;

            BPDocumento oBPDocumento = new BPDocumento();

            try
            {

                // Validaciones
                if (this.fupArchivo.PostedFile == null) { throw (new Exception("Es necesario seleccionar un Documento")); }
				if (!this.fupArchivo.HasFile) { throw (new Exception("Es necesario seleccionar un Documento")); }
                if (this.fupArchivo.PostedFile.ContentLength == 0) { throw (new Exception("Es necesario seleccionar un Documento")); }

                // Obtener Sesion
                oENTSession = (ENTSession)this.Session["oENTSession"];

                // Formulario
				oENTDocumento.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTDocumento.RecomendacionId = Int32.Parse(this.hddExpedienteId.Value);
				oENTDocumento.ModuloId = 4; // Seguimientos
                oENTDocumento.idUsuarioInsert = oENTSession.idUsuario;
                oENTDocumento.Extension = Path.GetExtension(this.fupArchivo.PostedFile.FileName);
                oENTDocumento.Nombre = this.fupArchivo.FileName;
                oENTDocumento.Descripcion = this.ckeDescripcion.Text.Trim();
				oENTDocumento.Ruta = oBPDocumento.UploadFile(this.fupArchivo.PostedFile, this.hddRecomendacionId.Value, BPDocumento.RepositoryTypes.Recomendacion );

				// Transacción
				oENTResponse = oBPDocumento.InsertDocumento(oENTDocumento);

                // Errores y Warnings
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Estado inicial del formulario
                this.ckeDescripcion.Text = "";

                // Refrescar el formulario
                SelectRecomendacion();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.fupArchivo.ClientID + "'); }", true);

            }catch (Exception ex){
                throw (ex);
            }
        }

		void SelectRecomendacion() {
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);

				// Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacion_Detalle(oENTSeguimiento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddSolicitudId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudId"].ToString();
				this.hddExpedienteId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteId"].ToString();

				// Encabezado
				this.lblEncabezado.Text = "Agregar documento " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "a la recomendación" : "al acuerdo de no responsabilidad");

				// Formulario
				this.RecomendacionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["RecomendacionNumero"].ToString();
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();

				this.TipoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Tipo"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.NombreAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreAutoridad"].ToString();
				this.PuestoAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["PuestoAutoridad"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaQuejasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaQuejas"].ToString();
				this.FechaVisitaduriasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaVisitadurias"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.NivelesAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Autoridades"].ToString();

				// Documentos
				this.gvDocumento.DataSource = oENTResponse.dsResponse.Tables[3];
				this.gvDocumento.DataBind();
				
			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener RecomendacionId
				this.hddRecomendacionId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Carátula
				SelectRecomendacion();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.fupArchivo.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.fupArchivo.ClientID + "'); }", true);
            }
		}

		protected void btnAgregar_Click(object sender, EventArgs e){
			try
            {
                InsertDocumento();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.fupArchivo.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segDetalleRecomendacion.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.fupArchivo.ClientID + "'); }", true);
            }
		}

		protected void gvDocumento_RowCommand(object sender, GridViewCommandEventArgs e){
			String CommandName = "";
			String DocumentoId = "";
			String sKey = "";

			Int32 iRow = 0;

            try
            {
                // Opción seleccionada
                CommandName = e.CommandName.ToString();

                // Se dispara el evento RowCommand en el ordenamiento
                if (CommandName == "Sort") { return; }

                // Fila
                iRow = Convert.ToInt32(e.CommandArgument.ToString());

                // DataKeys
                DocumentoId = gvDocumento.DataKeys[iRow]["DocumentoId"].ToString();

                // Acción
                switch (CommandName){
                    case "Visualizar":

						sKey = gcEncryption.EncryptString(DocumentoId, true);
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?key=" + sKey + "');", true);
                        break;

                    case "Borrar":
                        DeleteDocumento(Int32.Parse(DocumentoId));
                        break;
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void gvDocumento_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgView = null;
			ImageButton imgDelete = null;

			String DocumentoId = "";
			String NombreDocumento = "";
			String ModuloId = "";
			String Icono = "";

			String sImagesAttributes = "";
			String sToolTip = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener objetos
				imgView = (ImageButton)e.Row.FindControl("imgView");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				DocumentoId = this.gvDocumento.DataKeys[e.Row.RowIndex]["DocumentoId"].ToString();
				Icono = this.gvDocumento.DataKeys[e.Row.RowIndex]["Icono"].ToString();
				ModuloId = this.gvDocumento.DataKeys[e.Row.RowIndex]["ModuloId"].ToString();
				NombreDocumento = this.gvDocumento.DataKeys[e.Row.RowIndex]["NombreDocumento"].ToString();

				// Configuración del Icono
				sToolTip = "Visualizar [" + NombreDocumento + "]";
				imgView.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgView.Attributes.Add("onmouseout", "tooltip.hide();");
				imgView.Attributes.Add("style", "cursor:hand;");
				imgView.ImageUrl = "~/Include/Image/Icon/" + Icono;

				// Seguridad
				if( ModuloId != "4"){

					imgDelete.Visible = false;

					// Atributos Over y Out
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

				}else{

					// Tooltip
					sToolTip = "Eliminar [" + NombreDocumento + "]";
					imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
					imgDelete.Attributes.Add("style", "cursor:hand;");

					// Atributos Over
					sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvDocumento_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvDocumento, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

	}
}