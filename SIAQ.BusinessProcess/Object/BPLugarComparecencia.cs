using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPLugarComparecencia : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTLugarComparecencia _LugarComparecenciaEntity;

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
        public ENTLugarComparecencia LugarComparecenciaEntity
        {
            get { return _LugarComparecenciaEntity; }
            set { _LugarComparecenciaEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPLugarComparecencia()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _LugarComparecenciaEntity = new ENTLugarComparecencia();
        }

        #region "Methods"
            /// <summary>
            ///     Realiza una búsqueda de los lugares de una comparecencia.
            /// </summary>
            public void SelectLugarComparecencia()
            {
                DALugarComparecencia LugarComparecenciaAccess = new DALugarComparecencia();

                LugarComparecenciaEntity.ResultData = LugarComparecenciaAccess.SelectLugarComparecencia(_LugarComparecenciaEntity, sConnectionApplication);

                _ErrorId = LugarComparecenciaAccess.ErrorId;
                _ErrorDescription = LugarComparecenciaAccess.ErrorDescription;
            }
        #endregion
    }
}
