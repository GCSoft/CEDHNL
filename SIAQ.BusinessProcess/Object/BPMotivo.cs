using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
using System.Data;
using System.Web;

namespace SIAQ.BusinessProcess.Object
{
    public class BPMotivo : BPBase
    {
       protected ENTMotivo _MotivoEntity;

       public ENTMotivo Motivo
       {
           get { return _MotivoEntity; }
           set { _MotivoEntity = value; }
       }

       public BPMotivo()
       {
           _MotivoEntity = new ENTMotivo();
       }

       public DataSet SelectMotivo()
       {
           string ConnectionString = string.Empty;
           DAMotivo DAMotivo = new DAMotivo();
           ConnectionString = sConnectionApplication;
           _MotivoEntity.ResultData = DAMotivo.SelectMotivo(_MotivoEntity, ConnectionString);
           return _MotivoEntity.ResultData;
       }
    }
}
