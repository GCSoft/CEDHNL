using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DADiligencia : DABase
    {

        #region Atributos

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        #endregion

        #region Propiedades

        public DADiligencia()
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

        #endregion

        #region Funciones

        ///<remarks>
        ///   <name>DADiliencia.SelectTipoDiligencias</name>
        ///   <create>30/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona el listado de tipo de diligencias para llenado del combobox</summary>
        public DataSet SelectTipoDiligencias(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spTipoDiligencias_sel", Connection);
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
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DADiliencia.SelectLugarDiligencias</name>
        ///   <create>31/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Selecciona el listado de los lugares de diligencias para llenado del combobox</summary>
        public DataSet SelectLugarDiligencias(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spLugarDiligencia_sel", Connection);
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
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return ds;
        }

        ///<remarks>
        ///   <name>DADiliencia.SelectDiligencias</name>
        ///   <create>31/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el listado de las diligencias de solicitudes, expedientes y recomendaciones</summary>
        public DataSet SelectDiligencias(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spDiligencias_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("Id", SqlDbType.Int);
                Parameter.Value = oENTDiligencia.SolicitudId;
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

        ///<remarks>
        ///   <name>DADiliencia.SelectDetalleDiligencia</name>
        ///   <create>01/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Muestra los datos de la diligencia seleccionada</summary>
        public DataSet SelectDetalleDiligenciaExpediente(ENTDiligencia oENTDiligencia, string ConnectionString)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spDetalleDiligenciaExpediente_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Parameter = new SqlParameter("DiligenciaId", SqlDbType.Int);
                Parameter.Value = oENTDiligencia.DiligenciaId;
                Command.Parameters.Add(Parameter);

                Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
                Parameter.Value = oENTDiligencia.ExpedienteId;
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
        ///   <name>DADiliencia.InsertDiligenciaExpediente</name>
        ///   <create>01/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Crea una nueva diligencia para un expediente</summary>
        public ENTResponse InsertDiligenciaExpediente(ENTDiligencia oENTDiligencia, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spDiligenciaExpediente_ins", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FuncionarioAtiende", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.FuncionarioAtiendeId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FuncionarioEjecuta", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.FuncionarioEjecuta;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FechaDiligencia", SqlDbType.DateTime);
            Parameter.Value = oENTDiligencia.FechaDiligencia;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("TipoDiligencia", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.TipoDiligencia;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("LugarDiligencia", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.LugarDiligenciaId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
            Parameter.Value = oENTDiligencia.Detalle;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("SolicitadaPor", SqlDbType.VarChar);
            Parameter.Value = oENTDiligencia.SolicitadaPor;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Resultado", SqlDbType.VarChar);
            Parameter.Value = oENTDiligencia.Resultado;
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
        ///   <name>DADiliencia.UpdateDiligenciaExpediente</name>
        ///   <create>01/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Modifica una diligencia para un expediente</summary>
        public ENTResponse UpdateDiligenciaExpediente(ENTDiligencia oENTDiligencia, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlParameter Parameter;
            SqlDataAdapter DataAdapter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spDiligenciaExpediente_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("DiligenciaId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.DiligenciaId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FuncionarioEjecuta", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.FuncionarioEjecuta;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("FechaDiligencia", SqlDbType.DateTime);
            Parameter.Value = oENTDiligencia.FechaDiligencia;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("TipoDiligenciaId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.TipoDiligencia;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("LugarDiligenciaId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.LugarDiligenciaId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Detalle", SqlDbType.VarChar);
            Parameter.Value = oENTDiligencia.Detalle;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("SolicitadaPor", SqlDbType.VarChar);
            Parameter.Value = oENTDiligencia.SolicitadaPor;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Resultado", SqlDbType.VarChar);
            Parameter.Value = oENTDiligencia.Resultado;
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
        ///   <name>DADiliencia.DeleteDiligenciaExpediente</name>
        ///   <create>01/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Borra una diligencia de un expediente</summary>
        public ENTResponse DeleteDiligenciaExpediente(ENTDiligencia oENTDiligencia, string ConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("spDiligenciaExpediente_del", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("DiligenciaId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.DiligenciaId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTDiligencia.ExpedienteId;
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
