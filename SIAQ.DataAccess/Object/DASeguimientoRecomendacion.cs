using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.DataAccess.Object
{
    public class DASeguimientoRecomendacion : DABase
    {

        #region Atributos

        protected int _ErrorId;
        protected string _ErrorDescription;
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
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        #endregion

        #region Funciones

        public DASeguimientoRecomendacion()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        /// <remarks>
        /// <name>DASeguimientoRecomendacion.searchListadoRecomendacionDirector</name>
        /// <create>05/mar/2014</create>
        /// <author>Generador</author>
        /// <summary>
        /// Metodo para obtener las recomendaciones asignadas a un director especifico
        /// </summary>
        public DataSet SelectListadoRecomendacionDirector(ENTSeguimientoRecomendacion entFuncionarioId, string ConnectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("spSelectRecomendacionDirector", Connection);
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
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                return ds;
            }
        }

        #endregion

        #region Eventos
        #endregion

    }
}
