using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTVocesSenaladas : ENTBase
    {

        #region Atributos

        private int _VozId;
        private int _VozIdPadrePrimerNivel;
        private int _VozIdPadreSegundoNivel;
        private string _Nombre;
        private int _AutoridadId;
        private int _SolicitudId;
        private DataSet _dsResponse;

        private String _sComentarios;     // Almacena los comentarios al asociar voces a una autoridad

        #endregion

        #region Propiedades

        public int VozId
        {
            get { return _VozId; }
            set { _VozId = value; }
        }
        public int VozIdPadrePrimerNivel
        {
            get { return _VozIdPadrePrimerNivel; }
            set { _VozIdPadrePrimerNivel = value; }
        }
        public int VozIdPadreSegundoNivel
        {
            get { return _VozIdPadreSegundoNivel; }
            set { _VozIdPadreSegundoNivel = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public int AutoridadId
        {
            get { return _AutoridadId; }
            set { _AutoridadId = value; }
        }
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }
        public DataSet dsResponse
        {
            get { return _dsResponse; }
            set { _dsResponse = value; }
        }

        ///<remarks>
        ///   <name>ENTVocesSenaladas.Comentarios</name>
        ///   <create>28-Mayo-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna los comentarios al asociar voces a una autoridad</summary>
        public String Comentarios
        {
            get { return _sComentarios; }
            set { _sComentarios = value; }
        }

        #endregion

    }
}
