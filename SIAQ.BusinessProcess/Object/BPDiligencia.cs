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

        /// <summary>
        /// Muestra los datos de la diligencia seleccionada
        /// </summary>
        public DataSet SelectDetalleDiligenciaExpediente()
        {
            DADiligencia oDADiligencia = new DADiligencia();
            string ConnectionString = string.Empty;

            ConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectDetalleDiligenciaExpediente(_DiligenciaEntity, ConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;

            return _DiligenciaEntity.DataResult;
        }

        /// <summary>
        /// Crea una nueva diligencia para un expediente
        /// </summary>
        public ENTResponse InsertDiligenciaExpediente(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Transaccion
                oENTResponse = oDADiligencia.InsertDiligenciaExpediente(oENTDiligencia, sConnectionApplication, 0);

                //Validacion error
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de base de datos
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }

            //Resultado
            return oENTResponse;
        }

        /// <summary>
        /// Modifica una diligencia para un expediente
        /// </summary>
        public ENTResponse UpdateDiligenciaExpediente(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Transacción 
                oENTResponse = oDADiligencia.UpdateDiligenciaExpediente(oENTDiligencia, sConnectionApplication, 0);

                //Validación error
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                //Validacion de mensajes de error de base de datos
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }



            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }

            //Resultado
            return oENTResponse;
        }

        /// <summary>
        /// Borra una diligencia de un expediente
        /// </summary>
        public ENTResponse DeleteDiligenciaExpediente(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                oENTResponse = oDADiligencia.DeleteDiligenciaExpediente(oENTDiligencia, sConnectionApplication, 0);

                if (oENTResponse.GeneratesException) { return oENTResponse; }

                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }

            //Resultado
            return oENTResponse;
        }

        #endregion

    }
}
