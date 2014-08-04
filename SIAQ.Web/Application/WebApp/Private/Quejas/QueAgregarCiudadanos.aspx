<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueAgregarCiudadanos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueAgregarCiudadanos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Agregar ciudadanos a la solicitud
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Realice una búsqueda para agregar ciudadanos a la solicitud. "></asp:Label>
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
			<!-- Fin de Carátula -->
			<tr>
                <td class="Nombre">Ciudadano</td>
                <td class="Espacio"><font class="MarcadorObligatorio"></font></td>
                <td colspan="5" style="text-align:left; vertical-align: top;">
					<script type = "text/javascript"> function ClientItemSelected(sender, e) { $get("<%=hddCiudadanoId.ClientID %>").value = e.get_value(); } </script>
					<asp:TextBox ID="txtCiudadano" runat="server" CssClass="Textbox_General" Width="400px"></asp:TextBox>
					<asp:HiddenField ID="hddCiudadanoId" runat="server" />
					<ajaxToolkit:AutoCompleteExtender
						ID="autoCompleteExtender" 
						runat="server"
						TargetControlID="txtCiudadano"
						ServiceMethod="GetCitizenList"
						CompletionInterval="100"
						CompletionSetCount="10"
						EnableCaching="false"
						FirstRowSelected="false"
						MinimumPrefixLength="2"
						OnClientItemSelected="ClientItemSelected">
					</ajaxToolkit:AutoCompleteExtender>
				</td>
            </tr>
			<tr>
                <td class="Nombre">Tipo de Participación</td>
                <td class="Espacio"><font class="MarcadorObligatorio"></font></td>
                <td colspan="5" style="text-align:left; vertical-align:baseline;">
					<asp:DropDownList ID="ddlTipoParticipacion" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList>&nbsp;&nbsp;
					<asp:CheckBox ID="chkPresente" runat="server" CssClass="CheckBox_Regular" Checked="true" Text="Ciudadano Presente" />
				</td>
            </tr>
			<tr>
                <td colspan="7" style="text-align:left; vertical-align:bottom;">
					<asp:Button ID="btnAgregarCiudadano" runat="server" Text="Agregar" CssClass="Button_General" onclick="btnAgregarCiudadano_Click" Width="125px" />
				</td>
            </tr>
        </table>

		<!-- Grid -->
		<!-- Falta agregar el tipo de participación -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td>
					<asp:GridView ID="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="CiudadanoId,UsuarioId,NombreCompleto" 
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand"
                        OnSorting="gvCiudadano_Sorting">
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
                                    <td colspan="7" style="text-align:center;">No se encontraron Ciudadanos registrados en el sistema</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="Tipo"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="NombreTipoCiudadano"		SortExpression="NombreTipoCiudadano"></asp:BoundField>
							<asp:BoundField HeaderText="Presente"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="Presente"				SortExpression="Presente"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre"		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="250px"	DataField="NombreCompleto"			SortExpression="NombreCompleto"></asp:BoundField>
							<asp:BoundField HeaderText="Edad"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="90px"	DataField="Edad"					SortExpression="Edad"></asp:BoundField>
							<asp:BoundField HeaderText="Sexo"		ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="80px"	DataField="NombreSexo"				SortExpression="NombreSexo"></asp:BoundField>
							<asp:BoundField HeaderText="Telefono"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="100px"	DataField="TelefonoPrincipal"		SortExpression="TelefonoPrincipal"></asp:BoundField>
							<asp:BoundField HeaderText="Domicilio"	ItemStyle-HorizontalAlign="Left"							DataField="Domicilio"				SortExpression="Domicilio"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
							<asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
		<br />

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnNuevoCiudadano" runat="server" Text="Nuevo Ciudadano" CssClass="Button_General" onclick="btnNuevoCiudadano_Click" Width="125px" />&nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" onclick="btnRegresar_Click" Width="125px" />
                </td>
            </tr>
        </table>

	</div>

	<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
    <asp:HiddenField ID="hddSort" runat="server" value="NombreCompleto" />

</asp:Content>
