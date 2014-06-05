using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTDocumento : ENTBase
    {
        private string _RepositorioId;
        private string _ModuloId;
        private int _SolicitudId;
        private int _ExpedienteId;
        private int _RecomendacionId;
        private string _TipoDocumentoId;
        private string _FormatoDocumentoId;
        private int _idUsuarioInsert;
        private int _idUsuarioLastUpdate;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Documento;
        private FileUpload _FileUpload;
        private DataSet _ResultData;

        public ENTDocumento()
        {
            _RepositorioId = string.Empty;
            _SolicitudId = 0;
            _ExpedienteId = 0;
            _RecomendacionId = 0;
            _TipoDocumentoId = string.Empty;
            _FormatoDocumentoId = string.Empty;
            _idUsuarioInsert = 0;
            _idUsuarioLastUpdate = 0;
            _Nombre = string.Empty;
            _Descripcion = string.Empty;
            _Documento = new byte[] { 0 };
            _FileUpload = null;
            _ResultData = null;
        }

        /// <summary>
        ///     Identificador del documento.
        /// </summary>
        public string RepositorioId
        {
            get { return _RepositorioId; }
            set { _RepositorioId = value; }
        }

        /// <summary>
        ///     Módulo desde el que se guardó el documento.
        /// </summary>
        public string ModuloId
        {
            get { return _ModuloId; }
            set { _ModuloId = value; }
        }

        /// <summary>
        ///     Identificador de la solicitud.
        /// </summary>
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
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
        ///     Identificador de la recomendación.
        /// </summary>
        public int RecomendacionId
        {
            get { return _RecomendacionId; }
            set { _RecomendacionId = value; }
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
        ///     Identificador del formato del documento.
        /// </summary>
        public string FormatoDocumentoId
        {
            get { return _FormatoDocumentoId; }
            set { _FormatoDocumentoId = value; }
        }

        /// <summary>
        ///     Identificador del usuario que creó el registro.
        /// </summary>
        public int idUsuarioInsert
        {
            get { return _idUsuarioInsert; }
            set { _idUsuarioInsert = value; }
        }

        /// <summary>
        ///     Identificador del último usuario que modificó el registro.
        /// </summary>
        public int idUsuarioLastUpdate
        {
            get { return _idUsuarioLastUpdate; }
            set { _idUsuarioLastUpdate = value; }
        }

        /// <summary>
        ///     Nombre del documento.
        /// </summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        /// <summary>
        ///     Descripción del documento.
        /// </summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        ///     Documento en formato de bytes.
        /// </summary>
        public byte[] Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }

        /// <summary>
        ///     Control para subir archivos al servidor Web.
        /// </summary>
        public FileUpload FileUpload
        {
            get { return _FileUpload; }
            set { _FileUpload = value; }
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
