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

        ///<remarks>
        ///<name>DASeguimiento.SelectCiudadanoRecomendacionDirector</name>
        ///<create>07/mar/2014</create>
        ///<author>Generator</author>
        ///</remarks>
        /// <summary>
        /// Metodo para obtener los ciudadanos que tienen que ver con una recomendacion especifica
        /// </summary>
        public void SelectCiudadanoRecomendacionDirector()
        {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectListadoCiudadanosRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;

        }

        ///<remarks>
        ///<name>DASeguimiento.SelectDetalleRecomendacionDirector</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene el detalle de la recomendación
        /// </summary>
        public void SelectDetalleRecomendacionDirector() {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectDetalleRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription; 
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectAutoridadRecomendacionDirector</name>
        ///<create>07/mar/2014</create>
        ///<author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene la lista de autoridades para una recomendacion especifica
        /// </summary>
        public void SelectAutoridadRecomendacionDirector() {

            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectListadoAutoridadesRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;

        }

        ///<remarks>
        ///<name>DASeguimiento.SelectDetalleRecomendacionGrid</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene las recomendaciones en el grid
        /// </summary>
        public void SelectDetalleRecomendacionGrid()
        {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectRecomendacionGrid(ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectDetalleRecomendacion</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene el detalle de la recomendación
        /// </summary>
        public void SelectDetalleRecomendacion()
        {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectDetalleRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectAsignarFuncionarioCombo</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene los funcionarios a los que se van a asignar la recomendacion
        /// </summary>
        public void SelectAsignarFuncionarioCombo()
        {
            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectFuncionariosAsignarCombo(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;
        }

        #endregion


    }
}
