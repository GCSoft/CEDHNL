using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoSolicitud : BPBase
    {
        ///<remarks>
        ///   <name>BPcatTipoSolicitud.searchcatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTipoSolicitud del sistema</summary>
        public ENTResponse searchcatTipoSolicitud(ENTTipoSolicitud entTipoSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoSolicitud datacatTipoSolicitud = new DATipoSolicitud();
                oENTResponse = datacatTipoSolicitud.searchcatTipoSolicitud(entTipoSolicitud);
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
        ///   <name>BPcatTipoSolicitudinsertcatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTipoSolicitud del sistema</summary>
        public ENTResponse insertcatTipoSolicitud(ENTTipoSolicitud entTipoSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoSolicitud datacatTipoSolicitud = new DATipoSolicitud();
                oENTResponse = datacatTipoSolicitud.searchcatTipoSolicitud(entTipoSolicitud);
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
        ///   <name>BPcatTipoSolicitudupdatecatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTipoSolicitud del sistema</summary>
        public ENTResponse updatecatTipoSolicitud(ENTTipoSolicitud entTipoSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoSolicitud datacatTipoSolicitud = new DATipoSolicitud();
                oENTResponse = datacatTipoSolicitud.searchcatTipoSolicitud(entTipoSolicitud);
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
        ///   <name>BPcatTipoSolicituddeletecatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTipoSolicitud del sistema</summary>
        public ENTResponse deletecatTipoSolicitud(ENTTipoSolicitud entTipoSolicitud)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoSolicitud datacatTipoSolicitud = new DATipoSolicitud();
                oENTResponse = datacatTipoSolicitud.searchcatTipoSolicitud(entTipoSolicitud);
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
