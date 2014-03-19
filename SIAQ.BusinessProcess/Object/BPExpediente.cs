// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPExpediente : BPBase
    {
        ///<remarks>
        ///   <name>BPExpediente.searchcatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener el Expediente del sistema</summary>
        public ENTResponse searchExpediente(ENTExpediente oENTExpediente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAExpediente oDAExpediente = new DAExpediente();
                oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
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
        ///   <name>BPExpediente.searchExpedienteDetalle</name>
        ///   <create>14/Marzo/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener el detalle del expediente del sistema</summary>
        public ENTResponse searchExpedienteDetalle(ENTExpediente oENTExpediente)
        {
            DAExpediente oDAExpediente = new DAExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Consulta a base de datos
                oENTResponse = oDAExpediente.searchExpedienteDetalle(oENTExpediente);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }

            }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }

            // Resultado
            return oENTResponse;

        }
        ///<remarks>
        ///   <name>BPExpediente.insertcatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar Expediente del sistema</summary>
        public ENTResponse insertExpediente(ENTExpediente oENTExpediente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAExpediente oDAExpediente = new DAExpediente();
                oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
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
        ///   <name>BPExpediente.updatecatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Expediente del sistema</summary>
        public ENTResponse updateExpediente(ENTExpediente oENTExpediente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAExpediente oDAExpediente = new DAExpediente();
                oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
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
        ///   <name>BPExpediente.deletecatTipoSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de Expediente del sistema</summary>
        public ENTResponse deleteExpediente(ENTExpediente oENTExpediente)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAExpediente oDAExpediente = new DAExpediente();
                oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
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
