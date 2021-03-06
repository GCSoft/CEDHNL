﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicBusquedaAtenciones.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicBusquedaAtenciones" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Búsqueda de Atenciones
            </td>
        </tr>
        <tr>
            <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar la atención."></asp:Label></td>
        </tr>
		<tr>
            <td>
				<asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" style="width: 460px">
						<tr>
							<td class="Etiqueta">No. Folio</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtAtencionNumero" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
                        <tr>
							<td class="Etiqueta">Quejoso</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtQuejoso" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
						<tr>
                            <td class="Etiqueta">Doctor</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="ddlDoctor" runat="server" CssClass="DropDownList_General" Width="216px" ></asp:DropDownList></td>
                        </tr>
						 <tr>
                            <td class="Etiqueta">Fecha inicio</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><wuc:wucCalendar ID="wucBeginDate" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">Fecha fin</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><wuc:wucCalendar ID="wucEndDate" runat="server" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;">
								<asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" />
							</td>
                            <td style="height: 24px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvAtencion" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="AtencionId,AtencionNumeroFolio" 
						OnRowCommand="gvAtencion_RowCommand" 
						OnRowDataBound="gvAtencion_RowDataBound"
						OnSorting="gvAtencion_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
                                    <td style="width:100px;">Número de Folio</td>
									<td style="width:100px;">Número de Expediente</td>
									<td style="width:100px;">Número de Solicitud</td>
									<td>Ciudadanos</td>
									<td style="width:150px;">Estatus</td>
									<td style="width:75px;">Fecha</td>
									<td style="width:150px;">Médico</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="8">Seleccione los filtros deseados y pulse el botón Buscar</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número de Folio"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px" DataField="AtencionNumeroFolio"	SortExpression="AtencionNumeroFolio"></asp:BoundField>
							<asp:BoundField HeaderText="Número de Expediente"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="ExpedienteNumero"	SortExpression="ExpedienteNumero"></asp:BoundField>
                            <asp:BoundField HeaderText="Número de Solicitud"	ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px"	DataField="SolicitudNumero"		SortExpression="SolicitudNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Ciudadanos"				ItemStyle-HorizontalAlign="Left"							DataField="Ciudadanos"			SortExpression="Ciudadanos"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"				ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="EstatusNombre"		SortExpression="EstatusNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="FechaAtencion"		SortExpression="FechaAtencion"></asp:BoundField>
							<asp:BoundField HeaderText="Médico"					ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="FuncionarioNombre"	SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
									<asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
        <asp:HiddenField ID="hddSort" runat="server" Value="AtencionNumeroFolio" />
    </table>
</asp:Content>
