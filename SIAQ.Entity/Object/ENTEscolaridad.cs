using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTEscolaridad : ENTBase
    {
        private int _EscolaridadId; // Valor de EscolaridadId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        public ENTEscolaridad()
        {
            _EscolaridadId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Escolaridad.EscolaridadId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EscolaridadId</summary>
        public int EscolaridadId
        {
            get { return _EscolaridadId; }
            set { _EscolaridadId = value; }
        }
        ///<remarks>
        ///   <name>Escolaridad.Nombre</name>
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
        ///   <name>Escolaridad.Descripcion</name>
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
