using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTLugarComparecencia : ENTBase
    {
        private int _LugarComparecenciaId;
        private string _Nombre;
        private string _Descripcion;
        private DataSet _ResultData;

        public ENTLugarComparecencia()
        {
            _LugarComparecenciaId = 0;
            _Nombre = string.Empty;
            _Descripcion = string.Empty;
            _ResultData = null;
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
        ///     Nombre del lugar de la comparecencia.
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        ///     Descripción breve de la comparecencia.
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
