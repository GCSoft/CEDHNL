<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="opeRegistroSolicitud.aspx.cs" Inherits="SIAQ.Web.Application.WebApp.Private.Operation.opeRegistroSolicitud" %>
<%@ Register src="../../../../Include/WebUserControls/wucFixedDateTime.ascx" tagname="wucFixedDateTime" tagprefix="wuc" %>
<%@ Register src="../../../../Include/WebUserControls/wucBusquedaCiudadano.ascx" tagname="wucBusquedaCiudadano" tagprefix="wuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript" language="javascript">

        // Prototipos
        String.prototype.trim = function () { return this.replace(/^\s+|\s+$/g, ''); }

         // Funciones del programador
        function validateForm() {
            var txtCiudadano = document.getElementById('cntPrivateTemplateBody_wucBusquedaCiudadano_txtCiudadano');
            var txtObservaciones = document.getElementById('cntPrivateTemplateBody_txtObservaciones');
            var ddlAbogado = document.getElementById('cntPrivateTemplateBody_ddlAbogado');

            var sNombre;
            var sObservaciones;
            var iAbogado;

            // Inicializacion de variables
            sNombre = txtCiudadano.value.trim();
            sObservaciones = txtObservaciones.value.trim();
            iAbogado = ddlAbogado.value;

            // Espacio en blanco

            if (sNombre == "") {
                tinyboxMessage('El campo Nombre es obligatorio', 'Fail', true);
                focusControl('cntPrivateTemplateBody_wucBusquedaCiudadano_txtCiudadano');
                return false;
            }

            if (iAbogado == "0") {
                tinyboxMessage('El campo Abogado es obligatorio favor de seleccionar uno', 'Fail', true);
                focusControl('cntPrivateTemplateBody_ddlAbogado');
                return false;
            }

            if (sObservaciones == "") {
                tinyboxMessage('El campo Observaciones es obligatorio', 'Fail', true);
                focusControl('cntPrivateTemplateBody_txtObservaciones');
                return false;
            }

            
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
   <table class="GeneralTable">
        <tr>
            <td class="tdCeldaTituloEncabezado" style="background-image:url('../../../../Include/Image/Web/BarraTitulo.png');">
                Registrar solicitud
            </td>
        </tr>
        <tr>
            <td class="SubTitulo"><asp:Label ID="Label2" runat="server" Text="Proporcione la siguiente información para registrar una nueva solicitud en el sistema."></asp:Label></td>
        </tr>
        <tr>
            <td>
               <asp:Panel id="pnlFormulario" runat="server" Visible="true" Width="100%">
                  <table  border="0" style="width: 460px">
                     <tr>
                        <td class="Etiqueta">Fecha y Hora</td>
                        <td class="Espacio"></td>
                        <td class="Campo"><wuc:wucFixedDateTime ID="wucFixedDateTime" runat="server" /></td>
                     </tr>
                     <tr>
                        <td class="Etiqueta">Nombre del Ciudadano</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><wuc:wucBusquedaCiudadano ID="wucBusquedaCiudadano" runat="server" OnItemSelected="wucBusquedaCiudadano_ItemSelected" /></td>
                     </tr>
                     <tr>
                        <td class="Etiqueta">Abogado</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><asp:DropDownList ID="ddlAbogado" runat="server" CssClass="DropDownList_General" width="216px" ></asp:DropDownList></td>
                     </tr>
                     <tr>
                        <td class="Etiqueta">Observaciones</td>
                        <td class="VinetaObligatorio">*</td>
                        <td class="Campo"><asp:TextBox ID="txtObservaciones" runat="server" CssClass="Textarea_General" width="300px" TextMode="MultiLine" MaxLength="300"></asp:TextBox></td>
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
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Button_General" width="125px" onclick="btnGuardar_Click" /></td>
                     <td style="height:24px; text-align:left; width:130px;"><asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="Button_General" width="125px" onclick="btnRegresar_Click" /></td>
                     <td style="height:24px; width:530px;"></td>
                  </tr>
               </table>
            </asp:Panel>
         </td>
      </tr>
      <tr><td class="tdCeldaMiddleSpace"></td></tr>
      <tr>
         <td style="text-align: left;">
            <asp:Label Text="Los campos marcados con " runat="server"></asp:Label> 
            <asp:Label CssClass="VinetaObligatorio" Text="*" runat="server"></asp:Label>
            <asp:Label ID="Label4" Text="son obligatorios." runat="server"></asp:Label> 
         </td>
      </tr>
      <tr class="trFilaFooter"><td></td></tr>
   </table>
</asp:Content>