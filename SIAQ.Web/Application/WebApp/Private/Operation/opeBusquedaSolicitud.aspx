<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Busqueda de Solicitudes
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title">Proporcione los filtros deseados para buscar la solicitud</td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Número de solicitud</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNumeroSolicitud" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Ciudadano</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Forma de contacto</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlFormaContacto" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
                            <td ></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Funcionario</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="cmdGuardar" runat="server" Text="Guardar" OnClick="SearchButton_Click"  CssClass="Button_General_Verde" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="cmdRegresar" runat="server" Text="Regresar" CssClass="Button_General_Verde" width="125px" /></td>
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
               <asp:GridView ID="gvSolicitud" runat="server" AutoGenerateColumns="False"
                        AutoUpdateAfterCallBack="True"
                        UpdateAfterCallBack="True" Width="800px" Style="text-align: center" DataKeyNames="Solicitud"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <Columns>
                            <asp:BoundField DataField="Solicitud" HeaderText="Id" Visible="False"/>
                            <asp:BoundField DataField="Ciudadano" HeaderText="Ciudadano">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FormaContacto" HeaderText="Forma de contacto">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Funcionario" HeaderText="Funcionario">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quejosos" HeaderText="Quejosos">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Servidores" HeaderText="Servidores">
                                <ItemStyle HorizontalAlign="Left"/>
                            </asp:BoundField>
                            <asp:ButtonField CommandName="EDITA" HeaderText="Editar" Text="Editar" />
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
