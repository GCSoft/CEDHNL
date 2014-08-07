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
using GCUtility.Function;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDiligencias : System.Web.UI.Page
    {

        #region Atributos

		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

        protected string id;
        protected int tipo;

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            id = GetRawQueryParameter("id");
            tipo = Convert.ToInt32(GetRawQueryParameter("tip"));

            ComboFuncionariosEjecuta();
            ComboLugarDiligencia();
            ComboTipoDiligencia();
            GridDiligencias(tipo, id);
        }

        #region "Grid diligencias"

        #region "Solicitud"

        protected void gvDiligenciasSolicitud_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvDiligenciasSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDiligenciasSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        #endregion

        #region  "Expediente"

        protected void gvDiligenciasExpediente_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDiligenciasExpediente_RowDataBound(object sender, GridViewRowEventArgs e)
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

                sNumeroDiligencia = gvDiligenciasExpediente.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

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

        protected void gvDiligenciasExpediente_Sorting(object sender, GridViewSortEventArgs e){
            try
            {

				// Ordenar el Grid View
				gcCommon.SortGridView(ref this.gvDiligenciasExpediente, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #endregion

        #region "Recomendacion"

        protected void gvDiligenciasRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDiligenciasRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDiligenciasRecomendacion_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        #endregion

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

        private void GridDiligencias(int tipo, string id)
        {
            BPDiligencia oBPDiligencias = new BPDiligencia();

            switch (tipo)
            {
                case 1:// Solicitud 
                    pnlGridDiligenciasSolicitud.Visible = true;
                    pnlDiligenciaRecomendacion.Visible = false;
                    pnlDiligenciasExpediente.Visible = false;
                    break;
                case 2: // Expediente
                    pnlGridDiligenciasSolicitud.Visible = false;
                    pnlDiligenciaRecomendacion.Visible = false;
                    pnlDiligenciasExpediente.Visible = true;
                    break;
                case 3: // Recomendaciones
                    pnlGridDiligenciasSolicitud.Visible = false;
                    pnlDiligenciaRecomendacion.Visible = true;
                    pnlDiligenciasExpediente.Visible = false;
                    break;
            }

            oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(id);
            oBPDiligencias.SelectDiligencias();

            if (oBPDiligencias.ErrorId == 0)
            {
                if (tipo == 1)
                {
                    if (oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
                    {
                        gvDiligenciasSolicitud.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0];
                        gvDiligenciasSolicitud.DataBind();
                    }
                    else
                    {
                        gvDiligenciasSolicitud.DataSource = null;
                        gvDiligenciasSolicitud.DataBind();
                    }
                }

                else if (tipo == 2)
                {
                    if (oBPDiligencias.DiligenciaEntity.DataResult.Tables[1].Rows.Count > 0)
                    {
                        gvDiligenciasExpediente.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[1];
                        gvDiligenciasExpediente.DataBind();
                    }
                    else
                    {
                        gvDiligenciasExpediente.DataSource = null;
                        gvDiligenciasExpediente.DataBind();
                    }
                }

                else if (tipo == 3)
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

            }
            else
            {
                gvDiligenciasSolicitud.DataSource = null;
                gvDiligenciasSolicitud.DataBind();
                gvDiligenciasExpediente.DataSource = null;
                gvDiligenciasExpediente.DataBind();
                gvDiligenciasRecomendacion.DataSource = null;
                gvDiligenciasRecomendacion.DataBind();
            }
        }

        #endregion

    }
}