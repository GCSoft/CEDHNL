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
        #endregion
    }
}
