/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BusinessProcess.Page
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'         Sobreescritura del método Page_PreLoad la cual se utilizará como clase padre de las paginas del proyecto,
'        implementa la seguridad de la aplicación.
'
' Errores:
'   V01:  Error general del método Overload_PageLoad
'   V02:  El usuario no tiene permisos de acceder a esta página
'   V03:  Intento de acceso como [System Administrator]
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.DataAccess.Object;
using System.Configuration;

namespace SIAQ.BusinessProcess.Page
{

   public class BPPage : System.Web.UI.Page
   {

      // Asignación de evento PreLoad

      override protected void OnInit(EventArgs e){
         this.PreLoad += new System.EventHandler(this.Override_PagePreLoad);
      }


      // Evento PreLoad

      protected void Override_PagePreLoad(object sender, EventArgs e){
         DAArea oDAArea = new DAArea();
         ENTSession oENTSession;

         Encryption utilEncryption = new Encryption();

         String sKey = "";
         String sPage = "";

         // Validación. Solo la primera vez que entre a la página
         if (this.IsPostBack) { return; }

         // Mensaje de error general
         sKey = utilEncryption.EncryptString("[V01] Acceso denegado", true);

         // Sesión
         if (this.Session["oENTSession"] == null){
            this.Response.Redirect("~/Index.aspx", true);
         }

         // Información de Sesión
         oENTSession = (ENTSession)this.Session["oENTSession"];

         // Token generado
         if (!oENTSession.TokenGenerado){
            this.Response.Redirect("~/Index.aspx", true);
         }

         // Página que esta visitando
         sPage = this.Request.Url.AbsolutePath;
         sPage = sPage.Split(new Char[] { '/' })[sPage.Split(new Char[] { '/' }).Length - 1];

         // Validación de permisos en la página actual
         if (sPage != "AppIndex.aspx" && sPage != "saLogout.aspx" && sPage != "saNotificacion.aspx"){

            // Permisos
            if (oENTSession.tblSubMenu.Select("sPageName = '" + sPage + "'").Length < 1){
               sKey = utilEncryption.EncryptString("[V02] No tiene permisos para acceder a esta página", true);
               this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sKey, true);
            }

            // Compañía activa
            if ( oENTSession.idArea != 1 ){
               if (oDAArea.IsAreaActive(oENTSession.idArea, ConfigurationManager.ConnectionStrings["Application.DBCnn"].ToString(), 0) == false){
                  sKey = utilEncryption.EncryptString("[V04] Su compañía no tiene permisos para acceder a esta página", true);
                  this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sKey, true);
               }
            }

         }

         // Validación de acceso a opciones [System Administrator]
         if ((sPage == "scatArea.aspx" || sPage == "scatMenu.aspx" || sPage == "scatSubMenu.aspx") && (oENTSession.idArea != 1) ){

            sKey = utilEncryption.EncryptString("[V03] No tiene permisos para acceder a esta página", true);
            this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sKey, true);
         }

         // Deshabilitar caché
         this.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

      }

   }

}
