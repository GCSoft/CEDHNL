/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPRecomendacion
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las recomendaciones a un Expediente
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
    public class BPRecomendacion: BPBase 
    {

		///<remarks>
		///   <name>BPRecomendacion.SelectTipoRecomendacion</name>
		///   <create>31-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteRecomendacion(ENTRecomendacion oENTRecomendacion){
			DARecomendacion oDARecomendacion = new DARecomendacion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				oENTResponse = oDARecomendacion.DeleteRecomendacion(oENTRecomendacion, sConnectionApplication, 0);

				if (oENTResponse.GeneratesException) { return oENTResponse; }

				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPRecomendacion.InsertRecomendacion</name>
		///   <create>31-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertRecomendacion(ENTRecomendacion oENTRecomendacion){
			DARecomendacion oDARecomendacion = new DARecomendacion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				oENTResponse = oDARecomendacion.InsertRecomendacion(oENTRecomendacion, sConnectionApplication, 0);

				if (oENTResponse.GeneratesException) { return oENTResponse; }

				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPRecomendacion.SelectRecomendacion_ByID</name>
		///   <create>31-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectRecomendacion_ByID(ENTRecomendacion oENTRecomendacion){
			DARecomendacion oDARecomendacion = new DARecomendacion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				oENTResponse = oDARecomendacion.SelectRecomendacion_ByID(oENTRecomendacion, sConnectionApplication, 0);

				if (oENTResponse.GeneratesException) { return oENTResponse; }

				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPRecomendacion.UpdateRecomendacion</name>
		///   <create>31-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza una Recomendacion para un Expediente</summary>
		///<param name="oENTRecomendacion">Entidad de Tipo de Recomendación con los parámetros necesarios para la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateRecomendacion(ENTRecomendacion oENTRecomendacion){
			DARecomendacion oDARecomendacion = new DARecomendacion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{
				oENTResponse = oDARecomendacion.UpdateRecomendacion(oENTRecomendacion, sConnectionApplication, 0);

				if (oENTResponse.GeneratesException) { return oENTResponse; }

				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			//Resultado
			return oENTResponse;
		}

    }
}
