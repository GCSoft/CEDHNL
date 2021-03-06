﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucBusquedaUsuario.ascx.cs" Inherits="SIAQ.Web.Include.WebUserControls.wucBusquedaUsuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<div style="background-color:#D5E9F3; border:1px solid #5E8291; left:0px; text-align:center; top:0px;  width:214px;">
   <table border="0" cellpadding="0" cellspacing="0">
      <tr>
         <td style="text-align:left; width:194px;"><asp:TextBox ID="txtUsuario" runat="server" CssClass="Textbox_General" Width="183px"></asp:TextBox></td>
         <td style="width:20px;"><asp:ImageButton ID="imgBusqueda" runat="server" ImageUrl="~/Include/Image/Buttons/Search.png" onclick="imgBusqueda_Click" /></td>
      </tr>
   </table>
</div>
<asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock">
   <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" style="top:150px;" Height="305px" Width="735px">
      <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
         <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%;">
            <tr>
               <td style="width:10px"></td>
               <td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Filtro de Usuarios"></asp:Label></td>
               <td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
               <td style="width:10px"></td>
            </tr>
         </table>
      </asp:Panel>
      <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
         <div style="margin:0 auto; width:98%;">
            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
               <tr style="height:20px;"><td></td></tr>
               <tr class="trFilaItem">
                  <td>
                     <table cellpadding="0" cellspacing="0">
                        <tr>
                           <td></td>
                           <td rowspan="2" style="text-align:left;"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" MaxLength="200" width="567px" ></asp:TextBox></td>
                           <td></td>
                        </tr>
                        <tr>
                           <td style="width:50px; font-size:12px; text-align: left;">&nbsp;Nombre</td>
                           <td>&nbsp;&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="92px" onclick="btnBuscar_Click" /></td>
                        </tr>
                     </table>
                  </td>
               </tr>
               <tr style="height:5px;"><td></td></tr>
               <tr style="height:155px;">
                  <td>
                     <div style="border:1px solid #4B4878; height:200px; overflow-x:hidden; overflow-y:scroll; text-align:left; width:718px;">
                        <asp:GridView ID="gvUsuario" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" Width="700px"
                           DataKeyNames="idUsuario,sArea,sFullName"
                           onrowcommand="gvUsuario_RowCommand" 
                           onrowdatabound="gvUsuario_RowDataBound"
                           OnSorting = "gvUsuario_Sorting">
                           <HeaderStyle CssClass="Grid_Header_Action" />
                           <RowStyle CssClass="Grid_Row_Action" />
                           <EmptyDataTemplate>
                              <table border="1px" cellpadding="0px" cellspacing="0px">
                                 <tr class="Grid_Header_Action">
                                    <td style="text-align:center; width:100px;">Rol</td>
                                    <td style="text-align:center; width:100px;">Área</td>
                                    <td style="text-align:center; width:180px;">Email</td>
                                    <td style="text-align:center; width:320px;">Nombre</td>
                                 </tr>
                                 <tr class="Grid_Row"><td colspan="4" style="text-align:center;">No se encontraron Usuarios</td></tr>
                              </table>
                           </EmptyDataTemplate>
                           <Columns>
                              <asp:BoundField   HeaderText="Rol"     HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="100px"	SortExpression="sRol"      DataField="sRol"></asp:BoundField>
                              <asp:BoundField   HeaderText="Área"    HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="100px"	SortExpression="sArea"     DataField="sArea"></asp:BoundField>
                              <asp:BoundField   HeaderText="Email"   HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="180px"	SortExpression="sEmail"    DataField="sEmail"></asp:BoundField>
                              <asp:BoundField   HeaderText="Nombre"  HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Left"  ItemStyle-Width="290px"	SortExpression="sFullName" DataField="sFullName"></asp:BoundField>
                              <asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="30px">
                              <ItemTemplate>
                                 <asp:ImageButton ID="imgSelectItem" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Seleccionar" ImageUrl="~/Include/Image/Buttons/SelectItem_Null.png" runat="server" />
                              </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
				            </asp:GridView>
                     </div>
                  </td>
               </tr>
               <tr style="height:5px;"><td></td></tr>
               <tr>
                  <td><asp:Label ID="lblMessage" runat="server" CssClass="ActionContentMessage"></asp:Label></td>
               </tr>
            </table>
         </div>
      </asp:Panel>
   </asp:Panel>
   <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"></ajaxToolkit:DragPanelExtender>
</asp:Panel>
<asp:HiddenField ID="hddArea" runat="server" Value="0"/>
<asp:HiddenField ID="hddUsuarioID" runat="server" Value="0"/>
<asp:HiddenField ID="hddSort" runat="server" Value="sFullName"/>