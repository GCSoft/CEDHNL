﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DADocumento
' Autor: Ruben.Cobos
' Fecha: 09-Septiembre-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con la carga de Documentos
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
    public class DADocumento : DABase
    {

		///<remarks>
		///   <name>DADocumento.DeleteDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteDocumento(ENTDocumento oENTDocumento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDocumento_Del", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("DocumentoId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.DocumentoId;
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
		///   <name>DADocumento.InsertDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Guarda un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertDocumento(ENTDocumento oENTDocumento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDocumento_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("SolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.SolicitudId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.idUsuarioInsert;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Extension", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Extension;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Descripcion", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Descripcion;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Ruta", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Ruta;
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
		///   <name>DADocumento.SelectDocumento_Path</name>
		///   <create>10-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta la ruta física en donde se almacenó un documento</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectDocumento_Path(ENTDocumento oENTDocumento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDocumento_Sel_Path", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("DocumentoId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.DocumentoId;
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
