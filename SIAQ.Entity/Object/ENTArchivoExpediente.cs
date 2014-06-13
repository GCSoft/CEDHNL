/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTArchivoExpediente
' Autor: Ruben.Cobos
' Fecha: 11-Junio-2014
'
' Proposito:
'          Clase que modela el catálogo de ArchivoExpedientees de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{

	public class ENTArchivoExpediente : ENTBase
	{

		// Definiciones
		private Int32	_ExpedienteId;			// Identificador único del Expediente a consultar
		private Int32	_idUsuario;				// Identificador único del Usuario que tiene asignado el Expediente
		private Int32	_idUsuario_Presta;		// Identificador único del Usuario que asigna el Expediente
		private Int32	_idUsuario_Recibe;		// Identificador único del Usuario que recibe el Expediente
		private Int32	_UbicacionExpedienteId;	// Identificador único de la Ubicacion del Expediente a consultar
		private String  _Comentario;			// Comentario en el expediente dentro del módulo de archivo
		private String	_Nombre;				// Nombre a filtrar
		private String	_Numero;				// Número de expediente a filtrar
		private String	_Quejoso;				// Nombre del quejoso que levanta la denuncia

		
		 //Constructor

		public ENTArchivoExpediente()
		{
			_ExpedienteId = 0;
			_idUsuario = 0;
			_idUsuario_Presta = 0;
			_idUsuario_Recibe = 0;
			_UbicacionExpedienteId = 0;
			_Comentario = "";
			_Nombre = "";
			_Numero = "";
			_Quejoso = "";
		}


		// Propiedades

		///<remarks>
		///   <name>ENTArchivoExpediente.ExpedienteId</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Expediente a consultar</summary>
		public Int32 ExpedienteId
		{
			get { return _ExpedienteId; }
			set { _ExpedienteId = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.idUsuario</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Usuario que tiene asignado el Expediente</summary>
		public Int32 idUsuario
		{
			get { return _idUsuario; }
			set { _idUsuario = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.idUsuario_Presta</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Usuario que asigna el Expediente/summary>
		public Int32 idUsuario_Presta
		{
			get { return _idUsuario_Presta; }
			set { _idUsuario_Presta = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.idUsuario_Recibe</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Usuario que recibe el Expediente</summary>
		public Int32 idUsuario_Recibe
		{
			get { return _idUsuario_Recibe; }
			set { _idUsuario_Recibe = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.UbicacionExpedienteId</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Ubicacion del Expediente a consultar</summary>
		public Int32 UbicacionExpedienteId
		{
			get { return _UbicacionExpedienteId; }
			set { _UbicacionExpedienteId = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.Comentario</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el comentario en el expediente dentro del modulo de Archivo</summary>
		public String Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.Nombre</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el Nombre a filtrar</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.Numero</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de expediente a filtrar</summary>
		public String Numero
		{
			get { return _Numero; }
			set { _Numero = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.Quejoso</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del quejoso que levanta la denuncia</summary>
		public String Quejoso
		{
			get { return _Quejoso; }
			set { _Quejoso = value; }
		}
		

	}
}
