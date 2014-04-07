/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DATitulo
' Autor: Ruben.Cobos
' Fecha: 06-Abril-2014
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con los Titulos
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
    public class DATitulo : DABase
    {
        
       ///<remarks>
		///   <name>DATitulo.SelectTitulo</name>
		///   <create>06-Abril-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Titulos en base a los parámetros proporcionados</summary>
		///<param name="oENTTitulo">Entidad de Titulo con los parámetros necesarios para consultar la información</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectTitulo(ENTTitulo oENTTitulo, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspcatTitulo_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
         sqlPar = new SqlParameter("TituloId", SqlDbType.Int);
			sqlPar.Value = oENTTitulo.TituloId;
			sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTTitulo.Nombre;
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
