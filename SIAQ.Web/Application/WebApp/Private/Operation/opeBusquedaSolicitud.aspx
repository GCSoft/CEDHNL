<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
   <script type="text/javascript">
      
      // Funciones del programador
      function NumbersValidator(e) {
         
         var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
         return (tecla > 47 && tecla < 58);
      }

   </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table class="GeneralTable">
      <tr>
         <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
            Buscar solicitud
         </td>
		</tr>
      <tr><td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione los filtros deseados para buscar la solicitud."></asp:Label></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
               <table  border="0" style="width: 460px">
                     <tr>
                        <td class="Etiqueta">Número de solicitud</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:TextBox ID="txtNumeroSolicitud" runat="server" CssClass="Textbox_General" width="211px" ></asp:TextBox></td>
                     </tr>
                     <tr>
                        <td class="Etiqueta">Nombre del Ciudadano</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" width="211px" ></asp:TextBox></td>
                     </tr>
                     <tr>
                        <td class="Etiqueta">Forma de contacto</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:DropDownList ID="ddlFormaContacto" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
                     </tr>
                     <tr>
                        <td class="Etiqueta">Funcionario</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="DropDownList_General" width="216px"></asp:DropDownList></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="cmdRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="cmdRegresar_Click" /></td>
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
               <asp:GridView ID="gvSolicitud" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="800px"
                  DataKeyNames="SolicitudId,NumeroSol"
                  OnRowCommand="gvSolicitud_RowCommand"
                  OnRowDataBound="gvSolicitud_RowDataBound"
                  OnSorting="gvSolicitud_Sorting">
                  <alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
                     <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                        <tr class="Grid_Header">
                           <td style="width:60px;">Número Solicitud</td>
									<td style="width:130px;">Ciudadano</td>
                           <td style="width:80px;">Forma Contacto</td>
                           <td style="width:130px;">Funcionario</td>
									<td style="width:260px;">Detalle Queja</td>
                           <td style="width:140px;">Estatus</td>
                        </tr>
								<tr class="Grid_Row">
                           <td colspan="6" >No se encontraron solicitudes registradas en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
                  <Columns>
                     <asp:BoundField HeaderText="Número Solicitud"   ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="60px"  DataField="NumeroSol"            SortExpression="NumeroSol"></asp:BoundField>
                     <asp:BoundField HeaderText="Ciudadano"          ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="130px" DataField="NombreCompleto"       SortExpression="NombreCompleto"></asp:BoundField>
                     <asp:BoundField HeaderText="Forma Contacto"     ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="80px"  DataField="FormaContactoNombre"  SortExpression="FormaContactoNombre"></asp:BoundField>
                     <asp:BoundField HeaderText="Funcionario"        ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="130px" DataField="NombreFuncionario"    SortExpression="NombreFuncionario"></asp:BoundField>
                     <asp:BoundField HeaderText="Detalle Queja"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="260px" DataField="Observaciones"        SortExpression="Observaciones"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"            ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="120px"  DataField="NombreEstatus"        SortExpression="NombreEstatus"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
								<ItemTemplate>
                           <asp:ImageButton ID="imgEdit" CommandArgument='<%#Eval("SolicitudId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
                        </ItemTemplate>
							</asp:TemplateField>
                  </Columns>
               </asp:GridView>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
   <asp:HiddenField ID="hddSort" runat="server" value="NumeroSol" />
</asp:Content>
