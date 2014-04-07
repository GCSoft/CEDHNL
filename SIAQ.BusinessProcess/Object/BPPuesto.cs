/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPPuesto
' Autor: Ruben.Cobos
' Fecha: 06-Abril-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con los Puestos
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
   
   public class BPPuesto : BPBase
   {

      ///<remarks>
      ///   <name>BPPuesto.SelectPuesto</name>
      ///   <create>06-Abril-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Puestos</summary>
      ///<param name="oENTPuesto">Entidad de Puesto con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectPuesto(ENTPuesto oENTPuesto){
         DAPuesto oDAPuesto = new DAPuesto();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDAPuesto.SelectPuesto(oENTPuesto, this.sConnectionApplication, 0);

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
