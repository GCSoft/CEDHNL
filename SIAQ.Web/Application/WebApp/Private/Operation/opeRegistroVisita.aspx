<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroVisita.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroVisita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style1
        {
            width: 118px;
        }
                
        .DetalleBox
        {
            font-family: Calibri, Verdana, Arial;
            height: 100px;
            width: 300px;
            
        }
        
        .Tamanoletra
        {
          font-size:11px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
	            Registrar visita
            </td>
		</tr>
        <tr>
            <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione la siguiente información para registrar una nueva visita en el sistema."></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
				    <table border="0" style="width: 460px">
                      <tr>
                        <td class="Etiqueta">Fecha</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:TextBox ReadOnly="true" ID="txtBoxFecha" width="183px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td class="Etiqueta">Hora</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><asp:TextBox ReadOnly="true" ID="txtBoxHora" width="183px" runat="server"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td class="Etiqueta">Área que visita</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><asp:DropDownList ID="ddlArea" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                      </tr>
                      <tr>
                        <td class="Etiqueta">Funcionario</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><asp:DropDownList ID="ddlFuncionario" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                      </tr>
                      <tr>
                        <td class="Etiqueta">Motivo</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><asp:DropDownList ID="ddlMotivo" runat="server" CssClass="DropDownList_General" width="183px"></asp:DropDownList></td>
                      </tr>
                      <tr>
                        <td class="Etiqueta">Detalle de visita</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><asp:TextBox CssClass="DetalleBox" ID="DescriptionBox" MaxLength="200" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                      </tr>
                    </table>	
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlBotones" runat="server" Width="100%">
                   <table border="0" cellpadding="0" cellspacing="0" width="100%">
                      <tr>
                        <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" OnClick="GuardarButton_Click" runat="server" Text="Guardar" CssClass="Button_General" width="125px" /></td>
                        <td style="height:24px; text-align:left; width:130px;"><input class="Button_General" id="RegresarButton" onclick="document.location.href='opeInicio.aspx';" style="width: 125px;" type="button" value="Regresar" /></td>
                        <td style="height:24px; width:530px;"></td>
                      </tr>
                   </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Label Text="Los campos marcados con " runat="server"></asp:Label> 
                <asp:Label CssClass="style3" Text="*" runat="server"></asp:Label>
                <asp:Label ID="Label1" Text="son obligatorios." runat="server"></asp:Label> 
            </td>
        </tr>
    </table>
</asp:Content>
