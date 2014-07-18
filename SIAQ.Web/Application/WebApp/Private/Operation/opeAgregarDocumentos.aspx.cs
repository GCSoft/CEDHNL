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
    public partial class opeAgregarDocumentos : System.Web.UI.Page
    {
        public string _SolicitudId;
        const string ModuloId = "0AB3107A-3C18-4186-BB76-9DAAD63DBEC4";
        Function utilFunction = new Function();


		private void SelectSolicitud()
		{
			BPSolicitud SolicitudProcess = new BPSolicitud();
			int SolicitudId;

			// 
			SolicitudId = Int32.Parse(SolicitudIdHidden.Value);

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

					FechaRecepcionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
					FechaAsignacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
					FechaGestionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
					FechaModificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString();

				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
			}
		}

        #region "Events"

			protected void btnRegresar_Click(object sender, EventArgs e){
				Response.Redirect("opeDetalleSolicitud.aspx?s=" + this.SolicitudIdHidden.Value, false);
			}	

            protected void DocumentoGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
            {
                DocumentoGridRowCommand(e);
            }

            protected void DocumentoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                DocumentoGridRowDataBound(e);
            }

            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                SaveDocumento();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                // Se le agrega una propiedad al formulario de la página para poder subir archivos
                this.Form.Enctype = "multipart/form-data";

                PageLoad();
            }
        #endregion

        #region
            private void DeleteRepositorio(string RepositorioId)
            {
                DeleteRepositorio(RepositorioId, int.Parse(SolicitudIdHidden.Value));
            }

            private void DeleteRepositorio(string RepositorioId, int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.RepositorioId = RepositorioId;
                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.DeleteRepositorioSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    SelectDocumento(int.Parse(SolicitudIdHidden.Value));

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', false);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(DocumentoProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void DocumentoGridRowCommand(GridViewCommandEventArgs e)
            {
                string RepositorioId = string.Empty;

                RepositorioId = e.CommandArgument.ToString();

                switch (e.CommandName.ToString())
                {
                    case "Eliminar":
                        DeleteRepositorio(RepositorioId);
                        break;
                }
            }

            private void DocumentoGridRowDataBound(GridViewRowEventArgs e)
            {
                HyperLink DocumentoLink;
                Image DocumentoImage;
                DataRowView DataRow;

                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                    return;

                DocumentoImage = (Image)e.Row.FindControl("DocumentoImage");
                DocumentoLink = (HyperLink)e.Row.FindControl("DocumentoLink");

                DataRow = (DataRowView)e.Row.DataItem;

                DocumentoImage.ImageUrl = BPDocumento.GetIconoDocumento(DataRow["FormatoDocumentoId"].ToString());
                DocumentoLink.NavigateUrl = ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?R=" + DataRow["RepositorioId"].ToString() + "&S=" + DataRow["SolicitudId"].ToString();
            }

            private void PageLoad()
            {
                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        _SolicitudId = Request.QueryString["s"].ToString();

                        SolicitudLabel.Text = _SolicitudId;

                        SelectDocumento(int.Parse(_SolicitudId));
                        SelectTipoDocumento();

                        SolicitudIdHidden.Value = _SolicitudId;

						// consultar la carátula
						SelectSolicitud();

                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            private void ResetForm()
            {
                TipoDocumentoList.SelectedIndex = 0;
                NombreBox.Text = "";
                DescripcionBox.Text = "";
            }

            private void SaveDocumento()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                SaveDocumento(int.Parse(SolicitudIdHidden.Value), SessionEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
            }

            private void SaveDocumento(int SolicitudId, int idUsuarioInsert, string Nombre, string Descripcion, FileUpload DocumentoFile)
            {
                BPDocumento RepositorioProcess = new BPDocumento();

                RepositorioProcess.DocumentoEntity.ModuloId = ModuloId;
                RepositorioProcess.DocumentoEntity.TipoDocumentoId = TipoDocumentoList.SelectedValue;
                RepositorioProcess.DocumentoEntity.SolicitudId = SolicitudId;
                RepositorioProcess.DocumentoEntity.idUsuarioInsert = idUsuarioInsert;
                RepositorioProcess.DocumentoEntity.Nombre = Nombre;
                RepositorioProcess.DocumentoEntity.Descripcion = Descripcion;
                RepositorioProcess.DocumentoEntity.FileUpload = DocumentoFile;

                RepositorioProcess.SaveRepositorioSE();

                if (RepositorioProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectDocumento(int.Parse(SolicitudIdHidden.Value));

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', false);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(RepositorioProcess.ErrorDescription) + "', 'Error', true);", true);
            }

            private void SelectDocumento(int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.SelectRepositorioSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    DocumentoGrid.DataSource = DocumentoProcess.DocumentoEntity.ResultData;
                    DocumentoGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + DocumentoProcess.ErrorDescription + "', 'Error', true);", true);
            }

            private void SelectTipoDocumento()
            {
                BPTipoDocumento TipoDocumentoProcess = new BPTipoDocumento();

                TipoDocumentoProcess.SelectTipoDocumento();

                if (TipoDocumentoProcess.ErrorId == 0)
                {
                    TipoDocumentoList.DataValueField = "TipoDocumentoId";
                    TipoDocumentoList.DataTextField = "Nombre";

                    TipoDocumentoList.DataSource = TipoDocumentoProcess.TipoDocumentoEntity.ResultData;
                    TipoDocumentoList.DataBind();

                    TipoDocumentoList.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + TipoDocumentoProcess.ErrorDescription + "', 'Error', true);", true);
            }
        #endregion
    }
}