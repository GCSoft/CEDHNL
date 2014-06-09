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
            public void DeleteExpedienteSeguimiento()
            {
                DAExpedienteSeguimiento ExpedienteSeguimientoAccess = new DAExpedienteSeguimiento();

                ExpedienteSeguimientoAccess.DeleteExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionApplication);

                _ErrorId = ExpedienteSeguimientoAccess.ErrorId;
                _ErrorDescription = ExpedienteSeguimientoAccess.ErrorDescription;
            }

            public void SaveExpedienteSeguimiento()
            {
                DAExpedienteSeguimiento ExpedienteSeguimientoAccess = new DAExpedienteSeguimiento();

                if (!ValidarExpedienteSeguimiento())
                    return;

                if (ExpedienteSeguimientoEntity.ExpedienteSeguimientoId == 0)
                    ExpedienteSeguimientoAccess.InsertExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionApplication);
                else
                    ExpedienteSeguimientoAccess.UpdateExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionApplication);

                _ErrorId = ExpedienteSeguimientoAccess.ErrorId;
                _ErrorDescription = ExpedienteSeguimientoAccess.ErrorDescription;
            }

            public void SelectExpedienteSeguimiento()
            {
                DAExpedienteSeguimiento ExpedienteSeguimientoAccess = new DAExpedienteSeguimiento();

                ExpedienteSeguimientoEntity.ResultData = ExpedienteSeguimientoAccess.SelectExpedienteSeguimiento(_ExpedienteSeguimientoEntity, sConnectionApplication);

                _ErrorId = ExpedienteSeguimientoAccess.ErrorId;
                _ErrorDescription = ExpedienteSeguimientoAccess.ErrorDescription;
            }

            private bool ValidarExpedienteSeguimiento()
            {
                if (_ExpedienteSeguimientoEntity.ExpedienteId == 0)
                {
                    _ErrorId = 50001;
                    _ErrorDescription = "Se debe proporcionar un número de expediente para el seguimiento";
                    return false;
                }

               if (_ExpedienteSeguimientoEntity.FuncionarioId == 0)
                {
                    _ErrorId = 50002;
                    _ErrorDescription = "Se debe proporcionar un funcionario para el seguimiento";
                    return false;
                }

               if (_ExpedienteSeguimientoEntity.TipoSeguimientoId == 0)
               {
                   _ErrorId = 50003;
                   _ErrorDescription = "El campo Tipo de seguimiento es obligatorio";
                   return false;
               }

               if (_ExpedienteSeguimientoEntity.Fecha == "")
               {
                   _ErrorId = 50004;
                   _ErrorDescription = "El campo Fecha es obligatorio";
                   return false;
               }

               if (_ExpedienteSeguimientoEntity.Detalle == "")
               {
                   _ErrorId = 50005;
                   _ErrorDescription = "El campo Detalle es obligatorio";
                   return false;
               }

                return true;
            }
        #endregion
    }
}
