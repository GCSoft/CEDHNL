using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPFuncionario : BPBase
    {
        /*       protected ENTArea _AreaEntity;

       public ENTArea Area
       {
           get { return _AreaEntity; }
           set { _AreaEntity = value; }
       }

       public BPArea()
       {
           _AreaEntity = new ENTArea();
       }

       public DataSet SelectArea()
       {
           string ConnectionString = string.Empty;
           DAArea DAArea = new DAArea();
           ConnectionString = sConnectionApplication;
           _AreaEntity.ResultData = DAArea.SelectArea(_AreaEntity, ConnectionString);
           return _AreaEntity.ResultData;
       }*/
        protected ENTFuncionario _FuncionarioEntity;

        public ENTFuncionario Funcionario
        {
            get { return _FuncionarioEntity; }
            set { _FuncionarioEntity = value; }
        }

        public DataSet SelectFuncionario()
        {
            string ConnectionString = string.Empty;
            DAFuncionario DAFuncionario = new DAFuncionario();
            ConnectionString = sConnectionApplication;
            _FuncionarioEntity.ResultData = DAFuncionario.SelectFuncionario(_FuncionarioEntity, ConnectionString);
            return _FuncionarioEntity.ResultData;
        }
        ///<remarks>
        ///   <name>BPFuncionario.searchFuncionario</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las Funcionario del sistema</summary>
        public ENTResponse searchFuncionario(ENTFuncionario entFuncionario)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAFuncionario dataFuncionario = new DAFuncionario();
                oENTResponse = dataFuncionario.searchFuncionario(entFuncionario);
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
        ///   <name>BPFuncionarioinsertFuncionario</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar Funcionario del sistema</summary>
        public ENTResponse insertFuncionario(ENTFuncionario entFuncionario)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAFuncionario dataFuncionario = new DAFuncionario();
                oENTResponse = dataFuncionario.searchFuncionario(entFuncionario);
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
        ///   <name>BPFuncionarioupdateFuncionario</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Funcionario del sistema</summary>
        public ENTResponse updateFuncionario(ENTFuncionario entFuncionario)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAFuncionario dataFuncionario = new DAFuncionario();
                oENTResponse = dataFuncionario.searchFuncionario(entFuncionario);
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
        ///   <name>BPFuncionariodeleteFuncionario</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de Funcionario del sistema</summary>
        public ENTResponse deleteFuncionario(ENTFuncionario entFuncionario)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAFuncionario dataFuncionario = new DAFuncionario();
                oENTResponse = dataFuncionario.searchFuncionario(entFuncionario);
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
