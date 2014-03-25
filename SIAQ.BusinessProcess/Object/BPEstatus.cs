using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPEstatus : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTEstatus _EstatusEntity;

        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        public ENTEstatus EstatusEntity
        {
            get { return _EstatusEntity; }
            set { _EstatusEntity = value; }
        }

        ///<remarks>
        ///   <name>BPcatEstatus.searchcatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstatus del sistema</summary>
        public ENTResponse searchcatEstatus(ENTEstatus entEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstatus datacatEstatus = new DAEstatus();
                oENTResponse = datacatEstatus.searchcatEstatus(entEstatus);
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
        ///   <name>BPcatEstatusinsertcatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catEstatus del sistema</summary>
        public ENTResponse insertcatEstatus(ENTEstatus entEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstatus datacatEstatus = new DAEstatus();
                oENTResponse = datacatEstatus.searchcatEstatus(entEstatus);
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
        ///   <name>BPcatEstatusupdatecatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catEstatus del sistema</summary>
        public ENTResponse updatecatEstatus(ENTEstatus entEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstatus datacatEstatus = new DAEstatus();
                oENTResponse = datacatEstatus.searchcatEstatus(entEstatus);
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
        ///   <name>BPcatEstatusdeletecatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catEstatus del sistema</summary>
        public ENTResponse deletecatEstatus(ENTEstatus entEstatus)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAEstatus datacatEstatus = new DAEstatus();
                oENTResponse = datacatEstatus.searchcatEstatus(entEstatus);
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
        ///   <name>selectEstatusVisitaduria</name>
        ///   <create>25/MAR/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener los estatus de visitadurías de catEstatus del sistema</summary>
        public void selectEstatusVisitaduria()
        {
            _EstatusEntity = new ENTEstatus();

            string ConnectionString = string.Empty;
            DAEstatus DAEstatus = new DAEstatus();

            ConnectionString = sConnectionApplication;

            _EstatusEntity.ResultData = DAEstatus.selectEstatusVisitaduria(ConnectionString);
            _ErrorId = DAEstatus.ErrorId;
            _ErrorDescription = DAEstatus.ErrorDescription;
        }
    }
}
