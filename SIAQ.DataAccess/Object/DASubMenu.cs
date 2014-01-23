/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DASubMenu
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Sub Menús
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
	
	public class DASubMenu : DABase
	{
		
		///<remarks>
		///   <name>DASubMenu.InsertSubMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Crea una nueva opción en el SubMenu</summary>
		///<param name="oENTSubMenu">Entidad de SubMenu con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSubMenu(ENTSubMenu oENTSubMenu, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatSubMenu_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idMenu", SqlDbType.Int);
			sqlPar.Value = oENTSubMenu.idMenu;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("sDescripcion", SqlDbType.VarChar);
			sqlPar.Value = oENTSubMenu.sDescripcion;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTSubMenu.sNombre;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("sPageName", SqlDbType.VarChar);
			sqlPar.Value = oENTSubMenu.sPageName;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("sURL", SqlDbType.VarChar);
			sqlPar.Value = oENTSubMenu.sURL;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
         sqlPar.Value = oENTSubMenu.tiActivo;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiRequired", SqlDbType.TinyInt);
         sqlPar.Value = oENTSubMenu.tiRequired;
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
		///   <name>DASubMenu.SelectSubMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene un listado de SubMenus en base a los parámetros proporcionados</summary>
		///<param name="oENTSubMenu">Entidad de SubMenu con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectSubMenu(ENTSubMenu oENTSubMenu, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatSubMenu_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("idRol", SqlDbType.Int);
         sqlPar.Value = oENTSubMenu.idRol;
         sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("idMenu", SqlDbType.Int);
			sqlPar.Value = oENTSubMenu.idMenu;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("idSubMenu", SqlDbType.Int);
			sqlPar.Value = oENTSubMenu.idSubMenu;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
			sqlPar.Value = oENTSubMenu.sNombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTSubMenu.tiActivo;
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
		///   <name>DASubMenu.UpdateSubMenu</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
      ///<summary>Actualiza la información de un SubMenu</summary>
		///<param name="oENTSubMenu">Entidad de SubMenu con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateSubMenu(ENTSubMenu oENTSubMenu, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatSubMenu_Upd", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idSubMenu", SqlDbType.Int);
			sqlPar.Value = oENTSubMenu.idSubMenu;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("idMenu", SqlDbType.Int);
         sqlPar.Value = oENTSubMenu.idMenu;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sDescripcion", SqlDbType.VarChar);
         sqlPar.Value = oENTSubMenu.sDescripcion;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sNombre", SqlDbType.VarChar);
         sqlPar.Value = oENTSubMenu.sNombre;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sPageName", SqlDbType.VarChar);
         sqlPar.Value = oENTSubMenu.sPageName;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("sURL", SqlDbType.VarChar);
         sqlPar.Value = oENTSubMenu.sURL;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
         sqlPar.Value = oENTSubMenu.tiActivo;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("tiRequired", SqlDbType.TinyInt);
         sqlPar.Value = oENTSubMenu.tiRequired;
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
      ///   <name>DASubMenu.UpdateSubMenu_Estatus</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
      ///<summary>Activa/inactiva un SubMenu</summary>
		///<param name="oENTSubMenu">Entidad de SubMenu con los parámetros necesarios para crear el registro</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateSubMenu_Estatus(ENTSubMenu oENTSubMenu, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatSubMenu_Upd_Estatus", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("idSubMenu", SqlDbType.Int);
			sqlPar.Value = oENTSubMenu.idSubMenu;
			sqlCom.Parameters.Add(sqlPar);
			
			sqlPar = new SqlParameter("tiActivo", SqlDbType.TinyInt);
			sqlPar.Value = oENTSubMenu.tiActivo;
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
