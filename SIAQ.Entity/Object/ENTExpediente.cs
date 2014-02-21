using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTExpediente : ENTBase
    {

        private Int32 _ExpedienteId;                        // Identificacor unico del expediente
        private Int32 _SolicitudId;                         // Identificacor unico de la solicitud
        private Int32 _CalificacionId;                      // Identificacor unico de la Calificación
        private Int32 _TipoSolicitudId;                     // Identificacor unico del tipo de solicitud
        private Int32 _LugarHechosId;                       // Identificacor unico de LugarHechos
        private Int32 _EstatusId;                           // Identificacor unico de Esttus
        private string _Numero;                             // Numero de expediente
        private string _Fecha;                              // Fecha de creacion de expediente
        private string _Observaciones;                      // Observaciones de expediente

        private string _Ciudadano;                          // Nombre del ciudadano
        private Int32 _FuncionarioId;                       // Identificacor unico de FuncionarioId
        private Int32 _MedioComunicacionId;                 // Identificador unico MedioComunicacionId

        public ENTExpediente()
        {
            _ExpedienteId = 0;
            _SolicitudId = 0;
            _CalificacionId = 0;
            _TipoSolicitudId = 0;
            _LugarHechosId = 0;
            _EstatusId = 0;
            _Numero = "";
            _Fecha = "";
            _Observaciones = "";

            _Ciudadano = "";
            _FuncionarioId = 0;
            _MedioComunicacionId = 0;

        }


        ///<remarks>
        ///   <name>ENTExpediente.ExpedienteId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ExpedienteId</summary>
        public Int32 ExpedienteId
        {
            get { return _ExpedienteId; }
            set { _ExpedienteId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.SolicitudId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SolicitudId</summary>
        public Int32 SolicitudId
        {
            get { return _SolicitudId; }
            set{ _SolicitudId = value;}
        }

        ///<remarks>
        ///   <name>ENTExpediente.CalificacionId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CalificacionId</summary>
        public Int32 CalificacionId
        {
            get { return _CalificacionId; }
            set { _CalificacionId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.TipoSolicitudId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoSolicitudId</summary>
        public Int32 TipoSolicitudId
        {
            get { return _TipoSolicitudId; }
            set { _TipoSolicitudId = value;}
        }

        ///<remarks>
        ///   <name>ENTExpediente.LugarHechosId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna LugarHechosId</summary>
        public Int32 LugarHechosId {
            get { return _LugarHechosId; }
            set { _LugarHechosId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.EstatusId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstatusId</summary>
        public Int32 EstatusId
        {
            get { return _EstatusId; }
            set { _EstatusId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.Numero</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Numero</summary>
        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.Fecha</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Fecha</summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.Observaciones</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Observaciones</summary>
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.Ciudadano</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Ciudadano</summary>
        public string Ciudadano
        {
            get { return _Ciudadano; }
            set { _Ciudadano = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.FuncionarioId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FuncionarioId</summary>
        public Int32 FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.MedioComunicacionId</name>
        ///   <create>19/Febrero/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FuncionarioId</summary>
        public Int32 MedioComunicacionId
        {
            get { return _MedioComunicacionId; }
            set { _MedioComunicacionId = value; }
        }

    }
}
