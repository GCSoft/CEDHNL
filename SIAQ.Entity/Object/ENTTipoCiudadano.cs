using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTTipoCiudadano : ENTBase
    {
        private int _TipoCiudadanoId; // Valor de TipoCiudadanoId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        public ENTTipoCiudadano()
        {
            _TipoCiudadanoId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>TipoCiudadano.TipoCiudadanoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoCiudadanoId</summary>
        public int TipoCiudadanoId
        {
            get { return _TipoCiudadanoId; }
            set { _TipoCiudadanoId = value; }
        }
        ///<remarks>
        ///   <name>TipoCiudadano.Nombre</name>
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
        ///   <name>TipoCiudadano.Descripcion</name>
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
