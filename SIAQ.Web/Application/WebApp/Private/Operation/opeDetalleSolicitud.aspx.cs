// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleSolicitud : System.Web.UI.Page
    {

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Funciones el programador

		private void SelectCiudadano(int SolicitudId){
			BPSolicitud SolicitudProcess = new BPSolicitud();

			// Formulario
			SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

			// Transacción
			SolicitudProcess.SelectSolicitudCiudadano();

			// Manejo de errores
			if (SolicitudProcess.ErrorId != 0) { throw( new Exception(SolicitudProcess.ErrorDescription)); }
			
			// LLenado de Grid
			this.gvCiudadano.DataSource = SolicitudProcess.SolicitudEntity.ResultData.Tables[0];
			this.gvCiudadano.DataBind();

		}

		
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			int SolicitudId = 0;

			try
			{
				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["s"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener SolicitudId
				SolicitudId = int.Parse(Request.QueryString["s"].ToString());
				SolicitudIdHidden.Value = SolicitudId.ToString();

				// LLenado de controles
				SetPermisos();
				SelectLugarHechos();
				SelectSolicitud(SolicitudId);
				SelectCiudadano(SolicitudId);
				SelectRepositorio(SolicitudId);
				SelectComentario(SolicitudId);

			}catch (Exception Exception){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Exception.Message) + "', 'Fail', true);", true);
			}
		}

		protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
			String CiudadanoId;

			String strCommand = "";
			Int32 intRow = 0;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				CiudadanoId = this.gvCiudadano.DataKeys[intRow]["CiudadanoId"].ToString();

				// Acción
				switch (strCommand){
					case "Eliminar":

						// Obtener sesión
						//EliminarCiudadano
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String sNombreCompleto = "";
			String sImagesAttributes = "";
			String sToolTip = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// DataKeys
				sNombreCompleto = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

				// Tooltip Deletear Ciudadano
				sToolTip = "Elliminar del expediente al Ciudadano [" + sNombreCompleto + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblData = null;
			DataView viewData = null;

			try
			{
				//Obtener DataTable y View del GridView
				tblData = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
				viewData = new DataView(tblData);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				viewData.Sort = hddSort.Value;

				//Vaciar datos
				this.gvCiudadano.DataSource = viewData;
				this.gvCiudadano.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}


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
                HyperLink DocumentoLink;
                Image DocumentoImage;
                DataRowView DataRow;

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
                    DocumentoLink = (HyperLink)e.Item.FindControl("DocumentoLink");

                    DataRow = (DataRowView)e.Item.DataItem;

                    //DocumentoImage.ImageUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.cs?R=SE&id=" + DataRow["RepositrioId"].ToString();
                    DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
                    DocumentoLink.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=" + DataRow["SolicitudId"].ToString();
                    DocumentoLink.Text = DataRow["NombreDocumento"].ToString();
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

            protected void IndicadorButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAgregarIndicadores.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

            protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + SolicitudIdHidden.Value.ToString());
            }

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

           
        #endregion

        #region "Methods"
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

            private void SelectRepositorio(int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.SelectRepositorioSE();

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
                            AsignarPanel.Visible = true;
                            CiudadanoPanel.Visible = true;
                            CalificarPanel.Visible = true;
                            AutoridadPanel.Visible = true;
                            DiligenciasPanel.Visible = true;
                            IndicadorPanel.Visible = true;
                            DocumentoPanel.Visible = true;
                            EnviarPanel.Visible = true;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        case 3:
                            AsignarPanel.Visible = false;
                            CiudadanoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            DiligenciasPanel.Visible = false;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        case 4:
                            AsignarPanel.Visible = true;
                            CiudadanoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            DiligenciasPanel.Visible = true;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        case 5:
                            AsignarPanel.Visible = false;
                            CiudadanoPanel.Visible = true;
                            CalificarPanel.Visible = true;
                            AutoridadPanel.Visible = true;
                            DiligenciasPanel.Visible = true;
                            IndicadorPanel.Visible = true;
                            DocumentoPanel.Visible = true;
                            EnviarPanel.Visible = true;

                            LugarHechosList.Enabled = true;
                            DireccionHechosBox.Enabled = true;
                            //GuardarButton.Enabled = true;

                            break;

                        case 6:
                            AsignarPanel.Visible = true;
                            CiudadanoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            DiligenciasPanel.Visible = true;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;

                            break;

                        default:
                            AsignarPanel.Visible = false;
                            CiudadanoPanel.Visible = false;
                            CalificarPanel.Visible = false;
                            AutoridadPanel.Visible = false;
                            DiligenciasPanel.Visible = false;
                            IndicadorPanel.Visible = false;
                            DocumentoPanel.Visible = false;
                            EnviarPanel.Visible = false;

                            LugarHechosList.Enabled = false;
                            DireccionHechosBox.Enabled = false;
                            //GuardarButton.Enabled = false;
                            break;
                    }
                }
            }
        #endregion
    }
}