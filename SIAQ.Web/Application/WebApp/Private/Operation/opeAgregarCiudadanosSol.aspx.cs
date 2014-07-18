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
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarCiudadanosSol : System.Web.UI.Page
    {

        // Utilerías
        Function utilFunction = new Function();

        //Variables Globales 
        string AllDefault = "-- Todos --";
        public string _SolicitudId;

       
       // Funciones del programador

        void AgregaCiudadanoASolicitud(String CiudadanoId){
           BPCiudadano BPCiudadano = new BPCiudadano();

           try
           {

              BPCiudadano.ENTCiudadano.CiudadanoId = int.Parse(CiudadanoId);
              BPCiudadano.ENTCiudadano.SolicitudId = int.Parse(SolicitudIDHidden.Value);
              BPCiudadano.ENTCiudadano.TipoCiudadanoId = 1; // estos valores los debe de traer un checkbox, se han declarado solo para pruebas

              BPCiudadano.AgregarCiudadanoSolicitud();

              SelectCiudadanosAgregados(int.Parse(SolicitudIDHidden.Value));

           }catch (Exception ex){
              throw(ex);
           }
        }

		private void SelectSolicitud(){
			BPSolicitud SolicitudProcess = new BPSolicitud();
			int SolicitudId;

			// 
			SolicitudId = Int32.Parse(SolicitudIDHidden.Value);

			SolicitudProcess.SolicitudEntity.SolicitudId = SolicitudId;

			SolicitudProcess.SelectSolicitudDetalle();

			if (SolicitudProcess.ErrorId == 0)
			{
				if (SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0)
				{
					SolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Numero"].ToString();
					CalificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreCalificacion"].ToString();
					EstatusaLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreEstatus"].ToString();
					FuncionarioLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreFuncionario"].ToString();
					ContactoLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreContacto"].ToString();
					TipoSolicitudLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreTipoSolicitud"].ToString();
					ObservacionesLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
					LugarHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["NombreLugarHechos"].ToString();
					DireccionHechosLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

					FechaRecepcionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaRecepcion"].ToString();
					FechaAsignacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaAsignacion"].ToString();
					FechaGestionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
					FechaModificacionLabel.Text = SolicitudProcess.SolicitudEntity.ResultData.Tables[1].Rows[0]["UltimaModificacion"].ToString();

				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
			}
		}


       // Eventos de la página

        protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gvCiudadanoGridRowCommand(e);
        }

        private void gvCiudadanoGridRowCommand(GridViewCommandEventArgs e){
            string CiudadanoId = string.Empty;
            
            // Ciudadano seleccionado
            CiudadanoId = e.CommandArgument.ToString();
            
            switch (e.CommandName.ToString()){
                case "Agregar":
                  AgregaCiudadanoASolicitud(CiudadanoId);
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

        protected void QuickSearchButton_Click(object sender, EventArgs e)
        {
            BuscarCiudadano("", "" , "" , "" , 0 , 0 , 0, 0, txtNombre.Text.Trim());
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            BuscarCiudadano(TextBoxNombre.Text.Trim(), TextBoxPaterno.Text.Trim(), TextBoxMaterno.Text.Trim(), TextBoxCalle.Text.Trim(), int.Parse(BuscadorListaPais.SelectedValue), int.Parse(BuscadorListaEstado.SelectedValue), int.Parse(BuscadorListaCiudad.SelectedValue), int.Parse(BuscadorListaColonia.SelectedValue), "");
        }

        protected void BusquedaRapida_Click(object sender, EventArgs e)
        {
            VerBusquedaRapida();
        }

        protected void BusquedaAvanzada_Click(object sender, EventArgs e)
        {
            VerBusquedaAvanzada();
        }

        protected void Page_Load(object sender, EventArgs e){

           if (Page.IsPostBack) { return; }

            // Lógica de la página
            SelectPais();
            SelectEstado();
            SelectCiudad();
            SelectColonia();
    
            gvCiudadano.DataSource = null;
            gvCiudadano.DataBind();
                
            gvCiudadanosAgregados.DataSource = null;
            gvCiudadanosAgregados.DataBind();
                
            try
            {
               
               // Tomar la solicitud
               SolicitudIDHidden.Value = Request.QueryString["s"].ToString();
               _SolicitudId = SolicitudIDHidden.Value;

				// consultar la carátula
			   SelectSolicitud();


               // Consultar ciudadanos agregados
               SelectCiudadanosAgregados(int.Parse(SolicitudIDHidden.Value));

               // Tomar el ciudadano (en este caso viene de Registro de ciudadano)
               if (this.Request.QueryString["c"] != null){
                  AgregaCiudadanoASolicitud(this.Request.QueryString["c"].ToString());
               }

            }catch (Exception Exception){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
            }
            
        }

        protected void BuscarCiudadano(string Nombre, string Paterno, string Materno, string Calle, int PaisId, int EstadoId, int CiudadId, int ColoniaId, string CampoBusqueda)
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


                else
                {
                    gvCiudadano.DataSource = null;
                    gvCiudadano.DataBind();
                }
            }
        }

        protected void SelectCiudadanosAgregados(int SolicitudId){
            BPCiudadano BPCiudadano = new BPCiudadano();

            BPCiudadano.ENTCiudadano.SolicitudId = SolicitudId;
            BPCiudadano.SelectCiudadanosAgregados();

            // Validaciones
            if (BPCiudadano.ErrorId != 0){
               return;
            }

            // Listado de ciudadanos
            if (BPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0){

               gvCiudadanosAgregados.DataSource = BPCiudadano.ENTCiudadano.ResultData;
               gvCiudadanosAgregados.DataBind();
            }else{

               gvCiudadanosAgregados.DataSource = null;
               gvCiudadanosAgregados.DataBind();

            }

			//// Número de solicitud
			//SolicitudLabel.Text = BPCiudadano.ENTCiudadano.ResultData.Tables[1].Rows[0]["Numero"].ToString();
			//SolicitudLabelSearch.Text = BPCiudadano.ENTCiudadano.ResultData.Tables[1].Rows[0]["Numero"].ToString();

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
                BuscadorListaColonia.Items.Insert(0, new ListItem(AllDefault, "0"));

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
                BuscadorListaCiudad.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
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

                BuscadorListaPais.Items.Insert(0, new ListItem(AllDefault, "0"));

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
                BuscadorListaEstado.Items.Insert(0, new ListItem(AllDefault, "0"));

            }
            catch (Exception ex)
            {
                throw (ex);
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

        protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			
			   try{

               // Validación de que sea fila
               if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				   // Puntero y Sombra en fila Over
				   e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");

				   // Puntero y Sombra en fila Out
				   e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "';");
				
			   }catch (Exception ex){
				   throw (ex);
			   }
        }

        protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
            DataTable tblCiudadano = null;
			   DataView viewCiudadano = null;
			
			   try{

				   // Obtener DataTable y DataView del GridView
               tblCiudadano = utilFunction.ParseGridViewToDataTable(this.gvCiudadano, true);
				   viewCiudadano = new DataView(tblCiudadano);

				   // Determinar ordenamiento
				   this.hddSort.Value = (this.hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				   // Ordenar vista
				   viewCiudadano.Sort = this.hddSort.Value;

				   // Vaciar datos
               this.gvCiudadano.DataSource = viewCiudadano;
               this.gvCiudadano.DataBind();
				
			   }catch (Exception ex){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
			   }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            string sSolicitudId = SolicitudIDHidden.Value;
            Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + sSolicitudId);
        }

        protected void btnNuevoCiudadano_Click(object sender, EventArgs e){
           string sSolicitudId = SolicitudIDHidden.Value;
           Response.Redirect("~/Application/WebApp/Private/Operation/opeRegistroCiudadano.aspx?acs=" + sSolicitudId);
        }

    }
}