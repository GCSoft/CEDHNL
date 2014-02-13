using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPColonia : BPBase
    {

        protected ENTColonia _ColoniaEntity;

        public ENTColonia EstadoColonia
        {
            get { return _ColoniaEntity; }
            set { _ColoniaEntity = value; }
        }

        public BPColonia()
        {

            _ColoniaEntity = new ENTColonia();
        }

        public DataSet SelectColonia()
        {
            string ConnectionString = string.Empty;
            DAColonia DAColonia = new DAColonia();

            ConnectionString = sConnectionApplication;
            _ColoniaEntity.ResultData = DAColonia.SelectColonia(_ColoniaEntity, ConnectionString);
            return _ColoniaEntity.ResultData;
        }
        ///<remarks>
        ///   <name>BPcatColonia.searchcatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catColonia del sistema</summary>
        public ENTResponse searchcatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.searchcatColonia(entColonia);
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
        ///   <name>BPcatColoniainsertcatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catColonia del sistema</summary>
        public ENTResponse insertcatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.searchcatColonia(entColonia);
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
        ///   <name>BPcatColoniaupdatecatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catColonia del sistema</summary>
        public ENTResponse updatecatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.searchcatColonia(entColonia);
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
        ///   <name>BPcatColoniadeletecatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catColonia del sistema</summary>
        public ENTResponse deletecatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.searchcatColonia(entColonia);
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
