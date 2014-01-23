/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTSubMenu
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela el catálogo de Sub Menús de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

namespace SIAQ.Entity.Object
{

	public class ENTSubMenu : ENTBase
	{
	
		// Definiciones
		private Int32	_idSubMenu;			// Identificador único del SubMenu
      private Int32  _idRol;           // Identificador único del Rol al que pertenece el usuario que consulta el listado de SubMenús
		private Int32	_idMenu;          // Identificador único de Menu
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del SubMenu
		private String	_sPageName;			// Nombre de la Pagina aspx del SubMenú
		private String	_sURL;				// Dirección relativa completa de la Pagina aspx del SubMenú
		private Int16	_tiActivo;			// Control de baja lógica de registro
      private Int16  _tiRequired;      // Determina si el SubMenú es requerido o no al momento de diseñar un rol

		
		 //Constructor

		public ENTSubMenu(){
			_idMenu = 0;
         _idRol = 0;
			_idSubMenu = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_sPageName = "";
			_sURL = "";
			_tiActivo = 0;
         _tiRequired = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTMenu.idMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de Menu</summary>
		public Int32 idMenu
		{
			get { return _idMenu; }
			set { _idMenu = value; }
		}

      ///<remarks>
      ///   <name>ENTMenu.idRol</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del Rol al que pertenece el usuario que consulta el listado de SubMenús</summary>
      public Int32 idRol
      {
         get { return _idRol; }
         set { _idRol = value; }
      }
		
		///<remarks>
		///   <name>ENTSubMenu.idSubMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de SubMenu</summary>
		public Int32 idSubMenu
		{
			get { return _idSubMenu; }
			set { _idSubMenu = value; }
		}
		
		///<remarks>
		///   <name>ENTSubMenu.dtFechaCreacion</name>
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
		///   <name>ENTSubMenu.sDescripcion</name>
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
		///   <name>ENTSubMenu.sNombre</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del SubMenu</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}
		
		///<remarks>
		///   <name>ENTSubMenu.sPageName</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre de la Pagina aspx del SubMenú</summary>
		public String sPageName
		{
			get { return _sPageName; }
			set { _sPageName = value; }
		}
		
		///<remarks>
		///   <name>ENTSubMenu.sURL</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna la dirección relativa completa de la Pagina aspx del SubMenú</summary>
		public String sURL
		{
			get { return _sURL; }
			set { _sURL = value; }
		}

		///<remarks>
		///   <name>ENTSubMenu.tiActivo</name>
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
      ///   <name>ENTSubMenu.tiRequired</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna un valor que determina si el SubMenú es requerido o no al momento de diseñar un rol</summary>
      public Int16 tiRequired
      {
         get { return _tiRequired; }
         set { _tiRequired = value; }
      }
	
	}
	
}
