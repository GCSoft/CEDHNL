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
    public class DASolicitud : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

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

        public DASolicitud()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }

        ///<remarks>
        ///   <name>DASolicitud.searchSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las Solicitud del sistema</summary>
        public ENTResponse searchSolicitud(ENTSolicitud entSolicitud)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("SolicitudSel");
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
        ///   <name>DASolicitud.insertSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar Solicitud del sistema</summary>
        public ENTResponse insertSolicitud(ENTSolicitud oENTSolicitud)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();


            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("spSolicitud_Ins", oENTSolicitud.FuncinarioId, oENTSolicitud.CalificacionId, oENTSolicitud.TipoSolicitudId, oENTSolicitud.LugarHechosId, oENTSolicitud.EstatusId, oENTSolicitud.Numero, oENTSolicitud.Fecha, oENTSolicitud.Nombre, oENTSolicitud.Observaciones);
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
        ///   <name>DASolicitud.updateSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza Solicitud del sistema</summary>
        public ENTResponse updateSolicitud(ENTSolicitud entSolicitud)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("SolicitudUpd");
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
        ///   <name>DASolicitud.deleteSolicitud</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de Solicitud del sistema</summary>
        public ENTResponse deleteSolicitud(ENTSolicitud entSolicitud)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("SolicitudDel");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ENTSolicitud"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public DataSet SelectSolicitud(ENTSolicitud ENTSolicitud, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("ConsultarSolicitud", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                Parameter.Value = ENTSolicitud.Nombre;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("Numero", SqlDbType.TinyInt);
                Parameter.Value = ENTSolicitud.Numero;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("MedioComunicacionId", SqlDbType.TinyInt);
                Parameter.Value = ENTSolicitud.MedioComunicacion;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("FuncionarioId", SqlDbType.TinyInt);
                Parameter.Value = ENTSolicitud.FuncinarioId;
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
        
        /// <summary>
        ///     Busca las autoridades que están señaladas en una solicitud.
        /// </summary>
        /// <param name="ENTSolicitud">Entidad de solicitud.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        /// <returns>Resultado de la búsqueda.</returns>
        public DataSet SelectSolicitudAutoridad(ENTSolicitud ENTSolicitud, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("SelectSolicitudAutoridad", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = ENTSolicitud.SolicitudId;
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

        /// <summary>
        ///     Busca los ciudadanos que están relacionados a una solicitud.
        /// </summary>
        /// <param name="ENTSolicitud">Entidad de solicitud.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        /// <returns>Resultado de la búsqueda.</returns>
        public DataSet SelectSolicitudCiudadano(ENTSolicitud ENTSolicitud, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("SelectSolicitudCiudadano", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = ENTSolicitud.SolicitudId;
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

        /// <summary>
        ///     Busca el detalle completo de una solicitud.
        /// </summary>
        /// <param name="ENTSolicitud">Entidad de solicitud.</param>
        /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
        /// <returns>Resultado de la búsqueda.</returns>
        public DataSet SelectSolicitudDetalle(ENTSolicitud ENTSolicitud, string ConnectionString)
        {
            DataSet ResultData = new DataSet();
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("SelectSolicitudDetalle", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = ENTSolicitud.SolicitudId;
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
