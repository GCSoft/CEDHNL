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
    public class DASolicitud : DABase
	{

		#region "Rutina Original"

			protected int _ErrorId;
			protected string _ErrorDescription;
			Database dbs;

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

			public DASolicitud()
			{
				dbs = DatabaseFactory.CreateDatabase("Conn");
			}

			///<remarks>
			///   <name>DASolicitud.deleteSolicitud</name>
			///   <create>27/ene/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para eliminar de Solicitud del sistema</summary>
			public ENTResponse deleteSolicitud(ENTSolicitud entSolicitud)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					dbs.ExecuteDataSet("SolicitudDel");
					oENTResponse.dsResponse = ds;
				}
				catch (SqlException sqlEx)
				{
					oENTResponse.ExceptionRaised(sqlEx.Message);
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}
				finally
				{
				}
				// Resultado
				return oENTResponse;

			}

			///<remarks>
			///   <name>DASolicitud.EnviarSolicitud</name>
			///   <create>11/04/2014</create>
			///   <author>Jose.Gomez</author>
			///</remarks>
			///<summary>Metodo para enviar la solicitud a Visitadurías</summary>
			public ENTResponse EnviarSolicitud(ENTSolicitud oENTSolicitud, string sConnectionString, int iAlternativeTimeoOut)
			{
				SqlConnection Connection = new SqlConnection(sConnectionString);
				SqlCommand Command;
				SqlDataAdapter DataAdapter;
				SqlParameter Parameter;

				ENTResponse oENTResponse = new ENTResponse();

				Command = new SqlCommand("spEnviarSolicitud_ins", Connection);
				Command.CommandType = CommandType.StoredProcedure;

				if (iAlternativeTimeoOut > 0) { Command.CommandTimeout = iAlternativeTimeoOut; }

				Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
				Parameter.Value = oENTSolicitud.SolicitudId;
				Command.Parameters.Add(Parameter);

				oENTResponse.dsResponse = new DataSet();
				DataAdapter = new SqlDataAdapter(Command);

				try
				{
					Connection.Open();
					DataAdapter.Fill(oENTResponse.dsResponse);
					Connection.Close();
				}
				catch (SqlException ex) { oENTResponse.ExceptionRaised(ex.Message); }
				catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
				finally
				{
					if (Connection.State == ConnectionState.Open)
					{
						Connection.Close();
					}
				}

				return oENTResponse;
			}

			public void GuardarCalificacionSol(ENTSolicitud ENTSolicitud, string ConnectionString)
			{
				DataSet ResultData = new DataSet();
				SqlCommand Command;
				SqlParameter Parameter;
				SqlConnection Connection = new SqlConnection(ConnectionString);

				try
				{
					Command = new SqlCommand("InsertarCalificacionSol", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
					Parameter.Value = ENTSolicitud.SolicitudId;
					Command.Parameters.Add(Parameter);
					/*
					 * Esta entidad queda pendientee de revisar se propone que lleve el idUsuarioInsert para saber
					 * quien calificó la solicitud FelipeVéliz
					Parameter = new SqlParameter("IdUsuarioInsert", SqlDbType.Int);
					Parameter.Value = ENTSolicitud.idUsuarioInsert;
					Command.Parameters.Add(Parameter);*/

					Parameter = new SqlParameter("Fundamento", SqlDbType.VarChar);
					Parameter.Value = ENTSolicitud.Fundamento;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("CanalizacionId", SqlDbType.Int);
					Parameter.Value = ENTSolicitud.CalificacionId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("CalificacionId", SqlDbType.Int);
					Parameter.Value = ENTSolicitud.CalificacionId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("TipoOrientacionId", SqlDbType.Int);
					Parameter.Value = ENTSolicitud.CierreOrientacionId;
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
			///     Busca las autoridades que están señaladas en una solicitud.
			/// </summary>
			/// <param name="ENTSolicitud">Entidad de solicitud.</param>
			/// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
			/// <returns>Resultado de la búsqueda.</returns>
			public DataSet SelectSolicitudAutoridad(ENTSolicitud ENTSolicitud, string ConnectionString)
			{
				DataSet ResultData = new DataSet();
				SqlConnection Connection = new SqlConnection(ConnectionString);
				SqlCommand Command;
				SqlParameter Parameter;
				SqlDataAdapter DataAdapter;

				try
				{
					Command = new SqlCommand("SelectSolicitudAutoridad", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
					Parameter.Value = ENTSolicitud.SolicitudId;
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
			///     Muestra las voces señaladas de una autoridad de una solicitud
			/// </summary>
			/// <param name="ENTAutoridad">Entidad de autoridad.</param>
			/// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
			/// <returns>Resultado de la búsqueda.</returns>
			public DataSet SelectSolicitudAutoridadVoces(ENTAutoridad oENTAutoridad, string ConnectionString)
			{
				SqlConnection Connection = new SqlConnection(ConnectionString);
				SqlCommand Command;
				SqlDataAdapter DataAdapter;
				SqlParameter Parameter;
				DataSet ds = new DataSet();

				try
				{
					Command = new SqlCommand("SelectSolicitudAutoridadVoces_sel", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
					Parameter.Value = oENTAutoridad.SolicitudId;
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
					Parameter.Value = oENTAutoridad.AutoridadId;
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

					if (Connection.State == ConnectionState.Open) { Connection.Close(); }
				}

				return ds;
			}

			///<remarks>
			///   <name>DASolicitud.updateSolicitud</name>
			///   <create>27/ene/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo que actualiza Solicitud del sistema</summary>
			public ENTResponse updateSolicitud(ENTSolicitud entSolicitud)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					dbs.ExecuteDataSet("SolicitudUpd");
					oENTResponse.dsResponse = ds;
				}
				catch (SqlException sqlEx)
				{
					oENTResponse.ExceptionRaised(sqlEx.Message);
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}
				finally
				{
				}
				// Resultado
				return oENTResponse;
			}

			///<remarks>
			///   <name>DASolicitud.ValidarEnviarSolicitud</name>
			///   <create>11/04/2014</create>
			///   <author>Jose.Gomez</author>
			///</remarks>
			///<summary>Valida la solicitud antes de enviarla, que haya ciudadanos agregados, que se haya calificado, que haya autoridades agregadas y que se hayan agregado voces señaladas a dichas autoridades</summary>
			public DataSet ValidarEnviarSolicitud(ENTSolicitud oENTSolicitud, string sConnectionString)
			{
				SqlConnection Connection = new SqlConnection(sConnectionString);
				SqlCommand Command;
				SqlDataAdapter DataAdapter;
				SqlParameter Parameter;
				DataSet ds = new DataSet();

				try
				{
					Command = new SqlCommand("spValidarEnviarSolicitud_sel", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
					Parameter.Value = oENTSolicitud.SolicitudId;
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
					if (Connection.State == ConnectionState.Open) { Connection.Close(); }
				}

				return ds;
			}

			/// <summary>
			///     Selecciona las quejas y sus estatus para reporte de quejas por estatus.
			/// </summary>
			/// <param name="ENTSolicitudComentario">Entidad del comentario de la solicitud.</param>
			/// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
			/// <returns>Resultado de la búsqueda.</returns>
			public DataSet SelectRptQuejas(ENTSolicitud ent, string ConnectionString)
			{
				DataSet ResultData = new DataSet();
				SqlConnection Connection = new SqlConnection(ConnectionString);
				SqlCommand Command;
				SqlParameter Parameter;
				SqlDataAdapter DataAdapter;

				try
				{
					Command = new SqlCommand("usprptQuejasEstatus", Connection);
					Command.CommandType = CommandType.StoredProcedure;

					Parameter = new SqlParameter("FechaInicial", SqlDbType.DateTime);
					//Parameter.Value = ent.FechaDesde;
					Parameter.Value = "2013-01-01";
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("FechaFinal", SqlDbType.DateTime);
					//Parameter.Value = ent.FechaHasta;
					Parameter.Value = "2015-01-01";
					Command.Parameters.Add(Parameter);

					Parameter = new SqlParameter("Estatus", SqlDbType.Int);
					Parameter.Value = ent.EstatusId;
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

		#endregion


		///<remarks>
		///   <name>DASolicitud.InsertSolicitud</name>
		///   <create>06-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una Solicitud</summary>
		///<param name="oENTSolicitud">Entidad de Solicitud con los parámetros necesarios para crear la relación</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitud(ENTSolicitud oENTSolicitud, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitud_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTSolicitud.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CalificacionId", SqlDbType.Int);
			sqlPar.Value = oENTSolicitud.CalificacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("TipoSolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTSolicitud.TipoSolicitudId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("LugarHechosId", SqlDbType.Int);
			sqlPar.Value = oENTSolicitud.LugarHechosId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstatusId", SqlDbType.Int);
			sqlPar.Value = oENTSolicitud.EstatusId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CiudadanoId", SqlDbType.Int);
			sqlPar.Value = oENTSolicitud.CiudadanoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("NombreTemporal", SqlDbType.VarChar);
			sqlPar.Value = oENTSolicitud.NombreTemporal;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Observaciones", SqlDbType.VarChar);
			sqlPar.Value = oENTSolicitud.Observaciones;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();
			}catch (SqlException sqlEx){
				oENTResponse.ExceptionRaised(sqlEx.Message);
			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}finally{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}

			// Resultado
			return oENTResponse;
		}


	}
}
