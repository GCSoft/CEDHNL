using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// Referencias manuales
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using GCUtility.Function;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

using SIAQ.Web.Application.WebApp.Private.Reportes.DataSet;

namespace SIAQ.Web.Application.WebApp.Private.Reportes
{
    public partial class rptPresentaReporte : System.Web.UI.Page
    {

        ConnectionInfo connectionInfo = new ConnectionInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            string TipoReporte = Request.QueryString["TipoReporte"];
            DateTime FechaInicial = System.DateTime.Parse(Request.QueryString["FechaInicial"]);
            DateTime FechaFinal = System.DateTime.Parse(Request.QueryString["FechaFinal"]);
            
            PresentaReporte(TipoReporte, FechaInicial, FechaFinal);
        }

        #region Rutinas del programador

        public void PresentaReporte(string TipoReporte, DateTime FechaInicial, DateTime FechaFinal)
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
                        entGVis.FechaDesde = FechaInicial.ToString("yyyy-MM-dd");
                        entGVis.FechaHasta = FechaFinal.ToString("yyyy-MM-dd");

                        // Consulta reporte            
                        oResponse = bssGVis.RptGeneralVisitaduria(entGVis);

                        oResponse.dsResponse.Tables[0].TableName = "tblEncabezado";
                        oResponse.dsResponse.Tables[1].TableName = "tblExpPeriodo_I";
                        oResponse.dsResponse.Tables[2].TableName = "tblExpMedidaCautelar_II";
                        oResponse.dsResponse.Tables[3].TableName = "tblExpSolicitudGestion_III";
                        oResponse.dsResponse.Tables[4].TableName = "tblExpVisitaduriaGeneral_IV";
                        oResponse.dsResponse.Tables[5].TableName = "tblExpConcluidos_V";
                        oResponse.dsResponse.Tables[6].TableName = "tblExpNivelAutoridadVI";
                        oResponse.dsResponse.Tables[7].TableName = "tblPersonasAtendidasVII";
                        oResponse.dsResponse.Tables[8].TableName = "tblEntrevistas_VIII";
                        oResponse.dsResponse.Tables[9].TableName = "tblSupervisores_IX";
                        oResponse.dsResponse.Tables[10].TableName = "tblResultados_X";

                        rptVisGeneral rptCR = new rptVisGeneral();
                        rptCR.SetDataSource(oResponse.dsResponse);

                        // Presenta reporte
                        crViewer.ReportSource = rptCR;
                        break;

                    case "rptEstadisticaPresidencia":
                        // Declara Entidad y Buiseness
                        ENTVisitaduria entEstadisticaPresindecia = new ENTVisitaduria();
                        BPVisitaduria bssEstadisticaPresindecia = new BPVisitaduria();

                        // Asigna valores
                        entEstadisticaPresindecia.FechaDesde = FechaInicial.ToString("yyyy-MM-dd");
                        entEstadisticaPresindecia.FechaHasta = FechaFinal.ToString("yyyy-MM-dd");

                        // Consulta reporte            
                        oResponse = bssEstadisticaPresindecia.RptGeneralVisitaduria(entEstadisticaPresindecia);

                        //rptVisGeneral rptCREstadisticaPresidencia = new rptVisGeneral();
                        rptEstadisticaPresidencia rptCREstadisticaPresidencia = new rptEstadisticaPresidencia();
                        rptCREstadisticaPresidencia.SetDataSource(oResponse.dsResponse);
                        //SetDBLogonForReport(connectionInfo);
                        crViewer.ReportSource = rptCREstadisticaPresidencia;
                        break;

                    case "rptIntegralVictimas":
                        // Declara Entidad y Buiseness
                        ENTVisitaduria entIntegralVictimas = new ENTVisitaduria();
                        BPVisitaduria bssIntegralVictimas = new BPVisitaduria();

                        // Asigna valores
                        entIntegralVictimas.FechaDesde = FechaInicial.ToString("yyyy-MM-dd");
                        entIntegralVictimas.FechaHasta = FechaFinal.ToString("yyyy-MM-dd");

                        // Consulta reporte            
                        oResponse = bssIntegralVictimas.RptGeneralVisitaduria(entIntegralVictimas);

                        //rptEstadisticaPresidencia rptCR = new rptEstadisticaPresidencia();
                        rptIntegralVictimas rptCRIntegralVictimas = new rptIntegralVictimas();
                        rptCRIntegralVictimas.SetDataSource(oResponse.dsResponse);
                        crViewer.ReportSource = rptCRIntegralVictimas;
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