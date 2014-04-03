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
        public int ErrorId
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

        public void AgregarCiudadanoSolicitud(ENTCiudadano ENTCiudadano, string ConnectionString)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("InsertarCiudadanoSolicitud", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.CiudadanoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.SolicitudId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("TipoCiudadanoId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.TipoCiudadanoId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }

            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorDescription = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
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
                Command = new SqlCommand("ConsultarCiudadano", Connection);
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

                Parameter = new SqlParameter("ColoniaId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.ColoniaId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("CiudadId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.CiudadId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("EstadoId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.EstadoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("PaisId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.PaisId;
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

        public void EliminarCiudadanoSolicitud(ENTCiudadano ENTCiudadano, string ConnectionString)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("EliminarCiudadanoSolicitud", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.CiudadanoId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = ENTCiudadano.SolicitudId;
                Command.Parameters.Add(Parameter);

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
            }

            catch (SqlException Exception)
            {
                _ErrorId = Exception.Number;
                _ErrorDescription = Exception.Message;

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        public DataSet SelectCiudadanosAgregados(ENTCiudadano ENTCiudadano, string ConnectionString)
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
                Parameter.Value = ENTCiudadano.SolicitudId;
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

        ///<remarks>
        ///   <name>DACiudadano.SelectComboEscolaridad</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las escolaridades del sistema</summary>
        public DataSet SelectComboEscolaridad(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spcatEscolaridad_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboEstadoCivil</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener los estados civiles del sistema</summary>
        public DataSet SelectComboEstadoCivil(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spcatEstadoCivil_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboSexo</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener los sexos del sistema</summary>
        public DataSet SelectComboSexo(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spcatSexo_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboOcupacion</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las ocupaciones del sistema</summary>
        public DataSet SelectComboOcupacion(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spcatOcupacion_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboFormaContacto</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las formas de contacto del sistema</summary>
        public DataSet SelectComboFormaContacto(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spcatFormaContacto_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboColonia</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las colonias del sistema</summary>
        public DataSet SelectComboColonia(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spcatColonia_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("CiudadId", SqlDbType.Int);
                Parameter.Value = oENTCiudadano.CiudadId;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboEstado</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener los estados del sistema</summary>
        public DataSet SelectComboEstado(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spEstado_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("PaisId", SqlDbType.Int);
                Parameter.Value = oENTCiudadano.PaisId;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboCiudad</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las ciudades del sistema</summary>
        public DataSet SelectComboCiudad(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spCiudad_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("EstadoId", SqlDbType.Int);
                Parameter.Value = oENTCiudadano.EstadoId;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return ds;
        }
        

        ///<remarks>
        ///   <name>DACiudadano.SelectComboNacionalidad</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las nacionalidades del sistema</summary>
        public ENTResponse SelectComboNacionalidad(ENTCiudadano oENTCiudadano, string ConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spcatNacionalidad_SelForControl", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException ex) { oENTResponse.ExceptionRaised(ex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboPais</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener los países del sistema</summary>
        public ENTResponse SelectComboPais(ENTCiudadano oENTCiudadano, string ConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spcatPais_SelForControl", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException ex) { oENTResponse.ExceptionRaised(ex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DACiudadano.SelectComboCiudad</name>
        ///   <create>03/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener las ciudades del sistema</summary>
        public ENTResponse SelectComboCiudad(ENTCiudadano oENTCiudadano, string ConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spcatCiudad_SelForControl", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("EstadoId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.EstadoId;
            Command.Parameters.Add(Parameter);

            oENTResponse.dsResponse = new DataSet();
            DataAdapter = new SqlDataAdapter(Command);

            try
            {
                Connection.Open();
                DataAdapter.Fill(oENTResponse.dsResponse);
                Connection.Close();
            }
            catch (SqlException ex) { oENTResponse.ExceptionRaised(ex.Message); }
            catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return oENTResponse;
        }
    }
}
