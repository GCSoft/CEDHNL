// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Referencias manuales
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
using System.Data;
using System.Web;

namespace SIAQ.BusinessProcess.Object
{
   public class BPOcupacion : BPBase
    {
       protected ENTOcupacion _OcupacionEntity;

       public ENTOcupacion Ocupacion
       {
           get { return _OcupacionEntity; }
           set { _OcupacionEntity = value; }
       }

       public BPOcupacion()
       {
           _OcupacionEntity = new ENTOcupacion();
       }

       public DataSet SelectOcupacion(ENTOcupacion oENTOcupacion)
       {
           string ConnectionString = string.Empty;
           DAOcupacion oDAOcupacion = new DAOcupacion();
           ConnectionString = sConnectionApplication;
           _OcupacionEntity.ResultData = oDAOcupacion.SelectMotivo(_OcupacionEntity, ConnectionString);
           return _OcupacionEntity.ResultData;
       }

       ///<remarks>
       ///   <name>BPOcupacion.searchcatOcupacion</name>
       ///   <create>11/Junio/2014 </create>
       ///   <author>Daniel.Chavez</author>
       ///</remarks>
       ///<summary>Metodo para obtener las Ocupaciones del sistema</summary>
       public ENTResponse searchcatOcupacion(ENTOcupacion oENTOcupacion)
       {

           ENTResponse oENTResponse = new ENTResponse();
           try
           {
               // Consulta a base de datos
               DAOcupacion oDAOcupacion = new DAOcupacion();
               oENTResponse = oDAOcupacion.searchcatOcupacion(oENTOcupacion, sConnectionApplication);
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
       ///   <name>BPOcupacion.insertOcupacion</name>
       ///   <create>11/Junio/2014 </create>
       ///   <author>Daniel.Chavez</author>
       ///</remarks>
       ///<summary>Metodo para insertar Ocupaciones del sistema</summary>
       public ENTResponse insertOcupacion(ENTOcupacion oENTOcupacion)
       {

           ENTResponse oENTResponse = new ENTResponse();
           try
           {
               // Consulta a base de datos
               DAOcupacion oDAOcupacion = new DAOcupacion();
               oENTResponse = oDAOcupacion.insertcatOcupacion(oENTOcupacion);
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
       ///   <name>BPOcupacion.updateOcupacion</name>
       ///   <create>11/Junio/2014 </create>
       ///   <author>Daniel.Chavez</author>
       ///</remarks>
       ///<summary>Metodo que actualiza Ocupaciones del sistema</summary>
       public ENTResponse updateOcupacion(ENTOcupacion oENTOcupacion)
       {

           ENTResponse oENTResponse = new ENTResponse();
           try
           {
               // Consulta a base de datos
               DAOcupacion oDAOcupacion = new DAOcupacion();
               oENTResponse = oDAOcupacion.updateOcupacion(oENTOcupacion);
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
