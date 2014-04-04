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
        }

        #region Atributos
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

        #endregion

    }
}
