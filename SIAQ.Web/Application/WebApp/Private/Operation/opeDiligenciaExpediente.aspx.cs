using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

using GCUtility.Function;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;



namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDiligenciaExpediente : System.Web.UI.Page
    {

        #region Atributos

            bool IsReadOnly = false;
			GCCommon gcCommon = new GCCommon();
			GCJavascript gcJavascript = new GCJavascript();
            protected string ExpedienteId;

        #endregion

        #region Eventos

            protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack) { return; }

                ExpedienteId = GetRawQueryParameter("expId");

                ValidarExpediente(int.Parse(ExpedienteId));

                ComboFuncionariosEjecuta();
                ComboLugarDiligencia();
                ComboTipoDiligencia();
                GridDiligencias(ExpedienteId);
                LlenarDetalle(int.Parse(ExpedienteId));

                hdnExpedienteId.Value = ExpedienteId;
            }

        #region "Grid diligencias"

            protected void gvDiligenciasExpediente_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                string ExpedienteId = string.Empty;
                string DiligenciaId = string.Empty;
                int intRow = 0;

                try
                {
                    string sCommandName = e.CommandName.ToString();

                    if (sCommandName == "Sort") { return; }

                    //Fila 
                    intRow = Convert.ToInt32(e.CommandArgument.ToString());

                    // ExpedienteId 
                    ExpedienteId = hdnExpedienteId.Value;
                    if (String.IsNullOrEmpty(ExpedienteId)) { ExpedienteId = GetRawQueryParameter("expId"); }
                    DiligenciaId = gvDiligenciasExpediente.DataKeys[intRow]["DiligenciaId"].ToString();

                    switch (sCommandName)
                    {
                        case "Editar":
                            MostrarDatosEdicion(ExpedienteId, DiligenciaId);
                            break;

                        case "Borrar":
                            EliminarDiligencia(ExpedienteId, DiligenciaId);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
                }
            }

            protected void gvDiligenciasExpediente_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    sNumeroDiligencia = gvDiligenciasExpediente.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

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

            protected void gvDiligenciasExpediente_Sorting(object sender, GridViewSortEventArgs e){
				try
				{

					gcCommon.SortGridView(ref this.gvDiligenciasExpediente, ref this.hddSort, e.SortExpression);

				}catch (Exception ex){
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
                }
            }

        #endregion

        #region "Botones

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ExpedienteId))
            {
                ExpedienteId = hdnExpedienteId.Value;
            }

            Response.Redirect("~/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?expId=" + ExpedienteId);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string expedienteId = hdnExpedienteId.Value;
            if (String.IsNullOrEmpty(expedienteId)) { expedienteId = GetRawQueryParameter("expId"); }

            string diligenciaId = hdnDiligenciaId.Value;

            try
            {
                if (String.IsNullOrEmpty(diligenciaId))
                {
                    //Agregar
                    AgregarDiligencia(expedienteId);
                    GridDiligencias(expedienteId);
                    LimpiarControles();
                }
                else
                {
                    //Modificar
                    ModificarDiligencia(expedienteId, diligenciaId);
                    GridDiligencias(expedienteId);
                    LimpiarControles();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
					, "alert('" + gcJavascript.ClearText(ex.Message) + "');"
                    , true);
            }
        }

        #endregion

        #endregion

        #region Funciones

            private void AgregarDiligencia(string expedienteId)
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
                    oENTDiligencia.ExpedienteId = Convert.ToInt32(expedienteId);
                    oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
                    oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
                    oENTDiligencia.FechaDiligencia = this.calFecha.BeginDate;
                    oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
                    oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
                    oENTDiligencia.Detalle = txtCampo.Text;
                    oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
                    oENTDiligencia.Resultado = txtResultado.Text;

                    //Transacción
                    oENTResponse = oBPDiligencia.InsertDiligenciaExpediente(oENTDiligencia);

                    //Validación
                    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                    //Mensaje de usuario
                    ScriptManager.RegisterStartupScript(this.Page
                        , this.GetType()
                        , Convert.ToString(Guid.NewGuid())
						, "alert('Diligencia agregada con éxito');"
                        , true);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
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

            private void DisableControls()
            {
                btnGuardar.Enabled = false;
            }

            private void EliminarDiligencia(string expedienteId, string diligenciaId)
            {
                ENTResponse oENTResponse = new ENTResponse();
                ENTDiligencia oENTDiligencia = new ENTDiligencia();
                BPDiligencia oBPDiligencia = new BPDiligencia();

                try
                {
                    oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
                    oENTDiligencia.ExpedienteId = Convert.ToInt32(expedienteId);

                    oENTResponse = oBPDiligencia.DeleteDiligenciaExpediente(oENTDiligencia);

                    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                    GridDiligencias(expedienteId);
                }
                catch (Exception ex)
                {
                    throw (ex);
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

            private void GridDiligencias(string expedienteId)
            {
                BPDiligencia oBPDiligencias = new BPDiligencia();

                oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(expedienteId);
                oBPDiligencias.SelectDiligencias();

                if (oBPDiligencias.ErrorId == 0)
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
                else
                {
                    gvDiligenciasExpediente.DataSource = null;
                    gvDiligenciasExpediente.DataBind();
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

            private void LlenarDetalle(int ExpedienteId)
            {
                ENTSession oENTSession;
                ENTExpediente oENTExpediente = new ENTExpediente();
                BPExpediente ExpedienteProcess = new BPExpediente();

                oENTSession = (ENTSession)this.Session["oENTSession"];

                oENTExpediente.ExpedienteId = ExpedienteId;

                ExpedienteProcess.SelectDetalleExpediente(oENTExpediente);

                if (ExpedienteProcess.ErrorId != 0)
                {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ExpedienteProcess.ErrorDescription) + "');", true);
                    DisableControls();
                    return;
                }

                if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
                {
                    ExpedienteIdLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Numero"].ToString();
                }
                else
                {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('No se encontró información del expediente');", true);
                    DisableControls();
                }
            
                VisitadorAtiendeLabel.Text = oENTSession.sNombre;
                FechaRegistroLabel.Text = DateTime.Now.ToShortDateString();
            }

            private void ModificarDiligencia(string expedienteId, string diligenciaId)
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
                    oENTDiligencia.ExpedienteId = Convert.ToInt32(expedienteId);
                    oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
				    oENTDiligencia.FechaDiligencia = calFecha.BeginDate;
                    oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
                    oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
                    oENTDiligencia.Detalle = txtCampo.Text;
                    oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
                    oENTDiligencia.Resultado = txtResultado.Text;

                    //Transacción
                    oENTResponse = oBPDiligencia.UpdateDiligenciaExpediente(oENTDiligencia);

                    //Validación
                    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                    //Mensaje usuario
                    ScriptManager.RegisterStartupScript(this.Page
                        , this.GetType()
                        , Convert.ToString(Guid.NewGuid())
						, "alert('Diligencia modificada con éxito');"
                        , true);

                }

                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            private void MostrarDatosEdicion(string expedienteId, string diligenciaId)
            {
                BPDiligencia oBPDiligencia = new BPDiligencia();

                oBPDiligencia.DiligenciaEntity.ExpedienteId = Convert.ToInt32(expedienteId);
                oBPDiligencia.DiligenciaEntity.DiligenciaId = Convert.ToInt32(diligenciaId);

                oBPDiligencia.SelectDetalleDiligenciaExpediente();

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

            private void ValidarExpediente(int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();

                ExpedienteProcess.SelectExpedienteEstatus(ExpedienteId);

                if (ExpedienteProcess.ErrorId != 0)
                {
                    IsReadOnly = true;
                    DisableControls();
                    return;
                }

                if (ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.POR_ASIGNAR_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.POR_ATENDER_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.EN_PROCESO_ESTATUS &&
                        ExpedienteProcess.ExpedienteEntity.EstatusId != BPExpediente.PENDIENTE_APROBAR_ESTATUS)
                {
                    IsReadOnly = true;
                    DisableControls();
                    return;
                }
            }

        #endregion
    }
}