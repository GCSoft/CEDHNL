using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAVocesSenaladas : DABase
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
        ///   <name>DAVocesSenaladas.SelectNivelesVoces</name>
        ///   <create>09/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Selecciona las Voces para llenado de Combobox
        /// </summary>
        public DataSet SelectNivelesVoces(ENTVocesSenaladas oENTVocesSenaladas, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spNivelesVoces_selForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("VozIdPadre1", SqlDbType.Int);
                Parameter.Value = oENTVocesSenaladas.VozIdPadrePrimerNivel;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("VozIdPadre2", SqlDbType.Int);
                Parameter.Value = oENTVocesSenaladas.VozIdPadreSegundoNivel;
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
        ///   <name>DAVocesSenaladas.SelectListaVocesAutoridad</name>
        ///   <create>09/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Selecciona las Voces seleccionadas para una autoridad 
        /// </summary>
        public DataSet SelectListaVocesAutoridad(ENTVocesSenaladas oENTVocesSenaladas, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spListaVocesSenaladas_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                Parameter.Value = oENTVocesSenaladas.SolicitudId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
                Parameter.Value = oENTVocesSenaladas.AutoridadId;
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
        ///   <name>DAVocesSenaladas.InsertSolicitudAutoridadVoces</name>
        ///   <create>09/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Agrega voces a la autoridad señalada
        /// </summary>
        public ENTResponse InsertSolicitudAutoridadVoces(ENTVocesSenaladas oENTVocesSenaladas, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spSolicitudAutoridadVoces_ins", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
            Parameter.Value = oENTVocesSenaladas.SolicitudId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
            Parameter.Value = oENTVocesSenaladas.AutoridadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("VozId", SqlDbType.Int);
            Parameter.Value = oENTVocesSenaladas.VozId;
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
        ///   <name>DAVocesSenaladas.DeleteSolicitudAutoridadVoces</name>
        ///   <create>09/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        /// <summary>
        /// Elimina voces de la autoridad
        /// </summary>
        public ENTResponse DeleteSolicitudAutoridadVoces(ENTVocesSenaladas oENTVocesSenaladas, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("SolicitudAutoridadVoces_del", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
            Parameter.Value = oENTVocesSenaladas.SolicitudId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("AutoridadId", SqlDbType.Int);
            Parameter.Value = oENTVocesSenaladas.AutoridadId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("VozId", SqlDbType.Int);
            Parameter.Value = oENTVocesSenaladas.VozId;
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


        #endregion

    }
}
