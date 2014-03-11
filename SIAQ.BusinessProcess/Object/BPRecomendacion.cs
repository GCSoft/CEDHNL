using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPRecomendacion: BPBase 
    {

           #region Atributos

        protected ENTRecomendacion _RecomendacionEntity;
        private int _ErrorId;
        private string _ErrorString;

        #endregion

        #region Propiedades

        public ENTRecomendacion RecomendacionEntity
        {
            get { return _RecomendacionEntity; }
            set { _RecomendacionEntity = value; }
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

        public BPRecomendacion()
        {
            _RecomendacionEntity = new ENTRecomendacion();
        }

        public void SelectCiudadanoRecomendacionDirector()
        {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectListadoCiudadanosRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;

        }

        public void SelectDetalleRecomendacionDirector() {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectDetalleRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription; 
        }

        public void SelectAutoridadRecomendacionDirector() {

            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectListadoAutoridadesRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;

        }

        

        #endregion


    }
}
