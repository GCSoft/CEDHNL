/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTArchivoExpediente
' Autor: Ruben.Cobos
' Fecha: 11-Junio-2014
'
' Proposito:
'          Clase que modela el catálogo de ArchivoExpedientees de la aplicación
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{

	public class ENTArchivoExpediente : ENTBase
	{

		// Definiciones
		private Int32	_idUsuario;	// Identificador único del Usuario que tiene asignado el Expediente
		private String	_Numero;	// Número de expediente a filtrar
		private String	_Quejoso;	// Nombre del quejoso que levanta la denuncia

		
		 //Constructor

		public ENTArchivoExpediente()
		{
			_idUsuario = 0;
			_Numero = "";
			_Quejoso = "";
		}


		// Propiedades

		///<remarks>
		///   <name>ENTArchivoExpediente.idUsuario</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del Usuario que tiene asignado el Expediente</summary>
		public Int32 idUsuario
		{
			get { return _idUsuario; }
			set { _idUsuario = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.Numero</name>
		///   <create>11-Junio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de expediente a filtrar</summary>
		public String Numero
		{
			get { return _Numero; }
			set { _Numero = value; }
		}

		///<remarks>
		///   <name>ENTArchivoExpediente.Quejoso</name>
		///   <create>11-Junio-2014</create>
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
