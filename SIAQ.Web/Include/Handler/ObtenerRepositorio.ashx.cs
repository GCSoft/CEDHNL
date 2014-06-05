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
                RepositorioId = context.Request.QueryString["R"];
                SolicitudId = context.Request.QueryString["S"];

                RepositoryEntity = SelectRepository(RepositorioId, int.Parse(SolicitudId));

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
    }
}