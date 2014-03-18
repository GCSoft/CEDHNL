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
    public class DAColonia : DABase
    {

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        public DAColonia()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAcatColonia.searchcatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catColonia del sistema</summary>
        public ENTResponse searchcatColonia(ENTColonia entColonia)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catColoniaSel");
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
      ///   <name>DAColonia.SelectColonia</name>
      ///   <create>17-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene un listado de Colonias en base a los parámetros proporcionados</summary>
      ///<param name="oENTEstado">Entidad de Colonia con los parámetros necesarios para consultar la información</param>
      ///<param name="sConnection">Cadena de conexión a la base de datos</param>
      ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectColonia(ENTColonia oENTColonia, String sConnection, Int32 iAlternateDBTimeout){
         SqlConnection sqlCnn = new SqlConnection(sConnection);
         SqlCommand sqlCom;
         SqlParameter sqlPar;
         SqlDataAdapter sqlDA;

         ENTResponse oENTResponse = new ENTResponse();

         // Configuración de objetos
         sqlCom = new SqlCommand("uspcatColonia_Sel", sqlCnn);
         sqlCom.CommandType = CommandType.StoredProcedure;

         // Timeout alternativo en caso de ser solicitado
         if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

         // Parametros
         sqlPar = new SqlParameter("ColoniaId", SqlDbType.Int);
         sqlPar.Value = oENTColonia.ColoniaId;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("CiudadId", SqlDbType.Int);
         sqlPar.Value = oENTColonia.CiudadId;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
         sqlPar.Value = oENTColonia.Nombre;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Activo", SqlDbType.TinyInt);
         sqlPar.Value = oENTColonia.Activo;
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
        ///   <name>DAcatColonia.insertcatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catColonia del sistema</summary>
        public ENTResponse insertcatColonia(ENTColonia entColonia)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catColoniaIns");
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
        ///   <name>DAcatColonia.updatecatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catColonia del sistema</summary>
        public ENTResponse updatecatColonia(ENTColonia entColonia)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catColoniaUpd");
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
        ///   <name>DAcatColonia.deletecatColonia</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catColonia del sistema</summary>
        public ENTResponse deletecatColonia(ENTColonia entColonia)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catColoniaDel");
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
