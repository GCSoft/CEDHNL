using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPExpedienteComparecencia : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTExpedienteComparecencia _ExpedienteComparecenciaEntity;

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
        ///     Propiedad pública de la entidad de la comparecencia.
        /// </summary>
        public ENTExpedienteComparecencia ExpedienteComparecenciaEntity
        {
            get { return _ExpedienteComparecenciaEntity; }
            set { _ExpedienteComparecenciaEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPExpedienteComparecencia()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _ExpedienteComparecenciaEntity = new ENTExpedienteComparecencia();
        }

        #region "Methods"
            public void DeleteExpedienteComparecencia()
            {
                DAExpedienteComparecencia ExpedienteComparecenciaAccess = new DAExpedienteComparecencia();

                ExpedienteComparecenciaAccess.DeleteExpedienteComparecencia(_ExpedienteComparecenciaEntity, sConnectionApplication);

                _ErrorId = ExpedienteComparecenciaAccess.ErrorId;
                _ErrorDescription = ExpedienteComparecenciaAccess.ErrorDescription;
            }

            public void SaveExpedienteComparecencia()
            {
                DAExpedienteComparecencia ExpedienteComparecenciaAccess = new DAExpedienteComparecencia();

                if (!ValidarExpedienteComparecencia())
                    return;

                if (_ExpedienteComparecenciaEntity.ExpedienteComparecenciaId == 0)
                    ExpedienteComparecenciaAccess.InsertExpedienteComparecencia(_ExpedienteComparecenciaEntity, sConnectionApplication);
                else
                    ExpedienteComparecenciaAccess.UpdateExpedienteComparecencia(_ExpedienteComparecenciaEntity, sConnectionApplication);

                _ErrorId = ExpedienteComparecenciaAccess.ErrorId;
                _ErrorDescription = ExpedienteComparecenciaAccess.ErrorDescription;
            }

            public void SelectExpedienteComparecencia()
            {
                DAExpedienteComparecencia ExpedienteComparecenciaAccess = new DAExpedienteComparecencia();

                _ExpedienteComparecenciaEntity.ResultData = ExpedienteComparecenciaAccess.SelectExpedienteComparecencia(_ExpedienteComparecenciaEntity, sConnectionApplication);

                _ErrorId = ExpedienteComparecenciaAccess.ErrorId;
                _ErrorDescription = ExpedienteComparecenciaAccess.ErrorDescription;
            }

            private bool ValidarExpedienteComparecencia()
            {
                if (_ExpedienteComparecenciaEntity.ExpedienteId == 0)
                {
                    _ErrorId = 50001;
                    _ErrorDescription = "Se debe proporcionar un número de expediente para el seguimiento";
                    return false;
                }

                if (_ExpedienteComparecenciaEntity.FuncionarioId == 0)
                {
                    _ErrorId = 50002;
                    _ErrorDescription = "El campo funcionario es obligatorio";
                    return false;
                }

                if (_ExpedienteComparecenciaEntity.CiudadanoId == 0)
                {
                   _ErrorId = 50003;
                   _ErrorDescription = "El campo Ciudadano es obligatorio";
                   return false;
                }

                if (_ExpedienteComparecenciaEntity.LugarComparecenciaId == 0)
                {
                    _ErrorId = 50003;
                    _ErrorDescription = "El campo Lugar de comparecencia es obligatorio";
                    return false;
                }

                if (_ExpedienteComparecenciaEntity.TipoComparecenciaId == 0)
                {
                    _ErrorId = 50003;
                    _ErrorDescription = "El campo Tipo de comparecencia es obligatorio";
                    return false;
                }

                if (_ExpedienteComparecenciaEntity.Asunto == "")
                {
                    _ErrorId = 50005;
                    _ErrorDescription = "El campo Asunto es obligatorio";
                    return false;
                }

                if (_ExpedienteComparecenciaEntity.Detalle == "")
                {
                   _ErrorId = 50005;
                   _ErrorDescription = "El campo Detalle es obligatorio";
                   return false;
                }

                if (_ExpedienteComparecenciaEntity.Fecha == "")
                {
                    _ErrorId = 50004;
                    _ErrorDescription = "El campo Fecha es obligatorio";
                    return false;
                }

                return true;
            }
        #endregion
    }
}
