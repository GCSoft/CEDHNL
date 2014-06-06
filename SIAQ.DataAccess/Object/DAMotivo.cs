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
    public class DAMotivo : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;
        public DAMotivo()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAMotivo.insertMotivo</name>
        ///   <create>05/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las DAMotivo del sistema</summary>
        public DataSet SelectMotivo(ENTMotivo ENTMotivo, string ConnectionString)
        {

            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("uspcatMotivo_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("MotivoId", SqlDbType.Int);
                Parameter.Value = ENTMotivo.MotivoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTMotivo.Nombre;
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
        ///   <name>DAMotivo.searchcatMotivo</name>
        ///   <create>05/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las DAMotivo del sistema</summary>
        public ENTResponse searchcatMotivo(ENTMotivo ENTMotivo, string ConnectionString)
        {

            SqlConnection sqlCnn = new SqlConnection(ConnectionString);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                sqlCom = new SqlCommand("uspcatMotivo_Sel", sqlCnn);
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlPar = new SqlParameter("MotivoId", SqlDbType.Int);
                sqlPar.Value = ENTMotivo.MotivoId;
                sqlCom.Parameters.Add(sqlPar);

                sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
                sqlPar.Value = ENTMotivo.Nombre;
                sqlCom.Parameters.Add(sqlPar);

                sqlAdapter = new SqlDataAdapter(sqlCom);
                oENTResponse.dsResponse = new DataSet();

                sqlCnn.Open();
                sqlAdapter.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();


            }
            catch (SqlException sqlEX) { oENTResponse.ExceptionRaised(sqlEX.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally {
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAMotivo.insertcatMedioComunicacion</name>
        ///   <create>05/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo para insertar DAMotivo del sistema</summary>
        public ENTResponse insertMotivo(ENTMotivo oENTMotivo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatMotivo_Ins", oENTMotivo.Descripcion, oENTMotivo.Nombre);
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
        ///   <name>DAMotivo.updateMotivo</name>
        ///   <create>05/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo que actualiza deleteMotivo del sistema</summary>
        public ENTResponse updateMotivo(ENTMotivo oENTMotivo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatMotivo_Upd", oENTMotivo.MotivoId, oENTMotivo.Descripcion, oENTMotivo.Nombre);
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
        ///   <name>DAMotivo.deleteMotivo</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de deleteMotivo del sistema</summary>
        public ENTResponse deletecatMedioComunicacion(ENTMotivo oENTMotivo)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catMedioComunicacionDel");
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
