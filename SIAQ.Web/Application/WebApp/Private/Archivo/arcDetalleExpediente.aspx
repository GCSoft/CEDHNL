<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="arcDetalleExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Archivo.arcDetalleExpediente" %>
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
                    <asp:Label ID="Label2" runat="server" Text="Proporcione la información solicitada para dar administrar los préstamos del expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="InformacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="~/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="RecibirPanel" runat="server" Visible="true">
            <asp:ImageButton ID="RecibirExpedienteButton" ImageUrl="~/Include/Image/Icon/EnviarIcon.png" runat="server" OnClick="RecibirExpedienteButton_Click" OnClientClick="return confirm('¿Confirma la recepción del Archivo?');" ></asp:ImageButton><br />
            Recibir Expediente
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar expediente
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="LiberarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="LiberarButton" ImageUrl="~/Include/Image/Icon/AsignarIcon_Success.png" runat="server" OnClick="LiberarButton_Click" OnClientClick="return confirm('¿Confirma la liberación del Archivo?');"></asp:ImageButton><br />
            Liberar expediente
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="CambiarUbicacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="CambiarButton" ImageUrl="~/Include/Image/Icon/CalificarIcon.png" runat="server" OnClick="CambiarButton_Click"></asp:ImageButton><br />
            Cambiar de ubicación
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
				<td class="Especial">Solicitud número</td>
                <td class="Espacio"></td>
                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudNumeroLabel" runat="server" Text="0"></asp:Label></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="Nombre">Area</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="AreaNombreLabel" runat="server"></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre"></td>
                <td class="Espacio"></td>
                <td class="Etiqueta"></td>
            </tr>
			<tr>
                <td class="Nombre">Calificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre"></td>
                <td class="Espacio"></td>
                <td class="Etiqueta"></td>
            </tr>
			<tr>
                <td class="Nombre">Ubicación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="UbicacionLabel" runat="server"></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de recepción</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Estatus</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        
		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Historial
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvHistorial" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
							OnRowDataBound="gvHistorial_RowDataBound"
                            OnSorting="gvHistorial_Sorting">
                            <RowStyle CssClass="Grid_Row" />
                            <EditRowStyle Wrap="True" />
                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                            <EmptyDataTemplate>
                                <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                    <tr class="Grid_Header">
										<td style="width:150px;">Tipo</td>
										<td style="width:250px;">Nombre Presta</td>
										<td style="width:120px;">Fecha Prestamo</td>
										<td style="width:250px;">Nombre Recibe</td>
										<td style="width:120px;">Fecha Regreso</td>
										<td>Comentarios</td>
                                    </tr>
                                    <tr class="Grid_Row">
                                        <td colspan="6">El Archivo no tiene historial registrado</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>
								<asp:BoundField HeaderText="Tipo"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="150px"	DataField="Transaccion"								SortExpression="Transaccion"></asp:BoundField>
								<asp:BoundField HeaderText="Nombre Presta"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="UsuarioNombrePresta"						SortExpression="UsuarioNombrePresta"></asp:BoundField>
								<asp:BoundField HeaderText="Fecha Prestamo"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="120px"	DataField="FechaPrestamo"							SortExpression="FechaPrestamo"></asp:BoundField>
								<asp:BoundField HeaderText="Nombre Recibe"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="UsuarioNombreRecibe"						SortExpression="UsuarioNombreRecibe"></asp:BoundField>
								<asp:BoundField HeaderText="Fecha Regreso"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="120px"	DataField="FechaRegreso"							SortExpression="FechaRegreso"></asp:BoundField>
								<asp:BoundField HeaderText="Comentarios"	ItemStyle-HorizontalAlign="Left"							DataField="Comentarios"			HtmlEncode="false"	SortExpression="Comentarios"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        <br />

		<!-- Comentarios -->
        <div class="SolicitudComentarioDiv">
            <div style="text-align: left;">
                Comentarios &nbsp;&nbsp;
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
								<CKEditor:CKEditorControl ID="ckeComentario" BasePath="~/Include/Components/CKEditor/Core/" runat="server" MaxLength="8000"></CKEditor:CKEditorControl>
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

	<asp:HiddenField ID="hddArchivoId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddUbicacionExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Numero" />

</asp:Content>
