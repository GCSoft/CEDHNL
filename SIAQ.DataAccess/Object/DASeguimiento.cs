﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DASeguimiento
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Seguimientos
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
	public class DASeguimiento : DABase
	{

		///<remarks>
		///   <name>DASeguimiento.DeleteRecomendacionComentario</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un comentario al Expediente en el módulo de Seguimientos</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteRecomendacionComentario(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacionComentario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ComentarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ComentarioId;
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
		///   <name>DASeguimiento.InsertRecomendacionComentario</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario al Expediente en el módulo de Seguimientos</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacionComentario(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacionComentario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);


			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("MedidaPreventiva", SqlDbType.TinyInt);
			sqlPar.Value = oENTSeguimiento.MedidaPreventiva;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Comentario", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
		///   <name>DARecomendacion.InsertRecomendacionFuncionario</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a un Expediente de Seguimiento</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimiento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacionFuncionario(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacionFuncionario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.FuncionarioId;
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
		///   <name>DARecomendacion.InsertRecomendacionGestion</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea un nuevo registro de gestión sobre un Seguimiento de un punto resolutivo</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimiento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacionGestion(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacionGestion_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionDetalleId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionDetalleId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstatusPuntoResolutivoId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.EstatusPuntoResolutivoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fecha", SqlDbType.DateTime);
			sqlPar.Value = oENTSeguimiento.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Gestion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
		///   <name>DASeguimiento.SelectEstatusPuntoResolutivo</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de los estatus de un punto resolutivo en base a los parámetros proporcionados</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectEstatusPuntoResolutivo(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspEstatusPuntoResolutivo_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("EstatusPuntoResolutivoId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.EstatusPuntoResolutivoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AcuerdoNoResponsabilidad", SqlDbType.TinyInt);
			sqlPar.Value = oENTSeguimiento.AcuerdoNoResponsabilidad;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Visible", SqlDbType.TinyInt);
			sqlPar.Value = oENTSeguimiento.Visible;
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
		///   <name>DASeguimiento.SelectRecomendacion</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Recomendaciones en base a los parámetros proporcionados</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacion(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Sel_Seguimientos", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nivel", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.Nivel;
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
		///   <name>DASeguimiento.SelectRecomendacion_Filtro</name>
		///   <create>12-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Recomendaciones en base a los parámetros proporcionados utilizado en la pantalla de búsqueda</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacion_Filtro(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Sel_Seguimientos_Filtro", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("EstatusId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.EstatusId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.FuncionarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AcuerdoNoResponsabilidad", SqlDbType.TinyInt);
			sqlPar.Value = oENTSeguimiento.AcuerdoNoResponsabilidad;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ExpedienteNumero", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.ExpedienteNumero;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("RecomendacionNumero", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.RecomendacionNumero;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("NombreAutoridad", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.NombreAutoridad;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FechaDesde", SqlDbType.Date);
			sqlPar.Value = oENTSeguimiento.FechaDesde;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("FechaHasta", SqlDbType.Date);
			sqlPar.Value = oENTSeguimiento.FechaHasta;
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
		///   <name>DASeguimiento.SelectRecomendacion_Detalle</name>
		///   <create>14-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el detalle de una Recomendación en particular</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacion_Detalle(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Sel_Seguimientos_Detalle", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
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
		///   <name>DASeguimiento.SelectRecomendacionGestion_PuntoResolutivo</name>
		///   <create>12-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene la gestión de los puntos resolutivos de una Recomendación/Acuerdo de No Responsabilidad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacionGestion_PuntoResolutivo(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacionGestion_Sel_DetallePuntoResolutivo", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionDetalleId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionDetalleId;
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
		///   <name>DASeguimiento.UpdateRecomendacion_EnvioAutoridad</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inicia el proceso de envío de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_EnvioAutoridad(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_EnvioAutoridad", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fecha", SqlDbType.DateTime);
			sqlPar.Value = oENTSeguimiento.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Gestion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
		///   <name>DASeguimiento.UpdateRecomendacion_EnvioAutoridadCierre</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Finaliza el proceso de envío de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_EnvioAutoridadCierre(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_EnvioAutoridadCierre", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fecha", SqlDbType.DateTime);
			sqlPar.Value = oENTSeguimiento.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Aceptada", SqlDbType.TinyInt);
			sqlPar.Value = oENTSeguimiento.Aceptada;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Gestion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
		///   <name>DASeguimiento.UpdateRecomendacion_Estatus</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Cambia el estatus de la recomendación/Acuerdo de no responsabilidad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_Estatus(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_Estatus", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstatusId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.EstatusId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
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
		///   <name>DASeguimiento.UpdateRecomendacion_ImpugnarDocumento</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inicia el proceso de ipugnación de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_ImpugnarDocumento(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_ImpugnarDocumento", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fecha", SqlDbType.DateTime);
			sqlPar.Value = oENTSeguimiento.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Gestion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
		///   <name>DASeguimiento.UpdateRecomendacion_ImpugnarDocumentoCierre</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Finaliza el proceso de impugnación de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_ImpugnarDocumentoCierre(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_ImpugnarDocumentoCierre", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fecha", SqlDbType.DateTime);
			sqlPar.Value = oENTSeguimiento.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Gestion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
		///   <name>DASeguimiento.UpdateRecomendacion_Numero</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza el número de una recomendación</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_Numero(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_Numero", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("NumeroRecomendacion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.NumeroRecomendacion;
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
		///   <name>DASeguimiento.UpdateRecomendacion_PublicarDocumento</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Envia una recomendación/Acuerdo de no responsabilidad a un estado de publicación</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_PublicarDocumento(ENTSeguimiento oENTSeguimiento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspRecomendacion_Upd_PublicarDocumento", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("RecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.RecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTSeguimiento.UsuarioId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Fecha", SqlDbType.DateTime);
			sqlPar.Value = oENTSeguimiento.Fecha;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Gestion", SqlDbType.VarChar);
			sqlPar.Value = oENTSeguimiento.Comentario;
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
