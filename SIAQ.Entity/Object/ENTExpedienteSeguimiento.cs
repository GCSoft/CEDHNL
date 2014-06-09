using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTExpedienteSeguimiento : ENTBase
    {
        private int _ExpedienteSeguimientoId;
        private int _ExpedienteId;
        private int _FuncionarioId;
        private int _TipoSeguimientoId;
        private string _Fecha;
        private string _Detalle;
        private DataSet _ResultData;

        public ENTExpedienteSeguimiento()
        {
            _ExpedienteSeguimientoId = 0;
            _ExpedienteId = 0;
            _FuncionarioId = 0;
            _TipoSeguimientoId = 0;
            _Fecha = string.Empty;
            _Detalle = string.Empty;
            _ResultData = null;
        }

        /// <summary>
        ///     Identificador del seguimiento del expediente.
        /// </summary>
        public int ExpedienteSeguimientoId
        {
            get { return _ExpedienteSeguimientoId; }
            set { _ExpedienteSeguimientoId = value; }
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
        ///     Identificador del tipo de seguimiento.
        /// </summary>
        public int TipoSeguimientoId
        {
            get { return _TipoSeguimientoId; }
            set { _TipoSeguimientoId = value; }
        }

        /// <summary>
        ///     Fecha en que se dio el seguimiento.
        /// </summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
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
        ///     DataSet con el resultado de una búsqueda.
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }
    }
}
