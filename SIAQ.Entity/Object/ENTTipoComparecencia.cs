using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTTipoComparecencia : ENTBase
    {
        private int _TipoComparecenciaId;
        private string _Nombre;
        private string _Descripcion;
        private DataSet _ResultData;

        public ENTTipoComparecencia()
        {
            _TipoComparecenciaId = 0;
            _Nombre = string.Empty;
            _Descripcion = string.Empty;
            _ResultData = null;
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
        ///     Nombre del tipo de comparecencia.
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        ///     Descripción breve del tipo de comparecencia.
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
