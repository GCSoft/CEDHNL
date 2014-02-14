using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTVisita : ENTBase
    {
        private Int32 _AreaId;
        private Int32 _FuncionarioId;
        private Int32 _MotivoId;
        private Int32 _UsuarioIdInsert;
        private string _Observaciones;
        private string _Fecha;

        public ENTVisita() {

            _AreaId = 0;
            _FuncionarioId = 0;
            _MotivoId = 0;
            _UsuarioIdInsert = 0;
            _Observaciones = "";
            _Fecha = "";
        }

        public Int32 AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; }
        }

        public Int32 FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }

        public Int32 MotivoId
        {
            get { return _MotivoId; }
            set { _MotivoId = value; }
        }

        public Int32 UsuarioIdInsert
        {
            get { return _UsuarioIdInsert; }
            set { _UsuarioIdInsert = value; }
        }

        public String Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        public String Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
    }
}
