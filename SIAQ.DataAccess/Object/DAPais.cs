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
    public class DAPais : DABase
    {

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        public DAPais()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAcatPais.searchcatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catPais del sistema</summary>
        public ENTResponse searchcatPais(ENTPais entPais)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catPaisSel");
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
        ///   <name>DAPais.SelectPais</name>
        ///   <create>17-Marzo-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene un listado de Paises en base a los parámetros proporcionados</summary>
        ///<param name="oENTPais">Entidad de Pais con los parámetros necesarios para consultar la información</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectPais(ENTPais oENTPais, String sConnection, Int32 iAlternateDBTimeout){
           SqlConnection sqlCnn = new SqlConnection(sConnection);
           SqlCommand sqlCom;
           SqlParameter sqlPar;
           SqlDataAdapter sqlDA;

           ENTResponse oENTResponse = new ENTResponse();

           // Configuración de objetos
           sqlCom = new SqlCommand("uspcatPais_Sel", sqlCnn);
           sqlCom.CommandType = CommandType.StoredProcedure;

           // Timeout alternativo en caso de ser solicitado
           if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

           // Parametros
           sqlPar = new SqlParameter("PaisId", SqlDbType.Int);
           sqlPar.Value = oENTPais.PaisId;
           sqlCom.Parameters.Add(sqlPar);

           sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
           sqlPar.Value = oENTPais.Nombre;
           sqlCom.Parameters.Add(sqlPar);

           sqlPar = new SqlParameter("Activo", SqlDbType.TinyInt);
           sqlPar.Value = oENTPais.Activo;
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
        ///   <name>DAcatPais.insertcatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catPais del sistema</summary>
        public ENTResponse insertcatPais(ENTPais entPais)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catPaisIns");
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
        ///   <name>DAcatPais.updatecatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catPais del sistema</summary>
        public ENTResponse updatecatPais(ENTPais entPais)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catPaisUpd");
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
        ///   <name>DAcatPais.deletecatPais</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catPais del sistema</summary>
        public ENTResponse deletecatPais(ENTPais entPais)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catPaisDel");
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