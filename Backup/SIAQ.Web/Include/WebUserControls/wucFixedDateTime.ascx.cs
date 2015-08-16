/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre: wucFixedDateTime
' Autor: Ruben.Cobos
' Fecha: 09-Marzo-2014
'
' Descripción:
'           Muestra la fecha y hora del servidor, utilizado para notificación de Fechas y Hora en la que se guardará una transacción.
'
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCUtility.Function;

namespace SIAQ.Web.Include.WebUserControls
{
   public partial class wucFixedDateTime : System.Web.UI.UserControl
   {

      // Utilerias
	   GCJavascript gcJavascript = new GCJavascript();


      // Propiedades

      ///<remarks>
      ///   <name>wucFixedDateTime.GetDateTime</name>
      ///   <create>09-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene la fecha y hora establecida en el control en formato universal</summary>
      public String GetDateTime
      {
         get { return this.hddUniversalDateTime.Value; }
      }


      // Métodos públicos

      ///<remarks>
      ///   <name>wucFixedDateTime.SetDateTime</name>
      ///   <create>09-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Establece la fecha y hora del servidor en el control</summary>
      public void SetDateTime(){
         String sCurrentDay = "";
         String sCurrentMonth = "";
         String sCurrentYear = "";

         String sCurrenTime = "";

         try
         {

            // Día actual
            sCurrentDay = "0" + DateTime.Now.Day.ToString();
            if (sCurrentDay.Length > 2) { sCurrentDay = sCurrentDay.Substring(1, 2); }

            // Mes actual
            sCurrentMonth = "0" + DateTime.Now.Month.ToString();
            if (sCurrentMonth.Length > 2) { sCurrentMonth = sCurrentMonth.Substring(1, 2); }

            // Año actual
            sCurrentYear = DateTime.Now.Year.ToString();

            // Hora actual
            sCurrenTime = DateTime.Now.TimeOfDay.ToString().Split(new Char[] { ':' })[0] + ":" + DateTime.Now.TimeOfDay.ToString().Split(new Char[] { ':' })[1];

            // Fecha y Hora universal (para la transacción)
            this.hddUniversalDateTime.Value = sCurrentYear + "-" + sCurrentMonth + "-" + sCurrentDay + " " + sCurrenTime;

            // Fecha y hora a desplegar
            this.lblCanvas.Text = sCurrentDay + "/" + GetMonthName(sCurrentMonth) + "/" + sCurrentYear + " " + GetCustomeTime(sCurrenTime);

         }catch(Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
         }
      }


      // Rutinas del programador

      String GetCustomeTime(String sUniversalTime){
         String sCustomeTime = "";

         try
         {

            // Determinar el momento del día
            if (Int16.Parse(sUniversalTime.Split(new Char[] { ':' })[0]) < 13){
               sCustomeTime = sUniversalTime + " a.m.";
            }else{
               sCustomeTime = (Int16.Parse(sUniversalTime.Split(new Char[] { ':' })[0]) - 12).ToString() + ":" + sUniversalTime.Split(new Char[] { ':' })[1] + " p.m.";
            }

         }catch (Exception ex){
            throw (ex);
         }

         // Nombre del Mes
         return sCustomeTime;
      }
      
      String GetMonthName(String sMonthNumber){
         String sMonthName = "";

         try
         {

            switch(sMonthNumber){
               case "01":
                  sMonthName = "Ene";
                  break;
               case "02":
                  sMonthName = "Feb";
                  break;
               case "03":
                  sMonthName = "Mar";
                  break;
               case "04":
                  sMonthName = "Abr";
                  break;
               case "05":
                  sMonthName = "May";
                  break;
               case "06":
                  sMonthName = "Jun";
                  break;
               case "07":
                  sMonthName = "Jul";
                  break;
               case "08":
                  sMonthName = "Ago";
                  break;
               case "09":
                  sMonthName = "Sep";
                  break;
               case "10":
                  sMonthName = "Oct";
                  break;
               case "11":
                  sMonthName = "Nov";
                  break;
               case "12":
                  sMonthName = "Dic";
                  break;
               default:
                  throw( new Exception ("Número de mes inválido"));
            }

         }catch (Exception ex){
            throw (ex);
         }

         // Nombre del Mes
         return sMonthName;
      }


      // Eventos del control

      protected void Page_Load(object sender, EventArgs e){
         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) { return; }

         // Actualizar fecha y hora en el control
         SetDateTime();
      }

   }
}