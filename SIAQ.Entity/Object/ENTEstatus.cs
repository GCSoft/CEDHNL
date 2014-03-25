using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTEstatus : ENTBase
    {
        private int _EstatusId; // Valor de EstatusId
        private int _TipoEstatusId; // Valor de TipoEstatusId
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; // Valor de tabla de datos 

        public ENTEstatus()
        {
            _EstatusId = 0;
            _TipoEstatusId = 0;
            _Nombre = "";
            _Descripcion = "";
        }
        ///<remarks>
        ///   <name>Estatus.EstatusId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstatusId</summary>
        public int EstatusId
        {
            get { return _EstatusId; }
            set { _EstatusId = value; }
        }
        ///<remarks>
        ///   <name>Estatus.TipoEstatusId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoEstatusId</summary>
        public int TipoEstatusId
        {
            get { return _TipoEstatusId; }
            set { _TipoEstatusId = value; }
        }
        ///<remarks>
        ///   <name>Estatus.Nombre</name>
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
        ///   <name>Estatus.Descripcion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        ///<remarks>
        ///   <name>Estatus.ResultData</name>
        ///   <create>25/MAR/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Dataset</summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }

    }
}
