// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Configuration;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarCiudadanosSol : System.Web.UI.Page
    {

        // Utilerías
        Function utilFunction = new Function();

        //Variables Globales 
        string AllDefault = "-- Todos --";
        public string _SolicitudId;

        protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvCiudadanoGridRowCommand(e);
        }

        private void gvCiudadanoGridRowCommand(GridViewCommandEventArgs e)
        {

            string CiudadanoId = string.Empty;
            int TipoCiudadanoId = 1; //estos valores los debe de traer un checkbox, se han declarado solo para pruebas

            int SolicitudId = int.Parse(SolicitudIDHidden.Value);
            CiudadanoId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Agregar":

                    BPCiudadano BPCiudadano = new BPCiudadano();

                    BPCiudadano.ENTCiudadano.CiudadanoId = int.Parse(CiudadanoId);
                    BPCiudadano.ENTCiudadano.SolicitudId = SolicitudId;
                    BPCiudadano.ENTCiudadano.TipoCiudadanoId = TipoCiudadanoId;

                    BPCiudadano.AgregarCiudadanoSolicitud();

                    SelectCiudadanosAgregados(SolicitudId);
                    break;

            }
        }


        protected void gvCiudadanoAgregados_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string CiudadanoId = string.Empty;
            int SolicitudId = int.Parse(SolicitudIDHidden.Value);
            CiudadanoId = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "Eliminar":

                    BPCiudadano BPCiudadano = new BPCiudadano();

                    BPCiudadano.ENTCiudadano.CiudadanoId = int.Parse(CiudadanoId);
                    BPCiudadano.ENTCiudadano.SolicitudId = SolicitudId;

                    BPCiudadano.EliminarCiudadanoSolicitud();

                    SelectCiudadanosAgregados(SolicitudId);
                    break;

                case "SelectCiudadano":

                    Response.Redirect("/Application/WebApp/Private/Operation/opeDetalleCiudadano.aspx?s=" + CiudadanoId);

                    break;


            }
        }
        

        protected void QuickSearch(string SearchText)
        {

            BuscarCiudadano(BuscadorListaPais.SelectedValue, BuscadorListaEstado.SelectedValue, BuscadorListaCiudad.SelectedValue, BuscadorListaColonia.SelectedValue, "", "", "", "", SearchText);
        }

        protected void BuscarCiudadano(string Nombre, string Paterno, string Materno, string Calle)
        {

            BuscarCiudadano(BuscadorListaPais.SelectedValue, BuscadorListaEstado.SelectedValue, BuscadorListaCiudad.SelectedValue, BuscadorListaColonia.SelectedValue, Nombre, Paterno, Materno, Calle, "");
        }

        protected void QuickSearchButton_Click(object sender, EventArgs e)
        {
            QuickSearch(txtNombre.Text.Trim());//cambio de funciones
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            BuscarCiudadano(TextBoxNombre.Text.Trim(), TextBoxPaterno.Text.Trim(), TextBoxMaterno.Text.Trim(), TextBoxCalle.Text.Trim());
        }

        protected void BusquedaRapida_Click(object sender, EventArgs e)
        {
            VerBusquedaRapida();
        }

        protected void BusquedaAvanzada_Click(object sender, EventArgs e)
        {
            VerBusquedaAvanzada();
        }


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                SelectEstado();
                SelectPais();
                SelectCiudad();
                SelectColonia();

                

                gvCiudadano.DataSource = null;
                gvCiudadano.DataBind();
                
                gvCiudadanosAgregados.DataSource = null;
                gvCiudadanosAgregados.DataBind();
                
                try
                {
                    SolicitudIDHidden.Value = Request.QueryString["s"].ToString();
                    _SolicitudId = SolicitudIDHidden.Value;
                    SelectCiudadanosAgregados(int.Parse(SolicitudIDHidden.Value));
                    SolicitudLabel.Text = SolicitudIDHidden.Value;
                    SolicitudLabelSearch.Text = SolicitudIDHidden.Value;
                }
                catch (Exception Exception)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                }
            }
        }

        protected void BuscarCiudadano(string PaisId, string EstadoId, string CiudadId, string ColoniaId, string Nombre, string Paterno, string Materno, string Calle, string CampoBusqueda)
        {
            BPCiudadano BPCiudadano = new BPCiudadano();

            BPCiudadano.ENTCiudadano.Nombre = Nombre;
            BPCiudadano.ENTCiudadano.ApellidoPaterno = Paterno;
            BPCiudadano.ENTCiudadano.ApellidoMaterno = Materno;
            BPCiudadano.ENTCiudadano.CiudadId = CiudadId;
            BPCiudadano.ENTCiudadano.EstadoId = EstadoId;
            BPCiudadano.ENTCiudadano.PaisId = PaisId;
            BPCiudadano.ENTCiudadano.ColoniaId = ColoniaId;
            BPCiudadano.ENTCiudadano.Calle = Calle;
            BPCiudadano.ENTCiudadano.CampoBusqueda = CampoBusqueda;

            BPCiudadano.BuscarCiudadano();

            if (BPCiudadano.ErrorId == 0)
            {
                if (BPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvCiudadano.DataSource = BPCiudadano.ENTCiudadano.ResultData;
                    gvCiudadano.DataBind();
                }

            }
            else
            {
                gvCiudadano.DataSource = null;
                gvCiudadano.DataBind();
            }
        }

        protected void SelectCiudadanosAgregados(int SolicitudId)
        {
            BPCiudadano BPCiudadano = new BPCiudadano();

            BPCiudadano.ENTCiudadano.SolicitudId = SolicitudId;
            BPCiudadano.SelectCiudadanosAgregados();

            if (BPCiudadano.ErrorId == 0)
            {
                if (BPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                {
                    gvCiudadanosAgregados.DataSource = BPCiudadano.ENTCiudadano.ResultData;
                    gvCiudadanosAgregados.DataBind();
                }
                else {

                    gvCiudadanosAgregados.DataSource = null;
                    gvCiudadanosAgregados.DataBind();
                
                }
            }
        }

        protected void SelectColonia()
        {
            ENTColonia oENTColonia = new ENTColonia();
            ENTResponse oENTResponse = new ENTResponse();

            BPColonia oBPColonia = new BPColonia();


            try
            {


                // Formulario
                oENTColonia.ColoniaId = 0;
                oENTColonia.CiudadId = Int32.Parse(this.BuscadorListaCiudad.SelectedValue);
                oENTColonia.Nombre = "";
                oENTColonia.Activo = 1;

                // Transacción
                oENTResponse = oBPColonia.SelectColonia(oENTColonia);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Llenado de combo
                this.BuscadorListaColonia.DataTextField = "Nombre";
                this.BuscadorListaColonia.DataValueField = "ColoniaId";
                this.BuscadorListaColonia.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaColonia.DataBind();
                BuscadorListaColonia.Items.Insert(0, new ListItem(AllDefault, "-1"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        protected void SelectCiudad()
        {
            ENTCiudad oENTCiudad = new ENTCiudad();
            ENTResponse oENTResponse = new ENTResponse();

            BPCiudad oBPCiudad = new BPCiudad();

            try
            {

                // Formulario
                oENTCiudad.CiudadId = 0;
                oENTCiudad.EstadoId = Int32.Parse(this.BuscadorListaEstado.SelectedValue);
                oENTCiudad.Nombre = "";
                oENTCiudad.Activo = 1;

                // Transacción
                oENTResponse = oBPCiudad.SelectCiudad(oENTCiudad);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Llenado de combo
                this.BuscadorListaCiudad.DataTextField = "Nombre";
                this.BuscadorListaCiudad.DataValueField = "CiudadId";
                this.BuscadorListaCiudad.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaCiudad.DataBind();
                BuscadorListaCiudad.Items.Insert(0, new ListItem(AllDefault, "-1"));

            }
            catch (Exception ex)
            {
                //throw (ex);
            }
        }

        protected void SelectPais()
        {
            ENTPais oENTPais = new ENTPais();
            ENTResponse oENTResponse = new ENTResponse();

            BPPais oBPPais = new BPPais();

            try
            {

                // Formulario
                oENTPais.PaisId = 0;
                oENTPais.Nombre = "";
                oENTPais.Activo = 1;

                // Transacción
                oENTResponse = oBPPais.SelectPais(oENTPais);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
                if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

                // Llenado de combo
                this.BuscadorListaPais.DataTextField = "Nombre";
                this.BuscadorListaPais.DataValueField = "PaisId";
                this.BuscadorListaPais.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaPais.DataBind();

                BuscadorListaPais.Items.Insert(0, new ListItem(AllDefault, "-1"));

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void SelectEstado()
        {
            ENTEstado oENTEstado = new ENTEstado();
            ENTResponse oENTResponse = new ENTResponse();

            BPEstado oBPEstado = new BPEstado();

            try
            {

                // Formulario
                oENTEstado.EstadoId = 0;
                oENTEstado.PaisId = Int32.Parse(this.BuscadorListaPais.SelectedValue);
                oENTEstado.Nombre = "";
                oENTEstado.Activo = 1;

                // Transacción
                oENTResponse = oBPEstado.SelectEstado(oENTEstado);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Llenado de combo
                this.BuscadorListaEstado.DataTextField = "Nombre";
                this.BuscadorListaEstado.DataValueField = "EstadoId";
                this.BuscadorListaEstado.DataSource = oENTResponse.dsResponse.Tables[1];
                this.BuscadorListaEstado.DataBind();
                BuscadorListaEstado.Items.Insert(0, new ListItem(AllDefault, "-1"));

            }
            catch (Exception ex)
            {
                //throw (ex);
            }

        }

        protected void BuscadorListaCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Consulta de colonias
                SelectColonia();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Consulta de ciudades y colonias
                SelectCiudad();
                SelectColonia();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }

        protected void BuscadorListaPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                // Consulta de estados, ciudades y colonias
                SelectEstado();
                SelectCiudad();
                SelectColonia();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "'); focusControl('" + this.txtNombre.ClientID + "');", true);
            }
        }
        protected void VerBusquedaRapida()
        {

            pnlBusqedaAvanzada.Visible = false;
            pnlBusquedaSimple.Visible = true;
        }

        protected void VerBusquedaAvanzada()
        {

            pnlBusqedaAvanzada.Visible = true;
            pnlBusquedaSimple.Visible = false;
        }

        protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}