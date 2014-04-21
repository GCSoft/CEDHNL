using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SIAQ.Entity.Object;
using SIAQ.DataAccess.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPSolicitudComentario : BPBase
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

        /// <summary>
        /// Procedimiento que inserta comentarios
        /// </summary>
        public ENTResponse AgregarComentario(ENTSolicitudComentario oENTSolicitudComentario)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DASolicitudComentario oDASolicitudComentario = new DASolicitudComentario();
                oENTResponse = oDASolicitudComentario.AgregarComentario(oENTSolicitudComentario, sConnectionApplication, 0);

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
        /// Procedimiento que modifica comentarios
        /// </summary>
        public ENTResponse ModificarComentario(ENTSolicitudComentario oENTSolicitudComentario)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DASolicitudComentario oDASolicitudComentario = new DASolicitudComentario();
                oENTResponse = oDASolicitudComentario.ModificarComentario(oENTSolicitudComentario, sConnectionApplication, 0);

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
        /// Procedimiento que elimina comentarios
        /// </summary>
        public ENTResponse EliminarComentario(ENTSolicitudComentario oENTSolicitudComentario)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DASolicitudComentario oDASolicitudComentario = new DASolicitudComentario();
                oENTResponse = oDASolicitudComentario.EliminarComentario(oENTSolicitudComentario, sConnectionApplication, 0);

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

