/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTIndicador
' Autor: Ruben.Cobos
' Fecha: 18-Julio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using System.Data;

namespace SIAQ.Entity.Object
{
	public class ENTIndicador
	{

		// Definiciones
		private Int32	_IndicadorId;	// Identificador único del Indicador a consultar
		private String	_Nombre;		// Nombre del indicador
		private String	_Descripcion;	// Descripcion del indicador


		 //Constructor

        public ENTIndicador(){
			_IndicadorId = 0;
			_Nombre = "";
			_Descripcion = "";
        }


		// Propiedades

		///<remarks>
		///   <name>ENTIndicador.IndicadorId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del indicador a consultar</summary>
		public Int32 IndicadorId
		{
			get { return _IndicadorId; }
			set { _IndicadorId = value; }
		}

        ///<remarks>
		///   <name>ENTIndicador.Nombre</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del indicador</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTIndicador.Descripcion</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna las Descripcion de un Indicador</summary>
		public String Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}

	}
}
