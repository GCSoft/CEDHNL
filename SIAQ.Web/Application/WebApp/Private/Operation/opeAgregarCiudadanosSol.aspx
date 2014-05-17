<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarCiudadanosSol.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarCiudadanosSol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;">
        <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Agregar ciudadanos a la solicitud
			</td>
		</tr>
      <tr><td class="MiddleSpace"></td></tr>
      <tr style="font-size:11px;">
         <td>
         Realice una búsqueda para agregar ciudadanos a la solicitud. 
         </td>
      </tr>
      <tr><td class="MiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlBusquedaSimple" runat="server" Visible="true" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="Solicitud">Solicitud número</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabelSearch" runat="server" Text="0"></asp:Label></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem">
                            <asp:Button ID="btnBuscar" runat="server" OnClick="QuickSearchButton_Click" CssClass="Button_General" Text="Buscar" Width="120px"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkBusquedaAvanzada" CssClass="Tamanoletra" runat="server"  
                                Text="Busqueda avanzada" onclick="BusquedaAvanzada_Click"></asp:LinkButton>
                        </td>
                        <td style="width:5px;"></td>
                    </tr>   
                </table>
            </asp:Panel>
      <asp:Panel id="pnlBusqedaAvanzada" runat="server" Width="100%" Visible="false" CssClass="tdTituloEncabezado">
        <table border="0px" class="TablaCiudadano">
             <tr>
                <td class="TextoSolNum">Solicitud número</td>
                <td style="width:5px;"></td>
                <td class="tdCeldaItem"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" ></asp:Label></td>
                <td style="width:5px;"></td>
             </tr>
             <tr><td class="CeldaEspacioGrandeAncho"></td></tr>
              <tr>
                <td class="AnchoCeldaPrincipal" >Nombre</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td  ><asp:TextBox ID="TextBoxNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal">Apellido Paterno</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td ><asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal">Apellido Materno</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal" >País</td>
                <td class="EspacioCeldaIntermedia"></td>
                <td ><asp:DropDownList ID="BuscadorListaPais" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal" >Estado</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td><asp:DropDownList ID="BuscadorListaEstado" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal" >Municipio</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td ><asp:DropDownList ID="BuscadorListaCiudad" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal" >Colonia</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td ><asp:DropDownList ID="BuscadorListaColonia" width="214px" runat="server"></asp:DropDownList></td>
              </tr>
              <tr>
                <td class="AnchoCeldaPrincipal" >Calle</td>
                <td class="EspacioCeldaIntermedia" ></td>
                <td ><asp:TextBox ID="TextBoxCalle" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
              </tr>
        </table>
        <div style="text-align:left;">
        <br /><br />
        <table width="90%" border="0">
          <tr>
            <td class="tdBotonBuscar"><asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="Button_General" OnClick="SearchButton_Click" width="125px"/></td>
            <td class="EspacioCeldaMediano"></td>
            <td><asp:LinkButton  class="EstiloBR" ID="LinkButton1" runat="server" OnClick="BusquedaRapida_Click">Búsqueda rapida</asp:LinkButton></td>
          </tr>
        </table>
        </div>
     </asp:Panel>
         </td>
         <td rowspan="5" valign="top" style="width:200px;">
         <table width="100%" border="0">
              <tr>
                <td class="MiddleSpace"></td>
                <td style="border:0px">
                     <table width="100%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td style="background-color:#DDDDFF; height:30px; font-size:10px; border:0px; text-align:center;"> &nbsp;Ciudadanos agregados a la Solicitud&nbsp;</td>
                          </tr>
                          <tr>
                            <td style="height:175px; background-color:#EFF2FB; vertical-align: top;"> <!--aqui se estaran ingresando los ciudadanos agregados-->
                               <asp:GridView id="gvCiudadanosAgregados" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False"
                                 DataKeyNames="CiudadanoId" OnRowCommand="gvCiudadanoAgregados_RowCommand" BorderWidth="0"> 
                                <headerstyle cssclass="Grid_Encabezado" />
                                <rowstyle cssclass="Grid_Filas" />
                                <EmptyDataRowStyle CssClass="Empty" BorderStyle="None" BorderWidth="0px" />
                                 <EmptyDataTemplate>
                                    <table border="0px" cellpadding="0" style="border:0px;" cellspacing="0">
                                      <tr>
                                        <td style="height:5px"></td>
                                      </tr>
                                      <tr>
                                        <td style="font-size:9.5px; text-align:center;"> No se han agregado ciudadanos a la solicitud</td>
                                      </tr>
                                      <tr>
                                        <td style="height:130px;"></td>
                                      </tr>
                                    </table>
                                 </EmptyDataTemplate>
                                 <Columns>
                                 <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:LinkButton Width="150px" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="SelectCiudadano" ID="CiudadanoButton" runat="server" Text='<%#Eval("NombreCompleto")%>'></asp:LinkButton>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                 <asp:TemplateField>
                                 <ItemTemplate>
                                 <asp:ImageButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Eliminar"  runat="server" ID="ImagenEliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" Height="11px"> </asp:ImageButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 </Columns>
                                </asp:GridView>
                            </td>
                          </tr>
                     </table>
                </td>
              </tr>
            </table>

         </td>
      </tr>
    <tr><td class="tdCeldaMiddleSpace"></td></tr>
    <tr>
        <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView id="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False"
						DataKeyNames="CiudadanoId"
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand"
                  OnSorting="gvCiudadano_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px; text-align:center;">Nombre</td>
									<td style="width:70px; text-align:center;">Sexo</td>
                           <td style="width:100px; text-align:center;">Fecha Nacimiento</td>
                           <td style="width:200px; text-align:center;">Domicilio</td>
                           <td style="width:70px; text-align:center;" ></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="9"  style="text-align:center;">No se encontraron ciudadanos registradas en el sistema</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Nombre"             ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="170px" DataField="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"               ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="50px" DataField="SexoNombre"></asp:BoundField>
                     <asp:BoundField HeaderText="Fecha Nacimiento"   ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px" DataField="FechaNacimiento"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"          ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="280px" DataField="DireccionCompleta"></asp:BoundField>
                     <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                           <asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Agregar" ID="AgregarLink" runat="server" Text='Agregar' Width="80px"></asp:LinkButton>
                        </ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
            </asp:Panel>
        </td>
        <td></td>
    </tr>
    <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="height:24px; text-align:left; width:130px;">
                        <asp:Button ID="btnNuevoCiudadano" runat="server" Text="Nuevo Ciudadano" CssClass="Button_General" onclick="btnNuevoCiudadano_Click" Width="125px" />&nbsp;&nbsp;
                        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" onclick="btnRegresar_Click" Width="125px" />
                     </td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
    </table>
    <asp:HiddenField ID="SolicitudIDHidden" runat="server" Value="" />
    <asp:HiddenField ID="hddSort" runat="server" value="NombreCompleto" />
</asp:Content>
