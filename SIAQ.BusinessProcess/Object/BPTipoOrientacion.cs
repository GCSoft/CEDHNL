using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
namespace SIAQ.BusinessProcess.Object
{
    public class BPTipoOrientacion : BPBase
    {
        private int _ErrorId;
        private string _ErrorDescription;
        private ENTTipoOrientacion _ENTTipoOrientacion;//

        public BPTipoOrientacion()
        {

            _ErrorId = 0;
            _ErrorDescription = "";
            _ENTTipoOrientacion = new ENTTipoOrientacion();

        }

        /// <summary>
        ///     Número de error ocurrido. Cero por default
        /// </summary>
        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        /// <summary>
        ///     Descripción del error ocurrido
        /// </summary>
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        /// <summary>
        ///     Entidad de orientacion
        /// </summary>
        public ENTTipoOrientacion ENTTipoOrientacion
        {
            get { return _ENTTipoOrientacion; }
            set { _ENTTipoOrientacion = value; }
        }

        public DataSet SelectTipoOrientacion()
        {
            string ConnectionString = string.Empty;
            DATipoOrientacion DATipoOrientacion = new DATipoOrientacion();

            ConnectionString = sConnectionApplication;
            _ENTTipoOrientacion.ResultData = DATipoOrientacion.SelectTipoOrientacion(_ENTTipoOrientacion, ConnectionString);

            _ErrorId = DATipoOrientacion.ErrorId;
            _ErrorDescription = DATipoOrientacion.ErrorDescription;

            return _ENTTipoOrientacion.ResultData;

        }
    }
}
