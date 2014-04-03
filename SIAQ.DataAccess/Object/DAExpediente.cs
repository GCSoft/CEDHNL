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
        ///   <name>DAExpediente.searchcatTipoSolicitud</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener los Expedientes del sistema</summary>
        public ENTResponse searchExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel", oENTExpediente.Numero, oENTExpediente.Ciudadano, oENTExpediente.EstatusId, oENTExpediente.FuncionarioId);
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
        ///   <name>DASolicitud.SelectCiudadanosGrid</name>
        ///   <create>23/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene los ciudadanos relacionados al expediente 
        /// </summary>
        public DataSet SelectCiudadanosGrid(ENTExpediente ENTExpediente, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spCiudadanoVisitaduria_selGrid", Connection);
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
        ///   <name>DASolicitud.SelectDetalleExpediente</name>
        ///   <create>23/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene el detalle del expediente seleccionado
        /// </summary>
        public DataSet SelectDetalleExpediente(ENTExpediente ENTExpediente, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spExpedienteDetalle_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("FuncionarioId", DbType.Int32);
                Parameter.Value = ENTExpediente.FuncionarioId;
                Command.Parameters.Add(Parameter);

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
        ///   <name>DASolicitud.DeleteCiudadano_Expediente</name>
        ///   <create>24/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Elimina ciudadanos de un expediente en específico
        /// </summary>
        public ENTResponse DeleteCiudadano_Expediente(ENTExpediente oENTExpediente, String sConnectionString, int iAlternativeDBTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            //Configuración de objetos 
            Command = new SqlCommand("spVisitExpCiudadano_del", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            //Timeout alternativo en caso de ser solicitud 
            if (iAlternativeDBTimeOut > 0) { Command.CommandTimeout = iAlternativeDBTimeOut; }

            //Parametros 
            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
            Parameter.Value = Convert.ToInt32(oENTExpediente.Ciudadano);
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

            //Resultado 
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

        ///<remarks>
        ///   <name>DASolicitud.AsignarVisitador_Expediente</name>
        ///   <create>27/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Asigna funcionario al expediente
        /// </summary>
        public ENTResponse AsignarVisitador_Expediente(ENTExpediente oENTExpediente, string sConnectionString, int iAlternativeTimeOut)
        {
            //Declaración 
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            //Configuracion 
            Command = new SqlCommand("spAsignarVisitador_ins", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            //TimeOut
            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            //Parametros 
            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.FuncionarioId;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DASolicitud.InsertAcuerdoCalificacionDefinitiva</name>
        ///   <create>28/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Agrega el acuerdo de calificación definitiva
        /// </summary>
        public ENTResponse InsertAcuerdoCalificacionDefinitiva(ENTExpediente oENTExpediente, string sConnectionString, int iAlternativeTimeOut)
        {
            //Declaración 
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            //Configuracion 
            Command = new SqlCommand("spExpedienteCalificacionDefinitiva", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            //TimeOut
            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            //Parametros 
            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
            Parameter.Value = oENTExpediente.FuncionarioId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Acuerdo", SqlDbType.VarChar);
            Parameter.Value = oENTExpediente.Acuerdo;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return oENTResponse;
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
        ///   <name>DASolicitud.SelectExpediente_Funcionario</name>
        ///   <create>25/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene los expedientes asignados a un funcionario en específico
        /// </summary>
        public DataSet SelectExpediente_Funcionario(ENTExpediente oENTExpediente, string sConnectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spExpedienteFuncionario_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
                Parameter.Value = oENTExpediente.FuncionarioId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }
        }

        ///<remarks>
        ///   <name>DASolicitud.SelectFuncionario_Asignar</name>
        ///   <create>26/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene los funcionarios a los cuales se podrán asignar a un expediente
        /// </summary>
        public DataSet SelectFuncionario_Asignar(ENTExpediente oENTExpediente, string sConnectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spExpedienteFuncionariosAsignar_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                Parameter.Value = oENTExpediente.ExpedienteId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }
        }

    }
}
