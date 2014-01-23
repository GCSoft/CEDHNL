/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre: wucMenu
' Autor:  GCSoft - Web Project Creator BETA 1.0
' Fecha:  21-Octubre-2013
'
' Descripción:
'           Menu principal de la aplicación.
'			
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using AjaxControlToolkit;
using GCSoft.Utilities.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Include.WebUserControls
{
   public partial class wucMenu : System.Web.UI.UserControl
   {
     
		// Utilerias
		Function utilFunction = new Function();


		// Rutinas de la página

		private void createUserMenu(){
			ENTSession oENTSession = new ENTSession();
			DataSet dsMenu;
			String sIDMenu = "";

			AccordionPane oAccordionPane;
			Label lblAccordionHeader;
			HtmlAnchor anchContent;
			Panel pnlContent;
			HiddenField hddContentPageName;

			try
			{

				// Obtener sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Secciones de Menú
				foreach (DataRow drMenu in oENTSession.tblMenu.Rows){

					// Obtener el id menu actual
					sIDMenu = drMenu["idMenu"].ToString();

					// Nuevo Panel
					oAccordionPane = new AccordionPane();
					oAccordionPane.ID = "apnl" + sIDMenu;

					// Header
					lblAccordionHeader = new Label();
					lblAccordionHeader.Text = drMenu["sNombremenu"].ToString();
					oAccordionPane.HeaderContainer.Controls.Add(lblAccordionHeader);

					// Content
					foreach (DataRow drSubMenu in oENTSession.tblSubMenu.Select("idMenu = " + sIDMenu, "sNombreSubMenu")){

						// Nuevo panel
						pnlContent = new Panel();
						pnlContent.ID = "pnl" + drSubMenu["idSubMenu"].ToString();
						pnlContent.CssClass = "MenuItem";

						// Nuevo Anchor
						anchContent = new HtmlAnchor();
						anchContent.Title = drSubMenu["sDescripcion"].ToString();
						anchContent.HRef = this.ResolveUrl(drSubMenu["sURL"].ToString());
						anchContent.InnerHtml = (char)187 + " " + drSubMenu["sNombreSubMenu"].ToString();

						// Nuevo campo oculto (nombre de página)
						hddContentPageName = new HiddenField();
						hddContentPageName.ID = "hdd" + drSubMenu["idSubMenu"].ToString();
						hddContentPageName.Value = drSubMenu["sPageName"].ToString();

						// Agregar contenido al Panel
						pnlContent.Controls.Add(anchContent);
						pnlContent.Controls.Add(hddContentPageName);

						// Agregar contenido al Acordeón
						oAccordionPane.ContentContainer.Controls.Add(pnlContent);
					}

					// Agregar Pane al Acordeón
					this.acrdMenu.Panes.Add(oAccordionPane);
				}

				// DataSet en ViewState
				dsMenu = new DataSet();
				dsMenu.Tables.Add(oENTSession.tblMenu.Copy());
				dsMenu.Tables.Add(oENTSession.tblSubMenu.Copy());
				this.ViewState["dsMenu"] = dsMenu;

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
			}
		}

		private void recoveryUserMenu(){
			DataSet dsMenu;
			String sIDMenu = "";

			AccordionPane oAccordionPane;
			Label lblAccordionHeader;
			HtmlAnchor anchContent;
			Panel pnlContent;
			HiddenField hddContentPageName;

			try
			{

				// Recuperar menu
				dsMenu = (DataSet)this.ViewState["dsMenu"];

				// Secciones de Menú
				foreach (DataRow drMenu in dsMenu.Tables[0].Rows){

					// Obtener el id menu actual
					sIDMenu = drMenu["idMenu"].ToString();

					// Nuevo Panel
					oAccordionPane = new AccordionPane();
					oAccordionPane.ID = "apnl" + sIDMenu;

					// Header
					lblAccordionHeader = new Label();
					lblAccordionHeader.Text = drMenu["sNombremenu"].ToString();
					oAccordionPane.HeaderContainer.Controls.Add(lblAccordionHeader);

					// Content
					foreach (DataRow drSubMenu in dsMenu.Tables[1].Select("idMenu = " + sIDMenu, "sNombreSubMenu")){

						// Nuevo panel
						pnlContent = new Panel();
						pnlContent.ID = "pnl" + drSubMenu["idSubMenu"].ToString();
						pnlContent.CssClass = "MenuItem";

						// Nuevo Anchor
						anchContent = new HtmlAnchor();
						anchContent.Title = drSubMenu["sDescripcion"].ToString();
						anchContent.HRef = this.ResolveUrl(drSubMenu["sURL"].ToString());
						anchContent.InnerHtml = (char)187 + " " + drSubMenu["sNombreSubMenu"].ToString();

						// Nuevo campo oculto (nombre de página)
						hddContentPageName = new HiddenField();
						hddContentPageName.ID = "hdd" + drSubMenu["idSubMenu"].ToString();
						hddContentPageName.Value = drSubMenu["sPageName"].ToString();

						// Agregar contenido al Panel
						pnlContent.Controls.Add(anchContent);
						pnlContent.Controls.Add(hddContentPageName);

						// Agregar contenido al Acordeón
						oAccordionPane.ContentContainer.Controls.Add(pnlContent);
					}

					// Agregar Pane al Acordeón
					this.acrdMenu.Panes.Add(oAccordionPane);
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
			}
		}

		private void selectMenuOption(){
			Panel pnlContent;
			HiddenField hddContentPageName;

			String sCurrentSubMenuID = "";
			String sPage = "";

			Int32 iAccordionIndex = 0;

			try
			{

				// Página actual
				sPage = this.Request.Url.AbsolutePath;
				sPage = sPage.Split(new char[] { '/' })[sPage.Split(new char[] { '/' }).Length - 1];

				// Paneles
				foreach (AccordionPane oAccordionPane in this.acrdMenu.Panes){

					// Controles dentro de cada panel
					foreach (Control oCurrentControl in oAccordionPane.ContentContainer.Controls){

						pnlContent = (Panel)oCurrentControl;

						sCurrentSubMenuID = pnlContent.ID.Replace("pnl", "");
						hddContentPageName = (HiddenField)pnlContent.FindControl("hdd" + sCurrentSubMenuID);

						// Validación de la página actual
						if (hddContentPageName.Value == sPage){
							pnlContent.CssClass = "MenuItemSelected";
							this.acrdMenu.SelectedIndex = iAccordionIndex;
							return;
						}

					}

					// Indice del acordeón
					iAccordionIndex = iAccordionIndex + 1;

				}

				// Seleccionar primer opción por default
				this.acrdMenu.SelectedIndex = 0;


			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + utilFunction.JSClearText(ex.Message) + "');", true);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){

			// Validación de menu creado
			if (this.ViewState["dsMenu"] == null){
				createUserMenu();
			}else{
				recoveryUserMenu();
			}

			// Opción seleccionada
			selectMenuOption();

		}

   }
}
