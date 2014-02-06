using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;
namespace SIAQ.DataAccess.Object
{
    public class DAEstado : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;
        public DAEstado()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>DAcatEstado.searchcatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstado del sistema</summary>
        public ENTResponse searchcatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catEstadoSel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }
        ///<remarks>
        ///   <name>DAcatEstado.insertcatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catEstado del sistema</summary>
        public ENTResponse insertcatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catEstadoIns");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }
        ///<remarks>
        ///   <name>DAcatEstado.updatecatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catEstado del sistema</summary>
        public ENTResponse updatecatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catEstadoUpd");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }


        public DataSet SelectEstado(ENTEstado ENTEstado, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("sptblEstado_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("EstadoId", SqlDbType.Int);
                Parameter.Value = ENTEstado.EstadoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTEstado.Nombre;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);
                ResultData = new DataSet();

                Connection.Open();
                DataAdapter.Fill(ResultData);
                Connection.Close();

                return ResultData;
            }
            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorDescription = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                return ResultData;
            }
        }
        ///<remarks>
        ///   <name>DAcatEstado.deletecatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catEstado del sistema</summary>
        public ENTResponse deletecatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catEstadoDel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }
    }
}
