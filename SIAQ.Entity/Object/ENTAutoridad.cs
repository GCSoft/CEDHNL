using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SIAQ.Entity.Object
{
    class ENTAutoridad : ENTBase
    {

        #region Atributos

        private int _AutoridadId;
        private int _AutoridadIdPadrePrimerNivel;
        private int _AutoridadIdPadreSegundoNivel;
        private byte _Nivel;
        private string _Nombre;

        #endregion

        #region Propiedades

        public int AutoridadId { get { return _AutoridadId; } set { _AutoridadId = value; } }
        public int AutoridadIdPadrePrimerNivel { get { return _AutoridadIdPadrePrimerNivel; } set { _AutoridadIdPadrePrimerNivel = value; } }
        public int AutoridadIdPadreSegundoNivel { get { return _AutoridadIdPadreSegundoNivel; } set { _AutoridadIdPadreSegundoNivel = value; } }
        public byte Nivel { get { return _Nivel; } set { _Nivel = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }

        #endregion

        #region Funciones

        #endregion
    }
}
