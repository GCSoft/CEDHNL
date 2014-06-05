using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SIAQ.Entity.Object
{
    public class ENTSeguimientoRecomendacion : ENTBase
    {

        #region Atributos

			private int _RecomendacionId;
			private int _FuncionarioId;
			private int _EsVigente;
			private DateTime _Fecha;
			private DataSet _ResultData;
			
			// Atributos para consulta de expedientes
			private Int32	_ExpedienteId;			// Identificador único del usuario que realiza la transacción
			private Int32	_UsuarioId;				// Identificador único del usuario que realiza la transacción
			private Int16	_Aprobar;				// Determina si se listarán los expedientes con Estatus 8 (Pendiente de aprobar Recomendación) cuando se establece en 1 ó se listaran los estatus 9 (Por asignar a defensor de Seguimientos) cuando se establece en 0
			private String	_Numero;				// Número de expediente a filtrar
			private String	_Quejoso;				// Nombre del quejoso que levanta la denuncia
			private Int32	_MedioComunicacionId;	// Identificador único de la forma de contacto. 0 para todas

        #endregion

        #region Propiedades

			///<remarks>
			///   <name>SeguimientoRecomendacion.RecomendacionId</name>
			///   <create>05/mar/2014</create>
			///   <author>Generador</author>
			///</remarks>
			/// <summary>
			/// Obtener/Asignar RecomendacionId
			/// </summary>
			public int RecomendacionId
			{
				get { return _RecomendacionId; }
				set { _RecomendacionId = value; }
			}

			///<remarks>
			///   <name>SeguimientoRecomendacion.FuncionarioId</name>
			///   <create>05/mar/2014</create>
			///   <author>Generador</author>
			///</remarks>
			/// <summary>
			/// Obtener/Asignar FuncionarioId
			/// </summary>
			public int FuncionarioId
			{
				get { return _FuncionarioId; }
				set { _FuncionarioId = value; }
			}

			///<remarks>
			///   <name>SeguimientoRecomendacion.EsVigente</name>
			///   <create>05/mar/2014</create>
			///   <author>Generador</author>
			///</remarks>
			/// <summary>
			/// Obtener/Asignar EsVigente
			/// </summary>
			public int EsVigente
			{
				get { return _EsVigente; }
				set { _EsVigente = value; }
			}

			///<remarks>
			///   <name>SeguimientoRecomendacion.Fecha</name>
			///   <create>05/mar/2014</create>
			///   <author>Generador</author>
			///</remarks>
			/// <summary>
			/// Obtener/Asignar Fecha
			/// </summary>
			public DateTime Fecha
			{
				get { return _Fecha; }
				set { _Fecha = value; }
			}

			///<remarks>
			///   <name>SeguimientoRecomendacion.ResultData</name>
			///   <create>05/mar/2014</create>
			///   <author>Generador</author>
			///</remarks>
			/// <summary>
			/// Obtener/Asignar ResultData
			/// </summary>
			public DataSet ResultData
			{
				get { return _ResultData; }
				set { _ResultData = value; }
			}


			// Propiedades para consulta de expedientes

			///<remarks>
			///   <name>ENTSeguimientoRecomendacion.ExpedienteId</name>
			///   <create>04-Junio-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene/Asigna el identificador único del expediente a consultar</summary>
			public Int32 ExpedienteId
			{
				get { return _ExpedienteId; }
				set { _ExpedienteId = value; }
			}

			///<remarks>
			///   <name>ENTSeguimientoRecomendacion.UsuarioId</name>
			///   <create>31-Mayo-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene/Asigna el identificador único del usuario que realiza la transacción</summary>
			public Int32 UsuarioId
			{
				get { return _UsuarioId; }
				set { _UsuarioId = value; }
			}

			///<remarks>
			///   <name>ENTSeguimientoRecomendacion.MedioComunicacionId</name>
			///   <create>31-Mayo-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene/Asigna el identificador único de la forma de contacto. 0 para todas</summary>
			public Int32 MedioComunicacionId
			{
				get { return _MedioComunicacionId; }
				set { _MedioComunicacionId = value; }
			}

			///<remarks>
			///   <name>ENTSeguimientoRecomendacion.Aprobar</name>
			///   <create>31-Mayo-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene/Asigna un valor que determina si se listarán los expedientes con Estatus 8 (Pendiente de aprobar Recomendación) cuando se establece en 1 ó se listaran los estatus 9 (Por asignar a defensor de Seguimientos) cuando se establece en 0</summary>
			public Int16 Aprobar
			{
				get { return _Aprobar; }
				set { _Aprobar = value; }
			}

			///<remarks>
			///   <name>ENTSeguimientoRecomendacion.Numero</name>
			///   <create>02-Junio-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene/Asigna el número de expediente a filtrar</summary>
			public String Numero
			{
				get { return _Numero; }
				set { _Numero = value; }
			}

			///<remarks>
			///   <name>ENTSeguimientoRecomendacion.Quejoso</name>
			///   <create>02-Junio-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene/Asigna el nombre del quejoso que levanta la denuncia</summary>
			public String Quejoso
			{
				get { return _Quejoso; }
				set { _Quejoso = value; }
			}

        #endregion

        #region Funciones

			public ENTSeguimientoRecomendacion(){
				_RecomendacionId = 0;
				_FuncionarioId = 0;
				_EsVigente = 0;
				_Fecha = DateTime.Now;
				_ResultData = new DataSet();

				// Atributos para consulta de expedientes
				_ExpedienteId = 0;
				_UsuarioId = 0;
				_Aprobar = 0;
				_Numero = "";
				_Quejoso = "";
				_MedioComunicacionId = 0;
			}

        #endregion

    }
}
