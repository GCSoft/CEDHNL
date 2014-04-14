using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPVocesSenaladas : BPBase
    {

        #region Atributos

        private int _ErrorId;
        private string _ErrorDescription;
        private ENTVocesSenaladas _VocesSenaladasEntity;

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
        public ENTVocesSenaladas VocesSenaladasEntity
        {
            get { return _VocesSenaladasEntity; }
            set { _VocesSenaladasEntity = value; }
        }

        #endregion

        #region Funciones

        public BPVocesSenaladas()
        {
            _ErrorDescription = String.Empty;
            _ErrorId = 0;
            _VocesSenaladasEntity = new ENTVocesSenaladas();
        }

        /// <summary>
        /// Selecciona las Voces para llenado de Combobox
        /// </summary>
        public void SelectNivelesVoces()
        {
            string sConnectionString = String.Empty;
            DAVocesSenaladas oDAVocesSenaladas = new DAVocesSenaladas();

            sConnectionString = sConnectionApplication;

            _VocesSenaladasEntity.dsResponse = oDAVocesSenaladas.SelectNivelesVoces(_VocesSenaladasEntity, sConnectionString);

            _ErrorId = oDAVocesSenaladas.ErrorId;
            _ErrorDescription = oDAVocesSenaladas.ErrorDescription;
        }

        /// <summary>
        /// Selecciona las Voces seleccionadas para una autoridad 
        /// </summary>
        public void SelectListaVocesAutoridad()
        {
            string sConnectionString = String.Empty;
            DAVocesSenaladas oDAVocesSenaladas = new DAVocesSenaladas();

            sConnectionString = sConnectionApplication;

            _VocesSenaladasEntity.dsResponse = oDAVocesSenaladas.SelectListaVocesAutoridad(_VocesSenaladasEntity, sConnectionString);

            _ErrorId = oDAVocesSenaladas.ErrorId;
            _ErrorDescription = oDAVocesSenaladas.ErrorDescription;
        }

        /// <summary>
        /// Agrega voces a la autoridad señalada
        /// </summary>
        public ENTResponse InsertSolicitudAutoridadVoces(ENTVocesSenaladas oENTVocesSenaladas)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                //Consulta base de datos 
                DAVocesSenaladas oDAVocesSenaladas = new DAVocesSenaladas();
                oENTResponse = oDAVocesSenaladas.InsertSolicitudAutoridadVoces(oENTVocesSenaladas, sConnectionApplication, 0);
                //Validación de error de consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                oENTResponse.sMessage = String.Empty;
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            return oENTResponse;
        }

        /// <summary>
        /// Elimina voces de la autoridad
        /// </summary>
        public ENTResponse DeleteSolicitudAutoridadVoces(ENTVocesSenaladas oENTVocesSenaladas)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                //Consulta base de datos 
                DAVocesSenaladas oDAVocesSenaladas = new DAVocesSenaladas();
                oENTResponse = oDAVocesSenaladas.DeleteSolicitudAutoridadVoces(oENTVocesSenaladas, sConnectionApplication, 0);
                //Validación de error de consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                oENTResponse.sMessage = String.Empty;
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            return oENTResponse;
        }


        #endregion

    }
}
