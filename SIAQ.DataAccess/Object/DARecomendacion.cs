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

        public DataSet SelectDetalleRecomendacion(ENTRecomendacion entRecomendacion, string connectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(connectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spSelectDetalleRecomendacionDirector", Connection);
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

        #endregion

    }
}
