<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vicImprimirAtencion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Victimas.vicImprimirAtencion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>SIAQ - Vista Previa Impresión</title>
		<meta content="GCSoft - Web Project Creator BETA 1.0" name="autor" />
		<link rel="shortcut icon" href="~/Include/Image/Content/Web/favicon.ico" type="image/png" />
		<link href="~/Include/Style/Content.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Control.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/MasterPage.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Table.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Text.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Style/Wait.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Javascript/TinyBox/TinyBox.css" rel="Stylesheet" type="text/css" />
		<link href="~/Include/Javascript/ToolTip/ToolTip.css" rel="Stylesheet" type="text/css" />
		<script src="../../../../Include/Javascript/TinyBox/TinyBox.js" type="text/javascript"></script>
		<script src="../../../../Include/Javascript/ToolTip/ToolTip.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript" src="../../../../Include/Javascript/GCSoft/GCSoft.js"></script>
    </head>
    <body>
        <form id="form1" runat="server">
			
			<div id="TituloPaginaDiv">
				<table class="GeneralTable">
					<tr>
						<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
							Detalle de la atención
						</td>
					</tr>
				</table>
			</div>

			<div id="InformacionDiv">
				
				<!-- Carátula -->
				<table class="SolicitudTable">
					<tr>
						<td class="Especial">Folio</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label ID="AtencionNumeroFolio" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Especial">Afectado</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">No. Oficio</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="AtencionNumeroOficio" runat="server" Text=""></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Área</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="AreaLabel" runat="server" Text=""></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Expediente número</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="ExpedienteNumeroLabel" runat="server" Text=""></asp:Label></td>
						<td colspan="4"></td>
					</tr>
					<tr>
						<td class="Nombre">Solicitud número</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="SolicitudNumeroLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de Atención</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaAtencionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Estatus</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Fecha de Asignación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Médico</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="DoctorLabel" runat="server" Text=""></asp:Label></td>
						<td class="Espacio"></td>
						<td class="Nombre">Ultima Modificación</td>
						<td class="Espacio"></td>
						<td class="Etiqueta"><asp:Label ID="UltimaModificacionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Dictámen Médico</td>
						<td class="Espacio"></td>
						<td class="Etiqueta" colspan="5"><asp:Label ID="DictamenMedicoLabel" runat="server" Text=""></asp:Label></td>
					</tr>
					<tr>
						<td class="Nombre">Lugar de Revisión</td>
						<td class="Espacio"></td>
						<td class="Etiqueta" colspan="5"><asp:Label ID="LugarRevisionLabel" runat="server" Text=""></asp:Label></td>
					</tr>
				</table>
				<br />

				<!-- Detalle-->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							Detalle
						</td>
					</tr>
					<tr>
						<td>
							<asp:GridView ID="gvAtencionDetalle" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%">
								<RowStyle CssClass="Grid_Row" />
								<EditRowStyle Wrap="True" />
								<HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
								<AlternatingRowStyle CssClass="Grid_Row_Alternating" />
								<EmptyDataTemplate>
									<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
										<tr class="Grid_Header">
											<td style="width:50px;">No</td>
											<td>Detalle</td>
										</tr>
										<tr class="Grid_Row">
											<td colspan="2">No se encontraron Puntos Resolutivos asociados a la Recomendacion/Acuerdo de No Responsabilidad</td>
										</tr>
									</table>
								</EmptyDataTemplate>
								<Columns>
									<asp:BoundField HeaderText="No"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="50px"	DataField="RowNumber"						SortExpression="RowNumber"></asp:BoundField>
									<asp:BoundField HeaderText="Detalle"	ItemStyle-HorizontalAlign="Left"							DataField="Detalle"		HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
								</Columns>
							</asp:GridView>
						</td>
					</tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
				</table>
				<br />

				<!-- Dictámen -->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							Dictámen
						</td>
					</tr>
					<tr>
						<td>
							<asp:GridView ID="gvDictamen" runat="server" AllowPaging="false" AllowSorting="false"  AutoGenerateColumns="False" ShowHeader="false" Width="100%">
								<RowStyle CssClass="Grid_Row_Detail" />
								<EmptyDataTemplate>
									<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
										<tr class="Grid_Header">
											<td>Detalle</td>
										</tr>
										<tr class="Grid_Row">
											<td colspan="1">No se ha emitido un Dictamen para esta solicitud de atención a víctimas</td>
										</tr>
									</table>
								</EmptyDataTemplate>
								<Columns>
									<asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="Detalle" HtmlEncode="false"></asp:BoundField>
								</Columns>
							</asp:GridView>
						</td>
					</tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
				</table>
				<br />
				
				<!-- Botones Pie de Página -->
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
						</td>
					</tr>
				</table>

			</div>

			<asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
			<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

        </form>
    </body>
</html>
