<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicDetalleAtencion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicDetalleAtencion" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle de Atención
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Proporcione la información solicitada para dar seguimiento a la atención."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="pnlInformacion" runat="server" Visible="true">
            <asp:ImageButton ID="cmdInformacionGeneral" ImageUrl="~/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="cmdInformacionGeneral_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
		 <asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar doctor
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="pnlDictamenMedico" runat="server" Visible="true">
            <asp:ImageButton ID="cmdDictamenMedico" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="cmdDictamenMedico_Click"></asp:ImageButton><br />
            Dictámen Médico
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="pnlAgregarDocumento" runat="server" Visible="true">
            <asp:ImageButton ID="cmdAgregarDocumento" ImageUrl="~/Include/Image/Icon/SeguimientoIcon.png" runat="server" OnClick="cmdAgregarDocumento_Click"></asp:ImageButton><br />
            Agregar Documento
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="CerrarExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="CerrarExpedienteButton" ImageUrl="~/Include/Image/Icon/CerrarExpedienteIcon.png" runat="server" OnClick="CerrarExpedienteButton_Click"></asp:ImageButton><br />
            Cerrar Expediente de Atención
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ConfirmarCierreExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="ConfirmarCierreExpedienteButton" ImageUrl="~/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="ConfirmarCierreExpedienteButton_Click"></asp:ImageButton><br />
            Confirmar Cierre de Expediente de Atención
        </asp:Panel>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Atención número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AtencionNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Expediente número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ExpedienteNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre"></td>
				<td class="Espacio"></td>
				<td class="Etiqueta"></td>
			</tr>
			<tr>
				<td class="Nombre">Solicitud número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="SolicitudNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre"></td>
				<td class="Espacio"></td>
				<td class="Etiqueta"></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre"></td>
				<td class="Espacio"></td>
				<td class="Etiqueta"></td>
			</tr>
			<tr>
                <td class="Nombre">Doctor</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="DoctorLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de Atención</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaAtencionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Observaciones</td>
                <td class="Espacio"></td>
                <td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        
		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Ciudadanos
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="CiudadanoId,NombreCompleto" 
						OnRowCommand="gvCiudadano_RowCommand" 
						OnRowDataBound="gvCiudadano_RowDataBound"
                        OnSorting="gvCiudadano_Sorting">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
									<td style="width:100px;">Tipo</td>
									<td style="width:250px;">Nombre</td>
									<td style="width:90px;">Nacimiento</td>
									<td style="width:80px;">Sexo</td>
                                    <td style="width:100px;">Telefono</td>
									<td>Domicilio</td>
									<td style="width:25px;"></td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="8">No se encontraron Ciudadanos registrados en el sistema</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Tipo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="100px"	DataField="NombreTipoCiudadano"		SortExpression="NombreTipoCiudadano"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="NombreCompleto"			SortExpression="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Nacimiento"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	DataField="FechaNacimientoCorta"	SortExpression="FechaNacimientoCorta"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="NombreSexo"				SortExpression="NombreSexo"></asp:BoundField>
							<asp:BoundField HeaderText="Telefono"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="TelefonoPrincipal"		SortExpression="TelefonoPrincipal"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"	ItemStyle-HorizontalAlign="Left"							DataField="Domicilio"				SortExpression="Domicilio"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="20px">
							<ItemTemplate>
								<asp:ImageButton ID="imgEdit" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" runat="server" />
							</ItemTemplate>
						</asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        <br />

		<!-- Documentos -->
        <div style="text-align: left;">Documentos anexos</div>
        <div class="DocumentoListDiv">
            <asp:DataList ID="dlstDocumentoList" runat="server" CellPadding="5" CellSpacing="5" HorizontalAlign="Left" RepeatDirection="Horizontal" RepeatLayout="Table" OnItemDataBound="dlstDocumentoList_ItemDataBound" >
                <ItemTemplate>
                    <div class="Item">
                        <asp:Image ID="DocumentoImage" runat="server" />
                        <br />
                        <asp:Label CssClass="Texto" ID="DocumentoLabel" runat="server" Text="Nombre del documento"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label CssClass="Texto" ID="SinDocumentoLabel" runat="server" Text=""></asp:Label>
        </div>

		<!-- Comentarios -->
        <div class="SolicitudComentarioDiv">
            <div style="text-align: left;">
                Asuntos &nbsp;&nbsp;
                <asp:LinkButton ID="lnkAgregarComentario" runat="server" CssClass="LinkButton_Regular" Text="Agregar comentario" OnClick="lnkAgregarComentario_Click"></asp:LinkButton>
            </div>
            <div class="TituloDiv"><asp:Label ID="ComentarioTituloLabel" runat="server" Text=""></asp:Label></div>
            <asp:Repeater ID="repComentarios" runat="server">
                <HeaderTemplate>
                    <table border="1" class="ComentarioSolicitudTable">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="Numero">
							<%# DataBinder.Eval(Container.DataItem, "iRow") %>
						</td>
                        <td>
							<table class="ComentarioSolicitudTable">
								<tr>
									<td class="Nombre">
										<%# DataBinder.Eval(Container.DataItem, "UsuarioNombre")%>
									</td>
                                    <td class="Fecha">
										<%# DataBinder.Eval(Container.DataItem, "Fecha")%>
									</td>
                                </tr>
                                <tr>
                                    <td class="Texto" colspan="2">
										<%# DataBinder.Eval(Container.DataItem, "Comentario")%>
									</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label CssClass="Texto" ID="SinComentariosLabel" runat="server" Text=""></asp:Label>
        </div>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

    </div>

	<asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock" Visible="false">
        <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top:180px;" Height="380px" Width="800px">
            <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="text-align: left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Comentario"></asp:Label></td>
                        <td style="vertical-align: middle; width: 14px;"><asp:ImageButton ID="CloseWindowButton" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" onclick="CloseWindowButton_Click"></asp:ImageButton></td>
                        <td style="width: 10px"></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                <div style="margin:0 auto; width:98%;">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; text-align: left;" width="100%">
                        <tr style="height: 20px;"><td></td></tr>
                        <tr>
							<td class="tdActionCeldaLeyendaItem">
								<CKEditor:CKEditorControl ID="ckeComentario" BasePath="~/Include/Components/CKEditor/Core/" runat="server"></CKEditor:CKEditorControl>
							</td>
						</tr>
                        <tr style="height:5px;"><td></td></tr>
                        <tr>
							<td style="text-align:right;">
								<asp:Button ID="AgregarComentarioButton" runat="server" Text="Agregar comentario" CssClass="Button_General" Width="200px" onclick="AgregarComentarioButton_Click" />
							</td>
						</tr>
                        <tr>
							<td>
								<asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
							</td>
						</tr>
                    </table>
                </div>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>

	<asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddEstatusId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddFuncionarioId" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Numero" />

</asp:Content>
