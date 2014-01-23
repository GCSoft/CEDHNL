/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre: wucCalendar
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Descripción:
'           Calendario usado en la aplicación
'
' Notas:
'				Implementa el control calendar del AJAXControlToolKit
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SIAQ.Web.Include.WebUserControls
{
	public partial class wucCalendar : System.Web.UI.UserControl
	{

		// Enumeraciones
		private enum DateTypes { BeginDate, EndDate }


		///<remarks>
		///   <name>wucCalendar.BeginDate</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene la fecha seleccionada en formato universal agregando hora, minuto y segundo al iniciar el día</summary>
		public String BeginDate
		{
			get { return GetDate(DateTypes.BeginDate);  }
		}

		///<remarks>
		///   <name>wucCalendar.DisplayDate</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene la fecha desplegada en el control</summary>
		public String DisplayDate
		{
			get { return this.txtCanvas.Text; }
		}

		///<remarks>
		///   <name>wucCalendar.EndDate</name>
		///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Obtiene la fecha seleccionada en formato universal agregando hora, minuto y segundo al finalizar el día</summary>
		public String EndDate
		{
			get { return GetDate(DateTypes.EndDate); }
		}
		
		
		// Funciones del programador

		private String GetDate(DateTypes DateType){
			String sReturnDate = "";
			
			try
			{
				
				// Fecha en formato universal
				sReturnDate = this.txtCanvas.Text.Split(new Char[] { '/' })[2] + "-" + this.txtCanvas.Text.Split(new Char[] { '/' })[1] + "-" + this.txtCanvas.Text.Split(new Char[] { '/' })[0];
				
				// Hora, minuto y segundo
				switch(DateType){
					case DateTypes.BeginDate:
						sReturnDate = sReturnDate + " " + "00:00";
						break;
						
					case DateTypes.EndDate:
						sReturnDate = sReturnDate + " " + "23:59";
						break;
				}
			
			}catch(Exception ex){
				throw(ex);
			}

         return sReturnDate;
		}

		
		// Eventos del control
		
		protected void Page_Load(object sender, EventArgs e){
		
			// Mantener estado
			if (this.txtCanvas.Text != ""){ this.ceManager.SelectedDate = DateTime.Parse(this.txtCanvas.Text); }

			// Validación. Solo la primera vez que se ejecuta la página
			if (this.IsPostBack) { return; }
			
			// Atributos
			this.txtCanvas.Attributes.Add("onkeydown", "return false;");
			
			// Fecha actual
			this.ceManager.SelectedDate = DateTime.Now;
			
		}
		
	}
}
