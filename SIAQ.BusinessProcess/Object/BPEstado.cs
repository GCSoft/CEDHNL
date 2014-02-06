using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPEstado : BPBase
    {
        protected ENTEstado _EstadoEntity;

        public ENTEstado EstadoEntity
        {
            get { return _EstadoEntity; }
            set { _EstadoEntity = value; }
        }

        public BPEstado()
        {

            _EstadoEntity = new ENTEstado();
        }

        public DataSet SelectEstado()
        {
            string ConnectionString = string.Empty;
            DAEstado DAEstado = new DAEstado();

            ConnectionString = sConnectionApplication;
            _EstadoEntity.ResultData = DAEstado.SelectEstado(_EstadoEntity, ConnectionString);
            return _EstadoEntity.ResultData;
        }
        ///<remarks>
        ///   <name>BPcatEstado.searchcatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstado del sistema</summary>
        public ENTResponse searchcatEstado(ENTEstado entEstado)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstado datacatEstado = new DAEstado();
                oENTResponse = datacatEstado.searchcatEstado(entEstado);
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
        ///   <name>BPcatEstadoinsertcatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catEstado del sistema</summary>
        public ENTResponse insertcatEstado(ENTEstado entEstado)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstado datacatEstado = new DAEstado();
                oENTResponse = datacatEstado.searchcatEstado(entEstado);
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
        ///   <name>BPcatEstadoupdatecatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catEstado del sistema</summary>
        public ENTResponse updatecatEstado(ENTEstado entEstado)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstado datacatEstado = new DAEstado();
                oENTResponse = datacatEstado.searchcatEstado(entEstado);
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
        ///   <name>BPcatEstadodeletecatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catEstado del sistema</summary>
        public ENTResponse deletecatEstado(ENTEstado entEstado)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstado datacatEstado = new DAEstado();
                oENTResponse = datacatEstado.searchcatEstado(entEstado);
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
