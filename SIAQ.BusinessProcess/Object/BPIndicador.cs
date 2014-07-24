/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPIndicador
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Indicadores
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
	public class BPIndicador : BPBase
    {

		///<remarks>
		///   <name>BPIndicador.SelectIndicador</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Indicadores en base a los parámetros proporcionados</summary>
		///<param name="oENTIndicador">Entidad de Indicador con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectIndicador(ENTIndicador oENTIndicador){
           DAIndicador oDAIndicador = new DAIndicador();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAIndicador.SelectIndicador(oENTIndicador, this.sConnectionApplication, 0);

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
