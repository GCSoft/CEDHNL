using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTRecomendacion : ENTBase
    {
        #region Atributos

        private int _RecomendacionId;
        private int _ExpedienteId;
        private int _CalificacionId;
        private int _TipoSolicitudId;
        private int _LugarHechosId;
        private int _TipoRecomendacionId;
        private int _EstatusId;
        private int _Numero;
        private DateTime _Fecha;
        private string _Observaciones;
        private Int16 _Anio;
        private DataSet _ResultData;

        #endregion

        #region Propiedades

        ///<remarks>
        ///   <name>Recomendacion.RecomendacionId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna RecomendacionId
        /// </summary>
        public int RecomendacionId
        {
            get { return _RecomendacionId; }
            set { _RecomendacionId = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.ExpedienteId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna ExpedienteId
        /// </summary>
        public int ExpedienteId
        {
            get { return _ExpedienteId; }
            set { _ExpedienteId = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.CalificacionId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna CalificacionId
        /// </summary>
        public int CalificacionId
        {
            get { return _CalificacionId; }
            set { _CalificacionId = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.TipoSolicitudId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna TipoSolicitudId
        /// </summary>
        public int TipoSolicitudId
        {
            get { return _TipoSolicitudId; }
            set { _TipoSolicitudId = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.LugarHechosId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna LugarHechosId
        /// </summary>
        public int LugarHechosId
        {
            get { return _LugarHechosId; }
            set { _LugarHechosId = value; }
        }

        /// <summary>
        ///     Identificador del tipo de recomendación.
        /// </summary>
        public int TipoRecomendacionId
        {
            get { return _TipoRecomendacionId; }
            set { _TipoRecomendacionId = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.EstatusId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna EstatusId
        /// </summary>
        public int EstatusId
        {
            get { return _EstatusId; }
            set { _EstatusId = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.Numero</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna Numero
        /// </summary>
        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.Fecha</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna Fecha
        /// </summary>
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.Observaciones</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna Observaciones
        /// </summary>
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        /// <summary>
        ///     Número de año para calcular el siguiente número de folio.
        /// </summary>
        public Int16 Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        ///<remarks>
        ///   <name>Recomendacion.ResultData</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna ResultData
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }

        #endregion

        #region Funciones


        public ENTRecomendacion()
        {
            _RecomendacionId = 0;
            _ExpedienteId = 0;
            _CalificacionId = 0;
            _TipoSolicitudId = 0;
            _LugarHechosId = 0;
            _TipoRecomendacionId = 0;
            _EstatusId = 0;
            _Numero = 0;
            _Fecha = DateTime.Now;
            _Observaciones = "";
            _Anio = 0;
            _ResultData = new DataSet();
        }
        
        #endregion
    }
}
