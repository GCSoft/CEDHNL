using System;
using System.Collections.Generic;
using System.Text;
namespace SIAQ.Entity.Object
{
    public class ENTDictamen
    {
        private int _DictamenId; // Valor de DictamenId
        private int _AtencionId; // Valor de AtencionId
        private int _CiudadanoId; // Valor de CiudadanoId
        private int _LugarAtencionId; // Valor de LugarAtencionId
        private int _TipoDictamenId; // Valor de TipoDictamenId
		private int _FuncionarioId; // Valor de FuncionarioId
        private string _Fecha; // Valor de Fecha
        private string _Dictamen; // Valor de Dictamen
		private string _Nombre; // Valor de Nombre

        public ENTDictamen()
        {
            _DictamenId = 0;
            _AtencionId = 0;
            _CiudadanoId = 0;
            _LugarAtencionId = 0;
            _TipoDictamenId = 0;
			_FuncionarioId = 0;
            _Fecha = "";
            _Dictamen = "";
			_Nombre = "";
        }
        ///<remarks>
        ///   <name>Dictamen.DictamenId</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna DictamenId</summary>
        public int DictamenId
        {
            get { return _DictamenId; }
            set { _DictamenId = value; }
        }
        ///<remarks>
        ///   <name>Dictamen.AtencionId</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna AtencionId</summary>
        public int AtencionId
        {
            get { return _AtencionId; }
            set { _AtencionId = value; }
        }
        ///<remarks>
        ///   <name>Dictamen.CiudadanoId</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CiudadanoId</summary>
        public int CiudadanoId
        {
            get { return _CiudadanoId; }
            set { _CiudadanoId = value; }
        }
        ///<remarks>
        ///   <name>Dictamen.LugarAtencionId</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna LugarAtencionId</summary>
        public int LugarAtencionId
        {
            get { return _LugarAtencionId; }
            set { _LugarAtencionId = value; }
        }
        ///<remarks>
        ///   <name>Dictamen.TipoDictamenId</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoDictamenId</summary>
        public int TipoDictamenId
        {
            get { return _TipoDictamenId; }
            set { _TipoDictamenId = value; }
        }
		///<remarks>
		///   <name>Dictamen.FuncionarioId</name>
		///   <create>11/jun/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Obtiene/Asigna FuncionarioId</summary>
		public int FuncionarioId
		{
			get { return _FuncionarioId; }
			set { _FuncionarioId = value; }
		}
        ///<remarks>
        ///   <name>Dictamen.Fecha</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Fecha</summary>
        public string Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        ///<remarks>
        ///   <name>Dictamen.Dictamen</name>
        ///   <create>11/jun/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Dictamen</summary>
        public string Dictamen
        {
            get { return _Dictamen; }
            set { _Dictamen = value; }
        }
		///<remarks>
		///   <name>Dictamen.Nombre</name>
		///   <create>11/jun/2014</create>
		///   <author>Generador</author>
		///</remarks>
		///<summary>Obtiene/Asigna Nombre</summary>
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}
    }
}
