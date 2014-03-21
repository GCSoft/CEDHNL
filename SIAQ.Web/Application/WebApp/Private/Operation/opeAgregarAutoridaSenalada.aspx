﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarAutoridaSenalada.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarAutoridaSenalada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <style type="text/css">
        .style6
        {
            width: 394px;
        }
        .style7
        {
            width: 211px;
        }
        .style8
        {
            width: 149px;
        }
        .style9
        {
            height: 13px;
            width: 211px;
        }
        .style10
        {
            font-size: 15px;
            font-weight: bold;
            text-align: left;
            width: 211px;
        }
        .style11
        {
            height: 9px;
            width: 211px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
         <tr>
			    <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				     Agregar autoridades señaladas
                     </td>
	    </tr>
    </table>
     <br />
<table  border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;" >
      <tr>
        <td colspan="3" >Seleccione los distintos niveles de la autoridad a señalar en la solicitud</td>
      </tr>
           <tr>
            <td class="style9"></td>
          </tr>
      <tr>
        <td class="style10">Solicitud número</td>
        <td style="width:5px;"></td>
        <td class="tdCeldaItem"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabelSearch" runat="server" Text="0"></asp:Label></td>
        <td style="width:5px;"></td>
        <td rowspan="13">
                  <table border="0" cellpadding="0" cellspacing="0" 
                      style="width: 78%; margin-left: 44px; margin-top: 0px; bottom:120px; height: 212px;">
                     <tr>
                     <td style="background-color:#DDDDFF; font-size:10px; border:1px solid #333333; height:20px;" >Autoridades señaladas en la solicitud</td>
                     </tr>
                     <tr>
                     <td style="background-color:#FBFBFF; font-size:10px; border:1px solid #333333; height:300px">
                     <asp:CheckBoxList ID="chkListCiudadanos" runat="server"></asp:CheckBoxList>
                     </td>
                    </tr>
                </table>
        </td>
      </tr>
                 <tr>
            <td class="style11"></td>
          </tr>
      <tr>
        <td class="style7">Primer nivel</td>
        <td class="style6"><asp:DropDownList runat="server" ID="ddlPrimerNivel" Width="370px" ></asp:DropDownList></td>
      </tr>
                 <tr>
            <td class="style9"></td>
          </tr>
      <tr>
        <td class="style7">Segundo nivel</td>
        <td class="style6"><asp:DropDownList runat="server" ID="ddlSegundoNivel" Width="370px"  ></asp:DropDownList></td>
      </tr>
                 <tr>
            <td class="style9"></td>
          </tr>
      <tr>
        <td class="style7">Tercer nivel</td>
        <td class="style6"><asp:DropDownList runat="server" ID="ddlTercerNivel" Width="370px"  ></asp:DropDownList></td>
      </tr>
                       <tr>
            <td class="style9"></td>
          </tr>
      <tr>
        <td class="style7">Nombre funcionario público a cargo</td>
        <td class="style6"><asp:TextBox runat="server" ID="tbNombreFuncionario" Width="200px" CssClass="Textbox_General" ></asp:TextBox></td>
      </tr>
                 <tr>
            <td class="style9"></td>
          </tr>
      <tr>
        <td class="style7">Puesto actual</td>
        <td class="style6"><asp:TextBox runat="server" ID="tbPuestoActual" Width="200px" CssClass="Textbox_General" ></asp:TextBox></td>
      </tr>
                 <tr>
            <td class="style9"></td>
          </tr>
      <tr>
        <td class="style7">Comentarios</td>
        <td class="style6"><asp:TextBox runat="server" ID="tbComentarios" Width="370px" Height="90px" TextMode="MultiLine" CssClass="Textbox_General" ></asp:TextBox></td>
      </tr>
                 <tr>
            <td class="style9"></td>
          </tr>
                 <tr>
            <td class="style9"></td>
          </tr>
          <tr>
       <td colspan="2">
                     <table width="100%" border="0">
                      <tr>
           <td style="text-align:left;" class="style8"><asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="Button_General" width="125px"/></td>
           <td style="text-align:left;" class="style3"><input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" /></td>
           </tr>
           </table>
       </td>
      </tr>
</table>

</asp:Content>

