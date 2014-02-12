<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeLstEspedienteSecretaria.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeLstEspedienteSecretaria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado">
				Listado de Expedientes
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
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
									<td style="width:100px;">Expediente</td>
									<td style="width:200px;">Asunto</td>
                                    <td style="width:100px;">Fecha Visitadurías</td>
                                    <td style="width:100px;">Estatus</td>
                                    <td style="width:100px;">Quejosos</td>
                                    <td style="width:100px;">Autoridades</td>
                                    <td style="width:100px;">Visitador</td>
                                    
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron Expedientes registrados en el sistema</td>
								</tr>
							</table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Expediente" HeaderText="Expediente"/>
                            <asp:BoundField DataField="Asunto" HeaderText="Asunto">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaVisitadurías" HeaderText="Fecha Visitadurías">
                                <ItemStyle HorizontalAlign="Left"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quejosos" HeaderText="Quejosos">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Autoridades" HeaderText="Autoridades">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Visitador" HeaderText="Visitador">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
