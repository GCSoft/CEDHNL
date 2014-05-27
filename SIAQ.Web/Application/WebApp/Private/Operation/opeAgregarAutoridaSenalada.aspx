<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeAgregarAutoridaSenalada.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarAutoridaSenalada" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Agregar autoridad y voces señaladas
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace_Title"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" style="text-align:left; font-size:11px" width="100%">
                        <tr>
                            <td colspan="3">Seleccione los distintos niveles de la autoridad y voces a señalar en la solicitud</td>
                        </tr>
                        <tr><td class="style2"></td></tr>
                        <tr>
                            <td colspan="3">
                                <div id="InformacionDiv">
                                    <table class="SolicitudTable">
                                        <tr>
                                            <td class="Especial" style="width:150px">Solicitud Número</td>
                                            <td class="Campo" style="text-align:left;"><asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
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
                            <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnAgregarAutoridad" runat="server" Text="Agregar autoridad" CssClass="Button_General" width="125px" onclick="btnAgregarAutoridad_Click" /></td>
                            <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" /></td>
							<td style="height:24px;">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr><td class="tdCeldaMiddleSpace"></td></tr>
        <tr>
            <td>
                <asp:Panel id="pnlGrid" runat="server" Width="100%">
                    <asp:GridView id="gvAutoridades" runat="server" AllowPaging="false" AllowSorting="true" AutoGenerateColumns="False" Width="100%"
                        DataKeyNames="AutoridadId,Nombre"
                        OnRowCommand="gvAutoridades_RowCommand"
                        OnRowDataBound="gvAutoridades_RowDataBound"
                        OnSorting="gvAutoridades_Sorting">
                        <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                        <headerstyle cssclass="Grid_Header" />
                        <rowstyle cssclass="Grid_Row" />
                        <EmptyDataTemplate>
                            <table border="1px" cellpadding="0px" cellspacing="0px" width="100%">
                                <tr class="Grid_Header">
                                    <td style="width:140px;">Nombre</td>
                                    <td style="width:140px;">Puesto</td>
                                    <td style="width:140px;">Autoridad N1</td>
                                    <td style="width:140px;">Autoridad N2</td>
                                    <td style="width:140px;">Autoridad N3</td>
                                    <td>Comentarios</td>
                                </tr>
                                <tr class="Grid_Row">
                                    <td colspan="6">No se encontraron Autoridades añadidas a la solicitud</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Nombre de Autoridad"    ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nombre"      SortExpression="Nombre"></asp:BoundField>
                            <asp:BoundField HeaderText="Puesto"                 ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Puesto"      SortExpression="Puesto"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 1 Autoridad"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel1"      SortExpression="Nivel1"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 2 Autoridad"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel2"      SortExpression="Nivel2"></asp:BoundField>
                            <asp:BoundField HeaderText="Nivel 3 Autoridad"      ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="140px" DataField="Nivel3"      SortExpression="Nivel3"></asp:BoundField>
                            <asp:BoundField HeaderText="Comentarios"            ItemStyle-HorizontalAlign="Left"                            DataField="Comentarios" SortExpression="Comentarios"></asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="SelectButton" runat="server" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Seleccionar" ImageUrl="~/Include/Image/Buttons/AgregarVisita.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="EditButton" runat="server" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Editar" ImageUrl="~/Include/Image/Buttons/Edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="DeleteButton" runat="server" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Borrar" ImageUrl="~/Include/Image/Buttons/Delete.png" OnClientClick="return confirm('¿Seguro que desea eliminar esta autoridad?, Se eliminarán también sus respectivas voces señaladas.');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel id="pnlAction" runat="server" CssClass="ActionBlock" Visible="false" >
                    <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top: 200px;" Height="360px" Width="450px">
                        <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
                                <tr>
                                    <td style="width: 10px"></td>
                                    <td style="text-align: left;"><asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle"></asp:Label></td>
                                    <td style="vertical-align: middle; width: 14px;"><asp:ImageButton ID="imgActionCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgActionCloseWindow_Click"></asp:ImageButton></td>
                                    <td style="width: 10px"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                            <div style="margin:0 auto; width:98%;">
                                <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
                                    <tr style="height:20px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem" style="width:80px;">&nbsp;Primer nivel</td>
                                        <td style="width:5px;"></td>
                                        <td><asp:DropDownList ID="ddlActionPrimerNivel" runat="server" CssClass="DropDownList_General" Width="316px" AutoPostBack="True" OnSelectedIndexChanged="ddlActionPrimerNivel_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Segundo nivel</td>
                                        <td></td>
                                        <td><asp:DropDownList ID="ddlActionSegundoNivel" runat="server" CssClass="DropDownList_General" Width="316px" AutoPostBack="True" OnSelectedIndexChanged="ddlActionSegundoNivel_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Tercer nivel</td>
                                        <td></td>
                                        <td class="tdCeldaItem"><asp:DropDownList ID="ddlActionTercerNivel" runat="server" CssClass="DropDownList_General" Width="316px"></asp:DropDownList></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem" colspan="3">&nbsp;Nombre funcionario público a cargo</td>
                                    </tr>
                                    <tr style="height:1px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td></td>
                                        <td></td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="tbActionNombreFuncionario" runat="server" CssClass="Textbox_General" Width="310px" MaxLength="50"></asp:TextBox></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Puesto actual</td>
                                        <td></td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="tbActionPuestoActual" runat="server" CssClass="Textbox_General" Width="310px" MaxLength="50"></asp:TextBox></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem" style="vertical-align:top">&nbsp;Comentarios</td>
                                        <td></td>
                                        <td class="tdCeldaItem"><asp:TextBox ID="tbActionComentarios" runat="server" CssClass="Textbox_General" Width="310px" Height="70px" MaxLength="50" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr>
                                        <td colspan="3" style="text-align:right;">
                                            <asp:Button ID="btnActionAgregarAutoridad" runat="server" Text="Agregar" CssClass="Button_General" Width="125px" OnClick="btnActionAgregarAutoridad_Click" />&nbsp;&nbsp;
                                            <asp:Button ID="btnActionRegresarPop" runat="server" Text="Regresar" CssClass="Button_General" Width="125px" OnClick="btnActionRegresarPop_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblActionMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
                                        </td>
                                    </tr>
							   </table>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <ajaxToolkit:DragPanelExtender id="dragPanelAction" runat="server" TargetControlID="pnlActionContent" DragHandleID="pnlActionHeader"> </ajaxToolkit:DragPanelExtender>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel id="pnlVoces" runat="server" CssClass="ActionBlock" Visible="false" >
                    <asp:Panel ID="pnlVocesContent" runat="server" CssClass="ActionContent" Style="top: 200px;" Height="500px" Width="560px">
                        <asp:Panel ID="pnlVocesHeader" runat="server" CssClass="ActionHeader">
                            <table border="0" cellpadding="0" cellspacing="0" style="height:100%; width:100%">
                                <tr>
                                    <td style="width: 10px"></td>
                                    <td style="text-align: left;"><asp:Label ID="lblVocesTitle" runat="server" CssClass="ActionHeaderTitle" Text="Agregar voces a autoridad"></asp:Label></td>
                                    <td style="vertical-align: middle; width: 14px;"><asp:ImageButton ID="imgVocesCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png" ToolTip="Cerrar Ventana" OnClick="imgVocesCloseWindow_Click"></asp:ImageButton></td>
                                    <td style="width: 10px"></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlVocesBody" runat="server" CssClass="ActionBody">
                            <div style="margin:0 auto; width:98%;">
                                <table border="0" cellpadding="0" cellspacing="0" style="height:100%; text-align:left;" width="100%">
                                    <tr style="height:20px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Nombre de Autoridad</td>
                                        <td style="width:5px;"></td>
                                        <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNombre" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Puesto</td>
                                        <td style="width:5px;"></td>
                                        <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesPuesto" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Autoridad N1</td>
                                        <td style="width:5px;"></td>
                                        <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNivel1" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Autoridad N2</td>
                                        <td style="width:5px;"></td>
                                        <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNivel2" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Autoridad N3</td>
                                        <td style="width:5px;"></td>
                                        <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesNivel3" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Observaciones</td>
                                        <td style="width:5px;"></td>
                                        <td style="background-color:#ededed; font-size:12px; text-align:left;"><asp:Label ID="lblVocesObservaciones" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr class="trFilaItem">
                                        <td class="tdActionCeldaLeyendaItem">&nbsp;Voces agregadas</td>
                                        <td style="width:5px;"></td>
                                        <td></td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Panel id="pnlVocesTemporal" runat="server" Width="100%">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <div id="tblHeader_Voces" style="border:0px solid #000000; clear:both; position:relative; width:550px;">
                                                                <table cellspacing="0" rules="all" border="1" style="border-collapse:collapse; width:550px;">
                                                                    <tr class="Grid_Header_Action">
                                                                        <th scope="col" style="width:150px;">Primer nivel</th>
                                                                        <th scope="col" style="width:150px;">Segundo nivel</th>
                                                                        <th scope="col" style="width:150px;">Tercer nivel</th>
                                                                        <th scope="col"></th>
                                                                    </tr>
                                                                    <tr class="Grid_Header_Action">
                                                                        <th scope="col"><asp:DropDownList id="ddlVocesTemporal_Nivel1"  runat="server" AutoPostBack="True"  CssClass="DropDownList_General" Width="140px" OnSelectedIndexChanged="ddlVocesNivel1_SelectedIndexChanged"></asp:DropDownList></th>
                                                                        <th scope="col"><asp:DropDownList id="ddlVocesTemporal_Nivel2"  runat="server" AutoPostBack="True"  CssClass="DropDownList_General" Width="140px" OnSelectedIndexChanged="ddlVocesNivel2_SelectedIndexChanged"></asp:DropDownList></th>
                                                                        <th scope="col"><asp:DropDownList id="ddlVocesTemporal_Nivel3"  runat="server"                      CssClass="DropDownList_General" Width="140px"></asp:DropDownList></th>
                                                                        <th scope="col"><asp:Button ID="btnVocesTemporal_Nuevo"         runat="server"                      CssClass="Button_General"  Text="Agregar" width="90px" onclick="btnVocesTemporal_Nuevo_Click" /></th>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div id="tblBody_VocesTemporal" style="border:0px solid #000000; clear:both; position:relative; top:-1px; width:100%;">
                                                                <asp:GridView id="gvVocesTemporal" runat="server" border="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="False" ShowHeader="false" Width="550px"
                                                                    DataKeyNames="VozId"
                                                                    OnRowCommand="gvVocesTemporal_RowCommand"
                                                                    OnRowDataBound="gvVocesTemporal_RowDataBound">
                                                                    <alternatingrowstyle cssclass="Grid_Row_Alternating" />
                                                                    <rowstyle cssclass="Grid_Row" />
                                                                    <EmptyDataTemplate>
                                                                        <div class="Grid_Row" style="border:1px solid #C1C1C1; clear:both; left:-1px; position:relative; text-align:center; top:-2px; width:548px;">
                                                                            Agregue voces señaladas
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                    <Columns>
                                                                        <asp:BoundField		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="146px"	DataField="Voz1"></asp:BoundField>
                                                                        <asp:BoundField		ItemStyle-HorizontalAlign="Left"    ItemStyle-Width="146px"	DataField="Voz2"></asp:BoundField>
                                                                        <asp:BoundField		ItemStyle-HorizontalAlign="Left"	ItemStyle-Width="147px"	DataField="Voz3"></asp:BoundField>
                                                                        <asp:TemplateField	ItemStyle-HorizontalAlign ="Center">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="imgEliminar" CommandArgument="<%#Container.DataItemIndex%>" CommandName="Eliminar" ImageUrl="~/Include/Image/Buttons/Delete.png" ToolTip="Eliminar VocesTemporal" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr style="height:5px;"><td colspan="3"></td></tr>
                                    <tr>
                                        <td colspan="3" style="text-align:right;">
                                            <asp:Button ID="btnVocesRegresar" runat="server" Text="Regresar" CssClass="Button_General" Width="125px" OnClick="btnVocesRegresar_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblVocesMessage" runat="server" CssClass="ActionContentMessage"></asp:Label>
                                        </td>
                                    </tr>
							   </table>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <ajaxToolkit:DragPanelExtender id="dragPanelVoces" runat="server" TargetControlID="pnlVocesContent" DragHandleID="pnlVocesHeader"> </ajaxToolkit:DragPanelExtender>
                </asp:Panel>
            </td>
        </tr>
        <tr class="trFilaFooter"><td></td></tr>
        <asp:HiddenField ID="hdnAutoridadId" runat="server" />
        <asp:HiddenField ID="hddSort" runat="server" Value="Nombre" />
        <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
    </table>
</asp:Content>
