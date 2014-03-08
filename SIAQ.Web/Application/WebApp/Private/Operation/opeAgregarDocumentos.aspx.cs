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

                        SelectDocumento(int.Parse(_SolicitudId));

                        SolicitudIdHidden.Value = _SolicitudId;
                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            private void GuardarDocumento()
            {
                ENTUsuario UsuarioEntity = new ENTUsuario();

                GuardarDocumento(int.Parse(SolicitudIdHidden.Value), UsuarioEntity.idUsuario, NombreBox.Text.Trim(), DescripcionBox.Text.Trim(), DocumentoFile);
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
            }

            private void SelectDocumento(int SolicitudId)
            {

            }
        #endregion
    }
}