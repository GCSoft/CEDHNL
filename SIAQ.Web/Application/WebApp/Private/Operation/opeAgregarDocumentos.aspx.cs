using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarDocumentos : System.Web.UI.Page
    {
        public string _SolicitudId;

        #region "Events"
            protected void GuardarButton_Click(object sender, EventArgs e)
            {
                GuardarDocumento();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                // Se le agrega una propiedad al formulario de la página para poder subir archivos
                this.Form.Enctype = "multipart/form-data";

                PageLoad();
            }
        #endregion

        #region
            private void PageLoad()
            {
                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        _SolicitudId = Request.QueryString["s"].ToString();

                        SolicitudLabel.Text = _SolicitudId;

                        SelectDocumento(int.Parse(_SolicitudId));

                        SolicitudIdHidden.Value = _SolicitudId;
                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            private void ResetForm()
            {
                NombreBox.Text = "";
                DescripcionBox.Text = "";
            }

            private void GuardarDocumento()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                GuardarDocumento(int.Parse(SolicitudIdHidden.Value), SessionEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
            }

            private void GuardarDocumento(int SolicitudId, int idUsuarioInsert, string Nombre, string Descripcion, FileUpload DocumentoFile)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;
                DocumentoProcess.DocumentoEntity.idUsuarioInsert = idUsuarioInsert;
                DocumentoProcess.DocumentoEntity.Nombre = Nombre;
                DocumentoProcess.DocumentoEntity.Descripcion = Descripcion;
                DocumentoProcess.DocumentoEntity.FileUpload = DocumentoFile;

                DocumentoProcess.SaveDocumentoSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    ResetForm();
                    SelectDocumento(int.Parse(SolicitudIdHidden.Value));

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La información fue guardada con éxito!', 'Success', true);", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + DocumentoProcess.ErrorDescription + "', 'Error', true);", true);
            }

            private void SelectDocumento(int SolicitudId)
            {
                BPDocumento DocumentoProcess = new BPDocumento();

                DocumentoProcess.DocumentoEntity.SolicitudId = SolicitudId;

                DocumentoProcess.SelectDocumentoSE();

                if (DocumentoProcess.ErrorId == 0)
                {
                    DocumentoGrid.DataSource = DocumentoProcess.DocumentoEntity.ResultData;
                    DocumentoGrid.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + DocumentoProcess.ErrorDescription + "', 'Error', true);", true);
            }
        #endregion
    }
}