using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPAtencion : BPBase
    {

		///<remarks>
		///   <name>BPAtencion.DeleteAtencion</name>
		///   <create>29-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina una solicitud de Atención a Víctimas existente</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteAtencion(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.DeleteAtencion(oENTAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.InsertAtencion</name>
		///   <create>29-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una nueva solicitud de Atención a Víctimas</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertAtencion(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.InsertAtencion(oENTAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.InsertAtencionComentario</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un comentario al Expediente de Atención a Víctimas</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertAtencionComentario(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.InsertAtencionComentario(oENTAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.InsertAtencionDoctor</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva asignación de un funcionario a un Expediente de Atención a Víctimas</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertAtencionDoctor(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.InsertAtencionDoctor(oENTAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.InsertClimaLaboral</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva sesión de Clima Laboral en el módulo de Atención a Víctimas</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertClimaLaboral(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.InsertClimaLaboral(oENTAtencion, this.sConnectionApplication, 0);

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
        ///   <name>BPAtencion.RptIntegralVictimas</name>
        ///   <create>14-Nviembre-2014</create>
        ///   <author>JJGonzalez</author>
        ///</remarks>
        ///<summary>Reporte de Atn Víctimas</summary>
        ///<param name="oENTQuejas">Entidad de Atenion con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse RptIntegralVictimas(ENTAtencion oENTAtencion)
        {
            DAAtencion oDAAtencion = new DAAtencion();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAAtencion.RptIntegralVictimas(oENTAtencion, this.sConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }

            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

		///<remarks>
		///   <name>BPAtencion.SelectAtencion</name>
        ///   <create>17-Junio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Expedientes de Atención a Víctimas en base a los parámetros proporcionados</summary>
		///<param name="entAtencion">Entidad del Expediente de Atención a Víctimas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectAtencion(ENTAtencion entAtencion){
           DAAtencion oDAAtencion = new DAAtencion();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAAtencion.SelectAtencion(entAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.SelectAtencion_Detalle</name>
		///   <create>19-Junio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de un Expediente de Atención a Víctimas específico</summary>
		///<param name="entAtencion">Entidad del Expediente de Atención a Víctimas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectAtencion_Detalle(ENTAtencion entAtencion){
           DAAtencion oDAAtencion = new DAAtencion();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAAtencion.SelectAtencion_Detalle(entAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.SelectAtencion_Detalle_ById</name>
		///   <create>19-Junio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene el detalle de una solicitud de atención a víctimas</summary>
		///<param name="entAtencion">Entidad del Expediente de Atención a Víctimas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectAtencion_Detalle_ById(ENTAtencion entAtencion){
           DAAtencion oDAAtencion = new DAAtencion();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAAtencion.SelectAtencion_Detalle_ById(entAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.SelectAtencion_Filtro</name>
		///   <create>17-Junio-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
		///<summary>Obtiene un listado de Expedientes de Atención a Víctimas en base a los parámetros proporcionados</summary>
		///<param name="entAtencion">Entidad del Expediente de Atención a Víctimas con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectAtencion_Filtro(ENTAtencion entAtencion){
           DAAtencion oDAAtencion = new DAAtencion();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
			   oENTResponse = oDAAtencion.SelectAtencion_Filtro(entAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.UpdateAtencion</name>
		///   <create>29-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza una solicitud de Atención a Víctimas existente</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateAtencion(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.UpdateAtencion(oENTAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.UpdateAtencion_Estatus</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Cambia el estatus de un Expediente de Atencion a Víctimas</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateAtencion_Estatus(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.UpdateAtencion_Estatus(oENTAtencion, this.sConnectionApplication, 0);

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
		///   <name>BPAtencion.UpdateAtencion_NumeroFolio</name>
		///   <create>29-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza el Folio de una solicitud de Atención a Víctimas</summary>
		///<param name="entAtencion">Entidad de Atención a Víctimas con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateAtencion_NumeroFolio(ENTAtencion oENTAtencion){
			DAAtencion oDAAtencion = new DAAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAAtencion.UpdateAtencion_NumeroFolio(oENTAtencion, this.sConnectionApplication, 0);

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
