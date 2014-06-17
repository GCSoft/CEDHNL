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

		#region Logica Original
		
			///<remarks>
			///   <name>BPAtencion.searchAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para obtener las Atencion del sistema</summary>
			public ENTResponse searchAtencionDetalle(ENTAtencion entAtencion)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DAAtencion dataAtencion = new DAAtencion();
					oENTResponse = dataAtencion.searchAtencionDetalle(entAtencion);
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
			///   <name>BPAtencioninsertAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para insertar Atencion del sistema</summary>
			public ENTResponse insertAtencion(ENTAtencion entAtencion)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DAAtencion dataAtencion = new DAAtencion();
					//oENTResponse = dataAtencion.searchAtencion(entAtencion);
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
			///   <name>BPAtencioninsertAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para insertar Atencion del sistema</summary>
			public ENTResponse insertAtencionObservaciones(ENTAtencion entAtencion)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DAAtencion dataAtencion = new DAAtencion();
					oENTResponse = dataAtencion.insertAtencionObservaciones(entAtencion);
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
			///   <name>BPAtencionupdateAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo que actualiza Atencion del sistema</summary>
			public ENTResponse updateAtencion(ENTAtencion entAtencion)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DAAtencion dataAtencion = new DAAtencion();
					//oENTResponse = dataAtencion.searchAtencion(entAtencion);
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
			///   <name>BPAtenciondeleteAtencion</name>
			///   <create>04/jun/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para eliminar de Atencion del sistema</summary>
			public ENTResponse deleteAtencion(ENTAtencion entAtencion)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DAAtencion dataAtencion = new DAAtencion();
					//oENTResponse = dataAtencion.searchAtencion(entAtencion);
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

		#endregion

		///<remarks>
		///   <name>BPPais.SelectAtencion</name>
        ///   <create>17-Marzo-2014</create>
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
		///   <name>BPPais.SelectAtencion_Filtro</name>
        ///   <create>17-Marzo-2014</create>
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

	}
}
