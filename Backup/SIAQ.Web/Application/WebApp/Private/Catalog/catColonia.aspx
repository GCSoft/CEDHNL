﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="catColonia.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Catalog.catColonia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Colonias y Fraccionamientos
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr> 
      <tr>
			<td>
				<asp:Panel id="Panel1" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" style="text-align:left; font-size:11px" width="100%">
                        <tr>
                            <td colspan="3">Proporcione los filtros deseados para buscar la Colonia o Fraccionamiento</td>
                        </tr>
                        <tr><td class="style2"></td></tr>
                        <tr>
                            <td colspan="3">
								<table border="0" style="width: 460px">
									<tr>
										<td class="Etiqueta">Nombre</td>
										<td class="Espacio"></td>
										<td class="Campo"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
									</tr>
									<tr>
										<td class="Etiqueta">Estatus</td>
										<td class="Espacio"></td>
										<td class="Campo"><asp:DropDownList id="ddlStatus" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
									</tr>
								</table>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" 
                             runat="server" Text="Buscar" CssClass="Button_General" width="125px" 
                             onclick="btnBuscar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" 
                             runat="server" Text="Nuevo" CssClass="Button_General" width="125px" 
                             onclick="btnNuevo_Click" /></td>
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
               <asp:GridView id="gvColonia" runat="server" AllowPaging="false" 
                    AllowSorting="true" AutoGenerateColumns="False" Width="100%"
					DataKeyNames="ColoniaId, CiudadId,Activo, Nombre" onrowcommand="gvColonia_RowCommand" 
                    onrowdatabound="gvColonia_RowDataBound" onsorting="gvColonia_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
									<td style="width:150px;">Nombre del Ciudad</td>
                                    <td style="width:150px;">Nombre de la Colonia</td>
									<td>Descripción</td>
                                    <td style="width:100px;">Estatus</td>
                                    <td style="width:25px;" ></td>
									<td style="width:25px;" ></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="6">No se encontraron ciudades registrados en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Nombre del Estado"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="Ciudad"        SortExpression="Ciudad"></asp:BoundField>
                            <asp:BoundField HeaderText="Nombre de Ciudad"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="Nombre"        SortExpression="Nombre"></asp:BoundField>
							<asp:BoundField HeaderText="Descripción"		ItemStyle-HorizontalAlign="Left"		                    DataField="Descripcion"	SortExpression="Descripcion"></asp:BoundField>
                            <asp:BoundField HeaderText="Estatus"         ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="Estatus"       SortExpression="Estatus"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                                    <asp:ImageButton ID="imgAction" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Action" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
         </td>
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" >
               <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:200px;" Height="250px" Width="400px">
                  <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                     <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
								<tr>
                                    <td style="width:10px"></td>
									<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
                                    <td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
								   <td style="width:10px"></td>
								</tr>
							</table>
                  </asp:Panel>
                  <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                     <div style="margin:0 auto; width:98%;">
                        <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
                            <tr style="height:20px;"><td colspan="3"></td></tr>
                            <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Ciudad</td>
							    <td style="width:5px;"></td>
							    <td class="tdCeldaItem"><asp:DropDownList id="ddlActionCiudad" runat="server" CssClass="DropDownList_General" width="316px" ></asp:DropDownList></td>
						    </tr>
                            <tr style="height:5px;"><td colspan="3"></td></tr>
						    <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Nombre</td>
							    <td style="width:5px;"></td>
							    <td><asp:TextBox ID="txtActionNombre" runat="server" CssClass="Textbox_General" MaxLength="200" width="310px" ></asp:TextBox></td>
						    </tr>
						    <tr style="height:5px;"><td colspan="3"></td></tr>
						    <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Descripción</td>
							    <td></td>
							    <td><asp:TextBox ID="txtActionDescripcion" runat="server" CssClass="Textarea_General" height="50px" MaxLength="200" TextMode="MultiLine" width="310px" ></asp:TextBox></td>
						    </tr>
						    <tr style="height:5px;"><td colspan="3"></td></tr>
						    <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Estatus</td>
							    <td></td>
							    <td class="tdCeldaItem"><asp:DropDownList id="ddlActionStatus" runat="server" CssClass="DropDownList_General" width="316px" ></asp:DropDownList></td>
						    </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr>
                               <td colspan="3" style="text-align:right;">
                                    <asp:Button ID="btnAction" runat="server" Text="" CssClass="Button_General" width="125px" onclick="btnAction_Click" />
                               </td>
                           </tr>
                           <tr>
                              <td colspan="3">
                                 <asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
                              </td>
                           </tr>
						</table>
                     </div>
                  </asp:Panel>
               </asp:Panel>
               
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddColonia" runat="server" value="" />
   <asp:HiddenField ID="hddSort" runat="server" value="Nombre" />
</asp:Content>