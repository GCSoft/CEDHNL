using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPSeguimientoRecomendacion : BPBase
    {

        #region Atributos

        protected ENTSeguimientoRecomendacion _SeguimientoRecomendacionEntity;
        private int _ErrorId;
        private string _ErrorString;

        #endregion

        #region Propiedades

        public ENTSeguimientoRecomendacion SeguimientoRecomendacionEntity
        {
            get { return _SeguimientoRecomendacionEntity; }
            set { _SeguimientoRecomendacionEntity = value; }
        }

        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        public string ErrorString
        {
            get { return _ErrorString; }
            set { _ErrorString = value; }
        }

        #endregion

        #region Funciones

        public BPSeguimientoRecomendacion()
        {
            _SeguimientoRecomendacionEntity = new ENTSeguimientoRecomendacion();
        }

        public void SelectRecomendacionDirector()
        {
            string ConnectionString = String.Empty;
            DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

            ConnectionString = sConnectionApplication;

            _SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.SelectListadoRecomendacionDirector(_SeguimientoRecomendacionEntity, ConnectionString);
            _ErrorId = DASeguimientoRecomendacion.ErrorId;
            _ErrorString = DASeguimientoRecomendacion.ErrorDescription;

        }

        public void SelectRecomendacionDefensor()
        {
            string ConnectionString = String.Empty;
            DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

            ConnectionString = sConnectionApplication;

            _SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.SelectListadoRecomendacionDefensor(_SeguimientoRecomendacionEntity, ConnectionString);
            _ErrorId = DASeguimientoRecomendacion.ErrorId;
            _ErrorString = DASeguimientoRecomendacion.ErrorDescription; 

        }

        public void SelectRecomendacionSecretaria()
        {
            string ConnectionString = String.Empty;
            DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

            ConnectionString = sConnectionApplication;

            _SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.SelectListadoRecomendacionSecretaria(ConnectionString);
            _ErrorId = DASeguimientoRecomendacion.ErrorId;
            _ErrorString = DASeguimientoRecomendacion.ErrorDescription;

        }

        #endregion

    }
}
