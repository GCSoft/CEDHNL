using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleExpedienteVisitador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    ENTSession oENTSession;

            //    oENTSession = (ENTSession)this.Session["oENTSession"];

            //    string sRolId = oENTSession.idRol.ToString();

            //    if (String.IsNullOrEmpty(sRolId)) { sRolId = "0"; }
            //    int RolId = Convert.ToInt32(sRolId);

            //    if (RolId == 7)// Secretaria visitaduria ID = 7
            //    {
            //        SubMenuDivSecretaria.Visible = true;
            //        SubMenuDivVisitador.Visible = false;
            //    }
            //    else if (RolId == 8)// Visitador Visitaduria ID = 8
            //    {
            //        SubMenuDivSecretaria.Visible = false;
            //        SubMenuDivVisitador.Visible = true;
            //    }
            //    else
            //    {
            //        SubMenuDivSecretaria.Visible = false;
            //        SubMenuDivVisitador.Visible = false;
            //    }

            //    string ExpedienteId = GetRawQueryParameter("expId");
            //    hdnExpedienteId.Value = ExpedienteId;

            //    SelectComentario(Convert.ToInt32(ExpedienteId));
            //    LlenarCiudadanos(ExpedienteId);
            //    LlenarDetalle(ExpedienteId, oENTSession.FuncionarioId.ToString());
            //}
        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        #region "Botones SubMenu Secretaria"

        protected void InformacionGeneralSecretariaButton_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstEspedienteSecretaria.aspx");
        }

        protected void AsignarVisitadorButton_Click(object sender, ImageClickEventArgs e)
        {
            //string sExpedienteId = hdnExpedienteId.Value;
            //if (String.IsNullOrEmpty(sExpedienteId)) { sExpedienteId = GetRawQueryParameter("expId"); }

            //Response.Redirect("~/Application/WebApp/Private/Operation/opeAsignarVisitador.aspx?expId=" + sExpedienteId);
        }

        #endregion

        #region "Botones SubMenu Visitador"

        protected void InformacionGeneralVisitadorButton_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstExpedientesFuncionario.aspx");
        }

        protected void AcuerdoCalificacionButton_Click(object sender, ImageClickEventArgs e)
        {
            //string sExpedienteId = hdnExpedienteId.Value;
            //if (String.IsNullOrEmpty(sExpedienteId)) { sExpedienteId = GetRawQueryParameter("expId"); }

            //Response.Redirect("~/Application/WebApp/Private/Operation/opeAcuerdoCalifDefinitiva.aspx?expId=" + sExpedienteId);
        }

        protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e)
        {
            //string expedienteId = hdnExpedienteId.Value;
            //if (String.IsNullOrEmpty(expedienteId)) { expedienteId = GetRawQueryParameter("expId"); }
            //string numeroExpediente = SolicitudLabel.Text;

            //Response.Redirect("~/Application/WebApp/Private/Operation/opeDiligenciaExpediente.aspx?expId=" + expedienteId + "&numEx=" + numeroExpediente);
        }

        protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e)
        {
            // TO DO: Falta hacer el html
        }

        protected void ResolucionButton_Click(object sender, ImageClickEventArgs e)
        {
            // TO DO: Falta hacer el html
        }

        protected void EnviarExpedienteButton_Click(object sender, ImageClickEventArgs e)
        {
            // TO DO: Falta hacer el html
        }

        #endregion

        #region "Grid Ciudadano"

        protected void gvCiudadanos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string ExpedienteId = String.Empty;
            //int intRow = 0;
            //string ciudadanoId = String.Empty;

            //try
            //{
            //    // Opción seleccionada 
            //    string sCommandName = e.CommandName.ToString();

            //    if (sCommandName == "Sort") { return; }

            //    // Fila
            //    intRow = Convert.ToInt32(e.CommandArgument.ToString());

            //    //Ciudadano Id 
            //    ciudadanoId = gvCiudadanos.DataKeys[intRow]["CiudadanoId"].ToString();
            //    ExpedienteId = hdnExpedienteId.Value;
            //    if (String.IsNullOrEmpty(ExpedienteId)) { ExpedienteId = GetRawQueryParameter("expid"); }

            //    switch (sCommandName)
            //    {
            //        case "Borrar":
            //            EliminarCiudadano(ciudadanoId, Convert.ToInt32(ExpedienteId));
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtAsuntoSolicitud.ClientID + "');", true);
            //}
        }

        protected void gvCiudadanos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //ImageButton imgEdit = null;

            //String sImagesAttributes = "";
            //String sToolTip = "";

            //try
            //{
            //    //Validación de que sea fila 
            //    if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            //    //Obtener imagenes
            //    imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

            //    //Tooltip Edición
            //    sToolTip = "Eliminar ciudadano";
            //    imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
            //    imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            //    imgEdit.Attributes.Add("style", "curosr:hand;");

            //    //Atributos Over
            //    sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

            //    //Puntero y Sombra en fila Over
            //    e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

            //    //Atributos Out
            //    sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

            //    //Puntero y Sombra en fila Out
            //    e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        protected void gvCiudadanos_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DataTable TableExpediente = null;
            //DataView ViewExpediente = null;

            //try
            //{
            //    //Obtener DataTable y View del GridView
            //    TableExpediente = utilFunction.ParseGridViewToDataTable(gvCiudadanos, false);
            //    ViewExpediente = new DataView(TableExpediente);

            //    //Determinar ordenamiento
            //    hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

            //    //Ordenar Vista
            //    ViewExpediente.Sort = hddSort.Value;

            //    //Vaciar datos
            //    gvCiudadanos.DataSource = ViewExpediente;
            //    gvCiudadanos.DataBind();

            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            //}
        }

        #endregion

        #region "Botones"

        protected void cmdRegresar_Click(object sender, EventArgs e)
        {
            //ENTSession oENTSession;

            //oENTSession = (ENTSession)this.Session["oENTSession"];

            //string sRolId = oENTSession.idRol.ToString();
            //if (String.IsNullOrEmpty(sRolId)) { sRolId = "0"; }

            //int RolId = Convert.ToInt32(sRolId);

            //if (RolId == 7)// Secretaria
            //{
            //    Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstEspedienteSecretaria.aspx");
            //}
            //else if (RolId == 8) // Visitador
            //{
            //    Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstExpedientesFuncionario.aspx");
            //}
            //else
            //{
            //    Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeLstEspedienteSecretaria.aspx");
            //}
        }

        #endregion

        #endregion

        #region Funciones

        protected void LlenarCiudadanos(string ExpedienteId)
        {
            //ENTExpediente oENTExpediente = new ENTExpediente();
            //BPExpediente oBPExpediente = new BPExpediente();

            //if (String.IsNullOrEmpty(ExpedienteId))
            //{
            //    ExpedienteId = "0";
            //}

            //oENTExpediente.ExpedienteId = Convert.ToInt32(ExpedienteId);

            //oBPExpediente.SelectCiudadanosGrid(oENTExpediente);

            //if (oBPExpediente.ErrorId == 0)
            //{
            //    if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
            //    {
            //        gvCiudadanos.DataSource = oENTExpediente.ResultData;
            //        gvCiudadanos.DataBind();
            //    }
            //    else
            //    {
            //        gvCiudadanos.DataSource = null;
            //        gvCiudadanos.DataBind();
            //    }
            //}
            //else
            //{
            //    gvCiudadanos.DataSource = null;
            //    gvCiudadanos.DataBind();
            //}
        }

        protected void LlenarDetalle(string ExpedienteId, string FuncionarioId)
        {
            //BPExpediente BPExpediente = new BPExpediente();
            //ENTExpediente oENTExpediente = new ENTExpediente();

            //if (String.IsNullOrEmpty(ExpedienteId))
            //{
            //    ExpedienteId = "0";
            //}
            //if (String.IsNullOrEmpty(FuncionarioId))
            //{
            //    FuncionarioId = "0";
            //}

            //oENTExpediente.ExpedienteId = Convert.ToInt32(ExpedienteId);
            //oENTExpediente.FuncionarioId = Convert.ToInt32(FuncionarioId);

            //BPExpediente.SelectDetalleExpediente(oENTExpediente);

            //if (BPExpediente.ErrorId == 0)
            //{
            //    // Detalle 
            //    if (oENTExpediente.ResultData.Tables[0].Rows.Count > 0)
            //    {
            //        SolicitudLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Numero"].ToString();
            //        CalificacionLlabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Calificacion"].ToString();
            //        EstatusaLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Estatus"].ToString();
            //        VisitadorLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Visitador"].ToString();
            //        FormaContactoLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["FormaContacto"].ToString();
            //        TipoSolicitudLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["TipoSolicitud"].ToString();
            //        ObservacionesLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
            //        LugarHechosLabel.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["LugarHechos"].ToString();
            //        DireccionHechos.Text = oENTExpediente.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

            //    }

            //    //Fechas
            //    if (oENTExpediente.ResultData.Tables[1].Rows.Count > 0)
            //    {
            //        FechaRecepcionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
            //        FechaAsignacionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
            //        FechaGestionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
            //        FechaModificacionLabel.Text = oENTExpediente.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString();
            //    }
            //}
        }

        //public string GetRawQueryParameter(string parameterName)
        //{
        //    string raw = Request.RawUrl;
        //    int startQueryIdx = raw.IndexOf('?');
        //    if (startQueryIdx < 0)
        //        return null;

        //    int nameLength = parameterName.Length + 1;
        //    int startIdx = raw.IndexOf(parameterName + "=", startQueryIdx);
        //    if (startIdx < 0)
        //        return null;

        //    startIdx += nameLength;
        //    int endIdx = raw.IndexOf('&', startIdx);
        //    if (endIdx < 0)
        //        endIdx = raw.Length;

        //    return raw.Substring(startIdx, endIdx - startIdx);
        //}

        private void EliminarCiudadano(string ciudadanoId, int expedienteId)
        {
            //ENTExpediente oENTExpediente = new ENTExpediente();
            //ENTResponse oENTResponse = new ENTResponse();

            //BPExpediente oBPExpediente = new BPExpediente();

            //try
            //{
            //    //Formulario 
            //    oENTExpediente.ExpedienteId = expedienteId;
            //    oENTExpediente.Ciudadano = ciudadanoId;

            //    //Transacción 
            //    oENTResponse = oBPExpediente.DeleteCiudadano_Expediente(oENTExpediente);

            //    //Validaciones 
            //    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
            //    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

            //    //Actualzar datos 
            //    LlenarCiudadanos(expedienteId.ToString());
            //}
            //catch (Exception ex) { throw (ex); }
        }

        private void AgregarComentario(int ExpedienteId, int idUsuario, string Comentario)
        {
            //BPExpedienteComentario oBPExpedienteComentario = new BPExpedienteComentario();
            //ENTExpedienteComentario oENTExpedienteComentario = new ENTExpedienteComentario();

            //ENTResponse oENTResponse = new ENTResponse();

            //try
            //{
            //    oENTExpedienteComentario.ExpedienteId = ExpedienteId;
            //    oENTExpedienteComentario.idUsuario = idUsuario;
            //    oENTExpedienteComentario.Comentario = Comentario;

            //    oENTResponse = oBPExpedienteComentario.AgregarComentario(oENTExpedienteComentario);
            //    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
            //    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

            //    ScriptManager.RegisterStartupScript(this.Page
            //        , this.GetType()
            //        , Convert.ToString(Guid.NewGuid())
            //        , "tinyboxMessage('Comentario agregado con éxito','Success', true);"
            //        , true);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        private void ModificarComentario(int ExpedienteId, int idUsuario, string Comentario, int ComentarioId)
        {
            //BPExpedienteComentario oBPExpedienteComentario = new BPExpedienteComentario();
            //ENTExpedienteComentario oENTExpedienteComentario = new ENTExpedienteComentario();

            //ENTResponse oENTResponse = new ENTResponse();

            //try
            //{
            //    oENTExpedienteComentario.ExpedienteId = ExpedienteId;
            //    oENTExpedienteComentario.idUsuario = idUsuario;
            //    oENTExpedienteComentario.Comentario = Comentario;
            //    oENTExpedienteComentario.ComentarioId = ComentarioId;

            //    oENTResponse = oBPExpedienteComentario.ModificarComentario(oENTExpedienteComentario);
            //    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
            //    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

            //    ScriptManager.RegisterStartupScript(this.Page
            //        , this.GetType()
            //        , Convert.ToString(Guid.NewGuid())
            //        , "tinyboxMessage('Comentario modificado con éxito','Success', true);"
            //        , true);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        private void EliminarComentario(int ExpedienteId, int idUsuario, int ComentarioId)
        {
            //BPExpedienteComentario oBPExpedienteComentario = new BPExpedienteComentario();
            //ENTExpedienteComentario oENTExpedienteComentario = new ENTExpedienteComentario();

            //ENTResponse oENTResponse = new ENTResponse();

            //try
            //{
            //    oENTExpedienteComentario.ExpedienteId = ExpedienteId;
            //    oENTExpedienteComentario.idUsuario = idUsuario;
            //    oENTExpedienteComentario.ComentarioId = ComentarioId;

            //    oENTResponse = oBPExpedienteComentario.EliminarComentario(oENTExpedienteComentario);
            //    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
            //    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

            //    ScriptManager.RegisterStartupScript(this.Page
            //        , this.GetType()
            //        , Convert.ToString(Guid.NewGuid())
            //        , "tinyboxMessage('Comentario modificado con éxito','Success', true);"
            //        , true);
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        private void SelectComentario(int ExpedienteId)
        {
            //BPExpediente ExpedienteProcess = new BPExpediente();

            //ExpedienteProcess.ExpedienteEntity.ExpedienteId = ExpedienteId;

            //ExpedienteProcess.SelectSolicitudComentario();

            //if (ExpedienteProcess.ErrorId == 0)
            //{
            //    if (ExpedienteProcess.ExpedienteEntity.ResultData.Tables[0].Rows.Count == 0)
            //        SinComentariosLabel.Text = "<br /><br />No hay comentarios para esta solicitud";
            //    else
            //        SinComentariosLabel.Text = "";

            //    ComentarioRepeater.DataSource = ExpedienteProcess.ExpedienteEntity.ResultData.Tables[0];
            //    ComentarioRepeater.DataBind();

            //    ComentarioTituloLabel.Text = ExpedienteProcess.ExpedienteEntity.ResultData.Tables[0].Rows.Count.ToString() + " comentarios";
            //}
            //else
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ExpedienteProcess.ErrorDescription) + "', 'Fail', true);", true);
        }

        #endregion

        protected void DocumentList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //Label DocumentoLabel;
            //Image DocumentoImage;
            //DataRowView DataRow;

            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
            //    DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");

            //    DataRow = (DataRowView)e.Item.DataItem;

            //    //DocumentoImage.ImageUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.cs?R=SE&id=" + DataRow["RepositrioId"].ToString();
            //    DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["TipoDocumentoId"].ToString());
            //    DocumentoLabel.Text = DataRow["NombreDocumento"].ToString();
            //}
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            //ENTSession oENTSession = new ENTSession();
            //oENTSession = (ENTSession)this.Session["oENTSession"];

            //try
            //{
            //    if (String.IsNullOrEmpty(hdnComentarioId.Value))
            //    {
            //        if (String.IsNullOrEmpty(txtAsuntoSolicitud.Text)) { throw new Exception("Campo [comentario] requerido"); }
            //        // Insertar
            //        AgregarComentario(Convert.ToInt32(hdnExpedienteId.Value), oENTSession.idUsuario, txtAsuntoSolicitud.Text);
            //        SelectComentario(Convert.ToInt32(hdnExpedienteId.Value));
            //        txtAsuntoSolicitud.Text = String.Empty;
            //        pnlAction.Visible = false;
            //    }
            //    else
            //    {
            //        //Modificar Comentario
            //        if (String.IsNullOrEmpty(txtAsuntoSolicitud.Text)) { throw new Exception("Campo [comentario] requerido"); }
            //        ModificarComentario(Convert.ToInt32(hdnExpedienteId.Value), oENTSession.idUsuario, txtAsuntoSolicitud.Text, Convert.ToInt32(hdnComentarioId.Value));
            //        SelectComentario(Convert.ToInt32(hdnExpedienteId.Value));
            //        txtAsuntoSolicitud.Text = String.Empty;
            //        pnlAction.Visible = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page
            //        , this.GetType()
            //        , Convert.ToString(Guid.NewGuid())
            //        , "tinyboxMessage('" + ex.Message + "','Fail',true);"
            //        , true);
            //}
        }

        protected void lnkAgregarComentario_Click(object sender, EventArgs e)
        {
            //btnAction.Text = "Agregar comentario";
            //hdnComentarioId.Value = String.Empty;
            //pnlAction.Visible = true;
        }

        protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
        {
            //txtAsuntoSolicitud.Text = String.Empty;
            //pnlAction.Visible = false;
        }
    }
}