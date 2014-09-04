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
		///   <name>BPVisitaduria.DeleteExpedienteComentario</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un comentario asociado a un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteExpedienteComentario(ENTVisitaduria oENTVisitaduria){
			DAVisitaduria oDAExpediente = new DAVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.DeleteExpedienteComentario(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.InsertExpedienteCalificacionDefinitiva</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta o actualiza la calificación definitiva del expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteCalificacionDefinitiva(ENTVisitaduria oENTVisitaduria){
			DAVisitaduria oDAExpediente = new DAVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertExpedienteCalificacionDefinitiva(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.InsertExpedienteComentario</name>
		///   <create>19-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario al Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteComentario(ENTVisitaduria oENTVisitaduria){
			DAVisitaduria oDAExpediente = new DAVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertExpedienteComentario(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.InsertExpedienteFuncionario</name>
		///   <create>17-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a una Expediente de Visitadurias</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteFuncionario(ENTVisitaduria oENTVisitaduria){
			DAVisitaduria oDAExpediente = new DAVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertExpedienteFuncionario(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.InsertExpedienteResolucion</name>
		///   <create>30-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta o actualiza la resolución del expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertExpedienteResolucion(ENTVisitaduria oENTVisitaduria){
			DAVisitaduria oDAExpediente = new DAVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAExpediente.InsertExpedienteResolucion(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.SelectCalificacionAutoridad</name>
		///   <create>27-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Calificaciones de Autoridad en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectCalificacionAutoridad(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectCalificacionAutoridad(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.SelectExpediente</name>
		///   <create>04-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Expedientes de Visitadurias en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
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
		///   <name>BPVisitaduria.SelectExpedienteAutoridad</name>
		///   <create>02-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de autoridades asociadas a un expediente en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpedienteAutoridad(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectExpedienteAutoridad(oENTVisitaduria, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPVisitaduria.SelectExpedienteAutoridad_Detalle</name>
		///   <create>27-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de una autoridad asociada a un expediente en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpedienteAutoridad_Detalle(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectExpedienteAutoridad_Detalle(oENTVisitaduria, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPVisitaduria.SelectExpedienteAutoridadVoces</name>
		///   <create>27-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene las voces asociadas a una autoridad de un expediente en base a los parámetros proporcionados</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpedienteAutoridadVoces(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectExpedienteAutoridadVoces(oENTVisitaduria, this.sConnectionApplication, 0);

              // Validación de error en consulta
              if (oENTResponse.GeneratesException) { return oENTResponse; }

           }catch (Exception ex){
              oENTResponse.ExceptionRaised(ex.Message);
           }

           // Resultado
           return oENTResponse;
        }

		///<remarks>
		///   <name>BPVisitaduria.SelectExpediente_Detalle</name>
		///   <create>15-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de un Expedientes de Visitadurias en específico</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectExpediente_Detalle(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.SelectExpediente_Detalle(oENTVisitaduria, this.sConnectionApplication, 0);

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

		///<remarks>
		///   <name>BPVisitaduria.UpdateExpedienteAutoridad</name>
		///   <create>27-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Actualiza la información de una Autoridad señalada en particular de un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateExpedienteAutoridad(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.UpdateExpedienteAutoridad(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.UpdateExpedienteAutoridadVoces</name>
		///   <create>28-Agosto-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Actualiza la información de las Voces de una Autoridad señalada en particular de un Expediente</summary>
		///<param name="oENTVisitaduria">Entidad de Visitadurías con los filtros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateExpedienteAutoridadVoces(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.UpdateExpedienteAutoridadVoces(oENTVisitaduria, this.sConnectionApplication, 0);

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
		///   <name>BPVisitaduria.UpdateExpedienteEstatus</name>
		///   <create>03-Septiembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Cambia el estatus de un una Expediente de Visitadurias</summary>
		///<param name="oENTVisitaduria">Entidad de Visitaduria con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateExpedienteEstatus(ENTVisitaduria oENTVisitaduria){
           DAVisitaduria oDAVisitaduria = new DAVisitaduria();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAVisitaduria.UpdateExpedienteEstatus(oENTVisitaduria, this.sConnectionApplication, 0);

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
