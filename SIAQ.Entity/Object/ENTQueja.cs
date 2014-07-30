/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTQueja
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using System.Data;

namespace SIAQ.Entity.Object
{
	public class ENTQueja
	{

		// Definiciones
		private Int32		_AreaId;				// Identificador único del Área a la que se generará el Expediente
		private Int32		_CalificacionId;		// Identificador único de la Calificación de la Solicitud
		private Int32		_CiudadanoId;			// Identificador único del Ciudadano asociado a la solicitud
		private Int32		_EstatusId;				// Identificador único del Estatus de la Solicitud
		private Int32		_FormaContactoId;		// Identificador único de la forma de contacto
		private Int32		_FuncionarioId;			// Identificador único del funcionario asociado a la solicitud
		private Int32		_LugarHechosId;			// Identificador único del lugar de los hechos asociado a la solicitud
		private Int32		_SolicitudId;			// Identificador único de la solicitud a consultar
		private Int32		_TipoOrientacionId;		// Identificador único del tipo de orientación de una solicitud
		private Int32		_TipoParticipacionId;	// Identificador único del tipo de participación de un ciudadano asociado a una solicitud
		private Int32		_UsuarioId;				// Identificador único de Usuario
		private String		_Comentario;			// Comentarios
		private Int16		_Check;					// Determina con un 0 si es necesario hacer una revisión del ID del ciudadano por su nombre o con 1 en el caso contrario.
		private String		_CheckNombre;			// Nombre a validar cuando se especifica la opción Check igual a uno
		private String		_DireccionHechos;		// Dirección de los hechos en una solicitud
		private String		_FechaDesde;			// Fecha de inicio en una consulta
		private String		_FechaHasta;			// Fecha final en una consulta
		private String		_Fundamento;			// Fundameto de una calificación
		private Int16		_MedidaPreventiva;		// determina si un asunto es una medida preventiva
		private Int16		_Nivel;					// Nivel de transacción
		private String		_Nombre;				// Nombre del ciudadano
		private String		_Numero;				// Número de la solicitud
		private String		_NumeroFolio;			// Número de folio de expediente generado al aprobar la solicitud
		private String		_Observaciones;			// Observaciones de la solicitud
		private Int16		_Presente;				// Determina con un 1 si el ciudadano estuvo presente al momento del levantamientio de la solicitud
		private Int16		_TipoFolio;				// Tipo de Folio a generar: 1-> [Folio de Queja], 2-> [Folio de Orientacion], 3-> [Folio de Gestion de Quejas], 4-> [Folio de Gestion Penitenciaria]
		private DataTable	_tblCanalizacion;		// DataTable el cual contiene los ID's Canalizaciones que se asociarán a la Solicitud
		private DataTable	_tblIndicador;			// DataTable el cual contiene los ID's de los grupos minoritarios asociadas a la solicitud


		 //Constructor

        public ENTQueja(){
			_AreaId = 0;
			_CalificacionId = 0;
			_CiudadanoId = 0;
			_EstatusId = 0;
			_FormaContactoId = 0;
			_FuncionarioId = 0;
			_LugarHechosId = 0;
			_SolicitudId = 0;
			_TipoOrientacionId = 0;
			_TipoParticipacionId = 0;
			_UsuarioId = 0;
			_Comentario = "";
			_Check = 0;
			_CheckNombre = "";
			_DireccionHechos = "";
			_FechaDesde = "";
			_FechaHasta = "";
			_Fundamento = "";
			_MedidaPreventiva = 0;
			_Nivel = -1;
			_Nombre = "";
			_Numero = "";
			_NumeroFolio = "";
			_Observaciones = "";
			_Presente = 0;
			_TipoFolio = 0;
			_tblCanalizacion = null;
			_tblIndicador = null;
        }


		// Propiedades

		///<remarks>
		///   <name>ENTQueja.AreaId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del área al que se generará el expediente</summary>
		public Int32 AreaId
		{
			get { return _AreaId; }
			set { _AreaId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.CalificacionId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la Calificación de la Solicitud</summary>
		public Int32 CalificacionId
		{
			get { return _CalificacionId; }
			set { _CalificacionId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.CiudadanoId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Ciudadano asociado a la solicitud</summary>
		public Int32 CiudadanoId
		{
			get { return _CiudadanoId; }
			set { _CiudadanoId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.EstatusId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Estatus de la Solicitud</summary>
		public Int32 EstatusId
		{
			get { return _EstatusId; }
			set { _EstatusId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FormaContactoId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la forma de contacto</summary>
		public Int32 FormaContactoId
		{
			get { return _FormaContactoId; }
			set { _FormaContactoId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FuncionarioId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del funcionario asociado a la solicitud</summary>
		public Int32 FuncionarioId
		{
			get { return _FuncionarioId; }
			set { _FuncionarioId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.LugarHechosId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del lugar de los hechos asociado a la solicitud</summary>
		public Int32 LugarHechosId
		{
			get { return _LugarHechosId; }
			set { _LugarHechosId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.SolicitudId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la solicitud a consultar</summary>
		public Int32 SolicitudId
		{
			get { return _SolicitudId; }
			set { _SolicitudId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.TipoOrientacionId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del tipo de orientación de una solicitud</summary>
		public Int32 TipoOrientacionId
		{
			get { return _TipoOrientacionId; }
			set { _TipoOrientacionId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.TipoParticipacionId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del tipo de participación de un ciudadano asociado a una solicitud</summary>
		public Int32 TipoParticipacionId
		{
			get { return _TipoParticipacionId; }
			set { _TipoParticipacionId = value; }
		}

        ///<remarks>
		///   <name>ENTQueja.UsuarioId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único de Usuario</summary>
        public Int32 UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

		///<remarks>
		///   <name>ENTQueja.Comentario</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna los comentarios de una queja </summary>
		public String Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Check</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina con un 0 si es necesario hacer una revisión del ID del ciudadano por su nombre o con 1 en el caso contrario</summary>
		public Int16 Check
		{
			get { return _Check; }
			set { _Check = value; }
		}

		///<remarks>
		///   <name>ENTQueja.CheckNombre</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre a validar cuando se especifica la opción Check igual a uno</summary>
		public String CheckNombre
		{
			get { return _CheckNombre; }
			set { _CheckNombre = value; }
		}

		///<remarks>
		///   <name>ENTQueja.DireccionHechos</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la dirección de los hecho sde una solicitud</summary>
		public String DireccionHechos
		{
			get { return _DireccionHechos; }
			set { _DireccionHechos = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FechaDesde</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de inicio en una consulta</summary>
		public String FechaDesde
		{
			get { return _FechaDesde; }
			set { _FechaDesde = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FechaHasta</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha final en una consulta</summary>
		public String FechaHasta
		{
			get { return _FechaHasta; }
			set { _FechaHasta = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Fundamento</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el fundameto de una calificación</summary>
		public String Fundamento
		{
			get { return _Fundamento; }
			set { _Fundamento = value; }
		}

		///<remarks>
		///   <name>ENTQueja.MedidaPreventiva</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor que determina si un asunto es una medida preventiva</summary>
		public Int16 MedidaPreventiva
		{
			get { return _MedidaPreventiva; }
			set { _MedidaPreventiva = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Nivel</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nivel de la transacción</summary>
		public Int16 Nivel
		{
			get { return _Nivel; }
			set { _Nivel = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Nombre</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del ciudadano</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Numero</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de la solicitud</summary>
		public String Numero
		{
			get { return _Numero; }
			set { _Numero = value; }
		}

		///<remarks>
		///   <name>ENTQueja.NumeroFolio</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de folio de expediente generado al aprobar la solicitud</summary>
		public String NumeroFolio
		{
			get { return _NumeroFolio; }
			set { _NumeroFolio = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Observaciones</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna las observaciones de una solicitud</summary>
		public String Observaciones
		{
			get { return _Observaciones; }
			set { _Observaciones = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Presente</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un valor el cual determina con un 1 si el ciudadano estuvo presente al momento del levantamientio de la solicitud</summary>
		public Int16 Presente
		{
			get { return _Presente; }
			set { _Presente = value; }
		}

		///<remarks>
		///   <name>ENTQueja.TipoFolio</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el tipo de Folio a generar: 1-> [Folio de Queja], 2-> [Folio de Orientacion], 3-> [Folio de Gestión de Quejas], 4-> [Folio de Gestión Penitenciaria]</summary>
		public Int16 TipoFolio
		{
			get { return _TipoFolio; }
			set { _TipoFolio = value; }
		}

		///<remarks>
		///   <name>ENTQueja.tblCanalizacion</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un DataTable el cual contiene los ID's Canalizaciones que se asociarán a la Solicitud</summary>
		public DataTable tblCanalizacion
		{
			get { return _tblCanalizacion; }
			set { _tblCanalizacion = value; }
		}

		///<remarks>
		///   <name>ENTQueja.tblIndicador</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna un DataTable el cual contiene los ID's de los grupos minoritarios asociadas a la solicitud</summary>
		public DataTable tblIndicador
		{
			get { return _tblIndicador; }
			set { _tblIndicador = value; }
		}

	}
}
