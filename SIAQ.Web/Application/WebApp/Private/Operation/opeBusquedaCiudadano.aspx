﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaCiudadano" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	<table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Buscar ciudadano
            </td>
        </tr>
        <tr>
            <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar al ciudadano."></asp:Label></td>
        </tr>
        <tr>
            <td>
				<asp:Panel ID="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" style="width:460px">
						<tr>
							<td class="Etiqueta">Nombre del Ciudadano</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
                        </tr>
                        <tr><td colspan="3" style="height:10px;"></td></tr>
                    </table>
                    <table border="0" style="width: 460px">
                        <tr>
                            <td colspan="3">
                                <ajaxToolkit:Accordion ID="acrdBusqueda" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="False">
                                    <Panes>
                                        <ajaxToolkit:AccordionPane ID="apnlFiltros" runat="server">
                                            <Header>
                                                <table border="0" cellpadding="0" cellspacing="0" width="120px">
                                                    <tr>
                                                        <td align="left" style="cursor: pointer;">
															<asp:Label ID="lblFiltro" Style="height: 23px;" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="9pt" Font-Underline="true">Búsqueda Avanzada</asp:Label>
														</td>
                                                    </tr>
                                                </table>
                                            </Header>
                                            <Content>
												<table border="0" style="width: 460px">
													<tr>
														<td class="Etiqueta">Apellido Paterno</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
													</tr>
													<tr>
														<td class="Etiqueta">Apellido Materno</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
													</tr>
													<tr>
														<td class="Etiqueta">País</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:DropDownList ID="BuscadorListaPais" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" OnSelectedIndexChanged="BuscadorListaPais_SelectedIndexChanged"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="Etiqueta">Estado</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:DropDownList ID="BuscadorListaEstado" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" OnSelectedIndexChanged="BuscadorListaEstado_SelectedIndexChanged"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="Etiqueta">Municipio</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:DropDownList ID="BuscadorListaCiudad" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" OnSelectedIndexChanged="BuscadorListaCiudad_SelectedIndexChanged"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="Etiqueta">Colonia</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:DropDownList ID="BuscadorListaColonia" runat="server" CssClass="DropDownList_General" Width="216px"></asp:DropDownList></td>
													</tr>
													<tr>
														<td class="Etiqueta">Calle</td>
														<td class="Espacio"></td>
														<td class="Campo"><asp:TextBox ID="TextBoxCalle" runat="server" CssClass="Textbox_General" Width="211px"></asp:TextBox></td>
													</tr>
												</table>
                                            </Content>
                                        </ajaxToolkit:AccordionPane>
                                    </Panes>
                                </ajaxToolkit:Accordion>
                            </td>
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
                            <td style="height:24px; text-align:left; width:130px;">
                                <asp:Button ID="btnBuscar" runat="server" CssClass="Button_General"  Text="Buscar" Width="125px" OnClick="btnBuscar_Click" />
							</td>
                            <td style="height:24px;"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                    <asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="CiudadanoId,NombreCompleto"
						OnRowDataBound="gvCiudadano_RowDataBound"
                        OnRowCommand="gvCiudadano_RowCommand"
						OnSorting="gvCiudadano_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td>Nombre</td>
									<td style="width:40px;">Edad</td>
									<td style="width:40px;">Sexo</td>
									<td style="width:240px;">Domicilio</td>
									<td style="width:100px;">Estado</td>
									<td style="width:100px;">Teléfono</td>
									<td style="width:150px;">Email</td>
									<td style="width:30px;"></td>
									<td style="width:30px;"></td>
									<td style="width:30px;"></td>
									<td style="width:30px;"></td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="11">No se encontraron ciudadanos registrados en el sistema</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"							DataField="NombreCompleto"		SortExpression="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Edad"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="40px"	DataField="Edad"				SortExpression="Edad"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="40px"	DataField="SexoNombre"			SortExpression="SexoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="240px"	DataField="Domicilio"			SortExpression="Domicilio"></asp:BoundField>
							<asp:BoundField HeaderText="Estado"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="NombreEstado"		SortExpression="NombreEstado"></asp:BoundField>
							<asp:BoundField HeaderText="Telefono"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="TelefonoPrincipal"	SortExpression="TelefonoPrincipal"></asp:BoundField>
							<asp:BoundField HeaderText="Email"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="CorreoElectronico"	SortExpression="CorreoElectronico"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgVisita" runat="server"  CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Visita" ImageUrl="~/Include/Image/Buttons/AgregarVisita.png"/>
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSolicitud" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Solicitud" ImageUrl="~/Include/Image/Buttons/AgregarSolicitud.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgConsultar" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Consultar" ImageUrl="~/Include/Image/Buttons/ConsultarCiudadano.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

    <asp:HiddenField ID="hddSort" runat="server" Value="sNombre" />

</asp:Content>
