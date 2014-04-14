using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;


namespace SIAQ.BusinessProcess.Object
{
    public class BPAutoridad : BPBase
    {

        #region Atributos

        private int _ErrorId;
        private string _ErrorDescription;
        private ENTAutoridad _AutoridadEntity;

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

        public ENTAutoridad AutoridadEntity
        {
            get { return _AutoridadEntity; }
            set { _AutoridadEntity = value; }
        }

        #endregion

        #region Funciones

        public BPAutoridad()
        {
            _AutoridadEntity = new ENTAutoridad();
        }

        /// <summary>
        /// Selecciona las Autoridades para llenado de Combobox
        /// </summary>
        public void SelectNivelesAutoridad()
        {
            string sConnectionString = String.Empty;
            DAAutoridad oDAAutoridad = new DAAutoridad();

            sConnectionString = sConnectionApplication;

            _AutoridadEntity.dsResponse = oDAAutoridad.SelectNivelesAutoridad(_AutoridadEntity, sConnectionString);

            _ErrorId = oDAAutoridad.ErrorId;
            _ErrorDescription = oDAAutoridad.ErrorDescription;
        }

        /// <summary>
        /// Selecciona las Autoridades seleccionadas para una solicitud
        /// </summary>
        public void SelectListaAutoridadesSolicitud()
        {
            string sConnectionString = String.Empty;
            DAAutoridad oDAAutoridad = new DAAutoridad();

            sConnectionString = sConnectionApplication;

            _AutoridadEntity.dsResponse = oDAAutoridad.SelectListaAutoridadesSolicitud(_AutoridadEntity, sConnectionString);

            _ErrorId = oDAAutoridad.ErrorId;
            _ErrorDescription = oDAAutoridad.ErrorDescription;
        }

        /// <summary>
        /// Obtiene el detalle de una autoridad agregada
        /// </summary>
        public void SelectDetalleAutoridadesSolicitud()
        {
            string sConnectionString = string.Empty;
            DAAutoridad oDAAutoridad = new DAAutoridad();

            sConnectionString = sConnectionApplication;

            _AutoridadEntity.dsResponse = oDAAutoridad.SelectDetalleAutoridadesSolicitud(_AutoridadEntity, sConnectionString);
            _ErrorId = oDAAutoridad.ErrorId;
            _ErrorDescription = oDAAutoridad.ErrorDescription;
        }

        /// <summary>
        /// Elimina autoridades de la solicitud
        /// </summary>
        public ENTResponse DeleteSolicitudAutoridad(ENTAutoridad oENTAutoridad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                //Consulta base de datos 
                DAAutoridad oDAAutoridad = new DAAutoridad();
                oENTResponse = oDAAutoridad.DeleteSolicitudAutoridad(oENTAutoridad, sConnectionApplication, 0);
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
        /// Agrega autoridades de la solicitud
        /// </summary>
        public ENTResponse InsertSolicitudAutoridad(ENTAutoridad oENTAutoridad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                //Consulta base de datos 
                DAAutoridad oDAAutoridad = new DAAutoridad();
                oENTResponse = oDAAutoridad.InsertSolicitudAutoridad(oENTAutoridad, sConnectionApplication, 0);
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
        /// Agrega autoridades de la solicitud
        /// </summary>
        public ENTResponse UpdateSolicitudAutoridad(ENTAutoridad oENTAutoridad)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                //Consulta base de datos 
                DAAutoridad oDAAutoridad = new DAAutoridad();
                oENTResponse = oDAAutoridad.UpdateSolicitudAutoridad(oENTAutoridad, sConnectionApplication, 0);
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
