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

        public ENTSolicitud SolicitudEntity
        {
            get { return _SolicitudEntity; }
            set { _SolicitudEntity = value; }
        }

        public BPSolicitud()
        {
            _SolicitudEntity = new ENTSolicitud();
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
        ///     Busca el detalle completo de una solicitud.
        /// </summary>
        public void SelectSolicitudDetalle()
        {
            DASolicitud DASolicitud = new DASolicitud();

            _SolicitudEntity.ResultData = DASolicitud.SelectSolicitudDetalle(_SolicitudEntity, sConnectionApplication);

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
        ///     Actualiza la información del detalle de la solicitud.
        /// </summary>
        public void SaveSolicitudGeneral()
        {
            DASolicitud SolicitudAccess = new DASolicitud();

            SolicitudAccess.UpdateSolicitudGeneral(_SolicitudEntity, sConnectionApplication);

            _ErrorId = SolicitudAccess.ErrorId;
            _ErrorDescription = SolicitudAccess.ErrorDescription;
        }
    }
}
