using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
   public class ENTFuncionario : ENTBase
   {
       
      private Int32 _idUsuario;	// Identificador único del usuario asociado al funcionario
      private Int32 _idArea;	// Identificador único del área al que pertence el funcionario
	  private Int32 _idRol;		// Identificador único del Rol al que pertence el funcionario, aquí se determina a la sección de la aplicacion que puede acceder

        private int _FuncionarioId; // Valor de FuncionarioId
        private int _TituloId; // Valor de TituloId
        private int _PuestoId; // Valor de PuestoId
        private string _Nombre; // Valor de Nombre
        private string _ApellidoPaterno; // Valor de ApellidoPaterno
        private string _ApellidoMaterno; // Valor de ApellidoMaterno
        private string _FechaIngreso; // Valor de FechaIngreso
        private DataSet _ResultData; //Otras propiedades
        private string _Descripcion; // Valor de Descripcion

      public ENTFuncionario()
      {

         _idUsuario = 0;
         _idArea = 0;
		 _idRol = 0;

           _Descripcion = "";
            _FuncionarioId = 0;
            _TituloId = 0;
            _PuestoId = 0;
            _Nombre = "";
            _ApellidoPaterno = "";
            _ApellidoMaterno = "";
            _FechaIngreso = "";
        }


      ///<remarks>
      ///   <name>ENTFuncionario.idUsuario</name>
      ///   <create>06-Abril-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del usuario asociado al funcionario</summary>
      public Int32 idUsuario
      {
         get { return _idUsuario; }
         set { _idUsuario = value; }
      }

      ///<remarks>
      ///   <name>ENTFuncionario.idArea</name>
      ///   <create>06-Abril-2013</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el identificador único del área al que pertence el funcionario</summary>
      public int idArea
      {
         get { return _idArea; }
         set { _idArea = value; }
      }

	  ///<remarks>
	  ///   <name>ENTFuncionario.idRol</name>
	  ///   <create>06-Abril-2013</create>
	  ///   <author>Ruben.Cobos</author>
	  ///</remarks>
	  ///<summary>Obtiene/Asigna el identificador único del Rol al que pertence el funcionario, aquí se determina a la sección de la aplicacion que puede acceder</summary>
	  public Int32 idRol
	  {
		  get { return _idRol; }
		  set { _idRol = value; }
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
