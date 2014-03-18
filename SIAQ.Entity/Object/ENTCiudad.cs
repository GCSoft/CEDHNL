using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
   public class ENTCiudad : ENTBase
   {
      
      private Int16     _Activo;       // Control de baja lógica de registro
      private int       _CiudadId;     // Valor de CiudadId
      private int       _EstadoId;     // Valor de EstadoId
      private string    _Nombre;       // Valor de Nombre
      private string    _Descripcion;  // Valor de Descripcion
      private DataSet   _ResultData;   //Otras propiedades

      public ENTCiudad()
      {
         _Activo        = 0;
         _CiudadId      = 0;
         _EstadoId      = 0;
         _Nombre        = "";
         _Descripcion   = "";
      }

        ///<remarks>
        ///   <name>Ciudad.CiudadId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CiudadId</summary>
        public int CiudadId
        {
            get { return _CiudadId; }
            set { _CiudadId = value; }
        }

        ///<remarks>
        ///   <name>Ciudad.EstadoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstadoId</summary>
        public int EstadoId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }

        ///<remarks>
        ///   <name>Ciudad.Nombre</name>
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
        ///   <name>Ciudad.Descripcion</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
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

        ///<remarks>
        ///   <name>ENTCiudad.Activo</name>
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