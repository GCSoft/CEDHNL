/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: DAOcupacion
' Autor: Daniel.Chavez
' Fecha: 11-Junio-2014
'
' Proposito:
'          Clase que modela la capa de capa de acceso a datos de la aplicación con métodos relacionados con las ocupaciones
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;

// Referencias Manuales
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
   public class DAOcupacion : DABase
    {
       protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;
        public DAOcupacion()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DAOcupacion.insertOcupacion</name>
        ///   <create>15/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las ocupaciones del sistema</summary>
        public DataSet SelectMotivo(ENTOcupacion oENTOcupacion, string ConnectionString)
        {

            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("uspcatOcupacion_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("OcupacionId", SqlDbType.Int);
                Parameter.Value = oENTOcupacion.OcupacionId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = oENTOcupacion.Nombre;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);
                ResultData = new DataSet();

                Connection.Open();
                DataAdapter.Fill(ResultData);
                Connection.Close();

                return ResultData;
            }
            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorDescription = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();

                return ResultData;
            }
        }

        ///<remarks>
        ///   <name>DAOcupacion.searchcatOcupacion</name>
        ///   <create>11/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las ocupaciones del sistema</summary>
        public ENTResponse searchcatOcupacion(ENTOcupacion oENTOcupacion, string ConnectionString)
        {

            SqlConnection sqlCnn = new SqlConnection(ConnectionString);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                sqlCom = new SqlCommand("uspcatOcupacion_Sel", sqlCnn);
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlPar = new SqlParameter("OcupacionId", SqlDbType.Int);
                sqlPar.Value = oENTOcupacion.OcupacionId;
                sqlCom.Parameters.Add(sqlPar);

                sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
                sqlPar.Value = oENTOcupacion.Nombre;
                sqlCom.Parameters.Add(sqlPar);

                sqlAdapter = new SqlDataAdapter(sqlCom);
                oENTResponse.dsResponse = new DataSet();

                sqlCnn.Open();
                sqlAdapter.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();


            }
            catch (SqlException sqlEX) { oENTResponse.ExceptionRaised(sqlEX.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally {
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAOcupacion.insertcatOcupacion</name>
        ///   <create>11/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo para insertar ocupaciones del sistema</summary>
        public ENTResponse insertcatOcupacion(ENTOcupacion oENTOcupacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatOcupacion_Ins", oENTOcupacion.Descripcion, oENTOcupacion.Nombre);
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
        ///   <name>DAMotivo.updateOcupacion</name>
        ///   <create>11/Junio/2014</create>
        ///   <author>Danie.Chavez</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Ocupacion del sistema</summary>
        public ENTResponse updateOcupacion(ENTOcupacion oENTOcupacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatOcupacion_Upd", oENTOcupacion.OcupacionId, oENTOcupacion.Descripcion, oENTOcupacion.Nombre);
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
        ///   <name>DAMotivo.deleteOcupacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de deleteMotivo del sistema</summary>
        public ENTResponse deleteOcupacion(ENTOcupacion oENTOcupacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("");
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
