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

        public BPDiligencia()
        {
            _ErrorId = 0;
            _ErrorDescription = "";
            _DiligenciaEntity = new ENTDiligencia();
        }

        /// <summary>
        /// Selecciona el listado de tipo de diligencias para llenado del combobox
        /// </summary>
        public DataSet SelectTipoDiligencias()
        {
            string sConnectionString = string.Empty;
            DADiligencia oDADiligencia = new DADiligencia();

            sConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectTipoDiligencias(_DiligenciaEntity, sConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;
            return _DiligenciaEntity.DataResult;
        }

        /// <summary>
        /// Selecciona el listado de los lugares de diligencias para llenado del combobox
        /// </summary>
        public DataSet SelectLugarDiligencias()
        {
            string sConnectionString = string.Empty;
            DADiligencia oDADiligencia = new DADiligencia();

            sConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectLugarDiligencias(_DiligenciaEntity, sConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;
            return _DiligenciaEntity.DataResult;
        }

        /// <summary>
        /// Obtiene el listado de las diligencias de solicitudes, expedientes y recomendaciones
        /// </summary>
        public DataSet SelectDiligencias()
        {
            DADiligencia oDADiligencia = new DADiligencia();
            string ConnectionString = string.Empty;

            ConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectDiligencias(_DiligenciaEntity, ConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;

            return _DiligenciaEntity.DataResult;
        }

        #endregion

    }
}
