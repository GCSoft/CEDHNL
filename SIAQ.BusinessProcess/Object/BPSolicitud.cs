using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPSolicitud : BPBase
	{

		#region "Rutina Original"

			private int _ErrorId;
			private string _ErrorDescription;
			protected ENTSolicitud _SolicitudEntity;
			protected ENTAutoridad _AutoridadEntity;

			public ENTSolicitud SolicitudEntity
			{
				get { return _SolicitudEntity; }
				set { _SolicitudEntity = value; }
			}

			public ENTAutoridad AutoridadEntity
			{
				get { return _AutoridadEntity; }
				set { _AutoridadEntity = value; }
			}

			public BPSolicitud()
			{
				_SolicitudEntity = new ENTSolicitud();
				_AutoridadEntity = new ENTAutoridad();
			}

			/// <summary>
			///     Número de error ocurrido. Cero por default
			/// </summary>
			public int ErrorId
			{
				get { return _ErrorId; }
				set { _ErrorId = value; }
			}

			/// <summary>
			///     Descripción del error ocurrido
			/// </summary>
			public string ErrorDescription
			{
				get { return _ErrorDescription; }
			}

			public void GuardarCalificacionSol()
			{

				DASolicitud SolicitudAccess = new DASolicitud();

				SolicitudAccess.GuardarCalificacionSol(_SolicitudEntity, sConnectionApplication);

				_ErrorId = SolicitudAccess.ErrorId;
				_ErrorDescription = SolicitudAccess.ErrorDescription;
			}


			/// <summary>
			///     Busca las autoridades que están señaladas en una solicitud.
			/// </summary>
			public void SelectSolicitudAutoridad()
			{
				string ConnectionString = string.Empty;
				DASolicitud DASolicitud = new DASolicitud();

				ConnectionString = sConnectionApplication;

				_SolicitudEntity.ResultData = DASolicitud.SelectSolicitudAutoridad(_SolicitudEntity, ConnectionString);

				_ErrorId = DASolicitud.ErrorId;
				_ErrorDescription = DASolicitud.ErrorDescription;
			}

			/// <summary>
			/// Muestra las voces señaladas de una autoridad de una solicitud
			/// </summary>
			public void SelectSolicitudAutoridadVoces()
			{
				string sConnectionString = String.Empty;
				DASolicitud oDASolicitud = new DASolicitud();

				sConnectionString = sConnectionApplication;
				_AutoridadEntity.dsResponse = oDASolicitud.SelectSolicitudAutoridadVoces(_AutoridadEntity, sConnectionString);

				_ErrorId = oDASolicitud.ErrorId;
				_ErrorDescription = oDASolicitud.ErrorDescription;
			}

			/// <summary>
			/// Valida la solicitud antes de enviarla, que haya ciudadanos agregados, que se haya calificado, que haya autoridades agregadas y que se hayan agregado voces señaladas a dichas autoridades
			/// </summary>
			public void ValidarEnviarSolicitud()
			{
				string sConnectionString = String.Empty;
				DASolicitud oDASolicitud = new DASolicitud();

				sConnectionString = sConnectionApplication;

				_SolicitudEntity.ResultData = oDASolicitud.ValidarEnviarSolicitud(_SolicitudEntity, sConnectionString);

				_ErrorId = oDASolicitud.ErrorId;
				_ErrorDescription = oDASolicitud.ErrorDescription;
			}

			/// <summary>
			///     Busca los comentarios realizados para una solicitud.
			/// </summary>
			public void SelectRptQuejas(ref DataSet ds, ENTSolicitud ent)
			{
				ENTResponse oENTResponse = new ENTResponse();
				string ConnectionString = string.Empty;
				DASolicitud DASolicitud = new DASolicitud();

				ConnectionString = sConnectionApplication;

				_SolicitudEntity.ResultData = DASolicitud.SelectRptQuejas(ent, ConnectionString);

				_ErrorId = DASolicitud.ErrorId;
				_ErrorDescription = DASolicitud.ErrorDescription;

				oENTResponse.dsResponse = _SolicitudEntity.ResultData;
				ds = oENTResponse.dsResponse;

			}

		#endregion


		///<remarks>
		///   <name>BPSolicitud.InsertSolicitud</name>
		///   <create>06-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una nueva Solicitud</summary>
		///<param name="oENTSolicitud">Entidad de Solicitud con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertSolicitud(ENTSolicitud oENTSolicitud){
			DASolicitud oDASolicitud = new DASolicitud();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDASolicitud.InsertSolicitud(oENTSolicitud, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}


	}
}
