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
			
		

			

		///<remarks>
			///   <name>DASeguimientoRecomendacion.InsertRecomendacionGestion</name>
			///   <create>06-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Inserta un nuevo seguimiento a una recomendación</summary>
			///<param name="entRecomendacion">Entidad de Seguimiento con los parámetros necesarios para consultar el expediente</param>
			///<param name="ConnectionString">Cadena de conexión a la base de datos</param>
			///<returns>Una DataSet con información de la transacción</returns>
			public DataSet InsertRecomendacionGestion(ENTSeguimientoRecomendacion entRecomendacion, string ConnectionString){
				DataSet ds = new DataSet();
				SqlConnection Connection = new SqlConnection(ConnectionString);
				SqlCommand Command;
				SqlDataAdapter DataAdapter;
				SqlParameter Parameter;

				try
				{
					Command = new SqlCommand("uspRecomendacionGestion_Ins", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
					Parameter.Value = entRecomendacion.RecomendacionId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("TipoSeguimientoId", SqlDbType.Int);
					Parameter.Value = entRecomendacion.TipoSeguimientoId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
					Parameter.Value = entRecomendacion.FuncionarioId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("Comentario", SqlDbType.VarChar);
					Parameter.Value = entRecomendacion.Comentario;
					Command.Parameters.Add(Parameter);

					DataAdapter = new SqlDataAdapter(Command);

					Connection.Open();
					DataAdapter.Fill(ds);
					Connection.Close();

					return ds;

				}catch (SqlException ex){

					_ErrorId = ex.Number;
					_ErrorDescription = ex.Message;

					if (Connection.State == ConnectionState.Open) { Connection.Close(); }

					return ds;
				}
			}

			
			
			

        #endregion

     

    }
}
