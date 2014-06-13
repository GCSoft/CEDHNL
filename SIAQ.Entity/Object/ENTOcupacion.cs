/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTOcupacion
' Autor: Daniel.Chavez
' Fecha: 11-Junio-2014
'
' Proposito:
'          Clase que modela el catálogo de Ocupacion de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace SIAQ.Entity.Object
{
   public class ENTOcupacion : ENTBase
    {
        // Definiciones
       private Int32 _OcupacionId;              // Identificador único de Ocupacion
       private string _Nombre;                  // Nombre de la ocupacion
       private string _Descripcion;             // Descripión de la ocupacion

       private DataSet _ResultData; //Otras propiedades

       //Constructor
       public ENTOcupacion() {
           _OcupacionId = 0;
           _Nombre = "";
           _Descripcion = "";

       }

       // Propiedades

       ///<remarks>
       ///   <name>ENTOcupacion.OcupacionId</name>
       ///   <create>11-Junio-2014</create>
       ///   <author>Daniel.Chavez</author>
       ///</remarks>
       ///<summary>Obtiene/Asigna el identificador único de la Ocupación</summary>
       public Int32 OcupacionId {
           get { return _OcupacionId; }
           set { _OcupacionId = value; }
       }

       ///<remarks>
       ///   <name>ENTOcupacion.OcupacionId</name>
       ///   <create>11-Junio-2014</create>
       ///   <author>Daniel.Chavez</author>
       ///</remarks>
       ///<summary>Obtiene/Asigna el nombre de la Ocupación</summary>
       public string Nombre {
           get { return _Nombre; }
           set { _Nombre = value; }
       }

       ///<remarks>
       ///   <name>ENTOcupacion.OcupacionId</name>
       ///   <create>11-Junio-2014</create>
       ///   <author>Daniel.Chavez</author>
       ///</remarks>
       ///<summary>Obtiene/Asigna la descripción de la Ocupación</summary>
       public string Descripcion {
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
