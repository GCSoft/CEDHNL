/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPQueja
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el módulo de Quejas
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
	public class BPQueja : BPBase
	{

		///<remarks>
		///   <name>BPQueja.CreateFolio</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea un nuevo folio para un expediente</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse CreateFolio(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.CreateFolio(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.DeleteSolicitudCiudadano</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina la asociación de un ciudadano a la solicitud de una Queja</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteSolicitudCiudadano(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.DeleteSolicitudCiudadano(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.InsertExpediente</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea un nuevo expediente en base a la solicitud</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpediente(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.InsertExpediente(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.InsertSolicitudCiudadano</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Asocia un nuevo ciudadano a la solicitud de una Queja</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitudCiudadano(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.InsertSolicitudCiudadano(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.InsertSolicitudComentario</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario a la solicitud de una Queja</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitudComentario(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.InsertSolicitudComentario(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.InsertSolicitudFuncionario</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a una Solicitud de Quejas</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitudFuncionario(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.InsertSolicitudFuncionario(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.InsertSolicitudIndicador</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta el listado de Indicadores asociados a la solicitud de una Queja</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitudIndicador(ENTQueja oENTQueja){
			DAQueja oDASolicitud = new DAQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.InsertSolicitudIndicador(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectMecanismoApertura</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Mecanismos de Apertura de Solicitudes en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectMecanismoApertura(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectMecanismoApertura(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectNivelAutoridad</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Nivel de Autoridads de Solicitudes en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectNivelAutoridad(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectNivelAutoridad(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectProblematica</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Problematicas de Solicitudes en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectProblematica(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectProblematica(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectProblematicaDetalle</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Detalle de Problematicas de Solicitudes en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectProblematicaDetalle(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectProblematicaDetalle(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectSolicitud</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Solicitudes de Quejas en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectSolicitud(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectSolicitud_Cierre</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de una Solicitud de Quejas en específica la cual se cerrará</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud_Cierre(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectSolicitud_Cierre(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectSolicitud_Detalle</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de una Solicitud de Quejas en específica</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud_Detalle(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectSolicitud_Detalle(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.SelectSolicitud_Filtro</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Solicitudes de Quejas en base a los parámetros proporcionados</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectSolicitud_Filtro(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.SelectSolicitud_Filtro(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.UpdateSolicitud</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Actualiza la información general de una solicitud de Quejas</summary>
		///<param name="oENTQueja">Entidad del Expediente de Solicitud de Quejas con los filtros necesarios para la actualización</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateSolicitud(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.UpdateSolicitud(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.UpdateSolicitudCalificacion</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Actualiza la calificación de una solicitud de una Queja</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateSolicitudCalificacion(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.UpdateSolicitudCalificacion(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.UpdateSolicitudCalificacion</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Actualiza la información de asociación de un ciudadano en particular que pertenece a una solicitud de una Queja</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateSolicitudCiudadano(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.UpdateSolicitudCiudadano(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.UpdateSolicitudCapturaDiligencia</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Activa/Inactiva la bandera de captura de diligencias. Un cero determina que no se capturarán y un uno el caso contrario. Si se inhabilita se eliminan las capturas</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateSolicitudCapturaDiligencia(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.UpdateSolicitudCapturaDiligencia(oENTQueja, this.sConnectionApplication, 0);

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
		///   <name>BPQueja.UpdateSolicitudEstatus</name>
		///   <create>17-Julio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Cambia el estatus de un una Solicitud de Quejas</summary>
		///<param name="oENTQueja">Entidad de Queja con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateSolicitudEstatus(ENTQueja oENTQueja){
           DAQueja oDAQueja = new DAQueja();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAQueja.UpdateSolicitudEstatus(oENTQueja, this.sConnectionApplication, 0);

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
