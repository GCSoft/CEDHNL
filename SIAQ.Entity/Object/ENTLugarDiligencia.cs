using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SIAQ.Entity.Object
{
	public class ENTLugarDiligencia : ENTBase
	{
      
      private int _LugarDiligenciaId;       // Valor de LugarDiligenciaId
      private string    _Nombre;       // Valor de Nombre
      private string    _Descripcion;  // Valor de Descripcion
      private DataSet   _ResultData;   // Otras propiedades

      public ENTLugarDiligencia()
      {
         
         _LugarDiligenciaId = 0;
         _Nombre        = "";
         _Descripcion   = "";
         _ResultData    = null;
      }

      ///<remarks>
      ///   <name>ENTLugarDiligencia.LugarDiligenciaId</name>
      ///   <create>27/ene/2014</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna LugarDiligenciaId</summary>
      public int LugarDiligenciaId
      {
          get { return _LugarDiligenciaId; }
          set { _LugarDiligenciaId = value; }
      }

      ///<remarks>
      ///   <name>ENTLugarDiligencia.Nombre</name>
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
      ///   <name>ENTLugarDiligencia.Descripcion</name>
      ///   <create>27/ene/2014</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna Descripcion</summary>
      public string Descripcion
      {
         get { return _Descripcion; }
         set { _Descripcion = value; }
      }

      /// <summary>
      ///     DataSet resultante de las busquedas en la base de datos
      /// </summary>
      public DataSet ResultData
      {
         get { return _ResultData; }
         set { _ResultData = value; }
      }

      
	}
}
