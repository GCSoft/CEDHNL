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
    public partial class visImprmirExpediente : System.Web.UI.Page
    {
        // Utilerías
		GCJavascript gcJavascript = new GCJavascript();

        #region "Events"
            protected void DocumentList_ItemDataBound(Object sender, DataListItemEventArgs e)
            {
                DocumentListItemDataBound(e);
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
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

                ExpedienteId = GetExpedienteParameter();

                SelectExpediente(ExpedienteId);
                SelectExpedienteCiudadano(ExpedienteId);
                SelectExpedienteRepositorio(int.Parse(SolicitudIdHidden.Value));

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
        #endregion
    }
}