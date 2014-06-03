using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPCiudad : BPBase
    {

        protected ENTCiudad _CiudadEntity;

        public ENTCiudad EstadoCiudad
        {
            get { return _CiudadEntity; }
            set { _CiudadEntity = value; }
        }

        public BPCiudad()
        {

            _CiudadEntity = new ENTCiudad();
        }

        ///<remarks>
        ///   <name>BPcatCiudad.searchcatCiudad</name>
        ///   <create>27/ene/2014 </create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCiudad del sistema</summary>
        public ENTResponse searchcatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.searchcatCiudad(entCiudad);
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
        ///   <name>BPCiudad.SelectCiudad</name>
        ///   <create>17-Marzo-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Consulta el catálogo de Ciudades</summary>
        ///<param name="oENTEstado">Entidad de Estado con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectCiudad(ENTCiudad oENTCiudad)
        {
           DACiudad oDACiudad = new DACiudad();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

              // Transacción en base de datos
              oENTResponse = oDACiudad.SelectCiudad(oENTCiudad, this.sConnectionApplication, 0);

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
        ///   <name>BPcatCiudadinsertcatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catCiudad del sistema</summary>
        public ENTResponse insertcatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.insertcatCiudad(entCiudad);
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
        ///   <name>BPcatCiudadupdatecatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCiudad del sistema</summary>
        public ENTResponse updatecatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.updatecatCiudad(entCiudad);
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
        ///   <name>BPcatCiudad.updatecatCiudad_Estatus</name>
        ///   <create>31/Mayo/2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCiudad del sistema</summary>
        public ENTResponse updatecatCiudad_Estatus(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.updatecatCiudad_Estatus(entCiudad);
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
        ///   <name>BPcatCiudaddeletecatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catCiudad del sistema</summary>
        public ENTResponse deletecatCiudad(ENTCiudad entCiudad)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DACiudad datacatCiudad = new DACiudad();
                oENTResponse = datacatCiudad.searchcatCiudad(entCiudad);
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
