/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPArea
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con las Compañías
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

   public class BPArea : BPBase
   {
       protected ENTArea _AreaEntity;

       public ENTArea Area
       {
           get { return _AreaEntity; }
           set { _AreaEntity = value; }
       }

       public BPArea()
       {
           _AreaEntity = new ENTArea();
       }

       public DataSet SelectArea()
       {
           string ConnectionString = string.Empty;
           DAArea DAArea = new DAArea();
           ConnectionString = sConnectionApplication;
           _AreaEntity.ResultData = DAArea.SelectArea(_AreaEntity, ConnectionString);
           return _AreaEntity.ResultData;
       }

      ///<remarks>
		///   <name>BPArea.InsertArea</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Actualiza la información de una Compañia</summary>
		///<param name="oENTArea">Entidad de Area con los parámetros necesarios para actualizar su información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertArea(ENTArea oENTArea){
			DAArea oDAArea = new DAArea();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAArea.InsertArea(oENTArea, this.sConnectionApplication, 0);

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
      ///   <name>BPArea.SelectArea</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Compañías</summary>
      ///<param name="oENTArea">Entidad de Area con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectArea(ENTArea oENTArea){
         DAArea oDAArea = new DAArea();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDAArea.SelectArea(oENTArea, this.sConnectionApplication, 0);

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
      ///   <name>BPArea.UpdateArea</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Actualiza la información de un Compañía</summary>
      ///<param name="oENTArea">Entidad de Area con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateArea(ENTArea oENTArea){
			DAArea oDAArea = new DAArea();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAArea.UpdateArea(oENTArea, this.sConnectionApplication, 0);

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
      ///   <name>BPArea.UpdateArea_Estatus</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Activa/inactiva un Area</summary>
      ///<param name="oENTArea">Entidad de Compañía con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateArea_Estatus(ENTArea oENTArea){
			DAArea oDAArea = new DAArea();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
            oENTResponse = oDAArea.UpdateArea_Estatus(oENTArea, this.sConnectionApplication, 0);

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
