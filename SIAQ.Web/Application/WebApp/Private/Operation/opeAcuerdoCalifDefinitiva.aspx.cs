using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;


namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAcuerdoCalifDefinitiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENTSession oENTSession;
            string expedienteId = GetRawQueryParameter("expId");
            hdnExpedienteId.Value = expedienteId;

            oENTSession = (ENTSession)this.Session["oENTSession"];

            if (Page.IsPostBack) { return; }

            LlenarDetalle(expedienteId, oENTSession.FuncionarioId.ToString());
        }

        #region Atributos

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        #region "Botones"

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            string expedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(expedienteId)) { expedienteId = GetRawQueryParameter("expId"); }

            ENTSession oENTSession;
            oENTSession = (ENTSession)this.Session["oENTSession"];

            try
            {
                GuardarCalificacionDefinitiva(expedienteId, oENTSession.FuncionarioId, txtAsuntoSolicitud.Text);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage(' " + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            string expedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(expedienteId)) { expedienteId = GetRawQueryParameter("expId"); }

            Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeDetalleExpedienteVisitador.aspx?expId=" + expedienteId);
        }

        #endregion

        #endregion

        #region Funciones

        public string GetRawQueryParameter(string parameterName)
        {
            string raw = Request.RawUrl;
            int startQueryIdx = raw.IndexOf('?');
            if (startQueryIdx < 0)
                return null;

            int nameLength = parameterName.Length + 1;
            int startIdx = raw.IndexOf(parameterName + "=", startQueryIdx);
            if (startIdx < 0)
                return null;

            startIdx += nameLength;
            int endIdx = raw.IndexOf('&', startIdx);
            if (endIdx < 0)
                endIdx = raw.Length;

            return raw.Substring(startIdx, endIdx - startIdx);
        }

        public void GuardarCalificacionDefinitiva(string expedienteId, int funcionarioId, string acuerdo)
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTResponse oENTResponse = new ENTResponse();
            ENTExpediente oENTExpediente = new ENTExpediente();

            if (String.IsNullOrEmpty(acuerdo))
            {
                throw (new Exception("Campo [Acuerdo calificación definitiva] requerido"));
            }

            try
            {
                //Formulario
                oENTExpediente.ExpedienteId = Convert.ToInt32(expedienteId);
                oENTExpediente.FuncionarioId = funcionarioId;
                oENTExpediente.Acuerdo = acuerdo;

                //Transacción
                oENTResponse = oBPExpediente.InsertAcuerdoCalificacionDefinitiva(oENTExpediente);

                //Validación
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                //Actualizar datos 
                txtAsuntoSolicitud.Text = "";
                txtAsuntoSolicitud.Focus();

                // Mensaje al usuario 
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Acuerdo registrado con éxito','Success', true);"
                    , true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void LlenarDetalle(string ExpedienteId, string FuncionarioId)
        {
            BPExpediente BPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();

            if (String.IsNullOrEmpty(ExpedienteId))
            {
                ExpedienteId = "0";
            }
            if (String.IsNullOrEmpty(FuncionarioId))
            {
                FuncionarioId = "0";
            }

            oENTExpediente.ExpedienteId = Convert.ToInt32(ExpedienteId);
            oENTExpediente.FuncionarioId = Convert.ToInt32(FuncionarioId);

            BPExpediente.SelectDetalleExpediente(oENTExpediente);

            if (BPExpediente.ErrorId == 0)
            {
                // Detalle 
                if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                {
                    SolicitudLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                    CalificacionLlabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Calificacion"].ToString();
                    EstatusaLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                    VisitadorLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Visitador"].ToString();
                    FormaContactoLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["FormaContacto"].ToString();
                    TipoSolicitudLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["TipoSolicitud"].ToString();
                    ObservacionesLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
                    LugarHechosLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["LugarHechos"].ToString();
                    DireccionHechos.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

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
        }

        #endregion

    }
}