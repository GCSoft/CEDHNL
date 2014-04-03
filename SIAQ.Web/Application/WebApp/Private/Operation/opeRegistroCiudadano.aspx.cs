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
    public partial class opeRegistroCiudadano : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            ComboEscolaridad();
            ComboEstadoCivil();
            ComboSexo();
            ComboOcupacion();
            ComboFormaContacto();
            ComboNacionalidad();
            ComboPaises();
            ComboPaisesOrigen();
        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades
        #endregion

        #region Eventos

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Funciones

        private void ComboEscolaridad()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboEscolaridad();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEscolaridad.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEscolaridad.DataTextField = "Nombre";
                        ddlEscolaridad.DataValueField = "EscolaridadId";
                        ddlEscolaridad.DataBind();
                    }
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

        private void ComboEstadoCivil()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboEstadoCivil();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEstadoCivil.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEstadoCivil.DataTextField = "Nombre";
                        ddlEstadoCivil.DataValueField = "EstadoCivilId";
                        ddlEstadoCivil.DataBind();
                    }
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

        private void ComboSexo()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboSexo();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlSexo.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlSexo.DataTextField = "Nombre";
                        ddlSexo.DataValueField = "SexoId";
                        ddlSexo.DataBind();
                    }
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

        private void ComboOcupacion()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboOcupacion();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlOcupacion.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlOcupacion.DataTextField = "Nombre";
                        ddlOcupacion.DataValueField = "OcupacionId";
                        ddlOcupacion.DataBind();
                    }
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

        private void ComboFormaContacto()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.SelectComboFormaContacto();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlFormaEnterarse.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlFormaEnterarse.DataTextField = "Nombre";
                        ddlFormaEnterarse.DataValueField = "FormaContactoId";
                        ddlFormaEnterarse.DataBind();
                    }
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

        private void ComboColonia()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.CiudadId = Convert.ToInt32(ddlCiudad.SelectedValue);
                oBPCiudadano.SelectComboColonia();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlColonia.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlColonia.DataTextField = "Nombre";
                        ddlColonia.DataValueField = "ColoniaId";
                        ddlColonia.DataBind();
                    }
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

        private void ComboNacionalidad()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oENTResponse = oBPCiudadano.SelectComboNacionalidad(oENTCiudadano);
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ddlNacionalidad.DataSource = oENTResponse.dsResponse.Tables[1];
                ddlNacionalidad.DataTextField = "Nombre";
                ddlNacionalidad.DataValueField = "NacionalidadId";
                ddlNacionalidad.DataBind();

                ddlNacionalidad.Items.Insert(0, new ListItem("[Seleccione]", "0"));
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

        private void ComboPaises()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oENTResponse = oBPCiudadano.SelectComboPais(oENTCiudadano);
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ddlPais.DataSource = oENTResponse.dsResponse.Tables[1];
                ddlPais.DataTextField = "Nombre";
                ddlPais.DataValueField = "PaisId";
                ddlPais.DataBind();

                ddlPais.Items.Insert(0, new ListItem("[Seleccione]", "0"));
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

        private void ComboPaisesOrigen()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTResponse oENTResponse = new ENTResponse();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oENTResponse = oBPCiudadano.SelectComboPais(oENTCiudadano);
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                ddlPaisOrigen.DataSource = oENTResponse.dsResponse.Tables[1];
                ddlPaisOrigen.DataTextField = "Nombre";
                ddlPaisOrigen.DataValueField = "PaisId";
                ddlPaisOrigen.DataBind();

                ddlPaisOrigen.Items.Insert(0, new ListItem("[Seleccione]", "0"));
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

        private void ComboEstados()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.PaisId = Convert.ToInt32(ddlPais.SelectedValue);
                oBPCiudadano.SelectComboEstado();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEstado.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEstado.DataTextField = "Nombre";
                        ddlEstado.DataValueField = "EstadoId";
                        ddlEstado.DataBind();
                    }
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

        private void ComboEstadosOrigen()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.PaisId = Convert.ToInt32(ddlPaisOrigen.SelectedValue);
                oBPCiudadano.SelectComboEstado();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlEstadoOrigen.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlEstadoOrigen.DataTextField = "Nombre";
                        ddlEstadoOrigen.DataValueField = "EstadoId";
                        ddlEstadoOrigen.DataBind();
                    }
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

        private void ComboCiudades()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.EstadoId = Convert.ToInt32(ddlEstado.SelectedValue);
                oBPCiudadano.SelectComboCiudad();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlCiudad.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlCiudad.DataTextField = "Nombre";
                        ddlCiudad.DataValueField = "CiudadId";
                        ddlCiudad.DataBind();
                    }
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

        private void ComboCiudadesOrigen()
        {
            BPCiudadano oBPCiudadano = new BPCiudadano();
            ENTCiudadano oENTCiudadano = new ENTCiudadano();

            try
            {
                oBPCiudadano.ENTCiudadano.EstadoId = Convert.ToInt32(ddlEstadoOrigen.SelectedValue);
                oBPCiudadano.SelectComboCiudad();

                if (oBPCiudadano.ErrorId == 0)
                {
                    if (oBPCiudadano.ENTCiudadano.ResultData.Tables[0].Rows.Count > 0)
                    {
                        ddlCiudadOrigen.DataSource = oBPCiudadano.ENTCiudadano.ResultData;
                        ddlCiudadOrigen.DataTextField = "Nombre";
                        ddlCiudadOrigen.DataValueField = "CiudadId";
                        ddlCiudadOrigen.DataBind();
                    }
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

        #endregion

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboEstados();
                ComboCiudades();
                ComboColonia();
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

        protected void ddlPaisOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboEstadosOrigen();
                ComboCiudadesOrigen();
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

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboCiudades();
                ComboColonia();
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

        protected void ddlEstadoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboCiudadesOrigen();
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

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboColonia();
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

    }
}