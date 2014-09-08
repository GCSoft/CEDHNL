/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAVisitaduria
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Visitadurias
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
	public class DAVisitaduria : DABase
	{

		///<remarks>
		///   <name>DAVisitaduria.DeleteExpedienteAutoridad</name>
		///   <create>07-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina una Autoridad señalada en particular junto con sus voces</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse DeleteExpedienteAutoridad(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridad_Del", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
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
		///   <name>DAVisitaduria.DeleteExpedienteComentario</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un comentario asociado a un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteExpedienteComentario(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteComentario_Del", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ComentarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ComentarioId;
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
		///   <name>DAVisitaduria.InsertExpedienteAutoridad</name>
		///   <create>07-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva Autoridad señalada en particular de un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse InsertExpedienteAutoridad(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridad_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CalificacionAutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.CalificacionAutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Puesto", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Puesto;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Comentario", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Comentario;
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
		///   <name>DAVisitaduria.InsertExpedienteAutoridadVoces</name>
		///   <create>08-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva Voz a Autoridad señalada en particular de un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse InsertExpedienteAutoridadVoces(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridadVoces_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("VozId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.VozId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CalificacionAutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.CalificacionAutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Comentario", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Comentario;
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
		///   <name>DAVisitaduria.InsertExpedienteCalificacionDefinitiva</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta o actualiza la calificación definitiva del expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteCalificacionDefinitiva(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteCalificacionDefinitiva_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Acuerdo", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.Acuerdo;
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
		///   <name>DAVisitaduria.InsertExpedienteComentario</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario al Expediente</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteComentario(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteComentario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("MedidaPreventiva", SqlDbType.TinyInt);
			sqlPar.Value = oENTVisitaduria.MedidaPreventiva;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Comentario", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Comentario;
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
		///   <name>DAVisitaduria.InsertExpedienteFuncionario</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a una Expediente de Visitadurias</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteFuncionario(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteVisitador_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.FuncionarioId;
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
		///   <name>DAVisitaduria.InsertExpedienteResolucion</name>
		///   <create>30-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta o actualiza la resolución del expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteResolucion(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteResolucion_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("TipoResolucionId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.TipoResolucionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Detalle", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Detalle;
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
		///   <name>DAVisitaduria.SelectCalificacionAutoridad</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Calificaciones de Autoridad en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad del Expediente de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectCalificacionAutoridad(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspCalificacionAutoridad_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("CalificacionAutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.CalificacionAutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Nombre;
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
		///   <name>DAVisitaduria.SelectExpediente</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Expedientes de Visitadurias en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpediente(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpediente_Sel_Visitadurias", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("AreaId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AreaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nivel", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.Nivel;
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
		///   <name>DAVisitaduria.SelectExpedienteAutoridad</name>
		///   <create>02-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de autoridades asociadas a un expediente en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpedienteAutoridad(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridad_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CalificacionAutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.CalificacionAutoridadId;
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
		///   <name>DAVisitaduria.SelectExpedienteAutoridad_Detalle</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el detalle de una autoridad asociada a un expediente en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpedienteAutoridad_Detalle(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridad_Sel_Detalle", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
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
		///   <name>DAVisitaduria.SelectExpedienteAutoridadVoces</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene las voces asociadas a una autoridad de un expediente en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpedienteAutoridadVoces(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridadVoces_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
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
		///   <name>DAVisitaduria.SelectExpediente_Detalle</name>
		///   <create>15-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el detalle de un Expedientes de Visitadurias en específico</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpediente_Detalle(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpediente_Sel_Detalle_Visitadurias", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
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
		///   <name>DAVisitaduria.SelectExpediente_Filtro</name>
		///   <create>04-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Expedientes de Visitadurías en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad del Expediente de Visitadurías con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpediente_Filtro(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpediente_Sel_Visitadurias_Filtro", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Numero", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Numero;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AreaId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AreaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstatusId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.EstatusId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FechaDesde", SqlDbType.DateTime);
			sqlPar.Value = oENTVisitaduria.FechaDesde;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FechaHasta", SqlDbType.DateTime);
			sqlPar.Value = oENTVisitaduria.FechaHasta;
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
		///   <name>DAVisitaduria.UpdateExpedienteAutoridad</name>
		///   <create>27-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza la información de una Autoridad señalada en particular de un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateExpedienteAutoridad(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridad_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CalificacionAutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.CalificacionAutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Puesto", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Puesto;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Comentario", SqlDbType.VarChar);
			sqlPar.Value = oENTVisitaduria.Comentario;
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
		///   <name>DAVisitaduria.UpdateExpedienteAutoridadVoces</name>
		///   <create>28-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza la información de las Voces de una Autoridad señalada en particular de un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateExpedienteAutoridadVoces(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpedienteAutoridadVoces_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tblVoz", SqlDbType.Structured);
			sqlPar.Value = oENTVisitaduria.tblVoz;
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
		///   <name>DAVisitaduria.UpdateExpedienteEstatus</name>
		///   <create>03-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Cambia el estatus de un una Expediente de Visitadurias</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateExpedienteEstatus(ENTVisitaduria oENTVisitaduria, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspExpediente_Upd_Estatus", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstatusId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.EstatusId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTVisitaduria.ModuloId;
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
