using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
    public class ENTDiligencia : ENTBase
    {

        #region Atributos

        private int _DiligenciaId;                      // Identificador único de la diligencia
        private int _SolicitudId;                      // Identificador único de la solicitud
        private int _ExpedienteId;                      // Identificador único del expediente
        private int _RecomendacionId;                      // Identificador único de la recomendación
        private int _FuncionarioAtiendeId;                      // Identificador único del funcionario que atiende
        private int _FuncionarioEjecuta;                      // Identificador único del funcionario que ejecuta la diligencia
        private String _FechaDiligencia;                      // Fecha de la diligencia
        private DateTime _FechaRegistro;                      // Fecha de registro 
        private int _TipoDiligencia;                      // Identificador único del tipo de diligencia
        private string _NombreTipoDiligencia;                      // Nombre del tipo de diligencia
        private int _LugarDiligenciaId;                      // Identificador único del lugar de la diligencia
        private string _NombreLugarDiligencia;                      // Nombre del lugar de la diligencia
        private string _Detalle;                      // Detalle de la diligencia
        private string _SolicitadaPor;                       // Persona que solicitó la diligencia
        private string _Resultado;                      // Resultado de la diligencia

        private DataSet _DataResult;                    // dataset 

        #endregion

        #region Propiedades

        ///<remarks>
        ///   <name>ENTExpediente.DiligenciaId</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna DiligenciaId</summary>
        public int DiligenciaId
        {
            get { return _DiligenciaId; }
            set { _DiligenciaId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.SolicitudId</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SolicitudId</summary>
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.ExpedienteId</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ExpedienteId</summary>
        public int ExpedienteId
        {
            get { return _ExpedienteId; }
            set { _ExpedienteId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.RecomendacionId</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna RecomendacionId</summary>
        public int RecomendacionId
        {
            get { return _RecomendacionId; }
            set { _RecomendacionId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.FuncionarioAtiendeId</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FuncionarioAtiendeId</summary>
        public int FuncionarioAtiendeId
        {
            get { return _FuncionarioAtiendeId; }
            set { _FuncionarioAtiendeId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.FuncionarioEjecuta</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FuncionarioEjecuta</summary>
        public int FuncionarioEjecuta
        {
            get { return _FuncionarioEjecuta; }
            set { _FuncionarioEjecuta = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.FechaDiligencia</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaDiligencia</summary>
		public String FechaDiligencia
        {
            get { return _FechaDiligencia; }
            set { _FechaDiligencia = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.FechaRegistro</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaRegistro</summary>
        public DateTime FechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.TipoDiligencia</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoDiligencia</summary>
        public int TipoDiligencia
        {
            get { return _TipoDiligencia; }
            set { _TipoDiligencia = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.NombreTipoDiligencia</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NombreTipoDiligencia</summary>
        public string NombreTipoDiligencia
        {
            get { return _NombreTipoDiligencia; }
            set { _NombreTipoDiligencia = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.LugarDiligenciaId</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna LugarDiligenciaId</summary>
        public int LugarDiligenciaId
        {
            get { return _LugarDiligenciaId; }
            set { _LugarDiligenciaId = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.NombreLugarDiligencia</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NombreLugarDiligencia</summary>
        public string NombreLugarDiligencia
        {
            get { return _NombreLugarDiligencia; }
            set { _NombreLugarDiligencia = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.Detalle</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Detalle</summary>
        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.SolicitadaPor</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SolicitadaPor</summary>
        public string SolicitadaPor
        {
            get { return _SolicitadaPor; }
            set { _SolicitadaPor = value; }
        }

        ///<remarks>
        ///   <name>ENTExpediente.Resultado</name>
        ///   <create>30/Marzo/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Obtiene resultado</summary>
        public string Resultado
        {
            get { return _Resultado; }
            set { _Resultado = value; }
        }

        public DataSet DataResult
        {
            get { return _DataResult; }
            set { _DataResult = value; }
        }

        #endregion

    }
}
