using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTMotivo : ENTBase
    {
        private Int16 _MotivoId;
        private string _Nombre;
        private DataSet _ResultData; //Otras propiedades
        private string _Descripcion; // Valor de Descripcion

        public ENTMotivo(){
            _MotivoId = 0;
			_Nombre = "";
            _Descripcion = "";
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public Int16 MotivoId {

            get { return _MotivoId; }
            set { _MotivoId = value; }
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
