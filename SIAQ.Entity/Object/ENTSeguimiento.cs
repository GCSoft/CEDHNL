﻿/*---------------------------------------------------------------------------------------------------------------------------------
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
		private Int32	_ComentarioId;				// Identificador único del comentario
		private Int32	_EstatusId;					// Identificador único del Estatus de la recomendación
		private Int32	_EstatusPuntoResolutivoId;	// Identificador único del Estatus de punto resolutivo
		private Int32	_ExpedienteId;				// Identificador único del Expediente a consultar
		private Int32	_FuncionarioId;				// Identificador único del funcionario asociada la recomendación
		private Int32	_ModuloId;					// Identificador único del Módulo en donde se realiza la transacción
		private Int32	_RecomendacionId;			// Identificador único de la recomendación
		private Int32	_RecomendacionDetalleId;	// Identificador único del detalle de la recomendación (punto resolutivo)
		private Int32	_UsuarioId;					// Identificador único del Usuario
		private Int16	_Aceptada;					// Determina si una autoridad aceptó la recomendación/Acuerdo de no responsabilidad
		private Int16	_AcuerdoNoResponsabilidad;	// Determina con un 0 si es Recomendación, un 1 si es acuerdo o un 2 para ambos casos
		private Int16	_MedidaPreventiva;			// Determina con un 1 si es una Medida Preventina o un 0 si es un Asunto
		private Int16	_Nivel;						// Nivel de transacción
		private String	_Nombre;					// Nombre
		private String	_Comentario;				// Comentario en un Asunto o Medida Preventiva
		private String	_ExpedienteNumero;			// Número de expediente a consultar
		private String	_Fecha;						// Fecha de la transacción
		private String	_FechaDesde;				// Fecha inicial de la consulta
		private String	_FechaHasta;				// Fecha final de la consulta
		private Int16	_Impugnada;					// Determina si fue impugnado el proceso de una autoridad
		private String	_NombreAutoridad;			// Nombre de la autoridad a filtrar
		private String	_NumeroRecomendacion;		//
		private Int16	_Publicada;					// Determina si fue publicado el proceso de una autoridad
		private String	_PuestoAutoridad;			// Puesto de la autoridad a filtrar
		private String	_RecomendacionNumero;		// Número de recomendación a consultar
		private Int16	_Visible;					// Determina si un elemento es visible


		 //Constructor

		public ENTSeguimiento()
		{
			_ComentarioId = 0;
			_EstatusId = 0;
			_EstatusPuntoResolutivoId = 0;
			_ExpedienteId = 0;
			_FuncionarioId = 0;
			_ModuloId = 0;
			_RecomendacionId = 0;
			_RecomendacionDetalleId = 0;
			_UsuarioId = 0;
			_Aceptada = 2;
			_AcuerdoNoResponsabilidad = 2;
			_MedidaPreventiva = -1;
			_Nivel = -1;
			_Nombre = "";
			_Comentario = "";
			_ExpedienteNumero = "";
			_Fecha = "";
			_FechaDesde = "";
			_FechaHasta = "";
			_Impugnada = 2;
			_NombreAutoridad = "";
			_NumeroRecomendacion = "";
			_Publicada = 2;
			_PuestoAutoridad = "";
			_RecomendacionNumero = "";
			_Visible = 0;
		}


		// Propiedades

		///<remarks>
		///   <name>ENTSeguimiento.ComentarioId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Comentario de la recomendación</summary>
		public Int32 ComentarioId
		{
			get { return _ComentarioId; }
			set { _ComentarioId = value; }
		}

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
		///   <name>ENTSeguimiento.EstatusPuntoResolutivoId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Estatus del punto resolutivo</summary>
		public Int32 EstatusPuntoResolutivoId
		{
			get { return _EstatusPuntoResolutivoId; }
			set { _EstatusPuntoResolutivoId = value; }
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
		///   <name>ENTSeguimiento.RecomendacionDetalleId</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del detalle de la Recomendación (punto resolutivo)</summary>
		public Int32 RecomendacionDetalleId
		{
			get { return _RecomendacionDetalleId; }
			set { _RecomendacionDetalleId = value; }
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
		///   <name>ENTSeguimiento.Aceptada</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si una autoridad aceptó la recomendación/Acuerdo de no responsabilidad</summary>
		public Int16 Aceptada
		{
			get { return _Aceptada; }
			set { _Aceptada = value; }
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
		///   <name>ENTSeguimiento.MedidaPreventiva</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna unvalor que determina con un 1 si es una Medida Preventina o un 0 si es un Asunto</summary>
		public Int16 MedidaPreventiva
		{
			get { return _MedidaPreventiva; }
			set { _MedidaPreventiva = value; }
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
		///   <name>ENTSeguimiento.Nombre</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un Nombre</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.Comentario</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un comentario en un Asunto o Medida Preventiva</summary>
		public String Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
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
		///   <name>ENTSeguimiento.Fecha</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de la transacción</summary>
		public String Fecha
		{
			get { return _Fecha; }
			set { _Fecha = value; }
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
		///   <name>ENTSeguimiento.Aceptada</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si fue impugnado el proceso de una autoridad</summary>
		public Int16 Impugnada
		{
			get { return _Impugnada; }
			set { _Impugnada = value; }
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
		///   <name>ENTSeguimiento.NumeroRecomendacion</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de la recomendación</summary>
		public String NumeroRecomendacion
		{
			get { return _NumeroRecomendacion; }
			set { _NumeroRecomendacion = value; }
		}

		///<remarks>
		///   <name>ENTSeguimiento.Publicada</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si fue publicada el proceso de una autoridad</summary>
		public Int16 Publicada
		{
			get { return _Publicada; }
			set { _Publicada = value; }
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

		///<remarks>
		///   <name>ENTSeguimiento.Visible</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si un elemento es visible</summary>
		public Int16 Visible
		{
			get { return _Visible; }
			set { _Visible = value; }
		}

	}
}
