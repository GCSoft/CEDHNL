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
			///   <name>BPSeguimientoRecomendacion.SelectRecomendacionesSeguimientos</name>
			///   <create>30-May-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Obtiene un listado de Expedientes en fase de seguimientos con base a los parámetros proporcionados integrando la seguridad del usuario</summary>
			///<param name="entRecomendacion">Entidad de Seguimiento con los parámetros necesarios para consultar la información</param>
			///<returns>Una entidad de respuesta</returns>
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
			///<param name="entRecomendacion">Entidad de Seguimiento con los parámetros necesarios para consultar la información</param>
			///<returns>Una entidad de respuesta</returns>
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
