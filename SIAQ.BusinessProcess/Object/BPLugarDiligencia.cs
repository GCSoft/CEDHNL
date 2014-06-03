using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
	public class BPLugarDiligencia : BPBase
	{
        protected ENTLugarDiligencia _ENTLugarDiligencia;

        public ENTLugarDiligencia ENTLugarDiligencia
        {
            get { return _ENTLugarDiligencia; }
            set { _ENTLugarDiligencia = value; }
        }

        public BPLugarDiligencia()
        {

            _ENTLugarDiligencia = new ENTLugarDiligencia();
        }

		///<remarks>
        ///   <name>BPLugarDiligencia.searchLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Metodo para obtener las catPais del sistema</summary>
        public ENTResponse searchLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{

			ENTResponse oENTResponse = new ENTResponse();
			try
			{
				// Consulta a base de datos
                DALugarDiligencia oDALugarDiligencia = new DALugarDiligencia();
                oENTResponse = oDALugarDiligencia.searchLugarDiligencia(oENTLugarDiligencia);
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
        ///   <name>BPLugarDiligencia.SelectLugarDiligencia</name>
        ///   <create>17-Marzo-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Consulta el catálogo de Paises</summary>
        ///<param name="oENTPais">Entidad de LugarDiligencia con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
        {
            DALugarDiligencia oDALugarDiligencia = new DALugarDiligencia();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
               oENTResponse = oDALugarDiligencia.SelectLugarDiligencia(oENTLugarDiligencia, this.sConnectionApplication, 0);

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
        ///   <name>BPLugarDiligencia.insertLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
        ///<summary>Metodo para insertar LugarDiligencia del sistema</summary>
        public ENTResponse insertLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{

			ENTResponse oENTResponse = new ENTResponse();
			try
			{
				// Consulta a base de datos
                DALugarDiligencia oDALugarDiligencia = new DALugarDiligencia();
                oENTResponse = oDALugarDiligencia.insertLugarDiligencia(oENTLugarDiligencia);
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
        ///   <name>BPLugarDiligencia.updateLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
        ///<summary>Metodo que actualiza LugarDiligencia del sistema</summary>
        public ENTResponse updateLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{

			ENTResponse oENTResponse = new ENTResponse();
			try
			{
				// Consulta a base de datos
                DALugarDiligencia oDALugarDiligencia = new DALugarDiligencia();
                oENTResponse = oDALugarDiligencia.updateLugarDiligencia(oENTLugarDiligencia);
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
        ///   <name>BPLugarDiligencia.updateLugarDiligencia_Estatus</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
        ///<summary>Metodo que actualiza LugarDiligencia del sistema</summary>
        public ENTResponse updateLugarDiligencia_Estatus(ENTLugarDiligencia oENTLugarDiligencia)
		{
            DALugarDiligencia oDALugarDiligencia = new DALugarDiligencia();
			ENTResponse oENTResponse = new ENTResponse();
			try
			{
				// Consulta a base de datos
                oENTResponse = oDALugarDiligencia.updateLugarDiligencia_Estatus(oENTLugarDiligencia, this.sConnectionApplication, 0);
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
        ///   <name>BPLugarDiligencia.deleteLugarDiligencia</name>
		///   <create>27/ene/2014</create>
		///   <author>Generador</author>
		///</remarks>
        ///<summary>Metodo para eliminar de LugarDiligencia del sistema</summary>
        public ENTResponse deleteLugarDiligencia(ENTLugarDiligencia oENTLugarDiligencia)
		{

			ENTResponse oENTResponse = new ENTResponse();
			try
			{
				// Consulta a base de datos
                DALugarDiligencia oDALugarDiligencia = new DALugarDiligencia();
                oENTResponse = oDALugarDiligencia.searchLugarDiligencia(oENTLugarDiligencia);
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
	}
}
