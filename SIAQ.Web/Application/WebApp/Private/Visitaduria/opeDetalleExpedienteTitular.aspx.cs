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
    public partial class opeDetalleExpedienteTitular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ENTSession oENTSession;

                oENTSession = (ENTSession)this.Session["oENTSession"];

                string ExpedienteId = GetRawQueryParameter("expId");
                hdnExpedienteId.Value = ExpedienteId;

                LlenarCiudadanos(ExpedienteId);
                LlenarAutoridades(ExpedienteId);
                LlenarDetalle(ExpedienteId, oENTSession.FuncionarioId.ToString());
            }
        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        #region "GridView Ciudadano"

        protected void gvCiudadanos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");
                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvCiudadanos_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableExpediente = null;
            DataView ViewExpediente = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableExpediente = utilFunction.ParseGridViewToDataTable(gvCiudadanos, false);
                ViewExpediente = new DataView(TableExpediente);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewExpediente.Sort = hddSort.Value;

                //Vaciar datos
                gvCiudadanos.DataSource = ViewExpediente;
                gvCiudadanos.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #endregion

        #region "GridView Autoridades"

        protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvAutoridades_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableExpediente = null;
            DataView ViewExpediente = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableExpediente = utilFunction.ParseGridViewToDataTable(gvAutoridades, false);
                ViewExpediente = new DataView(TableExpediente);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewExpediente.Sort = hddSort.Value;

                //Vaciar datos
                gvAutoridades.DataSource = ViewExpediente;
                gvAutoridades.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #endregion

        #region "Botones"

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            string sExpedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(sExpedienteId)) { sExpedienteId = "0"; }
            int iExpedienteId = Convert.ToInt32(sExpedienteId);

            try
            {
                GuardarInformacionExpediente(txtAsuntoSolicitud.Text, iExpedienteId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    + "focusControl('" + this.txtAsuntoSolicitud.ClientID + "');", true);
            }

        }

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstExpedientesTitular.aspx");
        }

        #endregion

        #region "Submenu"

        protected void InformacionGeneralVisitadorButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstExpedientesTitular.aspx");
        }

        protected void AprobarCalificacionButton_Click(object sender, ImageClickEventArgs e)
        {
            //TO DO: Pendiente de crear html de la pagina de aprobar calificación
        }

        protected void AsignarVisitadorButton_Click(object sender, ImageClickEventArgs e)
        {
            string sExpedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(sExpedienteId)) { sExpedienteId = GetRawQueryParameter("expId"); }

            Response.Redirect("~/Application/WebApp/Private/Operation/opeAsignarVisitador.aspx?expId=" + sExpedienteId);
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

        protected void LlenarCiudadanos(string ExpedienteId)
        {
            ENTExpediente oENTExpediente = new ENTExpediente();
            BPExpediente oBPExpediente = new BPExpediente();

            if (String.IsNullOrEmpty(ExpedienteId))
            {
                ExpedienteId = "0";
            }

            oENTExpediente.ExpedienteId = Convert.ToInt32(ExpedienteId);

            oBPExpediente.SelectCiudadanosGrid(oENTExpediente);

            if (oBPExpediente.ErrorId == 0)
            {
                if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvCiudadanos.DataSource = oENTExpediente.ResultData;
                    gvCiudadanos.DataBind();
                }
                else
                {
                    gvCiudadanos.DataSource = null;
                    gvCiudadanos.DataBind();
                }
            }
            else
            {
                gvCiudadanos.DataSource = null;
                gvCiudadanos.DataBind();
            }

        }

        protected void LlenarAutoridades(string ExpedienteId)
        {
            BPExpediente BPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();

            if (String.IsNullOrEmpty(ExpedienteId))
            {
                ExpedienteId = "0";
            }

            oENTExpediente.ExpedienteId = Convert.ToInt32(ExpedienteId);
            BPExpediente.SelectAutoridadesGrid(oENTExpediente);

            if (BPExpediente.ErrorId == 0)
            {
                if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvAutoridades.DataSource = oENTExpediente.ResultData;
                    gvAutoridades.DataBind();
                }
                else
                {
                    gvAutoridades.DataSource = null;
                    gvAutoridades.DataBind();
                }
            }
            else
            {
                gvAutoridades.DataSource = null;
                gvAutoridades.DataBind();
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

        private void GuardarInformacionExpediente(string Observaciones, int ExpedienteId)
        {
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();
            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];
            BPExpediente oBPExpediente = new BPExpediente();

            if (String.IsNullOrEmpty(txtAsuntoSolicitud.Text))
            {
                throw new Exception("* El campo [Asunto de la solicitud] es requerido");
            }

            try
            {
                //Formulario 
                oENTExpediente.ExpedienteId = ExpedienteId;
                oENTExpediente.Observaciones = Observaciones;

                //Transacción
                oENTResponse = oBPExpediente.UpdateObservaciones_Expediente(oENTExpediente);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                //Actualizar datos 
                txtAsuntoSolicitud.Text = String.Empty;
                LlenarDetalle(ExpedienteId.ToString(), oENTSession.FuncionarioId.ToString());

                // Mensaje de usuario
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Información guardada con éxito', 'Success', true);"
                    , true);
            }
            catch (Exception ex) { throw (ex); }
        }


        #endregion

    }
}