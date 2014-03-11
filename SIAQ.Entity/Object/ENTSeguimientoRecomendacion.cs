using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTSeguimientoRecomendacion : ENTBase
    {

        #region Atributos

        private int _RecomendacionId;
        private int _FuncionarioId;
        private int _EsVigente;
        private DateTime _Fecha;
        private DataSet _ResultData;

        #endregion

        #region Propiedades

        ///<remarks>
        ///   <name>SeguimientoRecomendacion.RecomendacionId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtener/Asignar RecomendacionId
        /// </summary>
        public int RecomendacionId
        {
            get { return _RecomendacionId; }
            set { _RecomendacionId = value; }
        }

        ///<remarks>
        ///   <name>SeguimientoRecomendacion.FuncionarioId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtener/Asignar FuncionarioId
        /// </summary>
        public int FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }

        ///<remarks>
        ///   <name>SeguimientoRecomendacion.EsVigente</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtener/Asignar EsVigente
        /// </summary>
        public int EsVigente
        {
            get { return _EsVigente; }
            set { _EsVigente = value; }
        }

        ///<remarks>
        ///   <name>SeguimientoRecomendacion.Fecha</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtener/Asignar Fecha
        /// </summary>
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        ///<remarks>
        ///   <name>SeguimientoRecomendacion.ResultData</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtener/Asignar ResultData
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }

        #endregion

        #region Funciones

        public ENTSeguimientoRecomendacion()
        {
            _RecomendacionId = 0;
            _FuncionarioId = 0;
            _EsVigente = 0;
            _Fecha = DateTime.Now;
            _ResultData = new DataSet();
        }

        #endregion

    }
}
