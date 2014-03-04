using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAFormaContacto : DABase
    {

        protected int _ErrorId;
        protected string _ErrorDescription;

        public DataSet SelectFormaContacto(ENTFormaContacto ENTFormaContacto, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("sptblFormaContacto_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("FormaContactoId", SqlDbType.Int);
                Parameter.Value = ENTFormaContacto.FormaDeContactoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTFormaContacto.Nombre;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);
                ResultData = new DataSet();

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
    }
}
