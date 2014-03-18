using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTPais : ENTBase
    {

      private Int16     _Activo;       // Control de baja lógica de registro
      private int       _PaisId;       // Valor de PaisId
      private string    _Nombre;       // Valor de Nombre
      private string    _Descripcion;  // Valor de Descripcion
      private DataSet   _ResultData;   // Otras propiedades

      public ENTPais(){
         _Activo        = 0;
         _PaisId        = 0;
         _Nombre        = "";
         _Descripcion   = "";
         _ResultData    = null;
      }

      ///<remarks>
      ///   <name>Pais.PaisId</name>
      ///   <create>27/ene/2014</create>
      ///   <author>Generador</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna PaisId</summary>
      public int PaisId
      {
         get { return _PaisId; }
         set { _PaisId = value; }
      }

      ///<remarks>
      ///   <name>Pais.Nombre</name>
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
      ///   <name>Pais.Descripcion</name>
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

      ///<remarks>
      ///   <name>ENTPais.Activo</name>
      ///   <create>17-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene/Asigna el control de baja lógica de registro</summary>
      public Int16 Activo
      {
         get { return _Activo; }
         set { _Activo = value; }
      }

    }
}

