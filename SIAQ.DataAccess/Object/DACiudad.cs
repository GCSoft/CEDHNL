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
    public class DACiudad : DABase
    {

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        public DACiudad()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAcatCiudad.searchcatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catCiudad del sistema</summary>
        public ENTResponse searchcatCiudad(ENTCiudad entCiudad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCiudadSel");
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
      ///   <name>DACiudad.SelectCiudad</name>
      ///   <create>17-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene un listado de Ciudades en base a los parámetros proporcionados</summary>
      ///<param name="oENTEstado">Entidad de Estado con los parámetros necesarios para consultar la información</param>
      ///<param name="sConnection">Cadena de conexión a la base de datos</param>
      ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectCiudad(ENTCiudad oENTCiudad, String sConnection, Int32 iAlternateDBTimeout){
         SqlConnection sqlCnn = new SqlConnection(sConnection);
         SqlCommand sqlCom;
         SqlParameter sqlPar;
         SqlDataAdapter sqlDA;

         ENTResponse oENTResponse = new ENTResponse();

         // Configuración de objetos
         sqlCom = new SqlCommand("uspcatCiudad_Sel", sqlCnn);
         sqlCom.CommandType = CommandType.StoredProcedure;

         // Timeout alternativo en caso de ser solicitado
         if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

         // Parametros
         sqlPar = new SqlParameter("CiudadId", SqlDbType.Int);
         sqlPar.Value = oENTCiudad.CiudadId;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("EstadoId", SqlDbType.Int);
         sqlPar.Value = oENTCiudad.EstadoId;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
         sqlPar.Value = oENTCiudad.Nombre;
         sqlCom.Parameters.Add(sqlPar);

         sqlPar = new SqlParameter("Activo", SqlDbType.TinyInt);
         sqlPar.Value = oENTCiudad.Activo;
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
        ///   <name>DAcatCiudad.insertcatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catCiudad del sistema</summary>
        public ENTResponse insertcatCiudad(ENTCiudad entCiudad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catCiudadIns");
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
        ///   <name>DAcatCiudad.updatecatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catCiudad del sistema</summary>
        public ENTResponse updatecatCiudad(ENTCiudad entCiudad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catCiudadUpd");
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
        ///   <name>DAcatCiudad.deletecatCiudad</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catCiudad del sistema</summary>
        public ENTResponse deletecatCiudad(ENTCiudad entCiudad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catCiudadDel");
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
