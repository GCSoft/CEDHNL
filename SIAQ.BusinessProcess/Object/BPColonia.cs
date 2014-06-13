using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPColonia : BPBase
    {

        protected ENTColonia _ColoniaEntity;

        public ENTColonia EstadoColonia
        {
            get { return _ColoniaEntity; }
            set { _ColoniaEntity = value; }
        }

        public BPColonia()
        {

            _ColoniaEntity = new ENTColonia();
        }

        ///<remarks>
        ///   <name>BPcatColonia.searchcatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catColonia del sistema</summary>
        public ENTResponse searchcatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.searchcatColonia(entColonia);
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
      ///   <name>BPCiudad.SelectColonia</name>
      ///   <create>17-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Colonias</summary>
      ///<param name="oENTEstado">Entidad de Estado con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectColonia(ENTColonia oENTColonia)
      {
         DAColonia oDAColonia = new DAColonia();
         ENTResponse oENTResponse = new ENTResponse();

         try
         {

            // Transacción en base de datos
            oENTResponse = oDAColonia.SelectColonia(oENTColonia, this.sConnectionApplication, 0);

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
        ///   <name>BPcatColoniainsertcatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catColonia del sistema</summary>
        public ENTResponse insertcatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.insertcatColonia(entColonia);
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
        ///   <name>BPcatColoniaupdatecatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catColonia del sistema</summary>
        public ENTResponse updatecatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.updatecatColonia(entColonia);
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
        ///   <name>BPcatColonia.updatecatColonia_Estatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catColonia del sistema</summary>
        public ENTResponse updatecatColonia_Estatus(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.updatecatColonia_Estatus(entColonia);
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
        ///   <name>BPcatColoniadeletecatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catColonia del sistema</summary>
        public ENTResponse deletecatColonia(ENTColonia entColonia)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAColonia datacatColonia = new DAColonia();
                oENTResponse = datacatColonia.searchcatColonia(entColonia);
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
