using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DAExpedienteComentario : DABase
    {

        #region Atributos

        private int _ErrorId;
        private string _ErrorDescription;

        #endregion

        #region Propiedades

        public int ErrorId { get { return _ErrorId; } set { _ErrorId = value; } }
        public string ErrorDescription { get { return _ErrorDescription; } set { _ErrorDescription = value; } }

        #endregion

        #region Funciones


        ///<remarks>
        ///   <name>DAExpedienteComentario.AgregarComentario</name>
        ///   <create>28/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Procedimiento que inserta comentarios</summary>
        public ENTResponse AgregarComentario(ENTExpedienteComentario oENTExpedienteComentario, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("ComentarioExpediente_ins", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("idUsuario", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.idUsuario;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Comentario", SqlDbType.VarChar);
            Parameter.Value = oENTExpedienteComentario.Comentario;
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
        ///   <name>DAExpedienteComentario.ModificarComentario</name>
        ///   <create>28/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Procedimiento que modifica comentarios</summary>
        public ENTResponse ModificarComentario(ENTExpedienteComentario oENTExpedienteComentario, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("ComentarioExpediente_upd", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("idUsuario", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.idUsuario;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("Comentario", SqlDbType.VarChar);
            Parameter.Value = oENTExpedienteComentario.Comentario;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ComentarioId", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.ComentarioId;
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
        ///   <name>DAExpedienteComentario.EliminarComentario</name>
        ///   <create>28/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Procedimiento que elimina comentarios</summary>
        public ENTResponse EliminarComentario(ENTExpedienteComentario oENTExpedienteComentario, string sConnectionString, int iAlternativeTimeOut)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            SqlParameter Parameter;

            ENTResponse oENTResponse = new ENTResponse();

            Command = new SqlCommand("ComentarioSolicitud_del", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            if (iAlternativeTimeOut > 0) { Command.CommandTimeout = iAlternativeTimeOut; }

            Parameter = new SqlParameter("ExpedienteId", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.ExpedienteId;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("idUsuario", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.idUsuario;
            Command.Parameters.Add(Parameter);

            Parameter = new SqlParameter("ComentarioId", SqlDbType.Int);
            Parameter.Value = oENTExpedienteComentario.ComentarioId;
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
