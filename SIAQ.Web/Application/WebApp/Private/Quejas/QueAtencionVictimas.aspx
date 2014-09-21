<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueAtencionVictimas.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueAtencionVictimas" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucCalendar.ascx" tagname="wucCalendar" tagprefix="wuc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Registrar atención a víctimas
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Capture una solicitud de atención a víctimas para el ciudadano."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
                <td class="Especial">Solicitud Número</td>
                <td class="Espacio"></td>
                <td class="Campo"><asp:Label ID="SolicitudNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
                <td colspan="4"></td>
            </tr>
			<tr>
				<td class="Especial">Afectado/Quejoso</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
            <tr>
                <td class="Nombre">Calificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="CalificacionLabel" runat="server" Text=""></asp:Label></td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td class="Nombre">Estatus</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de recepción</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Funcionario</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de asignación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Forma de contacto</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Fecha de inicio gestión</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaGestionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Tipo de solicitud</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="TipoSolicitudLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Última modificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaModificacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Problemática</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="ProblematicaLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Nivel de Autoridad</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="NivelAutoridadLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Detalle de Problemática</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="ProblematicaDetalleLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Mecanismo de Apertura</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="MecanismoAperturaLabel" runat="server" Text=""></asp:Label></td>
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
			<tr>
                <td class="Nombre">Observaciones</td>
                <td class="Espacio"></td>
                <td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="7" style="text-align:left; vertical-align:bottom;">
					<asp:Button ID="btnAgregarAtencion" runat="server" Text="Agregar" CssClass="Button_General" onclick="btnAgregarAtencion_Click" Width="125px" />
				</td>
            </tr>
        </table>

        <!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td>
					<asp:GridView ID="gvAtencionVictimas" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" Width="100%"
						DataKeyNames="AtencionDetalleId,AtencionId,AfectadoId" 
						OnRowDataBound="gvAtencionVictimas_RowDataBound"
						OnRowCommand="gvAtencionVictimas_RowCommand"
                        OnSorting="gvAtencionVictimas_Sorting">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
									<td style="width:100px;">Tipo</td>
									<td style="width:80px;">Presente</td>
									<td style="width:250px;">Nombre</td>
									<td style="width:90px;">Edad</td>
									<td style="width:80px;">Sexo</td>
                                    <td style="width:100px;">Telefono</td>
									<td>Domicilio</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="7" style="text-align:center;">No se encontraron Ciudadanos asociados a la Solicitud</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Número"		
                                ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	
                                DataField="AtencionDetalleId"		SortExpression="AtencionDetalleId">
<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                            </asp:BoundField>
							<asp:BoundField HeaderText="AtencionId"	ItemStyle-HorizontalAlign="Center"	
                                ItemStyle-Width="80px"	DataField="AtencionId"				SortExpression="AtencionId" 
                                Visible="False">
<ItemStyle HorizontalAlign="Center" Width="0px"></ItemStyle>
                            </asp:BoundField>
							<asp:BoundField DataField="AfectadoId" HeaderText="Afectado" 
                                SortExpression="AfectadoId">
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
							<asp:BoundField HeaderText="Estatus"		
                                ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	
                                DataField="EstatusAtencionId"			SortExpression="EstatusAtencionId">
<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
                            </asp:BoundField>
							<asp:BoundField HeaderText="FechaModificacion"		
                                ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	
                                DataField="FechaModificacion"					SortExpression="FechaModificacion" 
                                Visible="False">
<ItemStyle HorizontalAlign="Center" Width="0px"></ItemStyle>
                            </asp:BoundField>
							<asp:BoundField HeaderText="Detalle"		ItemStyle-HorizontalAlign="Center"	
                                ItemStyle-Width="80px"	DataField="Detalle"				SortExpression="Detalle">
<ItemStyle HorizontalAlign="Center" Width="450px"></ItemStyle>
                            </asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" />
                                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="25px"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click"/>
                </td>
            </tr>
        </table>
		<br />

        <!-- PopUp -->
		<asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock">
			<asp:Panel id="pnlActionContent" runat="server" CssClass="ActionContent" style="top:50px;" Height="660px" Width="800px">
				<asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
					<table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
						<tr>
							<td style="width:10px"></td>
							<td style="text-align:left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
							<td style="vertical-align:middle; width:14px;"><asp:ImageButton id="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton></td>
							<td style="width:10px"></td>
						</tr>
					</table>
				</asp:Panel>
				<asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
					<div style="margin:0 auto; width:98%;">
						<table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
							<tr style="height:20px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha de registro</td>
								<td style="width:5px;"></td>
								<td><wuc:wucFixedDateTime ID="wucFixedDateTime" runat="server" /></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Fecha de atención</td>
								<td></td>
								<td><wuc:wucCalendar ID="calFecha" runat="server" /></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Tipo de atención</td>
								<td></td>
								<td class="tdCeldaItem"><asp:DropDownList ID="ddlTipoDiligencia" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Lugar de atención</td>
								<td></td>
								<td class="tdCeldaItem"><asp:DropDownList ID="ddlLugarDiligencia" runat="server" Width="216px" CssClass="DropDownList_General"></asp:DropDownList></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem">
								<td class="tdActionCeldaLeyendaItem">&nbsp;Solicitada por</td>
								<td></td>
								<td class="tdCeldaItem"><asp:TextBox ID="txtSolicitadaPor" runat="server" CssClass="Textbox_General" Width="210px" MaxLength="1000"></asp:TextBox></td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr class="trFilaItem"><td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Motivo de la atención</td></tr>
							<tr style="height:155px;">
								<td colspan="3">
									<CKEditor:CKEditorControl ID="ckeMotivoAtencion" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl>
								</td>
							</tr>
							<tr style="height:5px;"><td colspan="3"></td></tr>
							<tr>
								<td colspan="3" style="text-align:right;">
									<asp:Button ID="btnAction" runat="server" Text="" CssClass="Button_General" width="125px" onclick="btnAction_Click" />
								</td>
							</tr>
							<tr>
								<td colspan="3">
									<asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
								</td>
							</tr>
						</table>
					</div>
				</asp:Panel>
			</asp:Panel>
			<ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"> </ajaxToolkit:DragPanelExtender>
		</asp:Panel>
    </div>

    <asp:HiddenField ID="hddSolicitudId" runat="server" Value="0" />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
    <asp:HiddenField ID="hddSort" runat="server" value="NombreCiudadano" />

</asp:Content>
