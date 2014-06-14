/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicDictamenMedico
' Autor:	Ruben.Cobos
' Fecha:	05-Junio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class VicDictamenMedico : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                // Validaciones
                if (Page.IsPostBack) { return; }
                if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
                if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

                // Obtener ExpedienteId
                this.hddAtencionId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
                this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

                // Llenado de controles
                BuscaDictamen();
                Fillcbo();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCiudadano.ClientID + "');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        #region Rutinas de la página

        // Rutinas de la página
        protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {
                int Valido = 1;
                // ValidaDictamen
                ValidaCampos(ref Valido);

                // Valida dictámen
                if (Valido == 1)
				    InsertDictamen();
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText("Debe capturar los campos requeridos") + "', 'Fail', true); focusControl('" + this.ddlCiudadano.ClientID + "');", true);

				// Regresar al detalle del formulario
                Response.Redirect("VicDetalleAtencion.aspx?key=" + this.hddAtencionId.Value + "|" + this.SenderId.Value, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCiudadano.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
            Response.Redirect("VicDetalleAtencion.aspx?key=" + this.hddAtencionId.Value + "|" + this.SenderId.Value, false);
		}

		protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

				// Atributos Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvApps_Sorting(object sender, GridViewSortEventArgs e){
			DataTable TableAutoridad = null;
			DataView ViewAutoridad = null;

			try
			{
				//Obtener DataTable y View del GridView
				TableAutoridad = utilFunction.ParseGridViewToDataTable(gvApps, false);
				ViewAutoridad = new DataView(TableAutoridad);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				ViewAutoridad.Sort = hddSort.Value;

				//Vaciar datos
				this.gvApps.DataSource = ViewAutoridad;
				this.gvApps.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

        #endregion

        #region Rutinas del programador

        // Rutinas del programador

        private void InsertDictamen()
        {
            ENTResponse oResponse = new ENTResponse();
            BPDictamen bss = new BPDictamen();
            ENTDictamen ent = new ENTDictamen();
            DataSet ds = new DataSet();

            // Validaciones
            if (this.ddlCiudadano.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Ciudadano")); }

            // Parámetros
            ent.AtencionId = Int32.Parse(this.hddAtencionId.Value.Trim());
            ent.CiudadanoId = Int32.Parse(this.ddlCiudadano.SelectedItem.Value);

            // Transacción
            oResponse= bss.insertDictamen(ent);
            ds = oResponse.dsResponse;

            // Errores
            //if (ds.ErrorId != 0) { throw (new Exception(ds.ErrorString)); }

        }

        private void BuscaDictamen()
        {
            ENTResponse oResponse = new ENTResponse();
            BPDictamen bss = new BPDictamen();
            ENTDictamen ent = new ENTDictamen();
            DataSet ds = new DataSet();

            // Parámetros
            ent.AtencionId = Int32.Parse(this.hddAtencionId.Value);

            // Transacción
            oResponse = bss.searchDictamen(ent);
            ds = oResponse.dsResponse;

            // Errores
            //if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

            // No se encontró el expediente
            //if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count == 0) { throw (new Exception("No se encontro el expediente")); }

            // Formulario
            this.lblAtencionId.Text = ds.Tables[0].Rows[0]["AtencionId"].ToString();

            // Grid
            this.gvApps.DataSource = ds.Tables[1];
            this.gvApps.DataBind();

        }

        private void Fillcbo()
        {
            // Declaración de variables
            ENTResponse oResponse = new ENTResponse();
            ENTCiudadano ent = new ENTCiudadano();
            BPCiudadano bss = new BPCiudadano();

            try
            {
                // Asignación de valores
                ent.AtencionId = Int32.Parse(lblAtencionId.Text);

                // Transacción
                oResponse = bss.searchCiudadanoAtencion(ent);

                if (oResponse.dsResponse.Tables[1].Rows.Count > 0)
                {
                    ddlCiudadano.DataSource = oResponse.dsResponse.Tables[1];
                    ddlCiudadano.DataValueField = "CiudadanoId";
                    ddlCiudadano.DataTextField = "NombreCiudadano";
                    ddlCiudadano.DataBind();
                }
            }
            catch (Exception ex) { throw (ex); }
            finally { }
        }

        private void ValidaCampos(ref int Valido)
        {
            try {
                if (ddlCiudadano.SelectedItem.Text != "0") { Valido = 1; } else { Valido = 0; return; }
                if (txtDictamen.Text != "") { Valido = 1; } else { Valido = 0; return; }
            }
            catch (Exception ex) { throw(ex); }
            finally { }
        
        }

        #endregion

	}
}