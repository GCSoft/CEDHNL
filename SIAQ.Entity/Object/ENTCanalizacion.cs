using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTCanalizacion : ENTBase
    {
        private int _CanalizacionId; 
        private string _Nombre; // Valor de Nombre
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; //Otras propiedades

        public ENTCanalizacion()
        {
            _CanalizacionId = 0;
            _Nombre = "";
            _Descripcion = "";
        }

        public int CanalizacionId
        {
            get { return _CanalizacionId; }
            set { _CanalizacionId = value; }
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
