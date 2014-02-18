using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTFuncionario : ENTBase
    {
        private int _FuncionarioId; // Valor de FuncionarioId
        private int _TituloId; // Valor de TituloId
        private int _AreaId; // Valor de AreaId
        private int _PuestoId; // Valor de PuestoId
        private string _Nombre; // Valor de Nombre
        private string _ApellidoPaterno; // Valor de ApellidoPaterno
        private string _ApellidoMaterno; // Valor de ApellidoMaterno
        private string _FechaIngreso; // Valor de FechaIngreso
        private DataSet _ResultData; //Otras propiedades
        private string _Descripcion; // Valor de Descripcion
        public ENTFuncionario()
        {

            _Descripcion = "";
            _FuncionarioId = 0;
            _TituloId = 0;
            _AreaId = 0;
            _PuestoId = 0;
            _Nombre = "";
            _ApellidoPaterno = "";
            _ApellidoMaterno = "";
            _FechaIngreso = "";
        }
        ///<remarks>
        ///   <name>Funcionario.FuncionarioId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FuncionarioId</summary>
        public int FuncionarioId
        {
            get { return _FuncionarioId; }
            set { _FuncionarioId = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.TituloId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TituloId</summary>
        public int TituloId
        {
            get { return _TituloId; }
            set { _TituloId = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.AreaId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna AreaId</summary>
        public int AreaId
        {
            get { return _AreaId; }
            set { _AreaId = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.PuestoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna PuestoId</summary>
        public int PuestoId
        {
            get { return _PuestoId; }
            set { _PuestoId = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.Nombre</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Nombre</summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.ApellidoPaterno</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ApellidoPaterno</summary>
        public string ApellidoPaterno
        {
            get { return _ApellidoPaterno; }
            set { _ApellidoPaterno = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.ApellidoMaterno</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ApellidoMaterno</summary>
        public string ApellidoMaterno
        {
            get { return _ApellidoMaterno; }
            set { _ApellidoMaterno = value; }
        }
        ///<remarks>
        ///   <name>Funcionario.FechaIngreso</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaIngreso</summary>
        public string FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }

    }
}
