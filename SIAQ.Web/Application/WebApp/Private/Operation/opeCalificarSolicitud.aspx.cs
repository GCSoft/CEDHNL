using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeCalificarSolicitud : System.Web.UI.Page
    {
        string AllDefault = "-- Seleccione --";
        Function utilFunction = new Function();

        public string _SolicitudId;


		private void SelectSolicitud()
		{
			BPSolicitud SolicitudProcess = new BPSolicitud();
			int SolicitudId;

			// 
			SolicitudId = Int32.Parse(SolicitudIdHidden.Value);

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
				}
			}
			else
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(SolicitudProcess.ErrorDescription) + "', 'Fail', true);", true);
			}
		}

        #region "Events"
            protected void AgregarButton_Click(object sender, EventArgs e)
            {
                AgregarCanalizacion(int.Parse(CanalizadoList.SelectedValue), CanalizadoList.SelectedItem.Text);
            }

            protected void btnCancelar_Click(object sender, EventArgs e)
            {
                string sSolicitudId = SolicitudIdHidden.Value;
                Response.Redirect("~/Application/WebApp/Private/Operation/opeDetalleSolicitud.aspx?s=" + sSolicitudId);
            }

            protected void CalificacionList_SelectedIndexChanged(Object sender, EventArgs e)
            {
                CalificacionListSelectedIndexChanged();
            }

            protected void CierreList_SelectedIndexChanged(Object sender, EventArgs e)
            {
                CierreListSelectedIndexChanged();
            }

            protected void GuardarCalificacionSol_Click(object sender, EventArgs e)
            {
                GuardarCalificacionSol();
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region "Methods"
            private void AgregarCanalizacion(int CanalizacionId, string NombreCanalizacion)
            {
                DataRow Row = null;
                DataTable CanalizacionTable = null;

                if (ValidarCanalizacion(CanalizacionId))
                {
                    CanalizacionTable = utilFunction.ParseGridViewToDataTable(this.CanalizacionGrid, false);

                    Row = CanalizacionTable.NewRow();

                    Row["TipoOrientacionId"] = CanalizacionId;
                    Row["Nombre"] = NombreCanalizacion;

                    CanalizacionTable.Rows.Add(Row);

                    CanalizacionGrid.DataSource = CanalizacionTable;
                    CanalizacionGrid.DataBind();

                    CeldaGrid.Visible = true;
                }
            }

            private void GuardarCalificacionSol()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                if (this.CalificacionList.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Calificacion es obligatorio ', 'Fail', true); focusControl('" + this.CalificacionList.ClientID + "');", true);
                    return;
                }

                if (this.CierreList.SelectedValue != "0")
                {

                    if (this.CanalizadoList.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Fail', true); focusControl('" + this.CanalizadoList.ClientID + "');", true);
                        return;
                    }

                    if (this.FundamentoBox.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('El campo de Canalizado es obligatorio ', 'Fail', true); focusControl('" + this.CanalizadoList.ClientID + "');", true);
                        return;
                    }
                }

                GuardarCalificacionSol(SessionEntity.idUsuario, int.Parse(SolicitudIdHidden.Value), FundamentoBox.Text, int.Parse(CanalizadoList.SelectedValue), int.Parse(CalificacionList.SelectedValue), int.Parse(CierreList.SelectedValue));
            }

            private void GuardarCalificacionSol(int IdUsuarioInsert, int SolicitudId, string Fundamento, int CanalizacionId, int CalificacionId, int CierreOrientacionId)
            {

                BPSolicitud BPSolicitud = new BPSolicitud();

                BPSolicitud.SolicitudEntity.idUsuarioInsert = IdUsuarioInsert;
                BPSolicitud.SolicitudEntity.SolicitudId = SolicitudId;
                BPSolicitud.SolicitudEntity.Fundamento = Fundamento;
                BPSolicitud.SolicitudEntity.CanalizacionId = CanalizacionId;
                BPSolicitud.SolicitudEntity.CalificacionId = CalificacionId;
                BPSolicitud.SolicitudEntity.CierreOrientacionId = CierreOrientacionId;

                BPSolicitud.GuardarCalificacionSol();
                if (BPSolicitud.ErrorId == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('La Calificacion se ha dado de alta correctamente ', 'Success', true);", true);
                    LimpiarCampos();
                    Button1.Enabled = false;
                }
                else
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + BPSolicitud.ErrorDescription + "', 'Error', true);", true);
            }

            private void LimpiarCampos()
            {
                CalificacionList.SelectedIndex = 0;
                CierreList.SelectedIndex = 0;
                CeldaCanalizado.Visible = false;

                CalificacionList.Focus();
            }

            private void CalificacionListSelectedIndexChanged()
            {
                // ToDo: solo se debe mostrar esta información cuando la calificación es una orientación
                if (int.Parse(CalificacionList.SelectedValue) == 3)
                {
                    CeldaCierre.Visible = true;
                }
                else
                {
                    CeldaCierre.Visible = false;
                    CeldaCanalizado.Visible = false;
                }
            }

            private void CierreListSelectedIndexChanged()
            {
                // ToDo: solo se debe mostrar esta información cuando la calificación es una orientación
                if (int.Parse(CalificacionList.SelectedValue) == 3)
                    CeldaCanalizado.Visible = true;
                else
                    CeldaCanalizado.Visible = false;
            }

            private void PageLoad()
            {
                int SolicitudId = 0;

                if (!this.Page.IsPostBack)
                {
                    SelectCalificacion();
                    SelectOrientacion();
                    SelectCanalizacion();

                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

                        _SolicitudId = SolicitudId.ToString();
                        SolicitudLabel.Text = _SolicitudId;
                        SolicitudIdHidden.Value = _SolicitudId;

						// consultar la carátula
						SelectSolicitud();

                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + Exception.Message + "', 'Fail', true);", true);
                    }
                }
            }

            private void SelectCalificacion()
            {
                BPCalificacion BPCalificacion = new BPCalificacion();

                CalificacionList.DataValueField = "CalificacionId";
                CalificacionList.DataTextField = "Nombre";

                CalificacionList.DataSource = BPCalificacion.SelectCalificacion();
                CalificacionList.DataBind();
                CalificacionList.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            private void SelectCanalizacion()
            {
                BPCanalizacion BPCanalizacion = new BPCanalizacion();

                CanalizadoList.DataValueField = "CanalizacionId";
                CanalizadoList.DataTextField = "Nombre";

                CanalizadoList.DataSource = BPCanalizacion.SelectCanalizacion();
                CanalizadoList.DataBind();
                CanalizadoList.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            private void SelectOrientacion()
            {
                BPTipoOrientacion BPTipoOrientacion = new BPTipoOrientacion();

                CierreList.DataValueField = "TipoOrientacionId";
                CierreList.DataTextField = "Nombre";

                CierreList.DataSource = BPTipoOrientacion.SelectTipoOrientacion();
                CierreList.DataBind();
                CierreList.Items.Insert(0, new ListItem(AllDefault, "0"));
            }

            private bool ValidarCanalizacion(int CanalizacionId)
            {
                if (CanalizacionId == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Debe seleccionar una opción de canalización', 'Error', true);", true);
                    return false;
                }

                foreach (GridViewRow Row in CanalizacionGrid.Rows)
                {
                    if (CanalizacionId.ToString() == CanalizacionGrid.DataKeys[Row.DataItemIndex]["TipoOrientacionId"].ToString())
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Esta opción de canalización ya ha sido seleccionada', 'Error', true);", true);
                        return false;
                    }
                }

                return true;
            }
        #endregion
    }
}