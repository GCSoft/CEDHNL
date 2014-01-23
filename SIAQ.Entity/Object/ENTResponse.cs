/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTResponse
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que controla las respuestas entre las diferentes capas de la aplicación
'
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using System.Data;

namespace SIAQ.Entity.Object
{
   
   public class ENTResponse : ENTBase
   {


      // Definiciones

      private DataSet   _dsResponse;            // Contiene cualquier dataset de respuesta
      private bool      _GeneratesException;    // Indica si la llamada al método generó una excepción
      private string    _sErrorMessage;         // Contiene el mensaje de error cuando se genera una excepción
      private string    _sMessage;				   // Contiene un mensaje de respuesta de la base de datos


      // Constructor

      public ENTResponse()
      {
         _dsResponse = null;
         _GeneratesException = false;
         _sErrorMessage = "";
         _sMessage = "";
      }


      // Metodos publicos

      ///<remarks>
      ///   <name>ENTResponse.ExceptionRaised</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Indica la generación de una excepción en el método</summary>
      ///<param name="sErrorMessage">Descripción del mensaje de error</param>
      public void ExceptionRaised(string sErrorMessage)
      {
         _GeneratesException = true;
         _sErrorMessage = sErrorMessage;
      }


      // Propiedades

      ///<remarks>
      ///   <name>ENTResponse.dsResponse</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna un dataset de respuesta</summary>
      public DataSet dsResponse
      {
         get { return _dsResponse; }
         set { _dsResponse = value; }
      }

      ///<remarks>
      ///   <name>ENTResponse.GeneratesException</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Indica si la llamada al método generó una excepción</summary>
      public bool GeneratesException
      {
         get { return _GeneratesException; }
      }

      ///<remarks>
      ///   <name>ENTResponse.sErrorMessage</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Contiene el mensaje de error cuando se genera una excepción</summary>
      public string sErrorMessage
      {
         get { return _sErrorMessage; }
      }

      ///<remarks>
      ///   <name>ENTResponse.sMessage</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna un mensaje de respuesta de la base de datos</summary>
      public string sMessage
      {
         get { return _sMessage; }
         set { _sMessage = value; }
      }

   }

}
