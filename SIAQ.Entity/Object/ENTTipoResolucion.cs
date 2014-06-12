using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTTipoResolucion : ENTBase
    {
        private int _TipoResolucionId;
        private string _Nombre;
        private string _Descripcion;
        private DataSet _ResultData;

        public ENTTipoResolucion()
        {
            _TipoResolucionId = 0;
            _Nombre = string.Empty;
            _Descripcion = string.Empty;
            _ResultData = null;
        }

        /// <summary>
        ///     Identificador del tipo de Resolucion.
        /// </summary>
        public int TipoResolucionId
        {
            get { return _TipoResolucionId; }
            set { _TipoResolucionId = value; }
        }

        /// <summary>
        ///     Nombre del tipo de Resolucion.
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        ///     Descripción breve del tipo de Resolucion.
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
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
