using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTExpedienteComentario : ENTBase
    {

        #region Atribtuos

        private int _ComentarioId;
        private int _ExpedienteId;
        private int _idUsuario;
        private DateTime _Fecha;
        private string _Comentario;

        private DataSet _dsResult;

        #endregion

        #region Propiedades

        public int ComentarioId { get { return _ComentarioId; } set { _ComentarioId = value; } }
        public int ExpedienteId { get { return _ExpedienteId; } set { _ExpedienteId = value; } }
        public int idUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }
        public string Comentario { get { return _Comentario; } set { _Comentario = value; } }

        public DataSet dsResult { get { return _dsResult; } set { _dsResult = value; } }

        #endregion

    }
}
