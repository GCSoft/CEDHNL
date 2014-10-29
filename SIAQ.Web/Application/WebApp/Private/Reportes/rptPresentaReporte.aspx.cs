using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

// Referencias manuales
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using GCUtility.Function;

namespace SIAQ.Web.Application.WebApp.Private.Reportes
{
    public partial class rptPresentaReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TipoReporte = Request.QueryString["TipoReporte"];
            DateTime FechaInicial = System.DateTime.Parse(Request.QueryString["FechaInicial"]);
            DateTime FechaFinal = System.DateTime.Parse(Request.QueryString["FechaFinal"]);
            int EstatusId = Int32.Parse(Request.QueryString["EstatusId"]);
            
            PresentaReporte(TipoReporte, FechaInicial, FechaFinal, EstatusId);
        }

        #region Rutinas del programador

        public void PresentaReporte(string TipoReporte, DateTime FechaInicial, DateTime FechaFinal, int EstatusId)
        {
            ENTResponse oResponse = new ENTResponse();
            System.Data.DataSet ds = new System.Data.DataSet();

            try
            {
                switch (TipoReporte)
                {
                    case "rptVisGeneral":
                        
                        // Declara Entidad y Buiseness
                        ENTVisitaduria entGVis = new ENTVisitaduria();
                        BPVisitaduria bssGVis = new BPVisitaduria();

                        // Asigna valores
                        entGVis.FechaDesde = FechaInicial.ToString("dd-MM-yyyy");
                        entGVis.FechaHasta = FechaFinal.ToString("dd-MM-yyyy");
                        entGVis.EstatusId = EstatusId;

                        // Consulta reporte            
                        oResponse = bssGVis.RptGeneralVisitaduria(entGVis);

                        rptVisGeneral rptCR = new rptVisGeneral();
                        rptCR.SetDataSource(ds.Tables[1]);
                        crViewer.ReportSource = rptCR;
                        break;

                    case "Expedientes":
                        //// Declara Entidad y Buiseness
                        //ENTVisitaduria entGExp = new ENTVisitaduria();
                        //BPVisitaduria bssGVis = new BPVisitaduria();

                        //// Asigna valores
                        //entGVis.FechaDesde = FechaInicial.ToString("dd-MM-yyyy");
                        //entGVis.FechaHasta = FechaFinal.ToString("dd-MM-yyyy");
                        //entGVis.EstatusId = EstatusId;

                        //// Consulta reporte            
                        //bss.SelectRptQuejas(ref ds, ent);

                        //rptVisGeneral rptCREstatusExpediente = new rptVisGeneral();
                        //rptCREstatusExpediente.SetDataSource(ds.Tables[1]);
                        //crViewer.ReportSource = rptCREstatusExpediente;
                        break;

                    case "Solicitudes":
                        // Consulta reporte            
                        //bss.SelectRptQuejas(ref ds, ent);

                        //rptVisGeneral rptCRSolicitude = new rptVisGeneral();
                        //rptCRSolicitude.SetDataSource(ds.Tables[1]);
                        //crViewer.ReportSource = rptCRSolicitude;
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