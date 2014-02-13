using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeBusquedaCiudadano : System.Web.UI.Page
    {
        string AllDefault = "-- Todos --";


        protected void BusquedaRapida_Click(object sender, EventArgs e)
        {
            VerBusquedaRapida();
        }

        protected void BusquedaAvanzada_Click(object sender, EventArgs e)
        {
            VerBusquedaAvanzada();
        }

        protected void QuickSearchButton_Click(object sender, EventArgs e)
        {
            QuickSearch(txtNombre.Text.Trim());//cambio de funciones
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            BuscarCiudadano(TextBoxNombre.Text.Trim(), TextBoxPaterno.Text.Trim(), TextBoxMaterno.Text.Trim(), TextBoxCalle.Text.Trim());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        protected void VerBusquedaRapida()
        {

            pnlBusqedaAvanzada.Visible = false;
            pnlBusquedaSimple.Visible = true;
        }

        protected void PageLoad()
        {
            if (!Page.IsPostBack)
            {
                SelectEstado();
                SelectPais();
                SelectCiudad();
                SelectColonia();

            }
        }

        protected void SelectColonia()
        {

            BPColonia BPColonia = new BPColonia();

            BuscadorListaColonia.DataValueField = "ColoniaId";
            BuscadorListaColonia.DataTextField = "Nombre";


            BuscadorListaColonia.DataSource = BPColonia.SelectColonia();
            BuscadorListaColonia.DataBind();
            BuscadorListaColonia.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectCiudad()
        {

            BPCiudad BPCiudad = new BPCiudad();

            BuscadorListaCiudad.DataValueField = "CiudadId";
            BuscadorListaCiudad.DataTextField = "Nombre";


            BuscadorListaCiudad.DataSource = BPCiudad.SelectCiudad();
            BuscadorListaCiudad.DataBind();
            BuscadorListaCiudad.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectPais()
        {

            BPPais BPPais = new BPPais();

            BuscadorListaPais.DataValueField = "PaisId";
            BuscadorListaPais.DataTextField = "Nombre";


            BuscadorListaPais.DataSource = BPPais.SelectPais();
            BuscadorListaPais.DataBind();
            BuscadorListaPais.Items.Insert(0, new ListItem(AllDefault, "0"));
        }

        protected void SelectEstado()
        {

            BPEstado BPEstado = new BPEstado();

            BuscadorListaEstado.DataSource = "EstadoId";
            BuscadorListaEstado.DataTextField = "Nombre";

            BuscadorListaEstado.DataSource = BPEstado.SelectEstado();
            BuscadorListaEstado.DataBind();
            BuscadorListaEstado.Items.Insert(0, new ListItem(AllDefault, "0"));

        }
        protected void VerBusquedaAvanzada()
        {

            pnlBusqedaAvanzada.Visible = true;
            pnlBusquedaSimple.Visible = false;
        }

        protected void QuickSearch(string SearchText)
        {
            //SearchTextHidden.Value = SearchText;

            BuscarCiudadano(BuscadorListaPais.SelectedValue, BuscadorListaEstado.SelectedValue, BuscadorListaCiudad.SelectedValue, BuscadorListaColonia.SelectedValue, "", "", "", "", SearchText);
        }

        protected void BuscarCiudadano(string Nombre, string Paterno, string Materno, string Calle)
        {
            //NameSearchHidden.Value = Name;

            BuscarCiudadano(BuscadorListaPais.SelectedValue, BuscadorListaEstado.SelectedValue, BuscadorListaCiudad.SelectedValue, BuscadorListaColonia.SelectedValue, Nombre, Paterno, Materno, Calle, "");
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

            gvCiudadano.DataSource = null;
            gvCiudadano.DataBind();

        }

        protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

    }
}