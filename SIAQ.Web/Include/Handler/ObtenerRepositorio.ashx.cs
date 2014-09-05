using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Include.Handler
{
    /// <summary>
    /// Summary description for ObtenerRepositorio1
    /// </summary>
    public class ObtenerRepositorio1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string RepositorioId = string.Empty;
            string SolicitudId = string.Empty;
            byte[] File = new byte[] { 0 };
            ENTDocumento RepositoryEntity = new ENTDocumento();

            try
            {

				if (context.Request.QueryString["DocumentoId"] == null)
				{

					RepositorioId = context.Request.QueryString["R"];
					SolicitudId = context.Request.QueryString["S"];

					RepositoryEntity = SelectRepository(RepositorioId, int.Parse(SolicitudId));
				}
				else 
				{

					RepositoryEntity = SelectRepository_New(Int32.Parse(context.Request.QueryString["DocumentoId"]));
				}

                context.Response.BinaryWrite(RepositoryEntity.Documento);
            }

            catch
            {
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(File);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected ENTDocumento SelectRepository(string RepositorioId, int SolicitudId)
        {
            BPDocumento RepositoryProcess = new BPDocumento();
            ENTDocumento RepositoryEntity = new ENTDocumento();

            RepositoryProcess.DocumentoEntity.RepositorioId = RepositorioId;
            RepositoryProcess.DocumentoEntity.SolicitudId = SolicitudId;

            RepositoryProcess.SelectRepositorioSEConDocumento();

            if (RepositoryProcess.ErrorId == 0)
            {
                if (RepositoryProcess.DocumentoEntity.ResultData.Tables[0].Rows.Count > 0)
                {
                    RepositoryEntity.Documento = (byte[])RepositoryProcess.DocumentoEntity.ResultData.Tables[0].Rows[0]["Documento"];
                    RepositoryEntity.Nombre = RepositoryProcess.DocumentoEntity.ResultData.Tables[0].Rows[0]["NombreDocumento"].ToString();
                }
            }

            return RepositoryEntity;
        }

		protected ENTDocumento SelectRepository_New(Int32 DocumentoId){
			ENTDocumento oENTDocumento = new ENTDocumento();
			ENTResponse oENTResponse = new ENTResponse();

			BPDocumento oBPDocumento = new BPDocumento();

			try
			{

			    // Formulario
				oENTDocumento.DocumentoId = DocumentoId;

			    // Transacción
				oENTResponse = oBPDocumento.SelectDocumento(oENTDocumento);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			    
				// Obtener el documento
				oENTDocumento.Documento = (byte[])oENTResponse.dsResponse.Tables[0].Rows[0]["Archivo"];

			}catch (Exception){
				
			}

			// Retornar el documento
			return oENTDocumento;

		}

    }
}