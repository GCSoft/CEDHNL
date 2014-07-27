using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{

    public class BPCiudadano : BPBase
	{

		#region "Rutina Original"

			private int _ErrorId;
			private string _ErrorDescription;
			private ENTCiudadano _ENTCiudadano;

			public BPCiudadano()
			{

				_ErrorId = 0;
				_ErrorDescription = "";
				_ENTCiudadano = new ENTCiudadano();

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
				set { _ErrorDescription = value; }
			}

			/// <summary>
			///     Entidad de ciudadano
			/// </summary>
			public ENTCiudadano ENTCiudadano
			{
				get { return _ENTCiudadano; }
				set { _ENTCiudadano = value; }
			}

			///<remarks>
			///   <name>BPCiudadano.searchCiudadano</name>
			///   <create>27/ene/2014</create>
			///   <author>Generador</author>
			///</remarks>
			///<summary>Metodo para obtener las Ciudadano del sistema</summary>
			public ENTResponse searchCiudadano(ENTCiudadano entCiudadano)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DACiudadano dataCiudadano = new DACiudadano();
					oENTResponse = dataCiudadano.searchCiudadano(entCiudadano);
					// Validación de error en consulta
					if (oENTResponse.GeneratesException) { return oENTResponse; }
					// Validación de mensajes de la BD
					oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
					if (oENTResponse.sMessage != "") { return oENTResponse; }
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}
				// Resultado
				return oENTResponse;

			}

			public void BuscarCiudadano()
			{
				string ConnectionString = string.Empty;
				DACiudadano DACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = DACiudadano.SelectCiudadano(_ENTCiudadano, ConnectionString);

				_ErrorId = DACiudadano.ErrorId;
				_ErrorDescription = DACiudadano.ErrorDescription;

			}

			public void EliminarCiudadanoSolicitud()
			{
				string ConnectionString = string.Empty;
				DACiudadano DACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				DACiudadano.EliminarCiudadanoSolicitud(_ENTCiudadano, ConnectionString);

				_ErrorId = DACiudadano.ErrorId;
				_ErrorDescription = DACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener las escolaridades del sistema
			/// </summary>
			public void SelectComboEscolaridad()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboEscolaridad(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener los estados civiles del sistema
			/// </summary>
			public void SelectComboEstadoCivil()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboEstadoCivil(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener los sexos del sistema
			/// </summary>
			public void SelectComboSexo()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboSexo(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener las ocupaciones del sistema
			/// </summary>
			public void SelectComboOcupacion()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboOcupacion(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener las formas de contacto del sistema
			/// </summary>
			public void SelectComboFormaContacto()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboFormaContacto(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener las colonias del sistema
			/// </summary>
			public void SelectComboColonia()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboColonia(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener los estados del sistema
			/// </summary>
			public void SelectComboEstado()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboEstado(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Metodo para obtener las ciudades del sistema
			/// </summary>
			public void SelectComboCiudad()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectComboCiudad(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Selecciona los detalles del ciudadano en específico del sistema para el llenado de controles
			/// </summary>
			public void SelectDetalleCiudadano()
			{
				string ConnectionString = string.Empty;
				DACiudadano oDACiudadano = new DACiudadano();

				ConnectionString = sConnectionApplication;
				_ENTCiudadano.ResultData = oDACiudadano.SelectDetalleCiudadano(_ENTCiudadano, ConnectionString);

				_ErrorId = oDACiudadano.ErrorId;
				_ErrorDescription = oDACiudadano.ErrorDescription;
			}

			/// <summary>
			/// Inserta ciudadanos en el sistema
			/// </summary>
			public ENTResponse InsertCiudadano(ENTCiudadano oENTCiudadano)
			{
				DACiudadano oDACiudadano = new DACiudadano();
				ENTResponse oENTResponse = new ENTResponse();

				try
				{
					oENTResponse = oDACiudadano.InsertCiudadano(oENTCiudadano, sConnectionApplication, 0);
					if (oENTResponse.GeneratesException) { return oENTResponse; }
					oENTResponse.sMessage = String.Empty;
					oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
					if (oENTResponse.sMessage != "") { return oENTResponse; }
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}

				return oENTResponse;
			}

			/// <summary>
			/// Modifica ciudadanos en el sistema
			/// </summary>
			public ENTResponse UpdateCiudadano(ENTCiudadano oENTCiudadano)
			{
				DACiudadano oDACiudadano = new DACiudadano();
				ENTResponse oENTResponse = new ENTResponse();

				try
				{
					oENTResponse = oDACiudadano.UpdateCiudadano(oENTCiudadano, sConnectionApplication, 0);
					if (oENTResponse.GeneratesException) { return oENTResponse; }
					oENTResponse.sMessage = String.Empty;
					oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
					if (oENTResponse.sMessage != "") { return oENTResponse; }
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}

				return oENTResponse;
			}


			/// <summary>
			/// Metodo para obtener las nacionalidades del sistema
			/// </summary>
			public ENTResponse SelectComboNacionalidad(ENTCiudadano oENTCiudadano)
			{
				DACiudadano oDACiudadano = new DACiudadano();
				ENTResponse oENTResponse = new ENTResponse();

				try
				{
					oENTResponse = oDACiudadano.SelectComboNacionalidad(oENTCiudadano, sConnectionApplication, 0);
					if (oENTResponse.GeneratesException) { return oENTResponse; }
					oENTResponse.sMessage = String.Empty;
					oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
					if (oENTResponse.sMessage != "") { return oENTResponse; }
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}

				return oENTResponse;
			}

			/// <summary>
			/// Metodo para obtener los países del sistema
			/// </summary>
			public ENTResponse SelectComboPais(ENTCiudadano oENTCiudadano)
			{
				DACiudadano oDACiudadano = new DACiudadano();
				ENTResponse oENTResponse = new ENTResponse();

				try
				{
					oENTResponse = oDACiudadano.SelectComboPais(oENTCiudadano, sConnectionApplication, 0);
					if (oENTResponse.GeneratesException) { return oENTResponse; }
					oENTResponse.sMessage = String.Empty;
					oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
					if (oENTResponse.sMessage != "") { return oENTResponse; }
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}

				return oENTResponse;
			}

			///<remarks>
			///   <name>BPCiudadano.searchCiudadanoAtencionSel</name>
			///   <create>11/jun/2014</create>
			///   <author>JJ</author>
			///</remarks>
			///<summary>Metodo para obtener las Ciudadanos que esten en una atención</summary>
			public ENTResponse searchCiudadanoAtencion(ENTCiudadano entCiudadano)
			{

				ENTResponse oENTResponse = new ENTResponse();
				try
				{
					// Consulta a base de datos
					DACiudadano dataCiudadano = new DACiudadano();
					oENTResponse = dataCiudadano.searchCiudadanoAtencion(entCiudadano);
					// Validación de error en consulta
					if (oENTResponse.GeneratesException) { return oENTResponse; }
					// Validación de mensajes de la BD
					oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
					if (oENTResponse.sMessage != "") { return oENTResponse; }
				}
				catch (Exception ex)
				{
					oENTResponse.ExceptionRaised(ex.Message);
				}
				// Resultado
				return oENTResponse;

			}

		#endregion

		///<remarks>
		///   <name>BPCiudadano.SelectCiudadano_ByID</name>
		///   <create>06-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Consulta un ciudadano por su ID único</summary>
		///<param name="oENTCiudadano">Entidad de Ciudadano con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse SelectCiudadano_ByID(ENTCiudadano oENTCiudadano){
			DACiudadano oDACiudadano = new DACiudadano();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDACiudadano.SelectCiudadano_ByID(oENTCiudadano, this.sConnectionApplication, 0);

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
