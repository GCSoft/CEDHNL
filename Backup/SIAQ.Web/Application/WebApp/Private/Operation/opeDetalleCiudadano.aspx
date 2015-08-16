<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeDetalleCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleCiudadano" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">Detalle ciudadano</td>
        </tr>
        <tr>
            <td class="SubTitulo">
				<asp:Label ID="lblSubTitulo" runat="server" Text="Detalle de los datos del ciudadano"></asp:Label>
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
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Escolaridad</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblEscolaridad" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Apellido paterno</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblApellidoPaterno" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Estado civil</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblEstadoCivil" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Apellido materno</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblApellidoMaterno" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Teléfono principal</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblTelefonoPrincipal" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Sexo</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblSexo" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Otro teléfono</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblOtroTelefono" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Edad</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblEdad" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Correo electrónico</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblCorreoElectronico" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Nacionalidad</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblNacionalidad" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Dependientes económicos</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblDependientesEconomicos" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Ocupación</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblOcupacion" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Forma de enterarse de la CEDH</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblFormaEnterarse" runat="server" Text=""></asp:Label></td>
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
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblPais" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Nombre calle</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblCalle" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Estado</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblEstado" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Núm exterior</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblNoExterior" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Ciudad</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblCiudad" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Núm interior</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblNumInterior" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="Nombre">Colonia</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblColonia" runat="server" Text=""></asp:Label></td>
                            <td class="Espacio"></td>
                            <td class="Nombre">Años residiendo en NL</td>
                            <td class="Espacio"></td>
                            <td class="Etiqueta"><asp:Label ID="lblAniosResidiendoNL" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Solicitudes de intervención</td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSolicitudes" runat="server" Width="100%">
                    <asp:GridView ID="gvSolicitudes" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="SolicitudId"
                        OnRowDataBound="gvSolicitudes_RowDataBound" 
                        OnSorting="gvSolicitudes_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:100px;">Solicitud</td>
									<td style="width:100px;">Expediente</td>
									<td style="width:70px;">Fecha</td>
									<td style="width:120px;">Tipo de Solicitud</td>
									<td style="width:120px;">Tipo de Participación</td>
									<td style="width:70px;">Estuvo Presente</td>
                                    <td>Calificación</td>
                                    <td style="width:150px;">Estatus</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="8">No se encontraron solicitudes en las que haya participado el ciudadano</td>
								</tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Solicitud"				ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="SolicitudNumero"			SortExpression="SolicitudNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Expediente"				ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="ExpedienteNumero"		SortExpression="ExpedienteNumero"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"					SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Solicitud"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="TipoSolicitudNombre"		SortExpression="TipoSolicitudNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Participación"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="TipoParticipacionNombre"	SortExpression="TipoParticipacionNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Estuvo Presente"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Presente"				SortExpression="Presente"></asp:BoundField>
							<asp:BoundField HeaderText="Calificación"			ItemStyle-HorizontalAlign="Left"							DataField="CalificacionNombre"		SortExpression="CalificacionNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"				ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="EstatusNombre"			SortExpression="EstatusNombre"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr><td style="background-color: #CCCCCC; text-align: left;">Visitas a la CEDH</td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlVisitas" runat="server" Width="100%">
                    <asp:GridView ID="gvVisitas" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="VisitaId" 
                        OnRowDataBound="gvVisitas_RowDataBound"
						OnSorting="gvVisitas_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:70px;">Fecha</td>
									<td style="width:120px;">Área Visitada</td>
                                    <td style="width:200px;">Funcionario Visitado</td>
                                    <td style="width:120px;">Motivo de Visita</td>
									<td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="5">No se encontraron visitas del ciudadano seleccionado</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Área Visitada"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="120px"	DataField="AreaNombre"									SortExpression="AreaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario Visitado"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="200px"	DataField="FuncionarioNombre"							SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Motivo de Visita"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="120px"	DataField="MotivoVisitaNombre"							SortExpression="MotivoVisitaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"				ItemStyle-HorizontalAlign="Left"							DataField="Detalle"					HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
		<tr>
			<td>
				<asp:Panel id="pnlBotones" runat="server" Width="100%">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" CssClass="Button_General" Text="Regresar" Width="125px" OnClick="btnRegresar_Click" /></td>
							<td style="height:24px;"></td>
						</tr>
					</table>
			</asp:Panel>
			</td>
		</tr>
        <tr class="trFilaFooter"><td></td></tr>
    </table>

    <asp:HiddenField ID="hddCiudadanoId" runat="server" />
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />

</asp:Content>
