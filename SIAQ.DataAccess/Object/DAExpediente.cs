// Referencias
using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

// Referencias manuales
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAExpediente : DABase
    {
        Database dbs;
        public DAExpediente()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAExpediente.searchcatTipoSolicitud</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener los Expedientes del sistema</summary>
        public ENTResponse searchExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel", oENTExpediente.Numero, oENTExpediente.Ciudadano, oENTExpediente.MedioComunicacionId, oENTExpediente.FuncionarioId);
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }

        ///<remarks>
        ///   <name>DAExpediente.searchExpedienteDetalle</name>
        ///   <create>14/Marzo/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener el detalle de los Expedientes del sistema</summary>
        public ENTResponse searchExpedienteDetalle(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();

            oENTResponse.dsResponse = new DataSet();

            try
            {

                oENTResponse.dsResponse = dbs.ExecuteDataSet("spExpediente_selDetalle", oENTExpediente.ExpedienteId);

            }
            catch (SqlException sqlEx) { oENTResponse.ExceptionRaised(sqlEx.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAExpediente.insertExpediente</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar los Expedientes del sistema</summary>
        public ENTResponse insertExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }

        ///<remarks>
        ///   <name>DAExpediente.updateExpediente</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para actualizar los Expedientes del sistema</summary>
        public ENTResponse updateExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }

        ///<remarks>
        ///   <name>DAExpediente.deleteExpediente</name>
        ///   <create>19/feberero/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar los Expedientes del sistema</summary>
        public ENTResponse deleteExpediente(ENTExpediente oENTExpediente)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spExpediente_sel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }

    }
}
