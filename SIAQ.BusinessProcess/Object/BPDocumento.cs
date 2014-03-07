using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPDocumento : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTDocumento _DocumentoEntity;

        /// <summary>
        ///     Número de error, en caso de que haya ocurrido uno. Cero por default.
        /// </summary>
        public int ErrorId
        {
            get { return _ErrorId; }
        }

        /// <summary>
        ///     Descripción de error, en caso de que haya ocurrido uno. Empty por default.
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
        }

        /// <summary>
        ///     Propiedad pública de la entidad de repositorio.
        /// </summary>
        public ENTDocumento DocumentoEntity
        {
            get { return _DocumentoEntity; }
            set { _DocumentoEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPDocumento()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _DocumentoEntity = new ENTDocumento();
        }

        #region "Methods"
            public string GetFileType(string FileExtension)
            {
                string Result = "";

                switch (FileExtension)
                {
                    case "jpg":
                        Result = "";
                        break;

                    case "gif":
                        Result = "";
                        break;

                    case "png":
                        Result = "";
                        break;

                    case "bmp":
                        Result = "";
                        break;

                    case "doc":
                        Result = "";
                        break;

                    case "docx":
                        Result = "";
                        break;

                    case "pdf":
                        Result = "";
                        break;

                    case "ppt":
                        Result = "";
                        break;

                    case "pptx":
                        Result = "";
                        break;
                }
                return Result;
            }

            public void SelectDocumento()
            {
                string ConnectionString = string.Empty;
                DADocumento DocumentoAccess = new DADocumento();

                _DocumentoEntity.ResultData = DocumentoAccess.SelectDocumento(_DocumentoEntity, sConnectionApplication);

                _ErrorId = DocumentoAccess.ErrorId;
                _ErrorDescription = DocumentoAccess.ErrorDescription;
            }

            public void UploadDocumento()
            {
                string Extension = string.Empty;
                HttpContext httpContext = HttpContext.Current;
                DADocumento DocumentoAccess = new DADocumento();

                if (_DocumentoEntity.FileUpload.PostedFile == null && _DocumentoEntity.FileUpload.PostedFile.ContentLength == 0)
                {
                    _ErrorId = 50000;
                    _ErrorDescription = "El campo Archivo es obligatorio";
                }
                else
                {
                    try
                    {
                        Extension = Path.GetExtension(_DocumentoEntity.FileUpload.PostedFile.FileName);

                        _DocumentoEntity.RepositorioId = Guid.NewGuid().ToString();
                        //_DocumentoEntity.TipoDocumentoId = GetFileType(Extension);
                        _DocumentoEntity.Nombre = Path.GetFileName(_DocumentoEntity.FileUpload.PostedFile.FileName);
                        //_DocumentoEntity.Descripcion = ProgramConstant.ProductFileUpload;
                        //_DocumentoEntity.File = Common.Image.ImageConverter.ConvertImageToBytes(Image.FromStream(_DocumentoEntity.FileUpload.PostedFile.InputStream));


                    }
                    catch (Exception ex)
                    {
                        _ErrorId = 50000;
                        _ErrorDescription = ex.Message;
                    } 
                }

            }
        #endregion
    }
}
