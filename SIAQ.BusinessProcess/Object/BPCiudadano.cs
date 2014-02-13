using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{

    public class BPCiudadano : BPBase
    {

        private int _ErrorId;
        private string _ErrorDescription;
        private ENTCiudadano _ENTCiudadano;//

        public BPCiudadano()
        {

            _ErrorId = 0;
            _ErrorDescription = "";
            _ENTCiudadano = new ENTCiudadano();

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
        ///     Entidad de ciudadano
        /// </summary>
        public ENTCiudadano ENTCiudadano
        {
            get { return _ENTCiudadano; }
            set { _ENTCiudadano = value; }
        }

        ///<remarks>
        ///   <name>BPCiudadano.searchCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las Ciudadano del sistema</summary>
        public ENTResponse searchCiudadano(ENTCiudadano entCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudadano dataCiudadano = new DACiudadano();
                oENTResponse = dataCiudadano.searchCiudadano(entCiudadano);
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
        ///   <name>BPCiudadanoinsertCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar Ciudadano del sistema</summary>
        public ENTResponse insertCiudadano(ENTCiudadano entCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudadano dataCiudadano = new DACiudadano();
                oENTResponse = dataCiudadano.searchCiudadano(entCiudadano);
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
        ///   <name>BPCiudadanoupdateCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Ciudadano del sistema</summary>
        public ENTResponse updateCiudadano(ENTCiudadano entCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudadano dataCiudadano = new DACiudadano();
                oENTResponse = dataCiudadano.searchCiudadano(entCiudadano);
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
        ///   <name>BPCiudadanodeleteCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de Ciudadano del sistema</summary>
        public ENTResponse deleteCiudadano(ENTCiudadano entCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudadano dataCiudadano = new DACiudadano();
                oENTResponse = dataCiudadano.searchCiudadano(entCiudadano);
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

        public void BuscarCiudadano()
        {
            string ConnectionString = string.Empty;
            DACiudadano DACiudadano = new DACiudadano();

            ConnectionString = sConnectionApplication;
            _ENTCiudadano.ResultData = DACiudadano.SelectCiudadano(_ENTCiudadano, ConnectionString);

            _ErrorId = DACiudadano.ErrorId;
            _ErrorDescription = DACiudadano.ErrorDescription;

        }
    }
}
