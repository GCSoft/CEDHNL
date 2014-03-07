<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarDocumentos.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarDocumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
	            Agregar documentos a la solicitud
            </td>
		</tr>
        <tr>
            <td class="SubTitulo">Agregue aquellos documentos que sirvan para complementar la información de la solicitud</td>
        </tr>
        <tr>
            <td>
                <table border="0" style="width: 460px">
                    <tr>
                        <td class="Especial">Solicitud número</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
                        <td class="Espacio"></td>
                        <td class="Agregados" rowspan="6">
                                <table border="0" cellpadding="0" cellspacing="0" 
                                    style="width: 78%; margin-left: 44px; margin-top: 7px">
                                    <tr>
                                    <td style="background-color:#DDDDFF; font-size:10px; border:1px solid #333333;">Archivos agregados a la solicitud</td>
                                    </tr>
                                    <tr>
                                    <td style="background-color:#FBFBFF; font-size:10px; border:1px solid #333333;">
                                        <asp:CheckBoxList ID="chkListCiudadanos" runat="server"></asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Nombre">Archivo</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:FileUpload ID="DocumentoFile" runat="server" Width="210px" /></td>
                        <td class="Espacio"></td>
                    </tr>
                    <tr>
                        <td class="Nombre">Nombre</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:TextBox ID="NombreText" runat="server" CssClass="Textbox_General" width="210px" ></asp:TextBox></td>
                        <td class="Espacio"></td>
                    </tr>
                    <tr>
                        <td class="Nombre">Descripción</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:TextBox ID="DescripcionText" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
                        <td class="Espacio"></td>
                    </tr>
                    <tr>
                        <td class="Botones" colspan="5">
                            <br />
                            <asp:Button ID="GuardarButton" runat="server" Text="Agregar" CssClass="Button_General" width="125px" onclick="GuardarButton_Click"/>
                            <input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

