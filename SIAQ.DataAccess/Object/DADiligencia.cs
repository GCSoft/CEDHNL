using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DADiligencia : DABase
    {

        #region Atributos

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        #endregion

        #region Propiedades

        public DADiligencia()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

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

        ///<remarks>
        ///   <name>DADiliencia.SelectTipoDiligencias</name>
        ///   <create>30/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona el listado de tipo de diligencias para llenado del combobox</summary>
        public DataSet SelectTipoDiligencias(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spTipoDiligencias_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DADiliencia.SelectLugarDiligencias</name>
        ///   <create>31/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona el listado de los lugares de diligencias para llenado del combobox</summary>
        public DataSet SelectLugarDiligencias(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spLugarDiligencia_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DADiliencia.SelectDiligencias</name>
        ///   <create>31/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el listado de las diligencias de solicitudes, expedientes y recomendaciones</summary>
        public DataSet SelectDiligencias(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spDiligencias_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("Id", SqlDbType.Int);
                Parameter.Value = oENTDiligencia.SolicitudId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return ds;
        }

        #endregion

    }
}
