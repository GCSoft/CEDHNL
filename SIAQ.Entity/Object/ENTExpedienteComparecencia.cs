using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTExpedienteComparecencia : ENTBase
    {
        private int _ExpedienteComparecenciaId;
        private int _ExpedienteId;
        private int _FuncionarioId;
        private int _CiudadanoId;
        private int _LugarComparecenciaId;
        private int _TipoComparecenciaId;
        private string _Asunto;
        private string _Detalle;
        private string _Fecha;
        private DataSet _ResultData;

        public ENTExpedienteComparecencia()
        {
            _ExpedienteComparecenciaId = 0;
            _ExpedienteId = 0;
            _FuncionarioId = 0;
            _CiudadanoId = 0;
            _LugarComparecenciaId = 0;
            _TipoComparecenciaId = 0;
            _Asunto = string.Empty;
            _Detalle = string.Empty;
            _Fecha = string.Empty;
            _ResultData = null;
        }

        /// <summary>
        ///     Identificador de la comparecencia del expediente.
        /// </summary>
        public int ExpedienteComparecenciaId
        {
            get { return _ExpedienteComparecenciaId; }
            set { _ExpedienteComparecenciaId = value; }
        }

        /// <summary>
        ///     Identificador del expediente.
        /// </summary>
        public int ExpedienteId
        {
            get { return _ExpedienteId; }
            set { _ExpedienteId = value; }
        }

        /// <summary>
        ///     Identificador del funcionario.
        /// </summary>
        public int FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }

        /// <summary>
        ///     Identificador del ciudadano.
        /// </summary>
        public int CiudadanoId
        {
            get { return _CiudadanoId; }
            set { _CiudadanoId = value; }
        }

        /// <summary>
        ///     Identificador del lugar de la comparecencia.
        /// </summary>
        public int LugarComparecenciaId
        {
            get { return _LugarComparecenciaId; }
            set { _LugarComparecenciaId = value; }
        }

        /// <summary>
        ///     Identificador del tipo de comparecencia.
        /// </summary>
        public int TipoComparecenciaId
        {
            get { return _TipoComparecenciaId; }
            set { _TipoComparecenciaId = value; }
        }

        /// <summary>
        ///     Asunto de la comparecencia.
        /// </summary>
        public string Asunto
        {
            get { return _Asunto; }
            set { _Asunto = value; }
        }

        /// <summary>
        ///     Detalle del seguimiento.
        /// </summary>
        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }

        /// <summary>
        ///     Fecha de la comparecencia.
        /// </summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        /// <summary>
        ///     DataSet con el resultado de una búsqueda.
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }
    }
}
