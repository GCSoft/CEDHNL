using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GCSoft.Utilities.Common;

using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarAutoridaSenalada : System.Web.UI.Page
    {

        #region Atributos

        public string _SolicitudId;
        Function utilFunction = new Function();

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

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

        #endregion

        #region "Botones"

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string solicitudId = SolicitudIdHidden.Value;

                AgregarAutoridad(Convert.ToInt32(solicitudId));

                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('Autoridad agregada con éxito', 'Success', true);", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            string solicitudId = SolicitudIdHidden.Value;
            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + solicitudId);
        }

        #endregion

        #region "GridView"

        protected void gvAutoridadesAgregadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string SolicitudId = String.Empty;
            int intRow = 0;
            string AutoridadId = String.Empty;

            try
            {
                // Opción seleccionada 
                string sCommandName = e.CommandName.ToString();

                if (sCommandName == "Sort") { return; }

                // Fila
                intRow = Convert.ToInt32(e.CommandArgument.ToString());

                //Ciudadano Id 
                AutoridadId = e.CommandArgument.ToString();
                SolicitudId = SolicitudIdHidden.Value;

                switch (sCommandName)
                {
                    case "Borrar":
                        BorrarAutoridad(Convert.ToInt32(AutoridadId), Convert.ToInt32(SolicitudId));
                        break;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvAutoridadesAgregadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String sImagesAttributes = "";
            String sToolTip = "";

            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("ImagenEliminar");

                //Tooltip Edición
                sToolTip = "Eliminar autoridad";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                //Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                //Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #endregion

        #region Funciones

        private void PageLoad()
        {

            if (!this.Page.IsPostBack)
            {
                try
                {
                    _SolicitudId = Request.QueryString["s"].ToString();
                    SolicitudLabel.Text = _SolicitudId;
                    SolicitudIdHidden.Value = _SolicitudId;

                    ComboAutoridadPrimerNivel();
                    ddlPrimerNivel.SelectedIndex = 0;
                    ComboAutoridadSegundoNivel();
                    ddlSegundoNivel.SelectedIndex = 0;
                    ComboAutoridadTercerNivel();
                    LlenarListaAutoridades();
                }
                catch (Exception Exception)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                }
            }
        }

        private void ComboAutoridadPrimerNivel()
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = 0;
            oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
            oBPAutoridad.SelectNivelesAutoridad();

            if (oBPAutoridad.ErrorId == 0)
            {
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    ddlPrimerNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0];
                    ddlPrimerNivel.DataTextField = "Nombre";
                    ddlPrimerNivel.DataValueField = "AutoridadId";
                    ddlPrimerNivel.DataBind();
                }
            }
        }

        private void ComboAutoridadSegundoNivel()
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlPrimerNivel.SelectedValue);
            oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
            oBPAutoridad.SelectNivelesAutoridad();

            if (oBPAutoridad.ErrorId == 0)
            {
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    ddlSegundoNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[1];
                    ddlSegundoNivel.DataTextField = "Nombre";
                    ddlSegundoNivel.DataValueField = "AutoridadId";
                    ddlSegundoNivel.DataBind();
                }
            }
        }

        private void ComboAutoridadTercerNivel()
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlPrimerNivel.SelectedValue);
            oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = Convert.ToInt32(ddlSegundoNivel.SelectedValue);
            oBPAutoridad.SelectNivelesAutoridad();

            if (oBPAutoridad.ErrorId == 0)
            {
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    ddlTercerNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[2];
                    ddlTercerNivel.DataTextField = "Nombre";
                    ddlTercerNivel.DataValueField = "AutoridadId";
                    ddlTercerNivel.DataBind();
                }
            }
        }

        private void LlenarListaAutoridades()
        {
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.SolicitudId = Convert.ToInt32(SolicitudIdHidden.Value);
            oBPAutoridad.SelectListaAutoridadesSolicitud();

            if (oBPAutoridad.ErrorId == 0)
            {
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    gvAutoridadesAgregadas.DataSource = oBPAutoridad.AutoridadEntity.dsResponse;
                    gvAutoridadesAgregadas.DataBind();
                }
                else
                {
                    gvAutoridadesAgregadas.DataSource = null;
                    gvAutoridadesAgregadas.DataBind();
                }
            }
            else
            {
                gvAutoridadesAgregadas.DataSource = null;
                gvAutoridadesAgregadas.DataBind();
            }
        }

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
                LlenarListaAutoridades();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
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

                //Transacción 
                oENTResponse = oBPAutoridad.InsertSolicitudAutoridad(oENTAutoridad);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                //Actualizar Datos
                LlenarListaAutoridades();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LimpiarCampos()
        {
            ComboAutoridadPrimerNivel();
            ddlPrimerNivel.SelectedIndex = 0;
            ComboAutoridadSegundoNivel();
            ddlSegundoNivel.SelectedIndex = 0;
            ComboAutoridadTercerNivel();
            tbNombreFuncionario.Text = String.Empty;
            tbPuestoActual.Text = String.Empty;
            tbComentarios.Text = String.Empty;

            ddlPrimerNivel.Focus();
        }


        #endregion

    }
}