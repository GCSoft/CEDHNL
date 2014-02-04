<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroSolicitud" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="uc1" %>
<%@ Register src="../../../../Include/WebUserControls/wucTimeMask.ascx" tagname="wucTimeMask" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registro de Solicitudes
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Fecha</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <uc1:wucCalendar ID="txtFechaCaptura" runat="server" />
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Hora</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <wuc:wucTimeMask ID="txtFechaCargado" runat="server" />
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                         <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="177px"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">*</font>&nbsp;<asp:Button ID="btnBuscar" runat="server"  Width="30px" Text="..."></asp:Button>
                            </td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Abogado</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlAbogado" runat="server" CssClass="DropDownList_General" width="182px" ></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Observaciones</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="Textarea_General" width="300px" TextMode="MultiLine"></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr style="height:3px;"><td colspan="3"></td></tr>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General_Verde" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General_Verde" width="125px" /></td>
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
               <asp:GridView id="gvSolicitudes" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						DataKeyNames="SolicitudId,FuncionarioId">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px;">Solicitud</td>
									<td style="width:150px;">Funcionario</td>
                                    <td style="width:100px;">Numero</td>
                                    <td style="width:100px;">Estatus</td>
                                    <td style="width:190px;">Lugar de Hechos</td>
                                    <td style="width:100px;">Calificación</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="6">No se encontraron Solicitudes registrados en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Solicitud" ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="sNombre"        SortExpression="sNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Funcionario"           ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="iTerminal"      SortExpression="iTerminal"></asp:BoundField>
                            <asp:BoundField HeaderText="Numero"                ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sRFC"           SortExpression="sRFC"></asp:BoundField>
                            <asp:BoundField HeaderText="Estatus"        ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sProExterno"    SortExpression="sProExterno"></asp:BoundField>
							<asp:BoundField HeaderText="Lugar de Hechos"        ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="240px" DataField="sDescripcion"	SortExpression="sDescripcion"></asp:BoundField>
                            <asp:BoundField HeaderText="Calificación"            ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sEstatus"       SortExpression="sEstatus"></asp:BoundField>
							<%--<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                                </ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                                    <asp:ImageButton ID="imgAction" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Action" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>--%>
						</Columns>
					</asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
