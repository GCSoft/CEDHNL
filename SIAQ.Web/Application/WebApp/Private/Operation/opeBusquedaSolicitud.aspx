<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript">

        function NumbersValidator(e) {
            var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
            return (tecla > 47 && tecla < 58);

        }
    </script>

    <style type="text/css">
        .Tamanoletra
        {
          font-size:11px;
          text-align:left;
          height:50px;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Busqueda de Solicitudes
			</td>
		</tr>
      <tr><td class="Tamanoletra">Proporcione los filtros deseados para buscar la solicitud</td></tr>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="cmdGuardar" runat="server" Text="Buscar" OnClick="SearchButton_Click"  CssClass="Button_General" width="125px" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="cmdRegresar" 
                             runat="server" Text="Cancelar" CssClass="Button_General" width="125px" 
                             onclick="cmdRegresar_Click" /></td>
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
                        AutoUpdateAfterCallBack="True" OnRowCommand="gvSolicitud_RowCommand"
                        UpdateAfterCallBack="True" Width="800px" Style="text-align: center" DataKeyNames="SolicitudId"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
							<table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                            	<tr class="Grid_Header">
									<td>Número Solicitud</td>
                                    <td>Ciudadano</td>
                                    <td>Forma Contacto</td>
                                    <td>Funcionario</td>
                                    <td style="width:200px">Detalle queja</td>
                                    <td>Estatus</td>
                                    <td style="width:40px">Editar</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7" >No se encontraron solicitudes registradas en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="NumeroSol" HeaderText="Número Solicitud" />
                            <asp:BoundField DataField="NombreCompleto" HeaderText="Ciudadano">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FormaContactoNombre" HeaderText="Forma de contacto">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreFuncionario" HeaderText="Funcionario">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                           <asp:BoundField DataField="Observaciones" HeaderText="Detalle queja">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreEstatus" HeaderText="Estatus">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%#Eval("SolicitudId")%>' CommandName="Editar" ID="SolicitudLink" runat="server" Text='Editar' Width="40px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
