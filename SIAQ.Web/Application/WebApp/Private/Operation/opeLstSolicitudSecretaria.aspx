<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeLstSolicitudSecretaria.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeLstSolicitudSecretaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado">
				Listado de Solicitudes
			</td>
		</tr>
      <tr style="height:10px;"><td></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                        AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="800px" 
                        Style="text-align: center" DataKeyNames="Solicitud"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:100px;">Solicitud</td>
									<td style="width:150px;">Detalle</td>
                                    <td style="width:100px;">Fecha</td>
                                    <td style="width:100px;">Estatus</td>
                                    <td style="width:100px;">Quejosos</td>
                                    <td style="width:100px;">Servidores</td>
                                    <td style="width:100px;">Lugar de los hechos</td>
                                    <td style="width:50px;">Asignar</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="8">No se encontraron Solicitudes registrados en el sistema</td>
								</tr>
							</table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Solicitud" HeaderText="Id" Visible="False"/>
                            <asp:BoundField DataField="Detalle" HeaderText="Detalle">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quejosos" HeaderText="Quejosos">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Servidores" HeaderText="Servidores">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LugarHechos" HeaderText="Lugar de los hechos">
                                <ItemStyle HorizontalAlign="Left"/>
                            </asp:BoundField>
                            <asp:ButtonField CommandName="ASIGNA" HeaderText="Funcionario" Text="Asignar" />
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
