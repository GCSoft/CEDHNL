using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAExpedienteSeguimiento : DABase
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
        public DAExpedienteSeguimiento()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
        }

        #region "Method"
            /// <summary>
            ///     Elimina un registro de seguimiento del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad del seguimiento del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void DeleteExpedienteSeguimiento(ENTExpedienteSeguimiento ExpedienteSeguimientoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("DeleteExpedienteSeguimiento", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteSeguimientoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteSeguimientoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteId;
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
            ///     Guarda un registro nuevo de seguimiento del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad del seguimiento del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void InsertExpedienteSeguimiento(ENTExpedienteSeguimiento ExpedienteSeguimientoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("InsertExpedienteSeguimiento", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.FuncionarioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoSeguimientoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.TipoSeguimientoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Fecha", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteSeguimientoEntity.Fecha;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteSeguimientoEntity.Detalle;
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
            ///     Realiza una búsqueda de los seguimientos de un expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad del seguimiento del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            /// <returns>Resultado de la búsqueda.</returns>
            public DataSet SelectExpedienteSeguimiento(ENTExpedienteSeguimiento ExpedienteSeguimientoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlConnection Connection = new SqlConnection(ConnectionString);
                SqlCommand Command;
                SqlParameter Parameter;
                SqlDataAdapter DataAdapter;

                try
                {
                    Command = new SqlCommand("SelectExpedienteSeguimiento", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteSeguimientoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteSeguimientoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteId;
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
            ///     Actualiza un registro de un seguimiento del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad del seguimiento del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void UpdateExpedienteSeguimiento(ENTExpedienteSeguimiento ExpedienteSeguimientoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("UpdateExpedienteSeguimiento", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteSeguimientoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoSeguimientoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteSeguimientoEntity.TipoSeguimientoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Fecha", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteSeguimientoEntity.Fecha;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteSeguimientoEntity.Detalle;
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
        #endregion
    }
}
