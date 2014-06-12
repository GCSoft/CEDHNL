using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPExpedienteResolucion : BPBase
    {
        protected int _ErrorId;
        protected string _ErrorDescription;
        protected ENTExpedienteResolucion _ExpedienteResolucionEntity;

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
        ///     Propiedad pública de la entidad de la resolución.
        /// </summary>
        public ENTExpedienteResolucion ExpedienteResolucionEntity
        {
            get { return _ExpedienteResolucionEntity; }
            set { _ExpedienteResolucionEntity = value; }
        }

        /// <summary>
        ///     Constructor de la clase.
        /// </summary>
        public BPExpedienteResolucion()
        {
            _ErrorId = 0;
            _ErrorDescription = string.Empty;
            _ExpedienteResolucionEntity = new ENTExpedienteResolucion();
        }

        #region "Methods"
            public void DeleteExpedienteResolucion()
            {
                DAExpedienteResolucion ExpedienteResolucionAccess = new DAExpedienteResolucion();

                ExpedienteResolucionAccess.DeleteExpedienteResolucion(_ExpedienteResolucionEntity, sConnectionApplication);

                _ErrorId = ExpedienteResolucionAccess.ErrorId;
                _ErrorDescription = ExpedienteResolucionAccess.ErrorDescription;
            }

            public void SaveExpedienteEstatus(SqlConnection Connection, SqlTransaction Transaction, int ExpedienteId)
            {
                BPExpediente ExpedienteProcess = new BPExpediente();

                ExpedienteProcess.ExpedienteEntity.ExpedienteId = ExpedienteId;

                ExpedienteProcess.UpdateExpedienteEstatus(Connection, Transaction);
            }

            public void SaveExpedienteResolucion()
            {
                SqlTransaction Transaction;
                SqlConnection Connection = new SqlConnection(sConnectionApplication);
                DAExpedienteResolucion ExpedienteResolucionAccess = new DAExpedienteResolucion();

                if (!ValidarExpedienteResolucion())
                    return;

                Connection.Open();
                Transaction = Connection.BeginTransaction();

                try
                {
                    // Se guarda la información de la resolución
                    if (_ExpedienteResolucionEntity.ExpedienteResolucionId == 0)
                        ExpedienteResolucionAccess.InsertExpedienteResolucion(Connection, Transaction, _ExpedienteResolucionEntity);
                    else
                        ExpedienteResolucionAccess.UpdateExpedienteResolucion(Connection, Transaction, _ExpedienteResolucionEntity);

                    // Si todo sale bien, se le cambia el estatus al expediente
                    if (ExpedienteResolucionAccess.ErrorId == 0)
                        SaveExpedienteEstatus(Connection, Transaction, _ExpedienteResolucionEntity.ExpedienteId);
                    else
                    {
                        _ErrorId = ExpedienteResolucionAccess.ErrorId;
                        _ErrorDescription = ExpedienteResolucionAccess.ErrorDescription;
                    }

                    if (_ErrorId == 0)
                        Transaction.Commit();
                    else
                        Transaction.Rollback();

                    Connection.Close();
                }
                catch (SqlException Ex)
                {
                    _ErrorId = 50000;
                    _ErrorDescription = Ex.Message;

                    Transaction.Rollback();

                    if (Connection.State == ConnectionState.Open)
                        Connection.Close();
                }
            }

            public void SelectExpedienteResolucion()
            {
                DAExpedienteResolucion ExpedienteResolucionAccess = new DAExpedienteResolucion();

                _ExpedienteResolucionEntity.ResultData = ExpedienteResolucionAccess.SelectExpedienteResolucion(_ExpedienteResolucionEntity, sConnectionApplication);

                _ErrorId = ExpedienteResolucionAccess.ErrorId;
                _ErrorDescription = ExpedienteResolucionAccess.ErrorDescription;
            }

            private bool ValidarExpedienteResolucion()
            {
                if (_ExpedienteResolucionEntity.ExpedienteId == 0)
                {
                    _ErrorId = 50001;
                    _ErrorDescription = "Se debe proporcionar un número de expediente para la resolución";
                    return false;
                }

                if (_ExpedienteResolucionEntity.FuncionarioId == 0)
                {
                    _ErrorId = 50002;
                    _ErrorDescription = "Se debe proporcionar un funcionario para la resolución";
                    return false;
                }

                if (_ExpedienteResolucionEntity.TipoResolucionId == 0)
                {
                    _ErrorId = 50003;
                    _ErrorDescription = "El campo Tipo de Resolucion es obligatorio";
                    return false;
                }

                if (_ExpedienteResolucionEntity.Detalle == "")
                {
                   _ErrorId = 50005;
                   _ErrorDescription = "El campo Detalle es obligatorio";
                   return false;
                }

                if (_ExpedienteResolucionEntity.Fecha == "")
                {
                    _ErrorId = 50004;
                    _ErrorDescription = "Se debe proporcionar una fecha de la resolución";
                    return false;
                }

                return true;
            }
        #endregion
    }
}
