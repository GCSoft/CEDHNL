/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAExpedienteComparecencia
' Autor: Ruben.Cobos
' Fecha: 25-Agosto-2014
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con las Comparecencias
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
    public class DAExpedienteComparecencia : DABase
    {

		///<remarks>
		///   <name>DAExpedienteComparecencia.DeleteExpedienteComparecencia</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina una Comparecencia</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Servidor Publico con los parámetros necesarios realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteExpedienteComparecencia(ENTExpedienteComparecencia oENTExpedienteComparecencia, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteComparecencia_Del", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ExpedienteComparecenciaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ModuloId;
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
		///   <name>DAExpedienteComparecencia.InsertExpedienteComparecencia</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una Comparecencia</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Servidor Publico con los parámetros necesarios realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteComparecencia(ENTExpedienteComparecencia oENTExpedienteComparecencia, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteComparecencia_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("LugarComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.LugarComparecenciaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("TipoComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.TipoComparecenciaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioAtiende", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.FuncionarioAtiende;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioEjecuta", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.FuncionarioEjecuta;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Detalle", SqlDbType.VarChar);
			sqlPar.Value = oENTExpedienteComparecencia.Detalle;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fechacomparecencia", SqlDbType.DateTime);
			sqlPar.Value = oENTExpedienteComparecencia.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("HoraInicio", SqlDbType.Time);
			sqlPar.Value = oENTExpedienteComparecencia.HoraInicio;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("HoraFin", SqlDbType.Time);
			sqlPar.Value = oENTExpedienteComparecencia.HoraFin;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tblCiudadano", SqlDbType.Structured);
			sqlPar.Value = oENTExpedienteComparecencia.tblCiudadano;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tblServidorPublico", SqlDbType.Structured);
			sqlPar.Value = oENTExpedienteComparecencia.tblServidorPublico;
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
		///   <name>DAExpedienteComparecencia.SelectExpedienteComparecenciaByID</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta una Comparecencia en base a su ID</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Servidor Publico con los parámetros necesarios realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectExpedienteComparecenciaByID(ENTExpedienteComparecencia oENTExpedienteComparecencia, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteComparecencia_Sel_ByID", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ExpedienteComparecenciaId;
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
		///   <name>DAExpedienteComparecencia.UpdateExpedienteComparecencia</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza una Comparecencia</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Servidor Publico con los parámetros necesarios realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateExpedienteComparecencia(ENTExpedienteComparecencia oENTExpedienteComparecencia, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteComparecencia_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ExpedienteComparecenciaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("LugarComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.LugarComparecenciaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("TipoComparecenciaId", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.TipoComparecenciaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioAtiende", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.FuncionarioAtiende;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioEjecuta", SqlDbType.Int);
			sqlPar.Value = oENTExpedienteComparecencia.FuncionarioEjecuta;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Detalle", SqlDbType.VarChar);
			sqlPar.Value = oENTExpedienteComparecencia.Detalle;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fechacomparecencia", SqlDbType.DateTime);
			sqlPar.Value = oENTExpedienteComparecencia.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("HoraInicio", SqlDbType.Time);
			sqlPar.Value = oENTExpedienteComparecencia.HoraInicio;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("HoraFin", SqlDbType.Time);
			sqlPar.Value = oENTExpedienteComparecencia.HoraFin;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tblCiudadano", SqlDbType.Structured);
			sqlPar.Value = oENTExpedienteComparecencia.tblCiudadano;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tblServidorPublico", SqlDbType.Structured);
			sqlPar.Value = oENTExpedienteComparecencia.tblServidorPublico;
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
