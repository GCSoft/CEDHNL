using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Reportes
{
    public partial class rptPresentaReporte : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TipoReporte = Request.QueryString["TipoReporte"];
            DateTime FechaInicial = System.DateTime.Parse(Request.QueryString["FechaInicial"]);
            DateTime FechaFinal = System.DateTime.Parse(Request.QueryString["FechaFinal"]);
            int EstatusId = Int32.Parse(Request.QueryString["EstatusId"]);

            PresentaReporte(TipoReporte, FechaInicial, FechaFinal, EstatusId);
        }

        #region Rutinas de la página

        protected void cmdCerrar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Rutinas del programador

        public void PresentaReporte(string TipoReporte, DateTime FechaInicial, DateTime FechaFinal, int EstatusId)
        {
            ENTSolicitud ent = new ENTSolicitud();
            BPSolicitud bss = new BPSolicitud();
            ENTResponse oResponse = new ENTResponse();
            DataSet ds = new DataSet();

            // Asigna valores
            ent.FechaDesde = FechaInicial;
            ent.FechaHasta = FechaFinal;
            ent.EstatusId = EstatusId;

            try
            {
                switch (TipoReporte)
                {
                    case "Quejas":
                        
                        // Consulta reporte            
                        bss.SelectRptQuejas(ref ds, ent);
                        
                        rptEstatusQuejas rptCR = new rptEstatusQuejas();
                        rptCR.SetDataSource(ds.Tables[1]);
                        crViewer.ReportSource = rptCR;
                        break;

                    case "Expedientes":
                        // Consulta reporte            
                        bss.SelectRptQuejas(ref ds, ent);

                        rptEstatusExpediente rptCREstatusExpediente = new rptEstatusExpediente();
                        rptCREstatusExpediente.SetDataSource(ds.Tables[1]);
                        crViewer.ReportSource = rptCREstatusExpediente;
                        break;

                    case "Solicitudes":
                        // Consulta reporte            
                        bss.SelectRptQuejas(ref ds, ent);

                        rptEstatusSolicitud rptCRSolicitude = new rptEstatusSolicitud();
                        rptCRSolicitude.SetDataSource(ds.Tables[1]);
                        crViewer.ReportSource = rptCRSolicitude;
                        break;

                    case "Temas":
                        // Consulta reporte            
                        bss.SelectRptQuejas(ref ds, ent);

                        rptEstatusQuejas rptCRTema = new rptEstatusQuejas();
                        rptCRTema.SetDataSource(ds.Tables[1]);
                        crViewer.ReportSource = rptCRTema;
                        break;
                }
            }
            catch
            { }
            finally
            { }
        }

        #endregion

    }
}