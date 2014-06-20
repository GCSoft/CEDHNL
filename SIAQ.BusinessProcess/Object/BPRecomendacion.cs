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

        /// <summary>
        ///     Guarda un registro nuevo de recomendación del expediente.
        /// </summary>
        public void SaveRecomendacion()
        {
            DARecomendacion RecomendacionAccess = new DARecomendacion();

            if (!ValidarRecomendacion())
                return;

            if (_RecomendacionEntity.RecomendacionId == 0)
            {
                _RecomendacionEntity.Numero = SelectNextFolio();

                RecomendacionAccess.InsertRecomendacion(_RecomendacionEntity, sConnectionApplication);
            }
            //else
            //    RecomendacionAccess.InsertRecomendacion(_RecomendacionEntity, sConnectionApplication);

            _ErrorId = RecomendacionAccess.ErrorId;
            _ErrorString = RecomendacionAccess.ErrorDescription;
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

        ///<remarks>
        ///<name>DASeguimiento.SelectAutoridadRecomendacionDirector</name>
        ///<create>07/mar/2014</create>
        ///<author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene la lista de autoridades para una recomendacion especifica
        /// </summary>
        public void SelectAutoridadRecomendacionDirector()
        {

            string ConnectionString = String.Empty;
            DARecomendacion DARecomendacion = new DARecomendacion();

            ConnectionString = sConnectionApplication;

            _RecomendacionEntity.ResultData = DARecomendacion.SelectListadoAutoridadesRecomendacion(_RecomendacionEntity, ConnectionString);
            _ErrorId = DARecomendacion.ErrorId;
            _ErrorString = DARecomendacion.ErrorDescription;

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

        /// <summary>
        ///     Busca el siguiente número de folio para una recomendación.
        /// </summary>
        /// <returns>Siguiente número de recomendación.</returns>
        private int SelectNextFolio()
        {
            int NextFolio = 0;
            DataSet ResultData = new DataSet();
            DARecomendacion RecomendacionAccess = new DARecomendacion();

            if (_RecomendacionEntity.Anio == 0)
            {
                _ErrorId = 50006;
                _ErrorString = "Se debe proporcionar un año para calcular el siguiente número de folio";
                return 0;
            }

            ResultData = RecomendacionAccess.SelectNextFolio(_RecomendacionEntity, sConnectionApplication);

            if (RecomendacionAccess.ErrorId > 0)
            {
                _ErrorId = RecomendacionAccess.ErrorId;
                _ErrorString = RecomendacionAccess.ErrorDescription;
                return 0;
            }

            if (ResultData.Tables[0].Rows.Count == 0)
            {
                _ErrorId = 50007;
                _ErrorString = "No se encontró información para el siguiente número de folio";
                return 0;
            }

            NextFolio = int.Parse(ResultData.Tables[0].Rows[0]["Folio"].ToString()) + 1;

            return NextFolio;
        }

        /// <summary>
        ///     Valida que la información de la recomendación esté completa.
        /// </summary>
        /// <returns>True|False</returns>
        private bool ValidarRecomendacion()
        {
            if (_RecomendacionEntity.ExpedienteId == 0)
            {
                _ErrorId = 50001;
                _ErrorString = "Se debe proporcionar un número de expediente para la recomendación";
                return false;
            }

            if (_RecomendacionEntity.EstatusId == 0)
            {
                _ErrorId = 50002;
                _ErrorString = "Se debe proporcionar un estatus de recomendación";
                return false;
            }

            if (_RecomendacionEntity.Numero == 0)
            {
                _ErrorId = 50003;
                _ErrorString = "Se debe proporcionar un número de folio de recomendación";
                return false;
            }

            if (_RecomendacionEntity.TipoRecomendacionId == 0)
            {
                _ErrorId = 50004;
                _ErrorString = "El campo Tipo de recomendación es obligatorio";
                return false;
            }

            if (_RecomendacionEntity.Observaciones == "")
            {
                _ErrorId = 50005;
                _ErrorString = "El campo Recomendación es obligatorio";
                return false;
            }

            return true;
        }

        #endregion


    }
}
