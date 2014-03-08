/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTArea
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela el catálogo de Áreas de la CEDH de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace SIAQ.Entity.Object
{
   
   public class ENTArea : ENTBase
   {

      // Definiciones
		private Int32	_idArea;          // Identificador único de Area
		private String	_dtFechaCreacion;	// Fecha de creación del registro
		private String	_sDescripcion;		// Descripción/notas del registro
		private String	_sNombre;			// Nombre del Area
		private Int16	_tiActivo;			// Control de baja lógica de registro
      private Int16  _tiSistema;			// Determina si el área se visualizará en los combos o es para uso exclusivo de sistemas

      private DataSet _ResultData;     // Otras propiedades
      private string _Descripcion;     // Valor de Descripcion

		
		 //Constructor

		public ENTArea(){
			_idArea = 0;
			_dtFechaCreacion = "";
			_sDescripcion = "";
			_sNombre = "";
			_tiActivo = 0;
         _tiSistema = 0;
		}


      // Propiedades

		///<remarks>
		///   <name>ENTArea.idArea</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Área de la CEDH</summary>
		public Int32 idArea
		{
			get { return _idArea; }
			set { _idArea = value; }
		}
		
		///<remarks>
		///   <name>ENTArea.dtFechaCreacion</name>
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
		///   <name>ENTArea.sDescripcion</name>
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
		///   <name>ENTArea.sNombre</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre de la Compañía</summary>
		public String sNombre
		{
			get { return _sNombre; }
			set { _sNombre = value; }
		}

		///<remarks>
		///   <name>ENTArea.tiActivo</name>
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
      ///   <name>ENTArea.tiSistema</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna un valor que determina si el área se visualizará en los combos o es para uso exclusivo de sistemas</summary>
      public Int16 tiSistema
      {
         get { return _tiSistema; }
         set { _tiSistema = value; }
      }


      public string Descripcion{
         get { return _Descripcion; }
         set { _Descripcion = value; }
      }

      public DataSet ResultData{
         get { return _ResultData; }
         set { _ResultData = value; }
      }

   }

}
