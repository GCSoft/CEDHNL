<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaExpedientes.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaExpedientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado">
				Búsqueda de Expedientes
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Núm. de expediente</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNumeroExpediente" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Quejoso</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtQuejoso" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Forma de contacto</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlFormaContacto" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Visitador</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlVisitador" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td colspan = "8">
                                <hr />
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General_Verde" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="Button_General_Verde" width="125px" /></td>
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
									<td style="width:150px;">Asunto</td>
                                    <td style="width:100px;">Fecha Visitadurías</td>
                                    <td style="width:100px;">Visitador</td>
                                    <td style="width:100px;">Estatus</td>
                                    <td style="width:100px;">Quejosos</td>
                                    <td style="width:100px;">Autoridades</td>
                                    <td style="width:50px;">Editar</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="8">No se encontraron Solicitudes registrados en el sistema</td>
								</tr>
							</table>
                        </EmptyDataTemplate>
                        <Columns>
                            
                            <asp:BoundField DataField="Expediente" HeaderText="Expediente">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Asunto" HeaderText="Asunto">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaVisitadurias" HeaderText="Fecha Visitadurías">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Visitador" HeaderText="Visitador">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quejosos" HeaderText="Quejosos">
                                <ItemStyle HorizontalAlign="Left"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Autoridades" HeaderText="Autoridades" />
                            <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />

                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
