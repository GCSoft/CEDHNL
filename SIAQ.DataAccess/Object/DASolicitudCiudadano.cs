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
    public class DASolicitudCiudadano : DABase
    {
        Database dbs;
        int _ErrorId;
        string _ErrorDescription;

        public DASolicitudCiudadano()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        ///<remarks>
        ///   <name>DAcatSolicitudCiudadano.searchcatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catSolicitudCiudadano del sistema</summary>
        public ENTResponse searchcatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catSolicitudCiudadanoSel");
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
        ///   <name>DAcatSolicitudCiudadano.insertcatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catSolicitudCiudadano del sistema</summary>
        public ENTResponse insertcatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catSolicitudCiudadanoIns");
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
        ///   <name>DAcatSolicitudCiudadano.updatecatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catSolicitudCiudadano del sistema</summary>
        public ENTResponse updatecatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catSolicitudCiudadanoUpd");
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
        ///   <name>DAcatSolicitudCiudadano.deletecatSolicitudCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catSolicitudCiudadano del sistema</summary>
        public ENTResponse deletecatSolicitudCiudadano(ENTSolicitudCiudadano entSolicitudCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catSolicitudCiudadanoDel");
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
        ///   <name>DAcatSolicitudCiudadano.SelectSolicitudesCiudadano</name>
        ///   <create>07/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona las Solicitudes relacionadas con un ciudadano en específico</summary>
        public DataSet SelectSolicitudesCiudadano(ENTSolicitudCiudadano oENTSolicitudCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spCiudadanoSolicitudes_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                Parameter.Value = oENTSolicitudCiudadano.CiudadanoId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return ds; 
        }

    }
}
