using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoComparecencia : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTTipoComparecencia _TipoComparecenciaEntity;

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
        public ENTTipoComparecencia TipoComparecenciaEntity
        {
            get { return _TipoComparecenciaEntity; }
            set { _TipoComparecenciaEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPTipoComparecencia()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _TipoComparecenciaEntity = new ENTTipoComparecencia();
        }

        #region "Methods"
            /// <summary>
            ///     Realiza una búsqueda de los tipos de comparecencia.
            /// </summary>
            public void SelectTipoComparecencia()
            {
                DATipoComparecencia TipoComparecenciaAccess = new DATipoComparecencia();

                _TipoComparecenciaEntity.ResultData = TipoComparecenciaAccess.SelectTipoComparecencia(_TipoComparecenciaEntity, sConnectionApplication);

                _ErrorId = TipoComparecenciaAccess.ErrorId;
                _ErrorDescription = TipoComparecenciaAccess.ErrorDescription;
            }
        #endregion
    }
}
