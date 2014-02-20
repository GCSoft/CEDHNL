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

namespace SafeTransfere.Web.Include.WebUserControls
{
    public partial class wucTimeMask : System.Web.UI.UserControl
    {

        // Enumeraciones
        private enum TimeTypes { HoraMinuto }

        ///<remarks>
        ///   <name>wucTimeMaskr.GetTime</name>
        ///   <create>18-Diciembre-2013</create>
        ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
        ///</remarks>
        ///<summary>Obtiene la hora capturada en formato HH:mm AM/PM</summary>
        public string Tiempo
        {
            get { return GetTime(TimeTypes.HoraMinuto); }
        }

        // Funciones del programador
        private String GetTime(TimeTypes TimeType)
        {
            String sReturnTime = "";
            try
            {
                sReturnTime = this.txtCanvas.Text;
                //// Fecha en formato universal
                //sReturnDate = this.txtCanvas.Text.Split(new Char[] { '/' })[2] + "-" + this.txtCanvas.Text.Split(new Char[] { '/' })[1] + "-" + this.txtCanvas.Text.Split(new Char[] { '/' })[0];

                //// Hora, minuto y segundo
                //switch (DateType)
                //{
                //    case DateTypes.BeginDate:
                //        sReturnDate = sReturnDate + " " + "00:00";
                //        break;

                //    case DateTypes.EndDate:
                //        sReturnDate = sReturnDate + " " + "23:59";
                //        break;
                //}

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return sReturnTime;

        }

        // Eventos del control
        protected void Page_Load(object sender, EventArgs e)
        {

            //// Mantener estado
            //if (this.txtCanvas.Text != "") { this.ceManager.SelectedDate = DateTime.Parse(this.txtCanvas.Text); }

            // Validación. Solo la primera vez que se ejecuta la página
            if (this.IsPostBack) { return; }

            //// Atributos
            //this.txtCanvas.Attributes.Add("onkeydown", "return false;");

            //// Fecha actual
            //this.ceManager.SelectedDate = DateTime.Now;

        }
    }
}