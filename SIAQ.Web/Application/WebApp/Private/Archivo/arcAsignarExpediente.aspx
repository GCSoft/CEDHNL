<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="arcAsignarExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Archivo.arcAsignarExpediente" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Asignar expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="En esta sección puede asignar un expediente a un usuario de la aplicación."></asp:Label>
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
                <td class="Nombre"></td>
                <td class="Espacio"></td>
                <td class="Etiqueta"></td>
            </tr>
            <tr>
                <td class="Nombre">Estatus Archivo</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="EstatusLabel" runat="server"></asp:Label></td>
                <td class="Espacio"></td>
                <td class="Nombre"></td>
                <td class="Espacio"></td>
                <td class="Etiqueta"></td>
            </tr>
            <tr>
                <td class="Nombre">Usuario con el Expediente</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="UsuarioNombreRecibeLabel" runat="server"></asp:Label></td>
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
                <td class="Nombre">Fecha de préstamo</td>
                <td class="Espacio"></td>
                <td class="Etiqueta"><asp:Label ID="FechaPrestamoLabel" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="Nombre">Comentarios</td>
                <td class="Espacio"></td>
                <td class="Etiqueta" colspan="5"><asp:Label ID="ComentariosLabel" runat="server"></asp:Label></td>
            </tr>
			<tr>
                <td class="Nombre">Nueva Ubicación</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlUbicacionExpediente" runat="server" AutoPostBack="true" CssClass="DropDownList_General" width="216px" onselectedindexchanged="ddlUbicacionExpediente_SelectedIndexChanged" ></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="Nombre">Usuario a Asignar</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList id="ddlUsuario_Recibe" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="Nombre">Comentarios</td>
                <td class="Espacio"></td>
                <td colspan="5"></td>
            </tr>
			<tr>
                <td colspan="7" style="text-align:left;"><CKEditor:CKEditorControl ID="ckeComentarios" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl></td>
            </tr>
        </table>

		<!-- Botones -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="Button_General" width="125px" onclick="btnAsignar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" />
                </td>
            </tr>
        </table>
		<br />

    </div>

    <asp:HiddenField ID="ExpedienteIdHidden" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
