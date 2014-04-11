using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Include.WebUserControls
{
    public partial class wucCalendario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Mantener estado
            if (this.txtCalendario.Text != "") { this.CalendarExtender1.SelectedDate = DateTime.Parse(this.txtCalendario.Text); }

            if (Page.IsPostBack) { return; }
        }

        #region Atributos

        #endregion

        #region Propiedades

        public string GetDate
        {
            get { return txtCalendario.Text; }
        }

        public void SetCurrentDate()
        {
            CalendarExtender1.SelectedDate = DateTime.Now;
        }

        public string SetDate
        {
            set { CalendarExtender1.SelectedDate = Convert.ToDateTime(value); }
        }

        #endregion

    }
}