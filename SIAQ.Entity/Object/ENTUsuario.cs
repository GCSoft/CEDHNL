/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTUsuario
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela el catálogo de Usuarios de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

namespace SIAQ.Entity.Object
{

	public class ENTUsuario : ENTBase
	{
	
		// Definiciones
		private Int32	_idUsuario;			// Identificador único de Usuario
		private Int32	_idArea;            // Identificador único del Área de la CEDH a la que pertenece el usuario
		private Int32	_idRol;				// Identificador único del Rol de Usuario
		private Int32	_SexoId;
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sApellidoMaterno;  // Apellido de la madre del usuario
		private String	_sApellidoPaterno;	// Apellido del padre del usuario
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sEmail;			// Email/username del usuario
		private String	_sNombre;			// Nombre(s) del usuario
		private String	_sOldPassword;		// Password anterior encriptado del usuario. Utilizado en cambio de contraseña.
		private String	_sPassword;			// Password encriptado
		private Int16	_tiActivo;			// Control de baja lógica de registro

		
		 //Constructor

		public ENTUsuario(){
			_idUsuario = 0;
			_idArea = 0;
			_idRol = 0;
			_SexoId = 0;
			_dtFechaCreacion = "";
			_sApellidoMaterno = "";
			_sApellidoPaterno = "";
			_sDescripcion = "";
			_sEmail = "";
			_sNombre = "";
			_sOldPassword = "";
			_sPassword = "";
			_tiActivo = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTUsuario.idUsuario</name>
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
		///   <name>ENTUsuario.idArea</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Área de la CEDH a la que pertenece el usuario</summary>
		public Int32 idArea
		{
			get { return _idArea; }
			set { _idArea = value; }
		}
		
		///<remarks>
		///   <name>ENTUsuario.idRol</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Rol de Usuario</summary>
		public Int32 idRol
		{
			get { return _idRol; }
			set { _idRol = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.SexoId</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Sexo de Usuario</summary>
		public Int32 SexoId
		{
			get { return _SexoId; }
			set { _SexoId = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.dtFechaCreacion</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de creación del registro</summary>
		public String dtFechaCreacion
		{
			get { return _dtFechaCreacion; }
			set { _dtFechaCreacion = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.sApellidoMaterno</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el apellido de la madre del usuario</summary>
		public String sApellidoMaterno
		{
			get { return _sApellidoMaterno; }
			set { _sApellidoMaterno = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.sApellidoPaterno</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el apellido del padre del usuario</summary>
		public String sApellidoPaterno
		{
			get { return _sApellidoPaterno; }
			set { _sApellidoPaterno = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.sDescripcion</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna la descripción/notas del registro</summary>
		public String sDescripcion
		{
			get { return _sDescripcion; }
			set { _sDescripcion = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.sEmail</name>
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
		///   <name>ENTUsuario.sNombre</name>
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
		///   <name>ENTUsuario.sOldPassword</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el password anterior encriptado del usuario. Utilizado en cambio de contraseña.</summary>
		public String sOldPassword
		{
			get { return _sOldPassword; }
			set { _sOldPassword = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.sPassword</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el password encriptado</summary>
		public String sPassword
		{
			get { return _sPassword; }
			set { _sPassword = value; }
		}

		///<remarks>
		///   <name>ENTUsuario.tiActivo</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
		public Int16 tiActivo
		{
			get { return _tiActivo; }
			set { _tiActivo = value; }
		}
	
	}
	
}
