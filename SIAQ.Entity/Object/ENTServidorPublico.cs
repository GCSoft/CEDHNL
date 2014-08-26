/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTServidorPublico
' Autor: Ruben.Cobos
' Fecha: 25-Agosto-2014
'
' Proposito:
'          Clase que modela el catálogo de ServidorPublico de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
	
	public class ENTServidorPublico : ENTBase
	{

		// Definiciones
		private Int32	_ServidorPublicoId;			// Identificador único del Servidor Publico a consultar
		private	Int32	_AutoridadId;				// Identificador único del nivel de autoridad asociado al Servidor Público
		private Int32	_ColoniaId;					// Identificador único de la colonia a la que pertenece el Servidor Público
		private Int32	_EscolaridadId;				// Identificador único de la escolariad del Servidor Público
		private Int32	_EstadoCivilId;				// Identificador único del estado civil del Servidor Público
		private Int32	_NacionalidadId;			// Identificador único de la nacionalidad del Servidor Público
		private Int32	_OcupacionId;				// Identificador único de la ocupación del Servidor Público
		private Int32	_SexoId;					// Identificador único del género del Servidor Público
		private String	_Nombre;					// Nombre del Servidor Público
		private String	_ApellidoPaterno;			// Apellido paterno del Servidor Público
		private String	_ApellidoMaterno;			// Apellido materno del Servidor Público
		private Int32	_Edad;						// Edad del funcionario publico
		private String	_Calle;						// Calle en donde vive el Servidor Publico
		private String	_Telefono;					// Teléfono del Servidor Público
		private String	_CorreoElectronico;			// Correo electrónico del Servidor Público 

		
		//Constructor

		public ENTServidorPublico()
		{
			_ServidorPublicoId = 0;
			_AutoridadId = 0;
			_ColoniaId = 0;
			_EscolaridadId = 0;
			_EstadoCivilId = 0;
			_NacionalidadId = 0;
			_OcupacionId = 0;
			_SexoId = 0;
			_Nombre = "";
			_ApellidoPaterno = "";
			_ApellidoMaterno = "";
			_Edad = 0;
			_Calle = "";
			_Telefono = "";
			_CorreoElectronico = "";
		}


		// Propiedades

		///<remarks>
		///   <name>ENTServidorPublico.ServidorPublicoId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Servidor Publico a consultar</summary>
		public Int32 ServidorPublicoId
		{
			get { return _ServidorPublicoId; }
			set { _ServidorPublicoId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.AutoridadId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del nivel de autoridad asociado al Servidor Público</summary>
		public Int32 AutoridadId
		{
			get { return _AutoridadId; }
			set { _AutoridadId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.ColoniaId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la colonia a la que pertenece el Servidor Público</summary>
		public Int32 ColoniaId
		{
			get { return _ColoniaId; }
			set { _ColoniaId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.EscolaridadId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la escolariad del Servidor Público</summary>
		public Int32 EscolaridadId
		{
			get { return _EscolaridadId; }
			set { _EscolaridadId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.EstadoCivilId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del estado civil del Servidor Público</summary>
		public Int32 EstadoCivilId
		{
			get { return _EstadoCivilId; }
			set { _EstadoCivilId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.NacionalidadId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la nacionalidad del Servidor Público</summary>
		public Int32 NacionalidadId
		{
			get { return _NacionalidadId; }
			set { _NacionalidadId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.OcupacionId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la ocupación del Servidor Público</summary>
		public Int32 OcupacionId
		{
			get { return _OcupacionId; }
			set { _OcupacionId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.SexoId</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del género del Servidor Público</summary>
		public Int32 SexoId
		{
			get { return _SexoId; }
			set { _SexoId = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.Nombre</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Servidor Público</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.ApellidoPaterno</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el apellido paterno del Servidor Público</summary>
		public String ApellidoPaterno
		{
			get { return _ApellidoPaterno; }
			set { _ApellidoPaterno = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.ApellidoMaterno</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el apellido materno del Servidor Público</summary>
		public String ApellidoMaterno
		{
			get { return _ApellidoMaterno; }
			set { _ApellidoMaterno = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.Edad</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la edad del funcionario publico</summary>
		public Int32 Edad
		{
			get { return _Edad; }
			set { _Edad = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.Calle</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la calle en donde vive el Servidor Publico</summary>
		public String Calle
		{
			get { return _Calle; }
			set { _Calle = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.Telefono</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el teléfono del Servidor Publico</summary>
		public String Telefono
		{
			get { return _Telefono; }
			set { _Telefono = value; }
		}

		///<remarks>
		///   <name>ENTServidorPublico.CorreoElectronico</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el correo electrónico del Servidor Publico</summary>
		public String CorreoElectronico
		{
			get { return _CorreoElectronico; }
			set { _CorreoElectronico = value; }
		}

	}

}
