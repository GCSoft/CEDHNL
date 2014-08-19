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

		///<remarks>
		///   <name>BPDiligencia.SelectRecomendacionDiligencia</name>
		///   <create>07/Junio/2014</create>
		///   <author>Ruben.Cobosz</author>
		///</remarks>
		///<summary>Obtiene el listado de las diligencias de un expediente en la etapa de seguimientos</summary>
		public DataSet SelectRecomendacionDiligencia()
		{
			DADiligencia oDADiligencia = new DADiligencia();
			string ConnectionString = string.Empty;

			ConnectionString = sConnectionApplication;

			_DiligenciaEntity.DataResult = oDADiligencia.SelectRecomendacionDiligencia(_DiligenciaEntity, ConnectionString);
			_ErrorId = oDADiligencia.ErrorId;
			_ErrorDescription = oDADiligencia.ErrorDescription;

			return _DiligenciaEntity.DataResult;
		}


        //Detalle

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
        /// Muestra los datos de la diligencia seleccionada
        /// </summary>
        public DataSet SelectDetalleDiligenciaSolicitud()
        {
            DADiligencia oDADiligencia = new DADiligencia();
            string ConnectionString = string.Empty;

            ConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectDetalleDiligenciaSolicitud(_DiligenciaEntity, ConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;

            return _DiligenciaEntity.DataResult;
        }

        /// <summary>
        /// Muestra los datos de la diligencia seleccionada
        /// </summary>
        public DataSet SelectDetalleDiligenciaRecomendacion()
        {
            DADiligencia oDADiligencia = new DADiligencia();
            string ConnectionString = string.Empty;

            ConnectionString = sConnectionApplication;

            _DiligenciaEntity.DataResult = oDADiligencia.SelectDetalleDiligenciaRecomendacion(_DiligenciaEntity, ConnectionString);
            _ErrorId = oDADiligencia.ErrorId;
            _ErrorDescription = oDADiligencia.ErrorDescription;

            return _DiligenciaEntity.DataResult;
        }

        //Insertar

        

        /// <summary>
        /// Crea una nueva diligencia para una solicitud
        /// </summary>
        public ENTResponse InsertDiligenciaSolicitud(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Transaccion
                oENTResponse = oDADiligencia.InsertDiligenciaSolicitud(oENTDiligencia, sConnectionApplication, 0);

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
        /// Crea una nueva diligencia para una recomendación
        /// </summary>
        public ENTResponse InsertDiligenciaRecomendacion(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Transaccion
                oENTResponse = oDADiligencia.InsertDiligenciaRecomendacion(oENTDiligencia, sConnectionApplication, 0);

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

        //Modificar

        /// <summary>
        /// Modifica una diligencia para una solicitud
        /// </summary>
        public ENTResponse UpdateDiligenciaSolicitud(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Transacción 
                oENTResponse = oDADiligencia.UpdateDiligenciaSolicitud(oENTDiligencia, sConnectionApplication, 0);

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
		/// Modifica una diligencia para una recomendación
        /// </summary>
        public ENTResponse UpdateDiligenciaRecomendacion(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Transacción 
                oENTResponse = oDADiligencia.UpdateDiligenciaRecomendacion(oENTDiligencia, sConnectionApplication, 0);

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

        //Eliminar

        /// <summary>
        /// Borra una diligencia de una solicitud
        /// </summary>
        public ENTResponse DeleteDiligenciaSolicitud(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                oENTResponse = oDADiligencia.DeleteDiligenciaSolicitud(oENTDiligencia, sConnectionApplication, 0);

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

        /// <summary>
        /// Elimina una diligencia de una recomendacion
        /// </summary>
        public ENTResponse DeleteDiligenciaRecomendacion(ENTDiligencia oENTDiligencia)
        {
            DADiligencia oDADiligencia = new DADiligencia();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                oENTResponse = oDADiligencia.DeleteDiligenciaRecomendacion(oENTDiligencia, sConnectionApplication, 0);

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


		/// <summary>
		/// Elimina una diligencia para un Expediente
		/// </summary>
		public ENTResponse DeleteExpedienteDiligencia(ENTDiligencia oENTDiligencia){
			DADiligencia oDADiligencia = new DADiligencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				oENTResponse = oDADiligencia.DeleteExpedienteDiligencia(oENTDiligencia, sConnectionApplication, 0);

				if (oENTResponse.GeneratesException) { return oENTResponse; }

				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPDiligencia.InsertExpedienteDiligencia</name>
		///   <create>18/Ago/2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva diligencia para un Expediente</summary>
		public ENTResponse InsertExpedienteDiligencia(ENTDiligencia oENTDiligencia){
			DADiligencia oDADiligencia = new DADiligencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				//Transaccion
				oENTResponse = oDADiligencia.InsertExpedienteDiligencia(oENTDiligencia, sConnectionApplication, 0);

				//Validacion error
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de base de datos
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

		/// <summary>
		/// Consula la información de una Diligencia en particular asociada a un expediente
		/// </summary>
		public DataSet SelectExpedienteDiligencia(){
			DADiligencia oDADiligencia = new DADiligencia();
			string ConnectionString = string.Empty;

			ConnectionString = sConnectionApplication;

			_DiligenciaEntity.DataResult = oDADiligencia.SelectExpedienteDiligencia(_DiligenciaEntity, ConnectionString);
			_ErrorId = oDADiligencia.ErrorId;
			_ErrorDescription = oDADiligencia.ErrorDescription;

			return _DiligenciaEntity.DataResult;
		}

		/// <summary>
		/// Actualiza una diligencia existente para un Expediente
		/// </summary>
		public ENTResponse UpdateExpedienteDiligencia(ENTDiligencia oENTDiligencia){
			DADiligencia oDADiligencia = new DADiligencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				//Transacción 
				oENTResponse = oDADiligencia.UpdateExpedienteDiligencia(oENTDiligencia, sConnectionApplication, 0);

				//Validación error
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				//Validacion de mensajes de error de base de datos
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }



			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

    }
}
