<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroCiudadano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registro de Ciudadanos
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nombre</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Edad</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:TextBox ID="txtEdad" runat="server" CssClass="Textbox_General" width="50px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Apellido paterno</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtAPaaterno" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Sexo</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlSexo" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Apellido materno</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtAMaterno" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nacionalidad</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nombre calle</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtCalle" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Escolaridad</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlEscolaridad" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Colonia</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtColonia" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Ocupación</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlOcupacion" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;País</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlPais" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Estado Cívil</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;</td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Estado</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlEstado" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Teléfono</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:TextBox ID="TextBox2" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr style=" height:3px;"><td colspan="8"></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Ciudad</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlCiudad" runat="server" CssClass="Textbox_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Correo electrónico</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:TextBox ID="txtEmail" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;</td>
                            <td style="width:5px;"></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="Button_General_Verde" width="125px" /></td>
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
               <!-- GRID -->
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>
