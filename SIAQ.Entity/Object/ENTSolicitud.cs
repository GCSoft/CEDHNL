using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTSolicitud : ENTBase
    {
        private int _SolicitudId; // Valor de SolicitudId
        private int _CalificacionId; // Valor de CalificacionId
        private int _CanalizacionId;
        private int _TipoSolicitudId; // Valor de TipoSolicitudId
        private int _LugarHechosId; // Valor de LugarHechosId
        private int _EstatusId; // Valor de EstatusId
		private String _Numero; // Valor de Numero
        private int _MedioComunicacion;
        private int _FormaContactoId;
        private int _FuncionarioId;
        private string _Fecha; // Valor de Fecha
        private string _Nombre;
        private string _Fundamento;
        private DataSet _ResultData; //Otras propiedades
        private string _Observaciones;
        private string _DireccionHechos;
        private int _idUsuarioInsert;
        private int _idUsuarioLastUpdate;
        private int _CierreOrientacionId;
        private DateTime _FechaDesde;
        private DateTime _FechaHasta;


        private Int32	_CiudadanoId;		// Identificador unico del ciudadano
		private String	_NombreTemporal;	// Nombre Temporal

        public ENTSolicitud(){
            _SolicitudId = 0;
            _FuncionarioId = 0;
            _CalificacionId = 0;
            _TipoSolicitudId = 0;
            _LugarHechosId = 0;
            _EstatusId = 0;
            _Numero = "";
            _MedioComunicacion = 0;
            _Fecha = "";
            _Nombre = "";
            _Observaciones = "";
            _FormaContactoId = 0;
            _DireccionHechos = string.Empty;
            _idUsuarioInsert = 0;
            _idUsuarioLastUpdate = 0;
            _Fundamento = "";
            _CanalizacionId = 0;
            _CierreOrientacionId = 0;

			_CiudadanoId = 0;
			_NombreTemporal = "";

        }

        ///<remarks>
        ///   <name>Solicitud.SolicitudId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SolicitudId</summary>
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }

        public int CanalizacionId
        {
            get { return _CanalizacionId; }
            set { _CanalizacionId = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.CalificacionId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CalificacionId</summary>
        public int CalificacionId
        {
            get { return _CalificacionId; }
            set { _CalificacionId = value; }
        }

        public int CierreOrientacionId
        {
            get { return _CierreOrientacionId; }
            set { _CierreOrientacionId = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.TipoSolicitudId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoSolicitudId</summary>
        public int TipoSolicitudId
        {
            get { return _TipoSolicitudId; }
            set { _TipoSolicitudId = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.LugarHechosId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna LugarHechosId</summary>
        public int LugarHechosId
        {
            get { return _LugarHechosId; }
            set { _LugarHechosId = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.EstatusId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstatusId</summary>
        public int EstatusId
        {
            get { return _EstatusId; }
            set { _EstatusId = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.Numero</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Numero</summary>
        public String Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        /// <summary>
        ///     Identificador del usuario que creó el registro.
        /// </summary>
        public int idUsuarioInsert
        {
            get { return _idUsuarioInsert; }
            set { _idUsuarioInsert = value; }
        }

        /// <summary>
        ///     Identificador del último usuario que modificó el registro.
        /// </summary>
        public int idUsuarioLastUpdate
        {
            get { return _idUsuarioLastUpdate; }
            set { _idUsuarioLastUpdate = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.Fecha</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Fecha</summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Fundamento
        {
            get { return _Fundamento; }
            set { _Fundamento = value; }
        }

        public int MedioComunicacion
        {
            get { return _MedioComunicacion; }
            set { _MedioComunicacion = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }

        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public int FormaContactoId
        {
            get { return _FormaContactoId; }
            set { _FormaContactoId = value; }
        }

        /// <summary>
        ///     Dirección de los hechos.
        /// </summary>
        public string DireccionHechos
        {
            get { return _DireccionHechos; }
            set { _DireccionHechos = value; }
        }

        public DateTime FechaDesde
        {
            get { return _FechaDesde; }
            set { _FechaDesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return _FechaHasta; }
            set { _FechaHasta = value; }
        }


		///<remarks>
		///   <name>Solicitud.CiudadanoId</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Obtiene/Asigna el id del ciudadano</summary>
		public Int32 CiudadanoId
		{
			get { return _CiudadanoId; }
			set { _CiudadanoId = value; }
		}

		///<remarks>
		///   <name>Solicitud.NombreTemporal</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre temporal</summary>
		public String NombreTemporal
		{
			get { return _NombreTemporal; }
			set { _NombreTemporal = value; }
		}


    }
}
