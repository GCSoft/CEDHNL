using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTNacionalidad : ENTBase
    {
        private int _NacionalidadId; // Valor de NacionalidadId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        public ENTNacionalidad()
        {
            _NacionalidadId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Nacionalidad.NacionalidadId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NacionalidadId</summary>
        public int NacionalidadId
        {
            get { return _NacionalidadId; }
            set { _NacionalidadId = value; }
        }
        ///<remarks>
        ///   <name>Nacionalidad.Nombre</name>
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
        ///   <name>Nacionalidad.Descripcion</name>
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
