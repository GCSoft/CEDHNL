using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTCalificacion : ENTBase
    {
        private int _CalificacionId; // Valor de CalificacionId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        public ENTCalificacion()
        {
            _CalificacionId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Calificacion.CalificacionId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CalificacionId</summary>
        public int CalificacionId
        {
            get { return _CalificacionId; }
            set { _CalificacionId = value; }
        }
        ///<remarks>
        ///   <name>Calificacion.Nombre</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Nombre</summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        ///<remarks>
        ///   <name>Calificacion.Descripcion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
