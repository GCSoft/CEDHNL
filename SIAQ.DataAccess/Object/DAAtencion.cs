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
    public class DAAtencion : DABase
    {

		#region Logica Original

			Database dbs;

			public DAAtencion()
			{
				dbs = DatabaseFactory.CreateDatabase("Conn");
			}

			///<remarks>
			///   <name>DAAtencion.searchAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para obtener las Atencion del sistema</summary>
			public ENTResponse searchAtencionDetalle(ENTAtencion entAtencion)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					ds = dbs.ExecuteDataSet("uspAtencionDetalleSel", entAtencion.IdUsuario, entAtencion.Aprobar, entAtencion.AtencionId);
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
			///   <name>DAAtencion.insertAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para insertar Atencion del sistema</summary>
			public ENTResponse insertAtencion(ENTAtencion entAtencion)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					ds = dbs.ExecuteDataSet("AtencionIns");
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
			///   <name>DAAtencion.insertAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para insertar Atencion del sistema</summary>
			public ENTResponse insertAtencionObservaciones(ENTAtencion entAtencion)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					ds = dbs.ExecuteDataSet("AtencionObservacionesIns", entAtencion.AtencionId, entAtencion.Observaciones, entAtencion.IdUsuario);
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
			///   <name>DAAtencion.updateAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo que actualiza Atencion del sistema</summary>
			public ENTResponse updateAtencion(ENTAtencion entAtencion)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					dbs.ExecuteDataSet("AtencionUpd");
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
			///   <name>DAAtencion.deleteAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para eliminar de Atencion del sistema</summary>
			public ENTResponse deleteAtencion(ENTAtencion entAtencion)
			{
				ENTResponse oENTResponse = new ENTResponse();
				DataSet ds = new DataSet();
				// Transacción
				try
				{
					dbs.ExecuteDataSet("AtencionDel");
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
			
		#endregion

		///<remarks>
		///   <name>DAAtencion.SelectAtencion</name>
		///   <create>17-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Expedientes de Atención a Víctimas en base a los parámetros proporcionados</summary>
		///<param name="entAtencion">Entidad del Expediente de Atención a Víctimas con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectAtencion(ENTAtencion entAtencion, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspAtencion_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("Aprobar", SqlDbType.Int);
			sqlPar.Value = entAtencion.Aprobar;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = entAtencion.IdUsuario;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try
			{
				
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

		///<remarks>
		///   <name>DAAtencion.SelectAtencion_Filtro</name>
		///   <create>17-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Expedientes de Atención a Víctimas en base a los parámetros proporcionados</summary>
		///<param name="entAtencion">Entidad del Expediente de Atención a Víctimas con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectAtencion_Filtro(ENTAtencion entAtencion, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspAtencion_Sel_Filtro", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = entAtencion.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Numero", SqlDbType.VarChar);
			sqlPar.Value = entAtencion.Numero;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Quejoso", SqlDbType.VarChar);
			sqlPar.Value = entAtencion.Quejoso;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try
			{
				
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
