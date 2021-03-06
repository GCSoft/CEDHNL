﻿using System;
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
    public class DATipoOrientacion : DABase
    {
        protected int _ErrorId;

        protected string _ErrorDescription;

        /// <summary>
        ///     Número de error ocurrido. Cero por default//
        /// </summary>
        public int ErrorId//
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        /// <summary>
        ///     Descripción del error ocurrido
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        public DataSet SelectTipoOrientacion(ENTTipoOrientacion ENTTipoOrientacion, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("sptblTipoOrientacion_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("TipoOrientacionId", SqlDbType.Int);
                Parameter.Value = ENTTipoOrientacion.TipoOrientacionId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTTipoOrientacion.Nombre;
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
    }
}
