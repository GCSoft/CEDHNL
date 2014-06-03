using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPLugarHechos : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTLugarHechos _LugarEntity;

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
        ///     Propiedad pública de la entidad de lugar de los hechos.
        /// </summary>
        public ENTLugarHechos LugarEntity
        {
            get { return _LugarEntity; }
            set { _LugarEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPLugarHechos()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _LugarEntity = new ENTLugarHechos();
        }

        #region "Methods"
        public void SelectLugarHechos()
            {
                string ConnectionString = string.Empty;
                DALugarHechos LugarAccess = new DALugarHechos();

                _LugarEntity.ResultData = LugarAccess.SelectLugarHechos(_LugarEntity, sConnectionApplication);

                _ErrorId = LugarAccess.ErrorId;
                _ErrorDescription = LugarAccess.ErrorDescription;
            }

        ///<remarks>
        ///   <name>BPLugarHechos.SelectcatLugarHechos</name>
        ///   <create>31-Mayo-2014</create>
        ///   <author>Daniel.Chavez</author>
        ///</remarks>
        ///<summary>Consulta el catálogo de LugarHechos</summary>
        ///<param name="oENTPais">Entidad de BPLugarHechos con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectcatLugarHechos(ENTLugarHechos oENTLugarHechos)
        {
            DALugarHechos oDALugarHechos = new DALugarHechos();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDALugarHechos.SelectcatLugarHechos(oENTLugarHechos, this.sConnectionApplication);

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
        ///   <name>BPLugarHechos.insertLugarHechos</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar LugarDiligencia del sistema</summary>
        public ENTResponse insertLugarHechos(ENTLugarHechos oENTLugarHechos)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DALugarHechos oDALugarHechos = new DALugarHechos();
                oENTResponse = oDALugarHechos.insertcatLugarHechos(oENTLugarHechos);
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
        ///   <name>BPLugarHechos.updateLugarHechos</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza LugarHechos del sistema</summary>
        public ENTResponse updateLugarHechos(ENTLugarHechos oENTLugarHechos)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DALugarHechos oDALugarHechos = new DALugarHechos();
                oENTResponse = oDALugarHechos.updatecatLugarHechos(oENTLugarHechos);
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
        ///   <name>BPLugarHechos.deleteLugarHechos</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de LugarDiligencia del sistema</summary>
        public ENTResponse deleteLugarHechos(ENTLugarHechos oENTLugarHechos)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DALugarHechos oDALugarHechos = new DALugarHechos();
                //oENTResponse = oDALugarHechos.SelectLugarHechos(oENTLugarHechos);
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

        #endregion
    }
}
