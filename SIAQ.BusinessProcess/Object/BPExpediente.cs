﻿// Referencias
using System;
using System.Collections.Generic;
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
    }
}
