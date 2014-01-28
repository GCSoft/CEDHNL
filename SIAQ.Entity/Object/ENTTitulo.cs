using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTTitulo : ENTBase
    {
        private int _TituloId; // Valor de TituloId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        public ENTTitulo()
        {
            _TituloId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Titulo.TituloId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TituloId</summary>
        public int TituloId
        {
            get { return _TituloId; }
            set { _TituloId = value; }
        }
        ///<remarks>
        ///   <name>Titulo.Nombre</name>
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
        ///   <name>Titulo.Descripcion</name>
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
