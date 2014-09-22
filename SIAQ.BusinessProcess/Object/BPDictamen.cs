/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPDictamen
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con los Dictamenes Médicos
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
    public class BPDictamen : BPBase
    {

		///<remarks>
		///   <name>BPTipoDictamen.InsertDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea un nuevo dictamen a un ciudadano en el modulo de atención a víctimas</summary>
		///<param name="oENTTipoDictamen">Entidad de Dictamen con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertDictamen(ENTDictamen oENTDictamen){
			DADictamen oDADictamen = new DADictamen();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADictamen.InsertDictamen(oENTDictamen, this.sConnectionApplication, 0);

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
		///   <name>BPTipoDictamen.SelectLugarAtencion</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Lugares de Atención del dictamen en base a los parámetros proporcionados</summary>
		///<param name="oENTTipoDictamen">Entidad de Dictamen con los filtros necesarios para la consulta</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectLugarAtencion(ENTDictamen oENTDictamen){
			DADictamen oDADictamen = new DADictamen();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADictamen.SelectLugarAtencion(oENTDictamen, this.sConnectionApplication, 0);

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
		///   <name>BPResolucionDictamen.SelectResolucionDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Tipos de Dictámenes en base a los parámetros proporcionados</summary>
		///<param name="oENTResolucionDictamen">Entidad de Dictamen con los filtros necesarios para la consulta</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectResolucionDictamen(ENTDictamen oENTDictamen){
			DADictamen oDADictamen = new DADictamen();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADictamen.SelectResolucionDictamen(oENTDictamen, this.sConnectionApplication, 0);

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
		///   <name>BPTipoDictamen.SelectTipoDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de Tipos de Dictámenes en base a los parámetros proporcionados</summary>
		///<param name="oENTTipoDictamen">Entidad de Dictamen con los filtros necesarios para la consulta</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectTipoDictamen(ENTDictamen oENTDictamen){
			DADictamen oDADictamen = new DADictamen();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADictamen.SelectTipoDictamen(oENTDictamen, this.sConnectionApplication, 0);

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
		///   <name>BPTipoDictamen.UpdateDictamen</name>
		///   <create>20-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza el dictamen a un ciudadano en el modulo de atención a víctimas</summary>
		///<param name="oENTTipoDictamen">Entidad de Dictamen con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateDictamen(ENTDictamen oENTDictamen){
			DADictamen oDADictamen = new DADictamen();
			ENTResponse oENTResponse = new ENTResponse();

			try{

			// Transacción en base de datos
			oENTResponse = oDADictamen.UpdateDictamen(oENTDictamen, this.sConnectionApplication, 0);

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
