using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPCanalizacion : BPBase
    {
        private int _ErrorId;
        private string _ErrorDescription;
        private ENTCanalizacion _ENTCanalizacion;//

        public BPCanalizacion()
        {

            _ErrorId = 0;
            _ErrorDescription = "";
            _ENTCanalizacion = new ENTCanalizacion();

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
        ///     Entidad de canalizacion
        /// </summary>
        public ENTCanalizacion ENTCanalizacion
        {
            get { return _ENTCanalizacion; }
            set { _ENTCanalizacion = value; }
        }

        public DataSet SelectCanalizacion()
        {
            string ConnectionString = string.Empty;
            DACanalizacion DACanalizacion = new DACanalizacion();

            ConnectionString = sConnectionApplication;
            _ENTCanalizacion.ResultData = DACanalizacion.SelectCanalizacion(_ENTCanalizacion, ConnectionString);

            _ErrorId = DACanalizacion.ErrorId;
            _ErrorDescription = DACanalizacion.ErrorDescription;

            return _ENTCanalizacion.ResultData;

        }
    }
}
