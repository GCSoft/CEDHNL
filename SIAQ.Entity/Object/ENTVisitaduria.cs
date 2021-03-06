﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTVisitaduria
' Autor: Ruben.Cobos
' Fecha: 11-Junio-2014
'
' Proposito:
'          Clase que modela propiedades utilizadas en el módulo de Visitadurías
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
	public class ENTVisitaduria : ENTBase
	{

		// Definiciones
		private Int32	_AreaId;					// Identificador único del Área
		private Int32	_AutoridadId;				// Identificador único de la Autoridad
		private Int32	_CalificacionAutoridadId;	// Identificador único de la Calificación de la Autoridad
		private Int32	_CalificacionVozId;			// Identificador único de la Calificación de la Voz
		private Int32	_CiudadanoId;				// Identificador único del Ciudadano asociado al Expediente
		private Int32	_ComentarioId;				// Identificador único del Comentario del Expediente
		private Int32	_EstatusId;					// Identificador único del Estatus del Expediente
		private Int32	_ExpedienteId;				// Identificador único del Expediente a consultar
		private Int32	_FuncionarioId;				// Identificador único del funcionario asociado al Expediente
		private Int32	_ModuloId;					// Identificador único del Módulo en donde se realiza la transacción
		private Int32	_TipoParticipacionId;		// Identificador único del tipo de participación de un ciudadano asociado a un Expediente
		private Int32	_TipoResolucionId;			// Identificador único del Tipo de Resolución
		private Int32	_UsuarioId;					// Identificador único del Usuario
		private Int32	_VozId;						// Identificador único de la Voz señalatoria de una Autoridad
		private String	_Acuerdo;					// Acuerdo de calificación definitiva
		private String	_Comentario;				// Comentarios
		private Int16	_Check;						// Determina con un 0 si es necesario hacer una revisión del ID del ciudadano por su nombre o con 1 en el caso contrario.
		private String	_CheckNombre;				// Nombre a validar cuando se especifica la opción Check igual a uno
		private String	_Detalle;					// Detalle
		private String	_FechaDesde;				// Fecha de inicio en una consulta
		private String	_FechaHasta;				// Fecha final en una consulta
		private Int16	_MedidaPreventiva;			// Determina si un asunto es una medida preventiva
		private Int16	_Nivel;						// Nivel de transacción
		private String	_Nombre;					// Nombre del ciudadano/problematica/entidad
		private String	_Numero;					// Número del expediente
		private Int16	_Presente;					// Determina con un 1 si el ciudadano estuvo presente al momento del levantamientio del registro
		private String	_Puesto;					// Puesto de una autoridad señalada
		private DataTable _tblVoz;					// Listado de ID's de Voces, calificación y comentarios


		 //Constructor

		public ENTVisitaduria()
		{
			_AreaId = 0;
			_AutoridadId = 0;
			_CalificacionAutoridadId = 0;
			_CalificacionVozId = 0;
			_CiudadanoId = 0;
			_ComentarioId = 0;
			_EstatusId = 0;
			_ExpedienteId = 0;
			_FuncionarioId = 0;
			_ModuloId = 0;
			_TipoParticipacionId = 0;
			_TipoResolucionId = 0;
			_UsuarioId = 0;
			_VozId = 0;
			_Acuerdo = "";
			_Comentario = "";
			_Check = 0;
			_CheckNombre = "";
			_Detalle = "";
			_FechaDesde = "";
			_FechaHasta = "";
			_MedidaPreventiva = 0;
			_Nivel = -1;
			_Nombre = "";
			_Numero = "";
			_Presente = 0;
			_Puesto = "";
			_tblVoz = null;
		}


		// Propiedades

		///<remarks>
		///   <name>ENTVisitaduria.AreaId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Área</summary>
		public Int32 AreaId
		{
			get { return _AreaId; }
			set { _AreaId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.AutoridadId</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Autoridad</summary>
		public Int32 AutoridadId
		{
			get { return _AutoridadId; }
			set { _AutoridadId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.CalificacionAutoridadId</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Calificación de la Autoridad</summary>
		public Int32 CalificacionAutoridadId
		{
			get { return _CalificacionAutoridadId; }
			set { _CalificacionAutoridadId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.CalificacionVozId</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Calificación de la Voz</summary>
		public Int32 CalificacionVozId
		{
			get { return _CalificacionVozId; }
			set { _CalificacionVozId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.CiudadanoId</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Ciudadano asociado al Expediente</summary>
		public Int32 CiudadanoId
		{
			get { return _CiudadanoId; }
			set { _CiudadanoId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.ComentarioId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Comentario del Expediente</summary>
		public Int32 ComentarioId
		{
			get { return _ComentarioId; }
			set { _ComentarioId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.EstatusId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Estatus del Expediente</summary>
		public Int32 EstatusId
		{
			get { return _EstatusId; }
			set { _EstatusId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.ExpedienteId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Expediente a consultar</summary>
		public Int32 ExpedienteId
		{
			get { return _ExpedienteId; }
			set { _ExpedienteId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.FuncionarioId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del funcionario asociado al expediente</summary>
		public Int32 FuncionarioId
		{
			get { return _FuncionarioId; }
			set { _FuncionarioId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.ModuloId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Módulo en donde se realiza la transacción</summary>
		public Int32 ModuloId
		{
			get { return _ModuloId; }
			set { _ModuloId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.TipoParticipacionId</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del tipo de participación de un ciudadano asociado a un Expediente</summary>
		public Int32 TipoParticipacionId
		{
			get { return _TipoParticipacionId; }
			set { _TipoParticipacionId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.TipoResolucionId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Tipo de Resolución</summary>
		public Int32 TipoResolucionId
		{
			get { return _TipoResolucionId; }
			set { _TipoResolucionId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.UsuarioId</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Usuario</summary>
		public Int32 UsuarioId
		{
			get { return _UsuarioId; }
			set { _UsuarioId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.VozId</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Voz señalatoria de una Autoridad</summary>
		public Int32 VozId
		{
			get { return _VozId; }
			set { _VozId = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Acuerdo</name>
		///   <create>18-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el acuerdo de calificación definitiva</summary>
		public String Acuerdo
		{
			get { return _Acuerdo; }
			set { _Acuerdo = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Comentario</name>
		///   <create>18-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna los comentarios de un Expediente </summary>
		public String Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Check</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina con un 0 si es necesario hacer una revisión del ID del ciudadano por su nombre o con 1 en el caso contrario</summary>
		public Int16 Check
		{
			get { return _Check; }
			set { _Check = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.CheckNombre</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre a validar cuando se especifica la opción Check igual a uno</summary>
		public String CheckNombre
		{
			get { return _CheckNombre; }
			set { _CheckNombre = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Detalle</name>
		///   <create>18-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el detalle de una resolución</summary>
		public String Detalle
		{
			get { return _Detalle; }
			set { _Detalle = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.FechaDesde</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de inicio en una consulta</summary>
		public String FechaDesde
		{
			get { return _FechaDesde; }
			set { _FechaDesde = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.FechaHasta</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha final en una consulta</summary>
		public String FechaHasta
		{
			get { return _FechaHasta; }
			set { _FechaHasta = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.MedidaPreventiva</name>
		///   <create>18-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si un asunto es una medida preventiva</summary>
		public Int16 MedidaPreventiva
		{
			get { return _MedidaPreventiva; }
			set { _MedidaPreventiva = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Nivel</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nivel de la transacción</summary>
		public Int16 Nivel
		{
			get { return _Nivel; }
			set { _Nivel = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Nombre</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del ciudadano/problematica/entidad</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Numero</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número del expediente</summary>
		public String Numero
		{
			get { return _Numero; }
			set { _Numero = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Presente</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor el cual determina con un 1 si el ciudadano estuvo presente al momento del registro</summary>
		public Int16 Presente
		{
			get { return _Presente; }
			set { _Presente = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.Puesto</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el Puesto de una autoridad señalada</summary>
		public String Puesto
		{
			get { return _Puesto; }
			set { _Puesto = value; }
		}

		///<remarks>
		///   <name>ENTVisitaduria.tblVoz</name>
		///   <create>28-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un datatable que contiene el listado de ID's de Voces, calificación y comentarios</summary>
		public DataTable tblVoz
		{
			get { return _tblVoz; }
			set { _tblVoz = value; }
		}

	}
}
