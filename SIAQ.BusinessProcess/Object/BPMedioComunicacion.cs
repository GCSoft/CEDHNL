using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPMedioComunicacion : BPBase
    {

		// Definiciones
        protected ENTMedioComunicacion _MedioComunicacionEntity;

		
		// Constructor

        public BPMedioComunicacion()
        {
            _MedioComunicacionEntity = new ENTMedioComunicacion();
        }

		
		// Propiedades

        public ENTMedioComunicacion MedioComunicacionEntity
        {
            get { return _MedioComunicacionEntity; }
            set { _MedioComunicacionEntity = value;}
        }

        
		// Métodos
		
		public DataSet SelectMedioComunicacion(){
            string ConnectionString = string.Empty;
            DAMedioComunicacion DAMedioComunicacion = new DAMedioComunicacion();
            ConnectionString = sConnectionApplication;
            _MedioComunicacionEntity.ResultData = DAMedioComunicacion.SelectMedioComunicacion(_MedioComunicacionEntity, ConnectionString);
            return _MedioComunicacionEntity.ResultData;
        }

        ///<remarks>
        ///   <name>BPcatMedioComunicacion.searchcatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catMedioComunicacion del sistema</summary>
        public ENTResponse searchcatMedioComunicacion(ENTMedioComunicacion entMedioComunicacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAMedioComunicacion datacatMedioComunicacion = new DAMedioComunicacion();
                oENTResponse = datacatMedioComunicacion.searchcatMedioComunicacion(entMedioComunicacion);
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
        ///   <name>BPcatMedioComunicacioninsertcatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catMedioComunicacion del sistema</summary>
        public ENTResponse insertcatMedioComunicacion(ENTMedioComunicacion entMedioComunicacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAMedioComunicacion datacatMedioComunicacion = new DAMedioComunicacion();
                oENTResponse = datacatMedioComunicacion.searchcatMedioComunicacion(entMedioComunicacion);
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
        ///   <name>BPcatMedioComunicacionupdatecatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catMedioComunicacion del sistema</summary>
        public ENTResponse updatecatMedioComunicacion(ENTMedioComunicacion entMedioComunicacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAMedioComunicacion datacatMedioComunicacion = new DAMedioComunicacion();
                oENTResponse = datacatMedioComunicacion.searchcatMedioComunicacion(entMedioComunicacion);
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
        ///   <name>BPcatMedioComunicaciondeletecatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catMedioComunicacion del sistema</summary>
        public ENTResponse deletecatMedioComunicacion(ENTMedioComunicacion entMedioComunicacion)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAMedioComunicacion datacatMedioComunicacion = new DAMedioComunicacion();
                oENTResponse = datacatMedioComunicacion.searchcatMedioComunicacion(entMedioComunicacion);
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
