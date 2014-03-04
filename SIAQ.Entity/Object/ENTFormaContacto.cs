using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTFormaContacto : ENTBase
    {
        private int _FormaDeContactoId;
        private string _Nombre;
        private string _Descripcion; // Valor de Descripcion
        private DataSet _ResultData; //Otras propiedades

        public ENTFormaContacto()
        {
            _FormaDeContactoId = 0;
            _Nombre = "";
            _Descripcion = "";
        }

        public int FormaDeContactoId {

            get { return _FormaDeContactoId; }
            set { _FormaDeContactoId = value; }
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
