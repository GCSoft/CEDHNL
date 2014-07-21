<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueBusquedaSolicitudes.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueBusquedaSolicitudes" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
		<tr>
			<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
				Búsqueda de solicitud
			</td>
		</tr>
        <tr>
			<td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar la solicitud."></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" style="width: 460px">
                        <tr>
                            <td class="Etiqueta">Número de solicitud</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtNumeroSolicitud" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">Nombre del Ciudadano</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">Forma de contacto</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="ddlFormaContacto" runat="server" CssClass="DropDownList_General" Width="216px"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">Funcionario</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="DropDownList_General" Width="216px"></asp:DropDownList></td>
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
                <asp:Panel ID="pnlBotones" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 24px; text-align: left; width: 130px;"><asp:Button ID="cmdBuscar" runat="server" Text="Buscar" OnClick="cmdBuscar_Click" CssClass="Button_General" Width="125px" /></td>
                            <td style="height: 24px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                    <asp:GridView ID="gvSolicitud" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="SolicitudId,NumeroSol"
                        OnRowCommand="gvSolicitud_RowCommand"
						OnRowDataBound="gvSolicitud_RowDataBound"
                        OnSorting="gvSolicitud_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width:100px;">Número Solicitud</td>
                                    <td style="width:100px;">Forma Contacto</td>
                                    <td style="width:150px;">Funcionario</td>
                                    <td>Detalle Queja</td>
                                    <td style="width:200px;">Estatus</td>
                                    <td style="width:30px;"></td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron solicitudes registradas en el sistema</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Número Solicitud"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="NumeroSol"								SortExpression="NumeroSol"></asp:BoundField>
                            <asp:BoundField HeaderText="Forma Contacto"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="NombreFormaContacto"						SortExpression="NombreFormaContacto"></asp:BoundField>
                            <asp:BoundField HeaderText="Funcionario"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="NombreFuncionario"						SortExpression="NombreFuncionario"></asp:BoundField>
                            <asp:BoundField HeaderText="Detalle Queja"		ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"		HtmlEncode="false"	SortExpression="Observaciones"></asp:BoundField>
                            <asp:BoundField HeaderText="Estatus"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="NombreEstatus"							SortExpression="NombreEstatus"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("SolicitudId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
</asp:Content>
