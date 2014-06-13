<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="catFuncionario.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Catalog.catFuncionario" %>
<%@ Register src="../../../../Include/WebUserControls/wucBusquedaUsuario.ascx" tagname="wucBusquedaUsuario" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Funcionarios
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" style="text-align:left; font-size:11px" width="100%">
						<tr>
                            <td colspan="3">Proporcione los filtros deseados para buscar el Funcionario</td>
                        </tr>
                        <tr><td class="style2"></td></tr>
                        <tr>
                            <td colspan="3">
                                <table border="0" style="width: 460px">
                                    <tr>
							            <td class="Etiqueta">&nbsp;Área</td>
							            <td class="Espacio"></td>
							            <td class="Campo"><asp:DropDownList id="ddlArea" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
						            </tr>
                                    <tr>
							            <td class="Etiqueta">&nbsp;Nombre</td>
							            <td class="Espacio"></td>
							            <td class="Campo"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" onclick="btnBuscar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnNuevo_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="Button_General" width="125px" Visible="false" /></td>
					 <td style="height:24px;">&nbsp;</td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvFuncionario" runat="server" border="0" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="FuncionarioId,sFullName"
						OnRowDataBound="gvFuncionario_RowDataBound"
						OnRowCommand="gvFuncionario_RowCommand"
						OnSorting="gvFuncionario_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
                                    <td style="width:200px;">Área</td>
									<td style="width:100px;">Título</td>
									<td style="width:100px;">Puesto</td>
                                    <td style="width:90px;">Ingreso</td>
                                    <td style="width:300px;">Nombre</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="6">No se encontraron Funcionarios registrados en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
                     <asp:BoundField HeaderText="Área"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="sArea"          SortExpression="sArea"></asp:BoundField>
							<asp:BoundField HeaderText="Título"    ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="sTitulo"        SortExpression="sTitulo"></asp:BoundField>
							<asp:BoundField HeaderText="Puesto"    ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="100px" DataField="sPuesto"        SortExpression="sPuesto"></asp:BoundField>
                     <asp:BoundField HeaderText="Ingreso"   ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="90px"  DataField="sFechaIngreso"  SortExpression="sFechaIngreso"></asp:BoundField>
                     <asp:BoundField HeaderText="Nombre"    ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="260px" DataField="sFullName"      SortExpression="sFullName"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                           <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                        </ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                           <asp:ImageButton ID="imgAction" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
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
                              <td class="tdActionCeldaLeyendaItem">&nbsp;Puesto</td>
                              <td style="width:5px;"></td>
                              <td class="tdCeldaItem"><asp:DropDownList id="ddlActionPuesto" runat="server" CssClass="DropDownList_General" width="316px" ></asp:DropDownList></td>
                           </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
                              <td class="tdActionCeldaLeyendaItem">&nbsp;Título</td>
                              <td></td>
                              <td class="tdCeldaItem"><asp:DropDownList id="ddlActionTitulo" runat="server" CssClass="DropDownList_General" width="316px" ></asp:DropDownList></td>
                           </tr>
                           <tr style="height:5px;"><td colspan="3"></td></tr>
                           <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Usuario</td>
							    <td></td>
							    <td><wuc:wucBusquedaUsuario ID="wucBusquedaUsuario" runat="server" /></td>
						    </tr>
						    <tr style="height:5px;"><td colspan="3"></td></tr>
						    <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Área</td>
							    <td></td>
							    <td><asp:TextBox ID="txtActionArea" runat="server" CssClass="Textbox_General" MaxLength="200" ReadOnly="true" width="310px" ></asp:TextBox></td>
						    </tr>
						    <tr style="height:5px;"><td colspan="3"></td></tr>
						    <tr class="trFilaItem">
							    <td class="tdActionCeldaLeyendaItem">&nbsp;Ingreso</td>
							    <td></td>
							    <td><wuc:wucCalendar ID="wucCalendar" runat="server" /></td>
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
   <asp:HiddenField ID="hddFuncionario" runat="server" value="" />
   <asp:HiddenField ID="hddSort" runat="server" value="sFullName" />
</asp:Content>
