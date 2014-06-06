using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visDetalleExpediente : System.Web.UI.Page
    {
        // Utilerías
        Function utilFunction = new Function();

        #region "Event"
            protected void AcuerdoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAcuerdoCalifDefinitiva.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void AgregarComentarioButton_Click(object sender, EventArgs e)
            {

            }

            protected void AgregarComentarioLink_Click(object sender, EventArgs e)
            {

            }

            protected void AsignarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAsignarVisitador.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void CiudadanosGrid_RowCommand(object sender, GridViewCommandEventArgs e)
            {

            }

            protected void CiudadanosGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {

            }

            protected void CiudadanosGrid_Sorting(object sender, GridViewSortEventArgs e)
            {

            }

            protected void CloseWindowButton_Click(object sender, ImageClickEventArgs e)
            {
                //txtAsuntoSolicitud.Text = String.Empty;
                //pnlAction.Visible = false;
            }

            protected void ComparecenciaPanel_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visComparecencia.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeDiligenciaExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void DocumentoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visAgregarDocumento.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void DocumentList_ItemDataBound(Object sender, DataListItemEventArgs e)
            {

            }

            protected void EnviarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visEnviarExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }

            protected void RecomendacionButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visRecomendacionExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void ResolucionButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visResolucionExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visSeguimientoExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }
        #endregion

        #region "Method"
            private int GetExpedienteParameter()
            {
                try
                {
                    return int.Parse(Request.QueryString["expId"].ToString());
                }
                catch
                {
                    return 0;
                }
            }

            private void PageLoad()
            {
                int ExpedienteId = 0;

                if (Page.IsPostBack)
                    return;

                SetPermisos();
                
                ExpedienteId = GetExpedienteParameter();

                SelectExpediente(ExpedienteId);
                SelectExpedienteCiudadano(ExpedienteId);
                SelectExpedienteRepositorio(int.Parse(SolicitudIdHidden.Value));
                SelectExpedienteComentario(ExpedienteId);

                ExpedienteIdHidden.Value = ExpedienteId.ToString();
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

                        SolicitudIdHidden.Value = oENTExpediente.ResultData.Tables[0].Rows[0]["SolicitudId"].ToString();
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(BPExpediente.ErrorDescription) + "', 'Error', true);", true);
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oBPExpediente.ErrorDescription) + "', 'Error', true);", true);
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteProcess.ErrorDescription) + "', 'Fail', true);", true);
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
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(RepositorioProcess.ErrorDescription) + "', 'Fail', true);", true);
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
        #endregion
    }
}