using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
    public class BPVisita : BPBase
	{

		#region "Rutina Original"

			private int _ErrorId;                           // Número de error ocurrido
			private string _ErrorDescription;               // Descripción del error ocurrido
			protected ENTVisita _VisitaEntity;

			public ENTVisita ENTVisita
			{
				get { return _VisitaEntity; }
				set { _VisitaEntity = value; }
			}

			public BPVisita()
			{

				_ErrorId = 0;
				_ErrorDescription = string.Empty;
				_VisitaEntity = new ENTVisita();
			}

			public int ErrorId
			{
				get { return _ErrorId; }
				set { _ErrorId = value; }
			}

			public string ErrorDescription
			{
				get { return _ErrorDescription; }
				set { _ErrorDescription = value; }
			}

			public void SelectVisitaCiudadano()
			{
				DAVisita oDAVisita = new DAVisita();
				string sConnectionString = string.Empty;

				sConnectionString = sConnectionApplication;

				_VisitaEntity.dsResponse = oDAVisita.SelectVisitaCiudadano(_VisitaEntity, sConnectionString);
				_ErrorId = oDAVisita.ErrorId;
				_ErrorDescription = oDAVisita.ErrorDescription;
			}
			
		#endregion

		///<remarks>
		///   <name>BPVisita.InsertVisita</name>
		///   <create>06-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Inserta una nueva visita</summary>
		///<param name="oENTVisita">Entidad de Visita con los parámetros necesarios para realizar la transacción</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertVisita(ENTVisita oENTVisita){
			DAVisita oDAVisita = new DAVisita();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción en base de datos
				oENTResponse = oDAVisita.InsertVisita(oENTVisita, this.sConnectionApplication, 0);

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
