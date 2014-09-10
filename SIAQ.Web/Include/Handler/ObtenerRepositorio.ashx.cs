/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	ObtenerRepositorio
' Autor:	
' Fecha:	04-Septiembre-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Referencias manuales
using GCUtility.Function;
using GCUtility.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using System.IO;
using System.Collections;
using System.Net;
using System.Diagnostics;


namespace SIAQ.Web.Include.Handler
{
    
    public class ObtenerRepositorio1 : IHttpHandler
    {

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();

		
		// Propiedades

		public bool IsReusable
		{
			get { return false; }
		}
		

		// Eventos

        public void ProcessRequest(HttpContext httpContext){
			ENTDocumento oENTDocumento = new ENTDocumento();
			ENTResponse oENTResponse = new ENTResponse();
			BPDocumento oBPDocumento = new BPDocumento();

			MemoryStream msFile;
			FileStream fsFile;
            Byte[] byteFile;

			Int32 DocumentoId;

            try
            {

				// Validaciones de llamada
				if (httpContext.Request.QueryString["key"] == null) { httpContext.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener el id del documento
				DocumentoId = Int32.Parse(gcEncryption.DecryptString(httpContext.Request.QueryString["key"], true));
                
				// Consultar la ruta del archivo
				oENTDocumento.DocumentoId = DocumentoId;
				oENTResponse = oBPDocumento.SelectDocumento_Path(oENTDocumento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }
               
                // Obtener el archivo
				fsFile = new System.IO.FileStream(oENTResponse.dsResponse.Tables[1].Rows[0]["Ruta"].ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);

				byteFile = new Byte[fsFile.Length];
				fsFile.Read(byteFile, 0, (int)fsFile.Length);
				fsFile.Close();

				// Validación
				if (byteFile == null) { throw (new Exception("No se encontró el archivo")); }

				// Cambiar los contet de la página
                httpContext.Response.ContentType = "application/x-unknown/octet-stream";
				httpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + oENTResponse.dsResponse.Tables[1].Rows[0]["Nombre"].ToString() + "\"");

                // Descargar el archivo
				msFile = new MemoryStream(byteFile, true);
				msFile.Write(byteFile, 0, byteFile.Length);
				httpContext.Response.BinaryWrite(byteFile);
				httpContext.Response.Flush();

			}catch (IOException ioEx){

				httpContext.Response.Write(ioEx.Message);

             }catch (Exception ex){

				httpContext.Response.Write(ex.Message);

            }finally{ 

				httpContext.Response.End();

			}

        }

    }
}