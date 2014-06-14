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
        ///   <name>DACiudadano.SelectDetalleCiudadano</name>
        ///   <create>04/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona los detalles del ciudadano en específico del sistema para el llenado de controles</summary>
        public DataSet SelectDetalleCiudadano(ENTCiudadano oENTCiudadano, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();
            SqlParameter Parameter;

            try
            {
                Command = new SqlCommand("spDetalleCiudadanoEditar_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
                Parameter.Value = oENTCiudadano.CiudadanoId;
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

        ///<remarks>
        ///   <name>DACiudadano.InsertCiudadano</name>
        ///   <create>04/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Inserta ciudadanos en el sistema</summary>
        public ENTResponse InsertCiudadano(ENTCiudadano oENTCiudadano, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spCiudadanos_ins", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("SexoId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.SexoId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("EstadoCivilId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.EstadoCivilId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ColoniaId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.ColoniaId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("CiudadOrigenId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.CiudadOrigenId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("NacionalidadId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.NacionalidadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("EscolaridadId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.EscolaridadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("OcupacionId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.OcupacionId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("MedioComunicacionId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.MedioComunicacionId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.Nombre;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.ApellidoPaterno;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.ApellidoMaterno;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
            Parameter.Value = oENTCiudadano.FechaNacimiento;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Calle", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.Calle;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("NumeroExterior", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.NumeroExterior;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("NumeroInterior", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.NumeroInterior;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("TelefonoPrincipal", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.TelefonoPrincipal;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("TelefonoOtro", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.TelefonoOtro;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("CorreoElectronico", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.CorreoElectronico;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AniosResidiendoNL", SqlDbType.TinyInt);
            Parameter.Value = oENTCiudadano.AniosResidiendoNL;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("DependientesEconomicos", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.DependientesEconomicos;
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

        ///<remarks>
        ///   <name>DACiudadano.InsertCiudadano</name>
        ///   <create>04/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Modifica ciudadanos en el sistema</summary>
        public ENTResponse UpdateCiudadano(ENTCiudadano oENTCiudadano, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spCiudadanos_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("CiudadanoId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.CiudadanoId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("SexoId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.SexoId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("EstadoCivilId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.EstadoCivilId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ColoniaId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.ColoniaId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("CiudadOrigenId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.CiudadOrigenId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("NacionalidadId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.NacionalidadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("EscolaridadId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.EscolaridadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("OcupacionId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.OcupacionId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("MedioComunicacionId", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.MedioComunicacionId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.Nombre;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.ApellidoPaterno;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.ApellidoMaterno;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
            Parameter.Value = oENTCiudadano.FechaNacimiento;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Calle", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.Calle;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("NumeroExterior", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.NumeroExterior;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("NumeroInterior", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.NumeroInterior;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("TelefonoPrincipal", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.TelefonoPrincipal;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("TelefonoOtro", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.TelefonoOtro;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("CorreoElectronico", SqlDbType.VarChar);
            Parameter.Value = oENTCiudadano.CorreoElectronico;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AniosResidiendoNL", SqlDbType.TinyInt);
            Parameter.Value = oENTCiudadano.AniosResidiendoNL;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("DependientesEconomicos", SqlDbType.Int);
            Parameter.Value = oENTCiudadano.DependientesEconomicos;
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
        ///<remarks>
        ///   <name>DACiudadano.searchCiudadano</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las Ciudadano del sistema</summary>
        public ENTResponse searchCiudadanoAtencion(ENTCiudadano entCiudadano)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("uspSearchCiudadanoAtencionSel", entCiudadano.AtencionId);
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
