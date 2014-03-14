using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
     public class ENTTipoOrientacion : ENTBase
    {
        private int _TipoOrientacionId; 
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; //Otras propiedades

        public ENTTipoOrientacion()
        {
            _TipoOrientacionId = 0;
            _Nombre = "";
            _Descripcion = "";
        }

        public int TipoOrientacionId
        {
            get { return _TipoOrientacionId; }
            set { _TipoOrientacionId = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

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
