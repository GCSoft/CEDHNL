/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucASCiudadano
' Autor:	Ruben.Cobos
' Fecha:	25-Marzo-2014
'
' Descripción:
'           WUC que filtra ciudadanos mediante un Autosuggest
'
' Errores conocidos:
'           El control no puede tomar el foco con el evento JavaScripy Focus()
'           El control no funciona desde un WUC, se conserva para aislar la funcionalidad
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using GCUtility.Function;
using System.Data;

namespace SIAQ.Web.Include.WebUserControls
{
	public partial class wucASCiudadano : System.Web.UI.UserControl
	{


		// Servicio

		[System.Web.Script.Services.ScriptMethod()]
		[System.Web.Services.WebMethod]
		public static List<string> GetCitizenList(string prefixText, int count){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();
			ENTResponse oENTResponse = new ENTResponse();

			List<String> ServiceResponse = new List<String>();
			String Item;

			try
			{

				// Formulario
				oENTCiudadano.Nombre = prefixText;

				// Transacción
				oENTResponse = oBPCiudadano.searchCiudadano(oENTCiudadano);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Configuración de arreglo de respuesta
				foreach (DataRow rowCiudadano in oENTResponse.dsResponse.Tables[1].Rows){
					Item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(rowCiudadano["NombreCiudadano"].ToString(), rowCiudadano["CiudadanoId"].ToString());
					ServiceResponse.Add(Item);
				}

			}catch (Exception){
				// Do Nothing
			}

			//Return Selected Products
			return ServiceResponse;
		}


		// Propiedades

		///<remarks>
		///   <name>wucASCiudadano.CiudadanoId</name>
		///   <create>25-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el identificador del Ciudadano seleccionado</summary>
		public Int32 CiudadanoId
		{
			get { return SelfInt32Parse(this.Request.Form[this.hddCiudadanoId.UniqueID]); }
			set { this.hddCiudadanoId.Value = value.ToString(); }
		}

		///<remarks>
		///   <name>wucASCiudadano.Nombre</name>
		///   <create>25-Julio-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Obtiene/Asigna el nombre del Ciudadano seleccionado</summary>
		public String Nombre
		{
			get { return this.Request.Form[this.txtCiudadano.UniqueID]; }
			set { this.txtCiudadano.Text = value; }
		}


		// Funciones del programador

		private Int32 SelfInt32Parse(String sItem){
			Int32 iResponse;

			try
			{

				iResponse = Int32.Parse(sItem);

			}catch (Exception){
				iResponse = 0;
			}

			return iResponse;
		}


		// Eventos de la pagina

		protected void Page_Load(object sender, EventArgs e){

		}
	
	}
}