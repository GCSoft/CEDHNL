/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	opeAgregarAutoridaSenalada
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Modificación:
'           Se reconstruyó la pantalla reutilizando los métodos existentes
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segListadoExpediente : System.Web.UI.Page
	{


		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		private void SelectRecomendaciones(){
			//BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			//BPSeguimientoRecomendacion.SelectRecomendacionSecretaria();

			//if (BPSeguimientoRecomendacion.ErrorId == 0)
			//{
			//    if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count > 0)
			//    {
			//        gvApps.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData;
			//        gvApps.DataBind();
			//    }
			//}
			//else
			//{
			//    gvApps.DataSource = null;
			//    gvApps.DataBind();
			//}

		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
            try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }

                // Obtener Expedientes
				SelectRecomendaciones();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}
	}
}