using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;
namespace SIAQ.DataAccess.Object
{
    public class DAEstado : DABase
    {

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        public DAEstado()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAcatEstado.searchcatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstado del sistema</summary>
        public ENTResponse searchcatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catEstadoSel");
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
      ///   <name>DAEstado.SelectEstado</name>
      ///   <create>17-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene un listado de Estados en base a los parámetros proporcionados</summary>
      ///<param name="oENTEstado">Entidad de Estado con los parámetros necesarios para consultar la información</param>
      ///<param name="sConnection">Cadena de conexión a la base de datos</param>
      ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectEstado(ENTEstado oENTEstado, String sConnection, Int32 iAlternateDBTimeout){
         SqlConnection sqlCnn = new SqlConnection(sConnection);
         SqlCommand sqlCom;
         SqlParameter sqlPar;
         SqlDataAdapter sqlDA;

         ENTResponse oENTResponse = new ENTResponse();

         // Configuración de objetos
         sqlCom = new SqlCommand("uspcatEstado_Sel", sqlCnn);
         sqlCom.CommandType = CommandType.StoredProcedure;

         // Timeout alternativo en caso de ser solicitado
         if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

         // Parametros
         sqlPar = new SqlParameter("EstadoId", SqlDbType.Int);
         sqlPar.Value = oENTEstado.EstadoId;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("PaisId", SqlDbType.Int);
         sqlPar.Value = oENTEstado.PaisId;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
         sqlPar.Value = oENTEstado.Nombre;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Activo", SqlDbType.TinyInt);
         sqlPar.Value = oENTEstado.Activo;
         sqlCom.Parameters.Add(sqlPar);

         // Inicializaciones
         oENTResponse.dsResponse = new DataSet();
         sqlDA = new SqlDataAdapter(sqlCom);

         // Transacción
         try
         {
            sqlCnn.Open();
            sqlDA.Fill(oENTResponse.dsResponse);
            sqlCnn.Close();
         }catch (SqlException sqlEx){
            oENTResponse.ExceptionRaised(sqlEx.Message);
         }catch (Exception ex){
            oENTResponse.ExceptionRaised(ex.Message);
         }finally{
            if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
            sqlCnn.Dispose();
         }

         // Resultado
         return oENTResponse;
      }

        ///<remarks>
        ///   <name>DAcatEstado.insertcatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catEstado del sistema</summary>
        public ENTResponse insertcatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catEstadoIns");
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
        ///   <name>DAcatEstado.updatecatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catEstado del sistema</summary>
        public ENTResponse updatecatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catEstadoUpd");
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
        ///   <name>DAcatEstado.deletecatEstado</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catEstado del sistema</summary>
        public ENTResponse deletecatEstado(ENTEstado entEstado)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catEstadoDel");
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
