/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPServidorPublico
' Autor: Ruben.Cobos
' Fecha: 25-Agosto-2014
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con los Servidores Públicos
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
	public class BPServidorPublico : BPBase
	{

		///<remarks>
		///   <name>BPServidorPublico.InsertServidorPublico</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta un Servidor Publico</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertServidorPublico(ENTServidorPublico oENTServidorPublico){
			DAServidorPublico oDAServidorPublico = new DAServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAServidorPublico.InsertServidorPublico(oENTServidorPublico, this.sConnectionApplication, 0);

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
		///   <name>BPServidorPublico.SelectServidorPublico_ASService</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Motor de consulta del servicio de autosuggest</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la consulta</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectServidorPublico_ASService(ENTServidorPublico oENTServidorPublico){
			DAServidorPublico oDAServidorPublico = new DAServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAServidorPublico.SelectServidorPublico_ASService(oENTServidorPublico, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>BPServidorPublico.SelectServidorPublicoByID</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta la información de un Servidor Publico en base a su ID</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la consulta</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectServidorPublicoByID(ENTServidorPublico oENTServidorPublico){
			DAServidorPublico oDAServidorPublico = new DAServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAServidorPublico.SelectServidorPublicoByID(oENTServidorPublico, this.sConnectionApplication, 0);

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
		///   <name>BPServidorPublico.UpdateServidorPublico</name>
		///   <create>25-Agosto-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Actualiza la información de un Servidor Publico</summary>
		///<param name="oENTServidorPublico">Entidad de Servidor Publico con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateServidorPublico(ENTServidorPublico oENTServidorPublico){
			DAServidorPublico oDAServidorPublico = new DAServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAServidorPublico.UpdateServidorPublico(oENTServidorPublico, this.sConnectionApplication, 0);

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
