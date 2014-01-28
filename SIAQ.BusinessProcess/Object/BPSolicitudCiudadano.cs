using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPSolicitudCiudadano : BPBase
    {
        ///<remarks>
        ///   <name>BPcatSolicitudCiudadano.searchcatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catSolicitudCiudadano del sistema</summary>
        public ENTResponse searchcatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitudCiudadano datacatSolicitudCiudadano = new DASolicitudCiudadano();
                oENTResponse = datacatSolicitudCiudadano.searchcatSolicitudCiudadano(entSolicitudCiudadano);
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
        ///   <name>BPcatSolicitudCiudadanoinsertcatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catSolicitudCiudadano del sistema</summary>
        public ENTResponse insertcatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitudCiudadano datacatSolicitudCiudadano = new DASolicitudCiudadano();
                oENTResponse = datacatSolicitudCiudadano.searchcatSolicitudCiudadano(entSolicitudCiudadano);
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
        ///   <name>BPcatSolicitudCiudadanoupdatecatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catSolicitudCiudadano del sistema</summary>
        public ENTResponse updatecatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitudCiudadano datacatSolicitudCiudadano = new DASolicitudCiudadano();
                oENTResponse = datacatSolicitudCiudadano.searchcatSolicitudCiudadano(entSolicitudCiudadano);
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
        ///   <name>BPcatSolicitudCiudadanodeletecatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catSolicitudCiudadano del sistema</summary>
        public ENTResponse deletecatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DASolicitudCiudadano datacatSolicitudCiudadano = new DASolicitudCiudadano();
                oENTResponse = datacatSolicitudCiudadano.searchcatSolicitudCiudadano(entSolicitudCiudadano);
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
    }
}
