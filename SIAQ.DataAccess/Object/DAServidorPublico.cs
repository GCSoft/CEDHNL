/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAServidorPublico
' Autor: Ruben.Cobos
' Fecha: 25-Agosto-2014
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Servidores Públicos
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
	
	public class DAServidorPublico : DABase
	{

		///<remarks>
		///   <name>DAServidorPublico.InsertServidorPublico</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un Servidor Publico</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertServidorPublico(ENTServidorPublico oENTServidorPublico, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspServidorPublico_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ColoniaId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.ColoniaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EscolaridadId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.EscolaridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstadoCivilId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.EstadoCivilId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("NacionalidadId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.NacionalidadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("OcupacionId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.OcupacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("SexoId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.SexoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Edad", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.Edad;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.ApellidoPaterno;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.ApellidoMaterno;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Calle", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Calle;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Telefono", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Telefono;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CorreoElectronico", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.CorreoElectronico;
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
		///   <name>DAServidorPublico.SelectServidorPublico_ASService</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Motor de consulta del servicio de autosuggest</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectServidorPublico_ASService(ENTServidorPublico oENTServidorPublico, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspServidorPublico_Sel_ASService", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Nombre;
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
		///   <name>DAServidorPublico.SelectServidorPublicoByID</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta la información de un Servidor Publico en base a su ID</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectServidorPublicoByID(ENTServidorPublico oENTServidorPublico, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspServidorPublico_Sel_ByID", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ServidorPublicoId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.ServidorPublicoId;
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
		///   <name>DAServidorPublico.UpdateServidorPublico</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza la información de un Servidor Publico</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateServidorPublico(ENTServidorPublico oENTServidorPublico, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspServidorPublico_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("ServidorPublicoId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.ServidorPublicoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("AutoridadId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.AutoridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ColoniaId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.ColoniaId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EscolaridadId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.EscolaridadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("EstadoCivilId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.EstadoCivilId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("NacionalidadId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.NacionalidadId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("OcupacionId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.OcupacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("SexoId", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.SexoId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Edad", SqlDbType.Int);
			sqlPar.Value = oENTServidorPublico.Edad;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.ApellidoPaterno;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.ApellidoMaterno;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Calle", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Calle;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Telefono", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.Telefono;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("CorreoElectronico", SqlDbType.VarChar);
			sqlPar.Value = oENTServidorPublico.CorreoElectronico;
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
