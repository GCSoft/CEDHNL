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
    public partial class opeDiligenciaSolicitud : System.Web.UI.Page
    {

		private void SelectSolicitud()
		{
			BPSolicitud SolicitudProcess = new BPSolicitud();
			int SolicitudId;

			// 
			SolicitudId = Int32.Parse(hdnSolicitudId.Value);

			SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

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
					ObservacionesLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
					LugarHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreLugarHechos"].ToString();
					DireccionHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();
				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
			}
		}

        #region Atributos

        Function utilFunction = new Function();
        protected string SolicitudId;
        protected string NumeroSolicitud;

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            SolicitudId = GetRawQueryParameter("solId");
            NumeroSolicitud = GetRawQueryParameter("numSol");

            hdnSolicitudId.Value = SolicitudId;

            ComboFuncionariosEjecuta();
            ComboLugarDiligencia();
            ComboTipoDiligencia();
            GridDiligencias(SolicitudId);
            LlenarDetalle(NumeroSolicitud);

			// consultar la carátula
			SelectSolicitud();

			// Foco
			ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlVisitadorEjecuta.ClientID + "'); }", true);

        }

        #region "Grid diligencias"

        protected void gvDiligenciasSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string SolicitudId = string.Empty;
            string DiligenciaId = string.Empty;
            int intRow = 0;

            try
            {
                string sCommandName = e.CommandName.ToString();

                if (sCommandName == "Sort") { return; }

                //Fila 
                intRow = Convert.ToInt32(e.CommandArgument.ToString());

                // SolicitudId 
                SolicitudId = hdnSolicitudId.Value;
                if (String.IsNullOrEmpty(SolicitudId)) { SolicitudId = GetRawQueryParameter("solId"); }
                DiligenciaId = gvDiligenciasSolicitud.DataKeys[intRow]["DiligenciaId"].ToString();

                switch (sCommandName)
                {
                    case "Editar":
                        MostrarDatosEdicion(SolicitudId, DiligenciaId);
                        break;

                    case "Borrar":
                        EliminarDiligencia(SolicitudId, DiligenciaId);
                        break;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvDiligenciasSolicitud_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            ImageButton imgDelete = null;

            String sImagesAttributes = "";
            String sToolTip = "";
            String sNumeroDiligencia = "";

            String sImagesAttributesDelete = "";
            String sToolTipDelete = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

                sNumeroDiligencia = gvDiligenciasSolicitud.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

                //Tooltip Edición
                sToolTip = "Editar diligencia [" + sNumeroDiligencia + "]";
                sToolTipDelete = "Eliminar diligencia [" + sNumeroDiligencia + "]";

                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "cursor:hand;");

                imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipDelete + "', 'Izq');");
                imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
                imgDelete.Attributes.Add("style", "cursor:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
                sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes + sImagesAttributesDelete);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
                sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes + sImagesAttributesDelete);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvDiligenciasSolicitud_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableSolicitud = null;
            DataView ViewSolicitud = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableSolicitud = utilFunction.ParseGridViewToDataTable(gvDiligenciasSolicitud, false);
                ViewSolicitud = new DataView(TableSolicitud);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewSolicitud.Sort = hddSort.Value;

                //Vaciar datos
                gvDiligenciasSolicitud.DataSource = ViewSolicitud;
                gvDiligenciasSolicitud.DataBind();

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
            if (String.IsNullOrEmpty(SolicitudId))
            {
                SolicitudId = hdnSolicitudId.Value;
            }

            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + SolicitudId);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string solicitudId = hdnSolicitudId.Value;
            if (String.IsNullOrEmpty(solicitudId)) { solicitudId = GetRawQueryParameter("solId"); }

            string diligenciaId = hdnDiligenciaId.Value;

            try
            {
                if (String.IsNullOrEmpty(diligenciaId))
                {
                    //Agregar
                    AgregarDiligencia(solicitudId);
                    GridDiligencias(solicitudId);
                    LimpiarControles();
                }
                else
                {
                    //Modificar
                    ModificarDiligencia(solicitudId, diligenciaId);
                    GridDiligencias(solicitudId);
                    LimpiarControles();
                }
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

            oBPFuncionario.SelectFuncionarioQuejas
                ();

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

        private void GridDiligencias(string solicitudId)
        {
            BPDiligencia oBPDiligencias = new BPDiligencia();

            oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(solicitudId);
            oBPDiligencias.SelectDiligencias();

            if (oBPDiligencias.ErrorId == 0)
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
            else
            {
                gvDiligenciasSolicitud.DataSource = null;
                gvDiligenciasSolicitud.DataBind();
            }
        }

        private void LlenarDetalle(string numeroSolicitud)
        {
            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];


            SolicitudLabel.Text = numeroSolicitud;
            VisitadorAtiendeLabel.Text = oENTSession.sNombre;
            FechaRegistroLabel.Text = DateTime.Now.ToShortDateString();
        }

        private void AgregarDiligencia(string solicitudId)
        {
            ENTResponse oENTResponse = new ENTResponse();
            ENTDiligencia oENTDiligencia = new ENTDiligencia();
            ENTSession oENTSession;

            oENTSession = (ENTSession)this.Session["oENTSession"];
            BPDiligencia oBPDiligencia = new BPDiligencia();

            if (ddlVisitadorEjecuta.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
            if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
            if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
            if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
            if (String.IsNullOrEmpty(txtCampo.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
            if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
            if (String.IsNullOrEmpty(txtResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

            try
            {
                //Formulario
                oENTDiligencia.SolicitudId = Convert.ToInt32(solicitudId);
                oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
                oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
				oENTDiligencia.FechaDiligencia = calFecha.BeginDate;
                oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
                oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
                oENTDiligencia.Detalle = txtCampo.Text;
                oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
                oENTDiligencia.Resultado = txtResultado.Text;

                //Transacción
                oENTResponse = oBPDiligencia.InsertDiligenciaSolicitud(oENTDiligencia);

                //Validación
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                //Mensaje de usuario
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Diligencia agregada con éxito', 'Success', false);"
                    , true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void ModificarDiligencia(string solicitudId, string diligenciaId)
        {
            ENTResponse oENTResponse = new ENTResponse();
            ENTDiligencia oENTDiligencia = new ENTDiligencia();
            BPDiligencia oBPDiligencia = new BPDiligencia();


            if (ddlVisitadorEjecuta.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
            if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
            if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
            if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
            if (String.IsNullOrEmpty(txtCampo.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
            if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
            if (String.IsNullOrEmpty(txtResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

            try
            {
                //Formulario
                oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
                oENTDiligencia.SolicitudId = Convert.ToInt32(solicitudId);
                oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
				oENTDiligencia.FechaDiligencia = calFecha.BeginDate;
                oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
                oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
                oENTDiligencia.Detalle = txtCampo.Text;
                oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
                oENTDiligencia.Resultado = txtResultado.Text;

                //Transacción
                oENTResponse = oBPDiligencia.UpdateDiligenciaSolicitud(oENTDiligencia);

                //Validación
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                //Mensaje usuario
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Diligencia modificada con éxito', 'Success', false);"
                    , true);

            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void EliminarDiligencia(string solicitudId, string diligenciaId)
        {
            ENTResponse oENTResponse = new ENTResponse();
            ENTDiligencia oENTDiligencia = new ENTDiligencia();
            BPDiligencia oBPDiligencia = new BPDiligencia();

            try
            {
                oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
                oENTDiligencia.SolicitudId = Convert.ToInt32(solicitudId);

                oENTResponse = oBPDiligencia.DeleteDiligenciaSolicitud(oENTDiligencia);

                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                GridDiligencias(solicitudId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LimpiarControles()
        {
            ddlVisitadorEjecuta.SelectedIndex = 0;
            calFecha.SetCurrentDate();
            ddlTipoDiligencia.SelectedIndex = 0;
            ddlLugarDiligencia.SelectedIndex = 0;
            txtCampo.Text = String.Empty;
            txtSolicitadaPor.Text = String.Empty;
            txtResultado.Text = String.Empty;
            hdnDiligenciaId.Value = String.Empty;

            ddlVisitadorEjecuta.Focus();

        }

        private void MostrarDatosEdicion(string solicitudId, string diligenciaId)
        {
            BPDiligencia oBPDiligencia = new BPDiligencia();

            oBPDiligencia.DiligenciaEntity.SolicitudId = Convert.ToInt32(solicitudId);
            oBPDiligencia.DiligenciaEntity.DiligenciaId = Convert.ToInt32(diligenciaId);

            oBPDiligencia.SelectDetalleDiligenciaSolicitud();

            if (oBPDiligencia.ErrorId == 0)
            {
                if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
                {
                    hdnDiligenciaId.Value = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["DiligenciaId"].ToString();
                    ddlVisitadorEjecuta.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FuncionarioEjecuta"].ToString();
                    calFecha.SetDate = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FechaDiligencia"].ToString();
                    ddlTipoDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["TipoDiligencia"].ToString();
                    ddlLugarDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["LugarDiligencia"].ToString();
                    txtCampo.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Detalle"].ToString();
                    txtSolicitadaPor.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["SolicitadaPor"].ToString();
                    txtResultado.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Resultado"].ToString();
                }
            }
        }

        #endregion

    }
}