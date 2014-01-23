/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	xlsArea
' Autor:		Ruben.Cobos
' Fecha:		27-Octubre-2013
'
' Descripción:
'           Crear el reporte de excel de Compañías
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using Syncfusion.XlsIO;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.SysCat.ExcelMaker
{
   public partial class xlsArea : System.Web.UI.Page
   {
     
      // Utilerías
		Encryption utilEncryption = new Encryption();
		
		
		// Funciones del programador
		
		Boolean HasValidParams(String sKey, ref ENTArea oENTArea){
			Boolean ValidParams = true;
			
			try{

				// Query String
				sKey = utilEncryption.DecryptString(sKey, true);

            // Parámetros de consulta (sNombre|tiActivo)
            oENTArea.sNombre  = sKey.Split(new Char[] { '|' })[0].ToString();
            oENTArea.tiActivo = Int16.Parse(sKey.Split(new Char[] { '|' })[1].ToString());

				// Parámetros validos
				ValidParams = true;
				
			}catch(Exception){
				ValidParams = false;
			}
			
			return ValidParams;
		}

		
		// Rutinas del programador
		
		void ExportExcel(DataTable oDataTable, String sSheetName){
			ExcelEngine oEEngine = null;
			IApplication oExcel;
			IWorkbook oWorkbook;
			IWorksheet oSheet;

			Int32 iCol = 0;
			Int32 iRow = 2;

			String sGeneralTitle = "";

			try{

				// Crear Excel
				oEEngine = new ExcelEngine();
				oExcel = oEEngine.Excel;
				oExcel.DefaultVersion = ExcelVersion.Excel2007;
				oWorkbook = oExcel.Workbooks.Create(1);
				oSheet = oWorkbook.Worksheets[0];

				// Formato general de la hoja
				oWorkbook.StandardFont = "Verdana";
				oWorkbook.StandardFontSize = 8;
				oSheet.Name = sSheetName;

				// Título general del reporte
            sGeneralTitle = "SIAQ - Compañías al " + DateTime.Now.ToString("d");

				// Encabezados
				foreach (DataColumn oCol in oDataTable.Columns){
				   iCol = iCol + 1;
				   oSheet.Range[iRow, iCol].Text = oCol.ColumnName;
				}

				// Cuerpo
				foreach (DataRow oRow in oDataTable.Rows){

				   // Avanza en la fila del Excel
				   iRow = iRow + 1;

				   // Para cada columna
				   for (Int32 k = 0; k < iCol; k++){
				      switch (oDataTable.Columns[k].DataType.FullName){
				         case "System.DateTime":
				            oSheet.Range[iRow, k + 1].DateTime = Convert.ToDateTime(oRow[k]);
				            break;
								
				         case "System.Decimal":
				            oSheet.Range[iRow, k + 1].Number = Convert.ToDouble(oRow[k]);
								oSheet.Range[iRow, k + 1].NumberFormat = "#,##0.00";
				            oSheet.Range[iRow, k + 1].HorizontalAlignment = ExcelHAlign.HAlignRight;
				            break;
								
				         case "System.Double":
				            oSheet.Range[iRow, k + 1].Number = Convert.ToDouble(oRow[k]);
								oSheet.Range[iRow, k + 1].NumberFormat = "#,##0.00";
				            oSheet.Range[iRow, k + 1].HorizontalAlignment = ExcelHAlign.HAlignRight;
				            break;
								
				         case "System.Int16":
				            oSheet.Range[iRow, k + 1].Number = Convert.ToInt16(oRow[k]);
				            oSheet.Range[iRow, k + 1].NumberFormat = "#,##0";
				            oSheet.Range[iRow, k + 1].HorizontalAlignment = ExcelHAlign.HAlignRight;
				            break;
								
				         case "System.Int32":
				            oSheet.Range[iRow, k + 1].Number = Convert.ToInt32(oRow[k]);
				            oSheet.Range[iRow, k + 1].NumberFormat = "#,##0";
				            oSheet.Range[iRow, k + 1].HorizontalAlignment = ExcelHAlign.HAlignRight;
				            break;
								
				         case "System.Int64":
				            oSheet.Range[iRow, k + 1].Number = Convert.ToInt64(oRow[k]);
				            oSheet.Range[iRow, k + 1].NumberFormat = "#,##0";
				            oSheet.Range[iRow, k + 1].HorizontalAlignment = ExcelHAlign.HAlignRight;
				            break;
								
				         default:
				            oSheet.Range[iRow, k + 1].Text = Convert.ToString(oRow[k]);
				            break;
				      }
				      
				      // Formato de moneda para filas específicas
				      if(k == 5 || k == 7 || k == 8 || k == 9){
							oSheet.Range[iRow, k + 1].NumberFormat = "$#,##0.00";
				      }

				   }

				}

				// Formato
				if (iCol > 0){

				   // Encabezado principal
				   oSheet.Range[1, 1, 1, iCol].CellStyle.Font.Bold = true;
				   oSheet.Range[1, 1, 1, iCol].HorizontalAlignment = ExcelHAlign.HAlignCenter;
				   oSheet.Range[1, 1, 1, iCol].CellStyle.ColorIndex = ExcelKnownColors.Grey_25_percent;

				   // Encabezado de columnas
				   oSheet.Range[1, 1, 2, iCol].CellStyle.Font.Bold = true;
				   oSheet.Range[1, 1, 2, iCol].HorizontalAlignment = ExcelHAlign.HAlignCenter;
				   oSheet.Range[1, 1, 2, iCol].CellStyle.ColorIndex = ExcelKnownColors.Grey_25_percent;
				   oSheet.Range[1, 1, iRow, iCol].BorderInside(ExcelLineStyle.Thin);
				   oSheet.Range[1, 1, 1, iCol].BorderAround(ExcelLineStyle.Medium);
				   oSheet.Range[1, 1, iRow, iCol].BorderAround(ExcelLineStyle.Medium);
				   oSheet.Range[1, 1, iRow, iCol].VerticalAlignment = ExcelVAlign.VAlignCenter;

				   // Ancho de las columnas
				   for (Int32 j = 1; j <= iCol; j++){
				      oSheet.AutofitColumn(j);
				   }

				   // Título general (se mueve el set aquí para no afectar el ancho de las columnas)
				   oSheet.Range[1, 1].Text = sGeneralTitle;
				   oSheet.Range[1, 1, 1, iCol].Merge();

				}

				// Guardar libro
				oWorkbook.SaveAs(sSheetName + ".xlsx", this.Response, ExcelDownloadType.PromptDialog, ExcelHttpContentType.Excel2007);

				// Cerrar el libro
				oWorkbook.Close();

			}catch (ExcelWorkbookNotSavedException){
				// Do Nothing

			}catch (Exception){
				// Do Nothing

			}finally{
				oEEngine.ThrowNotSavedOnDestroy = false;
				oEEngine.Dispose();
			}
		}
		
		void SelectArea(ENTArea oENTArea){
			ENTResponse oENTResponse = new ENTResponse();
			BPArea oBPArea = new BPArea();

			try{
				
				// Transacción
				oENTResponse = oBPArea.SelectArea(oENTArea);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage));  }

				// Transacción exitosa
				ExportExcel(oENTResponse.dsResponse.Tables[2], "Area");
				
			}catch (Exception ex){
				throw (ex);
			}
		}
		
		
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			ENTArea oENTArea = new ENTArea();
			String sDefaultErrorMessage = "";

			try
			{
			
				// Mensaje de error por default
				sDefaultErrorMessage = utilEncryption.EncryptString("[V03] Acceso ilegal a la página", true);
				
				// Validaciones
				if (this.Request.QueryString["key"] == null) {
					this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sDefaultErrorMessage, false);
				}
				
				if (!HasValidParams(this.Request.QueryString["key"].ToString(), ref oENTArea)){
					this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx?key=" + sDefaultErrorMessage, false);
				}
				
				// Consultar Órdenes de Compra
				SelectArea(oENTArea);
				
			}catch (Exception){
				// Do Nothing
			}

		}

   }
}