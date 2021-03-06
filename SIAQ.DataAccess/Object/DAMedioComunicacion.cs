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
    public class DAMedioComunicacion : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;
        public DAMedioComunicacion()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>DAcatMedioComunicacion.searchcatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catMedioComunicacion del sistema</summary>
        public ENTResponse searchcatMedioComunicacion(ENTMedioComunicacion entMedioComunicacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spcatMedioComunicacion_Sel");
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
        ///   <name>DAcatMedioComunicacion.insertcatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catMedioComunicacion del sistema</summary>
        public ENTResponse insertcatMedioComunicacion(ENTMedioComunicacion oENTMedioComunicacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatMedioComunicacion_Ins", oENTMedioComunicacion.Descripcion, oENTMedioComunicacion.Nombre);
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
        ///   <name>DAcatMedioComunicacion.updatecatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catMedioComunicacion del sistema</summary>
        public ENTResponse updatecatMedioComunicacion(ENTMedioComunicacion oENTMedioComunicacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatMedioComunicacion_Upd", oENTMedioComunicacion.MedioComunicacionId, oENTMedioComunicacion.Descripcion, oENTMedioComunicacion.Nombre);
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
       

        public DataSet SelectMedioComunicacion(ENTMedioComunicacion ENTMedioComunicacion, string ConnectionString)
        {

            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("sptblMedioComunicacion_Sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("MedioComunicacionId", SqlDbType.Int);
                Parameter.Value = ENTMedioComunicacion.MedioComunicacionId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTMedioComunicacion.Nombre;
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
        ///   <name>DAcatMedioComunicacion.selecthcatMedioComunicacion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catMedioComunicacion del sistema</summary>
        public ENTResponse selectcatMedioComunicacion(ENTMedioComunicacion oENTMedioComunicacion)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspcatMedioComunicacion_Sel", oENTMedioComunicacion.MedioComunicacionId, oENTMedioComunicacion.Nombre);
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
