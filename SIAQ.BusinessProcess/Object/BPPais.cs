using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPPais : BPBase
    {
        protected ENTPais _PaisEntity;

        public ENTPais PaisEntity
        {
            get { return _PaisEntity; }
            set { _PaisEntity = value; }
        }

        public BPPais()
        {

            _PaisEntity = new ENTPais();
        }
        ///<remarks>
        ///   <name>BPcatPais.searchcatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catPais del sistema</summary>
        public ENTResponse searchcatPais(ENTPais entPais)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAPais datacatPais = new DAPais();
                oENTResponse = datacatPais.searchcatPais(entPais);
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

        public DataSet SelectPais()
        {
            string ConnectionString = string.Empty;
            DAPais DAPais = new DAPais();

            ConnectionString = sConnectionApplication;
            _PaisEntity.ResultData = DAPais.SelectPais(_PaisEntity, ConnectionString);
            return _PaisEntity.ResultData;
        }

        ///<remarks>
        ///   <name>BPcatPaisinsertcatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catPais del sistema</summary>
        public ENTResponse insertcatPais(ENTPais entPais)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAPais datacatPais = new DAPais();
                oENTResponse = datacatPais.searchcatPais(entPais);
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
        ///   <name>BPcatPaisupdatecatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catPais del sistema</summary>
        public ENTResponse updatecatPais(ENTPais entPais)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAPais datacatPais = new DAPais();
                oENTResponse = datacatPais.searchcatPais(entPais);
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
        ///   <name>BPcatPaisdeletecatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catPais del sistema</summary>
        public ENTResponse deletecatPais(ENTPais entPais)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAPais datacatPais = new DAPais();
                oENTResponse = datacatPais.searchcatPais(entPais);
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