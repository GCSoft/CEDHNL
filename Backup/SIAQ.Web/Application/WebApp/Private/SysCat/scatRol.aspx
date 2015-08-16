<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="scatRol.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.SysCat.scatRol" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Sistema - Roles
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Estatus</td>
							<td></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlStatus" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnNuevo_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="Button_General" width="125px" onclick="btnExportar_Click" /></td>
							<td style="height:24px; width:400px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvRol" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						DataKeyNames="idRol, tiActivo, sNombre"
						OnRowDataBound="gvRol_RowDataBound"
						OnRowCommand="gvRol_RowCommand"
						OnSorting="gvRol_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px;">Rol</td>
									<td style="width:540px;">Descripción</td>
                           <td style="width:100px;">Estatus</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="3">No se encontraron Roles registrados en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Rol"          ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="sNombre"        SortExpression="sNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Descripción"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="500px" DataField="sDescripcion"	SortExpression="sDescripcion"></asp:BoundField>
                     <asp:BoundField HeaderText="Estatus"      ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sEstatus"       SortExpression="sEstatus"></asp:BoundField>
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
               <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:100px;" Height="450px" Width="400px">
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
                           <tr class="trFilaItem">
							         <td class="tdActionCeldaLeyendaItem">&nbsp;Menú</td>
							         <td></td>
							         <td class="tdCeldaItem"><asp:DropDownList id="ddlActionMenu" runat="server" CssClass="DropDownList_General" width="316px" AutoPostBack="True" onselectedindexchanged="ddlActionMenu_SelectedIndexChanged" ></asp:DropDownList></td>
						         </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr style="height:155px;">
                              <td colspan="3">
                                 <div style="border:1px solid #4B4878; height:170px; overflow-x:hidden; overflow-y:scroll; text-align:left; width:387px;">
				                        <asp:GridView ID="gvActionSubMenu" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" Width="373px"
                                       DataKeyNames="idMenu, idSubMenu, tiSelected, tiRequired"
                                       OnRowDataBound="gvActionSubMenu_RowDataBound"
						                     OnSorting="gvActionSubMenu_Sorting">
                                       <HeaderStyle CssClass="Grid_Header_Action" />
					                        <RowStyle CssClass="Grid_Row_Action" />
					                        <Columns>
                                          <asp:BoundField		HeaderText="Menú"    ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="105px"	SortExpression="sNombreMenu"     DataField="sNombreMenu"></asp:BoundField>
						                        <asp:BoundField		HeaderText="SubMenú" ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="169px"	SortExpression="sNombreSubMenu"  DataField="sNombreSubMenu"></asp:BoundField>
						                        <asp:TemplateField	HeaderText="Incluír" ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="99px"	SortExpression="tiSelected">
							                        <ItemTemplate>
                                                <asp:CheckBox ID="chkActionIncluir" AutoPostBack="true" runat="server" OnCheckedChanged="chkActionIncluir_Changed" ToolTip = "Incluir en el Rol" />
							                        </ItemTemplate>
						                        </asp:TemplateField>
					                        </Columns>
				                        </asp:GridView>
			                        </div>
                              </td>
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
               <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"> </ajaxToolkit:DragPanelExtender>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddRol" runat="server" value="" />
   <asp:HiddenField ID="hddSort" runat="server" value="sNombre" />
   <asp:HiddenField ID="hddSortAction" runat="server" value="sNombreMenu" />
</asp:Content>
