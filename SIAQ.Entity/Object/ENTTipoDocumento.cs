using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTTipoDocumento : ENTBase
    {
        private string _TipoDocumentoId;
        private string _Nombre;
        private string _Descripcion;
        private DataSet _ResultData;

        public ENTTipoDocumento()
        {
            _TipoDocumentoId = string.Empty;
            _Nombre = string.Empty;
            _Descripcion = string.Empty;
            _ResultData = null;
        }

        /// <summary>
        ///     Identificador del tipo de documento.
        /// </summary>
        public string TipoDocumentoId
        {
            get { return _TipoDocumentoId; }
            set { _TipoDocumentoId = value; }
        }

        /// <summary>
        ///     Nombre del tipo de documento.
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        ///     Descripción del tipo de documento.
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
