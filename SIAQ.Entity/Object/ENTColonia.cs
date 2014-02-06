using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTColonia : ENTBase
    {
        private int _ColoniaId; // Valor de ColoniaId
        private int _CiudadId; // Valor de CiudadId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; //Otras propiedades
        public ENTColonia()
        {
            _ColoniaId = 0;
            _CiudadId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Colonia.ColoniaId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ColoniaId</summary>
        public int ColoniaId
        {
            get { return _ColoniaId; }
            set { _ColoniaId = value; }
        }
        ///<remarks>
        ///   <name>Colonia.CiudadId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CiudadId</summary>
        public int CiudadId
        {
            get { return _CiudadId; }
            set { _CiudadId = value; }
        }
        ///<remarks>
        ///   <name>Colonia.Nombre</name>
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
        ///   <name>Colonia.Descripcion</name>
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