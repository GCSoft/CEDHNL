using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPDiligencia : BPBase
    {

        #region Atributos

        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTDiligencia _DiligenciaEntity;

        #endregion

        #region Propiedades

        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        public ENTDiligencia DiligenciaEntity
        {
            get { return _DiligenciaEntity; }
            set { _DiligenciaEntity = value; }
        }

        #endregion

        #region Funciones

        public DataSet SelectTipoDiligencias(ENTDiligencia oENTDiligencia)
        {
            string sConnectionString = string.Empty;
            DADiligencia oDADiligencia = new DADiligencia();

            sConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectTipoDiligencias(oENTDiligencia, sConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;
            return _DiligenciaEntity.DataResult;
        }

        #endregion

    }
}
