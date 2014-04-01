using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;


namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDiligenciaRecomendacion : System.Web.UI.Page
    {

        #region Atributos

        Function utilFunction = new Function();
        protected string RecomendacionId;
        protected string NumeroRecomendacion;

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            RecomendacionId = GetRawQueryParameter("recId");
            NumeroRecomendacion = GetRawQueryParameter("numRec");

            ComboFuncionariosEjecuta();
            ComboLugarDiligencia();
            ComboTipoDiligencia();
            GridDiligencias(RecomendacionId);
            LlenarDetalle(NumeroRecomendacion);
        }

        #region "Grid diligencias"

        protected void gvDiligenciasRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDiligenciasRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String sImagesAttributes = "";
            String sToolTip = "";
            String sNumeroDiligencia = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                sNumeroDiligencia = gvDiligenciasRecomendacion.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

                //Tooltip Edición
                sToolTip = "Editar diligencia [" + sNumeroDiligencia + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvDiligenciasRecomendacion_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableExpediente = null;
            DataView ViewExpediente = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableExpediente = utilFunction.ParseGridViewToDataTable(gvDiligenciasRecomendacion, false);
                ViewExpediente = new DataView(TableExpediente);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewExpediente.Sort = hddSort.Value;

                //Vaciar datos
                gvDiligenciasRecomendacion.DataSource = ViewExpediente;
                gvDiligenciasRecomendacion.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #endregion

        #region "Botones

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

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

        private void ComboFuncionariosEjecuta()
        {
            BPFuncionario oBPFuncionario = new BPFuncionario();

            oBPFuncionario.SelectFuncionarioVistaduria();

            if (oBPFuncionario.ErrorId == 0)
            {
                if (oBPFuncionario.FuncionarioEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    ddlVisitadorEjecuta.DataSource = oBPFuncionario.FuncionarioEntity.ResultData;
                    ddlVisitadorEjecuta.DataTextField = "FuncionarioNombre";
                    ddlVisitadorEjecuta.DataValueField = "FuncionarioId";
                    ddlVisitadorEjecuta.DataBind();
                }
            }
        }

        private void ComboLugarDiligencia()
        {
            BPDiligencia oBPDiligencia = new BPDiligencia();

            oBPDiligencia.SelectLugarDiligencias();

            if (oBPDiligencia.ErrorId == 0)
            {
                if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
                {
                    ddlLugarDiligencia.DataSource = oBPDiligencia.DiligenciaEntity.DataResult;
                    ddlLugarDiligencia.DataTextField = "Nombre";
                    ddlLugarDiligencia.DataValueField = "LugarDiligenciaId";
                    ddlLugarDiligencia.DataBind();
                }
            }
        }

        private void ComboTipoDiligencia()
        {
            BPDiligencia oBPDiligencia = new BPDiligencia();

            oBPDiligencia.SelectTipoDiligencias();

            if (oBPDiligencia.ErrorId == 0)
            {
                if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
                {
                    ddlTipoDiligencia.DataSource = oBPDiligencia.DiligenciaEntity.DataResult;
                    ddlTipoDiligencia.DataTextField = "Nombre";
                    ddlTipoDiligencia.DataValueField = "TipoDiligenciaId";
                    ddlTipoDiligencia.DataBind();
                }
            }
        }

        private void GridDiligencias(string ExpedienteId)
        {
            BPDiligencia oBPDiligencias = new BPDiligencia();

            oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(ExpedienteId);
            oBPDiligencias.SelectDiligencias();

            if (oBPDiligencias.ErrorId == 0)
            {
                if (oBPDiligencias.DiligenciaEntity.DataResult.Tables[2].Rows.Count > 0)
                {
                    gvDiligenciasRecomendacion.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[2];
                    gvDiligenciasRecomendacion.DataBind();
                }
                else
                {
                    gvDiligenciasRecomendacion.DataSource = null;
                    gvDiligenciasRecomendacion.DataBind();
                }
            }
            else
            {
                gvDiligenciasRecomendacion.DataSource = null;
                gvDiligenciasRecomendacion.DataBind();
            }
        }

        private void LlenarDetalle(string numeroRecomendacion)
        {
            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];


            SolicitudLabel.Text = numeroRecomendacion;
            VisitadorAtiendeLabel.Text = oENTSession.sNombre;
            FechaRegistroLabel.Text = DateTime.Now.ToShortDateString();
        }

        #endregion

    }
}