using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
using System.Data;
using System.Web;

namespace SIAQ.BusinessProcess.Object
{
    public class BPMotivo : BPBase
    {
       protected ENTMotivo _MotivoEntity;

       public ENTMotivo Motivo
       {
           get { return _MotivoEntity; }
           set { _MotivoEntity = value; }
       }

       public BPMotivo()
       {
           _MotivoEntity = new ENTMotivo();
       }

       public DataSet SelectMotivo()
       {
           string ConnectionString = string.Empty;
           DAMotivo DAMotivo = new DAMotivo();
           ConnectionString = sConnectionApplication;
           _MotivoEntity.ResultData = DAMotivo.SelectMotivo(_MotivoEntity, ConnectionString);
           return _MotivoEntity.ResultData;
       }

       ///<remarks>
       ///   <name>BPMotivo.searchcatMotivo</name>
       ///   <create>27/ene/2014 </create>
       ///   <author>Generador</author>
       ///</remarks>
       ///<summary>Metodo para obtener las Motivo del sistema</summary>
       public ENTResponse searchcatMotivo(ENTMotivo oENTMotivo)
       {

           ENTResponse oENTResponse = new ENTResponse();
           try
           {
               // Consulta a base de datos
               DAMotivo oDAMotivo = new DAMotivo();
               oENTResponse = oDAMotivo.searchcatMotivo(oENTMotivo, sConnectionApplication);
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
       ///   <name>BPMotivo.insertMotivo</name>
       ///   <create>27/ene/2014</create>
       ///   <author>Generador</author>
       ///</remarks>
       ///<summary>Metodo para insertar Motivo del sistema</summary>
       public ENTResponse insertMotivo(ENTMotivo oENTMotivo)
       {

           ENTResponse oENTResponse = new ENTResponse();
           try
           {
               // Consulta a base de datos
               DAMotivo oDAMotivo = new DAMotivo();
               oENTResponse = oDAMotivo.insertMotivo(oENTMotivo);
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
       ///   <name>BPMotivo.updateMotivo</name>
       ///   <create>27/ene/2014</create>
       ///   <author>Generador</author>
       ///</remarks>
       ///<summary>Metodo que actualiza Motivo del sistema</summary>
       public ENTResponse updateMotivo(ENTMotivo oENTMotivo)
       {

           ENTResponse oENTResponse = new ENTResponse();
           try
           {
               // Consulta a base de datos
               DAMotivo oDAMotivo = new DAMotivo();
               oENTResponse = oDAMotivo.updateMotivo(oENTMotivo);
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
