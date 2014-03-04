using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
using System.Data;
namespace SIAQ.BusinessProcess.Object
{
    public class BPFormaContacto : BPBase
    {
        protected ENTFormaContacto _FormaContactoEntity;

        public ENTFormaContacto FormaContactoEntity
        {
            get { return _FormaContactoEntity; }
            set { _FormaContactoEntity = value; }
        }

        public BPFormaContacto()
        {

            _FormaContactoEntity = new ENTFormaContacto();
        }


        public DataSet SelectFormaContacto()
        {
            string ConnectionString = string.Empty;
            DAFormaContacto DAFormaContacto = new DAFormaContacto();

            ConnectionString = sConnectionApplication;
            _FormaContactoEntity.ResultData = DAFormaContacto.SelectFormaContacto(_FormaContactoEntity, ConnectionString);
            return _FormaContactoEntity.ResultData;
        }
    }
}
