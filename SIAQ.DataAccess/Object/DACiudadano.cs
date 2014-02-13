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
    public class DACiudadano : DABase
    {

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;
        public DACiudadano()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        /// <summary>
        ///     Número de error ocurrido. Cero por default//
        /// </summary>
        public int ErrorId//
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        /// <summary>
        ///     Descripción del error ocurrido
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }
        ///<remarks>
        ///   <name>DACiudadano.searchCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las Ciudadano del sistema</summary>
        public ENTResponse searchCiudadano(ENTCiudadano entCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spCiudadano_Search", entCiudadano.Nombre);
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
        ///   <name>DACiudadano.insertCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar Ciudadano del sistema</summary>
        public ENTResponse insertCiudadano(ENTCiudadano entCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("CiudadanoIns");
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
        ///   <name>DACiudadano.updateCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Ciudadano del sistema</summary>
        public ENTResponse updateCiudadano(ENTCiudadano entCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("CiudadanoUpd");
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
        ///   <name>DACiudadano.deleteCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de Ciudadano del sistema</summary>
        public ENTResponse deleteCiudadano(ENTCiudadano entCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("CiudadanoDel");
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
        public DataSet SelectCiudadano(ENTCiudadano ENTCiudadano, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("ConsultarCiudadano", Connection);//falta nombre stored
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTCiudadano.Nombre;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                Parameter.Value = ENTCiudadano.ApellidoPaterno;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                Parameter.Value = ENTCiudadano.ApellidoMaterno;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("ColoniaId", SqlDbType.VarChar);
                Parameter.Value = ENTCiudadano.ColoniaId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Calle", SqlDbType.VarChar);
                Parameter.Value = ENTCiudadano.Calle;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("CampoBusqueda", SqlDbType.VarChar);
                Parameter.Value = ENTCiudadano.CampoBusqueda;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

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
    }
}
