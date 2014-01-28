using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoCiudadano : BPBase
    {
        ///<remarks>
        ///   <name>BPcatTipoCiudadano.searchcatTipoCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTipoCiudadano del sistema</summary>
        public ENTResponse searchcatTipoCiudadano(ENTTipoCiudadano entTipoCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoCiudadano datacatTipoCiudadano = new DATipoCiudadano();
                oENTResponse = datacatTipoCiudadano.searchcatTipoCiudadano(entTipoCiudadano);
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
        ///   <name>BPcatTipoCiudadanoinsertcatTipoCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTipoCiudadano del sistema</summary>
        public ENTResponse insertcatTipoCiudadano(ENTTipoCiudadano entTipoCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoCiudadano datacatTipoCiudadano = new DATipoCiudadano();
                oENTResponse = datacatTipoCiudadano.searchcatTipoCiudadano(entTipoCiudadano);
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
        ///   <name>BPcatTipoCiudadanoupdatecatTipoCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTipoCiudadano del sistema</summary>
        public ENTResponse updatecatTipoCiudadano(ENTTipoCiudadano entTipoCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoCiudadano datacatTipoCiudadano = new DATipoCiudadano();
                oENTResponse = datacatTipoCiudadano.searchcatTipoCiudadano(entTipoCiudadano);
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
        ///   <name>BPcatTipoCiudadanodeletecatTipoCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTipoCiudadano del sistema</summary>
        public ENTResponse deletecatTipoCiudadano(ENTTipoCiudadano entTipoCiudadano)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoCiudadano datacatTipoCiudadano = new DATipoCiudadano();
                oENTResponse = datacatTipoCiudadano.searchcatTipoCiudadano(entTipoCiudadano);
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
