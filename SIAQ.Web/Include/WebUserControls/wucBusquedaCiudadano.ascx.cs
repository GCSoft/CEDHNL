/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	wucBusquedaCiudadano
' Autor:		Daniel.Chavez
' Fecha:		07-Marzo-2014
'
' Descripción:
'           Web User Control que ayuda a filtrar una ciudadano en particular
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
using GCSoft.Utilities.Common;
using System.Data;

namespace SIAQ.Web.Include.WebUserControls
{
   public partial class wucBusquedaCiudadano : System.Web.UI.UserControl
   {

      // Utilerías
      Function utilFunction = new Function();
      
      // Propiedades

      ///<remarks>
      ///   <name>wucBusquedaCiudadano.CanvasID</name>
      ///   <create>09-Marzo-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Obtiene el id del Canvas del control</summary>
      public String CanvasID
      {
         get { return this.txtCiudadano.ClientID; }
      }

      public Int32 CiudadanoID
      {
         get { return SelfInt32Parse(this.hddCiudadanoID.Value); }
         set { this.hddCiudadanoID.Value = value.ToString(); }
      }

      public String Text
      {
         get { return this.txtCiudadano.Text; }
         set { this.txtCiudadano.Text = value; }
      }

      public String NombreCiud
      {
         get { return this.hddNombre.Value; }
         set { this.hddNombre.Value = value; }
      }

      
      // Handlers

      public delegate void WUCSelectorCommandEventHandler();
      public event WUCSelectorCommandEventHandler ItemSelected;

      
      // Funciones del programador

      private Int32 SelfInt32Parse(String sItem)
      {
         Int32 iResponse;

         try
         {

               iResponse = Int32.Parse(sItem);

         }
         catch (Exception)
         {
               iResponse = 0;
         }

         return iResponse;
      }


      // Runtinas del programador

      private void selectCiudadano(){
         BPCiudadano oBPCiudadano = new BPCiudadano();
         ENTCiudadano oENTCiudadano = new ENTCiudadano();
         ENTResponse oENTResponse = new ENTResponse();

         // Limpiar mensajes anteriores
         this.lblMessage.Text = "";

         try
         {

            // Formulario
            oENTCiudadano.Nombre = this.txtNombre.Text.Trim();

            // Transacción
            oENTResponse = oBPCiudadano.searchCiudadano(oENTCiudadano);

            // Validaciones
            if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

            // Mensaje de la BD
            if (oENTResponse.sMessage != ""){
               this.lblMessage.Text = oENTResponse.sMessage;
               this.gvCiudadano.DataSource = null;
               this.gvCiudadano.DataBind();
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
               return;
            }

            // Llenado de contClientees
            this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[1];
            this.gvCiudadano.DataBind();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      private void ShowFilter(){
         try
         {

            // Mostrar filtro
            this.pnlAction.Visible = true;

            // Estado inicial del grid
            this.gvCiudadano.DataSource = null;
            this.gvCiudadano.DataBind();

            // Foco
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);

         }catch (Exception ex){
            throw (ex);
         }
      }

      
      // Eventos de la pagina
      
      protected void Page_Load(object sender, EventArgs e){

         // Validación. Solo la primera vez que se ejecuta la página
         if (this.IsPostBack) { return; }

         // Lógica de la página
         try {
                
               // Estado inicial
               this.pnlAction.Visible = false;
                
         }
         catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
         }
      }

      protected void btnBuscar_Click(object sender, EventArgs e){
         try
         {

            // Buscar ciudadanos
            selectCiudadano();

         }catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

      protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
         String strCommand = "";
         Int32 intRow = 0;

         try
         {

            // Opción seleccionada
            strCommand = e.CommandName.ToString();

            // Se dispara el evento RowCommand en el ordenamiento
            if (strCommand == "Sort") { return; }

            // Fila
            intRow = Int32.Parse(e.CommandArgument.ToString());

            // Datakeys
            this.hddCiudadanoID.Value = this.gvCiudadano.DataKeys[intRow]["CiudadanoId"].ToString();

            // Mostrar nombre
            this.txtCiudadano.Text = this.gvCiudadano.DataKeys[intRow]["NombreCiudadano"].ToString();
            this.hddNombre.Value = this.gvCiudadano.DataKeys[intRow]["NombreCiudadano"].ToString();

            // limpiar formulario
            this.txtNombre.Text = "";

            // Esconder control
            this.pnlAction.Visible = false;

            // Generar evento
            if (ItemSelected != null) { ItemSelected(); }

         }catch (Exception ex){
            this.lblMessage.Text = ex.Message;
         }
      }

      protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
         ImageButton imgSelectItem = null;

         String CiudadanoId = "";
         String NombreCiudadano = "";
         String sImagesAttributes = "";

         try
         {

            // Validación de que sea fila
            if (e.Row.RowType != DataControlRowType.DataRow) { return; }

            // Obtener imágen
            imgSelectItem = (ImageButton)e.Row.FindControl("imgSelectItem");

            // Datakeys
            CiudadanoId = this.gvCiudadano.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();
            NombreCiudadano = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCiudadano"].ToString();

            // Atributos Over
            sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem.png';";
            e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; " + sImagesAttributes);

            // Atributos Out
            sImagesAttributes = " document.getElementById('" + imgSelectItem.ClientID + "').src='../../../../Include/Image/Buttons/SelectItem_Null.png';";
            e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; " + sImagesAttributes);

         }
         catch (Exception ex){
            throw (ex);
         }
      }

      protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
         DataTable tblCliente = null;
			DataView viewCliente = null;
			
			try{

				// Obtener DataTable y DataView del GridView
            tblCliente = utilFunction.ParseGridViewToDataTable(this.gvCiudadano, true);
				viewCliente = new DataView(tblCliente);

				// Determinar ordenamiento
				this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				// Ordenar vista
				viewCliente.Sort = this.hddSort.Value;

				// Vaciar datos
				this.gvCiudadano.DataSource = viewCliente;
				this.gvCiudadano.DataBind();
				
			}catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
			}
		}
        
      protected void imgBusqueda_Click(object sender, ImageClickEventArgs e){
         try {

            // Mostrar el filtro
            ShowFilter();

         }
         catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

      protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
         try
         {

            // Ocultar filtro
            this.pnlAction.Visible = false;

         }
         catch (Exception ex){
            this.lblMessage.Text = ex.Message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtNombre.ClientID + "');", true);
         }
      }

   }
}