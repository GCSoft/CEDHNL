using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTRecomendacionAutoridad : ENTBase
    {

        #region Atributos

        private int _RecomendacionId;
        private int _AutoridadId;
        private int _Nombre;
        private int _PuestoId;
        private string _Comentarios;

        #endregion

        #region Propiedades

        ///<remarks>
        ///   <name>RecomendacionAutoridad.RecomendacionAutoridadId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna RecomendacionAutoridadId
        /// </summary>
        public int RecomendacionId
        {
            get { return _RecomendacionId; }
            set { _RecomendacionId = value; }
        }

        ///<remarks>
        ///   <name>RecomendacionAutoridad.AutoridadId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna AutoridadId
        /// </summary>
        public int AutoridadId
        {
            get { return _AutoridadId; }
            set { _AutoridadId = value; }
        }

        ///<remarks>
        ///   <name>RecomendacionAutoridad.Nombre</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna Nombre
        /// </summary>
        public int Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        ///<remarks>
        ///   <name>RecomendacionAutoridad.PuestoId</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna PuestoId
        /// </summary>
        public int PuestoId
        {
            get { return _PuestoId; }
            set { _PuestoId = value; }
        }

        ///<remarks>
        ///   <name>RecomendacionAutoridad.Comentarios</name>
        ///   <create>05/mar/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        /// <summary>
        /// Obtiene/Asigna Comentarios
        /// </summary>
        public string Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        #endregion

        #region Funciones

        public ENTRecomendacionAutoridad()
        {

            _RecomendacionId = 0;
            _AutoridadId = 0;
            _Nombre = 0;
            _PuestoId = 0;
            _Comentarios = "";

        }

        #endregion

    }
}
