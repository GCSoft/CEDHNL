using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTAutoridad : ENTBase
    {

        #region Atributos

        private int _AutoridadId;
        private int _AutoridadIdPadrePrimerNivel;
        private int _AutoridadIdPadreSegundoNivel;
        private int _SolicitudId;
        private byte _Nivel;
        private string _Nombre;
        private string _Puesto;
        private string _Comentario;
        private DataSet _dsResponse;

        #endregion

        #region Propiedades

        public int AutoridadId
        {
            get { return _AutoridadId; }
            set { _AutoridadId = value; }
        }
        public int AutoridadIdPadrePrimerNivel
        {
            get { return _AutoridadIdPadrePrimerNivel; }
            set { _AutoridadIdPadrePrimerNivel = value; }
        }
        public int AutoridadIdPadreSegundoNivel
        {
            get { return _AutoridadIdPadreSegundoNivel; }
            set { _AutoridadIdPadreSegundoNivel = value; }
        }
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }
        public byte Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Puesto
        {
            get { return _Puesto; }
            set { _Puesto = value; }
        }
        public string Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }
        public DataSet dsResponse
        {
            get { return _dsResponse; }
            set { _dsResponse = value; }
        }
        #endregion

        #region Funciones

        public ENTAutoridad()
        {
            _AutoridadId = 0;
            _AutoridadIdPadrePrimerNivel = 0;
            _AutoridadIdPadreSegundoNivel = 0;
            _Nivel = 0;
            _Nombre = String.Empty;
            _dsResponse = new DataSet();
        }

        #endregion
    }
}
