﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DATipoRecomendacion
' Autor: Ruben.Cobos
' Fecha: 31-Agosto-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con los Tipos de Recomendación
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
    public class DATipoRecomendacion : DABase
    {
        
		///<remarks>
		///   <name>DATipoRecomendacion.SelectTipoRecomendacion</name>
		///   <create>31-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Tipo de Recomendación en base a los parámetros proporcionados</summary>
		///<param name="oENTTipoRecomendacion">Entidad de Tipo de Recomendación con los filtros necesarios para la consulta</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectTipoRecomendacion( ENTTipoRecomendacion oENTTipoRecomendacion, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspTipoRecomendacion_Sel", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("TipoRecomendacionId", SqlDbType.Int);
			sqlPar.Value = oENTTipoRecomendacion.TipoRecomendacionId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTTipoRecomendacion.Nombre;
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
