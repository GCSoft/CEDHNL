/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPTipoRecomendacion
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
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoRecomendacion : BPBase
    {
        
		///<remarks>
		///   <name>BPTipoRecomendacion.SelectTipoRecomendacion</name>
		///   <create>31-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Tipo de Recomendación en base a los parámetros proporcionados</summary>
		///<param name="oENTTipoRecomendacion">Entidad de Tipo de Recomendación con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectTipoRecomendacion(ENTTipoRecomendacion oENTTipoRecomendacion){
			DATipoRecomendacion oDATipoRecomendacion = new DATipoRecomendacion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDATipoRecomendacion.SelectTipoRecomendacion(oENTTipoRecomendacion, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
        }

    }
}
