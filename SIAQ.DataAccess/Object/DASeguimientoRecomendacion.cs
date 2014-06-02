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
			///   <name>DASeguimientoRecomendacion.SelectRecomendacionesSeguimientos</name>
			///   <create>30-May-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene un listado de Expedientes en fase de seguimientos con base a los parámetros proporcionados integrando la seguridad del usuario</summary>
			///<param name="entRecomendacion">Entidad de Seguimiento con los parámetros necesarios para consultar la información</param>
			///<param name="ConnectionString">Cadena de conexión a la base de datos</param>
			///<returns>Una entidad de respuesta</returns>
			public DataSet SelectRecomendacionesSeguimientos(ENTSeguimientoRecomendacion entRecomendacion, string ConnectionString){
				DataSet ds = new DataSet();
				SqlConnection Connection = new SqlConnection(ConnectionString);
				SqlCommand Command;
				SqlDataAdapter DataAdapter;
				SqlParameter Parameter;

				try
				{
					Command = new SqlCommand("uspExpediente_Sel_Seguimientos", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("Aprobar", SqlDbType.TinyInt);
					Parameter.Value = entRecomendacion.Aprobar;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("UsuarioId", SqlDbType.Int);
					Parameter.Value = entRecomendacion.UsuarioId;
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
			
			///<remarks>
			///   <name>DASeguimientoRecomendacion.SelectRecomendacionesSeguimientos_Filtro</name>
			///   <create>02-Junio-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene un listado de Expedientes en fase de seguimientos con base a los parámetros proporcionados utilizada en el filtro de búsqueda</summary>
			///<param name="entRecomendacion">Entidad de Seguimiento con los parámetros necesarios para consultar la información</param>
			///<param name="ConnectionString">Cadena de conexión a la base de datos</param>
			///<returns>Una entidad de respuesta</returns>
			public DataSet SelectRecomendacionesSeguimientos_Filtro(ENTSeguimientoRecomendacion entRecomendacion, string ConnectionString){
				DataSet ds = new DataSet();
				SqlConnection Connection = new SqlConnection(ConnectionString);
				SqlCommand Command;
				SqlDataAdapter DataAdapter;
				SqlParameter Parameter;

				try
				{
					Command = new SqlCommand("uspExpediente_Sel_Seguimientos_Filtro", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
					Parameter.Value = entRecomendacion.FuncionarioId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("Numero", SqlDbType.VarChar);
					Parameter.Value = entRecomendacion.Numero;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("Quejoso", SqlDbType.VarChar);
					Parameter.Value = entRecomendacion.Quejoso;
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

        #region Eventos
        #endregion

    }
}
