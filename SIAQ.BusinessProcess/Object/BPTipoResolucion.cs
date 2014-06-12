using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoResolucion : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTTipoResolucion _TipoResolucionEntity;

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
        ///     Propiedad pública de la entidad del tipo de resolución.
        /// </summary>
        public ENTTipoResolucion TipoResolucionEntity
        {
            get { return _TipoResolucionEntity; }
            set { _TipoResolucionEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPTipoResolucion()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _TipoResolucionEntity = new ENTTipoResolucion();
        }

        #region "Methods"
            /// <summary>
            ///     Realiza una búsqueda de los tipos de Resolucion.
            /// </summary>
            public void SelectTipoResolucion()
            {
                DATipoResolucion TipoResolucionAccess = new DATipoResolucion();

                _TipoResolucionEntity.ResultData = TipoResolucionAccess.SelectTipoResolucion(_TipoResolucionEntity, sConnectionApplication);

                _ErrorId = TipoResolucionAccess.ErrorId;
                _ErrorDescription = TipoResolucionAccess.ErrorDescription;
            }
        #endregion
    }
}
