using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoEstatus : BPBase
    {
        ///<remarks>
        ///   <name>BPcatTipoEstatus.searchcatTipoEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catTipoEstatus del sistema</summary>
        public ENTResponse searchcatTipoEstatus(ENTTipoEstatus entTipoEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoEstatus datacatTipoEstatus = new DATipoEstatus();
                oENTResponse = datacatTipoEstatus.searchcatTipoEstatus(entTipoEstatus);
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
        ///   <name>BPcatTipoEstatusinsertcatTipoEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catTipoEstatus del sistema</summary>
        public ENTResponse insertcatTipoEstatus(ENTTipoEstatus entTipoEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoEstatus datacatTipoEstatus = new DATipoEstatus();
                oENTResponse = datacatTipoEstatus.searchcatTipoEstatus(entTipoEstatus);
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
        ///   <name>BPcatTipoEstatusupdatecatTipoEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catTipoEstatus del sistema</summary>
        public ENTResponse updatecatTipoEstatus(ENTTipoEstatus entTipoEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoEstatus datacatTipoEstatus = new DATipoEstatus();
                oENTResponse = datacatTipoEstatus.searchcatTipoEstatus(entTipoEstatus);
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
        ///   <name>BPcatTipoEstatusdeletecatTipoEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catTipoEstatus del sistema</summary>
        public ENTResponse deletecatTipoEstatus(ENTTipoEstatus entTipoEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DATipoEstatus datacatTipoEstatus = new DATipoEstatus();
                oENTResponse = datacatTipoEstatus.searchcatTipoEstatus(entTipoEstatus);
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
