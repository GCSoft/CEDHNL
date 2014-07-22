/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAQueja
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Quejas
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Referencias manuales
using System.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
	public class DAQueja : DABase
	{

		///<remarks>
		///   <name>DASolicitud.InsertSolicitudComentario</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario a la solicitud de una Queja</summary>
		///<param name="entSolicitud">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitudComentario(ENTQueja oENTQueja, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitudComentario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("SolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.SolicitudId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Comentario", SqlDbType.VarChar);
			sqlPar.Value = oENTQueja.Comentario;
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
		///   <name>DASolicitud.InsertSolicitudFuncionario</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a una Solicitud de Quejas</summary>
		///<param name="entSolicitud">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitudFuncionario(ENTQueja oENTQueja, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitudFuncionario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("SolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.SolicitudId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.FuncionarioId;
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
		///   <name>DAQueja.SelectSolicitud</name>
		///   <create>17-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Solicitudes de Quejas en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud(ENTQueja oENTQueja, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitud_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("Nivel", SqlDbType.Int);
			sqlPar.Value = oENTQueja.Nivel;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.UsuarioId;
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
		///   <name>DAQueja.SelectSolicitud_Detalle</name>
		///   <create>17-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el detalle de una Solicitud de Quejas en específica</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud_Detalle(ENTQueja oENTQueja, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitud_Sel_Detalle", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("SolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.SolicitudId;
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
		///   <name>DAQueja.SelectSolicitud_Filtro</name>
		///   <create>17-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Solicitudes de Quejas en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud_Filtro(ENTQueja oENTQueja, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitud_Sel_Filtro", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTQueja.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Numero", SqlDbType.VarChar);
			sqlPar.Value = oENTQueja.Numero;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FormaContactoId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.FormaContactoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FechaDesde", SqlDbType.DateTime);
			sqlPar.Value = oENTQueja.FechaDesde;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FechaHasta", SqlDbType.DateTime);
			sqlPar.Value = oENTQueja.FechaHasta;
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
		///   <name>DAQueja.UpdateSolicitud</name>
		///   <create>17-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza la información general de una solicitud de Quejas</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la actualización</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateSolicitud(ENTQueja oENTQueja, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspSolicitud_Upd_General", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("SolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.SolicitudId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FormaContactoId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.FormaContactoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("LugarHechosId", SqlDbType.Int);
			sqlPar.Value = oENTQueja.LugarHechosId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("DireccionHechos", SqlDbType.VarChar);
			sqlPar.Value = oENTQueja.DireccionHechos;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Observaciones", SqlDbType.VarChar);
			sqlPar.Value = oENTQueja.Observaciones;
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
