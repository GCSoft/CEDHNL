/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPSeguimiento
' Autor: Ruben.Cobos
' Fecha: 11-Septiembre-2014
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
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
	public class BPSeguimiento : BPBase
	{

		///<remarks>
		///   <name>BPSeguimiento.SelectRecomendacion</name>
		///   <create>11-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Recomendaciones en base a los parámetros proporcionados</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacion(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.SelectRecomendacion(oENTSeguimiento, this.sConnectionApplication, 0);

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

		///<remarks>
		///   <name>BPSeguimiento.SelectRecomendacion_Filtro</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Recomendaciones en base a los parámetros proporcionados utilizado en la pantalla de búsqueda</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacion_Filtro(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.SelectRecomendacion_Filtro(oENTSeguimiento, this.sConnectionApplication, 0);

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
