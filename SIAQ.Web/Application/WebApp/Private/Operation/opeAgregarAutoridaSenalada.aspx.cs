/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	opeAgregarAutoridaSenalada
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Modificación:
'           Se reconstruyó la pantalla reutilizando los métodos existentes
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GCSoft.Utilities.Common;
using System.Data;
using System.Text.RegularExpressions;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
   public partial class opeAgregarAutoridaSenalada : System.Web.UI.Page
   {

      // Utilerías
      Function utilFunction = new Function();
      Encryption utilEncryption = new Encryption();

      
      // Rutinas del programador

      private void ComboAutoridadPrimerNivel(){
         BPAutoridad oBPAutoridad = new BPAutoridad();

         oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = 0;
         oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
         oBPAutoridad.SelectNivelesAutoridad();

         if (oBPAutoridad.ErrorId == 0){
            if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
               ddlPrimerNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0];
               ddlPrimerNivel.DataTextField = "Nombre";
               ddlPrimerNivel.DataValueField = "AutoridadId";
               ddlPrimerNivel.DataBind();
            }
         }
      }

      private void ComboAutoridadSegundoNivel(){
         BPAutoridad oBPAutoridad = new BPAutoridad();

         oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlPrimerNivel.SelectedValue);
         oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
         oBPAutoridad.SelectNivelesAutoridad();

         if (oBPAutoridad.ErrorId == 0){
            if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
               ddlSegundoNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[1];
               ddlSegundoNivel.DataTextField = "Nombre";
               ddlSegundoNivel.DataValueField = "AutoridadId";
               ddlSegundoNivel.DataBind();
            }
         }
      }

      private void ComboAutoridadTercerNivel(){
         BPAutoridad oBPAutoridad = new BPAutoridad();

         oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlPrimerNivel.SelectedValue);
         oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = Convert.ToInt32(ddlSegundoNivel.SelectedValue);
         oBPAutoridad.SelectNivelesAutoridad();

         if (oBPAutoridad.ErrorId == 0){
            if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
               ddlTercerNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[2];
               ddlTercerNivel.DataTextField = "Nombre";
               ddlTercerNivel.DataValueField = "AutoridadId";
               ddlTercerNivel.DataBind();
            }
         }
      }

      private void LlenarGridAutoridades(int SolicitudId){
         BPSolicitud oBPSolicitud = new BPSolicitud();

         oBPSolicitud.SolicitudEntity.SolicitudId = SolicitudId;
         oBPSolicitud.SelectSolicitudAutoridad();

         // Validaciones
         if (oBPSolicitud.ErrorId != 0){
            gvAutoridades.DataSource = null;
            gvAutoridades.DataBind();
            return;
         }

         // Listado de autoridades
         if (oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
         {

            gvAutoridades.DataSource = oBPSolicitud.SolicitudEntity.ResultData;
            gvAutoridades.DataBind();
         }else{

            gvAutoridades.DataSource = null;
            gvAutoridades.DataBind();
         }

         // Número de solicitud
         SolicitudLabel.Text = oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Numero"].ToString();

      }


      
      // Eventos de la página

      protected void Page_Load(object sender, EventArgs e){

         if (Page.IsPostBack) { return; }

         // Lógica de la página
         String sKey = "";

         try
         {

            // Validación
            if (this.Request.QueryString["s"] == null){
               sKey = utilEncryption.EncryptString("[V02] No tiene permisos para acceder a esta página", true);
               this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sKey, true);
            }

            // Obtener SolicitudId
            SolicitudIdHidden.Value = Request.QueryString["s"].ToString();

            // Llenado de controles
            ComboAutoridadPrimerNivel();
            ComboAutoridadSegundoNivel();
            ComboAutoridadTercerNivel();

            LlenarGridAutoridades(Convert.ToInt32(SolicitudIdHidden.Value));

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
         }
      }

      protected void AgregarAutoridadButton_Click(object sender, EventArgs e){
         //Abrir popup
         ddlPrimerNivel.Enabled = true;
         ddlSegundoNivel.Enabled = true;
         ddlTercerNivel.Enabled = true;
         hdnAutoridadId.Value = String.Empty;
         btnAgregar.Text = "Agregar autoridad";
         pnlAction.Visible = true;
      }
        

        

        #region Eventos

       

        #region "Combobox"

        protected void ddlPrimerNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboAutoridadSegundoNivel();
            ComboAutoridadTercerNivel();
        }

        protected void ddlSegundoNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboAutoridadTercerNivel();
        }


        protected void ddlVocesNivel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboVocesTercerNivel();
        }

        protected void ddlVocesNivel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboVocesSegundoNivel();
            ComboVocesTercerNivel();
        }

        #endregion

        #region "Botones"

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            string solicitudId = SolicitudIdHidden.Value;
            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + solicitudId);
        }

        protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e)
        {
            LimpiarPopUp();
            pnlAction.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string AutoridadId = hdnAutoridadId.Value;
            string SolicitudId = SolicitudIdHidden.Value;

            try
            {
                if (String.IsNullOrEmpty(AutoridadId))
                {
                    // Agregar autoridad
                    AgregarAutoridad(Convert.ToInt32(SolicitudId));
                    LimpiarPopUp();
                    pnlAction.Visible = false;
                    LlenarGridAutoridades(Convert.ToInt32(SolicitudId));
                    LimpiarLabelsDetalle();
                }
                else
                {
                    //Modifiar autoridad
                    ModificarAutoridad(Convert.ToInt32(SolicitudId));
                    LimpiarPopUp();
                    pnlAction.Visible = false;
                    LlenarGridAutoridades(Convert.ToInt32(SolicitudId));
                    LimpiarLabelsDetalle();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        protected void btnRegresarPop_Click(object sender, EventArgs e)
        {
            LimpiarPopUp();
            pnlAction.Visible = false;
        }

        protected void btnRegresarPopVoz_Click(object sender, EventArgs e)
        {
            ComboVocesPrimerNivel();
            ddlVocesNivel1.SelectedIndex = 0;
            ComboVocesSegundoNivel();
            ComboVocesTercerNivel();

            pnlVocesPop.Visible = false;
        }

        protected void btnAgregarVoz_Click(object sender, EventArgs e)
        {
            string SolicitudId = SolicitudIdHidden.Value;
            string AutoridadId = hdnAutoridadId.Value;

            try
            {
                AgregarVoz(Convert.ToInt32(SolicitudId), Convert.ToInt32(AutoridadId), Convert.ToInt32(ddlVocesNivel3.SelectedValue));
                ddlVocesNivel1.SelectedIndex = 0;
                ComboVocesSegundoNivel();
                ComboVocesTercerNivel();
                pnlVocesPop.Visible = false;
                LlenarGridVoces(Convert.ToInt32(SolicitudId), Convert.ToInt32(AutoridadId));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
                    , true);
            }
        }

        #endregion

        #region "GridView"

        protected void gvAutoridades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string AutoridadId = String.Empty;

            AutoridadId = e.CommandArgument.ToString();


            switch (e.CommandName.ToString())
            {
                case "Seleccionar":
                    //Detalle y mostrar voces
                    MostrarDetalleAutoridad(Convert.ToInt32(SolicitudIdHidden.Value), Convert.ToInt32(AutoridadId));
                    LlenarGridVoces(Convert.ToInt32(SolicitudIdHidden.Value), Convert.ToInt32(AutoridadId));
                    DetallePanel.Visible = true;
                    VocesPanel.Visible = true;
                    break;
                case "Editar":
                    MostrarDetalleAutoridadPopUp(Convert.ToInt32(SolicitudIdHidden.Value), Convert.ToInt32(AutoridadId));
                    btnAgregar.Text = "Modificar autoridad";
                    pnlAction.Visible = true;

                    break;

                case "Borrar":
                    BorrarAutoridad(Convert.ToInt32(AutoridadId), Convert.ToInt32(SolicitudIdHidden.Value));
                    LlenarGridAutoridades(Convert.ToInt32(SolicitudIdHidden.Value));
                    LimpiarLabelsDetalle();
                    break;
            }
        }

        protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            ImageButton imgBorrar = null;
            ImageButton imgSeleccionar = null;
            String sNumeroExpediente = "";
            String sImagesAttributes = "";
            String sImagesAttributesSeleccionar = "";
            String sImagesAttributesBorrar = "";
            String sToolTip = "";
            String sToolTipBorrar = "";
            String sToolTipSeleccionar = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }

                //Decodificar HTML
                string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[6].Text);
                decodedText = Regex.Replace(decodedText, "<[^>]*>", string.Empty);
                e.Row.Cells[6].Text = decodedText;

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("EditButton");
                imgBorrar = (ImageButton)e.Row.FindControl("DeleteButton");
                imgSeleccionar = (ImageButton)e.Row.FindControl("SelectButton");

                //DataKeys
                sNumeroExpediente = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();

                //Tooltip Edición
                sToolTip = "Editar autoridad [" + sNumeroExpediente + "]";
                sToolTipBorrar = "Borrar autoridad con sus voces";
                sToolTipSeleccionar = "Agregar voces";

                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                imgBorrar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipBorrar + "', 'Izq');");
                imgBorrar.Attributes.Add("onmouseout", "tooltip.hide();");
                imgBorrar.Attributes.Add("style", "cursor:hand;");

                imgSeleccionar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipSeleccionar + "', 'Izq');");
                imgSeleccionar.Attributes.Add("onmouseout", "tooltip.hide();");
                imgSeleccionar.Attributes.Add("style", "cursor:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
                sImagesAttributesBorrar = "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
                sImagesAttributesSeleccionar = "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes + sImagesAttributesBorrar + sImagesAttributesSeleccionar);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
                sImagesAttributesBorrar = "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
                sImagesAttributesSeleccionar = "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes + sImagesAttributesBorrar
                    + sImagesAttributesSeleccionar);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvAutoridades_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableAutoridad = null;
            DataView ViewAutoridad = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableAutoridad = utilFunction.ParseGridViewToDataTable(gvAutoridades, false);
                ViewAutoridad = new DataView(TableAutoridad);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewAutoridad.Sort = hddSort.Value;

                //Vaciar datos
                gvAutoridades.DataSource = ViewAutoridad;
                gvAutoridades.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvVoces_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string VozId = String.Empty;

            VozId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Borrar":
                    BorrarVoz(Convert.ToInt32(SolicitudIdHidden.Value), Convert.ToInt32(hdnAutoridadId.Value), Convert.ToInt32(VozId));
                    LlenarGridVoces(Convert.ToInt32(SolicitudIdHidden.Value), Convert.ToInt32(hdnAutoridadId.Value));
                    break;
            }
        }

        protected void gvVoces_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgBorrar = null;
            String sNumeroVoz = "";
            String sImagesAttributesBorrar = "";
            String sToolTipBorrar = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }

                //Obtener imagenes
                imgBorrar = (ImageButton)e.Row.FindControl("DeleteButton");

                //DataKeys
                sNumeroVoz = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();

                //Tooltip Edición
                sToolTipBorrar = "Borrar voz señalada [" + sNumeroVoz + "]";

                imgBorrar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipBorrar + "', 'Izq');");
                imgBorrar.Attributes.Add("onmouseout", "tooltip.hide();");
                imgBorrar.Attributes.Add("style", "cursor:hand;");

                //Atributos Over
                sImagesAttributesBorrar = "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributesBorrar);

                //Atributos Out
                sImagesAttributesBorrar = "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributesBorrar);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvVoces_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableVoz = null;
            DataView VistaVoz = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableVoz = utilFunction.ParseGridViewToDataTable(gvVoces, false);
                VistaVoz = new DataView(TableVoz);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                VistaVoz.Sort = hddSort.Value;

                //Vaciar datos
                gvVoces.DataSource = VistaVoz;
                gvVoces.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }


        #endregion

        #region "LinkButton"

        

        protected void lnkAgregarVoces_Click(object sender, EventArgs e)
        {
            ComboVocesPrimerNivel();
            ComboVocesSegundoNivel();
            ComboVocesTercerNivel();
            pnlVocesPop.Visible = true;
        }

        #endregion

        #endregion

        #region Funciones

       

        #region "Autoridades"

        

      

        private void BorrarAutoridad(int autoridadId, int solicitudId)
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();
            ENTAutoridad oENTAutoridad = new ENTAutoridad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Formulario 
                oENTAutoridad.SolicitudId = solicitudId;
                oENTAutoridad.AutoridadId = autoridadId;

                //Transacción 
                oENTResponse = oBPAutoridad.DeleteSolicitudAutoridad(oENTAutoridad);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                //Actualizar Datos
                //LlenarListaAutoridades();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LimpiarPopUp()
        {
            ComboAutoridadPrimerNivel();
            ddlPrimerNivel.SelectedIndex = 0;
            ComboAutoridadSegundoNivel();
            ComboAutoridadTercerNivel();
            tbNombreFuncionario.Text = String.Empty;
            tbPuestoActual.Text = String.Empty;
            tbComentarios.Text = String.Empty;
        }

        private void LimpiarLabelsDetalle()
        {
            NombreLabel.Text = String.Empty;
            PuestoLabel.Text = String.Empty;
            ObservacionesBox.Text = String.Empty;
            Nivel1Label.Text = String.Empty;
            Nivel2Label.Text = String.Empty;
            Nivel3Label.Text = String.Empty;

            gvVoces.DataSource = null;
            gvVoces.DataBind();

            DetallePanel.Visible = false;
            VocesPanel.Visible = false;
        }

        private void AgregarAutoridad(int solicitudId)
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();
            ENTAutoridad oENTAutoridad = new ENTAutoridad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Formulario 
                oENTAutoridad.SolicitudId = solicitudId;

                if (ddlTercerNivel.SelectedValue == "0") { throw new Exception("Debe elegir una autoridad"); }
                if (String.IsNullOrEmpty(tbNombreFuncionario.Text)) { throw new Exception("El campo [Nombre] es requerido"); }

                oENTAutoridad.Nombre = tbNombreFuncionario.Text;
                oENTAutoridad.Puesto = tbPuestoActual.Text;
                oENTAutoridad.Comentario = tbComentarios.Text;
                oENTAutoridad.AutoridadId = Convert.ToInt32(ddlTercerNivel.SelectedValue);
                hdnAutoridadId.Value = ddlTercerNivel.SelectedValue;

                //Transacción 
                oENTResponse = oBPAutoridad.InsertSolicitudAutoridad(oENTAutoridad);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Autoridad agregada con éxito', 'Success', true);"
                    , true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void MostrarDetalleAutoridadPopUp(int SolicitudId, int AutoridadId)
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.SolicitudId = SolicitudId;
            oBPAutoridad.AutoridadEntity.AutoridadId = AutoridadId;

            oBPAutoridad.SelectDetalleAutoridadesSolicitud();

            if (oBPAutoridad.ErrorId == 0)
            {
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    ddlPrimerNivel.SelectedValue = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId1"].ToString();
                    ComboAutoridadSegundoNivel();
                    ddlSegundoNivel.SelectedValue = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId2"].ToString();
                    ComboAutoridadTercerNivel();
                    ddlTercerNivel.SelectedValue = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId3"].ToString();
                    tbNombreFuncionario.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nombre"].ToString();
                    tbPuestoActual.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Puesto"].ToString();
                    tbComentarios.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Comentarios"].ToString();
                    hdnAutoridadId.Value = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId3"].ToString();

                    ddlPrimerNivel.Enabled = false;
                    ddlSegundoNivel.Enabled = false;
                    ddlTercerNivel.Enabled = false;

                    btnAgregar.Text = "Modificar autoridad";
                    pnlAction.Visible = true;
                }
            }
        }

        private void MostrarDetalleAutoridad(int SolicitudId, int AutoridadId)
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.SolicitudId = SolicitudId;
            oBPAutoridad.AutoridadEntity.AutoridadId = AutoridadId;

            oBPAutoridad.SelectDetalleAutoridadesSolicitud();

            if (oBPAutoridad.ErrorId == 0)
            {
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    Nivel1Label.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nivel1"].ToString();
                    Nivel2Label.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nivel2"].ToString();
                    Nivel3Label.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nivel3"].ToString();
                    NombreLabel.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nombre"].ToString();
                    PuestoLabel.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Puesto"].ToString();
                    ObservacionesBox.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Comentarios"].ToString();
                    hdnAutoridadId.Value = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId3"].ToString();
                }
            }
        }

        private void ModificarAutoridad(int SolicitudId)
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();
            ENTAutoridad oENTAutoridad = new ENTAutoridad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Formulario 
                oENTAutoridad.SolicitudId = SolicitudId;

                if (ddlTercerNivel.SelectedValue == "0") { throw new Exception("Debe elegir una autoridad"); }
                if (String.IsNullOrEmpty(tbNombreFuncionario.Text)) { throw new Exception("El campo [Nombre] es requerido"); }

                oENTAutoridad.Nombre = tbNombreFuncionario.Text;
                oENTAutoridad.Puesto = tbPuestoActual.Text;
                oENTAutoridad.Comentario = tbComentarios.Text;
                oENTAutoridad.AutoridadId = Convert.ToInt32(ddlTercerNivel.SelectedValue);
                hdnAutoridadId.Value = ddlTercerNivel.SelectedValue;

                //Transacción 
                oENTResponse = oBPAutoridad.UpdateSolicitudAutoridad(oENTAutoridad);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Autoridad modificada con éxito', 'Success', true);"
                    , true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region "Voces"

        private void ComboVocesPrimerNivel()
        {
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();

            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadrePrimerNivel = 0;
            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadreSegundoNivel = 0;

            oBPVocesSenaladas.SelectNivelesVoces();

            if (oBPVocesSenaladas.ErrorId == 0)
            {
                if (oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    ddlVocesNivel1.DataSource = oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[0];
                    ddlVocesNivel1.DataTextField = "Nombre";
                    ddlVocesNivel1.DataValueField = "VozId";
                    ddlVocesNivel1.DataBind();
                }
            }
        }

        private void ComboVocesSegundoNivel()
        {
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();

            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadrePrimerNivel = Convert.ToInt32(ddlVocesNivel1.SelectedValue);
            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadreSegundoNivel = 0;

            oBPVocesSenaladas.SelectNivelesVoces();

            if (oBPVocesSenaladas.ErrorId == 0)
            {
                if (oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[1].Rows.Count > 0)
                {
                    ddlVocesNivel2.DataSource = oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[1];
                    ddlVocesNivel2.DataTextField = "Nombre";
                    ddlVocesNivel2.DataValueField = "VozId";
                    ddlVocesNivel2.DataBind();
                }
            }
        }

        private void ComboVocesTercerNivel()
        {
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();

            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadrePrimerNivel = Convert.ToInt32(ddlVocesNivel1.SelectedValue);
            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadreSegundoNivel = Convert.ToInt32(ddlVocesNivel2.SelectedValue);

            oBPVocesSenaladas.SelectNivelesVoces();

            if (oBPVocesSenaladas.ErrorId == 0)
            {
                if (oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[2].Rows.Count > 0)
                {
                    ddlVocesNivel3.DataSource = oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[2];
                    ddlVocesNivel3.DataTextField = "Nombre";
                    ddlVocesNivel3.DataValueField = "VozId";
                    ddlVocesNivel3.DataBind();
                }
            }
        }

        private void AgregarVoz(int solicitudId, int AutoridadId, int VozId)
        {
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();
            ENTVocesSenaladas oENTVocesSenaladas = new ENTVocesSenaladas();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                if (ddlVocesNivel3.SelectedValue == "0") { throw new Exception("Debe elegir una voz señalada"); }

                // Formulario 
                oENTVocesSenaladas.SolicitudId = solicitudId;
                oENTVocesSenaladas.AutoridadId = AutoridadId;
                oENTVocesSenaladas.VozId = VozId;

                //Transacción 
                oENTResponse = oBPVocesSenaladas.InsertSolicitudAutoridadVoces(oENTVocesSenaladas);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Voz agregada con éxito', 'Success', true);"
                    , true);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void BorrarVoz(int solicitudId, int AutoridadId, int VozId)
        {
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();
            ENTVocesSenaladas oENTVocesSenaladas = new ENTVocesSenaladas();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Formulario 
                oENTVocesSenaladas.SolicitudId = solicitudId;
                oENTVocesSenaladas.AutoridadId = AutoridadId;
                oENTVocesSenaladas.VozId = VozId;

                //Transacción 
                oENTResponse = oBPVocesSenaladas.DeleteSolicitudAutoridadVoces(oENTVocesSenaladas);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LlenarGridVoces(int SolicitudId, int AutoridadId)
        {
            BPSolicitud oBPSolicitud = new BPSolicitud();

            oBPSolicitud.AutoridadEntity.SolicitudId = SolicitudId;
            oBPSolicitud.AutoridadEntity.AutoridadId = AutoridadId;
            oBPSolicitud.SelectSolicitudAutoridadVoces();

            if (oBPSolicitud.ErrorId == 0)
            {
                if (oBPSolicitud.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    gvVoces.DataSource = oBPSolicitud.AutoridadEntity.dsResponse;
                    gvVoces.DataBind();
                }
                else
                {
                    gvVoces.DataSource = null;
                    gvVoces.DataBind();
                }
            }
            else
            {
                gvVoces.DataSource = null;
                gvVoces.DataBind();
            }
        }

        #endregion

        protected void btnTerminar_Click(object sender, EventArgs e)
        {
            LimpiarLabelsDetalle();
        }

        #endregion

    }
}