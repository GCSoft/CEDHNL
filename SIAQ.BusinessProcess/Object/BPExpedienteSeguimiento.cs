using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPExpedienteSeguimiento : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTExpedienteSeguimiento _ExpedienteSeguimientoEntity;

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
        ///     Propiedad pública de la entidad de expediente seguimiento.
        /// </summary>
        public ENTExpedienteSeguimiento ExpedienteSeguimientoEntity
        {
            get { return _ExpedienteSeguimientoEntity; }
            set { _ExpedienteSeguimientoEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPExpedienteSeguimiento()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _ExpedienteSeguimientoEntity = new ENTExpedienteSeguimiento();
        }

        #region "Methods"
            public void SaveExpedienteSeguimiento()
            {
                DAExpedienteSeguimiento ExpedienteSeguimientoAccess = new DAExpedienteSeguimiento();

                if (ExpedienteSeguimientoEntity.ExpedienteSeguimientoId == 0)
                    ExpedienteSeguimientoAccess.InsertExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionRepositorio);
                else
                    ExpedienteSeguimientoAccess.UpdateExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionRepositorio);

                _ErrorId = ExpedienteSeguimientoAccess.ErrorId;
                _ErrorDescription = ExpedienteSeguimientoAccess.ErrorDescription;
            }

            public void SelectRepositorioSE()
            {
                string ConnectionString = string.Empty;
                DAExpedienteSeguimiento ExpedienteSeguimientoAccess = new DAExpedienteSeguimiento();

                ExpedienteSeguimientoEntity.ResultData = ExpedienteSeguimientoAccess.SelectExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionRepositorio);

                _ErrorId = ExpedienteSeguimientoAccess.ErrorId;
                _ErrorDescription = ExpedienteSeguimientoAccess.ErrorDescription;
            }
        #endregion
    }
}
