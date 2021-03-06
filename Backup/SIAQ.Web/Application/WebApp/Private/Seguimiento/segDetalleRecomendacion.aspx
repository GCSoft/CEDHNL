﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segDetalleRecomendacion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segDetalleRecomendacion" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
					<asp:Label ID="lblEncabezado" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Proporcione la información solicitada para dar seguimiento a las recomendaciones del expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="InformacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="~/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="AgregrarInformacionPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AgregrarInformacionButton" ImageUrl="~/Include/Image/Icon/AgregarInformacionIcon.png" runat="server" OnClick="AgregrarInformacionButton_Click"></asp:ImageButton><br />
            Agregar Información
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar defensor
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="EnviarAutoridadPanel" runat="server" Visible="true">
            <asp:ImageButton ID="EnviarAutoridadButton" ImageUrl="~/Include/Image/Icon/NotificacionIcon.png" runat="server" OnClick="EnviarAutoridadButton_Click"></asp:ImageButton><br />
            Enviar a Autoridad
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="SeguimientoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="SeguimientoButton" ImageUrl="~/Include/Image/Icon/SeguimientoIcon.png" runat="server" OnClick="SeguimientoButton_Click"></asp:ImageButton><br />
            Gestión a puntos resolutivos
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="DocumentoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DocumentoButton" ImageUrl="~/Include/Image/Icon/DocumentoIcon.png" runat="server" OnClick="DocumentoButton_Click"></asp:ImageButton><br />
            Agregar documentos
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="DiligenciaPanel" runat="server" Visible="true">
            <asp:ImageButton ID="DiligenciasButton" ImageUrl="~/Include/Image/Icon/DiligenciaIcon.png" runat="server" OnClick="DiligenciasButton_Click"></asp:ImageButton><br />
            Diligencias
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="ImpugnarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="ImpugnarButton" ImageUrl="~/Include/Image/Icon/ComparecenciaIcon.png" runat="server" OnClick="ImpugnarButton_Click"></asp:ImageButton><br />
            Impugnar
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="PublicarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="PublicarButton" ImageUrl="~/Include/Image/Icon/PublicarIcon.png" runat="server" OnClick="PublicarButton_Click"></asp:ImageButton><br />
            Publicar
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="pnlVistaPrevia" runat="server" Visible="true">
            <asp:ImageButton ID="ImprimirButton" ImageUrl="~/Include/Image/Icon/ImprimirIcon.png" runat="server" OnClick="ImprimirButton_Click"></asp:ImageButton><br />
            Vista previa
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="pnlEnviarAtencion" runat="server" Visible="true">
            <asp:ImageButton ID="EnviarButton" ImageUrl="~/Include/Image/Icon/EnviarIcon.png" runat="server" OnClick="EnviarButton_Click"></asp:ImageButton><br />
            Enviar Seguimiento
        </asp:Panel>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial"><asp:Label ID="lblNumero" runat="server" ></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="RecomendacionNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Expediente Número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="ExpedienteNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus Seguimiento</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="TipoLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de recepción</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en quejas</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaQuejasLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Funcionario</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en visitadurías</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaVisitaduriasLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Nombre Autoridad</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="NombreAutoridadLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Puesto</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="PuestoAutoridadLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Última modificación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaModificacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Niveles de Autoridad</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="NivelesAutoridadLabel" runat="server"></asp:Label></td>
			</tr>
			<tr style="height:10px;"><td colspan="7"></td></tr>
        </table>

		<!-- Puntos Resolutivos-->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Puntos Resolutivos
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvPuntosResolutivos" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionDetalleId" 
						OnRowDataBound="gvPuntosResolutivos_RowDataBound"
                        OnSorting="gvPuntosResolutivos_Sorting">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
									<td style="width:50px;">No</td>
									<td style="width:150px;">Estatus</td>
									<td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="3">No se encontraron Puntos Resolutivos asociados a la Recomendacion/Acuerdo de No Responsabilidad</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="No"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="50px"	DataField="RowNumber"						SortExpression="RowNumber"></asp:BoundField>
							<asp:BoundField HeaderText="Estatus"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="150px"	DataField="EstatusPuntoResolutivoNombre"	SortExpression="EstatusPuntoResolutivoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"	ItemStyle-HorizontalAlign="Left"							DataField="Detalle"		HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        <br />

		<!-- Ciudadanos-->
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
									<td style="width:90px;">Edad</td>
									<td style="width:80px;">Sexo</td>
                                    <td style="width:100px;">Telefono</td>
									<td>Domicilio</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Ciudadanos asociados al Expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Tipo"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="NombreTipoCiudadano"		SortExpression="NombreTipoCiudadano"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="NombreCompleto"			SortExpression="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Edad"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	DataField="Edad"					SortExpression="Edad"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="NombreSexo"				SortExpression="NombreSexo"></asp:BoundField>
							<asp:BoundField HeaderText="Telefono"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="TelefonoPrincipal"		SortExpression="TelefonoPrincipal"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"	ItemStyle-HorizontalAlign="Left"							DataField="Domicilio"				SortExpression="Domicilio"></asp:BoundField>
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

		<!-- Asuntos/Comentarios -->
		<div class="SolicitudComentarioDiv">
            <div style="text-align: left;">
                Asuntos &nbsp;&nbsp;
                <asp:LinkButton ID="lnkAgregarComentario" runat="server" CssClass="LinkButton_Regular" Text="Agregar asunto" OnClick="lnkAgregarComentario_Click" Visible="false"></asp:LinkButton>
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
										<%# DataBinder.Eval(Container.DataItem, "Fecha")%><br />
										<%# DataBinder.Eval(Container.DataItem, "ModuloNombre")%> - <%# DataBinder.Eval(Container.DataItem, "Tipo")%>
										<asp:HiddenField ID="hddModuloId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "ModuloId")%>' />
									</td>
                                </tr>
                                <tr>
                                    <td class="Texto" colspan="2">
										<%# DataBinder.Eval(Container.DataItem, "Comentario")%>
									</td>
                                </tr>
								<tr>
                                    <td colspan="2" style="text-align:right;">
										<asp:LinkButton ID="lnkEliminarComentario" runat="server" CssClass="LinkButton_Regular" Text="Eiminar" CommandArgument='<%#Eval("ComentarioId")%>' OnCommand="lnkEliminarComentario_Click" Visible="false" ></asp:LinkButton>
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

	<!-- Asuntos/Nuevos -->
    <asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock" Visible="false">
        <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top:180px;" Height="380px" Width="800px">
            <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
                    <tr>
                        <td style="width: 10px"></td>
                        <td style="text-align: left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Asunto"></asp:Label></td>
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
							<td>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									 <tr>
										<td style="text-align:left;"><asp:CheckBox ID="chkMedidaPreventiva" runat="server" Text ="Medida Preventiva"  CssClass="CheckBox_General" /></td>
										<td style="text-align:right;"><asp:Button ID="AgregarComentarioButton" runat="server" Text="Agregar asunto" CssClass="Button_General" Width="200px" onclick="AgregarComentarioButton_Click" /></td>
									</tr>
								</table>
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

	<asp:HiddenField ID="hddEstatusId" runat="server" Value="0" />
	<asp:HiddenField ID="hddEstatusSeguimientoId" runat="server" Value="0" />
	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0" />
	<asp:HiddenField ID="hddFuncionarioId" runat="server" Value="0" />
	<asp:HiddenField ID="hddRecomendacionId" runat="server" Value="0" />
	<asp:HiddenField ID="AceptadaPorAutoridad" runat="server" Value="-1" />
	<asp:HiddenField ID="EsRecomendacion" runat="server" Value="-1" />
	<asp:HiddenField ID="hddSort" runat="server" Value="RowNumber" />
	<asp:HiddenField ID="Sender" runat="server" Value="" />
	<asp:HiddenField ID="SenderId" runat="server" Value="0" />
	
</asp:Content>
