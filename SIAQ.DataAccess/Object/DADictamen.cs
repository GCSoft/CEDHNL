/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DADictamen
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Dictamenes Médicos
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using System.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DADictamen : DABase
    {

		///<remarks>
		///   <name>DADictamen.InsertDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea un nuevo dictamen a un ciudadano en el modulo de atención a víctimas</summary>
		///<param name="oENTTipoDictamen">Entidad de Dictamen con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertDictamen(ENTDictamen oENTDictamen, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDictamen_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("AtencionId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.AtencionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CiudadanoId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.CiudadanoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("TipoDictamenId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.TipoDictamenId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("LugarAtencionId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.LugarAtencionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Dictamen", SqlDbType.VarChar);
			sqlPar.Value = oENTDictamen.Dictamen;
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

		///<remarks>
		///   <name>DADictamen.SelectDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el listado de Dictámenes asociados a una atención a Víctimas</summary>
		///<param name="oENTTipoDictamen">Entidad de Dictamen con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectDictamen(ENTDictamen oENTDictamen, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDictamen_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("AtencionId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.AtencionId;
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

		///<remarks>
		///   <name>DADictamen.SelectLugarAtencion</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Lugares de Atención del dictamen en base a los parámetros proporcionados</summary>
		///<param name="oENTDictamen">Entidad de Dictamen con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectLugarAtencion(ENTDictamen oENTDictamen, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspLugarAtencion_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("LugarAtencionId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.LugarAtencionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTDictamen.Nombre;
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
        
		///<remarks>
		///   <name>DADictamen.SelectTipoDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Tipos de Dictámenes en base a los parámetros proporcionados</summary>
		///<param name="oENTDictamen">Entidad de Dictamen con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectTipoDictamen(ENTDictamen oENTDictamen, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspTipoDictamen_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("TipoDictamenId", SqlDbType.Int);
			sqlPar.Value = oENTDictamen.TipoDictamenId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTDictamen.Nombre;
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
