using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPSeguimientoRecomendacion : BPBase
    {

        #region Atributos

			protected ENTSeguimientoRecomendacion _SeguimientoRecomendacionEntity;
			private int _ErrorId;
			private string _ErrorString;

        #endregion

        #region Propiedades

			public ENTSeguimientoRecomendacion SeguimientoRecomendacionEntity
			{
				get { return _SeguimientoRecomendacionEntity; }
				set { _SeguimientoRecomendacionEntity = value; }
			}

			public int ErrorId
			{
				get { return _ErrorId; }
				set { _ErrorId = value; }
			}

			public string ErrorString
			{
				get { return _ErrorString; }
				set { _ErrorString = value; }
			}

        #endregion

        #region Funciones

			public BPSeguimientoRecomendacion(){
				_SeguimientoRecomendacionEntity = new ENTSeguimientoRecomendacion();
			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.ActualizaEstatusExpedienteSeguimiento</name>
			///   <create>06-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Cambia el estatus de un expediente</summary>
			public void ActualizaEstatusExpedienteSeguimiento(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.ActualizaEstatusExpedienteSeguimiento(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.InsertComentarioSeguimiento</name>
			///   <create>05-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Inserta un comentario en el seguimiento</summary>
			public void InsertComentarioSeguimiento(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.InsertComentarioSeguimiento(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.InsertSeguimientoRecomendacion</name>
			///   <create>06-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Inserta un registro de seguimiento asociándolo a un Funcionario y estableciéndolo como el último (cerrando los anteriores). También cambia el estatus del expediente.</summary>
			public void InsertSeguimientoRecomendacion(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.InsertSeguimientoRecomendacion(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.InsertSegSeguimiento</name>
			///   <create>05-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Inserta un comentario en el seguimiento</summary>
			public void InsertSegSeguimiento(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.InsertSegSeguimiento(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos</name>
			///   <create>04-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene la información de un expediente en estatus de Seguimiento</summary>
			public void SelectExpediente_DetalleSeguimientos(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.SelectRecomendacionesSeguimientos</name>
			///   <create>30-May-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene un listado de Expedientes en fase de seguimientos con base a los parámetros proporcionados integrando la seguridad del usuario</summary>
			public void SelectRecomendacionesSeguimientos(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.SelectRecomendacionesSeguimientos(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.SelectRecomendacionesSeguimientos_Filtro</name>
			///   <create>02-Junio-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene un listado de Expedientes en fase de seguimientos con base a los parámetros proporcionados utilizada en el filtro de búsqueda</summary>
			public void SelectRecomendacionesSeguimientos_Filtro(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.SelectRecomendacionesSeguimientos_Filtro(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

        #endregion

    }
}
