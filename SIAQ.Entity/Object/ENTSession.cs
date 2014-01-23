/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTSession
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que contiene las variables de operación del usuario que se autentica en la aplicación
'
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using System.Data;

namespace SIAQ.Entity.Object
{

	public class ENTSession : ENTBase
	{

		// Definiciones
		private Int32		_idUsuario;			// Identificador único de Usuario
      private Int32     _idArea;			// Identificador único de la compañía a la que pertenece el usuario
      private Int32     _idRol;           // Identificador único del Rol al que pertenece el usuario
		private Boolean	_TokenGenerado;	// Indica si el Usuario ya generó el Token de autenticación a la aplicación
		private String		_sEmail;				// Email/username del usuario
		private String		_sNombre;			// Nombre(s) del usuario
		private DataTable	_tblMenu;			// Contienen un DataTable con las opciones del Menú válidas para el usuario
		private DataTable	_tblSubMenu;		// Contienen un DataTable con las opciones del SubMenú válidas para el usuario


		//Constructor

		public ENTSession()
		{
			_idUsuario = 0;
         _idArea = 0;
         _idRol = 0;
			_TokenGenerado = false;
			_sEmail = "";
			_sNombre = "";
			_tblMenu = null;
			_tblSubMenu = null;
		}


		// Propiedades

		///<remarks>
		///   <name>ENTSession.idUsuario</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Usuario</summary>
		public Int32 idUsuario
		{
			get { return _idUsuario; }
			set { _idUsuario = value; }
		}

      ///<remarks>
      ///   <name>ENTSession.idArea</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único de la compañía a la que pertenece el usuario</summary>
      public Int32 idArea
      {
         get { return _idArea; }
         set { _idArea = value; }
      }

      ///<remarks>
      ///   <name>ENTSession.idRol</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del Rol al que pertenece el usuario</summary>
      public Int32 idRol
      {
         get { return _idRol; }
         set { _idRol = value; }
      }

		///<remarks>
		///   <name>ENTSession.TokenGenerado</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor booleano que indica si el Usuario ya generó el Token de autenticación a la aplicación</summary>
		public Boolean TokenGenerado
		{
			get { return _TokenGenerado; }
			set { _TokenGenerado = value; }
		}

		///<remarks>
		///   <name>ENTSession.sEmail</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el email/username del usuario</summary>
		public String sEmail
		{
			get { return _sEmail; }
			set { _sEmail = value; }
		}

		///<remarks>
		///   <name>ENTSession.sNombre</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre(s) del usuario</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTSession.tblMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna un DataTable con las opciones del Menú válidas para el usuario</summary>
		public DataTable tblMenu
		{
			get { return _tblMenu; }
			set { _tblMenu = value; }
		}

		///<remarks>
		///   <name>ENTSession.tblSubMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna un DataTable con las opciones del SubMenú válidas para el usuario</summary>
		public DataTable tblSubMenu
		{
			get { return _tblSubMenu; }
			set { _tblSubMenu = value; }
		}

	}

}
