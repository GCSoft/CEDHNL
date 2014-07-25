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
    public class DAFuncionario : DABase
    {

        #region "Operacion"

        protected int _ErrorId;
        protected string _ErrorDescription;
        Database dbs;

        ///<remarks>
        ///   <name>DAFuncionario.SelectFuncionarioVistaduria</name>
        ///   <create>30/mar/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el listado de los funcionarios del área de visitadurias</summary>
        public DataSet SelectFuncionarioVistaduria(ENTFuncionario oENTFuncionario, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spExpedienteFuncionarioVisitaduria_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
                return ds;
            }
        }

        ///<remarks>
        ///   <name>DAFuncionario.SelectFuncionarioQuejas</name>
        ///   <create>02/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el listado de los funcionarios del área de quejas</summary>
        public DataSet SelectFuncionarioQuejas(ENTFuncionario oENTFuncionario, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spExpedienteFuncionarioQuejas_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
                return ds;
            }
        }

        ///<remarks>
        ///   <name>DAFuncionario.SelectFuncionarioRecomendacion</name>
        ///   <create>02/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el listado de los funcionarios del área de seguimientos</summary>
        public DataSet SelectFuncionarioRecomendacion(ENTFuncionario oENTFuncionario, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spExpedienteFuncionarioSeguimiento_sel", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
                return ds;
            }
        }

        ///<remarks>
        ///   <name>DAFuncionario.SelectFuncionarioBusqueda</name>
        ///   <create>02/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene el listado de los funcionarios para su búsqueda</summary>
        public DataSet SelectFuncionarioBusqueda(ENTFuncionario oENTFuncionario, string sConnectionString)
        {
            SqlConnection Connection = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                Command = new SqlCommand("spcatFuncionario_SelForControl", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                Connection.Open();
                DataAdapter.Fill(ds);
                Connection.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
                return ds;
            }
        }


        #endregion

        ///<remarks>
        ///   <name>DAFuncionario.DeleteFuncionario</name>
        ///   <create>06-Abril-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Elimina un Funcionario liberando la asociación del usuario. El usuario no se elimina</summary>
        ///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para crear el registro</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse DeleteFuncionario(ENTFuncionario oENTFuncionario, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("uspcatFuncionario_Del", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.FuncionarioId;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAFuncionario.InsertFuncionario</name>
        ///   <create>06-Abril-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Crea una nueva relación para un usuario y lo convierte en Funcionario</summary>
        ///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para crear el registro</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse InsertFuncionario(ENTFuncionario oENTFuncionario, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("uspcatFuncionario_Ins", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.idUsuario;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("TituloId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.TituloId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("PuestoId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.PuestoId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("FechaIngreso", SqlDbType.DateTime);
            sqlPar.Value = oENTFuncionario.FechaIngreso;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAFuncionario.SelectFuncionario</name>
        ///   <create>06-Abril-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Consulta el catálogo de Funcionarios</summary>
        ///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para consultar la información</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectFuncionario(ENTFuncionario oENTFuncionario, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("uspcatFuncionario_Sel", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.FuncionarioId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.idUsuario;
            sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("idRol", SqlDbType.Int);
			sqlPar.Value = oENTFuncionario.idRol;
			sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idArea", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.idArea;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("TituloId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.TituloId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("PuestoId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.PuestoId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
            sqlPar.Value = oENTFuncionario.Nombre;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>DAFuncionario.UpdateFuncionario</name>
        ///   <create>06-Abril-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Actualiza la información de un Funcionario</summary>
        ///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para crear el registro</param>
        ///<param name="sConnection">Cadena de conexión a la base de datos</param>
        ///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateFuncionario(ENTFuncionario oENTFuncionario, String sConnection, Int32 iAlternateDBTimeout)
        {
            SqlConnection sqlCnn = new SqlConnection(sConnection);
            SqlCommand sqlCom;
            SqlParameter sqlPar;
            SqlDataAdapter sqlDA;

            ENTResponse oENTResponse = new ENTResponse();

            // Configuración de objetos
            sqlCom = new SqlCommand("uspcatFuncionario_Upd", sqlCnn);
            sqlCom.CommandType = CommandType.StoredProcedure;

            // Timeout alternativo en caso de ser solicitado
            if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

            // Parametros
            sqlPar = new SqlParameter("FuncionarioId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.FuncionarioId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("idUsuario", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.idUsuario;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("TituloId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.TituloId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("PuestoId", SqlDbType.Int);
            sqlPar.Value = oENTFuncionario.PuestoId;
            sqlCom.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter("FechaIngreso", SqlDbType.DateTime);
            sqlPar.Value = oENTFuncionario.FechaIngreso;
            sqlCom.Parameters.Add(sqlPar);

            // Inicializaciones
            oENTResponse.dsResponse = new DataSet();
            sqlDA = new SqlDataAdapter(sqlCom);

            // Transacción
            try
            {
                sqlCnn.Open();
                sqlDA.Fill(oENTResponse.dsResponse);
                sqlCnn.Close();
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
                if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
                sqlCnn.Dispose();
            }

            // Resultado
            return oENTResponse;
        }

    }
}
