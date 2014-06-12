using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTExpedienteResolucion : ENTBase
    {
        private int _ExpedienteResolucionId;
        private int _ExpedienteId;
        private int _FuncionarioId;
        private int _TipoResolucionId;
        private string _Detalle;
        private DataSet _ResultData;

        public ENTExpedienteResolucion()
        {
            _ExpedienteResolucionId = 0;
            _ExpedienteId = 0;
            _FuncionarioId = 0;
            _TipoResolucionId = 0;
            _Detalle = string.Empty;
            _ResultData = null;
        }

        /// <summary>
        ///     Identificador de la resolución del expediente.
        /// </summary>
        public int ExpedienteResolucionId
        {
            get { return _ExpedienteResolucionId; }
            set { _ExpedienteResolucionId = value; }
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
        ///     Identificador del tipo de resolución.
        /// </summary>
        public int TipoResolucionId
        {
            get { return _TipoResolucionId; }
            set { _TipoResolucionId = value; }
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
