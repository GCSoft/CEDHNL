using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCSoft.Utilities.Common;
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeAgregarIndicadores : System.Web.UI.Page
    {
        Function utilFunction = new Function();


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
            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }
        #endregion

        #region
            private void PageLoad()
            {
                int SolicitudId = 0;

                if (!this.Page.IsPostBack)
                {
                    try
                    {
                        SolicitudId = int.Parse(Request.QueryString["s"].ToString());

						this.SolicitudIdHidden.Value = SolicitudId.ToString();

						SelectIndicadores(this.SolicitudIdHidden.Value);

						// consultar la carátula
						SelectSolicitud();

                    }
                    catch (Exception Exception)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(Exception.Message) + "', 'Fail', true);", true);
                    }
                }
            }

            private void SelectIndicadores(string SolicitudId)
            {

            }
        #endregion

			protected void btnGuardar_Click(object sender, EventArgs e)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Grupos minoritarios asociados con éxito', 'Success', false);", true);
			}

			protected void btnRegresar_Click(object sender, EventArgs e)
			{
				Response.Redirect("opeDetalleSolicitud.aspx?s=" + this.SolicitudIdHidden.Value, false);
			}


    }
}