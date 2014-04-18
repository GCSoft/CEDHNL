using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTSolicitudComentario : ENTSolicitud
    {
        private int _ComentarioId;
        private int _SolicitudId;
        private int _idUsuario;
        private string _Fecha;
        private string _Comentario;

        public ENTSolicitudComentario()
        {
            _ComentarioId = 0;
            _SolicitudId = 0;
            _idUsuario = 0;
            _Fecha = string.Empty;
            _Comentario = string.Empty;
        }

        /// <summary>
        ///     Identificador del comentario.
        /// </summary>
        public int ComentarioId
        {
            get { return _ComentarioId; }
            set { _ComentarioId = value; }
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
        ///     Identificador del usuario que publicó el comentario.
        /// </summary>
        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        /// <summary>
        ///     Fecha en que se publicó el comentario.
        /// </summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        /// <summary>
        ///     Comentario o asunto de una solicitud.
        /// </summary>
        public string Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }
    }
}
