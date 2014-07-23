<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="QueCrearExpediente.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Quejas.QueCrearExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Crear expediente
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label1" runat="server" Text="Seleccione la visitaduria a asignar la solicitud para crear el expediente."></asp:Label>
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
                <td class="Especial">Calificación</td>
                <td class="Espacio"></td>
                <td class="Campo"><asp:Label ID="CalificacionLabel" CssClass="NumeroSolicitudLabel" runat="server" Text="0"></asp:Label></td>
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
			<!-- Asignación -->
			<tr style="height:10px;"><td colspan="7"></td></tr>
			<tr>
                <td class="Especial">Asignación</td>
                <td colspan="6"></td>
            </tr>
			<tr>
                <td class="Nombre">Visitaduría a ser Asignada</td>
                <td class="Espacio"><font class="MarcadorObligatorio">&nbsp;*</font></td>
                <td colspan="5" style="text-align:left;"><asp:DropDownList ID="ddlVisitaduria" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
            </tr>
			<tr>
                <td class="Nombre"><asp:Label ID="lblVisitaduria" runat="server" Text="Número de expediente a ser asignado"></asp:Label></td>
                <td class="Espacio"></td>
                <td colspan="5" style="text-align:left;"><asp:Label ID="lblExpediente" runat="server" CssClass="NumeroNuevoExpedienteLabel" Text="0" Width="214" ></asp:Label></td>
            </tr>
        </table>
		<br />

		<!-- Botones Pie de Página -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
					<asp:Button ID="btnAprobar" runat="server" Text="Aprobar calificación" CssClass="Button_General" width="125px" onclick="btnAprobar_Click" /> &nbsp;&nbsp;
					<asp:Button ID="btnCancelar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnCancelar_Click" />
                </td>
            </tr>
        </table>

	</div>

	<asp:HiddenField ID="hddSolicitudId" runat="server" Value="0"  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />

</asp:Content>
