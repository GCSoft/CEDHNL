<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="VicDetalleAtencion.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Seguimiento.VicDetalleAtencion" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
	
	<div id="TituloPaginaDiv">
        <table class="GeneralTable">
            <tr>
                <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                    Detalle de Atención
                </td>
            </tr>
            <tr>
                <td class="SubTitulo">
                    <asp:Label ID="Label2" runat="server" Text="Proporcione la información solicitada para dar seguimiento a la atención."></asp:Label>
                </td>
            </tr>
        </table>
    </div>

	<div id="SubMenuDiv">
        <asp:Panel CssClass="IconoPanel" ID="pnlInformacion" runat="server" Visible="true">
            <asp:ImageButton ID="InformacionGeneralButton" ImageUrl="~/Include/Image/Icon/GeneralIcon.png" runat="server" OnClick="InformacionGeneralButton_Click"></asp:ImageButton><br />
            Información general
        </asp:Panel>
		 <asp:Panel CssClass="IconoPanel" ID="AsignarPanel" runat="server" Visible="true">
            <asp:ImageButton ID="AsignarButton" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="AsignarButton_Click"></asp:ImageButton><br />
            Asignar médico
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="pnlDictamenMedico" runat="server" Visible="true">
            <asp:ImageButton ID="DictamenMedicoButton" ImageUrl="~/Include/Image/Icon/AsignarIcon.png" runat="server" OnClick="DictamenMedicoButton_Click"></asp:ImageButton><br />
            Dictámen Médico
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="pnlAgregarDocumento" runat="server" Visible="true">
            <asp:ImageButton ID="AgregarDocumentoButton" ImageUrl="~/Include/Image/Icon/DocumentoIcon.png" runat="server" OnClick="AgregarDocumentoButton_Click"></asp:ImageButton><br />
            Agregar Documentos
        </asp:Panel>
		<asp:Panel CssClass="IconoPanel" ID="CerrarExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="CerrarExpedienteButton" ImageUrl="~/Include/Image/Icon/CerrarExpedienteIcon.png" runat="server" OnClick="CerrarExpedienteButton_Click"></asp:ImageButton><br />
            Cerrar Expediente de Atención
        </asp:Panel>
        <asp:Panel CssClass="IconoPanel" ID="ConfirmarCierreExpedientePanel" runat="server" Visible="true">
            <asp:ImageButton ID="ConfirmarCierreExpedienteButton" ImageUrl="~/Include/Image/Icon/ConfirmacionCierreIcon.png" runat="server" OnClick="ConfirmarCierreExpedienteButton_Click"></asp:ImageButton><br />
            Confirmar Cierre de Expediente de Atención
        </asp:Panel>
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
        </table>
        
		<!-- Detalle -->
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    Detalle
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvAtencionDetalle" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
						DataKeyNames="AtencionDetalleId" 
						OnRowDataBound="gvAtencionDetalle_RowDataBound"
                        OnSorting="gvAtencionDetalle_Sorting">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" width="100%" cellpadding="0px" cellspacing="0px">
                                <tr class="Grid_Header">
									<td style="width:50px;">No</td>
									<td>Detalle</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="2">No se encontraron Puntos Resolutivos asociados a la Recomendacion/Acuerdo de No Responsabilidad</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
							<asp:BoundField HeaderText="No"			ItemStyle-HorizontalAlign="Center"	ItemStyle-Width="50px"	DataField="RowNumber"						SortExpression="RowNumber"></asp:BoundField>
							<asp:BoundField HeaderText="Detalle"	ItemStyle-HorizontalAlign="Left"							DataField="Detalle"		HtmlEncode="false"	SortExpression="Detalle"></asp:BoundField>
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

	<asp:HiddenField ID="hddAtencionId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddEstatusId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddFuncionarioId" runat="server" Value="0"  />
	<asp:HiddenField ID="Sender" runat="server" Value=""  />
	<asp:HiddenField ID="SenderId" runat="server" Value="0"  />
	<asp:HiddenField ID="hddSort" runat="server" Value="Numero" />

</asp:Content>
