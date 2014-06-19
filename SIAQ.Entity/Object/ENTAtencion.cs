using System;
using System.Collections.Generic;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTAtencion : ENTBase
    {
        private int _AtencionId; // Valor de AtencionId
        private int _SolicitudId; // Valor de SolicitudId
        private int _ExpedienteId; // Valor de ExpedienteId
        private int _EstatusId; // Valor de EstatusId
        private string _Numero; // Valor de Numero
        private string _Fecha; // Valor de Fecha
        private string _Observaciones; // Valor de Observaciones
        private int _IdUsuario; // Usuario
        private int _ErrorId;
        private string _ErrorString;
        private int _Aprobar; // Aprobar o no aprobar atención
        private string _NombreCiudadano; // Nombre del ciudadano
        private int _DoctorId; // Identificador del doctor


		private Int32	_FuncionarioId;		// Identificador del funcionario que tiene asignado el caso
		private String	_Comentario;		// Comentario en el expediente de Atención a Víctimas
		private String	_Quejoso;			// Nombre del quejoso que levanta la denuncia


        public ENTAtencion(){
            _AtencionId = 0;
            _SolicitudId = 0;
            _ExpedienteId = 0;
            _EstatusId = 0;
            _Numero = "";
            _Fecha = "";
            _Observaciones = "";
            _IdUsuario = 0;
            _ErrorId = 0;
            _ErrorString = "";
            _Aprobar = 0;
            _NombreCiudadano = "";
            _DoctorId = 0;

			_FuncionarioId = 0;
			_Comentario = "";
			_Quejoso = "";
        }


        ///<remarks>
        ///   <name>Atencion.AtencionId</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna AtencionId</summary>
        public int AtencionId
        {
            get { return _AtencionId; }
            set { _AtencionId = value; }
        }
        ///<remarks>
        ///   <name>Atencion.SolicitudId</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SolicitudId</summary>
        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }
        ///<remarks>
        ///   <name>Atencion.ExpedienteId</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ExpedienteId</summary>
        public int ExpedienteId
        {
            get { return _ExpedienteId; }
            set { _ExpedienteId = value; }
        }
        ///<remarks>
        ///   <name>Atencion.EstatusId</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstatusId</summary>
        public int EstatusId
        {
            get { return _EstatusId; }
            set { _EstatusId = value; }
        }
        ///<remarks>
        ///   <name>Atencion.Numero</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Numero</summary>
        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }
        ///<remarks>
        ///   <name>Atencion.Fecha</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Fecha</summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        ///<remarks>
        ///   <name>Atencion.Observaciones</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Observaciones</summary>
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        ///<remarks>
        ///   <name>Atencion.IdUsuario</name>
        ///   <create>04/jun/2014</create>
        ///   <author>JJ</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Idde Usuario</summary>
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        ///<remarks>
        ///   <name>Atencion.ErrorId</name>
        ///   <create>04/jun/2014</create>
        ///   <author>JJ</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Idde Usuario</summary>
        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }
        ///<remarks>
        ///   <name>Atencion.ErrorString</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Observaciones</summary>
        public string ErrorString
        {
            get { return _ErrorString; }
            set { _ErrorString = value; }
        }
        ///<remarks>
        ///   <name>Atencion.Aprobar</name>
        ///   <create>04/jun/2014</create>
        ///   <author>JJ</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Idde Usuario</summary>
        public int Aprobar
        {
            get { return _Aprobar; }
            set { _Aprobar = value; }
        }
        ///<remarks>
        ///   <name>Atencion.NombreCiudadano</name>
        ///   <create>04/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Observaciones</summary>
        public string NombreCiudadano
        {
            get { return _NombreCiudadano; }
            set { _NombreCiudadano = value; }
        }
        ///<remarks>
        ///   <name>Atencion.DoctorId</name>
        ///   <create>04/jun/2014</create>
        ///   <author>JJ</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Idde Usuario</summary>
        public int DoctorId
        {
            get { return _DoctorId; }
            set { _DoctorId = value; }
        }



		///<remarks>
		///   <name>ENTAtencion.FuncionarioId</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del funcionario que tiene asignado el caso</summary>
		public Int32 FuncionarioId
		{
			get { return _FuncionarioId; }
			set { _FuncionarioId = value; }
		}

		///<remarks>
		///   <name>ENTAtencion.Comentario</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el comentario en el expediente de Atención a Víctimas</summary>
		public String Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
		}

		///<remarks>
		///   <name>ENTAtencion.Quejoso</name>
		///   <create>19-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del quejoso que levanta la denuncia</summary>
		public String Quejoso
		{
			get { return _Quejoso; }
			set { _Quejoso = value; }
		}

    }
}
