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
        private int _SolicitudId;
        private int _ExpedienteId;
        private int _RecomendacionId;
        private int _TipoDocumentoId;
        private int _UsuarioIdInsert;
        private int _UsuarioIdLastUpdate;
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
            _TipoDocumentoId = 0;
            _UsuarioIdInsert = 0;
            _UsuarioIdLastUpdate = 0;
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
        public int TipoDocumentoId
        {
            get { return _TipoDocumentoId; }
            set { _TipoDocumentoId = value; }
        }

        /// <summary>
        ///     Identificador del usuario que creó el registro.
        /// </summary>
        public int UsuarioIdInsert
        {
            get { return _UsuarioIdInsert; }
            set { _UsuarioIdInsert = value; }
        }

        /// <summary>
        ///     Identificador del último usuario que modificó el registro.
        /// </summary>
        public int UsuarioIdLastUpdate
        {
            get { return _UsuarioIdLastUpdate; }
            set { _UsuarioIdLastUpdate = value; }
        }
    }
}
