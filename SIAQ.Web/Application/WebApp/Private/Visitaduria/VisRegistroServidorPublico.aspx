<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VisRegistroServidorPublico.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.VisRegistroServidorPublico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registro de Servidores Públicos
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
                            <td class="tdCeldaItem"><asp:TextBox ID="txtEdad" runat="server" CssClass="DropDownList_General" width="50px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Apellido paterno</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Sexo</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlSexo" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Apellido materno</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nacionalidad</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Nombre calle</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtCalle" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Escolaridad</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlEscolaridad" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Colonia</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:TextBox ID="txtColonia" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Ocupación</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlOcupacion" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;País</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlPais" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Estado civil</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Estado</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Teléfono</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:TextBox ID="txtTelefono" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Ciudad</td>
							<td style="width:5px;"></td>
							<td class="tdCeldaItem"><asp:DropDownList ID="ddlCiudad" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Correo electrónico</td>
                            <td style="width:5px;"></td>
                            <td class="tdCeldaItem"><asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="Textbox_General" width="150px" ></asp:TextBox></td>
                            <td style="width:5px;"></td>
						</tr>
                        <tr class="trFilaItem"><td colspan = "8"><hr /></td></tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Autoridad nivel 1</td>
							<td style="width:5px;"></td>
							<td colspan="6" style="text-align:left;"><asp:DropDownList ID="ddlAutoridadNivel1" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList>&nbsp;<font class="MarcadorObligatorio">&nbsp;*</font></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Autoridad nivel 2</td>
							<td style="width:5px;"></td>
							<td colspan="6" style="text-align:left;"><asp:DropDownList ID="ddlAutoridadNivel2" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList></td>
						</tr>
                        <tr class="trFilaItem">
							<td class="tdCeldaLeyendaItemFondoBlanco">&nbsp;Autoridad nivel 3</td>
							<td style="width:5px;"></td>
							<td colspan="6" style="text-align:left;"><asp:DropDownList ID="ddlAutoridadNivel3" runat="server" CssClass="DropDownList_General" width="150px"></asp:DropDownList></td>
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
					<tr><td class="tdCeldaMiddleSpace"></td></tr>
					<tr>
						<td style="text-align: left;">
							<asp:Button ID="btnAceptar" runat="server" Text="Nuevo" CssClass="Button_General" width="125px" onclick="btnAceptar_Click" /> &nbsp;&nbsp;
							<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
						</td>
					</tr>
				</table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="trFilaFooter"></td></tr>
   </table>

   <asp:HiddenField ID="hddServidorPublicoId" runat="server" Value="0"  />
   <asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
   <asp:HiddenField ID="SenderId_Level1" runat="server" Value="0"  />
   <asp:HiddenField ID="SenderId_Level2" runat="server" Value="0"  />

</asp:Content>
