<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VisRegistroServidorPublico.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.VisRegistroServidorPublico" %>
<%@ Register src="../../../../Include/WebUserControls/wucFastCatalog.ascx" tagname="wucFastCatalog" tagprefix="wuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<table class="GeneralTable">
		<tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				Registro de Servidores Públicos
			</td>
		</tr>
		<tr>
			<td class="SubTitulo">
				<asp:Label ID="Label2" runat="server" Text="Ingrese los datos del Servicor Público"></asp:Label>
			</td>
		</tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Información general</td></tr>
		<tr>
			<td>
			<asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
				<table class="SolicitudTable">
					<tr>
						<td class="Nombre">Nombre</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" MaxLength="100" width="210px" TabIndex="1" ></asp:TextBox>&nbsp;</td>
						<td class="Espacio"></td>
						<td class="Nombre">Edad</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:TextBox ID="txtEdad" runat="server" CssClass="Textbox_General" MaxLength="3" width="50px" TabIndex="10" ></asp:TextBox></td>
					</tr>
					<tr>
						<td class="Nombre">Apellido paterno</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="Textbox_General" MaxLength="100" width="210px" TabIndex="2" ></asp:TextBox>&nbsp;</td>
						<td class="Espacio"></td>
						<td class="Nombre">Sexo</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:DropDownList ID="ddlSexo" runat="server" CssClass="DropDownList_General" width="210px" TabIndex="11" ></asp:DropDownList>&nbsp;</td>
					</tr>
					<tr>
						<td class="Nombre">Apellido materno</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="Textbox_General" MaxLength="100" width="210px" TabIndex="3" ></asp:TextBox></td>
						<td class="Espacio"></td>
						<td class="Nombre">Nacionalidad</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="DropDownList_General" width="210px" TabIndex="12" ></asp:DropDownList>&nbsp;</td>
					</tr>
					<tr>
						<td class="Nombre">País</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td><asp:DropDownList ID="ddlPais" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="true" onselectedindexchanged="ddlPais_SelectedIndexChanged" TabIndex="4" ></asp:DropDownList></td>
									<td style="width:5px;"></td>
									<td><wuc:wucFastCatalog ID="wucFastCatalogPais" runat="server" OnClose="wucFastCatalogPais_Close" OnItemCreated="wucFastCatalogPais_ItemCreated" /></td>
								</tr>
							</table>
						</td>
						<td class="Espacio"></td>
						<td class="Nombre">Escolaridad</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:DropDownList ID="ddlEscolaridad" runat="server" CssClass="DropDownList_General" width="210px" TabIndex="13" ></asp:DropDownList>&nbsp;</td>
					</tr>
					<tr>
						<td class="Nombre">Estado</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td><asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" onselectedindexchanged="ddlEstado_SelectedIndexChanged" TabIndex="5" ></asp:DropDownList></td>
									<td style="width:5px;"></td>
									<td><wuc:wucFastCatalog ID="wucFastCatalogEstado" runat="server" OnClick="wucFastCatalogEstado_Click" OnClose="wucFastCatalogEstado_Close" OnItemCreated="wucFastCatalogEstado_ItemCreated" /></td>
								</tr>
							</table>
						</td>
						<td class="Espacio"></td>
						<td class="Nombre">Ocupación</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:DropDownList ID="ddlOcupacion" runat="server" CssClass="DropDownList_General" width="210px" TabIndex="14" ></asp:DropDownList>&nbsp;</td>
					</tr>
					<tr>
						<td class="Nombre">Ciudad</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td><asp:DropDownList ID="ddlCiudad" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" onselectedindexchanged="ddlCiudad_SelectedIndexChanged" TabIndex="6" ></asp:DropDownList></td>
									<td style="width:5px;"></td>
									<td><wuc:wucFastCatalog ID="wucFastCatalogCiudad" runat="server" OnClick="wucFastCatalogCiudad_Click" OnClose="wucFastCatalogCiudad_Close" OnItemCreated="wucFastCatalogCiudad_ItemCreated" /></td>
								</tr>
							</table>
						</td>
						<td class="Espacio"></td>
						<td class="Nombre">Estado civil</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="DropDownList_General" width="210px" TabIndex="15" ></asp:DropDownList>&nbsp;</td>
						<td class="Espacio"></td>
					</tr>
					<tr>
						<td class="Nombre">Colonia</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo">
							<table border="0" cellpadding="0" cellspacing="0">
								<tr>
									<td><asp:DropDownList ID="ddlColonia" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="7" ></asp:DropDownList></td>
									<td style="width:5px;"></td>
									<td><wuc:wucFastCatalog ID="wucFastCatalogColonia" runat="server" OnClick="wucFastCatalogColonia_Click" OnClose="wucFastCatalogColonia_Close" OnItemCreated="wucFastCatalogColonia_ItemCreated"  /></td>
								</tr>
							</table>
						</td>
						<td class="Espacio"></td>
						<td class="Nombre">Teléfono</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:TextBox ID="txtTelefono" runat="server" CssClass="Textbox_General" MaxLength="15" width="210px" TabIndex="16" ></asp:TextBox>&nbsp;</td>
					</tr>
					<tr>
						<td class="Nombre">Calle y Número</td>
						<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
						<td class="Campo"><asp:TextBox ID="txtCalle" runat="server" CssClass="Textbox_General" width="210px" MaxLength="1000" TabIndex="8" ></asp:TextBox></td>
						<td class="Espacio"></td>
						<td class="Nombre">Correo electrónico</td>
						<td class="Espacio"></td>
						<td class="Campo"><asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="Textbox_General" MaxLength="50" width="210px" TabIndex="17" ></asp:TextBox></td>
					</tr>
				</table>
			</asp:Panel>
			</td>
		</tr>
		<tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Autoridad</td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioAutoridad" runat="server" Visible="true" Width="100%">
                    <table class="SolicitudTable">
                        <tr>
							<td class="Nombre">Autoridad nivel 1</td>
							<td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
							<td style="text-align:left;"><asp:DropDownList ID="ddlAutoridadNivel1" runat="server" CssClass="DropDownList_General" width="570px" AutoPostBack="True" OnSelectedIndexChanged="ddlAutoridadNivel1_SelectedIndexChanged" TabIndex="18" ></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Nombre">Autoridad nivel 2</td>
							<td class="Espacio"></td>
							<td style="text-align:left;"><asp:DropDownList ID="ddlAutoridadNivel2" runat="server" CssClass="DropDownList_General" width="570px" AutoPostBack="True" OnSelectedIndexChanged="ddlAutoridadNivel2_SelectedIndexChanged" TabIndex="19" ></asp:DropDownList></td>
						</tr>
						<tr>
							<td class="Nombre">Autoridad nivel 3</td>
							<td class="Espacio"></td>
							<td style="text-align:left;"><asp:DropDownList ID="ddlAutoridadNivel3" runat="server" CssClass="DropDownList_General" width="570px" TabIndex="20" ></asp:DropDownList></td>
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
							<asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="Button_General" width="125px" onclick="btnAceptar_Click" /> &nbsp;&nbsp;
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
