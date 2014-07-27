<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroCiudadano" %>
<%@ Register src="../../../../Include/WebUserControls/wucFastCatalog.ascx" tagname="wucFastCatalog" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Registrar ciudadano
            </td>
        </tr>
        <tr>
			<td class="SubTitulo">
				<asp:Label ID="Label2" runat="server" Text="Ingrese los datos del ciudadano"></asp:Label>
			</td>
		</tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Información general</td></tr>
		<tr>
            <td>
                <asp:Panel ID="pnlFormularioInfoGral" runat="server" Visible="true" Width="100%">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Nombre"></td>
                            <td class="Espacio"></td>
                            <td class="Espacio"></td>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Nombre</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" Width="210px" TabIndex="1" MaxLength="50"></asp:TextBox></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Escolaridad</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:DropDownList ID="ddlEscolaridad" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="8"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Apellido paterno</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="Textbox_General" Width="210px" TabIndex="2" MaxLength="50"></asp:TextBox></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Estado civil</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="9"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Apellido materno</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="Textbox_General" Width="210px" TabIndex="3" MaxLength="50"></asp:TextBox></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Teléfono principal</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:TextBox ID="txtTelefonoPrincipal" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="10" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Sexo</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:DropDownList ID="ddlSexo" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="4"></asp:DropDownList></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Otro teléfono</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtOtroTelefono" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="11" MaxLength="15"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Edad</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:TextBox ID="txtEdad" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="5" Text="0" MaxLength="3"></asp:TextBox></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Correo electrónico</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="Textbox_General" Width="210px" TabIndex="12" MaxLength="50"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Nacionalidad</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="6"></asp:DropDownList></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Dependientes económicos</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtDependientesEconomicos" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="13" MaxLength="3"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Ocupación</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:DropDownList ID="ddlOcupacion" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="7"></asp:DropDownList></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Forma de enterarse de la CEDH</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:DropDownList ID="ddlFormaEnterarse" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="14"></asp:DropDownList></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Domicilio</td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioDomicilio" runat="server" Visible="true" Width="100%">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Nombre"></td>
                            <td class="Espacio"></td>
							<td class="Espacio"></td>
							<td colspan="4"></td>
						</tr>
                        <tr>
                            <td class="Nombre">País</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlPais" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="true" onselectedindexchanged="ddlPais_SelectedIndexChanged" TabIndex="15"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogPais" runat="server" OnClose="wucFastCatalogPais_Close" OnItemCreated="wucFastCatalogPais_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Nombre calle</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo"><asp:TextBox ID="txtNombreCalle" runat="server" CssClass="Textbox_General" Width="210px" TabIndex="19" MaxLength="50"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Estado</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlEstado" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" onselectedindexchanged="ddlEstado_SelectedIndexChanged" TabIndex="16"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogEstado" runat="server" OnClick="wucFastCatalogEstado_Click" OnClose="wucFastCatalogEstado_Close" OnItemCreated="wucFastCatalogEstado_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Núm exterior</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtNumExterior" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="20" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Ciudad</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlCiudad" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" onselectedindexchanged="ddlCiudad_SelectedIndexChanged" TabIndex="17"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogCiudad" runat="server" OnClick="wucFastCatalogCiudad_Click" OnClose="wucFastCatalogCiudad_Close" OnItemCreated="wucFastCatalogCiudad_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Núm interior</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtNumInterior" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="21" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Colonia</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlColonia" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="18"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogColonia" runat="server" OnClick="wucFastCatalogColonia_Click" OnClose="wucFastCatalogColonia_Close" OnItemCreated="wucFastCatalogColonia_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Años residiendo en NL</td>
                            <td class="Espacio"></td>
                            <td class="Campo"><asp:TextBox ID="txtAniosResidiendo" runat="server" CssClass="Textbox_General" Width="108px" TabIndex="22" MaxLength="3"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Información de origen</td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlFormularioInformacionOrigen" runat="server" Visible="true" Width="100%">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Nombre" style="width:150px"></td>
                            <td class="Espacio"></td>
                            <td class="Espacio"></td>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td class="Nombre">País</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlPaisOrigen" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" onselectedindexchanged="ddlPaisOrigen_SelectedIndexChanged" TabIndex="23"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogPaisOrigen" runat="server" OnClose="wucFastCatalogPaisOrigen_Close" OnItemCreated="wucFastCatalogPaisOrigen_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre"></td>
                            <td class="Espacio"></td>
                            <td class="Campo" style="width:215px"></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Estado</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlEstadoOrigen" runat="server" CssClass="DropDownList_General" Width="216px" AutoPostBack="True" onselectedindexchanged="ddlEstadoOrigen_SelectedIndexChanged" TabIndex="24"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogEstadoOrigen" runat="server" OnClick="wucFastCatalogEstadoOrigen_Click" OnClose="wucFastCatalogEstadoOrigen_Close" OnItemCreated="wucFastCatalogEstadoOrigen_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre"></td>
                            <td class="Espacio"></td>
                            <td class="Campo" style="width:215px"></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Ciudad</td>
                            <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                            <td class="Campo">
								<table border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td><asp:DropDownList ID="ddlCiudadOrigen" runat="server" CssClass="DropDownList_General" Width="216px" TabIndex="25"></asp:DropDownList></td>
										<td style="width:5px;"></td>
										<td><wuc:wucFastCatalog ID="wucFastCatalogCiudadOrigen" runat="server" OnClick="wucFastCatalogCiudadOrigen_Click" OnClose="wucFastCatalogCiudadOrigen_Close" OnItemCreated="wucFastCatalogCiudadOrigen_ItemCreated"  /></td>
									</tr>
								</table>
							</td>
                            <td class="Espacio"></td>
                            <td class="Nombre"></td>
                            <td class="Espacio"></td>
                            <td class="Campo" style="width:215px"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
				<asp:Panel ID="pnlFormularioBotones" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr style="height:24px;">
                            <td style="text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" Width="125px" onclick="btnGuardar_Click" /></td>
                            <td style="text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" Width="125px" onclick="btnRegresar_Click" /></td>
                            <td></td>
                        </tr>
						<tr style="height:10px;"><td colspan="3"></td></tr>
                        <tr>
                            <td colspan="3" style="text-align:left">Los campos marcados con <font class="MarcadorObligatorio">&nbsp;*</font> son obligatorios</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

    <asp:HiddenField ID="hdnCiudadanoId" runat="server" />
    <asp:HiddenField ID="hddSolicitudId" runat="server" />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
