/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTRol
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela el catálogo de Roles de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{

	public class ENTRol : ENTBase
	{
	
		// Definiciones
		private Int32     _idRol;			   // Identificador único de Rol
		private String    _dtFechaCreacion;	// Fecha de creación del registro
		private String    _sDescripcion;		// Descripción/notas del registro
		private String    _sNombre;			// Nombre del Rol
		private Int16     _tiActivo;			// Control de baja lógica de registro
      private DataTable _tblSubMenu;		// DataTable el cual contiene los ID's de las opciones del SubMenú asociadas al Rol

		
		 //Constructor

		public ENTRol(){
			_idRol = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;
			_tblSubMenu = null;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTRol.idRol</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Rol</summary>
		public Int32 idRol
		{
			get { return _idRol; }
			set { _idRol = value; }
		}
		
		///<remarks>
		///   <name>ENTRol.dtFechaCreacion</name>
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
		///   <name>ENTRol.sDescripcion</name>
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
		///   <name>ENTRol.sNombre</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Rol</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTRol.tiActivo</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
		public Int16 tiActivo
		{
			get { return _tiActivo; }
			set { _tiActivo = value; }
		}
		
		///<remarks>
      ///   <name>ENTUsuario.tblSubMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna un DataTable el cual contiene los ID's de las opciones del SubMenú asociadas al Rol</summary>
      public DataTable tblSubMenu
		{
			get { return _tblSubMenu; }
			set { _tblSubMenu = value; }
		}
	
	}
	
}
