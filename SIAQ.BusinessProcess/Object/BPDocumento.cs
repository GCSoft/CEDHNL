using System;
using System.Collections.Generic;
using System.Configuration;
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
            public void DeleteRepositorioSE()
            {
                DADocumento DocumentoAccess = new DADocumento();

                DocumentoAccess.DeleteRepositorioSE(_DocumentoEntity, sConnectionRepositorio);

                _ErrorId = DocumentoAccess.ErrorId;
                _ErrorDescription = DocumentoAccess.ErrorDescription;
            }

            public string GetFileFormat(string FileExtension)
            {
                string Result = string.Empty;

                switch (FileExtension)
                {
                    case ".jpg":
                        Result = "81944c0f-8fa6-4e9b-b7b8-74afeccfc54c";
                        break;

                    case ".gif":
                        Result = "31bb2d11-2f6f-47be-891b-4ff3113b8b73";
                        break;

                    case ".png":
                        Result = "0d4186fa-3b0f-49dc-a55f-a362ad893211";
                        break;

                    case ".bmp":
                        Result = "8f455f2a-0492-487c-a729-7b4c4913257d";
                        break;

                    case ".doc":
                        Result = "275ebe4c-d4a8-4f4d-8dda-98f8c9ccfe70";
                        break;

                    case ".docx":
                        Result = "96a31530-202c-44ad-ba1e-3e07777a0d7c";
                        break;

                    case ".pdf":
                        Result = "523e371f-07e8-46c7-81f4-a92a843fa1a1";
                        break;

                    case ".ppt":
                        Result = "cba3eb71-5c11-489d-9b92-da1cc7fbe8af";
                        break;

                    case ".pptx":
                        Result = "bd168a5e-ec4c-47d7-96a7-03f05ad77bca";
                        break;

                    default:
                        Result = "c67454c0-2a89-4053-bbf9-bf0edcdd136c";
                        break;
                }

                return Result;
            }

            public static string GetIconoDocumento(string TipoDocumentoId)
            {
                string IconoPath = string.Empty;

                switch (TipoDocumentoId)
                {
                    // .jpg
                    case "81944c0f-8fa6-4e9b-b7b8-74afeccfc54c":
                        IconoPath = "FileIcon_Foto.png";
                        break;

                    // .gif
                    case "31bb2d11-2f6f-47be-891b-4ff3113b8b73":
                        IconoPath = "FileIcon_Foto.png";
                        break;

                    // .png
                    case "0d4186fa-3b0f-49dc-a55f-a362ad893211":
                        IconoPath = "FileIcon_Foto.png";
                        break;

                    // .bmp
                    case "8f455f2a-0492-487c-a729-7b4c4913257d":
                        IconoPath = "FileIcon_Foto.png";
                        break;

                    // .doc y .docx
                    case "275ebe4c-d4a8-4f4d-8dda-98f8c9ccfe70":
                    case "96a31530-202c-44ad-ba1e-3e07777a0d7c":
                        IconoPath = "FileIcon_Word.png";
                        break;

                    // .pdf
                    case "523e371f-07e8-46c7-81f4-a92a843fa1a1":
                        IconoPath = "FileIcon_Pdf.png";
                        break;

                    // .ppt y .pptx
                    case "cba3eb71-5c11-489d-9b92-da1cc7fbe8af":
                    case "bd168a5e-ec4c-47d7-96a7-03f05ad77bca":
                        IconoPath = "PowerPointIcon.png";
                        break;

                    // Formato desconocido
                    default:
                        IconoPath = "UnknownIcon.png";
                        break;
                }

                return ConfigurationManager.AppSettings["Application.Url.Icon"].ToString() + IconoPath;
            }

            public void SaveRepositorioSE()
            {
                DADocumento DocumentoAccess = new DADocumento();

                UploadDocumento();

				if (_ErrorId == 0){

					DocumentoAccess.InsertRepositorioSE(_DocumentoEntity, sConnectionRepositorio);

					_ErrorId = DocumentoAccess.ErrorId;
					_ErrorDescription = DocumentoAccess.ErrorDescription;
				}
            }

            public void SelectRepositorioSE()
            {
                string ConnectionString = string.Empty;
                DADocumento DocumentoAccess = new DADocumento();

                _DocumentoEntity.ResultData = DocumentoAccess.SelectRepositorioSE(_DocumentoEntity, sConnectionRepositorio);

                _ErrorId = DocumentoAccess.ErrorId;
                _ErrorDescription = DocumentoAccess.ErrorDescription;
            }

            public void SelectRepositorioSEConDocumento()
            {
                string ConnectionString = string.Empty;
                DADocumento DocumentoAccess = new DADocumento();

                _DocumentoEntity.ResultData = DocumentoAccess.SelectRepositorioSEConDocumento(_DocumentoEntity, sConnectionRepositorio);

                _ErrorId = DocumentoAccess.ErrorId;
                _ErrorDescription = DocumentoAccess.ErrorDescription;
            }

            private void UploadDocumento()
            {
                int DocumentoLen = 0;
                string Extension = string.Empty;
                Stream DocumentoStream;
                byte[] DocumentoBytes;
                HttpContext httpContext = HttpContext.Current;
                DADocumento DocumentoAccess = new DADocumento();

                try
                {
                    if (_DocumentoEntity.FileUpload.PostedFile == null && _DocumentoEntity.FileUpload.PostedFile.ContentLength == 0)
                    {
                        _ErrorId = 50000;
                        _ErrorDescription = "El campo Archivo es obligatorio";
                    }
                    else
                    {
                            Extension = Path.GetExtension(_DocumentoEntity.FileUpload.PostedFile.FileName);
                            DocumentoStream = _DocumentoEntity.FileUpload.PostedFile.InputStream;
                            DocumentoLen = _DocumentoEntity.FileUpload.PostedFile.ContentLength;
                            DocumentoBytes = new byte[DocumentoLen];
                            DocumentoStream.Read(DocumentoBytes, 0, DocumentoLen);

                            _DocumentoEntity.RepositorioId = Guid.NewGuid().ToString();
                            _DocumentoEntity.FormatoDocumentoId = GetFileFormat(Extension);
                            _DocumentoEntity.Documento = DocumentoBytes;
                    }
                }
                catch (Exception ex)
                {
                    _ErrorId = 50000;
                    _ErrorDescription = ex.Message;
                }
            }
        #endregion


		///<remarks>
		///   <name>BPDocumento.DeleteDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteDocumento(ENTDocumento oENTDocumento){
			DADocumento oDADocumento = new DADocumento();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADocumento.DeleteDocumento(oENTDocumento, this.sConnectionRepositorio, 0);

			// Validación de error en consulta
			if (oENTResponse.GeneratesException) { return oENTResponse; }

			// Validación de mensajes de la BD
			oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
			if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}


		///<remarks>
		///   <name>BPDocumento.InsertDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Guarda un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertDocumento(ENTDocumento oENTDocumento){
			DADocumento oDADocumento = new DADocumento();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADocumento.InsertDocumento(oENTDocumento, this.sConnectionRepositorio, 0);

			// Validación de error en consulta
			if (oENTResponse.GeneratesException) { return oENTResponse; }

			// Validación de mensajes de la BD
			oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
			if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}


		///<remarks>
		///   <name>BPDocumento.SelectDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectDocumento(ENTDocumento oENTDocumento){
			DADocumento oDADocumento = new DADocumento();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDADocumento.SelectDocumento(oENTDocumento, this.sConnectionRepositorio, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

    }
}
