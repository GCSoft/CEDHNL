﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPTipoResolucion
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el catálogo de Tipo de Resolución
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
    public class BPTipoResolucion : BPBase
    {
       
		///<remarks>
		///   <name>BPTipoResolucion.SelectTipoResolucion</name>
		///   <create>30-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Tipo de Resolución en base a los parámetros proporcionados</summary>
		///<param name="oENTTipoResolucion">Entidad de Tipo de Resolución con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectTipoResolucion(ENTTipoResolucion oENTTipoResolucion){
           DATipoResolucion oDATipoResolucion = new DATipoResolucion();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDATipoResolucion.SelectTipoResolucion(oENTTipoResolucion, this.sConnectionApplication, 0);

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
