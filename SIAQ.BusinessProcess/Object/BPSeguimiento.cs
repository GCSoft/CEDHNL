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
		///   <name>BPSeguimiento.DeleteRecomendacionComentario</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un comentario al Expediente en el módulo de Seguimientos</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimiento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteRecomendacionComentario(ENTSeguimiento oENTSeguimiento){
			DASeguimiento oDAExpediente = new DASeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.DeleteRecomendacionComentario(oENTSeguimiento, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPSeguimiento.InsertRecomendacionComentario</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario al Expediente en el módulo de Seguimientos</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimiento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacionComentario(ENTSeguimiento oENTSeguimiento){
			DASeguimiento oDAExpediente = new DASeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertRecomendacionComentario(oENTSeguimiento, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPSeguimiento.InsertRecomendacionFuncionario</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a un Expediente de Seguimiento</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimiento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacionFuncionario(ENTSeguimiento oENTSeguimiento){
			DASeguimiento oDAExpediente = new DASeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertRecomendacionFuncionario(oENTSeguimiento, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPSeguimiento.InsertRecomendacionGestion</name>
		///   <create>11-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea un nuevo registro de gestión sobre un Seguimiento de un punto resolutivo</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimiento con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacionGestion(ENTSeguimiento oENTSeguimiento){
			DASeguimiento oDAExpediente = new DASeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertRecomendacionGestion(oENTSeguimiento, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

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

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.SelectRecomendacion_Detalle</name>
		///   <create>14-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de una Recomendación en particular</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectRecomendacion_Detalle(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.SelectRecomendacion_Detalle(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.UpdateRecomendacion_EnvioAutoridad</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Inicia el proceso de envío de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_EnvioAutoridad(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.UpdateRecomendacion_EnvioAutoridad(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.UpdateRecomendacion_EnvioAutoridadCierre</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Finaliza el proceso de envío de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_EnvioAutoridadCierre(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.UpdateRecomendacion_EnvioAutoridadCierre(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.UpdateRecomendacion_ImpugnarDocumento</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Inicia el proceso de impugnación de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_ImpugnarDocumento(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.UpdateRecomendacion_ImpugnarDocumento(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.UpdateRecomendacion_ImpugnarDocumentoCierre</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Finaliza el proceso de impugnación de la recomendación/Acuerdo de no responsabilidad a una autoridad</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_ImpugnarDocumentoCierre(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.UpdateRecomendacion_ImpugnarDocumentoCierre(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.UpdateRecomendacion_Numero</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Actualiza el número de una recomendación</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_Numero(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.UpdateRecomendacion_Numero(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPSeguimiento.UpdateRecomendacion_PublicarDocumento</name>
		///   <create>12-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Envia una recomendación/Acuerdo de no responsabilidad a un estado de publicación</summary>
		///<param name="oENTSeguimiento">Entidad de Seguimientos con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateRecomendacion_PublicarDocumento(ENTSeguimiento oENTSeguimiento){
           DASeguimiento oDASeguimiento = new DASeguimiento();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDASeguimiento.UpdateRecomendacion_PublicarDocumento(oENTSeguimiento, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

              // Validación de mensajes de la BD
              oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

	}
}
