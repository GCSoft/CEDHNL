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
        public const int POR_ASIGNAR_ESTATUS = 5;
        public const int POR_ATENDER_ESTATUS = 6;
        public const int EN_PROCESO_ESTATUS = 7;
        public const int PENDIENTE_APROBAR_ESTATUS = 16;
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
