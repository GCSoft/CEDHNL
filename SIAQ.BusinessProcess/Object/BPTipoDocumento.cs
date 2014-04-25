using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoDocumento : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTTipoDocumento _TipoDocumentoEntity;

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
        ///     Propiedad pública de la entidad de repositorio.
        /// </summary>
        public ENTTipoDocumento TipoDocumentoEntity
        {
            get { return _TipoDocumentoEntity; }
            set { _TipoDocumentoEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPTipoDocumento()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _TipoDocumentoEntity = new ENTTipoDocumento();
        }

        #region "Method"
            public void SelectTipoDocumento()
            {
                string ConnectionString = string.Empty;
                DATipoDocumento TipoDocumentoAccess = new DATipoDocumento();

                _TipoDocumentoEntity.ResultData = TipoDocumentoAccess.SelectTipoDocumento(_TipoDocumentoEntity, sConnectionRepositorio);

                _ErrorId = TipoDocumentoAccess.ErrorId;
                _ErrorDescription = TipoDocumentoAccess.ErrorDescription;
            }
        #endregion
    }
}
