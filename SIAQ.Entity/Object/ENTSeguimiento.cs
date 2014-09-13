/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTSeguimiento
' Autor: Ruben.Cobos
' Fecha: 11-Septiembre-2014
'
' Proposito:
'          Clase que modela propiedades utilizadas en el módulo de Seguimiento
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
	public class ENTSeguimiento : ENTBase
	{


		// Definiciones
		private Int32	_EstatusId;					// Identificador único del Estatus de la recomendación
		private Int32	_ExpedienteId;				// Identificador único del Expediente a consultar
		private Int32	_FuncionarioId;				// Identificador único del funcionario asociada la recomendación
		private Int32	_ModuloId;					// Identificador único del Módulo en donde se realiza la transacción
		private Int32	_RecomendacionId;			// Identificador único de la recomendación
		private Int32	_UsuarioId;					// Identificador único del Usuario
		private Int16	_AcuerdoNoResponsabilidad;	// Determina con un 0 si es Recomendación, un 1 si es acuerdo o un 2 para ambos casos
		private Int16	_Nivel;						// Nivel de transacción
		private String	_ExpedienteNumero;			// Número de expediente a consultar
		private String	_FechaDesde;				// Fecha inicial de la consulta
		private String	_FechaHasta;				// Fecha final de la consulta
		private String	_NombreAutoridad;			// Nombre de la autoridad a filtrar
		private String	_PuestoAutoridad;			// Puesto de la autoridad a filtrar
		private String	_RecomendacionNumero;		// Número de recomendación a consultar


		 //Constructor

		public ENTSeguimiento()
		{
			_EstatusId = 0;
			_ExpedienteId = 0;
			_FuncionarioId = 0;
			_ModuloId = 0;
			_RecomendacionId = 0;
			_UsuarioId = 0;
			_AcuerdoNoResponsabilidad = 2;
			_Nivel = -1;
			_ExpedienteNumero = "";
			_FechaDesde = "";
			_FechaHasta = "";
			_NombreAutoridad = "";
			_PuestoAutoridad = "";
			_RecomendacionNumero = "";
		}


		// Propiedades

		///<remarks>
		///   <name>ENTSeguimiento.EstatusId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Estatus de la recomendación</summary>
		public Int32 EstatusId
		{
			get { return _EstatusId; }
			set { _EstatusId = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.ExpedienteId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Expediente a consultar</summary>
		public Int32 ExpedienteId
		{
			get { return _ExpedienteId; }
			set { _ExpedienteId = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.FuncionarioId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del funcionario asociada la recomendación</summary>
		public Int32 FuncionarioId
		{
			get { return _FuncionarioId; }
			set { _FuncionarioId = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.ModuloId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Módulo en donde se realiza la transacción</summary>
		public Int32 ModuloId
		{
			get { return _ModuloId; }
			set { _ModuloId = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.RecomendacionId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Recomendación</summary>
		public Int32 RecomendacionId
		{
			get { return _RecomendacionId; }
			set { _RecomendacionId = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.UsuarioId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Usuario</summary>
		public Int32 UsuarioId
		{
			get { return _UsuarioId; }
			set { _UsuarioId = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.AcuerdoNoResponsabilidad</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si se trata de un recomendación (0), Acuerdo de no responsabilidad (1) o ambos casos (2)</summary>
		public Int16 AcuerdoNoResponsabilidad
		{
			get { return _AcuerdoNoResponsabilidad; }
			set { _AcuerdoNoResponsabilidad = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.Nivel</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nivel de la transacción</summary>
		public Int16 Nivel
		{
			get { return _Nivel; }
			set { _Nivel = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.ExpedienteNumero</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de expediente a consultar</summary>
		public String ExpedienteNumero
		{
			get { return _ExpedienteNumero; }
			set { _ExpedienteNumero = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.FechaDesde</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha inicial de la consulta</summary>
		public String FechaDesde
		{
			get { return _FechaDesde; }
			set { _FechaDesde = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.FechaHasta</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha final de la consulta</summary>
		public String FechaHasta
		{
			get { return _FechaHasta; }
			set { _FechaHasta = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.NombreAutoridad</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre de la autoridad a filtrar</summary>
		public String NombreAutoridad
		{
			get { return _NombreAutoridad; }
			set { _NombreAutoridad = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.PuestoAutoridad</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el puesto de la autoridad a filtrar</summary>
		public String PuestoAutoridad
		{
			get { return _PuestoAutoridad; }
			set { _PuestoAutoridad = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.RecomendacionNumero</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de recomendación a consultar</summary>
		public String RecomendacionNumero
		{
			get { return _RecomendacionNumero; }
			set { _RecomendacionNumero = value; }
		}

	}
}
