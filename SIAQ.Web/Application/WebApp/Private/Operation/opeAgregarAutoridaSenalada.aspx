<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master"
    AutoEventWireup="true" CodeBehind="opeAgregarAutoridaSenalada.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeAgregarAutoridaSenalada" %>

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
            <td colspan="3" style="background-color: #CCCCCC; text-align: left;">
                Autoridad señalada
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="EspacioIntermedio">
                Solicitud número
            </td>
            <td class="style12">
                <asp:Label CssClass="NumeroSolicitudLabel" ID="SolicitudLabel" runat="server" Text="0"></asp:Label>
            </td>
            <td rowspan="13" style="vertical-align: super">
                <table width="100%" border="0">
                    <tr>
                        <td style="width: 10px">
                        </td>
                        <td style="border: 0px">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="background-color: #DDDDFF; height: 30px; font-size: 10px; border: 0px;
                                        text-align: center;">
                                        &nbsp;Autoridades Señaladas a la Solicitud&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 175px; background-color: #EFF2FB; vertical-align: top;">
                                        <!--aqui se estaran ingresando los ciudadanos agregados-->
                                        <asp:GridView ID="gvAutoridadesAgregadas" runat="server" AllowPaging="false" AllowSorting="false"
                                            AutoGenerateColumns="False" DataKeyNames="AutoridadId"
                                            BorderWidth="0" onrowcommand="gvAutoridadesAgregadas_RowCommand" 
                                            onrowdatabound="gvAutoridadesAgregadas_RowDataBound">
                                            <HeaderStyle CssClass="Grid_Encabezado" />
                                            <RowStyle CssClass="Grid_Filas" />
                                            <EmptyDataRowStyle CssClass="Empty" BorderStyle="None" BorderWidth="0px" />
                                            <EmptyDataTemplate>
                                                <table border="0px" cellpadding="0" style="border: 0px;" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 9.5px; text-align: center;">
                                                            No se han agregado autoridades a la solicitud
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 130px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton Width="150px" CommandArgument='<%#Eval("AutoridadId")%>' CommandName="SelectCiudadano"
                                                            ID="CiudadanoButton" runat="server" Text='<%#Eval("Nombre")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton CommandArgument='<%#Eval("AutoridadId")%>' CommandName="Borrar"
                                                            runat="server" ID="ImagenEliminar" ImageUrl="~/Include/Image/Buttons/Delete.png"
                                                            Height="11px"></asp:ImageButton>
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
            <td class="EspacioIntermedio">
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
            <td class="EspacioIntermedio" style="vertical-align:top">
                Comentarios
            </td>
            <td class="style6">
                <asp:TextBox ID="tbComentarios" runat="server" CssClass="Textbox_General" 
                    Width="210px" Height="70px"
                    MaxLength="50" TextMode="MultiLine"></asp:TextBox>
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
                                Width="125px" onclick="btnAgregar_Click" />
                        </td>
                        <td style="text-align: left;">
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General"
                                Width="125px" onclick="btnRegresar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color: #CCCCCC; text-align: left;">
                Voces señaladas
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="EspacioIntermedio">
                Autoridad
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlAutoridad" runat="server" CssClass="DropDownList_General" AutoPostBack="true"
                    Width="216px">
                </asp:DropDownList>
            </td>
            <td rowspan="7" style="vertical-align: super">
                <table width="100%" border="0">
                    <tr>
                        <td style="width: 10px">
                        </td>
                        <td style="border: 0px">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="background-color: #DDDDFF; height: 30px; font-size: 10px; border: 0px;
                                        text-align: center;">
                                        &nbsp;Voces Señaladas a la Autoridad&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 175px; background-color: #EFF2FB; vertical-align: top;">
                                        <!--aqui se estaran ingresando los ciudadanos agregados-->
                                        <asp:GridView ID="gvVocesSenaladas" runat="server" AllowPaging="false" AllowSorting="false"
                                            AutoGenerateColumns="False" DataKeyNames="VozId"
                                            BorderWidth="0">
                                            <HeaderStyle CssClass="Grid_Encabezado" />
                                            <RowStyle CssClass="Grid_Filas" />
                                            <EmptyDataRowStyle CssClass="Empty" BorderStyle="None" BorderWidth="0px" />
                                            <EmptyDataTemplate>
                                                <table border="0px" cellpadding="0" style="border: 0px;" cellspacing="0">
                                                    <tr>
                                                        <td style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 9.5px; text-align: center;">
                                                            No se han agregado voces a esta autoridad
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 130px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton Width="150px" CommandArgument='<%#Eval("VozId")%>'
                                                            ID="VozButton" runat="server" Text='<%#Eval("Nombre")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton CommandArgument='<%#Eval("VozId")%>' CommandName="Borrar"
                                                            runat="server" ID="ImagenEliminar" ImageUrl="~/Include/Image/Buttons/Delete.png"
                                                            Height="11px"></asp:ImageButton>
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
            <td class="EspacioIntermedio">
            </td>
        </tr>
        <tr>
            <td class="EspacioIntermedio">
                Primer nivel
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlVozPrimerNivel" runat="server" CssClass="DropDownList_General"
                    Width="216px" AutoPostBack="True">
                </asp:DropDownList>
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
                <asp:DropDownList ID="ddlVozSegundoNivel" runat="server" CssClass="DropDownList_General"
                    Width="216px" AutoPostBack="True">
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
                <asp:DropDownList ID="ddlVozTercerNivel" runat="server" CssClass="DropDownList_General"
                    Width="216px">
                </asp:DropDownList>
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
                                Width="125px" onclick="btnAgregar_Click" />
                        </td>
                        <td style="text-align: left;">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="SolicitudIdHidden" runat="server" Value="0" />
</asp:Content>
