using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPCalificacion : BPBase
    {
        private int _ErrorId;
        private string _ErrorDescription;
        private ENTCalificacion _ENTCalificacion;//

        public BPCalificacion()
        {

            _ErrorId = 0;
            _ErrorDescription = "";
            _ENTCalificacion = new ENTCalificacion();

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
            set { _ErrorDescription = value; }
        }
        /// <summary>
        ///     Entidad de calificacion
        /// </summary>
        public ENTCalificacion ENTCalificacion
        {
            get { return _ENTCalificacion; }
            set { _ENTCalificacion = value; }
        }
        ///<remarks>
        ///   <name>BPcatCalificacion.searchcatCalificacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCalificacion del sistema</summary>
        public ENTResponse searchcatCalificacion(ENTCalificacion entCalificacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACalificacion datacatCalificacion = new DACalificacion();
                oENTResponse = datacatCalificacion.searchcatCalificacion(entCalificacion);
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
        ///   <name>BPcatCalificacioninsertcatCalificacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catCalificacion del sistema</summary>
        public ENTResponse insertcatCalificacion(ENTCalificacion entCalificacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACalificacion datacatCalificacion = new DACalificacion();
                oENTResponse = datacatCalificacion.searchcatCalificacion(entCalificacion);
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
        ///   <name>BPcatCalificacionupdatecatCalificacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCalificacion del sistema</summary>
        public ENTResponse updatecatCalificacion(ENTCalificacion entCalificacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACalificacion datacatCalificacion = new DACalificacion();
                oENTResponse = datacatCalificacion.searchcatCalificacion(entCalificacion);
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
        ///   <name>BPcatCalificaciondeletecatCalificacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catCalificacion del sistema</summary>
        public ENTResponse deletecatCalificacion(ENTCalificacion entCalificacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACalificacion datacatCalificacion = new DACalificacion();
                oENTResponse = datacatCalificacion.searchcatCalificacion(entCalificacion);
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

        public DataSet SelectCalificacion()
        {
            string ConnectionString = string.Empty;
            DACalificacion DACalificacion = new DACalificacion();

            ConnectionString = sConnectionApplication;
            _ENTCalificacion.ResultData = DACalificacion.SelectCalificacion(_ENTCalificacion, ConnectionString);

            _ErrorId = DACalificacion.ErrorId;
            _ErrorDescription = DACalificacion.ErrorDescription;

            return _ENTCalificacion.ResultData;

        }
    }
}
