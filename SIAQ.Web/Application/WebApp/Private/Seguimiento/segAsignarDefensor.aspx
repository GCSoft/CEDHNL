<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="segAsignarDefensor.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.segAsignarDefensor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Asignar defensor a las recomendaciones del expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Indique a qué defensor se le van a asignar las recomendaciones del expediente."></asp:Label>
                </td>
            </tr>
        </table>
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
			<tr>
                <td class="Nombre">Asignar a</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlFuncionario" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
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
						DataKeyNames="RecomendacionId,iRow" 
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
								</tr>
								<tr class="Grid_Row">
									<td colspan="5">No se encontraron recomendaciones asociadas al expediente</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Número"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="iRow"				SortExpression="iRow"></asp:BoundField>
							<asp:BoundField HeaderText="Nombre de la Autoridad"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="AutoridadNombre"		SortExpression="AutoridadNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Puesto de la Autoridad"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="PuestoNombre"		SortExpression="PuestoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Fecha"					ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="70px"	DataField="FechaRecomendacion"	SortExpression="FechaRecomendacion"></asp:BoundField>
							<asp:BoundField HeaderText="Comentarios"			ItemStyle-HorizontalAlign="Left"							DataField="Comentarios"			SortExpression="Comentarios"></asp:BoundField>
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
					<asp:Button ID="bnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="bnGuardar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>

    </div>

    <asp:HiddenField ID="ExpedienteIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="iRow" />

</asp:Content>
