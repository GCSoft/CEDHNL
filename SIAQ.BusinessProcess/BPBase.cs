/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPBase
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'           Clase base. Todas clases definidas en el proyecto [BusinessProcess.Object] heredarán de esta clase.
'
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using System.Configuration;

namespace SIAQ.BusinessProcess
{

   public class BPBase
   {

      // Definiciones
      private Int16  _iSessionTimeout;          // Periodo en minutos que durará la sesión de un usuario
      private String _sApplicationURL;          // URL de la publicación aplicación
      private String _sConnectionApplication;   // Cadena de conexión a la base de datos de la Aplicación

      // Constructor
      public BPBase()
      {
         _iSessionTimeout        = Int16.Parse(ConfigurationManager.AppSettings["Application.SessionTimeout"].ToString());
         _sApplicationURL        = ConfigurationManager.AppSettings["Application.URL"].ToString();
         _sConnectionApplication = ConfigurationManager.ConnectionStrings["Application.DBCnn"].ToString();
      }


      // Propiedades

      ///<remarks>
      ///   <name>BPBase.iSessionTimeout</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene el periodo en minutos que durará la sesión de un usuario</summary>
      public Int16 iSessionTimeout
      {
         get { return _iSessionTimeout; }
      }

      ///<remarks>
      ///   <name>BPBase.sApplicationURL</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene la URL de la publicación aplicaciónn</summary>
      public String sApplicationURL
      {
         get { return _sApplicationURL; }
      }

      ///<remarks>
      ///   <name>BPBase.sConnectionApplication</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene la cadena de conexión a la base de datos de la aplicación</summary>
      public String sConnectionApplication
      {
         get { return _sConnectionApplication; }
      }

      
   }

}
