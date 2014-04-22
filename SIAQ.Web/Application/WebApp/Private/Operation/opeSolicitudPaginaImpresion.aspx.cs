using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;


namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeSolicitudPaginaImpresion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            //Obtener detalle 
            string solicitudId = Request.QueryString["s"];
            ObtenerDetalle(Convert.ToInt32(solicitudId));
            SelectComentario(Convert.ToInt32(solicitudId));
        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades

        #endregion

        #region Funciones

        private void ObtenerDetalle(int solicitudId)
        {
            BPSolicitud SolicitudProcess = new BPSolicitud();

            SolicitudProcess.SolicitudEntity.SolicitudId = solicitudId;

            SolicitudProcess.SelectSolicitudDetalle();

            if (SolicitudProcess.ErrorId == 0)
            {
                if (SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    SolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                    CalificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreCalificacion"].ToString();
                    EstatusaLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreEstatus"].ToString();
                    FuncionarioLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreFuncionario"].ToString();
                    ContactoLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreContacto"].ToString();
                    TipoSolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreTipoSolicitud"].ToString();
                    LugarHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["LugarHechosId"].ToString();
                    DireccionHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();
                    ObservacionesLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
            }
        }

        private void SelectComentario(int SolicitudId)
        {
            BPSolicitud SolicitudProcess = new BPSolicitud();

            SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

            SolicitudProcess.SelectSolicitudComentario();

            if (SolicitudProcess.ErrorId == 0)
            {
                if (SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows.Count == 0)
                    SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
                else
                    SinComentariosLabel.Text = "";

                ComentarioRepeater.DataSource = SolicitudProcess.SolicitudEntity.ResultData.Tables[0];
                ComentarioRepeater.DataBind();

                ComentarioTituloLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows.Count.ToString() + " comentarios";
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
        }

        #endregion

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            string SolicitudId = Request.QueryString["s"];
            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + SolicitudId);
        }

        #region Eventos

        #endregion

    }
}