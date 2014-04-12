<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaCiudadano" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table class="GeneralTable">
      <tr>
         <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
            Buscar ciudadano
         </td>
      </tr>
      <tr>
         <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar al ciudadano."></asp:Label></td>
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
               <table border="0" style="width:460px">
                  <tr>
                     <td class="Etiqueta">Nombre del Ciudadano</td>
                     <td class="Espacio"></td>
                     <td class="Campo"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="211px" ></asp:TextBox></td>
                  </tr>
                  <tr><td colspan="3" style="height:10px;"></td></tr>
               </table>
               <table  border="0" style="width: 460px">
                  <tr>
                     <td colspan="3">
                        <ajaxToolkit:Accordion ID="acrdBusqueda" runat="server" SelectedIndex="-1" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="False">
						         <Panes>
							         <ajaxToolkit:AccordionPane ID="apnlFiltros" runat="server">
								         <Header>
									         <table border="0" cellpadding="0" cellspacing="0" width="120px">
										         <tr>
											         <td align="left" style="cursor:pointer;">
												         <asp:Label ID="lblFiltro" style="height:23px;" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="9pt" Font-Underline="true">Búsqueda Avanzada</asp:Label>
											         </td>
										         </tr>
									         </table>
								         </Header>
								         <Content>
                                    <table border="0" style="width:460px">
                                       <tr>
                                          <td class="Etiqueta">Apellido Paterno</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="Textbox_General" width="211px" ></asp:TextBox></td>
                                       </tr>
                                       <tr>
                                          <td class="Etiqueta">Apellido Materno</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" width="211px" ></asp:TextBox></td>
                                       </tr>
                                       <tr>
                                          <td class="Etiqueta">País</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:DropDownList ID="BuscadorListaPais" runat="server" CssClass="DropDownList_General" width="216px" AutoPostBack="True" onselectedindexchanged="BuscadorListaPais_SelectedIndexChanged" ></asp:DropDownList></td>
                                       </tr>
                                       <tr>
                                          <td class="Etiqueta">Estado</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:DropDownList ID="BuscadorListaEstado" runat="server" CssClass="DropDownList_General" width="216px" AutoPostBack="True" onselectedindexchanged="BuscadorListaEstado_SelectedIndexChanged" ></asp:DropDownList></td>
                                       </tr>
                                       <tr>
                                          <td class="Etiqueta">Municipio</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:DropDownList ID="BuscadorListaCiudad" runat="server" CssClass="DropDownList_General" width="216px" AutoPostBack="True" onselectedindexchanged="BuscadorListaCiudad_SelectedIndexChanged" ></asp:DropDownList></td>
                                       </tr>
                                       <tr>
                                          <td class="Etiqueta">Colonia</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:DropDownList ID="BuscadorListaColonia" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
                                       </tr>
                                       <tr>
                                          <td class="Etiqueta">Calle</td>
                                          <td class="Espacio"></td>
                                          <td class="Campo"><asp:TextBox ID="TextBoxCalle" runat="server" CssClass="Textbox_General" width="211px" ></asp:TextBox></td>
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
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"></td>
                     <td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						DataKeyNames="CiudadanoId"
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand"
                  OnSorting="gvCiudadano_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:200px;">Nombre</td>
									<td style="width:50px;">Sexo</td>
                           <td style="width:65px;">Fecha Nacimiento</td>
                           <td style="width:280px;">Domicilio</td>
                           <td style="width:65px;">Telefono</td>
                           <td style="width:50px;">Visita</td>
                           <td style="width:53px;">Solicitud</td>
                           <td style="width:30px;">Editar</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="8">No se encontraron ciudadanos registradas en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
                     <asp:BoundField HeaderText="Nombre"             ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="170px" DataField="NombreCompleto"></asp:BoundField>
                     <asp:BoundField HeaderText="Sexo"               ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="50px"  DataField="SexoNombre"></asp:BoundField>
                     <asp:BoundField HeaderText="Fecha Nacimiento"   ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px"  DataField="FechaNacimiento"></asp:BoundField>
                     <asp:BoundField HeaderText="Domicilio"          ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="280px" DataField="DireccionCompleta"></asp:BoundField>
                     <asp:BoundField HeaderText="Telefono"           ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px"  DataField="TelefonoPrincipal"></asp:BoundField>
                     <asp:TemplateField HeaderText="Visita">
                        <ItemTemplate>
                           <asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Visita" ID="VisitaLink" runat="server" Text='Visita' Width="80px"></asp:LinkButton>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField HeaderText="Solicitud"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="50px"></asp:BoundField>
                     <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                           <asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Editar" ID="EditarLink" runat="server" Text='Editar' Width="80px"></asp:LinkButton>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Consultar">
                        <ItemTemplate>
                           <asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Consultar" ID="ConsultarLink" runat="server" Text='Consultar' Width="80px"></asp:LinkButton>
                        </ItemTemplate>
                     </asp:TemplateField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddSort" runat="server" value="sNombre" />
</asp:Content>
