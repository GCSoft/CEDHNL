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

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeDiligencias : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) { return; }

            ComboFuncionariosEjecuta();
        }

        #region Atributos

        Function utilFunction = new Function();

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        #region "Grid diligencias"


        protected void gvDiligencias_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvDiligencias_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDiligencias_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        #endregion

        #region "Botones

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region Funciones

        private void ComboFuncionariosEjecuta()
        {
            BPFuncionario oBPFuncionario = new BPFuncionario();

            oBPFuncionario.SelectFuncionarioVistaduria();

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

        #endregion

    }
}