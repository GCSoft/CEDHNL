/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	Index
' Autor:		GCSoft - Web Project Creator BETA 1.0
' Fecha:		21-Octubre-2013
'
' Descripción:
'				Canaliza la aplicación al módulo de autenticación correspondiente
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web
{
   public partial class Index : System.Web.UI.Page
   {
      

      // Eventos de la página

      protected void Page_Load(object sender, EventArgs e){

         Response.Redirect("Application/WebApp/Public/frmLogin.aspx", false);
      }

   }
}
