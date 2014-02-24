<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAprobarResolucionTitular.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAprobarResolucionTitular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
			<td class="tdCeldaTituloEncabezado">
				Aprobar resolución
			</td>
		</tr>
      <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
      <tr>
         <td>
         <asp:Label ID="Label1" runat="server" Text="Indique si la resolución del expediente es aprobada o no dependiendo de la información proporcionada."></asp:Label>
         <br /><br />
         </td>      
      </tr>
      <tr>
         <td>
            <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Expediente Número</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:Label ID="lbNumeroSolictud" runat="server" Text="2000"></asp:Label></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:20px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Tipo de resolución</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtTipoResolucion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha recepción</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaRecepcion" runat="server" CssClass="Textbox_General" Width="177"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Estatus</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtEstatus" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha asignación</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaAsignacion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Visitador</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFuncionario" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha inicio gestión</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaGestion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Núm de recomendación</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtNumerorecomendacion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco">Fecha resolución</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtFechaResolucion" runat="server" CssClass="Textbox_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco"><asp:Button ID="btnAprobar" runat="server" CssClass="Button_General_Verde" Text="Aprobar sesolución" Width="120px"></asp:Button></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:Button ID="btnRechazar" runat="server" CssClass="Button_General_Verde" Text="Rechazar sesolución" Width="120px"></asp:Button></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:30px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td colspan="8" style="background-color:#CCCCCC; text-align:left;">&nbsp;&nbsp;Detalle del expediente</td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Tipo de solicitud</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtTipoSolicitud" runat="server" CssClass="Textbox_General"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Observaciones (Recepción)</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem" colspan="5"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="Textarea_General" width="586px" ></asp:TextBox>&nbsp;</td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Lugar de los hechos</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtLugarHechos" runat="server" CssClass="Textbox_General"></asp:TextBox></td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                    <tr style=" height:3px;"><td colspan="8"></td></tr>
                    <tr class="trFilaItem">
                        <td class="tdCeldaLeyendaItemFondoBlanco">Dirección de los hechos</td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"><asp:TextBox ID="txtDireccionHechos" runat="server" CssClass="Textarea_General" width="177px" ></asp:TextBox>&nbsp;</td>
                        <td style="width:5px;"></td>
                        <td class="tdCeldaLeyendaItemFondoBlanco"></td>
                        <td style="width:5px;"></td>
						<td class="tdCeldaItem"></td>
                        <td style="width:5px;"></td>
                    </tr>
                </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr><td style="text-align:left;">Ciudadanos</td></tr>
      <tr>
         <td>
            <asp:Panel id="pnlGrid" runat="server" Width="100%">
               <asp:GridView ID="gvCiudadano" runat="server" AutoGenerateColumns="False"
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
									<td colspan="7">No se encontraron Ciudadanos registrados en el sistema</td>
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
                    <tr style=" height:10px;"><td colspan="4"></td></tr>
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
         <td>
            <asp:Panel id="pnlBotones" runat="server" Width="100%">
               <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                     <td style="height:24px; text-align:left; width:130px;"></td>
                     <td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
    </table>
</asp:Content>
