using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAExpedienteResolucion : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;

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

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public DAExpedienteResolucion()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
        }

        #region "Method"
            /// <summary>
            ///     Elimina un registro de resolucion del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad de la resolucion del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void DeleteExpedienteResolucion(ENTExpedienteResolucion ExpedienteResolucionEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("DeleteExpedienteResolucion", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteResolucionId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteResolucionId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteId;
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
            ///     Guarda un registro nuevo de la resolución del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad de la resolución del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void InsertExpedienteResolucion(SqlConnection Connection, SqlTransaction Transaction, ENTExpedienteResolucion ExpedienteResolucionEntity)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;

                try
                {
                    Command = new SqlCommand("InsertExpedienteResolucion", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Transaction = Transaction;

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.FuncionarioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoResolucionId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.TipoResolucionId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteResolucionEntity.Detalle;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Fecha", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteResolucionEntity.Fecha;
                    Command.Parameters.Add(Parameter);

                    Command.ExecuteNonQuery();
                }
                catch (SqlException Exception)
                {
                    _ErrorId = Exception.Number;
                    _ErrorDescription = Exception.Message;
                }
            }

            /// <summary>
            ///     Realiza una búsqueda de la resolución de un expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad de la resolución del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            /// <returns>Resultado de la búsqueda.</returns>
            public DataSet SelectExpedienteResolucion(ENTExpedienteResolucion ExpedienteResolucionEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlConnection Connection = new SqlConnection(ConnectionString);
                SqlCommand Command;
                SqlParameter Parameter;
                SqlDataAdapter DataAdapter;

                try
                {
                    Command = new SqlCommand("SelectExpedienteResolucion", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteResolucionId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteResolucionId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteId;
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

            /// <summary>
            ///     Actualiza un registro de la resolución del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad de la resolución del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void UpdateExpedienteResolucion(SqlConnection Connection, SqlTransaction Transaction, ENTExpedienteResolucion ExpedienteResolucionEntity)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;

                try
                {
                    Command = new SqlCommand("UpdateExpedienteResolucion", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Transaction = Transaction;

                    Parameter = new SqlParameter("ExpedienteResolucionId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteResolucionId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.FuncionarioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoResolucionId", SqlDbType.Int);
                    Parameter.Value = ExpedienteResolucionEntity.TipoResolucionId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteResolucionEntity.Detalle;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Fecha", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteResolucionEntity.Fecha;
                    Command.Parameters.Add(Parameter);

                    Command.ExecuteNonQuery();
                }
                catch (SqlException Exception)
                {
                    _ErrorId = Exception.Number;
                    _ErrorDescription = Exception.Message;
                }
            }
        #endregion
    }
}
