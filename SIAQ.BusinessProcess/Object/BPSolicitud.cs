using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPSolicitud : BPBase
    {
        private int _ErrorId;
        private string _ErrorDescription;
        protected ENTSolicitud _SolicitudEntity;
        protected ENTAutoridad _AutoridadEntity;

        public ENTSolicitud SolicitudEntity
        {
            get { return _SolicitudEntity; }
            set { _SolicitudEntity = value; }
        }

        public ENTAutoridad AutoridadEntity
        {
            get { return _AutoridadEntity; }
            set { _AutoridadEntity = value; }
        }

        public BPSolicitud()
        {
            _SolicitudEntity = new ENTSolicitud();
            _AutoridadEntity = new ENTAutoridad();
        }

        /// <summary>
        ///     Número de error ocurrido. Cero por default
        /// </summary>
        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        /// <summary>
        ///     Descripción del error ocurrido
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
        }
        
        ///<remarks>
        ///   <name>BPSolicituddeleteSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de Solicitud del sistema</summary>
        public ENTResponse deleteSolicitud(ENTSolicitud entSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitud dataSolicitud = new DASolicitud();
                oENTResponse = dataSolicitud.searchSolicitud(entSolicitud);
                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            // Resultado
            return oENTResponse;

        }

        /// <summary>
        /// Metodo para enviar la solicitud a Visitadurías
        /// </summary>
        public ENTResponse EnviarSolicitud(ENTSolicitud oENTSolicitud)
        {
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                //Consulta 
                DASolicitud oDASolicitud = new DASolicitud();
                oENTResponse = oDASolicitud.EnviarSolicitud(oENTSolicitud, sConnectionApplication, 0);
                //Validacion de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                oENTResponse.sMessage = String.Empty;
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }

            //Resultado
            return oENTResponse;
        }

        public void GuardarCalificacionSol()
        {

            DASolicitud SolicitudAccess = new DASolicitud();

            SolicitudAccess.GuardarCalificacionSol(_SolicitudEntity, sConnectionApplication);

            _ErrorId = SolicitudAccess.ErrorId;
            _ErrorDescription = SolicitudAccess.ErrorDescription;
        }

        ///<remarks>
        ///   <name>BPSolicitudinsertSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar Solicitud del sistema</summary>
        public ENTResponse insertSolicitud(ENTSolicitud entSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitud dataSolicitud = new DASolicitud();
                oENTResponse = dataSolicitud.insertSolicitud(entSolicitud);
                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            // Resultado
            return oENTResponse;

        }

        ///<remarks>
        ///   <name>BPSolicitud.searchSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las Solicitud del sistema</summary>
        public ENTResponse searchSolicitud(ENTSolicitud entSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitud dataSolicitud = new DASolicitud();
                oENTResponse = dataSolicitud.searchSolicitud(entSolicitud);
                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            // Resultado
            return oENTResponse;

        }

        public void SaveFuncionarioSolicitud()
        {
            DASolicitud SolicitudAccess = new DASolicitud();

            SolicitudAccess.UpdateFuncionarioSolicitud(_SolicitudEntity, sConnectionApplication);

            _ErrorId = SolicitudAccess.ErrorId;
            _ErrorDescription = SolicitudAccess.ErrorDescription;
        }

        /// <summary>
        ///     
        /// </summary>
        public void SelectSolicitud()
        {
            string ConnectionString = string.Empty;
            DASolicitud DASolicitud = new DASolicitud();

            ConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitud(_SolicitudEntity, ConnectionString);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        /// <summary>
        ///     Cambia el estatus de una solicitud.
        /// </summary>
        public void SaveSolicitudEstatus()
        {
            DASolicitud SolicitudAccess = new DASolicitud();

            SolicitudAccess.UpdateSolicitudEstatus(_SolicitudEntity, sConnectionApplication);

            _ErrorId = SolicitudAccess.ErrorId;
            _ErrorDescription = SolicitudAccess.ErrorDescription;
        }

        /// <summary>
        ///     Actualiza la información del detalle de la solicitud.
        /// </summary>
        public void SaveSolicitudGeneral()
        {
            DASolicitud SolicitudAccess = new DASolicitud();

            SolicitudAccess.UpdateSolicitudGeneral(_SolicitudEntity, sConnectionApplication);

            _ErrorId = SolicitudAccess.ErrorId;
            _ErrorDescription = SolicitudAccess.ErrorDescription;
        }

        /// <summary>
        ///     Busca las autoridades que están señaladas en una solicitud.
        /// </summary>
        public void SelectSolicitudAutoridad()
        {
            string ConnectionString = string.Empty;
            DASolicitud DASolicitud = new DASolicitud();

            ConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudAutoridad(_SolicitudEntity, ConnectionString);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        /// <summary>
        /// Muestra las voces señaladas de una autoridad de una solicitud
        /// </summary>
        public void SelectSolicitudAutoridadVoces()
        {
            string sConnectionString = String.Empty;
            DASolicitud oDASolicitud = new DASolicitud();

            sConnectionString = sConnectionApplication;
            _AutoridadEntity.dsResponse = oDASolicitud.SelectSolicitudAutoridadVoces(_AutoridadEntity, sConnectionString);

            _ErrorId = oDASolicitud.ErrorId;
            _ErrorDescription = oDASolicitud.ErrorDescription;
        }

        /// <summary>
        ///     Busca los ciudadanos que están relacionados a una solicitud.
        /// </summary>
        public void SelectSolicitudCiudadano()
        {
            string ConnectionString = string.Empty;
            DASolicitud DASolicitud = new DASolicitud();

            ConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudCiudadano(_SolicitudEntity, ConnectionString);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        /// <summary>
        ///     Busca los comentarios realizados para una solicitud.
        /// </summary>
        public void SelectSolicitudComentario()
        {
            string ConnectionString = string.Empty;
            DASolicitud DASolicitud = new DASolicitud();

            ConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudComentario(_SolicitudEntity, ConnectionString);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        /// <summary>
        ///     Busca el detalle completo de una solicitud.
        /// </summary>
        public void SelectSolicitudDetalle()
        {
            DASolicitud DASolicitud = new DASolicitud();

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudDetalle(_SolicitudEntity, sConnectionApplication);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        /// <summary>
        ///     Busca las solicitudes asignadas a un funcionario, que están en estatus por atender o en proceso.
        /// </summary>
        public void SelectSolicitudFuncionario()
        {
            string ConnectionString = string.Empty;
            DASolicitud DASolicitud = new DASolicitud();

            ConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudFuncionario(_SolicitudEntity, ConnectionString);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        /// <summary>
        ///     Busca las solicitudes de la secretaria que están pendientes de aprobar.
        /// </summary>
        public void SelectSolicitudSecretaria()
        {
            string ConnectionString = string.Empty;
            DASolicitud DASolicitud = new DASolicitud();

            ConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudSecretaria(_SolicitudEntity, ConnectionString);

            _ErrorId = DASolicitud.ErrorId;
            _ErrorDescription = DASolicitud.ErrorDescription;
        }

        ///<remarks>
        ///   <name>BPSolicitudupdateSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Solicitud del sistema</summary>
        public ENTResponse updateSolicitud(ENTSolicitud entSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitud dataSolicitud = new DASolicitud();
                oENTResponse = dataSolicitud.searchSolicitud(entSolicitud);
                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            // Resultado
            return oENTResponse;

        }

        /// <summary>
        /// Valida la solicitud antes de enviarla, que haya ciudadanos agregados, que se haya calificado, que haya autoridades agregadas y que se hayan agregado voces señaladas a dichas autoridades
        /// </summary>
        public void ValidarEnviarSolicitud()
        {
            string sConnectionString = String.Empty;
            DASolicitud oDASolicitud = new DASolicitud();

            sConnectionString = sConnectionApplication;

            _SolicitudEntity.ResultData = oDASolicitud.ValidarEnviarSolicitud(_SolicitudEntity, sConnectionString);

            _ErrorId = oDASolicitud.ErrorId;
            _ErrorDescription = oDASolicitud.ErrorDescription;
        }


		/// <summary>
		///     Busca los comentarios realizados para una solicitud.
		/// </summary>
		public void SelectRptQuejas(ref DataSet ds, ENTSolicitud ent)
		{
			ENTResponse oENTResponse = new ENTResponse();
			string ConnectionString = string.Empty;
			DASolicitud DASolicitud = new DASolicitud();

			ConnectionString = sConnectionApplication;

			_SolicitudEntity.ResultData = DASolicitud.SelectRptQuejas(ent, ConnectionString);

			_ErrorId = DASolicitud.ErrorId;
			_ErrorDescription = DASolicitud.ErrorDescription;

			oENTResponse.dsResponse = _SolicitudEntity.ResultData;
			ds = oENTResponse.dsResponse;

		}

    }
}
