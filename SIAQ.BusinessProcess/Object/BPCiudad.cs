using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPCiudad : BPBase
    {

        protected ENTCiudad _CiudadEntity;

        public ENTCiudad EstadoCiudad
        {
            get { return _CiudadEntity; }
            set { _CiudadEntity = value; }
        }

        public BPCiudad()
        {

            _CiudadEntity = new ENTCiudad();
        }

        public DataSet SelectCiudad()
        {
            string ConnectionString = string.Empty;
            DACiudad DACiudad = new DACiudad();

            ConnectionString = sConnectionApplication;
            _CiudadEntity.ResultData = DACiudad.SelectCiudad(_CiudadEntity, ConnectionString);
            return _CiudadEntity.ResultData;
        }
        ///<remarks>
        ///   <name>BPcatCiudad.searchcatCiudad</name>
        ///   <create>27/ene/2014 </create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCiudad del sistema</summary>
        public ENTResponse searchcatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.searchcatCiudad(entCiudad);
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
        ///   <name>BPcatCiudadinsertcatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catCiudad del sistema</summary>
        public ENTResponse insertcatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.searchcatCiudad(entCiudad);
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
        ///   <name>BPcatCiudadupdatecatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCiudad del sistema</summary>
        public ENTResponse updatecatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.searchcatCiudad(entCiudad);
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
        ///   <name>BPcatCiudaddeletecatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catCiudad del sistema</summary>
        public ENTResponse deletecatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.searchcatCiudad(entCiudad);
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
