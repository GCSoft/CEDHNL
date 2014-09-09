using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

using System.IO;
using System.Collections;
using System.Net;
using System.Diagnostics;


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

            string DocumentoNombre = "";
            string DocumentoNumero = "";

            try
            {
                DocumentoNombre = context.Request.QueryString["DocumentoNombre"];
                DocumentoNumero = context.Request.QueryString["DocumentoNumero"];


                //MuestraDocumento(context, DocumentoNombre, DocumentoNumero);

                if (context.Request.QueryString["DocumentoId"] == null)
                {

                    RepositorioId = context.Request.QueryString["R"];
                    SolicitudId = context.Request.QueryString["S"];
                }

                // Variables para manejo de archivos
                string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Files\\" + DocumentoNumero + "\\" + DocumentoNombre;
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, (int)fs.Length);
                fs.Close();

                context.Response.ContentType = "application/x-unknown/octet-stream";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + DocumentoNombre + "\"");

                //AbrirArchivo(DocumentoNombre);
                if (bt != null)
                {
                    System.IO.MemoryStream stream1 = new System.IO.MemoryStream(bt, true);
                    stream1.Write(bt, 0, bt.Length);
                    context.Response.BinaryWrite(bt);
                    context.Response.Flush();
                }
            }

            catch
            {
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(File);
            }
            finally
            { context.Response.End(); }
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