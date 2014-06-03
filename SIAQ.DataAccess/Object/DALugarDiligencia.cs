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
	public class DALugarDiligencia: DABase
	{
        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        public DALugarDiligencia()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

		///<remarks>
        ///   <name>DALugarDiligencia.searchLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Metodo para obtener las catPais del sistema</summary>
        public ENTResponse searchLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{
			ENTResponse oENTResponse = new ENTResponse();
			DataSet ds = new DataSet();
			// Transacción
			try
			{
				ds = dbs.ExecuteDataSet("catPaisSel");
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
        ///   <name>DALugarDiligencia.SelectLugarDiligencia</name>
        ///   <create>17-Marzo-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene un listado de Paises en base a los parámetros proporcionados</summary>
        ///<param name="oENTPais">Entidad de Pais con los parámetros necesarios para consultar la información</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia, String sConnection, Int32 iAlternateDBTimeout)
        {
           SqlConnection sqlCnn = new SqlConnection(sConnection);
           SqlCommand sqlCom;
           SqlParameter sqlPar;
           SqlDataAdapter sqlDA;

           ENTResponse oENTResponse = new ENTResponse();

           // Configuración de objetos
           sqlCom = new SqlCommand("uspLugarDiligencia_Sel", sqlCnn);
           sqlCom.CommandType = CommandType.StoredProcedure;

           // Timeout alternativo en caso de ser solicitado
           if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

           // Parametros
           sqlPar = new SqlParameter("LugarDiligenciaId", SqlDbType.Int);
           sqlPar.Value = oENTLugarDiligencia.LugarDiligenciaId;
           sqlCom.Parameters.Add(sqlPar);

           sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
           sqlPar.Value = oENTLugarDiligencia.Nombre;
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
        ///   <name>DALugarDiligencia.insertLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Metodo para insertar catPais del sistema</summary>
        public ENTResponse insertLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{
			ENTResponse oENTResponse = new ENTResponse();
			DataSet ds = new DataSet();
			// Transacción
			try
			{
                ds = dbs.ExecuteDataSet("uspLugarDiligencia_Ins", oENTLugarDiligencia.Descripcion, oENTLugarDiligencia.Nombre);
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
        ///   <name>DALugarDiligencia.updateLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Metodo que actualiza catPais del sistema</summary>
        public ENTResponse updateLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{
			ENTResponse oENTResponse = new ENTResponse();
			DataSet ds = new DataSet();
			// Transacción
			try
			{
                ds = dbs.ExecuteDataSet("uspLugarDiligencia_Upd", oENTLugarDiligencia.LugarDiligenciaId, oENTLugarDiligencia.Descripcion, oENTLugarDiligencia.Nombre);
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
        ///   <name>DALugarDiligencia.updateLugarDiligencia_Estatus</name>
		///   <create>28-Mayo-2014</create>
		///   <author>Daniel.Chavez</author>
		///</remarks>
		///<summary>Actualiza estatus de Pais en base a los parámetros proporcionados</summary>
		///<param name="oENTPais">Entidad de Pais con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse updateLugarDiligencia_Estatus(ENTLugarDiligencia oENTLugarDiligencia, String sConnection, Int32 iAlternateDBTimeout)
		{

			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlAdapter;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
            sqlPar = new SqlParameter("LugarDiligenciaId", SqlDbType.Int);
            sqlPar.Value = oENTLugarDiligencia.LugarDiligenciaId;
			sqlCom.Parameters.Add(sqlPar);

            //sqlPar = new SqlParameter("Activo", SqlDbType.TinyInt);
            //sqlPar.Value = oENTLugarDiligencia.Activo;
            //sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlAdapter = new SqlDataAdapter(sqlCom);

			// Transacción
			try
			{

				sqlCnn.Open();
				sqlAdapter.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();
			}
			catch (SqlException sqlEx) { oENTResponse.ExceptionRaised(sqlEx.Message); }
			catch (Exception Ex) { oENTResponse.ExceptionRaised(Ex.Message); }
			finally
			{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}


			// Resultado
			return oENTResponse;

		}

		///<remarks>
        ///   <name>DALugarDiligencia.deleteLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
        ///<summary>Metodo para eliminar de LugarDiligencia del sistema</summary>
        public ENTResponse deleteLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{
			ENTResponse oENTResponse = new ENTResponse();
			DataSet ds = new DataSet();
			// Transacción
			try
			{
				dbs.ExecuteDataSet("");
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
	}
}
