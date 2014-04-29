using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleSolicitud : System.Web.UI.Page
    {
        // Utilerías
        Function utilFunction = new Function();

        #region "Events"
            protected void AsignarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAsignarFuncionario.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void AutoridadButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarAutoridaSenalada.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void CalificarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeCalificarSolicitud.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void CiudadanoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarCiudadanosSol.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void DiligenciaPanel_Click(object sender, ImageClickEventArgs e)
            {
                string solicitudId = SolicitudIdHidden.Value;
                if (String.IsNullOrEmpty(solicitudId)) { solicitudId = Request.QueryString["s"].ToString(); }

                Response.Redirect("~/Application/WebApp/Private/Operation/opeDiligenciaSolicitud.aspx?solId=" + solicitudId + "&numSol=" + SolicitudLabel.Text);
            }

            protected void DocumentoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarDocumentos.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void DocumentList_ItemDataBound(Object sender, DataListItemEventArgs e)
            {
                Label DocumentoLabel;
                Image DocumentoImage;
                DataRowView DataRow;

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
                    DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");

                    DataRow = (DataRowView)e.Item.DataItem;

                    //DocumentoImage.ImageUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.cs?R=SE&id=" + DataRow["RepositrioId"].ToString();
                    DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["TipoDocumentoId"].ToString());
                    DocumentoLabel.Text = DataRow["NombreDocumento"].ToString();
                }
            }

            protected void ImprimirButton_Click(object sender, ImageClickEventArgs e)
            {
                string SolicitudId = Request.QueryString["s"];
                Response.Redirect("~/Application/WebApp/Private/Operation/opeSolicitudPaginaImpresion.aspx?s=" + SolicitudId);
            }

            protected void EnviarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeEnviarSolicitud.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            //protected void GuardarButton_Click(object sender, EventArgs e)
            //{
            //    GuardarSolicitud();
            //}

            protected void IndicadorButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarIndicadores.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                // Pendiente de ver si tendrá botones de comando 
            }

            protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                //ImageButton imgEdit = null;
                //String sNumeroSolicitud = "";
                //String sImagesAttributes = "";
                //String sToolTip = "";

                try
                {
                    //Validación de que sea fila 
                    if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                    //Obtener imagenes
                    //imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                    //DataKeys
                    //sNumeroSolicitud = gvApps.DataKeys[e.Row.RowIndex]["Recomendacion"].ToString();

                    //Tooltip Edición
                    //sToolTip = "Editar recomendación [" + sNumeroSolicitud + "]";
                    //imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                    //imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                    //imgEdit.Attributes.Add("style", "curosr:hand;");

                    //Atributos Over
                    //sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

                    //Puntero y Sombra en fila Over
                    e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

                    //Atributos Out
                    //sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

                    //Puntero y Sombra en fila Out
                    e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "';");

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e)
            {
                DataTable TableRecomendacion = null;
                DataView ViewRecomendacion = null;

                try
                {
                    //Obtener DataTable y View del GridView
                    TableRecomendacion = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
                    ViewRecomendacion = new DataView(TableRecomendacion);

                    //Determinar ordenamiento
                    hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                    //Ordenar Vista
                    ViewRecomendacion.Sort = hddSort.Value;

                    //Vaciar datos
                    gvCiudadano.DataSource = ViewRecomendacion;
                    gvCiudadano.DataBind();

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
                }
            }

            //protected void gvAutoridades_RowCommand(object sender, GridViewCommandEventArgs e)
            //{
            //    // Pendiente de ver si tendrá botones de comando 
            //}

            //protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e)
            //{
            //    //ImageButton imgEdit = null;
            //    //String sNumeroSolicitud = "";
            //    //String sImagesAttributes = "";
            //    //String sToolTip = "";

            //    try
            //    {
            //        //Validación de que sea fila 
            //        if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            //        //Obtener imagenes
            //        //imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

            //        //DataKeys
            //        //sNumeroSolicitud = gvApps.DataKeys[e.Row.RowIndex]["Recomendacion"].ToString();

            //        //Tooltip Edición
            //        //sToolTip = "Editar recomendación [" + sNumeroSolicitud + "]";
            //        //imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
            //        //imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
            //        //imgEdit.Attributes.Add("style", "curosr:hand;");

            //        //Atributos Over
            //        //sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

            //        //Puntero y Sombra en fila Over
            //        e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

            //        //Atributos Out
            //        //sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

            //        //Puntero y Sombra en fila Out
            //        e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "';");

            //    }
            //    catch (Exception ex)
            //    {
            //        throw (ex);
            //    }
            //}

        //protected void gvAutoridades_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable TableRecomendacion = null;
        //    DataView ViewRecomendacion = null;

        //    try
        //    {
        //        //Obtener DataTable y View del GridView
        //        TableRecomendacion = utilFunction.ParseGridViewToDataTable(gvAutoridades, false);
        //        ViewRecomendacion = new DataView(TableRecomendacion);

        //        //Determinar ordenamiento
        //        hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

        //        //Ordenar Vista
        //        ViewRecomendacion.Sort = hddSort.Value;

        //        //Vaciar datos
        //        gvAutoridades.DataSource = ViewRecomendacion;
        //        gvAutoridades.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
        //    }
        //}

            protected void lnkAgregarComentario_Click(object sender, EventArgs e)
            {
                btnAction.Text = "Agregar comentario";
                hdnComentarioId.Value = String.Empty;
                pnlAction.Visible = true;
            }

            protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
            {
                txtAsuntoSolicitud.Text = String.Empty;
                pnlAction.Visible = false;
            }

            protected void btnAction_Click(object sender, EventArgs e)
            {
                ENTSession oENTSession = new ENTSession();
                oENTSession = (ENTSession)this.Session["oENTSession"];

                try
                {
                    if (String.IsNullOrEmpty(hdnComentarioId.Value))
                    {
                        if (String.IsNullOrEmpty(txtAsuntoSolicitud.Text)) { throw new Exception("Campo [comentario] requerido"); }
                        // Insertar
                        AgregarComentario(Convert.ToInt32(SolicitudIdHidden.Value), oENTSession.idUsuario, txtAsuntoSolicitud.Text);
                        SelectComentario(Convert.ToInt32(SolicitudIdHidden.Value));
                        txtAsuntoSolicitud.Text = String.Empty;
                        pnlAction.Visible = false;
                    }
                    else
                    {
                        //Modificar Comentario
                        if (String.IsNullOrEmpty(txtAsuntoSolicitud.Text)) { throw new Exception("Campo [comentario] requerido"); }
                        ModificarComentario(Convert.ToInt32(SolicitudIdHidden.Value), oENTSession.idUsuario, txtAsuntoSolicitud.Text, Convert.ToInt32(hdnComentarioId.Value));
                        SelectComentario(Convert.ToInt32(SolicitudIdHidden.Value));
                        txtAsuntoSolicitud.Text = String.Empty;
                        pnlAction.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page
                        , this.GetType()
                        , Convert.ToString(Guid.NewGuid())
                        , "tinyboxMessage('" + ex.Message + "','Fail',true);"
                        , true);
                }
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void GetIconoDocumento()
            {

            }

            private void GuardarSolicitud()
            {
                GuardarSolicitud(int.Parse(SolicitudIdHidden.Value), int.Parse(LugarHechosList.SelectedValue), DireccionHechosBox.Text.Trim(), "");
            }

            private void GuardarSolicitud(int SolicitudId, int LugarHechosId, string DireccionHechos, string Observaciones)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;
                SolicitudProcess.SolicitudEntity.LugarHechosId = LugarHechosId;
                SolicitudProcess.SolicitudEntity.DireccionHechos = DireccionHechos;
                SolicitudProcess.SolicitudEntity.Observaciones = "";    // ToDo: Cambiar por el editor de texto

                SolicitudProcess.SaveSolicitudGeneral();

                if (SolicitudProcess.ErrorId == 0)
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', true);", true);
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void LimpiarFormulario()
            {
                SolicitudLabel.Text = "";
                CalificacionLabel.Text = "";
                EstatusaLabel.Text = "";
                FuncionarioLabel.Text = "";
                ContactoLabel.Text = "";
                TipoSolicitudLabel.Text = "";
                ObservacionesLabel.Text = "";
            }

            private void PageLoad()
            {
                int SolicitudId = 0;

                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                        SetPermisos();
                        SelectLugarHechos();
                        SelectSolicitud(SolicitudId);
                        SelectCiudadano(SolicitudId);
                        //SelectAutoridades(SolicitudId);
                        SelectDocumento(SolicitudId);
                        SelectComentario(SolicitudId);

                        SolicitudIdHidden.Value = SolicitudId.ToString();
                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Exception.Message) + "', 'Fail', true);", true);
                    }
                }
            }

            //private void SelectAutoridades(int SolicitudId)
            //{
            //    BPSolicitud SolicitudProcess = new BPSolicitud();

            //    SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

            //    // ToDo: Habilitar la búsqueda de autoridades
            //    SolicitudProcess.SelectSolicitudAutoridad();

            //    if (SolicitudProcess.ErrorId == 0)
            //    {
            //        if (SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
            //        {
            //            this.gvAutoridades.DataSource = SolicitudProcess.SolicitudEntity.ResultData;
            //            this.gvAutoridades.DataBind();
            //        }
            //        else
            //        {
            //            this.gvAutoridades.DataSource = null;
            //            this.gvAutoridades.DataBind();
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
            //    }
            //}

            private void SelectCiudadano(int SolicitudId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

                SolicitudProcess.SelectSolicitudCiudadano();

                if (SolicitudProcess.ErrorId == 0)
                {
                    this.gvCiudadano.DataSource = SolicitudProcess.SolicitudEntity.ResultData.Tables[0];
                    this.gvCiudadano.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
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

            private void SelectDocumento(int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.SelectDocumentoSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    if (DocumentoProcess.DocumentoEntity.ResultData.Tables[0].Rows.Count == 0)
                        SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados a la solicitud";
                    else
                        SinDocumentoLabel.Text = "";

                    DocumentoList.DataSource = DocumentoProcess.DocumentoEntity.ResultData;
                    DocumentoList.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(DocumentoProcess.ErrorDescription) + "', 'Fail', true);", true);
            }

            private void SelectLugarHechos()
            {
                BPLugarHechos LugarProcess = new BPLugarHechos();

                LugarProcess.SelectLugarHechos();

                if (LugarProcess.ErrorId == 0)
                {
                    LugarHechosList.DataValueField = "LugarHechosId";
                    LugarHechosList.DataTextField = "Nombre";

                    LugarHechosList.DataSource = LugarProcess.LugarEntity.ResultData.Tables[0];
                    LugarHechosList.DataBind();

                    LugarHechosList.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(LugarProcess.ErrorDescription) + "', 'Fail', true);", true);
            }

            private void SelectSolicitud(int SolicitudId)
            {
                BPSolicitud SolicitudProcess = new BPSolicitud();
                ENTSession oENTSession = new ENTSession();

                oENTSession = (ENTSession)this.Session["oENTSession"];

                SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;
                SolicitudProcess.SolicitudEntity.FuncionarioId = oENTSession.FuncionarioId;

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
                        LugarHechosList.SelectedValue = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["LugarHechosId"].ToString();
                        DireccionHechosBox.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();
                        ObservacionesLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();

                        FechaRecepcionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
                        FechaAsignacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
                        FechaGestionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
                        FechaModificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString(); 

                    }
                }
                else
                {
                    LimpiarFormulario();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
                }
            }

            private void SetPermisos()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                if (SessionEntity != null)
                {
                    switch (SessionEntity.idRol)
                    {
                        case 1:
                        case 2:
                            CiudadanoPanel.Visible = true;
                            AutoridadPanel.Visible = true;
                            IndicadorPanel.Visible = true;
                            DocumentoPanel.Visible = true;
                            CalificarPanel.Visible = true;
                            EnviarPanel.Visible = true;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        case 3:
                            CiudadanoPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        case 4:
                            CiudadanoPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        case 5:
                            CiudadanoPanel.Visible = true;
                            AutoridadPanel.Visible = true;
                            IndicadorPanel.Visible = true;
                            DocumentoPanel.Visible = true;
                            CalificarPanel.Visible = true;
                            EnviarPanel.Visible = true;

                            LugarHechosList.Enabled = true;
                            DireccionHechosBox.Enabled = true;
                            //GuardarButton.Enabled = true;

                            break;

                        case 6:
                            CiudadanoPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        default:
                            CiudadanoPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;
                    }
                }
            }

            private void AgregarComentario(int SolicitudId, int idUsuario, string Comentario)
            {
                BPSolicitudComentario oBPSolicitudComentario = new BPSolicitudComentario();
                ENTSolicitudComentario oENTSolicitudComentario = new ENTSolicitudComentario();

                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    oENTSolicitudComentario.SolicitudId = SolicitudId;
                    oENTSolicitudComentario.idUsuario = idUsuario;
                    oENTSolicitudComentario.Comentario = Comentario;

                    oENTResponse = oBPSolicitudComentario.AgregarComentario(oENTSolicitudComentario);
                    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                    ScriptManager.RegisterStartupScript(this.Page
                        , this.GetType()
                        , Convert.ToString(Guid.NewGuid())
                        , "tinyboxMessage('Comentario agregado con éxito','Success', true);"
                        , true);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            private void ModificarComentario(int SolicitudId, int idUsuario, string Comentario, int ComentarioId)
            {
                BPSolicitudComentario oBPSolicitudComentario = new BPSolicitudComentario();
                ENTSolicitudComentario oENTSolicitudComentario = new ENTSolicitudComentario();

                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    oENTSolicitudComentario.SolicitudId = SolicitudId;
                    oENTSolicitudComentario.idUsuario = idUsuario;
                    oENTSolicitudComentario.Comentario = Comentario;
                    oENTSolicitudComentario.ComentarioId = ComentarioId;

                    oENTResponse = oBPSolicitudComentario.ModificarComentario(oENTSolicitudComentario);
                    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                    ScriptManager.RegisterStartupScript(this.Page
                        , this.GetType()
                        , Convert.ToString(Guid.NewGuid())
                        , "tinyboxMessage('Comentario modificado con éxito','Success', true);"
                        , true);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

            private void EliminarComentario(int SolicitudId, int idUsuario, int ComentarioId)
            {
                BPSolicitudComentario oBPSolicitudComentario = new BPSolicitudComentario();
                ENTSolicitudComentario oENTSolicitudComentario = new ENTSolicitudComentario();

                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    oENTSolicitudComentario.SolicitudId = SolicitudId;
                    oENTSolicitudComentario.idUsuario = idUsuario;
                    oENTSolicitudComentario.ComentarioId = ComentarioId;

                    oENTResponse = oBPSolicitudComentario.EliminarComentario(oENTSolicitudComentario);
                    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                    ScriptManager.RegisterStartupScript(this.Page
                        , this.GetType()
                        , Convert.ToString(Guid.NewGuid())
                        , "tinyboxMessage('Comentario modificado con éxito','Success', true);"
                        , true);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        #endregion
    }
}