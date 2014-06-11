using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAExpedienteComparecencia : DABase
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
        public DAExpedienteComparecencia()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
        }

        #region "Method"
            /// <summary>
            ///     Elimina un registro de comparecencia del expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad de la comparecencia del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void DeleteExpedienteComparecencia(ENTExpedienteComparecencia ExpedienteComparecenciaEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("DeleteExpedienteComparecencia", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteId;
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
            public void InsertExpedienteComparecencia(ENTExpedienteComparecencia ExpedienteComparecenciaEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("InsertExpedienteComparecencia", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.FuncionarioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.CiudadanoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("LugarComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.LugarComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.TipoComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Asunto", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteComparecenciaEntity.Asunto;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteComparecenciaEntity.Detalle;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Fecha", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteComparecenciaEntity.Fecha;
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
            ///     Realiza una búsqueda de las comparecencias de un expediente.
            /// </summary>
            /// <param name="ExpedienteSeguimientoEntity">Entidad del seguimiento del expediente.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            /// <returns>Resultado de la búsqueda.</returns>
            public DataSet SelectExpedienteComparecencia(ENTExpedienteComparecencia ExpedienteComparecenciaEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlConnection Connection = new SqlConnection(ConnectionString);
                SqlCommand Command;
                SqlParameter Parameter;
                SqlDataAdapter DataAdapter;

                try
                {
                    Command = new SqlCommand("SelectExpedienteComparecencia", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteId;
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
            public void UpdateExpedienteComparecencia(ENTExpedienteComparecencia ExpedienteComparecenciaEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("UpdateExpedienteComparecencia", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("ExpedienteComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.ExpedienteId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.FuncionarioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.CiudadanoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("LugarComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.LugarComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoComparecenciaId", SqlDbType.Int);
                    Parameter.Value = ExpedienteComparecenciaEntity.TipoComparecenciaId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Asunto", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteComparecenciaEntity.Asunto;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteComparecenciaEntity.Detalle;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Fecha", SqlDbType.VarChar);
                    Parameter.Value = ExpedienteComparecenciaEntity.Fecha;
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
