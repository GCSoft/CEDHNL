<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicDictamenMedico.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicDictamenMedico" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Seguimiento de recomendaciones
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="En esta sección puede registrar el seguimiento de las recomendaciones."></asp:Label>
                </td>
            </tr>
        </table>
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
			<tr>
                <td class="Nombre">Ciudadano</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlCiudadano" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="Nombre">Tipo de dictamen</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlTipoDictamen" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="Nombre">Lugar de atención</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlLugarAtencion" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="Nombre">Dictamen</td>
                <td class="Espacio"></td>
                <td colspan="5"></td>
            </tr>
			<tr>
                <td colspan="7" style="text-align:left;"><CKEditor:CKEditorControl ID="ckeDictamen" BasePath="~/Include/Components/CKEditor/Core/" runat="server"></CKEditor:CKEditorControl></td>
            </tr>
        </table>

		<!-- Botones -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>
		<br />
        
		<!-- Grid -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Dictámenes
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView id="gvDictamen" runat="server" AllowPaging="false" AllowSorting="true"  AutoGenerateColumns="False" Width="100%"
						DataKeyNames="DictamenId" 
						OnRowDataBound="gvDictamen_RowDataBound"
						OnSorting="gvDictamen_Sorting">
						<alternatingrowstyle cssclass="Grid_Row_Alternating" />
						<headerstyle cssclass="Grid_Header" />
						<rowstyle cssclass="Grid_Row" />
						<EmptyDataTemplate>
							<table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
								<tr class="Grid_Header">
									<td style="width:75px;">Fecha</td>
									<td style="width:120px;">Tipo de Dictamen</td>
									<td style="width:120px;">Lugar de Atención</td>
									<td style="width:200px;">Doctor que Atendió</td>
									<td style="width:200px;">Ciudadano</td>
									<td>Dictamen</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="6">No se encontraron dictámenes médicos de ciudadanos</td>
								</tr>
							</table>
						</EmptyDataTemplate>
						<Columns>
							<asp:BoundField HeaderText="Fecha"				ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="75px"	DataField="Fecha"										SortExpression="Fecha"></asp:BoundField>
							<asp:BoundField HeaderText="Tipo de Dictamen"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="120px"	DataField="TipoDictamenNombre"							SortExpression="TipoDictamenNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Lugar de Atención"	ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="120px"	DataField="LugarAtencionNombre"							SortExpression="LugarAtencionNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Doctor que Atendió"	ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="FuncionarioNombre"							SortExpression="FuncionarioNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Ciudadano"			ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="200px"	DataField="CiudadanoNombre"								SortExpression="CiudadanoNombre"></asp:BoundField>
							<asp:BoundField HeaderText="Dictamen"			ItemStyle-HorizontalAlign="Left"							DataField="Dictamen"				HtmlEncode="false"	SortExpression="Dictamen"></asp:BoundField>
						</Columns>
					</asp:GridView>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
        </table>
        <br />

    </div>

    <asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Fecha" />

</asp:Content>
