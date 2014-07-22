/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: ENTQueja
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
	public class ENTQueja
	{

		// Definiciones
		private Int32	_FormaContactoId;	// Identificador único de la forma de contacto
		private Int32	_FuncionarioId;		// Identificador único del funcionario asociado a la solicitud
		private Int32	_LugarHechosId;		// Identificador único del lugar de los hechos asociado a la solicitud
		private Int32	_SolicitudId;		// Identificador único de la solicitud a consultar
		private Int32	_UsuarioId;			// Identificador único de Usuario
		private String	_Comentario;		// Comentarios
		private String	_DireccionHechos;	// Dirección de los hechos en una solicitud
		private String	_FechaDesde;		// Fecha de inicio en una consulta
		private String	_FechaHasta;		// Fecha final en una consulta
		private Int16	_Nivel;				// Nivel de transacción
		private String	_Nombre;			// Nombre del ciudadano
		private String	_Numero;			// Número de la solicitud
		private String	_Observaciones;		// Observaciones de la solicitud


		 //Constructor

        public ENTQueja(){
			_FormaContactoId = 0;
			_FuncionarioId = 0;
			_LugarHechosId = 0;
			_SolicitudId = 0;
			_UsuarioId = 0;
			_Comentario = "";
			_DireccionHechos = "";
			_FechaDesde = "";
			_FechaHasta = "";
			_Nivel = -1;
			_Nombre = "";
			_Numero = "";
			_Observaciones = "";
        }


		// Propiedades

		///<remarks>
		///   <name>ENTQueja.FormaContactoId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la forma de contacto</summary>
		public Int32 FormaContactoId
		{
			get { return _FormaContactoId; }
			set { _FormaContactoId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FuncionarioId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del funcionario asociado a la solicitud</summary>
		public Int32 FuncionarioId
		{
			get { return _FuncionarioId; }
			set { _FuncionarioId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.LugarHechosId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único del lugar de los hechos asociado a la solicitud</summary>
		public Int32 LugarHechosId
		{
			get { return _LugarHechosId; }
			set { _LugarHechosId = value; }
		}

		///<remarks>
		///   <name>ENTQueja.SolicitudId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador único de la solicitud a consultar</summary>
		public Int32 SolicitudId
		{
			get { return _SolicitudId; }
			set { _SolicitudId = value; }
		}

        ///<remarks>
		///   <name>ENTQueja.UsuarioId</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna el identificador único de Usuario</summary>
        public Int32 UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

		///<remarks>
		///   <name>ENTQueja.Comentario</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna los comentarios de una queja </summary>
		public String Comentario
		{
			get { return _Comentario; }
			set { _Comentario = value; }
		}

		///<remarks>
		///   <name>ENTQueja.DireccionHechos</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la dirección de los hecho sde una solicitud</summary>
		public String DireccionHechos
		{
			get { return _DireccionHechos; }
			set { _DireccionHechos = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FechaDesde</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha de inicio en una consulta</summary>
		public String FechaDesde
		{
			get { return _FechaDesde; }
			set { _FechaDesde = value; }
		}

		///<remarks>
		///   <name>ENTQueja.FechaHasta</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna la fecha final en una consulta</summary>
		public String FechaHasta
		{
			get { return _FechaHasta; }
			set { _FechaHasta = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Nivel</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nivel de la transacción</summary>
		public Int16 Nivel
		{
			get { return _Nivel; }
			set { _Nivel = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Nombre</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del ciudadano</summary>
		public String Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Numero</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el número de la solicitud</summary>
		public String Numero
		{
			get { return _Numero; }
			set { _Numero = value; }
		}

		///<remarks>
		///   <name>ENTQueja.Observaciones</name>
		///   <create>18-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna las observaciones de una solicitud</summary>
		public String Observaciones
		{
			get { return _Observaciones; }
			set { _Observaciones = value; }
		}

	}
}
