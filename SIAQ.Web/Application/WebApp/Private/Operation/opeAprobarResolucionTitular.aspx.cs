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
    public partial class opeAprobarResolucionTitular : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];

            sExpedienteId = GetRawQueryParameter("expId");
            hdnExpedienteId.Value = sExpedienteId;

            LlenarCiudadanos(sExpedienteId);
            LlenarAutoridades(sExpedienteId);
            LlenarDetalle(sExpedienteId, oENTSession.FuncionarioId.ToString());
        }

        #region Atributos

        Function utilFunction = new Function();
        string sExpedienteId;


        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        #region "Botones"

        protected void btnAprobarResolucion_Click(object sender, EventArgs e)
        {
            string expedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(expedienteId)) { expedienteId = GetRawQueryParameter("expId"); }

            try
            {
                AprobarResolucion(Convert.ToInt32(expedienteId));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        protected void btnRechazarResolucion_Click(object sender, EventArgs e)
        {
            string expedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(expedienteId)) { expedienteId = GetRawQueryParameter("expId"); }

            try
            {
                RechazarResolucion(Convert.ToInt32(expedienteId));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        #endregion

        #region "Grid Ciudadanos"

        protected void gvCiudadanos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ExpedienteId = String.Empty;
            int intRow = 0;
            string ciudadanoId = String.Empty;

            try
            {
                // Opción seleccionada 
                string sCommandName = e.CommandName.ToString();

                if (sCommandName == "Sort") { return; }

                // Fila
                intRow = Convert.ToInt32(e.CommandArgument.ToString());

                //Ciudadano Id 
                ciudadanoId = gvCiudadanos.DataKeys[intRow]["CiudadanoId"].ToString();
                ExpedienteId = hdnExpedienteId.Value;
                if (String.IsNullOrEmpty(ExpedienteId)) { ExpedienteId = GetRawQueryParameter("expid"); }

                switch (sCommandName)
                {
                    case "Borrar":
                        EliminarCiudadano(ciudadanoId, Convert.ToInt32(ExpedienteId));
                        break;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAsuntoSolicitud.ClientID + "');", true);
            }
        }

        protected void gvCiudadanos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                //Tooltip Edición
                sToolTip = "Eliminar ciudadano";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

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

        #region "Grid Autoridades"

        protected void gvAutoridades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ExpedienteId = String.Empty;
            int intRow = 0;
            string AutoridadId = String.Empty;

            try
            {
                // Opción seleccionada 
                string sCommandName = e.CommandName.ToString();

                if (sCommandName == "Sort") { return; }

                // Fila
                intRow = Convert.ToInt32(e.CommandArgument.ToString());

                //Ciudadano Id 
                AutoridadId = gvAutoridades.DataKeys[intRow]["AutoridadId"].ToString();
                ExpedienteId = hdnExpedienteId.Value;

                switch (sCommandName)
                {
                    case "Borrar":
                        EliminarAutoridad(Convert.ToInt32(ExpedienteId), Convert.ToInt32(AutoridadId));
                        break;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAsuntoSolicitud.ClientID + "');", true);
            }
        }

        protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                //Tooltip Edición
                sToolTip = "Eliminar autoridad";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

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

        #endregion

        #region Funciones

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

        private void EliminarCiudadano(string ciudadanoId, int expedienteId)
        {
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            BPExpediente oBPExpediente = new BPExpediente();

            try
            {
                //Formulario 
                oENTExpediente.ExpedienteId = expedienteId;
                oENTExpediente.Ciudadano = ciudadanoId;

                //Transacción 
                oENTResponse = oBPExpediente.DeleteCiudadano_Expediente(oENTExpediente);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                //Actualzar datos 
                LlenarCiudadanos(expedienteId.ToString());
            }
            catch (Exception ex) { throw (ex); }
        }

        private void EliminarAutoridad(int expedienteId, int autoridadId)
        {
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            BPExpediente oBPExpediente = new BPExpediente();

            try
            {
                //Formulario 
                oENTExpediente.ExpedienteId = expedienteId;
                oENTExpediente.AutoridadId = autoridadId;

                //Transacción 
                oENTResponse = oBPExpediente.DeleteAutoridad_Expediente(oENTExpediente);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                //Actualizar datos 
                LlenarAutoridades(expedienteId.ToString());
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void AprobarResolucion(int expedienteId)
        {
            ENTExpediente oENTExpediente = new ENTExpediente();
            BPExpediente oBPExpediente = new BPExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Formulario 
                oENTExpediente.ExpedienteId = expedienteId;

                //Transacción 
                oBPExpediente.AprobarResolucionTitular(oENTExpediente);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                //Mensaje Usuario 
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Resolución aprobada', 'Success', true);"
                    , true);

            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void RechazarResolucion(int expedienteId)
        {
            ENTExpediente oENTExpediente = new ENTExpediente();
            BPExpediente oBPExpediente = new BPExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Formulario 
                oENTExpediente.ExpedienteId = expedienteId;

                //Transacción 
                oBPExpediente.RechazarResolucionTitular(oENTExpediente);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                //Mensaje Usuario 
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Resolución rechazada', 'Success', true);"
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
                    EstatusaLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
                    VisitadorLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Visitador"].ToString();
                    TipoResolucionLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["TipoResolucion"].ToString();
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
                    FechaInicioGestionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
                    //FechaResolucionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0][""].ToString();
                }
            }
        }

        #endregion

    }
}