/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicDetalleAtencion
' Autor:	Ruben.Cobos
' Fecha:	18-Junio-2014
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
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using System.Data;


namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class VicDetalleAtencion : System.Web.UI.Page
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
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

		void SelectAtencion() {
			BPAtencion oBPAtencion = new BPAtencion();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTAtencion.AtencionId = Int32.Parse(this.hddAtencionId.Value);

				// Transacción
				oENTResponse = oBPAtencion.SelectAtencion_Detalle(oENTAtencion);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddEstatusId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusId"].ToString();
				this.hddFuncionarioId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioId"].ToString();

				// Formulario
				this.AtencionNumeroFolio.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AtencionNumeroFolio"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Ciudadanos"].ToString();
				this.AtencionNumeroOficio.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AtencionNumeroOficio"].ToString();
				this.AreaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Area"].ToString();
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.DoctorLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();

				this.FechaAtencionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAtencion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.UltimaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.DictamenMedicoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoDictamenNombre"].ToString();
				this.LugarRevisionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarAtencionNombre"].ToString();

				// Grid
				this.gvAtencionDetalle.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvAtencionDetalle.DataBind();

				// Documentos
				if (oENTResponse.dsResponse.Tables[3].Rows.Count == 0){

					this.SinDocumentoLabel.Text = "<br /><br />No hay documentos anexados al Dictámen";
				}else{

					this.SinDocumentoLabel.Text = "";
					this.dlstDocumentoList.DataSource = oENTResponse.dsResponse.Tables[3];
					this.dlstDocumentoList.DataBind();
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetPermisosGenerales(Int32 idRol) {
			try
            {

				// Permisos por rol
				switch (idRol){

					case 1:	// System Administrator
						this.pnlInformacion.Visible = true;
						this.pnlAsignarDoctor.Visible = true;
						this.pnlDictamenMedico.Visible = true;
						this.pnlAgregarDocumento.Visible = true;
						this.pnlVistaPrevia.Visible = true;
						this.pnlEnviarAtencion.Visible = true;
						break;

					case 2:	// Administrador
						this.pnlInformacion.Visible = true;
						this.pnlAsignarDoctor.Visible = true;
						this.pnlDictamenMedico.Visible = true;
						this.pnlAgregarDocumento.Visible = true;
						this.pnlVistaPrevia.Visible = true;
						this.pnlEnviarAtencion.Visible = true;
						break;

					case 13:	// Atención a Víctimas - Secretaria
						this.pnlInformacion.Visible = true;
						this.pnlAsignarDoctor.Visible = true;
						this.pnlDictamenMedico.Visible = false;
						this.pnlAgregarDocumento.Visible = false;
						this.pnlVistaPrevia.Visible = true;
						this.pnlEnviarAtencion.Visible = false;
						break;

					case 14:	// Atención a Víctimas - Doctor
						this.pnlInformacion.Visible = true;
						this.pnlAsignarDoctor.Visible = false;
						this.pnlDictamenMedico.Visible = true;
						this.pnlAgregarDocumento.Visible = true;
						this.pnlVistaPrevia.Visible = true;
						this.pnlEnviarAtencion.Visible = true;
						break;

					case 15:	// Atención a Víctimas - Director
						this.pnlInformacion.Visible = true;
						this.pnlAsignarDoctor.Visible = true;
						this.pnlDictamenMedico.Visible = false;
						this.pnlAgregarDocumento.Visible = false;
						this.pnlVistaPrevia.Visible = true;
						this.pnlEnviarAtencion.Visible = false;
						break;

					default:
						this.pnlInformacion.Visible = false;
						this.pnlAsignarDoctor.Visible = false;
						this.pnlDictamenMedico.Visible = false;
						this.pnlAgregarDocumento.Visible = false;
						this.pnlVistaPrevia.Visible = false;
						this.pnlEnviarAtencion.Visible = false;
						break;

				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		void SetPermisosParticulares(Int32 idRol, Int32 FuncionarioId) {
			try
            {

				// Si es Doctor pero el expediente no está asignado a él no lo podrá operar
				if (idRol == 14 && Int32.Parse(this.hddFuncionarioId.Value) != FuncionarioId) {
					this.pnlDictamenMedico.Visible = false;
					this.pnlAgregarDocumento.Visible = false;
					this.pnlEnviarAtencion.Visible = false;
				}

				// Si el expediente está en estatus de confirmación de cierre o cerrado no se podrá operar
				if ( Int32.Parse(this.hddEstatusId.Value) == 20 || Int32.Parse(this.hddEstatusId.Value) == 21 ){
					this.pnlAsignarDoctor.Visible = false;
					this.pnlDictamenMedico.Visible = false;
					this.pnlAgregarDocumento.Visible = false;
					this.pnlEnviarAtencion.Visible = false;
				}

            }catch (Exception ex){
				throw(ex);
            }
		}



		//  Eventos de la página

        protected void Page_Load(object sender, EventArgs e){
            ENTSession SessionEntity = new ENTSession();
			String sKey;

            try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener AtencionId
				this.hddAtencionId.Value = sKey.ToString().Split(new Char[] { '|' })[0];

                // Obtener Sender
				this.SenderId.Value = sKey.ToString().Split(new Char[] { '|' })[1];

                switch (this.SenderId.Value){
                    case "1":
						this.Sender.Value = "VicBusquedaAtenciones.aspx";
                        break;

                    case "2":
						this.Sender.Value = "VicListadoAtenciones.aspx";
                        break;

					case "3":
						this.Sender.Value = "VicListadoAtencionesEnProceso.aspx";
						break;

                    default:
                        this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
                        return;
                }

                // Obtener sesión
                SessionEntity = (ENTSession)Session["oENTSession"];

                // Consultar detalle de expediente de atención a víctimas
                SelectAtencion();

                // Seguridad
                SetPermisosGenerales(SessionEntity.idRol);
                SetPermisosParticulares(SessionEntity.idRol, SessionEntity.FuncionarioId);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e){
            Response.Redirect(this.Sender.Value);
        }

        protected void dlstDocumentoList_ItemDataBound(Object sender, DataListItemEventArgs e){
            Label DocumentoLabel;
            Image DocumentoImage;
            DataRowView DataRow;

			String DocumentoId = "";
			String sKey = "";

            try
            {

                // Validación de que sea Item 
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

                // Obtener controles
                DocumentoImage = (Image)e.Item.FindControl("DocumentoImage");
                DocumentoLabel = (Label)e.Item.FindControl("DocumentoLabel");
                DataRow = (DataRowView)e.Item.DataItem;

				// Id del documento
				DocumentoId = DataRow["DocumentoId"].ToString();
				sKey = gcEncryption.EncryptString(DocumentoId, true);

                // Configurar imagen
				DocumentoLabel.Text = DataRow["NombreDocumentoCorto"].ToString();

				DocumentoImage.ImageUrl = "~/Include/Image/Icon/" + DataRow["Icono"].ToString();
				DocumentoImage.ToolTip = DataRow["NombreDocumento"].ToString();
                DocumentoImage.Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                DocumentoImage.Attributes.Add("onmouseout", "this.style.cursor='auto'");
				DocumentoImage.Attributes.Add("onclick", "window.open('" + System.Configuration.ConfigurationManager.AppSettings["Application.Url.Handler"].ToString() + "ObtenerRepositorio.ashx?key=" + sKey + "');");

            }catch (Exception ex){
                throw (ex);
            }
        }

        protected void gvAtencionDetalle_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvAtencionDetalle_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvAtencionDetalle, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


        // Opciones de Menu (en orden de aparación)

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
            try
            {

                // Actualizar el expediente
                SelectAtencion();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		//protected void AgregrarInformacionButton_Click(object sender, ImageClickEventArgs e){
		//    String sKey = "";

		//    try
		//    {

		//        // Llave encriptada
		//        sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
		//        sKey = gcEncryption.EncryptString(sKey, true);
		//        this.Response.Redirect("vicAgregrarInformacion.aspx?key=" + sKey, false);

		//    }catch (Exception ex){
		//        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
		//    }
		//}

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("vicAsignarDoctor.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void DictamenMedicoButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("VicDictamenMedico.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
        }

		protected void AgregarDocumentoButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("VicAgregarDocumento.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void ImprimirButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("vicImprimirAtencion.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void EnviarButton_Click(object sender, ImageClickEventArgs e){
			String sKey = "";

			try
			{

				// Llave encriptada
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("vicEnviarAtencion.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

    }
}