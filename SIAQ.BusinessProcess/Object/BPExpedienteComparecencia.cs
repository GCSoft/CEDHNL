/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPExpedienteComparecencia
' Autor: Ruben.Cobos
' Fecha: 12-Junio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Comparecencias del Expediente
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
    public class BPExpedienteComparecencia : BPBase
    {

		///<remarks>
		///   <name>BPExpedienteComparecencia.DeleteExpedienteComparecencia</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina una Comparecencia</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Comparecencia con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteExpedienteComparecencia(ENTExpedienteComparecencia oENTExpedienteComparecencia){
			DAExpedienteComparecencia oDAExpedienteComparecencia = new DAExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpedienteComparecencia.DeleteExpedienteComparecencia(oENTExpedienteComparecencia, this.sConnectionApplication, 0);

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
		///   <name>BPExpedienteComparecencia.InsertExpedienteComparecencia</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una Comparecencia</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Comparecencia con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteComparecencia(ENTExpedienteComparecencia oENTExpedienteComparecencia){
			DAExpedienteComparecencia oDAExpedienteComparecencia = new DAExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpedienteComparecencia.InsertExpedienteComparecencia(oENTExpedienteComparecencia, this.sConnectionApplication, 0);

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
		///   <name>BPExpedienteComparecencia.SelectExpedienteComparecenciaByID</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta una Comparecencia en base a su ID</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Comparecencia con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectExpedienteComparecenciaByID(ENTExpedienteComparecencia oENTExpedienteComparecencia){
			DAExpedienteComparecencia oDAExpedienteComparecencia = new DAExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpedienteComparecencia.SelectExpedienteComparecenciaByID(oENTExpedienteComparecencia, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPExpedienteComparecencia.UpdateExpedienteComparecencia</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza una Comparecencia</summary>
		///<param name="oENTExpedienteComparecencia">Entidad de Comparecencia con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateExpedienteComparecencia(ENTExpedienteComparecencia oENTExpedienteComparecencia){
			DAExpedienteComparecencia oDAExpedienteComparecencia = new DAExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpedienteComparecencia.UpdateExpedienteComparecencia(oENTExpedienteComparecencia, this.sConnectionApplication, 0);

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
