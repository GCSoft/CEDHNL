<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeAgregarAutoridaSenalada.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarAutoridaSenalada" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: left;">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image: url('../../../../Include/Image/Web/BarraTitulo.png');">
                Agregar autoridad y voces señaladas
            </td>
        </tr>
    </table>
    <br />
    <table style="text-align: left; font-size: 11px">
        <tr>
            <td colspan="3">
                Seleccione los distintos niveles de la autoridad y voces a señalar en la solicitud
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="InformacionDiv">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Especial">
                                Solicitud Número
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo">
                                <asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label>
                            </td>
                            <td style="width: 500px">
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="text-align: left;">
                            Autoridades
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlGrid" runat="server" Width="100%">
                                <asp:GridView AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" DataKeyNames="AutoridadId"
                                    ID="gvAutoridades" PageSize="30" runat="server" Style="text-align: center" UpdateAfterCallBack="True"
                                    Width="800px" OnRowCommand="gvAutoridades_RowCommand" OnRowDataBound="gvAutoridades_RowDataBound"
                                    OnSorting="gvAutoridades_Sorting">
                                    <RowStyle CssClass="Grid_Row" />
                                    <EditRowStyle Wrap="True" />
                                    <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                    <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                    <EmptyDataTemplate>
                                        <table border="1px" cellpadding="0px" cellspacing="0px" width="800px">
                                            <tr class="Grid_Header">
                                                <td style="width: 100px;">
                                                    Nombre
                                                </td>
                                                <td style="width: 50px;">
                                                    Puesto
                                                </td>
                                                <td style="width: 100px;">
                                                    Autoridad N1
                                                </td>
                                                <td style="width: 200px;">
                                                    Autoridad N2
                                                </td>
                                                <td style="width: 100px;">
                                                    Autoridad N3
                                                </td>
                                                <td style="width: 100px;">
                                                    Comentario
                                                </td>
                                                <td style="width: 50px;">
                                                    Editar
                                                </td>
                                                <td style="width: 50px;">
                                                    Borrar
                                                </td>
                                            </tr>
                                            <tr class="Grid_Row">
                                                <td colspan="7">
                                                    No se encontraron Ciudadanos registrados en el sistema
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="AutoridadId" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>
                                        <asp:BoundField DataField="Puesto" HeaderText="Puesto" SortExpression="Puesto"></asp:BoundField>
                                        <asp:BoundField DataField="Nivel1" HeaderText="Autoridad N1" SortExpression="Nivel1">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nivel2" HeaderText="Autoridad N2" SortExpression="Nivel2">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nivel3" HeaderText="Autoridad N3" SortExpression="Nivel3">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" SortExpression="Comentarios">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="SelectButton" runat="server" ImageUrl="~/Include/Image/Buttons/Edit.png"
                                                    CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Seleccionar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="EditButton" runat="server" ImageUrl="~/Include/Image/Buttons/Edit.png"
                                                    CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Include/Image/Buttons/Delete.png"
                                                    OnClientClick="return confirm('¿Seguro que desea eliminar esta autoridad?, se eliminarán también sus respectivas voces señaladas.');"
                                                    CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Borrar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCeldaMiddleSpace">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="AgregarAutoridadButton" runat="server" Text="Agregar autoridad"
                                CssClass="LinkButton_Regular" OnClick="AgregarAutoridadButton_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdCeldaMiddleSpace">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="DetallePanel" runat="server" Visible="false">
                    <table class="SolicitudTable">
                        <tr>
                            <td class="Nombre">
                                Nombre
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="NombreLabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Puesto
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="PuestoLabel" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Autoridad N1
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="Nivel1Label" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Autoridad N2
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="Nivel2Label" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Autoridad N3
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Etiqueta">
                                <asp:Label ID="Nivel3Label" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Nombre">
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Espacio">
                            </td>
                        </tr>
                        <tr>
                            <td class="Nombre">
                                Observaciones
                            </td>
                            <td class="Espacio">
                            </td>
                            <td class="Campo" colspan="5">
                                <asp:TextBox CssClass="Textarea_General" ID="ObservacionesBox" runat="server" TextMode="multiline"
                                    ReadOnly="true" Width="260px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="VocesPanel" runat="server" Visible="false">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="text-align: left;">
                                Voces señaladas
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="VocesGridPanel" runat="server" Width="100%">
                                    <asp:GridView AutoGenerateColumns="False" AutoUpdateAfterCallBack="True" DataKeyNames="VozId"
                                        ID="gvVoces" PageSize="30" runat="server" Style="text-align: center" UpdateAfterCallBack="True"
                                        Width="800px" OnRowCommand="gvVoces_RowCommand" OnRowDataBound="gvVoces_RowDataBound"
                                        OnSorting="gvVoces_Sorting">
                                        <RowStyle CssClass="Grid_Row" />
                                        <EditRowStyle Wrap="True" />
                                        <HeaderStyle CssClass="Grid_Header" ForeColor="#E3EBF5" />
                                        <AlternatingRowStyle CssClass="Grid_Row_Alternating" />
                                        <EmptyDataTemplate>
                                            <table border="1px" cellpadding="0px" cellspacing="0px" width="800px">
                                                <tr class="Grid_Header">
                                                    <td style="width: 100px;">
                                                        Voz N1
                                                    </td>
                                                    <td style="width: 50px;">
                                                        Voz N2
                                                    </td>
                                                    <td style="width: 100px;">
                                                        Voz N3
                                                    </td>
                                                    <td style="width: 50px;">
                                                        Borrar
                                                    </td>
                                                </tr>
                                                <tr class="Grid_Row">
                                                    <td colspan="7">
                                                        No se encontraron voces señaladas registradas en el sistema
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="VozId" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="Voz1" HeaderText="Voz N1" SortExpression="Voz1"></asp:BoundField>
                                            <asp:BoundField DataField="Voz2" HeaderText="Voz N2" SortExpression="Voz2"></asp:BoundField>
                                            <asp:BoundField DataField="Voz3" HeaderText="Voz N3" SortExpression="Voz3"></asp:BoundField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Include/Image/Buttons/Delete.png"
                                                        CommandArgument='<%#Eval("VozId")%>' CommandName="Borrar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdCeldaMiddleSpace">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkAgregarVoces" runat="server" Text="Agregar voces señaladas"
                                    CssClass="LinkButton_Regular" OnClick="lnkAgregarVoces_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdCeldaMiddleSpace">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnTerminar" runat="server" Text="Terminar" CssClass="Button_General"
                                    Width="125px" OnClick="btnTerminar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdCeldaMiddleSpace">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlAction" runat="server" CssClass="ActionBlock" Visible="false">
        <asp:Panel ID="pnlActionContent" runat="server" CssClass="ActionContent" Style="top: 200px;"
            Height="300px" Width="425px">
            <asp:Panel ID="pnlActionHeader" runat="server" CssClass="ActionHeader">
                <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%">
                    <tr>
                        <td style="width: 10px">
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="lblActionTitle" runat="server" CssClass="ActionHeaderTitle" Text="Asunto de la solicitud"></asp:Label>
                        </td>
                        <td style="vertical-align: middle; width: 14px;">
                            <asp:ImageButton ID="imgCloseWindow" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png"
                                ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton>
                        </td>
                        <td style="width: 10px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlActionBody" runat="server" CssClass="ActionBody">
                <div style="margin: 0 auto; width: 98%;">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; text-align: left;"
                        width="100%">
                        <tr>
                            <td class="style2">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Primer nivel
                            </td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlPrimerNivel" runat="server" CssClass="DropDownList_General"
                                    Width="216px" AutoPostBack="True" OnSelectedIndexChanged="ddlPrimerNivel_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Segundo nivel
                            </td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlSegundoNivel" runat="server" CssClass="DropDownList_General"
                                    Width="216px" AutoPostBack="True" OnSelectedIndexChanged="ddlSegundoNivel_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Tercer nivel
                            </td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlTercerNivel" runat="server" CssClass="DropDownList_General"
                                    Width="216px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Nombre funcionario público a cargo
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="tbNombreFuncionario" runat="server" CssClass="Textbox_General" Width="210px"
                                    MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Puesto actual
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="tbPuestoActual" runat="server" CssClass="Textbox_General" Width="210px"
                                    MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio" style="vertical-align: top">
                                Comentarios
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="tbComentarios" runat="server" CssClass="Textbox_General" Width="210px"
                                    Height="70px" MaxLength="50" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style="text-align: left; width: 139px;">
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="Button_General"
                                                Width="125px" OnClick="btnAgregar_Click" />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Button ID="btnRegresarPop" runat="server" Text="Regresar" CssClass="Button_General"
                                                Width="125px" OnClick="btnRegresarPop_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </asp:Panel>
        <ajaxToolkit:DragPanelExtender ID="dragPanelAction" runat="server" TargetControlID="pnlAction"
            DragHandleID="pnlActionHeader">
        </ajaxToolkit:DragPanelExtender>
    </asp:Panel>
    <asp:Panel ID="pnlVocesPop" runat="server" CssClass="ActionBlock" Visible="false">
        <asp:Panel ID="Panel2" runat="server" CssClass="ActionContent" Style="top: 200px;"
            Height="150px" Width="425px">
            <asp:Panel ID="pnlActionTitleVoces" runat="server" CssClass="ActionHeader">
                <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; width: 100%">
                    <tr>
                        <td style="width: 10px">
                        </td>
                        <td style="text-align: left;">
                            <asp:Label ID="Label1" runat="server" CssClass="ActionHeaderTitle" Text="Asunto de la solicitud"></asp:Label>
                        </td>
                        <td style="vertical-align: middle; width: 14px;">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Image/Buttons/CloseWindow.png"
                                ToolTip="Cerrar Ventana" OnClick="imgCloseWindow_Click"></asp:ImageButton>
                        </td>
                        <td style="width: 10px">
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlActionBodyVoces" runat="server" CssClass="ActionBody">
                <div style="margin: 0 auto; width: 98%;">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 100%; text-align: left;"
                        width="100%">
                        <tr>
                            <td class="style2">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Primer nivel
                            </td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlVocesNivel1" runat="server" CssClass="DropDownList_General"
                                    Width="216px" AutoPostBack="True" OnSelectedIndexChanged="ddlVocesNivel1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Segundo nivel
                            </td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlVocesNivel2" runat="server" CssClass="DropDownList_General"
                                    Width="216px" AutoPostBack="True" OnSelectedIndexChanged="ddlVocesNivel2_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                                Tercer nivel
                            </td>
                            <td class="style6">
                                <asp:DropDownList ID="ddlVocesNivel3" runat="server" CssClass="DropDownList_General"
                                    Width="216px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td class="EspacioIntermedio">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%" border="0">
                                    <tr>
                                        <td style="text-align: left; width: 139px;">
                                            <asp:Button ID="btnAgregarVoz" runat="server" Text="Agregar" CssClass="Button_General"
                                                Width="125px" OnClick="btnAgregarVoz_Click" />
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:Button ID="btnRegresarPopVoz" runat="server" Text="Regresar" CssClass="Button_General"
                                                Width="125px" OnClick="btnRegresarPopVoz_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </asp:Panel>
        <ajaxToolkit:DragPanelExtender ID="DragPanelExtender1" runat="server" TargetControlID="pnlVocesPop"
            DragHandleID="pnlActionTitleVoces">
        </ajaxToolkit:DragPanelExtender>
    </asp:Panel>
    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
    <asp:HiddenField ID="hdnAutoridadId" runat="server" />
    <asp:HiddenField ID="hddSort" runat="server" Value="NumeroSol" />
</asp:Content>
