using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTSolicitud : ENTBase
    {
        private int _SolicitudId;       // Valor de SolicitudId
        private int _FuncionarioId;     // Valor de FuncionarioId
        private int _CalificacionId;    // Valor de CalificacionId
        private int _TipoSolicitudId;   // Valor de TipoSolicitudId
        private int _LugarHechosId;     // Valor de LugarHechosId
        private int _EstatusId;         // Valor de EstatusId
        private int _Numero;            // Valor de Numero
        private string _Fecha;          // Valor de Fecha
        private string _NombreTemporal; // Nombtre temporal de ciudadano
        private string _Observaciones;  // Observaciones del recepcionista


        public ENTSolicitud()
        {
            _SolicitudId = 0;
            _FuncionarioId = 0;
            _CalificacionId = 0;
            _TipoSolicitudId = 0;
            _LugarHechosId = 0;
            _EstatusId = 0;
            _Numero = 0;
            _Fecha = "";
            _NombreTemporal = "";
            _Observaciones = "";
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
        ///<remarks>
        ///   <name>Solicitud.FuncionarioId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FuncionarioId</summary>
        public int FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
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
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
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

        ///<remarks>
        ///   <name>Solicitud.NombreTemporal</name>
        ///   <create>o5/Feb/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NombreTemporal</summary>
        public string NombreTemporal {
            get { return _NombreTemporal; }
            set { _NombreTemporal = value; }
        }

        ///<remarks>
        ///   <name>Solicitud.Observaciones</name>
        ///   <create>o5/Feb/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Observaciones</summary>
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

    }
}
