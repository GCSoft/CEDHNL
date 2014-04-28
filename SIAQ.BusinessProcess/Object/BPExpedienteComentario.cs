using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIAQ.DataAccess.Object;
using System.Data;
using SIAQ.Entity.Object;


namespace SIAQ.BusinessProcess.Object
{
    public class BPExpedienteComentario : BPBase
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
        public ENTResponse AgregarComentario(ENTExpedienteComentario oENTExpedienteComentario)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DAExpedienteComentario oDAExpedienteComentario = new DAExpedienteComentario();
                oENTResponse = oDAExpedienteComentario.AgregarComentario(oENTExpedienteComentario, sConnectionApplication, 0);

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
        public ENTResponse ModificarComentario(ENTExpedienteComentario oENTExpedienteComentario)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DAExpedienteComentario oDAExpedienteComentario = new DAExpedienteComentario();
                oENTResponse = oDAExpedienteComentario.ModificarComentario(oENTExpedienteComentario, sConnectionApplication, 0);

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
        public ENTResponse EliminarComentario(ENTExpedienteComentario oENTExpedienteComentario)
        {
            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                DAExpedienteComentario oDAExpedienteComentario = new DAExpedienteComentario();
                oENTResponse = oDAExpedienteComentario.EliminarComentario(oENTExpedienteComentario, sConnectionApplication, 0);

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
