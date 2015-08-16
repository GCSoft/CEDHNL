<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicDictamenMedico.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicDictamenMedico" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Dictámen
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="En esta sección puede emitir el dictámen a la solicitud de atención a víctimas."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="InformacionDiv">
		
		<!-- Carátula -->
		<table class="SolicitudTable">
			<tr>
				<td class="Especial">Folio</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AtencionNumeroFolio" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Especial">Afectado</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:Label ID="AfectadoLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">No. Oficio</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="AtencionNumeroOficio" runat="server" Text=""></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Área</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="AreaLabel" runat="server" Text=""></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Expediente número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="ExpedienteNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td colspan="4"></td>
			</tr>
			<tr>
				<td class="Nombre">Solicitud número</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="SolicitudNumeroLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de Atención</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAtencionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Estatus</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server" Text=""></asp:Label></td>
				<td class="Espacio"></td>
				<td class="Nombre">Fecha de Asignación</td>
				<td class="Espacio"></td>
				<td class="Etiqueta"><asp:Label ID="FechaAsignacionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
                <td class="Nombre">Médico</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="DoctorLabel" runat="server" Text=""></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre">Ultima Modificación</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="UltimaModificacionLabel" runat="server" Text=""></asp:Label></td>
            </tr>
			<tr>
				<td class="Nombre">Dictámen Médico</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="DictamenMedicoLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td class="Nombre">Lugar de Revisión</td>
				<td class="Espacio"></td>
				<td class="Etiqueta" colspan="5"><asp:Label ID="LugarRevisionLabel" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr style="height:10px;"><td colspan="7"></td></tr>
			<!-- Fin de carátula -->
			<tr>
                <td class="Nombre">Resolución de dictamen</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlResolucionDictamen" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
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
        
    </div>

    <asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddAtencionDictamenId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Fecha" />

</asp:Content>
