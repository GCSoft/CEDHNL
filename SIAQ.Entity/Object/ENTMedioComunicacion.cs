using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTMedioComunicacion : ENTBase
    {
        private int _MedioComunicacionId; // Valor de MedioComunicacionId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; //Otras propiedades
        public ENTMedioComunicacion()
        {
            _MedioComunicacionId = 0;
            _Nombre = "";
            _Descripcion = "";
        }

        ///<remarks>
        ///   <name>MedioComunicacion.MedioComunicacionId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna MedioComunicacionId</summary>
        public int MedioComunicacionId
        {
            get { return _MedioComunicacionId; }
            set { _MedioComunicacionId = value; }
        }
        ///<remarks>
        ///   <name>MedioComunicacion.Nombre</name>
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
        ///   <name>MedioComunicacion.Descripcion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }

    }
}
