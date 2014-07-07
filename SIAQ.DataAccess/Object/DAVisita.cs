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

		#region "Rutina Original"
		
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

		#endregion

		///<remarks>
		///   <name>DAVisita.InsertVisita</name>
		///   <create>06-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una visita</summary>
		///<param name="oENTVisita">Entidad de Visita con los parámetros necesarios para crear la relación</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertVisita(ENTVisita oENTVisita, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspVisita_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("AreaId", SqlDbType.Int);
			sqlPar.Value = oENTVisita.AreaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisita.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("MotivoId", SqlDbType.Int);
			sqlPar.Value = oENTVisita.MotivoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CiudadanoId", SqlDbType.Int);
			sqlPar.Value = oENTVisita.CiudadanoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioIdInsert", SqlDbType.Int);
			sqlPar.Value = oENTVisita.UsuarioIdInsert;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Visitante", SqlDbType.VarChar);
			sqlPar.Value = oENTVisita.Visitante;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Observaciones", SqlDbType.VarChar);
			sqlPar.Value = oENTVisita.Observaciones;
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
