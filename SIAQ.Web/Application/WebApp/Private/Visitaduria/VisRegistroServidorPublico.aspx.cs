/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VisRegistroServidorPublico
' Autor:	Ruben.Cobos
' Fecha:	24-Agosto-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCUtility.Function;
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
	public partial class VisRegistroServidorPublico : System.Web.UI.Page
	{

		// Utilerías
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();
		
		
		// Funciones del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}



		// Rutinas del programador

		void InsertServidorPublico() { 
		}

		void SelectServidorPublico() { 
		}

		void UpdateServidorPublico() { 
		}

		
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 4) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddExpedienteId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId_Level1.Value = sKey.Split(new Char[] { '|' })[1];
				this.SenderId_Level2.Value = sKey.Split(new Char[] { '|' })[2];

				// Obtener hddServidorPublicoId
				this.hddServidorPublicoId.Value = sKey.Split(new Char[] { '|' })[3];

				// Consulta de servidor público
				if (this.hddServidorPublicoId.Value != "0") { SelectServidorPublico(); }
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
		}

		protected void btnAceptar_Click(object sender, EventArgs e){
			ENTExpedienteComparecencia oENTExpedienteComparecencia;
			ENTSession oENTSession = new ENTSession();

			DataRow rowServidorPublico;

			String sKey = "";

			try
            {

				// Determinar el tipo de transacción
				if (this.hddServidorPublicoId.Value != "0"){

					InsertServidorPublico();
				}else {

					UpdateServidorPublico();
				}

				// Çonfiguración y regreso
				switch (this.SenderId_Level2.Value) {
					case "1":

						// Obtener la sesión
						oENTSession = (ENTSession)this.Session["oENTSession"];
						oENTExpedienteComparecencia = (ENTExpedienteComparecencia)oENTSession.Entity;

						// Registrar los cambios
						if ( oENTExpedienteComparecencia.tblServidorPublico.Select("ServidorPublicoId=" + this.hddServidorPublicoId.Value).Length > 0 ){
							oENTExpedienteComparecencia.tblServidorPublico.Rows.Remove(oENTExpedienteComparecencia.tblServidorPublico.Select("ServidorPublicoId=" + this.hddServidorPublicoId.Value)[0]);
						}
						rowServidorPublico = oENTExpedienteComparecencia.tblServidorPublico.NewRow();
						rowServidorPublico["ServidorPublicoId"] = this.hddServidorPublicoId.Value;
						rowServidorPublico["ServidorPublicoNombreCompleto"] = this.txtNombre.Text + " " + this.txtApellidoPaterno.Text + " " + this.txtApellidoMaterno.Text;
						rowServidorPublico["AutoridadNombre"] = this.ddlAutoridadNivel1.SelectedItem.Text;
						if (this.ddlAutoridadNivel2.SelectedIndex > 0) { rowServidorPublico["AutoridadNombre"] = this.ddlAutoridadNivel2.SelectedItem.Text; }
						if (this.ddlAutoridadNivel3.SelectedIndex > 0) { rowServidorPublico["AutoridadNombre"] = this.ddlAutoridadNivel3.SelectedItem.Text; }
						oENTExpedienteComparecencia.tblServidorPublico.Rows.Add(rowServidorPublico);

						// Actualizar la sesión
						oENTSession.Entity = oENTExpedienteComparecencia;
						this.Session["oENTSession"] = oENTSession;

						// Regreso
						sKey = this.hddExpedienteId.Value + "|" + this.SenderId_Level1.Value;
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("visComparecencia.aspx?key=" + sKey, false);
						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				switch (this.SenderId_Level2.Value) {
					case "1":

						sKey = this.hddExpedienteId.Value + "|" + this.SenderId_Level1.Value;
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("visComparecencia.aspx?key=" + sKey, false);
						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtNombre.ClientID + "'); }", true);
            }
		}

	}
}