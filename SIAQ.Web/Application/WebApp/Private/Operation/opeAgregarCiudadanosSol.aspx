<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarCiudadanosSol.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarCiudadanosSol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
           .style5
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
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;">
        <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Agregar ciudadanos a la solicitud
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
         Realice una búsqueda para agregar ciudadanos a la solicitud.
         <br /><br />
         </td>      
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td class="style5">Solicitud número:</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem"><asp:Label ID="lblNumSolicitud" runat="server"></asp:Label></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style="height:10px;"><td colspan="3"></td></tr>
                     <tr>
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:TextBox ID="txtAgrega" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaItem">
                            <asp:Button ID="btnBuscar" runat="server" CssClass="Button_General" Text="Buscar" Width="120px"></asp:Button>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lnkBusquedaAvanzada" runat="server"  Text="Busqueda avanzada"></asp:LinkButton>
                        </td>
                        <td style="width:5px;"></td>
                    </tr>   
                </table>
            </asp:Panel>
         </td>
         <td style="width:20px;"></td>
         <td rowspan="5" valign="top" style="width:200px;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="background-color:#DDDDFF; font-size:10px; border:1px solid #333333;">Ciudadanos agregados a la Solicitud</td>
                </tr>
                <tr>
                    <td style="background-color:#FBFBFF; font-size:10px; border:1px solid #333333;">
                        <asp:CheckBoxList ID="chkListCiudadanos" runat="server"></asp:CheckBoxList>
                    </td>
                </tr>
            </table>
         </td>
      </tr>
    <tr><td class="tdCeldaMiddleSpace"></td></tr>
    <tr>
        <td valign="top">
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView ID="gvApps" runat="server" AutoGenerateColumns="False"
                        AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="600px" 
                        Style="text-align: center" DataKeyNames="CiudadanoId"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:200px;">Nombre</td>
									<td style="width:100px;">Sexo</td>
                                    <td style="width:100px;">Fecha nacimiento</td>
                                    <td style="width:100px;">Domicilio</td>
                                    <td style="width:100px;">Agregar</td>
                                </tr>
								<tr class="Grid_Row">
									<td colspan="8">No se encontraron ciudadanos registrados en el sistema</td>
								</tr>
							</table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="idCiudadano" HeaderText="idCiudadano" Visible="false" />
                            <asp:ButtonField CommandName="Detalle" DataTextField="Numero" HeaderText="Expediente" runat="server" ItemStyle-Width="50px"/>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="200px"></asp:BoundField>
                            <asp:BoundField DataField="Sexo" HeaderText="Sexo" ItemStyle-Width="100px"></asp:BoundField>
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento" ItemStyle-Width="100px"></asp:BoundField>
                            <asp:BoundField DataField="Domicilio" HeaderText="Domicilio" ItemStyle-Width="100px"></asp:BoundField>
                            <asp:BoundField DataField="Agregar" HeaderText="Agregar" ItemStyle-Width="100px"></asp:BoundField>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px"/></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
    </table>


</asp:Content>
