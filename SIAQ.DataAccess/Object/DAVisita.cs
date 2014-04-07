using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;


namespace SIAQ.DataAccess.Object
{
    public class DAVisita
    {
        protected int _ErrorId;
        protected string _ErrorDescription;

        public DAVisita()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
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
        public void GuardarVisita(ENTVisita ENTVisita, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spGuardarVisita", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("AreaId", SqlDbType.SmallInt);
                Parameter.Value = ENTVisita.AreaId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("FuncionarioId", SqlDbType.SmallInt);
                Parameter.Value = ENTVisita.FuncionarioId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("MotivoId", SqlDbType.SmallInt);
                Parameter.Value = ENTVisita.MotivoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("UsuarioIdInsert", SqlDbType.SmallInt);
                Parameter.Value = ENTVisita.UsuarioIdInsert;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Observaciones", SqlDbType.VarChar);
                Parameter.Value = ENTVisita.Observaciones;
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

        public DataSet SelectVisitaCiudadano(ENTVisita oENTVisita, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spCiudadanoVisitas_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                Parameter.Value = oENTVisita.UsuarioIdInsert;
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
    }
}
