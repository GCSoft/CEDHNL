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
            int AreaId = 0;

            // Se asigna la visitaduria a la que corresponde
            if (TipoReporte == "rptVisGeneral") { AreaId = Int32.Parse(Request.QueryString["AreaId"].ToString()); }

            PresentaReporte(TipoReporte, FechaInicial, FechaFinal, AreaId);
        }

        #region Rutinas del programador

        public void PresentaReporte(string TipoReporte, DateTime FechaInicial, DateTime FechaFinal, int AreaId)
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
                        entGVis.AreaId = AreaId;

                        // Consulta reporte            
                        oResponse = bssGVis.RptGeneralVisitaduria(entGVis);

                        //oResponse.dsResponse.Tables[0].TableName = "tblEncabezado";
                        oResponse.dsResponse.Tables[0].TableName = "tblExpPeriodo_I";
                        oResponse.dsResponse.Tables[1].TableName = "tblExpMedidaCautelar_II";
                        oResponse.dsResponse.Tables[2].TableName = "tblExpSolicitudGestion_III";
                        oResponse.dsResponse.Tables[3].TableName = "tblExpVisitaduriaGeneral_IV";
                        oResponse.dsResponse.Tables[4].TableName = "tblExpConcluidos_V";
                        oResponse.dsResponse.Tables[5].TableName = "tblExpNivelAutoridadVI";
                        oResponse.dsResponse.Tables[6].TableName = "tblPersonasAtendidasVII";
                        oResponse.dsResponse.Tables[7].TableName = "tblEntrevistas_VIII";
                        oResponse.dsResponse.Tables[8].TableName = "tblSupervisores_IX";
                        oResponse.dsResponse.Tables[9].TableName = "tblResultados_X";
                        oResponse.dsResponse.Tables[10].TableName = "tblDatosGenerales";

                        rptVisGeneral rptCR = new rptVisGeneral();
                        //rptVisGeneral rptCR = new rptVisGeneral();
                        rptCR.SetDataSource(oResponse.dsResponse);
                        // Presenta reporte
                        crViewer.ReportSource = rptCR;
                        break;

                    case "rptEstadisticaPresidencia":
                        // Declara Entidad y Buiseness
                        ENTQueja entEstadisticaPresindecia = new ENTQueja();
                        BPQueja bssEstadisticaPresindecia = new BPQueja();

                        // Asigna valores
                        entEstadisticaPresindecia.FechaDesde = FechaInicial.ToString("yyyy-MM-dd");
                        entEstadisticaPresindecia.FechaHasta = FechaFinal.ToString("yyyy-MM-dd");

                        // Consulta reporte            
                        oResponse = bssEstadisticaPresindecia.RptEstadisticaPresidencia(entEstadisticaPresindecia);

                        oResponse.dsResponse.Tables[0].TableName = "tblEncabezado_0";
                        oResponse.dsResponse.Tables[1].TableName = "tblEncabezado_I";
                        oResponse.dsResponse.Tables[2].TableName = "tblIntervenciones_II";
                        oResponse.dsResponse.Tables[3].TableName = "tblAsignacionExpediente_III";
                        oResponse.dsResponse.Tables[4].TableName = "tblMecanismoApertura_IV";
                        oResponse.dsResponse.Tables[5].TableName = "tblAsignaionExpQuejas_V";
                        oResponse.dsResponse.Tables[6].TableName = "tblAsignacionExpCautelares_VI";
                        oResponse.dsResponse.Tables[7].TableName = "tblAsignacionExpGestion_VII";
                        oResponse.dsResponse.Tables[8].TableName = "tblQuejasVulnerabilidad_VIII";
                        oResponse.dsResponse.Tables[9].TableName = "tblListadoExpGeneral_IX";
                        oResponse.dsResponse.Tables[10].TableName = "tblListadoCautelares_X";
                        oResponse.dsResponse.Tables[11].TableName = "tblSolicitudesGestion_XI";
                        oResponse.dsResponse.Tables[12].TableName = "tblExpQuejaAutoridad_XII";
                        oResponse.dsResponse.Tables[13].TableName = "tblDiligenciasYEntrevistas_XIII";
                        oResponse.dsResponse.Tables[14].TableName = "tblGrupoPersonasRelacionadas_XIV";
                        oResponse.dsResponse.Tables[15].TableName = "tblOrigenPersonasRelacionadas_XV";
                        oResponse.dsResponse.Tables[16].TableName = "tblDatosGenerales";

                        rptEstadisticaPresidencia rptCREstadisticaPresidencia = new rptEstadisticaPresidencia();
                        rptCREstadisticaPresidencia.SetDataSource(oResponse.dsResponse);
                        crViewer.ReportSource = rptCREstadisticaPresidencia;
                        break;

                    case "rptIntegralVictimas":
                        // Declara Entidad y Buiseness
                        ENTAtencion entIntegralVictimas = new ENTAtencion();
                        BPAtencion bssIntegralVictimas = new BPAtencion();

                        // Asigna valores
                        entIntegralVictimas.FechaDesde = FechaInicial.ToString("yyyy-MM-dd");
                        entIntegralVictimas.FechaHasta = FechaFinal.ToString("yyyy-MM-dd");

                        // Consulta reporte            
                        oResponse = bssIntegralVictimas.RptIntegralVictimas(entIntegralVictimas);

                        oResponse.dsResponse.Tables[0].TableName = "tblDMFPrevioLesiones_I";
                        oResponse.dsResponse.Tables[1].TableName = "tblDMFPrevioLesionesPorGenero_II";
                        oResponse.dsResponse.Tables[2].TableName = "tblDMFPrevioLesionesEstatus_III";
                        oResponse.dsResponse.Tables[3].TableName = "tblDictamenPsicologico_163_IV";
                        oResponse.dsResponse.Tables[4].TableName = "tblDictamenPsicologico_163_PorGenero_V";
                        oResponse.dsResponse.Tables[5].TableName = "tblOpinionMedica_VI";
                        oResponse.dsResponse.Tables[6].TableName = "tblDesgloseDictamen_VII";
                        oResponse.dsResponse.Tables[7].TableName = "tblClimaLaboral_IX";
                        oResponse.dsResponse.Tables[8].TableName = "tblDatosGenerales";

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