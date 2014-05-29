using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segDiligencia : System.Web.UI.Page
	{
		#region Atributos

		Function utilFunction = new Function();
		protected string RecomendacionId;
		protected string NumeroRecomendacion;

		#endregion

		#region Propiedades

		#endregion

		#region Eventos

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Page.IsPostBack) { return; }

			RecomendacionId = GetRawQueryParameter("recId");
			NumeroRecomendacion = GetRawQueryParameter("numRec");

			hdnRecomendacionId.Value = RecomendacionId;

			ComboFuncionariosEjecuta();
			ComboLugarDiligencia();
			ComboTipoDiligencia();
			GridDiligencias(RecomendacionId);
			LlenarDetalle(NumeroRecomendacion);
		}

		#region "Grid diligencias"

		protected void gvDiligenciasRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			string ExpedienteId = string.Empty;
			string DiligenciaId = string.Empty;
			int intRow = 0;

			try
			{
				string sCommandName = e.CommandName.ToString();

				if (sCommandName == "Sort") { return; }

				//Fila 
				intRow = Convert.ToInt32(e.CommandArgument.ToString());

				// ExpedienteId 
				ExpedienteId = hdnRecomendacionId.Value;
				if (String.IsNullOrEmpty(ExpedienteId)) { ExpedienteId = GetRawQueryParameter("recId"); }
				DiligenciaId = gvDiligenciasRecomendacion.DataKeys[intRow]["DiligenciaId"].ToString();

				switch (sCommandName)
				{
					case "Editar":
						MostrarDatosEdicion(ExpedienteId, DiligenciaId);
						break;

					case "Borrar":
						EliminarDiligencia(ExpedienteId, DiligenciaId);
						break;
				}

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		protected void gvDiligenciasRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String sImagesAttributes = "";
			String sToolTip = "";
			String sNumeroDiligencia = "";

			String sImagesAttributesDelete = "";
			String sToolTipDelete = "";

			try
			{
				//Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				//Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				sNumeroDiligencia = gvDiligenciasRecomendacion.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

				//Tooltip Edición
				sToolTip = "Editar diligencia [" + sNumeroDiligencia + "]";
				sToolTipDelete = "Eliminar diligencia [" + sNumeroDiligencia + "]";

				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipDelete + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				//Atributos Over
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

				//Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes + sImagesAttributesDelete);

				//Atributos Out
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

				//Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes + sImagesAttributesDelete);
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		protected void gvDiligenciasRecomendacion_Sorting(object sender, GridViewSortEventArgs e)
		{
			DataTable TableRecomendacion = null;
			DataView ViewRecomendacion = null;

			try
			{
				//Obtener DataTable y View del GridView
				TableRecomendacion = utilFunction.ParseGridViewToDataTable(gvDiligenciasRecomendacion, false);
				ViewRecomendacion = new DataView(TableRecomendacion);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				ViewRecomendacion.Sort = hddSort.Value;

				//Vaciar datos
				gvDiligenciasRecomendacion.DataSource = ViewRecomendacion;
				gvDiligenciasRecomendacion.DataBind();

			}
			catch (Exception ex)
			{
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

		#endregion

		#region "Botones

		protected void btnRegresar_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(RecomendacionId))
			{
				RecomendacionId = hdnRecomendacionId.Value;
			}

			Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeDetalleSolicitud.aspx?recId=" + RecomendacionId);
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			string recomendacionId = hdnRecomendacionId.Value;
			if (String.IsNullOrEmpty(recomendacionId)) { recomendacionId = GetRawQueryParameter("recId"); }

			string diligenciaId = hdnDiligenciaId.Value;

			try
			{
				if (String.IsNullOrEmpty(diligenciaId))
				{
					//Agregar
					AgregarDiligencia(recomendacionId);
					GridDiligencias(recomendacionId);
					LimpiarControles();
				}
				else
				{
					//Modificar
					ModificarDiligencia(recomendacionId, diligenciaId);
					GridDiligencias(recomendacionId);
					LimpiarControles();
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

		#endregion

		#region Funciones

		public string GetRawQueryParameter(string parameterName)
		{
			string raw = Request.RawUrl;
			int startQueryIdx = raw.IndexOf('?');
			if (startQueryIdx < 0)
				return null;

			int nameLength = parameterName.Length + 1;
			int startIdx = raw.IndexOf(parameterName + "=", startQueryIdx);
			if (startIdx < 0)
				return null;

			startIdx += nameLength;
			int endIdx = raw.IndexOf('&', startIdx);
			if (endIdx < 0)
				endIdx = raw.Length;

			return raw.Substring(startIdx, endIdx - startIdx);
		}

		private void ComboFuncionariosEjecuta()
		{
			BPFuncionario oBPFuncionario = new BPFuncionario();

			oBPFuncionario.SelectFuncionarioRecomendacion();

			if (oBPFuncionario.ErrorId == 0)
			{
				if (oBPFuncionario.FuncionarioEntity.ResultData.Tables[0].Rows.Count > 0)
				{
					ddlVisitadorEjecuta.DataSource = oBPFuncionario.FuncionarioEntity.ResultData;
					ddlVisitadorEjecuta.DataTextField = "FuncionarioNombre";
					ddlVisitadorEjecuta.DataValueField = "FuncionarioId";
					ddlVisitadorEjecuta.DataBind();
				}
			}
		}

		private void ComboLugarDiligencia()
		{
			BPDiligencia oBPDiligencia = new BPDiligencia();

			oBPDiligencia.SelectLugarDiligencias();

			if (oBPDiligencia.ErrorId == 0)
			{
				if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
				{
					ddlLugarDiligencia.DataSource = oBPDiligencia.DiligenciaEntity.DataResult;
					ddlLugarDiligencia.DataTextField = "Nombre";
					ddlLugarDiligencia.DataValueField = "LugarDiligenciaId";
					ddlLugarDiligencia.DataBind();
				}
			}
		}

		private void ComboTipoDiligencia()
		{
			BPDiligencia oBPDiligencia = new BPDiligencia();

			oBPDiligencia.SelectTipoDiligencias();

			if (oBPDiligencia.ErrorId == 0)
			{
				if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
				{
					ddlTipoDiligencia.DataSource = oBPDiligencia.DiligenciaEntity.DataResult;
					ddlTipoDiligencia.DataTextField = "Nombre";
					ddlTipoDiligencia.DataValueField = "TipoDiligenciaId";
					ddlTipoDiligencia.DataBind();
				}
			}
		}

		private void GridDiligencias(string recomendacionId)
		{
			BPDiligencia oBPDiligencias = new BPDiligencia();

			oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(recomendacionId);
			oBPDiligencias.SelectDiligencias();

			if (oBPDiligencias.ErrorId == 0)
			{

				if (oBPDiligencias.DiligenciaEntity.DataResult.Tables[2].Rows.Count > 0)
				{
					gvDiligenciasRecomendacion.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[2];
					gvDiligenciasRecomendacion.DataBind();
				}
				else
				{
					gvDiligenciasRecomendacion.DataSource = null;
					gvDiligenciasRecomendacion.DataBind();
				}
			}
			else
			{
				gvDiligenciasRecomendacion.DataSource = null;
				gvDiligenciasRecomendacion.DataBind();
			}
		}

		private void LlenarDetalle(string numeroRecomendacion)
		{
			ENTSession oENTSession;

			oENTSession = (ENTSession)this.Session["oENTSession"];


			SolicitudLabel.Text = numeroRecomendacion;
			VisitadorAtiendeLabel.Text = oENTSession.sNombre;
			FechaRegistroLabel.Text = DateTime.Now.ToShortDateString();
		}

		private void AgregarDiligencia(string recomendacionId)
		{
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			ENTSession oENTSession;

			oENTSession = (ENTSession)this.Session["oENTSession"];
			BPDiligencia oBPDiligencia = new BPDiligencia();

			if (ddlVisitadorEjecuta.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
			if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
			if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
			if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
			if (String.IsNullOrEmpty(txtCampo.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
			if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
			if (String.IsNullOrEmpty(txtResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

			try
			{
				//Formulario
				oENTDiligencia.RecomendacionId = Convert.ToInt32(recomendacionId);
				oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
				oENTDiligencia.FechaDiligencia = Convert.ToDateTime(calFecha.DisplayDate);
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.Detalle = txtCampo.Text;
				oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
				oENTDiligencia.Resultado = txtResultado.Text;

				//Transacción
				oENTResponse = oBPDiligencia.InsertDiligenciaRecomendacion(oENTDiligencia);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				//Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page
					, this.GetType()
					, Convert.ToString(Guid.NewGuid())
					, "tinyboxMessage('Diligencia agregada con éxito', 'Success', true);"
					, true);
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void ModificarDiligencia(string recomendacionId, string diligenciaId)
		{
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();


			if (ddlVisitadorEjecuta.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
			if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
			if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
			if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
			if (String.IsNullOrEmpty(txtCampo.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
			if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
			if (String.IsNullOrEmpty(txtResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

			try
			{
				//Formulario
				oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
				oENTDiligencia.RecomendacionId = Convert.ToInt32(recomendacionId);
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
				oENTDiligencia.FechaDiligencia = Convert.ToDateTime(calFecha.DisplayDate);
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.Detalle = txtCampo.Text;
				oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
				oENTDiligencia.Resultado = txtResultado.Text;

				//Transacción
				oENTResponse = oBPDiligencia.UpdateDiligenciaRecomendacion(oENTDiligencia);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				//Mensaje usuario
				ScriptManager.RegisterStartupScript(this.Page
					, this.GetType()
					, Convert.ToString(Guid.NewGuid())
					, "tinyboxMessage('Diligencia modificada con éxito', 'Success', true);"
					, true);

			}

			catch (Exception ex)
			{
				throw (ex);
			}

		}

		private void EliminarDiligencia(string recomendacionId, string diligenciaId)
		{
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();

			try
			{
				oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
				oENTDiligencia.RecomendacionId = Convert.ToInt32(recomendacionId);

				oENTResponse = oBPDiligencia.DeleteDiligenciaRecomendacion(oENTDiligencia);

				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				GridDiligencias(recomendacionId);
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		private void LimpiarControles()
		{
			ddlVisitadorEjecuta.SelectedIndex = 0;
			calFecha.SetCurrentDate();
			ddlTipoDiligencia.SelectedIndex = 0;
			ddlLugarDiligencia.SelectedIndex = 0;
			txtCampo.Text = String.Empty;
			txtSolicitadaPor.Text = String.Empty;
			txtResultado.Text = String.Empty;
			hdnDiligenciaId.Value = String.Empty;

			ddlVisitadorEjecuta.Focus();

		}

		private void MostrarDatosEdicion(string recomendacionId, string diligenciaId)
		{
			BPDiligencia oBPDiligencia = new BPDiligencia();

			oBPDiligencia.DiligenciaEntity.RecomendacionId = Convert.ToInt32(recomendacionId);
			oBPDiligencia.DiligenciaEntity.DiligenciaId = Convert.ToInt32(diligenciaId);

			oBPDiligencia.SelectDetalleDiligenciaRecomendacion();

			if (oBPDiligencia.ErrorId == 0)
			{
				if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
				{
					hdnDiligenciaId.Value = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["DiligenciaId"].ToString();
					ddlVisitadorEjecuta.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FuncionarioEjecuta"].ToString();
					calFecha.SetDate = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FechaDiligencia"].ToString();
					ddlTipoDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["TipoDiligencia"].ToString();
					ddlLugarDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["LugarDiligencia"].ToString();
					txtCampo.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Detalle"].ToString();
					txtSolicitadaPor.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["SolicitadaPor"].ToString();
					txtResultado.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Resultado"].ToString();
				}
			}
		}

		#endregion
	}
}