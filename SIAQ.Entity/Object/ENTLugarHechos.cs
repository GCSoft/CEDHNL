using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTLugarHechos : ENTBase
    {
        private int _LugarHechosId; // Valor de LugarHechosId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData;

        public ENTLugarHechos()
        {
            _LugarHechosId = 0;
            _Nombre = "";
            _Descripcion = "";
            _ResultData = null;
        }

        ///<remarks>
        ///   <name>LugarHechos.LugarHechosId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna LugarHechosId</summary>
        public int LugarHechosId
        {
            get { return _LugarHechosId; }
            set { _LugarHechosId = value; }
        }

        ///<remarks>
        ///   <name>LugarHechos.Nombre</name>
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
        ///   <name>LugarHechos.Descripcion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        /// <summary>
        ///     Resultado de búsquedas.
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }
    }
}
