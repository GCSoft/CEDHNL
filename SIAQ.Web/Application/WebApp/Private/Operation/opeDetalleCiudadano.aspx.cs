using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using GCSoft.Utilities.Common;


namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDetalleCiudadano : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            string ciudadanoId = Convert.ToString(Request.QueryString["s"]);
            if (String.IsNullOrEmpty(ciudadanoId)) { ciudadanoId = "0"; }
            hdnCiudadanoId.Value = ciudadanoId;

            ObtenerDetalleCiudadano(Convert.ToInt32(ciudadanoId));
            ComboSolicitudes(Convert.ToInt32(ciudadanoId));
            ComboVisitas(Convert.ToInt32(ciudadanoId));
        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades
        #endregion

        #region Eventos

        #region "GridView"
        #endregion

        #region "Botones"
        #endregion

        #endregion

        #region Funciones

        private void ObtenerDetalleCiudadano(int ciudadanoId)
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.CiudadanoId = ciudadanoId;
                oBPCiudadano.SelectDetalleCiudadano();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        lblNombre.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Nombre"].ToString();
                        lblApellidoPaterno.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["ApellidoPaterno"].ToString();
                        lblApellidoMaterno.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["ApellidoMaterno"].ToString();
                        lblSexo.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Sexo"].ToString();
                        lblFechaNacimiento.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                        lblNacionalidad.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Nacionalidad"].ToString();
                        lblOcupacion.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Ocupacion"].ToString();
                        lblEscolaridad.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Escolaridad"].ToString();
                        lblEstadoCivil.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["EstadoCivil"].ToString();
                        lblTelefonoPrincipal.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["TelefonoPrincipal"].ToString();
                        lblOtroTelefono.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["TelefonoOtro"].ToString();
                        lblCorreoElectronico.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["CorreoElectronico"].ToString();
                        lblDependientesEconomicos.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["DependientesEconomicos"].ToString();
                        lblFormaEnterarse.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["MedioComunicacionId"].ToString();
                        lblPais.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Pais"].ToString();
                        lblEstado.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Estado"].ToString();
                        lblCiudad.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Ciudad"].ToString();
                        lblColonia.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Colonia"].ToString();
                        lblCalle.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["Calle"].ToString();
                        lblNoExterior.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["NumeroExterior"].ToString();
                        lblNumInterior.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["NumeroInterior"].ToString();
                        lblAniosResidiendoNL.Text = oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows[0]["AniosResidiendoNL"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page
                    , this.GetType()
                    , Convert.ToString(Guid.NewGuid())
                    , "tinyboxMessage('" + ex.Message + "','Fail',true);"
                    , true);
            }
        }

        private void ComboSolicitudes(int ciudadanoId)
        {
            BPSolicitudCiudadano oBPSolicitudCiudadano = new BPSolicitudCiudadano();

            oBPSolicitudCiudadano.SolicitudCiudadanoEntity.CiudadanoId = ciudadanoId;
            oBPSolicitudCiudadano.SelectSolicitudesCiudadano();

            if (oBPSolicitudCiudadano.ErrorId == 0)
            {
                if (oBPSolicitudCiudadano.SolicitudCiudadanoEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    gvSollicitudesIntervencion.DataSource = oBPSolicitudCiudadano.SolicitudCiudadanoEntity.dsResponse;
                    gvSollicitudesIntervencion.DataBind();
                }
                else
                {
                    gvSollicitudesIntervencion.DataSource = null;
                    gvSollicitudesIntervencion.DataBind();
                }
            }
            else
            {
                gvSollicitudesIntervencion.DataSource = null;
                gvSollicitudesIntervencion.DataBind();
            }
        }

        private void ComboVisitas(int ciudadanoId)
        {
            BPVisita oBPVisita = new BPVisita();

            oBPVisita.ENTVisita.UsuarioIdInsert = ciudadanoId;
            oBPVisita.SelectVisitaCiudadano();

            if (oBPVisita.ErrorId == 0)
            {
                if (oBPVisita.ENTVisita.dsResponse.Tables[0].Rows.Count > 0)
                {
                    gvVisitasCEDH.DataSource = oBPVisita.ENTVisita.dsResponse;
                    gvVisitasCEDH.DataBind();
                }
                else
                {
                    gvVisitasCEDH.DataSource = null;
                    gvVisitasCEDH.DataBind();
                }
            }
            else
            {
                gvVisitasCEDH.DataSource = null;
                gvVisitasCEDH.DataBind();
            }
        }

        #endregion

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Application/WebApp/Private/Operation/opeBusquedaCiudadano.aspx");
        }

        protected void gvSollicitudesIntervencion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");
                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvSollicitudesIntervencion_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableSolicitudes = null;
            DataView ViewSolicitudes = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableSolicitudes = utilFunction.ParseGridViewToDataTable(gvSollicitudesIntervencion, false);
                ViewSolicitudes = new DataView(TableSolicitudes);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewSolicitudes.Sort = hddSort.Value;

                //Vaciar datos
                gvSollicitudesIntervencion.DataSource = ViewSolicitudes;
                gvSollicitudesIntervencion.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvVisitasCEDH_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over';");
                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void gvVisitasCEDH_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable TableVisitas = null;
            DataView ViewVisitas = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableVisitas = utilFunction.ParseGridViewToDataTable(gvVisitasCEDH, false);
                ViewVisitas = new DataView(TableVisitas);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewVisitas.Sort = hddSort.Value;

                //Vaciar datos
                gvVisitasCEDH.DataSource = ViewVisitas;
                gvVisitasCEDH.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

    }
}
