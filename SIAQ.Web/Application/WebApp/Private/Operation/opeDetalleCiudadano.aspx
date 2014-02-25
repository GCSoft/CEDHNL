<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeDetalleCiudadano.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeDetalleCiudadano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
<style type="text/css">
    
.CeldaTabla 
{
    border-bottom: 1px solid #cccccc;
	background-color: #ececff;
	border-spacing: 5px;
	font-weight: bold;
	padding: 5px;
	text-align:left;
}

.PrimerColumna
{
   width:157px;
    
    }

.ColumnaTextBox1
{
   width:164px;
    
    }

.SegundaColumna
{
   width:286px;
    
    }
    
.ColumnaTextBox2
{
   width:165px;
    
    }

  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
     <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
			<td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">Detalle de Ciudadano</td>
		</tr>
          <tr>
                <td>&nbsp;</td>
             </tr>
          <tr>
                <td class="CeldaTabla">Información General</td>
          </tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
            <table width="100%" border="0" class="tdBusquedaAvanzada" style="text-align:left">
                  <tr>
                    <td>Nombre</td>
                    <td><asp:TextBox ID="TextBoxPa" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Escolaridad</td>
                    <td><asp:TextBox ID="TextBox1" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>Apellido Paterno</td>
                    <td><asp:TextBox ID="TextBox2" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Estado Civil</td>
                    <td><asp:TextBox ID="TextBox3" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>Apellido Materno</td>
                    <td><asp:TextBox ID="TextBox4" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Teléfono Principal</td>
                    <td><asp:TextBox ID="TextBox5" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>Sexo</td>
                    <td><asp:TextBox ID="TextBox6" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Otro Teléfono</td>
                    <td><asp:TextBox ID="TextBox7" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>Fecha nacimiento</td>
                    <td><asp:TextBox ID="TextBox8" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Correo Electrónico</td>
                    <td><asp:TextBox ID="TextBox9" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>Nacionalidad</td>
                    <td><asp:TextBox ID="TextBox10" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Dependientes Económicos</td>
                    <td><asp:TextBox ID="TextBox11" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td>Ocupacion</td>
                    <td><asp:TextBox ID="TextBox12" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                    <td>Forma de enterarse de la CEDH</td>
                    <td><asp:TextBox ID="TextBox13" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                  </tr>
                </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr><td class="CeldaTabla">Domicilio</td></tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Visible="true" Width="98%">
            <table width="100%" border="0" class="tdBusquedaAvanzada" style="text-align:left">
              <tr>
                <td class="PrimerColumna">País</td>
                <td class="ColumnaTextBox1"><asp:TextBox ID="TextBox14" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                <td class="SegundaColumna">Nombre de la calle</td>
                <td class="ColumnaTextBox2"><asp:TextBox ID="TextBox17" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="PrimerColumna" >Estado</td>
                <td class="ColumnaTextBox1"><asp:TextBox ID="TextBox15" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                <td class="SegundaColumna">Núm exterior</td>
                <td class="ColumnaTextBox2"><asp:TextBox ID="TextBox16" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="PrimerColumna">Ciudad</td>
                <td class="ColumnaTextBox1"><asp:TextBox ID="TextBox18" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                <td class="SegundaColumna">Núm interior</td>
                <td class="ColumnaTextBox2"><asp:TextBox ID="TextBox19" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="PrimerColumna">Colonia</td>
                <td class="ColumnaTextBox1"><asp:TextBox ID="TextBox20" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
                <td class="SegundaColumna">Años residiendo en NL</td>
                <td class="ColumnaTextBox2"><asp:TextBox ID="TextBox21" runat="server" CssClass="Textbox_General" Enabled="false"></asp:TextBox></td>
              </tr>
            </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr><td class="CeldaTabla">Solicitudes Intervención</td></tr>
       <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlSolcitudes" runat="server" Width="100%">
                      <asp:GridView ID="gvSolcitudes" runat="server" AutoGenerateColumns="False"
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
									<td style="width:100px;">Solicitud</td>
									<td style="width:100px;">Fecha</td>
                                    <td style="width:100px;">Participa como</td>
                                    <td style="width:100px;">Calificación</td>
                                    <td style="width:100px;">Expediente</td>
                                    <td style="width:100px;">Estatus</td>
                                    <td style="width:100px;">Tipo</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron Solicitudes registrados en el sistema</td>
								</tr>
							</table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Solicitud" HeaderText="Solicitud"></asp:BoundField>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha"></asp:BoundField>
                            <asp:BoundField DataField="Participa como" HeaderText="Participa como"></asp:BoundField>
                            <asp:BoundField DataField="Calificación" HeaderText="Calificación"></asp:BoundField>
                            <asp:BoundField DataField="Expediente" HeaderText="Expediente"></asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus"></asp:BoundField>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo"></asp:BoundField>
                        </Columns>
                </asp:GridView>
            </asp:Panel>
         </td>
                <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      </tr>
      <tr><td class="CeldaTabla">Visitas a la CEDH</td></tr>
            <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
        <td>
            <asp:panel ID="pnlVisitas" runat="server" Width="100%">
                        <asp:GridView ID="gvVisitas" runat="server" AutoGenerateColumns="False"
                        AutoUpdateAfterCallBack="True" UpdateAfterCallBack="True" Width="800px" 
                        Style="text-align: center" DataKeyNames="Visita"
                        PageSize="30" ShowHeaderWhenEmpty="True">
                        <RowStyle CssClass="Grid_Row" />
                        <EditRowStyle Wrap="True" />
                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="800px">
								<tr class="Grid_Header">
									<td style="width:100px;">Fecha</td>
									<td style="width:200px;">Funcionario visitado</td>
                                    <td style="width:100px;">Área Visitada</td>
                                    <td style="width:300px;">Motivo Visita</td>
								</tr>
								<tr class="Grid_Row">
									<td colspan="7">No se encontraron Visitas registrados en el sistema</td>
								</tr>
							</table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Solicitud"></asp:BoundField>
                            <asp:BoundField DataField="Funcionario visitado" HeaderText="Fecha"></asp:BoundField>
                            <asp:BoundField DataField="Área Visitada" HeaderText="Participa como"></asp:BoundField>
                            <asp:BoundField DataField="Motivo Visita" HeaderText="Calificación"></asp:BoundField>
                        </Columns>
                </asp:GridView>
            </asp:panel>
        </td>
               <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      </tr>
      <tr><td class="CeldaTabla">Documentos</td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlDocumentos" runat="server" Width="100%">
            No se encontron domentos para este ciudadano
            </asp:Panel>
            <br /><br />
         </td>
      </tr>
    </table>
</asp:Content>
