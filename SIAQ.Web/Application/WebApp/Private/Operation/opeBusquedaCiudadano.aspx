<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaCiudadano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
 <style type="text/css">
        .style1
        {
            width: 236px;
        }
        .style2
        {
            width: 127px;
        }
        .style3
        {
            width: 450px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Catálogo de Operación - Búsqueda de Ciudadanos

			</td>
		</tr>
 </table>
 <br />
 <div style="text-align:left;">
 <asp:Label ID="Label1" runat="server">Búsqueda de Ciudadanos</asp:Label>
 </div>
  <br />
  <asp:Panel id="pnlBusquedaSimple" runat="server" Width="100%" Visible="true">
    <table>
       <tr>
         <td ><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
         <td style="width:25px;"></td>
         <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="Button_General" width="125px" OnClick="QuickSearchButton_Click" /></td>
         <td style="width:190px;"></td>
         <td ><asp:LinkButton  class="style1" ID="btnBusqueda" runat="server" OnClick="BusquedaAvanzada_Click">Búsqueda avanzada</asp:LinkButton></td> 
       </tr>
     </table> 
     </asp:Panel>
     <asp:Panel id="pnlBusqedaAvanzada" runat="server" Width="100%" Visible="false" CssClass="tdTituloEncabezado">
        <table border="0px" class="tdBusquedaAvanzada">
              <tr>
                <td >Nombre</td>
                <td ></td>
                <td  ><asp:TextBox ID="TextBoxNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td>Apellido Paterno</td>
                <td ></td>
                <td ><asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td>Apellido Materno</td>
                <td ></td>
                <td><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td >País</td>
                <td></td>
                <td ><asp:DropDownList ID="BuscadorListaPais" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td >Estado</td>
                <td ></td>
                <td><asp:DropDownList ID="BuscadorListaEstado" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td >Municipio</td>
                <td ></td>
                <td ><asp:DropDownList ID="BuscadorListaCiudad" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td >Colonia</td>
                <td ></td>
                <td ><asp:DropDownList ID="BuscadorListaColonia" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td >Calle</td>
                <td ></td>
                <td ><asp:TextBox ID="TextBoxCalle" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
        </table>
        <div style="text-align:left;">
        <br /><br />
        <table width="90%" border="0">
          <tr>
            <td class="style2"><asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="Button_General" OnClick="SearchButton_Click" width="125px"/></td>
            <td class="style3"><asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="Button_General" width="125px"/></td>
            <td><asp:LinkButton  class="style1" ID="LinkButton1" runat="server" OnClick="BusquedaRapida_Click">Búsqueda rapida</asp:LinkButton></td>
          </tr>
        </table>
        </div>
     </asp:Panel>
     <br /><br />
     <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						DataKeyNames="idCiudadano"
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px;">Nombre</td>
									<td style="width:20px;">Sexo</td>
                                    <td style="width:100px;">Fecha Nacimiento</td>
                                    <td style="width:220px;">Domicilio</td>
                                    <td style="width:100px;">Telefono</td>
                                    <td style="width:100px;">Visita</td>
                                    <td style="width:100px;">Solicitud</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron ciudadanos registradas en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Nombre"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="50px" DataField="SexoNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Fecha Nacimiento"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="FechaNacimiento"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="100px" DataField="DireccionCompleta"></asp:BoundField>
                            <asp:BoundField HeaderText="Telefono"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px" DataField="TelefonoPrincipal"></asp:BoundField>
							<asp:BoundField HeaderText="Visita"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="100px" DataField="sDescripcion"></asp:BoundField>
                            <asp:BoundField HeaderText="Solicitud"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="100px"></asp:BoundField>
                             <asp:BoundField HeaderText="Estatus"      ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100px" DataField="sEstatus"></asp:BoundField>
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
</asp:Content>
