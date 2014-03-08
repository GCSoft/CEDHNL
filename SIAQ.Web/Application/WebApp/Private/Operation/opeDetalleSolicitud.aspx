<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeDetalleSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <div id="TituloPaginaDiv">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="tdCeldaTituloEncabezado">
                    Detalle de Solictud
                </td>
            </tr>
        </table>
    </div>

    <div id="SubMenuDiv">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width:65px;"><asp:ImageButton ID="InformacionGeneralButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png" runat="server" onclick="InformacionGeneralButton_Click"></asp:ImageButton></td>
                <td></td>
                <td style="width:65px;"><asp:ImageButton ID="CiudadanoButton" ImageUrl="/Include/Image/Icon/CiudadanoIcon.png" runat="server" onclick="CiudadanoButton_Click"></asp:ImageButton></td>
                <td></td>
                <td style="width:65px;"><asp:ImageButton ID="AutoridadButton" ImageUrl="/Include/Image/Icon/GeneralIcon.png" runat="server" onclick="AutoridadButton_Click"></asp:ImageButton></td>
                <td></td>
                <td style="width:65px;"><asp:ImageButton ID="IndicadorButton" ImageUrl="/Include/Image/Icon/IndicadorIcon.png" runat="server" onclick="IndicadorButton_Click"></asp:ImageButton></td>
                <td></td>
                <td style="width:65px;"><asp:ImageButton ID="DocumentoButton" ImageUrl="/Include/Image/Icon/DocumentoIcon.png" runat="server" onclick="DocumentoButton_Click"></asp:ImageButton></td>
                <td></td>
                <td style="width:65px;"><asp:ImageButton ID="CalificarButton" ImageUrl="/Include/Image/Icon/CalificarIcon.png" runat="server" onclick="CalificarButton_Click"></asp:ImageButton></td>
                <td></td>
                <td style="width:65px;"><asp:ImageButton ID="EnviarButton" ImageUrl="/Include/Image/Icon/EnviarIcon.png" runat="server" onclick="EnviarButton_Click"></asp:ImageButton></td>
            </tr>
            <tr style=" height:2px;"><td colspan="13"></td></tr>
            <tr>
                <td style="width:65px; font-size:10px;">Información general</td>
                <td></td>
                <td style="width:65px; font-size:10px;">Agregar ciudadanos</td>
                <td></td>
                <td style="width:65px; font-size:10px;">Agegar autoridades señaladas y voces</td>
                <td></td>
                <td style="width:65px; font-size:10px;">Indicadores</td>
                <td></td>
                <td style="width:65px; font-size:10px;">Agregar documentos</td>
                <td></td>
                <td style="width:65px; font-size:10px;">Calificar solicitud</td>
                <td></td>
                <td style="width:65px; font-size:10px;">Enviar solicitud</td>
            </tr>
            <tr style=" height:30px; "><td colspan="13"></td></tr>
        </table>
    </div>

    <div id="InformacionDiv">
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
                <td class="Nombre">Fecha de asignación</td><td class="Espacio"></td>
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
				<td class="Campo" colspan="5"><asp:DropDownList ID="LugarHechosList" runat="server" CssClass="DropDownList_General" width="198px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td class="Nombre">Dirección de los hechos</td>
                <td class="Espacio"></td>
				<td class="Campo" colspan="5"><asp:TextBox CssClass="Textarea_General" ID="DireccionHechosBox" runat="server" TextMode="multiline" width="193px" ></asp:TextBox></td>
            </tr>
        </table>

        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td style="text-align:left;">Ciudadanos</td></tr>
            <tr>
                <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" DataKeyNames="SolicitudId" ID="gvCiudadano" PageSize="30"
                            runat="server" ShowHeaderWhenEmpty="True" Style="text-align: center" UpdateAfterCallBack="True" Width="800px" >
                            <RowStyle CssClass="Grid_Row" />
                            <EditRowStyle Wrap="True" />
                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                            <EmptyDataTemplate>
                                <table border="1px" cellpadding="0px" cellspacing="0px" width="800px">
						            <tr class="Grid_Header">
							            <td style="width:100px;">Nombre</td>
							            <td style="width:50px;">Sexo</td>
                                        <td style="width:100px;">Fecha nacimiento</td>
                                        <td style="width:200px;">Domicilio</td>
                                        <td style="width:100px;">Telefono</td>
                                        <td style="width:100px;">Tipo</td>
                                        <td style="width:50px;">Editar</td>
						            </tr>
						            <tr class="Grid_Row">
							            <td colspan="7">No se encontraron Ciudadanos registrados en el sistema</td>
						            </tr>
					            </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="NombreCiudadano" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField DataField="NombreSexo" HeaderText="Sexo"></asp:BoundField>
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento"></asp:BoundField>
                                <asp:BoundField DataField="Domicilio" HeaderText="Funcionario"></asp:BoundField>
                                <asp:BoundField DataField="TelefonoPrincipal" HeaderText="Estatus"></asp:BoundField>
                                <asp:BoundField DataField="NombreTipoCiudadano" HeaderText="Quejosos"></asp:BoundField>
                                <asp:TemplateField HeaderText="Borrar">
                                    <ItemTemplate></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>
                </asp:Panel>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr><td style="text-align:left;">Autoridades</td></tr>
            <tr>
                <td>
                <asp:Panel id="pnlGrid2" runat="server" Width="100%">
                    <asp:GridView ID="gvAutoridades" runat="server" AutoGenerateColumns="False"
                            AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="800px" 
                            Style="text-align: center" DataKeyNames="Solicitud"
                            PageSize="30" ShowHeaderWhenEmpty="True">
                            <RowStyle CssClass="Grid_Row" />
                            <EditRowStyle Wrap="True" />
                            <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                            <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                            <EmptyDataTemplate>
                                <table border="1px" cellpadding="0px" cellspacing="0px" width="800px">
						            <tr class="Grid_Header">
							            <td style="width:100px;">Nombre</td>
							            <td style="width:50px;">Sexo</td>
                                        <td style="width:100px;">Fecha nacimiento</td>
                                        <td style="width:200px;">Domicilio</td>
                                        <td style="width:100px;">Telefono</td>
                                        <td style="width:100px;">Tipo</td>
                                        <td style="width:50px;">Editar</td>
						            </tr>
						            <tr class="Grid_Row">
							            <td colspan="7">No se encontraron Autoridades registradas en el sistema</td>
						            </tr>
					            </table>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"></asp:BoundField>
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha nacimiento"></asp:BoundField>
                                <asp:BoundField DataField="Domicilio" HeaderText="Funcionario"></asp:BoundField>
                                <asp:BoundField DataField="Telefono" HeaderText="Estatus"></asp:BoundField>
                                <asp:BoundField DataField="Tipo" HeaderText="Quejosos"></asp:BoundField>
                            
                            </Columns>
                    </asp:GridView>
                </asp:Panel>
                </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
            <td>
                <asp:panel ID="pnlDocumentos" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="text-align:left;">Documentos anexos</td>
                        </tr>
                        <tr style=" height:3px;"><td colspan="4"></td></tr>
                        <tr>
                            <td style="text-align:left;"><asp:ImageButton ID="imgWord" runat="server" ImageUrl="~/Include/Image/Web/word.png"></asp:ImageButton></td>
                            <td style="text-align:left;"><asp:ImageButton ID="imgPdf" runat="server" ImageUrl="~/Include/Image/Web/pdf.png"></asp:ImageButton></td>
                            <td style="text-align:left;"><asp:ImageButton ID="imgImages" runat="server" ImageUrl="~/Include/Image/Web/imgs.png"></asp:ImageButton></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="tdCeldaLeyendaItemFondoBlanco">Dictamen médico</td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">Anotaciones</td>
                            <td class="tdCeldaLeyendaItemFondoBlanco">Foto 1</td>
                            <td></td>
                        </tr>
                        <tr style=" height:3px;"><td colspan="4"></td></tr>
                        <tr>
                            <td colspan="4" style="text-align:left;">Asuto de la solicitud</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="background-color:Gray;">Barra de Herramientas</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="background-color:Gray;">
                            <asp:TextBox ID="txtAsunto" runat="server" TextMode="MultiLine" CssClass="Textarea_General" Width="800px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:panel>
            </td>
            </tr>
            <tr><td class="tdCeldaMiddleSpace"></td></tr>
            <tr>
                <td style="text-align: left;">
                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar información de solicitud" CssClass="Button_General" width="200px" onclick="GuardarButton_Click" />
                    <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeBusquedaSolicitud.aspx';" style="width: 125px;" type="button" value="Regresar" />
                </td>
            </tr>
        </table>
    </div>

    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
</asp:Content>
