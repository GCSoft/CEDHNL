<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicDictamenMedico.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicDictamenMedico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Dectámen Médico
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Proporcione la información relacionada al dictamen médico realizado"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Atención número</td>
                <td class="Espacio"></td>
                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="lblAtencionId" runat="server" Text="0"></asp:Label></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="7" ></td>
            </tr>
			<tr>
                <td class="Nombre">Ciudadano</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlCiudadano" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td ></td>
                <td class="Espacio"></td>
                <td colspan="5" style="text-align:left;"></td>
            </tr>
            <tr>
                <td class="Nombre">Dictámen</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:TextBox ID="txtDictamen" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="7" style="text-align:left;">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click" /> 
					&nbsp; 
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>
        
		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace">&nbsp;</td></tr>
            <tr>
                <td style="text-align: left;">
                    Dictámenes realizados
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView id="gvApps" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionId,Numero" 
						onrowdatabound="gvApps_RowDataBound"
						onsorting="gvApps_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
									<td style="width:75px;">Ciudadano</td>
									<td style="width:200px;">Descripción</td>
									<td style="width:70px;">Fecha</td>
									<td></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="5">No se encontraron dictámenes asociadas a esta atención</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Ciudadano"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="NombreCiudadano"		SortExpression="NombreCiudadano"></asp:BoundField>
							<asp:BoundField HeaderText="Descripción"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="Descripción"		    SortExpression="Descripción"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"	            SortExpression="Fecha"></asp:BoundField>
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
            <tr><td class="tdCeldaMiddleSpace">&nbsp;</td></tr>
            <tr>
                <td style="text-align: left;">
                    &nbsp;&nbsp;
					</td>
            </tr>
        </table>

    </div>

    <asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Numero" />

</asp:Content>
