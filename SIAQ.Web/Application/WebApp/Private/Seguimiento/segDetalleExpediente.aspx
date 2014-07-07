<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segDetalleExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segDetalleExpediente" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle de Expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Proporcione la información solicitada para dar seguimiento a las recomendaciones del expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="InformacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="~/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar defensor
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="SeguimientoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="SeguimientoButton" ImageUrl="~/Include/Image/Icon/SeguimientoIcon.png" runat="server" OnClick="SeguimientoButton_Click"></asp:ImageButton><br />
            Seguimiento
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="NotificacionesPanel" runat="server" Visible="true">
            <asp:ImageButton ID="NotificacionesButton" ImageUrl="~/Include/Image/Icon/NotificacionIcon.png" runat="server" OnClick="NotificacionesButton_Click"></asp:ImageButton><br />
            Notificaciones
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DiligenciaPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DiligenciasButton" ImageUrl="~/Include/Image/Icon/DiligenciaIcon.png" runat="server" OnClick="DiligenciasButton_Click"></asp:ImageButton><br />
            Diligencias
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CerrarExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="CerrarExpedienteButton" ImageUrl="~/Include/Image/Icon/CerrarExpedienteIcon.png" runat="server" OnClick="CerrarExpedienteButton_Click"></asp:ImageButton><br />
            Cerrar Expediente
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ConfirmarCierreExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="ConfirmarCierreExpedienteButton" ImageUrl="~/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="ConfirmarCierreExpedienteButton_Click"></asp:ImageButton><br />
            Confirmar Cierre de Expediente
        </asp:Panel>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Expediente número</td>
                <td class="Espacio"></td>
                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="ExpedienteNumeroLabel" runat="server" Text="0"></asp:Label></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="Nombre">Calificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de recepción</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Estatus</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server"></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de asignación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Tipo de solicitud</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="TipoSolicitudLabel" runat="server"></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de inicio gestión</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaInicioLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Defensor</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="DefensorLabel" runat="server"></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Última modificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaUltimaLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Observaciones</td>
                <td class="Espacio"></td>
                <td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Lugar de los hechos</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="LugarHechosLabel" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Dirección de los hechos</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="DireccionHechosLabel" runat="server"></asp:Label></td>
            </tr>
        </table>
        
		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Recomendaciones
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView id="gvRecomendacion" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionId,Numero" 
						onrowcommand="gvRecomendacion_RowCommand" 
						onrowdatabound="gvRecomendacion_RowDataBound"
						onsorting="gvRecomendacion_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
									<td style="width:75px;">Número</td>
									<td style="width:200px;">Nombre de la Autoridad</td>
									<td style="width:200px;">Puesto de la Autoridad</td>
									<td style="width:70px;">Fecha</td>
									<td>Comentarios</td>
									<td style="width:25px;"></td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="6">No se encontraron recomendaciones asociadas al expediente</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="Numero"									SortExpression="Numero"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre de la Autoridad"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="AutoridadNombre"							SortExpression="AutoridadNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Puesto de la Autoridad"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="PuestoNombre"							SortExpression="PuestoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="FechaRecomendacion"						SortExpression="FechaRecomendacion"></asp:BoundField>
							<asp:BoundField HeaderText="Comentarios"			ItemStyle-HorizontalAlign="Left"							DataField="Comentarios"			HtmlEncode="false"	SortExpression="Comentarios"></asp:BoundField>
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
								<CKEditor:CKEditorControl ID="ckeComentario" BasePath="/Include/Components/CKEditor/Core/" runat="server"></CKEditor:CKEditorControl>
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

	<asp:HiddenField ID="EstatusIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="ExpedienteIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="FuncionarioIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Numero" />

</asp:Content>
