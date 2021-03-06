﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="scatUsuario.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.SysCat.scatUsuario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Sistema - Usuario
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Rol</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlRol" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
                  <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Área</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList id="ddlArea" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Correo</td>
							<td></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtEmail" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
						</tr>
                  <tr style="height:3px;"><td colspan="3"></td></tr>
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItem">&nbsp;Nombre</td>
							<td></td>
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
					<td style="height:24px;">
						<asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" />&nbsp;&nbsp;
						<asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnNuevo_Click" />&nbsp;&nbsp;
						<asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="Button_General" width="125px" onclick="btnExportar_Click" />
					</td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvUsuario" runat="server" border="0" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="idUsuario, idArea, tiActivo, sFullName"
						OnRowDataBound="gvUsuario_RowDataBound"
						OnRowCommand="gvUsuario_RowCommand"
						OnSorting="gvUsuario_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px;">Rol</td>
									<td style="width:150px;">Área</td>
									<td style="width:100px;">Estatus</td>
									<td style="width:150px;">Correo</td>
									<td>Nombre del Usuario</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="5">No se encontraron Usuarios registrados en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Rol"                ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="sRol"        SortExpression="sRol"></asp:BoundField>
							<asp:BoundField HeaderText="Área"               ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="sArea"       SortExpression="sArea"></asp:BoundField>
							<asp:BoundField HeaderText="Correo"             ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="sEmail"      SortExpression="sEmail"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"            ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sEstatus"    SortExpression="sEstatus"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre del Usuario" ItemStyle-HorizontalAlign="Left"							DataField="sFullName"   SortExpression="sFullName"></asp:BoundField>
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
               <asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:200px;" Height="390px" Width="400px">
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
								<td class="tdActionCeldaLeyendaItem">&nbsp;Rol</td>
								<td style="width:5px;"></td>
								<td><asp:DropDownList id="ddlActionRol" runat="server" CssClass="DropDownList_General" width="316px" AutoPostBack="True" onselectedindexchanged="ddlActionRol_SelectedIndexChanged" ></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Área</td>
								<td style="width:5px;"></td>
								<td><asp:DropDownList id="ddlActionArea" runat="server" CssClass="DropDownList_General" width="316px" ></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Sexo</td>
								<td style="width:5px;"></td>
								<td><asp:DropDownList id="ddlSexo" runat="server" CssClass="DropDownList_General" width="316px" ></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Correo</td>
								<td style="width:5px;"></td>
								<td><asp:TextBox ID="txtActionEmail" runat="server" CssClass="Textbox_General" MaxLength="200" width="310px" ></asp:TextBox></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Nombre</td>
								<td style="width:5px;"></td>
								<td><asp:TextBox ID="txtActionNombre" runat="server" CssClass="Textbox_General" MaxLength="200" width="310px" ></asp:TextBox></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;A. Paterno</td>
								<td style="width:5px;"></td>
								<td><asp:TextBox ID="txtActionApellidoPaterno" runat="server" CssClass="Textbox_General" MaxLength="200" width="310px" ></asp:TextBox></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;A. Materno</td>
								<td style="width:5px;"></td>
								<td><asp:TextBox ID="txtActionApellidoMaterno" runat="server" CssClass="Textbox_General" MaxLength="200" width="310px" ></asp:TextBox></td>
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
               <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"> </ajaxToolkit:DragPanelExtender>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddUsuario" runat="server" value="" />
   <asp:HiddenField ID="hddSort" runat="server" value="sArea" />
</asp:Content>
