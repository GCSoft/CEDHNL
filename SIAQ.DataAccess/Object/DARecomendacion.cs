/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DARecomendacion
' Autor: Ruben.Cobos
' Fecha: 31-Agosto-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las recomendaciones a un Expediente
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
    public class DARecomendacion : DABase
    {

		///<remarks>
		///   <name>DARecomendacion.DeleteRecomendacion</name>
		///   <create>31/Ago/2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteRecomendacion(ENTRecomendacion oENTRecomendacion, string ConnectionString, int iAlternativeTimeOut){
			SqlConnection Connection = new SqlConnection(ConnectionString);
			SqlCommand Command;
			SqlDataAdapter DataAdapter;
			SqlParameter Parameter;

			ENTResponse oENTResponse = new ENTResponse();

			Command = new SqlCommand("uspRecomendacion_Del", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

			Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.RecomendacionId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.ExpedienteId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("ModuloId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.ModuloId;
			Command.Parameters.Add(Parameter);

			oENTResponse.dsResponse = new DataSet();
			DataAdapter = new SqlDataAdapter(Command);

			try
			{
				
				Connection.Open();
				DataAdapter.Fill(oENTResponse.dsResponse);
				Connection.Close();

			}catch (SqlException ex) {

				oENTResponse.ExceptionRaised(ex.Message);

			}catch (Exception ex) {
				
				oENTResponse.ExceptionRaised(ex.Message);
			
			}finally{

				if (Connection.State == ConnectionState.Open) { Connection.Close(); }
			}

			return oENTResponse;
		}

		///<remarks>
		///   <name>DARecomendacion.InsertRecomendacion</name>
		///   <create>31/Ago/2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacion(ENTRecomendacion oENTRecomendacion, string ConnectionString, int iAlternativeTimeOut){
			SqlConnection Connection = new SqlConnection(ConnectionString);
			SqlCommand Command;
			SqlDataAdapter DataAdapter;
			SqlParameter Parameter;

			ENTResponse oENTResponse = new ENTResponse();

			Command = new SqlCommand("uspRecomendacion_Ins", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

			Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.ExpedienteId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("EstatusId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.EstatusId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.FuncionarioId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("ModuloId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.ModuloId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("TipoRecomendacionId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.TipoRecomendacionId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("Observaciones", SqlDbType.VarChar);
			Parameter.Value = oENTRecomendacion.Observaciones;
			Command.Parameters.Add(Parameter);

			oENTResponse.dsResponse = new DataSet();
			DataAdapter = new SqlDataAdapter(Command);

			try
			{
				
				Connection.Open();
				DataAdapter.Fill(oENTResponse.dsResponse);
				Connection.Close();

			}catch (SqlException ex) {

				oENTResponse.ExceptionRaised(ex.Message);

			}catch (Exception ex) {
				
				oENTResponse.ExceptionRaised(ex.Message);
			
			}finally{

				if (Connection.State == ConnectionState.Open) { Connection.Close(); }
			}

			return oENTResponse;
		}

		///<remarks>
		///   <name>DARecomendacion.SelectRecomendacion_ByID</name>
		///   <create>31/Ago/2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectRecomendacion_ByID(ENTRecomendacion oENTRecomendacion, string ConnectionString, int iAlternativeTimeOut){
			SqlConnection Connection = new SqlConnection(ConnectionString);
			SqlCommand Command;
			SqlDataAdapter DataAdapter;
			SqlParameter Parameter;

			ENTResponse oENTResponse = new ENTResponse();

			Command = new SqlCommand("uspRecomendacion_Sel_ByID", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

			Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.RecomendacionId;
			Command.Parameters.Add(Parameter);

			oENTResponse.dsResponse = new DataSet();
			DataAdapter = new SqlDataAdapter(Command);

			try
			{
				
				Connection.Open();
				DataAdapter.Fill(oENTResponse.dsResponse);
				Connection.Close();

			}catch (SqlException ex) {

				oENTResponse.ExceptionRaised(ex.Message);

			}catch (Exception ex) {
				
				oENTResponse.ExceptionRaised(ex.Message);
			
			}finally{

				if (Connection.State == ConnectionState.Open) { Connection.Close(); }
			}

			return oENTResponse;
		}

		///<remarks>
		///   <name>DARecomendacion.UpdateRecomendacion</name>
		///   <create>31/Ago/2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateRecomendacion(ENTRecomendacion oENTRecomendacion, string ConnectionString, int iAlternativeTimeOut){
			SqlConnection Connection = new SqlConnection(ConnectionString);
			SqlCommand Command;
			SqlDataAdapter DataAdapter;
			SqlParameter Parameter;

			ENTResponse oENTResponse = new ENTResponse();

			Command = new SqlCommand("uspRecomendacion_Upd", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

			Parameter = new SqlParameter("RecomendacionId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.RecomendacionId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.ExpedienteId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("EstatusId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.EstatusId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("FuncionarioId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.FuncionarioId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("ModuloId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.ModuloId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("TipoRecomendacionId", SqlDbType.Int);
			Parameter.Value = oENTRecomendacion.TipoRecomendacionId;
			Command.Parameters.Add(Parameter);

			Parameter = new SqlParameter("Observaciones", SqlDbType.VarChar);
			Parameter.Value = oENTRecomendacion.Observaciones;
			Command.Parameters.Add(Parameter);

			oENTResponse.dsResponse = new DataSet();
			DataAdapter = new SqlDataAdapter(Command);

			try
			{
				
				Connection.Open();
				DataAdapter.Fill(oENTResponse.dsResponse);
				Connection.Close();

			}catch (SqlException ex) {

				oENTResponse.ExceptionRaised(ex.Message);

			}catch (Exception ex) {
				
				oENTResponse.ExceptionRaised(ex.Message);
			
			}finally{

				if (Connection.State == ConnectionState.Open) { Connection.Close(); }
			}

			return oENTResponse;
		}

    }
}
