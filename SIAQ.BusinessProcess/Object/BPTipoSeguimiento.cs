/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPTipoSeguimiento
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con los TipoSeguimientoes
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
using System.Data;
using System.Web;

namespace SIAQ.BusinessProcess.Object
{

	public class BPTipoSeguimiento : BPBase
	{

		///<remarks>
		///   <name>BPTipoSeguimiento.SelectTipoSeguimiento</name>
		///   <create>06-Junio-2014</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Consulta el catálogo de TipoSeguimientos y obtiene un listado en base a los parámetros proporcionados<</summary>
		///<param name="oENTTipoSeguimiento">Entidad de TipoSeguimiento con los filtros necesarios para la consulta</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectTipoSeguimiento(ENTTipoSeguimiento oENTTipoSeguimiento){
			DATipoSeguimiento oDATipoSeguimiento = new DATipoSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDATipoSeguimiento.SelectTipoSeguimiento(oENTTipoSeguimiento, this.sConnectionApplication, 0);

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
