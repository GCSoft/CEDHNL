using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visDetalleExpediente : System.Web.UI.Page
    {
        #region "Event"
            protected void AcuerdoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAcuerdoCalifDefinitiva.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void AgregarComentarioButton_Click(object sender, EventArgs e)
            {

            }

            protected void AgregarComentarioLink_Click(object sender, EventArgs e)
            {

            }

            protected void AsignarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeAsignarVisitador.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void CiudadanosGrid_RowCommand(object sender, GridViewCommandEventArgs e)
            {

            }

            protected void CiudadanosGrid_RowDataBound(object sender, GridViewRowEventArgs e)
            {

            }

            protected void CiudadanosGrid_Sorting(object sender, GridViewSortEventArgs e)
            {

            }

            protected void CloseWindowButton_Click(object sender, ImageClickEventArgs e)
            {
                //txtAsuntoSolicitud.Text = String.Empty;
                //pnlAction.Visible = false;
            }

            protected void ComparecenciaPanel_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visComparecencia.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Operation/opeDiligenciaExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void DocumentoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visAgregarDocumento.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void DocumentList_ItemDataBound(Object sender, DataListItemEventArgs e)
            {

            }

            protected void EnviarButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visEnviarExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                PageLoad();
            }

            protected void RecomendacionButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visRecomendacionExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void ResolucionButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visResolucionExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }

            protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Application/WebApp/Private/Visitaduria/visSeguimientoExpediente.aspx?expId=" + ExpedienteIdHidden.Value.ToString());
            }
        #endregion

        #region "Method"
            private void PageLoad()
            {
                if (Page.IsPostBack)
                    return;

                SetPermisos();
            }

            private void SetPermisos()
            {
                ENTSession SessionEntity = new ENTSession();

                SessionEntity = (ENTSession)Session["oENTSession"];

                if (SessionEntity == null)
                    return;

                switch (SessionEntity.idRol)
                {
                    case 1:
                    case 2:
                        AsignarPanel.Visible = true;
                        AcuerdoPanel.Visible = true;
                        DiligenciaPanel.Visible = true;
                        DocumentoPanel.Visible = true;
                        SeguimientoPanel.Visible = true;
                        ComparecenciaPanel.Visible = true;
                        ResolucionPanel.Visible = true;
                        RecomendacionPanel.Visible = true;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = true;
                        break;

                    case 7:
                        AsignarPanel.Visible = true;
                        AcuerdoPanel.Visible = false;
                        DiligenciaPanel.Visible = false;
                        DocumentoPanel.Visible = false;
                        SeguimientoPanel.Visible = false;
                        ComparecenciaPanel.Visible = false;
                        ResolucionPanel.Visible = false;
                        RecomendacionPanel.Visible = false;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = false;
                        break;

                    case 8:
                        AsignarPanel.Visible = false;
                        AcuerdoPanel.Visible = true;
                        DiligenciaPanel.Visible = true;
                        DocumentoPanel.Visible = true;
                        SeguimientoPanel.Visible = true;
                        ComparecenciaPanel.Visible = true;
                        ResolucionPanel.Visible = true;
                        RecomendacionPanel.Visible = true;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = true;
                        break;

                    case 9:
                        AsignarPanel.Visible = true;
                        AcuerdoPanel.Visible = false;
                        DiligenciaPanel.Visible = false;
                        DocumentoPanel.Visible = false;
                        SeguimientoPanel.Visible = false;
                        ComparecenciaPanel.Visible = false;
                        ResolucionPanel.Visible = false;
                        RecomendacionPanel.Visible = false;
                        ImprimirPanel.Visible = true;
                        EnviarPanel.Visible = false;
                        break;

                    default:
                        AsignarPanel.Visible = false;
                        AcuerdoPanel.Visible = false;
                        DiligenciaPanel.Visible = false;
                        DocumentoPanel.Visible = false;
                        SeguimientoPanel.Visible = false;
                        ComparecenciaPanel.Visible = false;
                        ResolucionPanel.Visible = false;
                        RecomendacionPanel.Visible = false;
                        ImprimirPanel.Visible = false;
                        EnviarPanel.Visible = false;
                        break;
                }
            }
        #endregion
    }
}