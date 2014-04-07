using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTSolicitudCiudadano : ENTBase
    {
        private int _SolicitudId; // Valor de SolicitudId
        private int _CiudadanoId; // Valor de CiudadanoId
        private int _TipoCiudadanoId; // Valor de TipoCiudadanoId
        private DataSet _dsResponse; // Valor del dataset 

        public ENTSolicitudCiudadano()
        {
            _SolicitudId = 0;
            _CiudadanoId = 0;
            _TipoCiudadanoId = 0;
            _dsResponse = new DataSet();
        }
        ///<remarks>
        ///   <name>SolicitudCiudadano.SolicitudId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SolicitudId</summary>
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }
        ///<remarks>
        ///   <name>SolicitudCiudadano.CiudadanoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CiudadanoId</summary>
        public int CiudadanoId
        {
            get { return _CiudadanoId; }
            set { _CiudadanoId = value; }
        }
        ///<remarks>
        ///   <name>SolicitudCiudadano.TipoCiudadanoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoCiudadanoId</summary>
        public int TipoCiudadanoId
        {
            get { return _TipoCiudadanoId; }
            set { _TipoCiudadanoId = value; }
        }
        ///<remarks>
        ///   <name>SolicitudCiudadano.dsResponse</name>
        ///   <create>07/abr/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna dsResponse</summary>
        public DataSet dsResponse
        {
            get { return _dsResponse; }
            set { _dsResponse = value; }
        }
    }
}
