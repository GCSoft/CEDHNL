using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCUtility.Function;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visDetalleExpediente : System.Web.UI.Page
    {
        bool IsReadOnly = false;
		GCJavascript gcJavascript = new GCJavascript();


		protected void Page_Load(object sender, EventArgs e){
			ENTSession SessionEntity = new ENTSession();

			int ExpedienteId = 0;

            try
            {

                // Validaciones
                if (Page.IsPostBack) { return; }
                if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
                if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener AtencionId
				this.hddExpedienteId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
                this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

                switch (this.SenderId.Value){
					case "1": // Invocado desde [Listado de Expedientes]
						this.Sender.Value = "VisListadoExpedientes.aspx";
                        break;

					case "2": // Invocado desde [Búsqueda de Solicitudes]
						this.Sender.Value = "VisBusquedaExpedientes.aspx";
						break;

					//case "3": // Invocado desde [Registrar solicitud ]
					//    this.Sender.Value = "../Operation/opeRegistroSolicitud.aspx?key=0|0";
					//    break;

                    default:
                        this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
                        return;
                }

				//// Obtener sesión
				//SessionEntity = (ENTSession)Session["oENTSession"];

				//// Consultar detalle de la Solicitud de Quejas
				//SelectSolicitud();

				//// Seguridad
				//SetPermisosGenerales(SessionEntity.idRol);
				//SetPermisosParticulares(SessionEntity.idRol, SessionEntity.FuncionarioId);

				SetPermisos();

				ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);

				ValidarExpediente(ExpedienteId);
				SelectExpediente(ExpedienteId);
				SelectExpedienteCiudadano(ExpedienteId);
				SelectExpedienteRepositorio(int.Parse(this.hddExpedienteId.Value));
				SelectExpedienteComentario(ExpedienteId);

				this.hddExpedienteId.Value = ExpedienteId.ToString();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}


        #region "Event"
           

            protected void AgregarComentarioButton_Click(object sender, EventArgs e)
            {

            }

            protected void AgregarComentarioLink_Click(object sender, EventArgs e)
            {

            }

            

            protected void CiudadanosGrid_RowCommand(object sender, GridViewCommandEventArgs e)
            {

            }

            protected void CiudadanosGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                CiudadanosGridRowDataBound(e);
            }

            protected void CiudadanosGrid_Sorting(object sender, GridViewSortEventArgs e)
            {

            }

            protected void CloseWindowButton_Click(object sender, ImageClickEventArgs e)
            {
                //txtAsuntoSolicitud.Text = String.Empty;
                //pnlAction.Visible = false;
            }

            protected void DocumentList_ItemDataBound(Object sender, DataListItemEventArgs e)
            {
                DocumentListItemDataBound(e);
            }
            
        #endregion

        #region "Method"
            private void CiudadanosGridRowDataBound(GridViewRowEventArgs e)
            {
                ImageButton DeleteImage;

                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                    return;

                DeleteImage = (ImageButton)e.Row.FindControl("DeleteImage");

                if (DeleteImage == null)
                    return;

                if(IsReadOnly)
                    DeleteImage.Enabled = false;
            }

            private void DocumentListItemDataBound(DataListItemEventArgs e)
            {
                HyperLink DocumentoLink;
                Image DocumentoImage;
                DataRowView DataRow;

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
                    DocumentoLink = (HyperLink)e.Item.FindControl("DocumentoLink");

                    DataRow = (DataRowView)e.Item.DataItem;

                    //DocumentoImage.ImageUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.cs?R=SE&id=" + DataRow["RepositrioId"].ToString();
                    DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
                    DocumentoLink.NavigateUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=" + DataRow["SolicitudId"].ToString();
                    DocumentoLink.Text = DataRow["NombreDocumento"].ToString();
                }
            }

            private void SelectExpediente(int ExpedienteId)
            {
                ENTSession UsuarioEntity = new ENTSession();

                UsuarioEntity = (ENTSession)Session["oENTSession"];

                SelectExpediente(ExpedienteId, UsuarioEntity.FuncionarioId);
            }

            private void SelectExpediente(int ExpedienteId, int FuncionarioId)
            {
                BPExpediente BPExpediente = new BPExpediente();
                ENTExpediente oENTExpediente = new ENTExpediente();

                oENTExpediente.ExpedienteId = ExpedienteId;
                oENTExpediente.FuncionarioId = FuncionarioId;

                BPExpediente.SelectDetalleExpediente(oENTExpediente);

                if (BPExpediente.ErrorId == 0)
                {
                    // Detalle 
                    if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ExpedienteIdLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                        CalificacionLlabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Calificacion"].ToString();
                        EstatusaLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                        VisitadorLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Visitador"].ToString();
                        FormaContactoLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["FormaContacto"].ToString();
                        TipoSolicitudLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["TipoSolicitud"].ToString();
                        ObservacionesLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                        LugarHechosLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["LugarHechos"].ToString();
                        DireccionHechos.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

                        this.hddExpedienteId.Value = oENTExpediente.ResultData.Tables[0].Rows[0]["SolicitudId"].ToString();
                    }

                    //Fechas
                    if (oENTExpediente.ResultData.Tables[1].Rows.Count > 0)
                    {
                        FechaRecepcionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
                        FechaAsignacionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
                        FechaGestionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
                        FechaModificacionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString();
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(BPExpediente.ErrorDescription) + "');", true);
            }

            private void SelectExpedienteCiudadano(int ExpedienteId)
            {
                ENTExpediente oENTExpediente = new ENTExpediente();
                BPExpediente oBPExpediente = new BPExpediente();

                oENTExpediente.ExpedienteId = ExpedienteId;

                oBPExpediente.SelectCiudadanosGrid(oENTExpediente);

                if (oBPExpediente.ErrorId == 0)
                {
                    CiudadanosGrid.DataSource = oENTExpediente.ResultData;
                    CiudadanosGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oBPExpediente.ErrorDescription) + "');", true);
            }

            private void SelectExpedienteComentario(int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();

                ExpedienteProcess.ExpedienteEntity.ExpedienteId = ExpedienteId;

                ExpedienteProcess.SelectExpedienteComentario();

                if (ExpedienteProcess.ErrorId == 0)
                {
                    if (ExpedienteProcess.ExpedienteEntity.ResultData.Tables[0].Rows.Count == 0)
                        SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
                    else
                        SinComentariosLabel.Text = "";

                    ComentarioRepeater.DataSource = ExpedienteProcess.ExpedienteEntity.ResultData.Tables[0];
                    ComentarioRepeater.DataBind();

                    ComentarioTituloLabel.Text = ExpedienteProcess.ExpedienteEntity.ResultData.Tables[0].Rows.Count.ToString() + " comentarios";
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ExpedienteProcess.ErrorDescription) + "');", true);
            }

            private void SelectExpedienteRepositorio(int SolicitudId)
            {
                BPDocumento RepositorioProcess = new BPDocumento();

                RepositorioProcess.DocumentoEntity.SolicitudId = SolicitudId;

                RepositorioProcess.SelectRepositorioSE();

                if (RepositorioProcess.ErrorId == 0)
                {
                    if (RepositorioProcess.DocumentoEntity.ResultData.Tables[0].Rows.Count == 0)
                        SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados al expediente";
                    else
                        SinDocumentoLabel.Text = "";

                    DocumentoList.DataSource = RepositorioProcess.DocumentoEntity.ResultData;
                    DocumentoList.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(RepositorioProcess.ErrorDescription) + "');", true);
            }

            private void SetPermisos()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                if (SessionEntity == null)
                    return;

                switch (SessionEntity.idRol)
                {
                    case 1:
                    case 2:
                        AsignarPanel.Visible = true;
                        AcuerdoPanel.Visible = true;
                        DiligenciaPanel.Visible = true;
                        DocumentoPanel.Visible = true;
                        SeguimientoPanel.Visible = true;
                        ComparecenciaPanel.Visible = true;
                        ResolucionPanel.Visible = true;
                        RecomendacionPanel.Visible = true;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = true;
                        break;

                    case 7:
                        AsignarPanel.Visible = true;
                        AcuerdoPanel.Visible = false;
                        DiligenciaPanel.Visible = false;
                        DocumentoPanel.Visible = false;
                        SeguimientoPanel.Visible = false;
                        ComparecenciaPanel.Visible = false;
                        ResolucionPanel.Visible = false;
                        RecomendacionPanel.Visible = false;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = false;
                        break;

                    case 8:
                        AsignarPanel.Visible = false;
                        AcuerdoPanel.Visible = true;
                        DiligenciaPanel.Visible = true;
                        DocumentoPanel.Visible = true;
                        SeguimientoPanel.Visible = true;
                        ComparecenciaPanel.Visible = true;
                        ResolucionPanel.Visible = true;
                        RecomendacionPanel.Visible = true;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = true;
                        break;

                    case 9:
                        AsignarPanel.Visible = true;
                        AcuerdoPanel.Visible = false;
                        DiligenciaPanel.Visible = false;
                        DocumentoPanel.Visible = false;
                        SeguimientoPanel.Visible = false;
                        ComparecenciaPanel.Visible = false;
                        ResolucionPanel.Visible = false;
                        RecomendacionPanel.Visible = false;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = false;
                        break;

                    default:
                        AsignarPanel.Visible = false;
                        AcuerdoPanel.Visible = false;
                        DiligenciaPanel.Visible = false;
                        DocumentoPanel.Visible = false;
                        SeguimientoPanel.Visible = false;
                        ComparecenciaPanel.Visible = false;
                        ResolucionPanel.Visible = false;
                        RecomendacionPanel.Visible = false;
                        ImprimirPanel.Visible = false;
                        EnviarPanel.Visible = false;
                        break;
                }
            }

            private void ValidarExpediente(int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();

                ExpedienteProcess.SelectExpedienteEstatus(ExpedienteId);

                if (ExpedienteProcess.ErrorId != 0)
                {
                    IsReadOnly = true;
                    return;
                }

                if (ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.POR_ASIGNAR_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.POR_ATENDER_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.EN_PROCESO_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.PENDIENTE_APROBAR_ESTATUS)
                {
                    IsReadOnly = true;
                    return;
                }
            }
        #endregion


		// Opciones de Menu (en orden de aparación)

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visDetalleExpediente.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("~/Application/WebApp/Private/Operation/opeAsignarVisitador.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void AcuerdoButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("~/Application/WebApp/Private/Operation/opeAcuerdoCalifDefinitiva.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("~/Application/WebApp/Private/Operation/opeDiligenciaExpediente.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void DocumentoButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visAgregarDocumento.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visSeguimientoExpediente.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void ComparecenciaPanel_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visComparecencia.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void ResolucionButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visResolucionExpediente.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void RecomendacionButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visRecomendacionExpediente.aspx?expId=" + this.hddExpedienteId.Value);
		}

		protected void EnviarButton_Click(object sender, ImageClickEventArgs e){
			Response.Redirect("visEnviarExpediente.aspx?expId=" + this.hddExpedienteId.Value);
		}



    }
}