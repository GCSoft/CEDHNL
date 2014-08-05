/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPVisitaduria
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Visitaduría
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
	public class BPVisitaduria : BPBase
	{

		///<remarks>
		///   <name>BPVisitaduria.SelectExpediente</name>
		///   <create>04-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Expedientees de Visitadurias en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías de Visitadurias con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpediente(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectExpediente(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.SelectExpediente_Filtro</name>
		///   <create>04-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Expedientes de Visitadurías en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad del Expediente de Visitadurías con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpediente_Filtro(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectExpediente_Filtro(oENTVisitaduria, this.sConnectionApplication, 0);

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
