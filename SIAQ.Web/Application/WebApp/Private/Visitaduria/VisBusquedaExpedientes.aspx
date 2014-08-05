<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VisBusquedaExpedientes.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.VisBusquedaExpedientes" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">

	<table class="GeneralTable">
		<tr>
			<td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
				Búsqueda de expediente
			</td>
		</tr>
        <tr>
			<td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar la Expediente."></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" style="width: 460px">
                        <tr>
                            <td class="Etiqueta">Número de Expediente</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtNumeroExpediente" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">Nombre del Ciudadano</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" MaxLength="8000" Width="211px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Etiqueta">Estatus</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:DropDownList ID="ddlEstatus" runat="server" CssClass="DropDownList_General" Width="216px"></asp:DropDownList></td>
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
                            <td style="height: 24px; text-align: left; width: 130px;"><asp:Button ID="btnBuscar" runat="server" CssClass="Button_General"  Text="Buscar" Width="125px" OnClick="btnBuscar_Click" /></td>
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
                    <asp:GridView ID="gvExpediente" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedienteId,ExpedienteNumero"
                        OnRowCommand="gvExpediente_RowCommand"
						OnRowDataBound="gvExpediente_RowDataBound"
                        OnSorting="gvExpediente_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
                                    <td style="width:80px;">Expediente</td>
									<td style="width:150px;">Funcionario</td>
                                    <td style="width:150px;">Afectado</td>
									<td style="width:150px;">Acompañantes</td>
                                    <td>Observaciones</td>
                                    <td style="width:200px;">Estatus</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Expedientees registradas en el sistema</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Expediente"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="ExpedienteNumero"						SortExpression="ExpedienteNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="FuncionarioNombre"						SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Afectado"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Afectados"								SortExpression="Afectados"></asp:BoundField>
							<asp:BoundField HeaderText="Acompañantes"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Acompanantes"							SortExpression="Acompanantes"></asp:BoundField>
                            <asp:BoundField HeaderText="Observaciones"		ItemStyle-HorizontalAlign="Left"							DataField="Observaciones"		HtmlEncode="false"	SortExpression="Observaciones"></asp:BoundField>
                            <asp:BoundField HeaderText="Estatus"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="EstatusNombre"							SortExpression="EstatusNombre"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("ExpedienteId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

    <asp:HiddenField ID="hddSort" runat="server" Value="ExpedienteNumero" />
	
</asp:Content>
