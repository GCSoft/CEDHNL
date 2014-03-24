<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarAutoridaSenalada.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarAutoridaSenalada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table  border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align:left;">
         <tr>
			   <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
				     Agregar autoridades señaladas
                     </td>
	    </tr>
    </table>
     <br />
    <table style="text-align:left; font-size:11px">
      <tr>
        <td colspan="3" >Seleccione los distintos niveles de la autoridad a señalar en la solicitud</td>
      </tr>
           <tr>
            <td class="style2"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Solicitud número</td>
        <td class="style12"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
        <td rowspan="13" style="vertical-align:super">
            <table width="100%" border="0">
              <tr>
                <td style="width:10px"></td>
                <td style="border:0px">
                     <table width="100%" border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td style="background-color:#DDDDFF; height:30px; font-size:10px; border:0px; text-align:center;"> &nbsp;Autoridades Señaladas a la Solicitud&nbsp;</td>
                          </tr>
                          <tr>
                            <td style="height:175px; background-color:#EFF2FB; vertical-align: top;"> <!--aqui se estaran ingresando los ciudadanos agregados-->
                               <asp:GridView id="gvAutoridadesAgregadas" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False"
                                 DataKeyNames="CiudadanoId" OnRowCommand="gvAutoridadesAgregadas_RowCommand" BorderWidth="0"> 
                                <headerstyle cssclass="Grid_Encabezado" />
                                <rowstyle cssclass="Grid_Filas" />
                                <EmptyDataRowStyle CssClass="Empty" BorderStyle="None" BorderWidth="0px" />
                                 <EmptyDataTemplate>
                                    <table border="0px" cellpadding="0" style="border:0px;" cellspacing="0">
                                      <tr>
                                        <td style="height:5px"></td>
                                      </tr>
                                      <tr>
                                        <td style="font-size:9.5px; text-align:center;">No se han agregado autoridades a la solicitud</td>
                                      </tr>
                                      <tr>
                                        <td style="height:130px;"></td>
                                      </tr>
                                    </table>
                                 </EmptyDataTemplate>
                                 <Columns>
                                 <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:LinkButton Width="150px" CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="SelectCiudadano" ID="CiudadanoButton" runat="server" Text='<%#Eval("NombreCompleto")%>'></asp:LinkButton>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                 <asp:TemplateField>
                                 <ItemTemplate>
                                 <asp:ImageButton CommandArgument='<%#Eval("CiudadanoId")%>' CommandName="Eliminar"  runat="server" ID="ImagenEliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" Height="11px"> </asp:ImageButton>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 </Columns>
                                </asp:GridView>
                            </td>
                          </tr>
                     </table>
                </td>
              </tr>
            </table>
         </td>
           </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Primer nivel</td>
        <td class="style6"><asp:DropDownList runat="server" ID="ddlPrimerNivel" Width="330px" ></asp:DropDownList></td>
      </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Segundo nivel</td>
        <td class="style6"><asp:DropDownList runat="server" ID="ddlSegundoNivel" Width="330px"  ></asp:DropDownList></td>
      </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Tercer nivel</td>
        <td class="style6"><asp:DropDownList runat="server" ID="ddlTercerNivel" Width="330px"  ></asp:DropDownList></td>
      </tr>
                       <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Nombre funcionario público a cargo</td>
        <td class="style6"><asp:TextBox runat="server" ID="tbNombreFuncionario" Width="200px" CssClass="Textbox_General" ></asp:TextBox></td>
      </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Puesto actual</td>
        <td class="style6"><asp:TextBox runat="server" ID="tbPuestoActual" Width="200px" CssClass="Textbox_General" ></asp:TextBox></td>
      </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
      <tr>
        <td class="EspacioIntermedio">Comentarios</td>
        <td class="style6"><asp:TextBox runat="server" ID="tbComentarios" Width="330px" Height="90px" TextMode="MultiLine" CssClass="Textbox_General" ></asp:TextBox></td>
      </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
                 <tr>
            <td class="EspacioIntermedio"></td>
          </tr>
          <tr>
       <td colspan="2">
       <table width="100%" border="0">
           <tr>
           <td style="text-align:left; width: 139px;"><asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="Button_General" width="125px"/></td>
           <td style="text-align:left;"><input class="Button_General" id="RegresarButton" onclick="document.location.href='opeDetalleSolicitud.aspx?s=<%= _SolicitudId %>';" style="width: 125px;" type="button" value="Regresar" /></td>
           </tr>
           </table>
       </td>
      </tr>
</table>

</asp:Content>

