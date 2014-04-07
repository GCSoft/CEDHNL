/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPTitulo
' Autor: Ruben.Cobos
' Fecha: 06-Abril-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con los Titulos
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
    public class BPTitulo : BPBase
    {
       
       ///<remarks>
      ///   <name>BPTitulo.SelectTitulo</name>
      ///   <create>06-Abril-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Titulos</summary>
      ///<param name="oENTTitulo">Entidad de Titulo con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectTitulo(ENTTitulo oENTTitulo){
         DATitulo oDATitulo = new DATitulo();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDATitulo.SelectTitulo(oENTTitulo, this.sConnectionApplication, 0);

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
