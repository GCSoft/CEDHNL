using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoRecomendacion : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTTipoRecomendacion _TipoRecomendacionEntity;

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
        ///     Propiedad pública de la entidad del lugar de comprarecencia.
        /// </summary>
        public ENTTipoRecomendacion TipoRecomendacionEntity
        {
            get { return _TipoRecomendacionEntity; }
            set { _TipoRecomendacionEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPTipoRecomendacion()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _TipoRecomendacionEntity = new ENTTipoRecomendacion();
        }

        #region "Methods"
            /// <summary>
            ///     Realiza una búsqueda de los tipos de recomendación.
            /// </summary>
            public void SelectTipoRecomendacion()
            {
                DATipoRecomendacion TipoRecomendacionAccess = new DATipoRecomendacion();

                _TipoRecomendacionEntity.ResultData = TipoRecomendacionAccess.SelectTipoRecomendacion(_TipoRecomendacionEntity, sConnectionApplication);

                _ErrorId = TipoRecomendacionAccess.ErrorId;
                _ErrorDescription = TipoRecomendacionAccess.ErrorDescription;
            }
        #endregion
    }
}
