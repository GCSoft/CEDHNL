using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTEstado : ENTBase
    {
        private int _EstadoId; // Valor de EstadoId
        private int _PaisId; // Valor de PaisId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; //Otras propiedades
        public ENTEstado()
        {

            _EstadoId = 0;
            _PaisId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Estado.EstadoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstadoId</summary>
        public int EstadoId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }
        ///<remarks>
        ///   <name>Estado.PaisId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PaisId</summary>
        public int PaisId
        {
            get { return _PaisId; }
            set { _PaisId = value; }
        }
        ///<remarks>
        ///   <name>Estado.Nombde</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Nombde</summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        ///<remarks>
        ///   <name>Estado.Descripcion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        ///     DataSet resultante de las busquedas en la base de datos
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }
    }
}
