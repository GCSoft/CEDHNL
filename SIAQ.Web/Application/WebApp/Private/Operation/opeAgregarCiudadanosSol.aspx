<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarCiudadanosSol.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarCiudadanosSol" %>

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
                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
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
                <td class="Nombre">Observaciones (Recepción)</td>
                <td class="Espacio"></td>
				<td class="Observaciones" colspan="5"><asp:Label ID="ObservacionesLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Lugar de los hechos</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="LugarHechosLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Dirección de los hechos</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="DireccionHechosLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Ciudadanos agregados a la solicitud</td>
                <td class="Espacio"><font class="MarcadorObligatorio"></font></td>
                <td colspan="5" style="text-align:left; vertical-align: top;">
					<asp:GridView id="gvCiudadanosAgregados" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" BorderWidth="0"
						DataKeyNames="CiudadanoId"
						OnRowCommand="gvCiudadanoAgregados_RowCommand"> 
						<headerstyle cssclass="Grid_Encabezado" />
						<rowstyle cssclass="Grid_Filas" />
						<EmptyDataRowStyle CssClass="Empty" BorderStyle="None" BorderWidth="0px" />
						<EmptyDataTemplate>
							<table border="0px" cellpadding="0" style="border:0px;" cellspacing="0">
								<tr><td style="height:5px"></td></tr>
								<tr><td style="font-size:9.5px; text-align:center;"> No se han agregado ciudadanos a la solicitud</td></tr>
								<tr><td style="height:130px;"></td></tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<asp:LinkButton Width="150px" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="SelectCiudadano" ID="CiudadanoButton" runat="server" Text='<%#Eval("NombreCompleto")%>'></asp:LinkButton>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left" />
							</asp:TemplateField>
							<asp:TemplateField>
								<ItemTemplate>
									<asp:ImageButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Eliminar"  runat="server" ID="ImagenEliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" Height="11px"> </asp:ImageButton>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</td>
            </tr>
        </table>

		<!-- Filtro -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Buscar ciudadanos
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
					<asp:Panel id="pnlBusquedaSimple" runat="server" Visible="true" Width="100%">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr style="height:20px;"><td colspan="4"></td></tr>
							<tr>
								<td class="tdCeldaLeyendaItemFondoBlanco"><asp:TextBox ID="txtNombre" runat="server" CssClass="Textbox_General" Width="177px"></asp:TextBox></td>
								<td style="width:5px;"></td>
								<td class="tdCeldaItem">
									<asp:Button ID="btnBuscar" runat="server" OnClick="QuickSearchButton_Click" CssClass="Button_General" Text="Buscar" Width="120px"></asp:Button>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:LinkButton ID="lnkBusquedaAvanzada" CssClass="Tamanoletra" runat="server" Text="Busqueda avanzada" onclick="BusquedaAvanzada_Click"></asp:LinkButton>
								</td>
								<td style="width:5px;"></td>
							</tr>   
						</table>
					</asp:Panel>
					<asp:Panel id="pnlBusqedaAvanzada" runat="server" Width="100%" Visible="false" CssClass="tdTituloEncabezado">
						<table border="0px" class="TablaCiudadano">
							<tr style="height:20px;"><td colspan="4"></td></tr>
							<tr>
								<td class="AnchoCeldaPrincipal" >Nombre</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td  ><asp:TextBox ID="TextBoxNombre" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal">Apellido Paterno</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td ><asp:TextBox ID="TextBoxPaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal">Apellido Materno</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal" >País</td>
								<td class="EspacioCeldaIntermedia"></td>
								<td ><asp:DropDownList ID="BuscadorListaPais" width="214px" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal" >Estado</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td><asp:DropDownList ID="BuscadorListaEstado" width="214px" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal" >Municipio</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td ><asp:DropDownList ID="BuscadorListaCiudad" width="214px" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal" >Colonia</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td ><asp:DropDownList ID="BuscadorListaColonia" width="214px" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="AnchoCeldaPrincipal" >Calle</td>
								<td class="EspacioCeldaIntermedia" ></td>
								<td ><asp:TextBox ID="TextBoxCalle" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
							</tr>
						</table>
						<div style="text-align:left;">
							<br /><br />
							<table width="90%" border="0">
								<tr>
									<td class="tdBotonBuscar"><asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="Button_General" OnClick="SearchButton_Click" width="125px"/></td>
									<td class="EspacioCeldaMediano"></td>
									<td><asp:LinkButton  class="EstiloBR" ID="LinkButton1" runat="server" OnClick="BusquedaRapida_Click">Búsqueda rapida</asp:LinkButton></td>
								</tr>
							</table>
						</div>
					</asp:Panel>
                </td>
            </tr>
		</table>

		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td>
					<asp:GridView id="gvCiudadano" runat="server" AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False"
						DataKeyNames="CiudadanoId"
						OnRowDataBound="gvCiudadano_RowDataBound"
						OnRowCommand="gvCiudadano_RowCommand"
						OnSorting="gvCiudadano_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px">
								<tr class="Grid_Header">
									<td style="width:150px; text-align:center;">Nombre</td>
									<td style="width:70px; text-align:center;">Sexo</td>
									<td style="width:100px; text-align:center;">Fecha Nacimiento</td>
									<td style="width:200px; text-align:center;">Domicilio</td>
									<td style="width:70px; text-align:center;" ></td>
								</tr>
								<tr class="Grid_Row"><td colspan="9"  style="text-align:center;">No se encontraron ciudadanos registradas en el sistema</td></tr>
							</table>
						</EmptyDataTemplate>
					<Columns>
						<asp:BoundField HeaderText="Nombre"             ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="170px" DataField="NombreCompleto"></asp:BoundField>
						<asp:BoundField HeaderText="Sexo"               ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="50px" DataField="SexoNombre"></asp:BoundField>
						<asp:BoundField HeaderText="Fecha Nacimiento"   ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="65px" DataField="FechaNacimiento"></asp:BoundField>
						<asp:BoundField HeaderText="Domicilio"          ItemStyle-HorizontalAlign="Left"		ItemStyle-Width="280px" DataField="DireccionCompleta"></asp:BoundField>
						<asp:TemplateField HeaderText="Editar">
							<ItemTemplate>
								<asp:LinkButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Agregar" ID="AgregarLink" runat="server" Text='Agregar' Width="80px"></asp:LinkButton>
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

	<asp:HiddenField ID="SolicitudIDHidden" runat="server" Value="" />
    <asp:HiddenField ID="hddSort" runat="server" value="NombreCompleto" />

</asp:Content>
