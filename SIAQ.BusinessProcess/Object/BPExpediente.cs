// Referencias
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

// Referencias manuales
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPExpediente : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTExpediente _ExpedienteEntity;

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

        public ENTExpediente ExpedienteEntity
        {
            get { return _ExpedienteEntity; }
            set { _ExpedienteEntity = value; }
        }

        public BPExpediente()
        {
            _ExpedienteEntity = new ENTExpediente();
        }

        #region "Method"
            /// <summary>
            /// Aprueba resolución de expediente 
            /// </summary>
            public ENTResponse AprobarResolucionTitular(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción
                    oDAExpediente.AprobarResolucionTitular(oENTExpediente, sConnectionApplication, 0);

                    //Validación error
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    //Validación mensajes base de datos
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }

                //Resultado
                return oENTResponse;
            }

            /// <summary>
            /// Asigna funcionario al expediente
            /// </summary>
            public ENTResponse AsignarVisitador_Expediente(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción
                    oENTResponse = oDAExpediente.AsignarVisitador_Expediente(oENTExpediente, sConnectionApplication, 0);

                    // Validación error 
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    //Validacion de mensajes de base de datos 
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }

                //Resultado 
                return oENTResponse;
            }

            /// <summary>
            /// Elimina autoridades de un expediente en específico
            /// </summary>
            public ENTResponse DeleteAutoridad_Expediente(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción 
                    oENTResponse = oDAExpediente.DeleteAutoridad_Expediente(oENTExpediente, sConnectionApplication, 0);

                    //Validación de error de consulta 
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    //Validacion de mensajes de la base de datos 
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }

                }
                catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }

                //Resultado
                return oENTResponse;
            }

            /// <summary>
            /// Elimina ciudadanos de un expediente en específico
            /// </summary>
            public ENTResponse DeleteCiudadano_Expediente(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción en base de datos 
                    oENTResponse = oDAExpediente.DeleteCiudadano_Expediente(oENTExpediente, sConnectionApplication, 0);

                    // Validación de error en consulta
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    // Validación de mensajes de la BD
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }

                //Resultado 
                return oENTResponse;
            }

            ///<remarks>
            ///   <name>BPExpediente.deletecatTipoSolicitud</name>
            ///   <create>27/ene/2014</create>
            ///   <author>Generador</author>
            ///</remarks>
            ///<summary>Metodo para eliminar de Expediente del sistema</summary>
            public ENTResponse deleteExpediente(ENTExpediente oENTExpediente)
            {

                ENTResponse oENTResponse = new ENTResponse();
                try
                {
                    // Consulta a base de datos
                    DAExpediente oDAExpediente = new DAExpediente();
                    oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
                    // Validación de error en consulta
                    if (oENTResponse.GeneratesException) { return oENTResponse; }
                    // Validación de mensajes de la BD
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }
                // Resultado
                return oENTResponse;

            }

            /// <summary>
            /// Agrega el acuerdo de calificación definitiva
            /// </summary>
            public ENTResponse InsertAcuerdoCalificacionDefinitiva(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción
                    oENTResponse = oDAExpediente.InsertAcuerdoCalificacionDefinitiva(oENTExpediente, sConnectionApplication, 0);

                    // Validación error 
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    //Validacion de mensajes de base de datos 
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }

                //Resultado 
                return oENTResponse;
            }

            ///<remarks>
            ///   <name>BPExpediente.insertcatTipoSolicitud</name>
            ///   <create>27/ene/2014</create>
            ///   <author>Generador</author>
            ///</remarks>
            ///<summary>Metodo para insertar Expediente del sistema</summary>
            public ENTResponse insertExpediente(ENTExpediente oENTExpediente)
            {

                ENTResponse oENTResponse = new ENTResponse();
                try
                {
                    // Consulta a base de datos
                    DAExpediente oDAExpediente = new DAExpediente();
                    oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
                    // Validación de error en consulta
                    if (oENTResponse.GeneratesException) { return oENTResponse; }
                    // Validación de mensajes de la BD
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }
                // Resultado
                return oENTResponse;

            }

            /// <summary>
            /// Rechaza resolución de expediente 
            /// </summary>
            public ENTResponse RechazarResolucionTitular(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción
                    oDAExpediente.RechazarResolucionTitular(oENTExpediente, sConnectionApplication, 0);

                    //Validación error
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    //Validación mensajes base de datos
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }

                //Resultado
                return oENTResponse;
            }

            ///<remarks>
            ///   <name>BPExpediente.searchcatTipoSolicitud</name>
            ///   <create>27/ene/2014</create>
            ///   <author>Generador</author>
            ///</remarks>
            ///<summary>Metodo para obtener el Expediente del sistema</summary>
            public ENTResponse searchExpediente(ENTExpediente oENTExpediente)
            {

                ENTResponse oENTResponse = new ENTResponse();
                try
                {
                    // Consulta a base de datos
                    DAExpediente oDAExpediente = new DAExpediente();
                    oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
                    // Validación de error en consulta
                    if (oENTResponse.GeneratesException) { return oENTResponse; }
                    // Validación de mensajes de la BD
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }
                // Resultado
                return oENTResponse;
            }

            /// <summary>
            ///     Obtiene las autoridades relacionados al expediente 
            /// </summary>
            public void SelectAutoridadesGrid(ENTExpediente oENTExpediente)
            {
                string ConnectionString = String.Empty;
                DAExpediente DAExpediente = new DAExpediente();

                ConnectionString = sConnectionApplication;

                oENTExpediente.ResultData = DAExpediente.SelectAutoridadesGrid(oENTExpediente, ConnectionString);
                _ErrorId = DAExpediente.ErrorId;
                _ErrorDescription = DAExpediente.ErrorDescription;
            }

            /// <summary>
            ///     Obtiene los ciudadanos relacionados al expediente 
            /// </summary>
            public void SelectCiudadanosGrid(ENTExpediente oENTExpediente)
            {
                string ConnectionString = String.Empty;
                DAExpediente DAExpediente = new DAExpediente();

                ConnectionString = sConnectionApplication;

                oENTExpediente.ResultData = DAExpediente.SelectCiudadanosGrid(oENTExpediente, ConnectionString);

                _ErrorId = DAExpediente.ErrorId;
                _ErrorDescription = DAExpediente.ErrorDescription;
            }

            /// <summary>
            ///     Obtiene el detalle del expediente seleccionado
            /// </summary>
            public void SelectDetalleExpediente(ENTExpediente oENTExpediente)
            {
                string ConnectionString = String.Empty;
                DAExpediente DAExpediente = new DAExpediente();

                ConnectionString = sConnectionApplication;

                oENTExpediente.ResultData = DAExpediente.SelectDetalleExpediente(oENTExpediente, ConnectionString);

                _ErrorId = DAExpediente.ErrorId;
                _ErrorDescription = DAExpediente.ErrorDescription;
            }

            /// <summary>
            ///     Obtiene los expedientes asignados a un funcionario en específico
            /// </summary>
            public void SelectExpediente_Funcionario(ENTExpediente oENTExpediente)
            {
                _ExpedienteEntity = new ENTExpediente();

                string sConnectionString = string.Empty;
                DAExpediente oDAExpediente = new DAExpediente();

                sConnectionString = sConnectionApplication;

                _ExpedienteEntity.ResultData = oDAExpediente.SelectExpediente_Funcionario(oENTExpediente, sConnectionString);
                _ErrorId = oDAExpediente.ErrorId;
                _ErrorDescription = oDAExpediente.ErrorDescription;
            }

            /// <summary>
            ///     Busca los comentarios realizados para una solicitud.
            /// </summary>
            public void SelectExpedienteComentario()
            {
                string ConnectionString = string.Empty;
                DAExpediente DAExpediente = new DAExpediente();

                ConnectionString = sConnectionApplication;

                _ExpedienteEntity.ResultData = DAExpediente.SelectExpedienteComentario(_ExpedienteEntity, ConnectionString);

                _ErrorId = DAExpediente.ErrorId;
                _ErrorDescription = DAExpediente.ErrorDescription;
            }

            /// <summary>
            ///     Busca la información importante de un expediente para su validación.
            /// </summary>
            public void SelectExpedienteEstatus(int ExpedienteId)
            {
                DataSet ResultData = new DataSet();
                DAExpediente DAExpediente = new DAExpediente();

                ResultData = DAExpediente.SelectExpedienteEstatus(ExpedienteId, sConnectionApplication);

                _ErrorId = DAExpediente.ErrorId;
                _ErrorDescription = DAExpediente.ErrorDescription;

                if (_ErrorId != 0)
                    return;

                if (ResultData.Tables[0].Rows.Count == 0)
                    return;

                _ExpedienteEntity.ExpedienteId = ExpedienteId;
                _ExpedienteEntity.FuncionarioId = int.Parse(ResultData.Tables[0].Rows[0]["FuncionarioId"].ToString());
                _ExpedienteEntity.EstatusId = int.Parse(ResultData.Tables[0].Rows[0]["EstatusId"].ToString());
                _ExpedienteEntity.Numero = ResultData.Tables[0].Rows[0]["EstatusId"].ToString();
            }

            /// <summary>
            ///     Obtiene los funcionarios a los cuales se podrán asignar a un expediente
            /// </summary>
            public void SelectFuncionario_Asignar(ENTExpediente oENTExpediente)
            {

                string sConnectionString = string.Empty;
                DAExpediente oDAExpediente = new DAExpediente();

                sConnectionString = sConnectionApplication;

                oENTExpediente.ResultData = oDAExpediente.SelectFuncionario_Asignar(oENTExpediente, sConnectionString);
                _ErrorId = oDAExpediente.ErrorId;
                _ErrorDescription = oDAExpediente.ErrorDescription;
            }

            ///<remarks>
            ///   <name>BPExpediente.updatecatTipoSolicitud</name>
            ///   <create>27/ene/2014</create>
            ///   <author>Generador</author>
            ///</remarks>
            ///<summary>Metodo que actualiza Expediente del sistema</summary>
            public ENTResponse updateExpediente(ENTExpediente oENTExpediente)
            {

                ENTResponse oENTResponse = new ENTResponse();
                try
                {
                    // Consulta a base de datos
                    DAExpediente oDAExpediente = new DAExpediente();
                    oENTResponse = oDAExpediente.searchExpediente(oENTExpediente);
                    // Validación de error en consulta
                    if (oENTResponse.GeneratesException) { return oENTResponse; }
                    // Validación de mensajes de la BD
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex)
                {
                    oENTResponse.ExceptionRaised(ex.Message);
                }
                // Resultado
                return oENTResponse;

            }

            /// <summary>
            ///     Actualiza el estatus de un expediente.
            /// </summary>
            public void UpdateExpedienteEstatus()
            {
                DAExpediente ExpedienteAccess = new DAExpediente();

                if (!ValidarExpedienteEstatus())
                    return;

                ExpedienteAccess.UpdateExpedienteEstatus(_ExpedienteEntity, sConnectionApplication);

                _ErrorId = ExpedienteAccess.ErrorId;
                _ErrorDescription = ExpedienteAccess.ErrorDescription;
            }

            /// <summary>
            ///     Actualiza el estatus de un expediente.
            /// </summary>
            /// <param name="Connection">Conexión actual a la base de datos.</param>
            /// <param name="Transaction">Transacción actual a la base de datos.</param>
            public void UpdateExpedienteEstatus(SqlConnection Connection, SqlTransaction Transaction)
            {
                DAExpediente ExpedienteAccess = new DAExpediente();

                if (!ValidarExpedienteEstatus())
                    return;
                    
                ExpedienteAccess.UpdateExpedienteEstatus(Connection, Transaction, _ExpedienteEntity);

                _ErrorId = ExpedienteAccess.ErrorId;
                _ErrorDescription = ExpedienteAccess.ErrorDescription;
            }

            /// <summary>
            /// Modifica la observación de un expediente en específico
            /// </summary>
            public ENTResponse UpdateObservaciones_Expediente(ENTExpediente oENTExpediente)
            {
                DAExpediente oDAExpediente = new DAExpediente();
                ENTResponse oENTResponse = new ENTResponse();

                try
                {
                    //Transacción 
                    oENTResponse = oDAExpediente.UpdateObservaciones_Expediente(oENTExpediente, sConnectionApplication, 0);

                    //Validacion de error
                    if (oENTResponse.GeneratesException) { return oENTResponse; }

                    //Validacion de mensajes de base de datos 
                    oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                    if (oENTResponse.sMessage != "") { return oENTResponse; }
                }
                catch (Exception ex) { oENTResponse.ExceptionRaised(ex.Message); }

                //Resultado 
                return oENTResponse;
            }

            private bool ValidarExpedienteEstatus()
            {
                if (_ExpedienteEntity.ExpedienteId == 0)
                {
                    _ErrorId = 50001;
                    _ErrorDescription = "Se debe proporcionar un número de expediente";
                }

                if (_ExpedienteEntity.EstatusId == 0)
                {
                    _ErrorId = 50002;
                    _ErrorDescription = "Se debe proporcionar un estatus para actualizar el expediente";
                }

                return true;
            }
        #endregion
    }
}
