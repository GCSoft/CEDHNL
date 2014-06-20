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
    public class DARecomendacion : DABase
    {

        #region Atributos

        protected int _ErrorId;
        protected string _ErrorString;
        Database dbs;

        #endregion

        #region Propiedades

        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        public string ErrorDescription
        {
            get { return _ErrorString; }
            set { _ErrorString = value; }
        }

        #endregion

        #region Funciones

        public DARecomendacion()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        /// <summary>
        ///     Guarda un registro nuevo de recomendación del expediente.
        /// </summary>
        /// <param name="RecomendacionEntity">Entidad de la comparecencia del expediente.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        public void InsertRecomendacion(ENTRecomendacion RecomendacionEntity, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlCommand Command;
            SqlParameter Parameter;
            SqlConnection Connection = new SqlConnection(ConnectionString);

            try
            {
                Command = new SqlCommand("InsertRecomendacion", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                Parameter.Value = RecomendacionEntity.ExpedienteId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("EstatusId", SqlDbType.Int);
                Parameter.Value = RecomendacionEntity.EstatusId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Numero", SqlDbType.VarChar);
                Parameter.Value = RecomendacionEntity.Numero;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Observaciones", SqlDbType.VarChar);
                Parameter.Value = RecomendacionEntity.Observaciones;
                Command.Parameters.Add(Parameter);

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorString = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectListadoCiudadanosRecomendacion</name>
        ///<create>07/mar/2014</create>
        ///<author>Generator</author>
        ///</remarks>
        /// <summary>
        /// Metodo para obtener los ciudadanos que tienen que ver con una recomendacion especifica
        /// </summary>
        public DataSet SelectListadoCiudadanosRecomendacion(ENTRecomendacion entRecomendacion, string connectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spSelectCiudadanoRecomendacion", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
                Parameter.Value = entRecomendacion.RecomendacionId;
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
                _ErrorString = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectDetalleRecomendacion</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene el detalle de la recomendación
        /// </summary>
        public DataSet SelectDetalleRecomendacion(ENTRecomendacion entRecomendacion, string connectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spDetalleRecomendacion_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
                Parameter.Value = entRecomendacion.RecomendacionId;
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
                _ErrorString = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectListadoAutoridadesRecomendacion</name>
        ///<create>07/mar/2014</create>
        ///<author>Generator</author>
        ///</remarks>
        /// <summary>
        /// Obtiene la lista de autoridades para una recomendacion especifica
        /// </summary>
        public DataSet SelectListadoAutoridadesRecomendacion(ENTRecomendacion entRecomendacion, string connectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spSelectAutoridadRecomendacion", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
                Parameter.Value = entRecomendacion.RecomendacionId;
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
                _ErrorString = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }

        }

        /// <summary>
        ///     Busca el siguiente número de folio para una recomendación.
        /// </summary>
        /// <param name="RecomendacionEntity">Entidad de la recomendación del expediente.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        /// <returns>Resultado de la búsqueda.</returns>
        public DataSet SelectNextFolio(ENTRecomendacion RecomendacionEntity, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("SelectNextFolio", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("Anio", SqlDbType.SmallInt);
                Parameter.Value = RecomendacionEntity.Anio;
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
                _ErrorString = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                return ResultData;
            }
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectRecomendacionGrid</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Muestra las recomendaciones para llenado de grid
        /// </summary>
        public DataSet SelectRecomendacionGrid(string connectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spDetalleRecomendacion_selGrid", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }

            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorString = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }
        }

        ///<remarks>
        ///<name>DASeguimiento.SelectFuncionariosAsignarCombo</name>
        ///<create>19/mar/2014</create>
        ///<author>Jose.gomez</author>
        ///</remarks>
        /// <summary>
        /// Obtiene los funcionarios a los que se van a asignar la recomendacion
        /// </summary>
        public DataSet SelectFuncionariosAsignarCombo(ENTRecomendacion ENTRecomendacionEntity, string connectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connexion = new SqlConnection(connectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spDefRecomendacion_sel_cmb", Connexion);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("RecomendacionId", DbType.Int32);
                Parameter.Value = ENTRecomendacionEntity.RecomendacionId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connexion.Open();
                DataAdapter.Fill(ds);
                Connexion.Close();

                return ds;
            }

            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorString = ex.Message;

                if (Connexion.State == ConnectionState.Open)
                {
                    Connexion.Close();
                }

                return ds;
            }
        }

        #endregion

    }
}
