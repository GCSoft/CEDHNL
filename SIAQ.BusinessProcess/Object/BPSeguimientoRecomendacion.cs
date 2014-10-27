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

		
			// ESTE SE VA JUNTO CON LA ENTIDAD
		

			///<remarks>
			///   <name>BPSeguimientoRecomendacion.InsertSegSeguimiento</name>
			///   <create>05-Jun-2014</create>
			///   <author>Ruben.Cobos</author>
			///</remarks>
			///<summary>Inserta un comentario en el seguimiento</summary>
			public void InsertRecomendacionGestion(){
				string ConnectionString = String.Empty;
				DASeguimientoRecomendacion DASeguimientoRecomendacion = new DASeguimientoRecomendacion();

				ConnectionString = sConnectionApplication;

				_SeguimientoRecomendacionEntity.ResultData = DASeguimientoRecomendacion.InsertRecomendacionGestion(_SeguimientoRecomendacionEntity, ConnectionString);
				_ErrorId = DASeguimientoRecomendacion.ErrorId;
				_ErrorString = DASeguimientoRecomendacion.ErrorDescription;

			}

			
			

        #endregion

    }
}
