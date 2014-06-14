/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicDetalleAtencion
' Autor:	Ruben.Cobos
' Fecha:	02-Junio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class VicDetalleAtencion : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();

        protected void Page_Load(object sender, EventArgs e)
        {
            ENTSession SessionEntity = new ENTSession();

            try
            {

                // Validaciones
                if (Page.IsPostBack) { return; }
                if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
                if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

                // Obtener ExpedienteId
                this.hddFuncionarioId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
                this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

                switch (this.SenderId.Value)
                {
                    case "1": // Invocado desde [Listado de Atenciones]
                        this.Sender.Value = "VicListadoAtenciones.aspx";
                        break;

                    case "2": // Invocado desde [Búsqueda de Atenciones]
                        this.Sender.Value = "VicBusquedaAtenciones.aspx";
                        break;

                    default:
                        this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
                        return;
                }

                // Obtener sesión
                SessionEntity = (ENTSession)Session["oENTSession"];

                // Consultar detalle de expediente
                BuscarAtencion();

                // Seguridad
                SetPermisosGenerales(SessionEntity.idRol);
                SetPermisosParticulares(SessionEntity.idRol, SessionEntity.FuncionarioId);


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #region Rutinas de la página

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect(this.Sender.Value);
        }

        protected void dlstDocumentoList_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
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

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ENTSession SessionEntity = new ENTSession();
            String RecomendacionId;

            String strCommand = "";
            Int32 intRow = 0;

            try
            {

                // Opción seleccionada
                strCommand = e.CommandName.ToString();

                // Se dispara el evento RowCommand en el ordenamiento
                if (strCommand == "Sort") { return; }

                // Fila
                intRow = Int32.Parse(e.CommandArgument.ToString());

                // Datakeys
                RecomendacionId = this.gvApps.DataKeys[intRow]["AtencionId"].ToString();

                // Acción
                switch (strCommand)
                {
                    case "Editar":

                        // Obtener sesión
                        SessionEntity = (ENTSession)Session["oENTSession"];

                        // Si el expediente está en estatus de espera e confirmación de cierre no se podrá editar
                        if (Int32.Parse(this.hddEstatusId.Value) == 8)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No es posible editar esta atención debido a que está a la espera de confirmación de cierre', 'Warning', false);", true);
                            return;
                        }

                        // Si no es Defensor no podrá editar
                        if (SessionEntity.idRol != 1 && SessionEntity.idRol != 2 && SessionEntity.idRol != 11)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No cuenta con permisos para realizar ésta opción', 'Warning', false);", true);
                            return;
                        }
                // TODO: "Aqui hay que ponerle la acción que le corresponde para eliminar lógiicamente el ciudadano"
                        this.Response.Redirect("segSeguimientoRecomendacion.aspx?key=" + this.hddFuncionarioId.Value.ToString() + "|" + this.SenderId.Value.ToString() + "|" + RecomendacionId, false);
                        break;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String sNumero = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {

                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                // DataKeys
                sNumero = gvApps.DataKeys[e.Row.RowIndex]["Numero"].ToString();

                // Tooltip Editar Recomendacion
                sToolTip = "Número de atención [" + sNumero + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "cursor:hand;");

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvApps_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableAutoridad = null;
            DataView ViewAutoridad = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableAutoridad = utilFunction.ParseGridViewToDataTable(gvApps, false);
                ViewAutoridad = new DataView(TableAutoridad);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewAutoridad.Sort = hddSort.Value;

                //Vaciar datos
                this.gvApps.DataSource = ViewAutoridad;
                this.gvApps.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void lnkAgregarComentario_Click(object sender, EventArgs e)
        {
            this.lblActionMessage.Text = "";
            this.ckeComentario.Text = "";
            this.ckeComentario.Focus();
            this.pnlAction.Visible = true;
        }

        #endregion

        #region Rutinas del programador

        // Rutinas del programador

		void InsertComentarioAtencion() {
			ENTSession SessionEntity = new ENTSession();
            BPAtencion bss = new BPAtencion();
            ENTAtencion ent = new ENTAtencion();

			// Validaciones
			if (this.ckeComentario.Text.Trim() == "") { throw( new Exception("Es necesario ingresar un comentario")); }

			// Obtener sesión
			SessionEntity = (ENTSession)Session["oENTSession"];

			// Parámetros
            ent.AtencionId = Int32.Parse(this.hddFuncionarioId.Value.Trim());
            ent.IdUsuario = SessionEntity.idUsuario;
            ent.Observaciones = this.ckeComentario.Text.Trim();

			// Transacción
			bss.insertAtencionObservaciones(ent);

			// Errores
            //if (bss.ErrorId != 0) { throw (new Exception(bss.ErrorString)); }

		}

		void BuscarAtencion() {
            BPAtencion bss = new BPAtencion();
            ENTAtencion ent = new ENTAtencion();
            ENTResponse oResponse =new ENTResponse();
            DataSet ds = new DataSet();

			// Parámetros
            ent.AtencionId = Int32.Parse(this.hddFuncionarioId.Value );

			// Transacción
			oResponse = bss.searchAtencionDetalle(ent);

			// Errores
			//if (bss.ErrorId != 0) { throw (new Exception(bss.ErrorString)); }

			// No se encontró el expediente
            if (oResponse.dsResponse.Tables[0].Rows.Count == 0) { throw (new Exception("No se encontro el expediente")); }

			// Campos ocultos
            this.hddEstatusId.Value = ds.Tables[1].Rows[0]["EstatusId"].ToString();
            this.hddFuncionarioId.Value = ds.Tables[1].Rows[0]["FuncionarioId"].ToString();

			// Formulario
            this.lblAtencionNumero.Text = ds.Tables[1].Rows[0]["AtencionId"].ToString();
            this.lblSolicitud.Text = ds.Tables[1].Rows[0]["solicitudId"].ToString();
            this.lblEstatus.Text = ds.Tables[1].Rows[0]["EstatusNombre"].ToString();
            this.lblDoctor.Text = ds.Tables[1].Rows[0]["DoctorNombre"].ToString();

            this.lblFechaRecepcion.Text = ds.Tables[1].Rows[0]["FechaRecepcion"].ToString();
            this.lblFechaAsignacion.Text = ds.Tables[1].Rows[0]["FechaAsignacion"].ToString();
            this.lblFechaInicio.Text = ds.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
            this.lblFechaUltima.Text = ds.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

            this.lblObservaciones.Text = ds.Tables[1].Rows[0]["Observaciones"].ToString();
            this.lblAreaSolicitante.Text = ds.Tables[1].Rows[0]["AreaSolicitanteNombre"].ToString();
            this.lblLugarAtencion.Text = ds.Tables[1].Rows[0]["LugarAtencion"].ToString();
            this.lblTipoDictamen.Text = ds.Tables[1].Rows[0]["TipoDictamen"].ToString();


			// Grid
            this.gvApps.DataSource = ds.Tables[2];
			this.gvApps.DataBind();

			// Documentos
			if (ds.Tables[2].Rows.Count == 0) {

				this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados a la solicitud";
			} else {

				this.SinDocumentoLabel.Text = "";
                this.dlstDocumentoList.DataSource = ds.Tables[2];
				this.dlstDocumentoList.DataBind();
			}

			// Comentarios
            if (ds.Tables[3].Rows.Count == 0)
            {

				this.SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
			} else {

				this.SinComentariosLabel.Text = "";
                this.repComentarios.DataSource = ds.Tables[3];
				this.repComentarios.DataBind();
                this.ComentarioTituloLabel.Text = ds.Tables[3].Rows.Count.ToString() + " comentarios";
			}

		}

		void SetPermisosGenerales(Int32 idRol) {
			try
            {

				// Permisos por rol
				switch (idRol){

					case 1:	// System Administrator
                        this.pnlInformacion.Visible = true;
                        this.pnlDictamenMedico.Visible = true;
                        this.pnlAgregarDocumento.Visible = true;
                        this.pnlEnviarOrientacion.Visible = true;
						break;

					case 2:	// Administrador
						this.pnlInformacion.Visible = true;
                        this.pnlDictamenMedico.Visible = true;
                        this.pnlAgregarDocumento.Visible = true;
                        this.pnlEnviarOrientacion.Visible = true;
						break;

					case 10:	// Seguimiento - Secretaria
                        this.pnlInformacion.Visible = true;
                        this.pnlDictamenMedico.Visible = false;
                        this.pnlAgregarDocumento.Visible = true;
                        this.pnlEnviarOrientacion.Visible = true;
						break;

					case 11:	// Seguimiento - Doctor
						this.pnlInformacion.Visible = true;
                        this.pnlDictamenMedico.Visible = true;
                        this.pnlAgregarDocumento.Visible = true;
                        this.pnlEnviarOrientacion.Visible = false;
						break;

					case 12:	// Seguimiento - Director
                        this.pnlInformacion.Visible = true;
                        this.pnlDictamenMedico.Visible = false;
                        this.pnlAgregarDocumento.Visible = false;
                        this.pnlEnviarOrientacion.Visible = false;
						break;

					default:
						this.pnlInformacion.Visible = false;
                        this.pnlDictamenMedico.Visible = false;
                        this.pnlAgregarDocumento.Visible = false;
                        this.pnlEnviarOrientacion.Visible = false;
						break;
				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		void SetPermisosParticulares(Int32 idRol, Int32 FuncionarioId) {
			try
            {

				// Si es Defensor pero el expediente no está asignado a él no lo podrá operar
				if (idRol == 11 && Int32.Parse(this.hddFuncionarioId.Value) != FuncionarioId) {
                    this.pnlInformacion.Visible = false;
                    this.pnlDictamenMedico.Visible = false;
                    this.pnlAgregarDocumento.Visible = false;
                    this.pnlEnviarOrientacion.Visible = false;
				}

				// Si es Director y el expediente no está en estatus de confirmación de cierre ocultar dicha opción
                //if (idRol == 12 && Int32.Parse(this.hddEstatusId.Value) != 8) {
                //    this.ConfirmarCierreExpedientePanel.Visible = false;
                //}

                //// Si es System Administrator y el expediente no está en estatus de confirmación de cierre ocultar dicha opción
                //if (idRol == 1 && Int32.Parse(this.hddEstatusId.Value) != 8) {
                //    this.ConfirmarCierreExpedientePanel.Visible = false;
                //}

                //// Si es Administrador y el expediente no está en estatus de confirmación de cierre ocultar dicha opción
                //if (idRol == 2 && Int32.Parse(this.hddEstatusId.Value) != 8) {
                //    this.ConfirmarCierreExpedientePanel.Visible = false;
                //}

				// Si el expediente está en estatus de confirmación de cierre no se podrá operar
				if ( Int32.Parse(this.hddEstatusId.Value) == 8 ){
                    this.pnlInformacion.Visible = false;
                    this.pnlDictamenMedico.Visible = false;
                    this.pnlAgregarDocumento.Visible = false;
                    this.pnlEnviarOrientacion.Visible = false;
				}

            }catch (Exception ex){
				throw(ex);
            }
		}

        #endregion

        #region Opciones de menú

        // Opciones de Menu

        protected void cmdInformacionGeneral_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                // Actualizar el expediente
                BuscarAtencion();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void cmdDictamenMedico_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("VicDictamenMedico.aspx?key=" + this.hddAtencionId.Value.ToString() + "|" + this.SenderId.Value.ToString());
        }

        protected void cmdAgregarDocumento_Click(object sender, ImageClickEventArgs e)
        {
			Response.Redirect("VicAgregarDocumento.aspx?key=" + this.hddAtencionId.Value.ToString() + "|" + this.SenderId.Value.ToString());
		}

        protected void cmdEnviarOrientacion_Click(object sender, ImageClickEventArgs e)
        {
			Response.Redirect("VicEnviaOrientacion.aspx?key=" + this.hddAtencionId.Value.ToString() + "|" + this.SenderId.Value.ToString());
		}

        #endregion

        #region Panel de comentarios

        // Eventos del panel Action (Agregar comentarios)

		protected void AgregarComentarioButton_Click(object sender, EventArgs e){
			try {

				// Agregar el comentario
				InsertComentarioAtencion();

				// Actualizar el expediente
				BuscarAtencion();

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

        #endregion

    }
}