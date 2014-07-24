<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueCalificarSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueCalificarSolicitud" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Calificar Solicitud
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="En esta pantalla se puede especificar la calificación de la solicitud para determinar qué información complementaria debe capturarse en las demás pantallas."></asp:Label>
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
                <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudNumero" runat="server" Text="0"></asp:Label></td>
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
                <td class="Nombre">Calificación</td>
                <td class="Espacio"></td>
                <td class="Campo" colspan="5">
					<asp:DropDownList ID="ddlCalificacion" runat="server" AutoPostBack="true" CssClass="DropDownList_General" Width="198px" OnSelectedIndexChanged="ddlCalificacion_SelectedIndexChanged"></asp:DropDownList>
				</td>
            </tr>
			<tr>
                <td class="Nombre">Cierre de orientación</td>
                <td class="Espacio"></td>
                <td class="Campo" colspan="5">
					<asp:DropDownList ID="ddlTipoOrientacion" runat="server" AutoPostBack="true" CssClass="DropDownList_General" Enabled="false" Width="198px" OnSelectedIndexChanged="ddlTipoOrientacion_SelectedIndexChanged"></asp:DropDownList>
				</td>
            </tr>
			<tr>
                <td class="Nombre">Canalizado a</td>
                <td class="Espacio"></td>
                <td class="Campo" colspan="5">
					<asp:DropDownList ID="ddlCanalizacion" runat="server" CssClass="DropDownList_General" Enabled="false" Width="198px"></asp:DropDownList>&nbsp;&nbsp;
					<asp:Button ID="btnAgregarCanalizacion" runat="server" CssClass="Button_General_Disabled" width="125px" Enabled="false" Text="Agregar" OnClick="btnAgregarCanalizacion_Click" />
				</td>
            </tr>
			<tr>
                <td class="Nombre"></td>
                <td class="Espacio"></td>
                <td class="Campo" colspan="5">
					<asp:GridView ID="grdCanalizacion" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" CssClass="GridDinamico" ShowHeader="false" Width="100%"
                        DataKeyNames="CanalizacionId,Nombre"
						OnRowCommand="grdCanalizacion_RowCommand"
						OnRowDataBound="grdCanalizacion_RowDataBound">
                        <RowStyle CssClass="Grid_Row_Action" />
                        <EditRowStyle Wrap="True" />
                        <Columns>
                            <asp:BoundField DataField="Nombre" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="95%"></asp:BoundField>
							<asp:TemplateField ItemStyle-HorizontalAlign ="Center" ItemStyle-Width="5%">
								<ItemTemplate>
									<asp:ImageButton ID="imgDelete" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
                        </Columns>
                    </asp:GridView>
				</td>
            </tr>
			<tr style="height:30px;"><td colspan="7"></td></tr>
			<tr>
                <td class="Nombre">Fundamento</td>
                <td class="Espacio"></td>
                <td class="Campo" colspan="5"><CKEditor:CKEditorControl ID="ckeFundamento" BasePath="~/Include/Components/CKEditor/Core/" runat="server" Height="90px" MaxLength="8000"></CKEditor:CKEditorControl></td>
            </tr>
        </table>

        <!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

	</div>

	<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
