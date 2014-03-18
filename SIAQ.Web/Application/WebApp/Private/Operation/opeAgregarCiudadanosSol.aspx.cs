// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Configuration;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarCiudadanosSol : System.Web.UI.Page
    {
        string AllDefault = "-- Todos --";

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

            //BPColonia BPColonia = new BPColonia();

            //BuscadorListaColonia.DataValueField = "ColoniaId";
            //BuscadorListaColonia.DataTextField = "Nombre";


            //BuscadorListaColonia.DataSource = BPColonia.SelectColonia();
            //BuscadorListaColonia.DataBind();
            //BuscadorListaColonia.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectCiudad()
        {

            //BPCiudad BPCiudad = new BPCiudad();

            //BuscadorListaCiudad.DataValueField = "CiudadId";
            //BuscadorListaCiudad.DataTextField = "Nombre";


            //BuscadorListaCiudad.DataSource = BPCiudad.SelectCiudad();
            //BuscadorListaCiudad.DataBind();
            //BuscadorListaCiudad.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectPais()
        {

            //BPPais BPPais = new BPPais();

            //BuscadorListaPais.DataValueField = "PaisId";
            //BuscadorListaPais.DataTextField = "Nombre";


            //BuscadorListaPais.DataSource = BPPais.SelectPais();
            //BuscadorListaPais.DataBind();
            //BuscadorListaPais.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectEstado()
        {

            //BPEstado BPEstado = new BPEstado();

            //BuscadorListaEstado.DataSource = "EstadoId";
            //BuscadorListaEstado.DataTextField = "Nombre";

            //BuscadorListaEstado.DataSource = BPEstado.SelectEstado();
            //BuscadorListaEstado.DataBind();
            //BuscadorListaEstado.Items.Insert(0, new ListItem(AllDefault, "0"));

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