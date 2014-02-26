<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarVocesSenaladas.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarVocesSenaladas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
            .style2
            {
                height: 30px;
            }
            .style3
            {
                height: 46px;
            }
            .style5
            {
                height: 35px;
                width: 126px;
                color:#979393;
	            font-family:Verdana;
	            font-size:13px;
	            font-weight:bold;
	            height: 27px;
	            text-align:left;
            }
            .style6
            {
                height: 26px;
                width: 126px;
            }
            .style7
            {
                width: 126px;
            }
            .style8
            {
                height: 46px;
                width: 131px;
            }
            .style9
            {
                height: 35px;
            width: 158px;
        }
        .style10
        {
            height: 26px;
            width: 158px;
        }
        .style11
        {
            width: 158px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
         <tr>
			    <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				     Agregar voces señaladas
                     </td>
	    </tr>
    </table>
        <br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;">
            <tr>
              <td colspan="3" class="style2">Seleccione los distintos niveles de las voces a señalar en la solicitud</td>
            </tr>
            <tr>
              <td class="style5">Solicitud número</td>
              <td class="style9"></td>
              <td rowspan="11">
                 <table border="0" cellpadding="0" cellspacing="0" 
                      style="width: 78%; margin-left: 44px; margin-top: 7px">
                     <tr>
                     <td style="background-color:#DDDDFF; font-size:10px; border:1px solid #333333;">Voces señaladas en la solicitud</td>
                     </tr>
                     <tr>
                     <td style="background-color:#FBFBFF; font-size:10px; height:60px; border:1px solid #333333;">
                     <asp:CheckBoxList ID="chkListCiudadanos" runat="server"></asp:CheckBoxList>
                     </td>
                    </tr>
                </table>
              </td>
           </tr>
          <tr>
            <td style="height:9px"></td>
          </tr>
            <tr>
              <td class="style6">Primer nivel</td>
              <td class="style10"><asp:DropDownList ID="ddlPrinerNivel" runat="server" CssClass="DropDownList_General" Width="360"></asp:DropDownList></td>
            </tr>
           <tr>
            <td style="height:9px"></td>
          </tr>
            <tr>
              <td class="style6">Segundo nivel</td>
              <td class="style10"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropDownList_General" Width="360"></asp:DropDownList></td>
            </tr>
            <tr>
            <td style="height:9px"></td>
          </tr>
            <tr>
              <td class="style6">Tercer nivel</td>
              <td class="style10"><asp:DropDownList ID="DropDownList2" runat="server" CssClass="DropDownList_General" Width="360"></asp:DropDownList></td>
            </tr>
           <tr>
            <td style="height:9px"></td>
          </tr>
            <tr>
              <td class="style7">Comentarios</td>
              <td class="style11"><asp:TextBox ID="TextBoxMaterno" runat="server" CssClass="Textbox_General" TextMode="MultiLine" Height="100px" width="360px" ></asp:TextBox></td>
            </tr>
          <tr>
            <td style="height:9px"></td>
          </tr>
            <tr>
            <td></td>
            </tr>
            <tr>
              <td colspan="2">
              <table width="100%" border="0">
                      <tr>
                      <td style="text-align:left;" class="style8"><asp:Button ID="Button1" runat="server" Text="Aceptar" CssClass="Button_General" width="125px"/></td>
                      <td style="text-align:left;" class="style3"><asp:Button ID="Button2" runat="server" Text="Regresar" CssClass="Button_General" width="125px"/></td>
                      </tr>
            </table>
              </td>
            </tr>
    </table>
    </asp:Content>
