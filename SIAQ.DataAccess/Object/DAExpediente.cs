// Referencias
using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

// Referencias manuales
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAExpediente : DABase
    {
        Database dbs;
        protected int _ErrorId;
        protected string _ErrorDescription;

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

        public DAExpediente()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DASolicitud.AprobarResolucionTitular</name>
        ///   <create>02/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Aprueba resolución de expediente 
        /// </summary>
        public ENTResponse AprobarResolucionTitular(ENTExpediente oENTExpediente, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spAprobarResolucionTitular_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException ex) { oENTResponse.ExceptionRaised(ex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DASolicitud.DeleteAutoridad_Expediente</name>
        ///   <create>24/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Elimina autoridades de un expediente en específico
        /// </summary>
        public ENTResponse DeleteAutoridad_Expediente(ENTExpediente oENTExpediente, string sConnectionString, int iAlternativeTimeOut)
        {
            //Declaración
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            //Coniguración de objetos
            Command = new SqlCommand("spVisitExpedienteAutoridad_del", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            //TimeOut
            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            //Parametros 
            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.AutoridadId;
            Command.Parameters.Add(Parameter);

            //Inicializadores 
            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            //Transacción
            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException sqlex) { oENTResponse.ExceptionRaised(sqlex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAExpediente.deleteExpediente</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar los Expedientes del sistema</summary>
        public ENTResponse deleteExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel");
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
        ///   <name>DAExpediente.insertExpediente</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar los Expedientes del sistema</summary>
        public ENTResponse insertExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel");
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
        ///   <name>DASolicitud.RechazarResolucionTitular</name>
        ///   <create>01/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Rechaza resolución de expediente 
        /// </summary>
        public ENTResponse RechazarResolucionTitular(ENTExpediente oENTExpediente, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spRechazarResolucionTitular_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException ex) { oENTResponse.ExceptionRaised(ex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return oENTResponse;

        }

        ///<remarks>
        ///   <name>DASolicitud.SelectAutoridadesGrid</name>
        ///   <create>23/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene las autoridades relacionados al expediente 
        /// </summary>
        public DataSet SelectAutoridadesGrid(ENTExpediente ENTExpediente, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spAutoridadVisit_sel_grid", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("ExpedienteId", DbType.Int32);
                Parameter.Value = ENTExpediente.ExpedienteId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ResultData);
                Connection.Close();

                return ResultData;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ResultData;
            }
        }

        ///<remarks>
        ///   <name>DAExpediente.updateExpediente</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para actualizar los Expedientes del sistema</summary>
        public ENTResponse updateExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel");
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
        ///     Actualiza el estatus de un expediente.
        /// </summary>
        /// <param name="ExpedienteEntity">Entidad del expediente.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        public void UpdateExpedienteEstatus(ENTExpediente ExpedienteEntity, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlCommand Command;
            SqlParameter Parameter;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                Command = new SqlCommand("UpdateExpedienteEstatus", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                Parameter.Value = ExpedienteEntity.ExpedienteId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("EstatusId", SqlDbType.Int);
                Parameter.Value = ExpedienteEntity.EstatusId;
                Command.Parameters.Add(Parameter);

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorDescription = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        /// <summary>
        ///     Actualiza el estatus de un expediente.
        /// </summary>
        /// <param name="ExpedienteEntity">Entidad del expediente.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        public void UpdateExpedienteEstatus(SqlConnection Connection, SqlTransaction Transaction, ENTExpediente ExpedienteEntity)
        {
            DataSet ResultData = new DataSet();
            SqlCommand Command;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("UpdateExpedienteEstatus", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Transaction = Transaction;

                Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                Parameter.Value = ExpedienteEntity.ExpedienteId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("EstatusId", SqlDbType.Int);
                Parameter.Value = ExpedienteEntity.EstatusId;
                Command.Parameters.Add(Parameter);

                Command.ExecuteNonQuery();
            }
            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorDescription = Exception.Message;
            }
        }

        ///<remarks>
        ///   <name>DASolicitud.UpdateObservaciones_Expediente</name>
        ///   <create>24/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Modifica la observación de un expediente en específico
        /// </summary>
        public ENTResponse UpdateObservaciones_Expediente(ENTExpediente oENTExpediente, string sConnectionString, int iAlternativeTimeOut)
        {
            //Declaración
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            //Configuracion
            Command = new SqlCommand("spVisitObservacionesExp_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            //Timeout 
            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            //Parametros 
            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Observaciones", SqlDbType.VarChar);
            Parameter.Value = oENTExpediente.Observaciones;
            Command.Parameters.Add(Parameter);

            //Inicializador 
            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            //Transacción 
            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException sqlex) { oENTResponse.ExceptionRaised(sqlex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return oENTResponse;
        }
    }
}
