/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPArchivoExpediente
' Autor: Ruben.Cobos
' Fecha: 12-Junio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Archivo
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

	public class BPArchivoExpediente : BPBase
	{

		///<remarks>
		///   <name>BPArchivoExpediente.InsertArchivoComentario</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario al Expediente en el módulo de Archivo</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertArchivoComentario(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.InsertArchivoComentario(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.InsertArchivoHistorial</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un registro en el historial del archivo</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoHistorial con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertArchivoHistorial(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.InsertArchivoHistorial(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.SelectArchivo</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el listado de Archivos listos para ser recibidos por el modulo de Archivo</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para consultar la información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectArchivo(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.SelectArchivo(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.SelectArchivo_Detalle</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene el detalle de un expediente en particular</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para consultar la información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectArchivo_Detalle(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.SelectArchivo_Detalle(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.SelectArchivo_Filtro</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene un listado de expedientes existentes en el sistema para el módulo de Archivos en base a los parámetros proporcionados</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para consultar la información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectArchivo_Filtro(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.SelectArchivo_Filtro(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.SelectUbicacionExpediente</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta el catálogo de Ubicacion de Expediente</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para consultar la información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectUbicacionExpediente(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.SelectUbicacionExpediente(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.UpdateArchivo_Liberar</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Libera un expediente dejándolo disponible para una nueva asignación dentro del módulo de Archivo</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateArchivo_Liberar(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.UpdateArchivo_Liberar(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
		///   <name>BPArchivoExpediente.UpdateArchivo_Recibir</name>
		///   <create>12-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Proceso de recepcion de expediete por parte del modulo de Archivo</summary>
		///<param name="oENTArchivoExpediente">Entidad de ArchivoExpediente con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateArchivo_Recibir(ENTArchivoExpediente oENTArchivoExpediente){
			DAArchivoExpediente oDAArchivoExpediente = new DAArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAArchivoExpediente.UpdateArchivo_Recibir(oENTArchivoExpediente, this.sConnectionApplication, 0);

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
