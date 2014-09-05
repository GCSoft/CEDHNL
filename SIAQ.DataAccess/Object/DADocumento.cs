using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using SIAQ.Entity.Object;

namespace SIAQ.DataAccess.Object
{
    public class DADocumento : DABase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;

        /// <summary>
        ///     Número de error, en caso de que haya ocurrido uno. Cero por default.
        /// </summary>
        public int ErrorId
        {
            get { return _ErrorId; }
        }

        /// <summary>
        ///     Descripción de error, en caso de que haya ocurrido uno. Empty por default.
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public DADocumento()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
        }

        #region "Method"
            /// <summary>
            ///     Elimina un documento del repositorio.
            /// </summary>
            /// <param name="DocumentoEntity"></param>
            /// <param name="ConnectionString"></param>
            public void DeleteRepositorioSE(ENTDocumento DocumentoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("DeleteRepositorioSE", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("RepositorioId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.RepositorioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                    Parameter.Value = DocumentoEntity.SolicitudId;
                    Command.Parameters.Add(Parameter);

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

            /// <summary>
            ///     Guarda un documento en el repositorio.
            /// </summary>
            /// <param name="ENTDocumento">Entidad de documento.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            public void InsertRepositorioSE(ENTDocumento DocumentoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlCommand Command;
                SqlParameter Parameter;
                SqlConnection Connection = new SqlConnection(ConnectionString);

                try
                {
                    Command = new SqlCommand("InsertRepositorioSE", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("RepositorioId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.RepositorioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("ModuloId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.ModuloId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("TipoDocumentoId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.TipoDocumentoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("FormatoDocumentoId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.FormatoDocumentoId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                    Parameter.Value = DocumentoEntity.SolicitudId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("idUsuarioInsert", SqlDbType.Int);
                    Parameter.Value = DocumentoEntity.idUsuarioInsert;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Nombre", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.Nombre;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Descripcion", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.Descripcion;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("Documento", SqlDbType.Image);
                    Parameter.Value = DocumentoEntity.Documento;
                    Command.Parameters.Add(Parameter);

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

            /// <summary>
            ///     Busca documentos en el repositorio relacionados a una solicitud, expediente o recomendación.
            /// </summary>
            /// <param name="ENTDocumento">Entidad de documento.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            /// <returns>Resultado de la búsqueda.</returns>
            public DataSet SelectRepositorioSE(ENTDocumento DocumentoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlConnection Connection = new SqlConnection(ConnectionString);
                SqlCommand Command;
                SqlParameter Parameter;
                SqlDataAdapter DataAdapter;

                try
                {
                    Command = new SqlCommand("SelectRepositorioSE", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("RepositorioId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.RepositorioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                    Parameter.Value = DocumentoEntity.SolicitudId;
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
            ///     Busca un registro y trae su información junto con el archivo físico.
            /// </summary>
            /// <param name="ENTDocumento">Entidad de documento.</param>
            /// <param name="ConnectionString">Cadena de conexión a la base de datos.</param>
            /// <returns>Resultado de la búsqueda.</returns>
            public DataSet SelectRepositorioSEConDocumento(ENTDocumento DocumentoEntity, string ConnectionString)
            {
                DataSet ResultData = new DataSet();
                SqlConnection Connection = new SqlConnection(ConnectionString);
                SqlCommand Command;
                SqlParameter Parameter;
                SqlDataAdapter DataAdapter;

                try
                {
                    Command = new SqlCommand("SelectRepositorioSEConDocumento", Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Parameter = new SqlParameter("RepositorioId", SqlDbType.VarChar);
                    Parameter.Value = DocumentoEntity.RepositorioId;
                    Command.Parameters.Add(Parameter);

                    Parameter = new SqlParameter("SolicitudId", SqlDbType.Int);
                    Parameter.Value = DocumentoEntity.SolicitudId;
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
        #endregion


		///<remarks>
		///   <name>DADocumento.DeleteDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Elimina un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteDocumento(ENTDocumento oENTDocumento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDocumento_Del", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("DocumentoId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.DocumentoId;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();

			}catch (SqlException sqlEx){

				oENTResponse.ExceptionRaised(sqlEx.Message);

			}catch (Exception ex){

				oENTResponse.ExceptionRaised(ex.Message);

			}finally{

				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();

			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>DADocumento.InsertDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Guarda un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertDocumento(ENTDocumento oENTDocumento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDocumento_Ins", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("SolicitudId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.SolicitudId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ExpedienteId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.ExpedienteId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("ModuloId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.ModuloId;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("UsuarioId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.idUsuarioInsert;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Extension", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Extension;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Nombre", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Nombre;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Descripcion", SqlDbType.VarChar);
			sqlPar.Value = oENTDocumento.Descripcion;
			sqlCom.Parameters.Add(sqlPar);

			sqlPar = new SqlParameter("Archivo", SqlDbType.VarBinary);
			sqlPar.Value = oENTDocumento.Documento;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();

			}catch (SqlException sqlEx){

				oENTResponse.ExceptionRaised(sqlEx.Message);

			}catch (Exception ex){

				oENTResponse.ExceptionRaised(ex.Message);

			}finally{

				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();

			}

			// Resultado
			return oENTResponse;
		}

		///<remarks>
		///   <name>DADocumento.SelectDocumento</name>
		///   <create>04-Septiembre-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta un documento en la BD</summary>
		///<param name="oENTDocumento">Entidad de Documento con los parámetros necesarios para realizar la transacción</param>
		///<param name="sConnection">Cadena de conexión a la base de datos</param>
		///<param name="iAlternateDBTimeout">Valor en milisegundos del Timeout en la consulta a la base de datos. 0 si se desea el Timeout por default</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectDocumento(ENTDocumento oENTDocumento, String sConnection, Int32 iAlternateDBTimeout){
			SqlConnection sqlCnn = new SqlConnection(sConnection);
			SqlCommand sqlCom;
			SqlParameter sqlPar;
			SqlDataAdapter sqlDA;

			ENTResponse oENTResponse = new ENTResponse();

			// Configuración de objetos
			sqlCom = new SqlCommand("uspDocumento_Sel_Document", sqlCnn);
			sqlCom.CommandType = CommandType.StoredProcedure;

			// Timeout alternativo en caso de ser solicitado
			if (iAlternateDBTimeout > 0) { sqlCom.CommandTimeout = iAlternateDBTimeout; }

			// Parametros
			sqlPar = new SqlParameter("DocumentoId", SqlDbType.Int);
			sqlPar.Value = oENTDocumento.DocumentoId;
			sqlCom.Parameters.Add(sqlPar);

			// Inicializaciones
			oENTResponse.dsResponse = new DataSet();
			sqlDA = new SqlDataAdapter(sqlCom);

			// Transacción
			try{
				
				sqlCnn.Open();
				sqlDA.Fill(oENTResponse.dsResponse);
				sqlCnn.Close();

			}catch (SqlException sqlEx){

				oENTResponse.ExceptionRaised(sqlEx.Message);

			}catch (Exception ex){

				oENTResponse.ExceptionRaised(ex.Message);

			}finally{

				if (sqlCnn.State == ConnectionState.Open) { sqlCnn.Close(); }
				sqlCnn.Dispose();

			}

			// Resultado
			return oENTResponse;
		}


    }
}
