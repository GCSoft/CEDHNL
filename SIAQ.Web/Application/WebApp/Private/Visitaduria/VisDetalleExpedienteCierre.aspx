<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VisDetalleExpedienteCierre.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Visitaduria.VisDetalleExpedienteCierre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle del expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Confirme o Deniegue la solicitud de cierre del expediente."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div id="SubMenuDiv">
		<asp:Panel CssClass="IconoPanel" ID="AprobarProyectoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AprobarProyectoButton" ImageUrl="~/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="AprobarProyectoButton_Click" OnClientClick="return confirm('¿Seguro que desea aprobar el proyecto?');"></asp:ImageButton><br />
            Aprobar proyecto
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="RechazarProyectoPanel" runat="server" Visible="true">
            <asp:ImageButton ID="RechazarProyectoButton" ImageUrl="~/Include/Image/Icon/RechazarCierreIcon.png" runat="server" OnClick="RechazarProyectoButton_Click" OnClientClick="return confirm('¿Seguro que desea rechazar el proyecto?');"></asp:ImageButton><br />
            Rechazar proyecto
        </asp:Panel>
    </div>

    <div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Expediente Número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="ExpedienteNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Solicitud Número</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="SolicitudNumero" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Calificación</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="CalificacionLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Afectado/Quejoso</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Resolución</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="ResolucionLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Area</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="AreaLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de recepción</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaRecepcionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusaLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Funcionario</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FuncionarioLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en quejas</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaQuejasLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Forma de contacto</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ContactoLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de inicio en visitadurías</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaVisitaduriasLabel" runat="server" Text=""></asp:Label></td>
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
				<td class="Nombre">Fundamento</td>
				<td class="Espacio"></td>
				<td class="Observaciones" colspan="5"><asp:Label ID="FundamentoLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre"><asp:Label ID="CierreOrientacionLabel" runat="server" Text="Cierre de Orientación"></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="TipoOrientacionLabel" runat="server"></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre"><asp:Label ID="CanalizacionesLabel" runat="server" Text="Canalizaciones" Visible="false"></asp:Label></td>
				<td class="Espacio"></td>
				<td colspan="5">
					<asp:GridView ID="grdCanalizacion" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" CssClass="GridDinamico" ShowHeader="false" Width="100%">
						<RowStyle CssClass="Grid_Row_Action" />
						<EditRowStyle Wrap="True" />
						<Columns>
							<asp:BoundField DataField="Nombre" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100%"></asp:BoundField>
						</Columns>
					</asp:GridView>
				</td>
			</tr>
			<tr style="height:10px;"><td colspan="7"></td></tr>
        </table>

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
		<br />

        <!-- Asuntos/Comentarios -->
		<div class="SolicitudComentarioDiv">
            <div style="text-align: left;">
                Asuntos &nbsp;&nbsp;
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

		<!-- Grupos Minoritarios / Indicadores  -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Grupos Minoritarios
				</td>
			</tr>
			<tr>
				<td>
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr><td class="DivisonTabla">&nbsp;Grupos Minoritarios</td></tr>
						<tr><td></td></tr>
						<tr>
							<td>
								<asp:CheckBoxList ID="chkIndicadores" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" RepeatColumns="4" CellSpacing="20"></asp:CheckBoxList>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
		</table>
		<br />

		<!-- Diligencias-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Diligencias
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView ID="gvDiligencia" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="DiligenciaId,ModuloId,Fecha"
                        OnRowDataBound="gvDiligencia_RowDataBound" 
                        OnSorting="gvDiligencia_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
									<td style="width:70px;">Módulo</td>
                                    <td style="width:70px;">Fecha</td>
									<td style="width:150px;">Tipo de Diligencia</td>
                                    <td style="width:200px;">Funcionario que ejecuta</td>
                                    <td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="5">No se encontraron diligencias registradas en esta solicitud</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Módulo"						ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="70px"	DataField="ModuloNombre"								SortExpression="ModuloNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Diligencia"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="Tipo"										SortExpression="Tipo"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario que ejecuta"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="NombreVisitadorEjecuta"						SortExpression="NombreVisitadorEjecuta"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"					ItemStyle-HorizontalAlign="Left"							DataField="Detalle"					HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
				</td>
			</tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
		</table>
		<br />

		<!-- Gestión-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Gestión
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView ID="gvSeguimiento" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedienteSeguimientoId,Fecha"
                        OnRowDataBound="gvSeguimiento_RowDataBound" 
                        OnSorting="gvSeguimiento_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:75px;">Fecha</td>
									<td style="width:200px;">Visitador</td>
									<td style="width:200px;">Tipo</td>
                                    <td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="5">No se encontraron gestiones registradas en este Expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Fecha"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="FechaCorta"							SortExpression="FechaCorta"></asp:BoundField>
							<asp:BoundField HeaderText="Visitador"					ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="NombreVisitador"						SortExpression="NombreVisitador"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Diligencia"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="TipoSeguimiento"						SortExpression="TipoSeguimiento"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"					ItemStyle-HorizontalAlign="Left"							DataField="Detalle"			HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
				</td>
			</tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
		</table>
		<br />

		<!-- Comparecencia-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Comparecencia
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView ID="gvComparecencia" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="ExpedienteComparecenciaId,ModuloId,FechaComparecenciaCorta"
                        OnRowDataBound="gvComparecencia_RowDataBound" 
                        OnSorting="gvComparecencia_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
									<td style="width:70px;">Fecha</td>
									<td style="width:150px;">Tipo de Comparecencia</td>
									<td style="width:150px;">Lugar de Comparecencia</td>
                                    <td style="width:200px;">Funcionario que ejecuta</td>
                                    <td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="5">No se encontraron Comparecencias registradas en este expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Fecha"						ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="FechaComparecenciaCorta"							SortExpression="FechaComparecenciaCorta"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Comparecencia"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="150px"	DataField="TipoComparecenciaNombre"							SortExpression="TipoComparecenciaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Lugar de Comparecencia"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="70px"	DataField="LugarComparecenciaNombre"						SortExpression="LugarComparecenciaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Funcionario que ejecuta"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="FuncionarioEjecutaNombre"						SortExpression="FuncionarioEjecutaNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"					ItemStyle-HorizontalAlign="Left"							DataField="Detalle"					HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
				</td>
			</tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
		</table>
		<br />

		<!-- Autoridades y Voces-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Autoridades y Voces Señaladas
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView id="gvAutoridades" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="AutoridadId,Nombre"
                        OnRowCommand="gvAutoridades_RowCommand"
                        OnRowDataBound="gvAutoridades_RowDataBound"
                        OnSorting="gvAutoridades_Sorting">
                        <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                        <headerstyle cssclass="Grid_Header" />
                        <rowstyle cssclass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:25px;" ></td>
									<td style="width:140px;">Calificación</td>
                                    <td style="width:140px;">Nombre de Autoridad</td>
                                    <td style="width:140px;">Puesto</td>
                                    <td style="width:140px;">Nivel 1 Autoridad</td>
                                    <td style="width:140px;">Nivel 2 Autoridad</td>
                                    <td style="width:140px;">Nivel 3 Autoridad</td>
                                    <td>Comentarios</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="8">No se encontraron Autoridades asociadas al Expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25px">
                                <HeaderTemplate>
                                    <asp:ImageButton ID="imgSwapAll_Autoridad" runat="server" CommandName="SwapGridHeader" CommandArgument="-1" ImageUrl="~/Include/Image/Buttons/Expand_Header.png" OnClick="imgSwapAll_Autoridad_Click" onmouseover="tooltip.show('Expander todos los elementos', 'Der');" onmouseout="tooltip.hide();" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSwapGrid" CommandName="SwapGrid" CommandArgument="<%#Container.DataItemIndex%>" runat="server" ImageUrl="~/Include/Image/Buttons/Expand.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:BoundField HeaderText="Calificación"			ItemStyle-ForeColor="#FF6600"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="140px" DataField="CalificacionAutoridadNombre"	SortExpression="CalificacionAutoridadNombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Nombre de Autoridad"									ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nombre"						SortExpression="Nombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto"													ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Puesto"						SortExpression="Puesto"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 1 Autoridad"										ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel1"						SortExpression="Nivel1"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 2 Autoridad"										ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel2"						SortExpression="Nivel2"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 3 Autoridad"										ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel3"						SortExpression="Nivel3"></asp:BoundField>
                            <asp:BoundField HeaderText="Comentarios"											ItemStyle-HorizontalAlign="Left"                            DataField="Comentarios"					SortExpression="Comentarios"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="0px">
								<ItemTemplate>
									<asp:Panel ID="pnlGridDetail" runat="server">
										<tr>
											<td align="center" colspan="100%" style="border:1px solid #C1C1C1">
                                                <asp:GridView id="gvVocesDetalle" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="90%"
                                                    DataKeyNames="VozId">
                                                    <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                                                    <headerstyle cssclass="Grid_Header_Action_Alternative" />
                                                    <rowstyle cssclass="Grid_Row" />
                                                    <EmptyDataTemplate>
                                                       <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
															<tr class="Grid_Header_Action_Alternative">
																<td style="text-align:center; width:180px;">Voz1</td>
																<td style="text-align:center; width:180px;">Voz2</td>
																<td style="text-align:center; width:180px;">Voz3</td>
																<td style="text-align:center;">Comentarios</td>
																<td style="text-align:center; width:100px;">Calificación</td>
															</tr>
															<tr class="Grid_Row">
																<td colspan="5" style="text-align:center;">No se han agregado voces a la autoridad</td>
															</tr>
														</table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Voz1" 											ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="180px"	DataField="Voz1"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Voz2" 											ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="180px"	DataField="Voz2"></asp:BoundField>
                                                        <asp:BoundField HeaderText="Voz3"											ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="180px"	DataField="Voz3"></asp:BoundField>
														<asp:BoundField HeaderText="Comentarios"									ItemStyle-HorizontalAlign="Left"							DataField="Comentarios"></asp:BoundField>
														<asp:BoundField HeaderText="Calificación"	ItemStyle-ForeColor="#FF6600"	ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="180px"	DataField="CalificacionAutoridadNombre"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
												<br />
											</td>
										</tr>
									</asp:Panel>
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

		<!-- Recomendaciones-->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr><td class="tdCeldaMiddleSpace"></td></tr>
			<tr>
				<td style="text-align: left;">
					Recomendaciones
				</td>
			</tr>
			<tr>
				<td>
					<asp:GridView ID="gvRecomendacion" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="RecomendacionId,NombreAutoridad"
                        OnRowCommand="gvRecomendacion_RowCommand" 
                        OnRowDataBound="gvRecomendacion_RowDataBound" 
                        OnSorting="gvRecomendacion_Sorting">
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <HeaderStyle CssClass="Grid_Header" />
                        <RowStyle CssClass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:25px;" ></td>
                                    <td style="width:150px;">Nombre de Autoridad</td>
                                    <td style="width:150px;">Puesto</td>
                                    <td>Nivel 1 Autoridad</td>
                                    <td style="width:200px;">Nivel 2 Autoridad</td>
                                    <td style="width:200px;">Nivel 3 Autoridad</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Recomendaciones asociadas al Expediente</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25px">
                                <HeaderTemplate>
                                    <asp:ImageButton ID="imgSwapAll" runat="server" CommandName="SwapGridHeader" CommandArgument="-1" ImageUrl="~/Include/Image/Buttons/Expand_Header.png" OnClick="imgSwapAll_Click" onmouseover="tooltip.show('Expander todos los elementos', 'Der');" onmouseout="tooltip.hide();" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgSwapGrid" CommandName="SwapGrid" CommandArgument="<%#Container.DataItemIndex%>" runat="server" ImageUrl="~/Include/Image/Buttons/Expand.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Nombre de Autoridad"	ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="NombreAutoridad"	SortExpression="NombreAutoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto"					ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="150px" DataField="PuestoAutoridad"	SortExpression="PuestoAutoridad"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 1 Autoridad"		ItemStyle-HorizontalAlign="Left"							DataField="AutoridadNivel1"	SortExpression="AutoridadNivel1"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 2 Autoridad"		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="AutoridadNivel2"	SortExpression="AutoridadNivel2"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 3 Autoridad"		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="200px" DataField="AutoridadNivel3"	SortExpression="AutoridadNivel3"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="0px">
								<ItemTemplate>
									<asp:Panel ID="pnlGridDetail" runat="server">
										<tr>
											<td align="center" colspan="100%" style="border:1px solid #C1C1C1">
                                                <asp:GridView id="gvRecomendacionDetalle" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" Width="90%"
                                                    DataKeyNames="RecomendacionDetalleId">
                                                    <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                                                    <headerstyle cssclass="Grid_Header_Action_Alternative" />
                                                    <rowstyle cssclass="Grid_Row" />
                                                    <EmptyDataTemplate>
                                                        <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
															<tr class="Grid_Header_Action_Alternative">
																<td style="text-align:center; width:25px;"></td>
																<td style="text-align:center;">Detalle</td>
															</tr>
															<tr class="Grid_Row">
																<td colspan="2" style="text-align:center;">No se han agregado detalles de la recomendación</td>
															</tr>
														</table>
                                                    </EmptyDataTemplate>
                                                    <Columns>
                                                        <asp:BoundField HeaderText=""								ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="25px"	DataField="RowNumber"></asp:BoundField>
														<asp:BoundField HeaderText="Detalle"	HtmlEncode="false"	ItemStyle-HorizontalAlign="Left"							DataField="Apartado"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
												<br />
											</td>
										</tr>
									</asp:Panel>
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

	<asp:HiddenField ID="hddExpedienteId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddEstatusId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddFuncionarioId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddTipoResolucionId" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="NombreTipoCiudadano" />

</asp:Content>
