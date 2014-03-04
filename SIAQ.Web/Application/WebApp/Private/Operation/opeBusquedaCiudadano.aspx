<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeBusquedaCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeBusquedaCiudadano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
 <style type="text/css">
        .TablaCiudadano
        {
            	border-spacing: 5px;
	            font-size:11px;
	            padding: 0px;
	            width: 100%;
	            text-align:left;
            }  
            
        .style1
        {
            width: 236px;
            font-size:13.5px;
        }
        
        .style2
        {
            width: 127px;
        }
        
        .style3
        {
            width: 450px;
        }
     .style4
     {
         width: 140px;
     }
     .style5
     {
         width: 7px;
     }
     .style6
     {
         width: 104px;
     }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Búsqueda de Ciudadanos

			</td>
		</tr>
 </table>
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
        <table border="0px" class="TablaCiudadano">
              <tr>
                <td class="style6" >Nombre</td>
                <td class="style5" ></td>
                <td  ><asp:TextBox ID="TextBoxNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td class="style6">Apellido Paterno</td>
                <td class="style5" ></td>
                <td ><asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td class="style6">Apellido Materno</td>
                <td class="style5" ></td>
                <td><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td class="style6" >País</td>
                <td class="style5"></td>
                <td ><asp:DropDownList ID="BuscadorListaPais" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="style6" >Estado</td>
                <td class="style5" ></td>
                <td><asp:DropDownList ID="BuscadorListaEstado" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="style6" >Municipio</td>
                <td class="style5" ></td>
                <td ><asp:DropDownList ID="BuscadorListaCiudad" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="style6" >Colonia</td>
                <td class="style5" ></td>
                <td ><asp:DropDownList ID="BuscadorListaColonia" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="style6" >Calle</td>
                <td class="style5" ></td>
                <td ><asp:TextBox ID="TextBoxCalle" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
        </table>
        <div style="text-align:left;">
        <br /><br />
        <table width="90%" border="0">
          <tr>
            <td class="style2"><asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="Button_General" OnClick="SearchButton_Click" width="125px"/></td>
            <td class="style3"><asp:Button ID="Button2" runat="server" Text="Cancelar" 
                    CssClass="Button_General" width="125px" onclick="Button2_Click"/></td>
            <td><asp:LinkButton  class="style1" ID="LinkButton1" runat="server" OnClick="BusquedaRapida_Click">Búsqueda rapida</asp:LinkButton></td>
          </tr>
        </table>
        </div>
     </asp:Panel>
     <br /><br />
     <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="790px"
						DataKeyNames="CiudadanoId"
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:200px;">Nombre</td>
									<td style="width:50px;">Sexo</td>
                                    <td style="width:65px;">Fecha Nacimiento</td>
                                    <td style="width:280px;">Domicilio</td>
                                    <td style="width:65px;">Telefono</td>
                                    <td style="width:50px;">Visita</td>
                                    <td style="width:53px;">Solicitud</td>
                                    <td style="width:30px;">Editar</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="9">No se encontraron ciudadanos registradas en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Nombre"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="170px" DataField="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="50px" DataField="SexoNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Fecha Nacimiento"  ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px" DataField="FechaNacimiento"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="280px" DataField="DireccionCompleta"></asp:BoundField>
                            <asp:BoundField HeaderText="Telefono"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px" DataField="TelefonoPrincipal"></asp:BoundField>
								<asp:TemplateField HeaderText="Visita">
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Visita" ID="VisitaLink" runat="server" Text='Visita' Width="80px"></asp:LinkButton>
                                </ItemTemplate>
							</asp:TemplateField>
                            <asp:BoundField HeaderText="Solicitud"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="50px"></asp:BoundField>
							<asp:TemplateField HeaderText="Editar">
                                <ItemTemplate>
                                    <asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Editar" ID="EditarLink" runat="server" Text='Editar' Width="80px"></asp:LinkButton>
                                </ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
</asp:Content>
