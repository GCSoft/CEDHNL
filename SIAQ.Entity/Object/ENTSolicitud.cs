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
        private int _TipoSolicitudId; // Valor de TipoSolicitudId
        private int _LugarHechosId; // Valor de LugarHechosId
        private int _EstatusId; // Valor de EstatusId
        private int _Numero; // Valor de Numero
        private Int32 _MedioComunicacion;
        private Int32 _FuncionarioId;
        private string _Fecha; // Valor de Fecha
        private string _Nombre;
        private DataSet _ResultData; //Otras propiedades
        


        public ENTSolicitud()
        {
            
            _SolicitudId = 0;
            _FuncionarioId = 0;
            _CalificacionId = 0;
            _TipoSolicitudId = 0;
            _LugarHechosId = 0;
            _EstatusId = 0;
            _Numero = 0;
            _MedioComunicacion = 0; 
            _Fecha = "";
            _Nombre = "";
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

        public Int32 MedioComunicacion
        {
            get { return _MedioComunicacion; }
            set { _MedioComunicacion = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public Int32 FuncinarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }

        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }
    }
}
