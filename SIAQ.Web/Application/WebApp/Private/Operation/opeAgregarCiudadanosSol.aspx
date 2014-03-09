<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarCiudadanosSol.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarCiudadanosSol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
            .Solictud
            { 
                height: 35px;
                width: 175px;
                color:#979393;
	            font-family:Verdana;
	            font-size:13px;
	            font-weight:bold;
	            height: 27px;
	            text-align:left;
            }
            
            .MiddleSpace
            {
	            height:7px;
            }
                        
             .Tamanoletra
            {
              font-size:13.5px;
              text-align:left;
              height:50px;
            }
        
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
                width: 251px;
            }
             .style5
             {
                 width: 7px;
             }
             .style6
             {
                 width: 104px;
             }
             
             .gv
             {
                 border: 0px;
             }
          </style>
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
                        <td style="font-size:12px">Solicitud número:</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:Label ID="lblNumSolicitud" runat="server"></asp:Label></td>
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
                <td class="Solicitud">Solicitud número:</td>
                <td style="width:5px;"></td>
                <td class="tdCeldaItem"><asp:Label ID="Label1" runat="server"></asp:Label></td>
                <td style="width:5px;"></td>
             </tr>
             <tr><td class="MiddleSpace"></td></tr>
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
            <td class="style3"></td>
            <td><asp:LinkButton  class="style1" ID="LinkButton1" runat="server" OnClick="BusquedaRapida_Click">Búsqueda rapida</asp:LinkButton></td>
          </tr>
        </table>
        </div>
     </asp:Panel>
         </td>
         <td rowspan="5" valign="top" style="width:200px;">
         <table width="100%" border="0">
              <tr>
                <td class="MiddleSpace"></td>
                <td>
                     <table width="100%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td style="background-color:#DDDDFF; height:30px; font-size:10px; border:0px; text-align:center;"> &nbsp;Ciudadanos agregados a la Solicitud&nbsp;</td>
                          </tr>
                          <tr>
                            <td style="height:175px; background-color:#EFF2FB;"> <!--aqui se estaran ingresando los ciudadanos agregados-->
                               <asp:GridView CssClass="gv" id="gvCiudadanosAgregados" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False"
                                 DataKeyNames="CiudadanoId">
                                 <EmptyDataTemplate>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                      <tr>
                                        <td style="font-size:9.5px; text-align:center;"> No se han agregado ciudadanos a la solicitud</td>
                                      </tr>
                                      <tr>
                                        <td style="height:130px;"></td>
                                      </tr>
                                    </table>
                                 </EmptyDataTemplate>
                                 <Columns>
                                 <asp:BoundField HeaderText="Nombre" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="170px" DataField="NombreCompleto"></asp:BoundField>
                                 <asp:TemplateField HeaderText="Eliminar">
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
               <asp:GridView id="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False"
						DataKeyNames="CiudadanoId"
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand">
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
							<asp:BoundField HeaderText="Nombre"         ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="170px" DataField="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="50px" DataField="SexoNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Fecha Nacimiento"  ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px" DataField="FechaNacimiento"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"  ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="280px" DataField="DireccionCompleta"></asp:BoundField>
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
                        <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=1004';" style="width: 125px;" type="button" value="Regresar" />
                     </td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
    </table>
    <asp:HiddenField ID="SolicitudIDHidden" runat="server" Value="" />
</asp:Content>
