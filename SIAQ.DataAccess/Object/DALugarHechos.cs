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
    public class DALugarHechos : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        /// <summary>
        ///     Número de error, en caso de que haya ocurrido uno. Cero por default.
        /// </summary>
        public int ErrorId
        {
            get { return _ErrorId; }
        }

        /// <summary>
        ///     Descripción de error, en caso de que haya ocurrido uno. Empty por default.
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
        }

        public DALugarHechos()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAcatLugarHechos.deletecatLugarHechos</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catLugarHechos del sistema</summary>
        public ENTResponse deletecatLugarHechos(ENTLugarHechos entLugarHechos)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catLugarHechosDel");
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
        ///   <name>DAcatLugarHechos.insertcatLugarHechos</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catLugarHechos del sistema</summary>
        public ENTResponse insertcatLugarHechos(ENTLugarHechos entLugarHechos)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatLugarHechos_Ins", entLugarHechos.Descripcion, entLugarHechos.Nombre);
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

        /// <summary>
        ///     Busca la información de los lugares de los hechos en donde ocurrieron las violaciones a los derechos humanos.
        /// </summary>
        /// <param name="HechosEntity">Entidad del lugar de los hechos.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        /// <returns>Resultado de la búsqueda.</returns>
        public DataSet SelectLugarHechos(ENTLugarHechos LugarEntity, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("SelectLugarHechos", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("LugarHechosId", SqlDbType.Int);
                Parameter.Value = LugarEntity.LugarHechosId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

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

        
        public ENTResponse SelectcatLugarHechos(ENTLugarHechos LugarEntity, string ConnectionString)
        {
            
            SqlConnection sqlCnn = new SqlConnection(ConnectionString);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            sqlCom = new SqlCommand("uspcatLugarHechos_Sel", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlPar = new SqlParameter("LugarHechosId", SqlDbType.Int);
            sqlPar.Value = LugarEntity.LugarHechosId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
            sqlPar.Value = LugarEntity.Nombre;
            sqlCom.Parameters.Add(sqlPar);

            oENTResponse.dsResponse = new DataSet();
            sqlAdapter = new SqlDataAdapter(sqlCom);

            try
            {
                sqlCnn.Open();
                sqlAdapter.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();

            }
            catch (SqlException sqlException) { oENTResponse.ExceptionRaised(sqlException.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally {
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAcatLugarHechos.updatecatLugarHechos</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catLugarHechos del sistema</summary>
        public ENTResponse updatecatLugarHechos(ENTLugarHechos oENTLugarHechos)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatLugarHechos_Upd", oENTLugarHechos.LugarHechosId, oENTLugarHechos.Descripcion, oENTLugarHechos.Nombre);
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
