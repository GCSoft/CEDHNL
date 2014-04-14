using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAAutoridad : DABase
    {

        #region Atributos

        private int _ErrorId;
        private string _ErrorDescription;

        #endregion

        #region Propiedades

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

        #endregion

        #region Funciones

        ///<remarks>
        ///   <name>DAAutoridad.SelectNivelesAutoridad</name>
        ///   <create>08/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona las Autoridades para llenado de Combobox</summary>
        public DataSet SelectNivelesAutoridad(ENTAutoridad oENTAutoridad, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spNivelesAutoridad_selForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("AutoridadIdPadre1", SqlDbType.Int);
                Parameter.Value = oENTAutoridad.AutoridadIdPadrePrimerNivel;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("AutoridadIdPadre2", SqlDbType.Int);
                Parameter.Value = oENTAutoridad.AutoridadIdPadreSegundoNivel;
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
        ///   <name>DAAutoridad.SelectListaAutoridadesSolicitud</name>
        ///   <create>08/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona las Autoridades seleccionadas para una solicitud</summary>
        public DataSet SelectListaAutoridadesSolicitud(ENTAutoridad oENTAutoridad, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spListaAutoridadSeleccionada_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = oENTAutoridad.SolicitudId;
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
        ///   <name>DAAutoridad.SelectDetalleAutoridadesSolicitud</name>
        ///   <create>14/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el detalle de una autoridad agregada</summary>
        public DataSet SelectDetalleAutoridadesSolicitud(ENTAutoridad oENTAutoridad, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spSolicitudAutoridadDetalle_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = oENTAutoridad.SolicitudId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
                Parameter.Value = oENTAutoridad.AutoridadId;
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
        ///   <name>DAAutoridad.DeleteSolicitudAutoridad</name>
        ///   <create>08/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Elimina autoridades de la solicitud</summary>
        public ENTResponse DeleteSolicitudAutoridad(ENTAutoridad oENTAutoridad, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spAutoridadSolicitud_del", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
            Parameter.Value = oENTAutoridad.SolicitudId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
            Parameter.Value = oENTAutoridad.AutoridadId;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAAutoridad.InsertSolicitudAutoridad</name>
        ///   <create>08/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Agrega autoridades de la solicitud</summary>
        public ENTResponse InsertSolicitudAutoridad(ENTAutoridad oENTAutoridad, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spAutoridadSolicitud_ins", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
            Parameter.Value = oENTAutoridad.SolicitudId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
            Parameter.Value = oENTAutoridad.AutoridadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
            Parameter.Value = oENTAutoridad.Nombre;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Puesto", SqlDbType.VarChar);
            Parameter.Value = oENTAutoridad.Puesto;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Comentarios", SqlDbType.VarChar);
            Parameter.Value = oENTAutoridad.Comentario;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAAutoridad.UpdateSolicitudAutoridad</name>
        ///   <create>14/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Modificar el nombre, puesto y comentarios de una autoridad agregada a la solicitud</summary>
        public ENTResponse UpdateSolicitudAutoridad(ENTAutoridad oENTAutoridad, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spSolicitudAutoridad_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
            Parameter.Value = oENTAutoridad.SolicitudId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
            Parameter.Value = oENTAutoridad.AutoridadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
            Parameter.Value = oENTAutoridad.Nombre;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Puesto", SqlDbType.VarChar);
            Parameter.Value = oENTAutoridad.Puesto;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Comentarios", SqlDbType.VarChar);
            Parameter.Value = oENTAutoridad.Comentario;
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
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }
            }

            return oENTResponse;
        }

        #endregion

    }
}
