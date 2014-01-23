/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAUsuario
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con el usuario
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

	public class DAUsuario : DABase
	{

		///<remarks>
		///   <name>DAUsuario.InsertUsuario</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Crea un nuevo Usuario</summary>
		///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para actualizar su información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertUsuario(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idArea", SqlDbType.Int);
         sqlPar.Value = oENTUsuario.idArea;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("idRol", SqlDbType.Int);
			sqlPar.Value = oENTUsuario.idRol;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("sApellidoMaterno", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sApellidoMaterno;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sApellidoPaterno", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sApellidoPaterno;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sDescripcion", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sDescripcion;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sEmail", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sEmail;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sPassword", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sPassword;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
         sqlPar.Value = oENTUsuario.tiActivo;
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
		///   <name>DAUsuario.SelectUsuario</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Consulta el catálogo de Usuarios</summary>
		///<param name="oENTUsuario">Entidad de usuario con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectUsuario(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idArea", SqlDbType.Int);
         sqlPar.Value = oENTUsuario.idArea;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("idRol", SqlDbType.Int);
			sqlPar.Value = oENTUsuario.idRol;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
			sqlPar.Value = oENTUsuario.idUsuario;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("sEmail", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sEmail;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTUsuario.tiActivo;
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
		///   <name>DAUsuario.selectUsuario_Autenticacion</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Consulta la información de un usuario para verificar su posible acceso al sistema</summary>
		///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectUsuario_Autenticacion(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Sel_Autenticacion", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("sEmail", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sEmail;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sPassword", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sPassword;
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
		///   <name>DAUsuario.SelectUsuario_RecuperaContrasena</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Consulta el password de un usuario para enviarlo por correo a través del sistema</summary>
		///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectUsuario_RecuperaContrasena(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Sel_PasswordRecovery", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("sEmail", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sEmail;
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
		///   <name>DAUsuario.UpdateUsuario</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Actualiza la información de un usuario</summary>
		///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para actualizar su información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateUsuario(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
			sqlPar.Value = oENTUsuario.idUsuario;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idArea", SqlDbType.Int);
         sqlPar.Value = oENTUsuario.idArea;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idRol", SqlDbType.Int);
         sqlPar.Value = oENTUsuario.idRol;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sApellidoMaterno", SqlDbType.VarChar);
         sqlPar.Value = oENTUsuario.sApellidoMaterno;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sApellidoPaterno", SqlDbType.VarChar);
         sqlPar.Value = oENTUsuario.sApellidoPaterno;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sDescripcion", SqlDbType.VarChar);
         sqlPar.Value = oENTUsuario.sDescripcion;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sEmail", SqlDbType.VarChar);
         sqlPar.Value = oENTUsuario.sEmail;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
         sqlPar.Value = oENTUsuario.sNombre;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
         sqlPar.Value = oENTUsuario.tiActivo;
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
		///   <name>DAUsuario.UpdateUsuario_ActualizaContrasena</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Actualiza la contraseña de un usuario</summary>
		///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para actualizar la contraseña</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateUsuario_ActualizaContrasena(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Upd_ChangePassword", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
			sqlPar.Value = oENTUsuario.idUsuario;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sPassword", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sPassword;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sOldPassword", SqlDbType.VarChar);
			sqlPar.Value = oENTUsuario.sOldPassword;
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
			}
			finally{
				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();
			}

			// Resultado
			return oENTResponse;
		}

      ///<remarks>
      ///   <name>DAUsuario.UpdateUsuario_Estatus</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
      ///<summary>Activa/inactiva un Usuario</summary>
		///<param name="oENTUsuario">Entidad de Usuario con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateUsuario_Estatus(ENTUsuario oENTUsuario, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatUsuario_Upd_Estatus", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
			sqlPar.Value = oENTUsuario.idUsuario;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTUsuario.tiActivo;
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
