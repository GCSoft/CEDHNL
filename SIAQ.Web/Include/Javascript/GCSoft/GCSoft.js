/*---------------------------------------------------------------------------------------------------------------------------------
' Prototipo:	GCSoft.Utilities
' Autor:			Ruben.Cobos
' Fecha:			11-Marzo-2013
'
' Descripción:	Compilación de funciones Javascript de uso general
'           
'----------------------------------------------------------------------------------------------------------------------------------*/

// Prototipos
String.prototype.trim = function(){ return this.replace(/^\s+|\s+$/g,'') }


// Funciones

function isEmail(stringEvalMail) {
   // Espacios en blanco
	stringEvalMail = stringEvalMail.trim();
	
	// Campo vacío
	if (stringEvalMail == '') {
		return false;
	}
   
	// Evaluar cadena
   return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/.test(stringEvalMail);

}


function focusControl(sIDControl) {
   var oControl = document.getElementById(sIDControl);
   
   oControl.focus();
   if (oControl.type == 'text' || oControl.type == 'password') { oControl.select(); }

}


// Mensajes del TINYBOX

function tinyboxToolTipMessage_ClearOld() {
   oDivCanvas = null;

   if (document.getElementById('divTinyboxToolTipMessage') != null) {

      oDivCanvas = document.getElementById('divTinyboxToolTipMessage')
      document.body.removeChild(oDivCanvas);
      oDivCanvas = null;
   }
}

function tinyboxToolTipMessage(sMessage, sMessageType) {
   oDivCanvas = null;
   oImageToolTip = null;

   sAltImageURL = '';
   sImageURL = '';

   // Tipo de mensaje
   switch (sMessageType) {
      case 'AlertFail':
         sAltImageURL = '../../../Include/Javascript/ToolTip/ImageError.png';
         sImageURL = '../../../../Include/Javascript/ToolTip/ImageError.png';
         break;

      case 'AlertWarning':
         sAltImageURL = '../../../Include/Javascript/ToolTip/ImageWarning.png';
         sImageURL = '../../../../Include/Javascript/ToolTip/ImageWarning.png';
         break;

      default:
         return;
   }

   // Crear y configurar Imagen
   oImage = document.createElement('img');
   oImage.setAttribute('src', sImageURL);
   oImage.setAttribute('onerror', 'this.src="' + sAltImageURL + '"');
   oImage.style.cursor = 'help';

   // Agregar ToolTip
   oImage.onmouseover = function () {
      tooltip.show(sMessage, 'Der');
   };

   oImage.onmouseout = function () {
      tooltip.hide();
   };

   // Crear y configurar Div
   oDivCanvas = document.createElement('div');
   oDivCanvas.setAttribute('id', 'divTinyboxToolTipMessage');
   oDivCanvas.style.top = '0px';
   oDivCanvas.style.left = '0px';
   oDivCanvas.style.position = 'absolute';

   // Adjuntar Imagen a Div
   oDivCanvas.appendChild(oImage);

   // Adjuntar DIV a Documento desfasado 1 segundo
   setTimeout(function () {
      document.body.appendChild(oDivCanvas);
   }, 1000);

}

function tinyboxMessage(sMessage, sMessageType, ShowToolTip) {
   iAutohide = 3;

   // Tipo de mensaje
   switch (sMessageType) {
      case 'Fail':
         sMessageType = 'AlertFail';
         break;

      case 'Success':
         sMessageType = 'AlertSuccess';
         break;

      case 'Warning':
         sMessageType = 'AlertWarning';
         break;

      default:
         sMessageType = 'AlertWarning';
         break;
   }

   // Si ya existe un ToolTip eliminarlo
   tinyboxToolTipMessage_ClearOld();

   // Mostrar mensaje
   TINY.box.show({ html: sMessage, animate: false, close: false, mask: false, boxid: sMessageType, autohide: iAutohide, top: -14, left: -17, width: 250 })

   // Configurar ToolTip posterior al mensaje 
   if (ShowToolTip) {
      tinyboxToolTipMessage(sMessage, sMessageType);
   }

}


// Llamadas a Páginas de Descargas Asincronas

function CallAsyncFame(sSource, sKey) {
   oiFrame = null;

   try {

      // Eliminar el objeto en caso de que exista
      if (document.getElementById('iframeDownloadExcelFile') != null) {

         oiFrame = document.getElementById('iframeDownloadExcelFile')
         document.body.removeChild(oiFrame);
         oiFrame = null;
      }

      // Crear y configurar IFRAME.
      oiFrame = document.createElement("iframe");
      oiFrame.setAttribute('id', 'iframeDownloadExcelFile');
      oiFrame.src = sSource + "?key=" + sKey;
      oiFrame.style.display = "none";

      // Adjuntar IFRAME al Documento.
      document.body.appendChild(oiFrame);

      // Notificación de espera al usuario
      tinyboxMessage('Se ha enviado la solicitud de exportacion a Excel. Por favor espere mientras se descarga el archivo.', 'Success', false);

   } catch (err) {
      tinyboxMessage(err.message, 'Fail', true);
   }
}

// Validaciones de Login

function validateLogin() {
   var txtEmail = document.getElementById('cntLoginBody_txtEmail').value.trim();
   var txtPassword = document.getElementById('cntLoginBody_txtPassword').value.trim();
   var oSpan = document.getElementById('spanMessage');

   var RegExPattern = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;

   // Campos vacíos
   if (txtEmail == '') {
      oSpan.innerHTML = 'Correo requerido';
      oSpan.style.display = "block";
      focusControl('cntLoginBody_txtEmail');
      return false;
   }

   if (txtPassword == '') {
      oSpan.innerHTML = 'Password requerido';
      oSpan.style.display = "block";
      focusControl('cntLoginBody_txtPassword');
      return false;
   }

   // Formato de correo
   if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/.test(txtEmail) == false) {
      oSpan.innerHTML = 'Formato de correo incorrecto';
      oSpan.style.display = "block";
      focusControl('cntLoginBody_txtEmail');
      return false;
   }

   oSpan.style.display = "none";
   return true;
}

function validateRecoveryPassword() {
   var txtEmail = document.getElementById('cntLoginBody_txtEmail').value.trim();
   var oSpan = document.getElementById('spanMessage');

   // Campo vacío
   if (txtEmail == '') {
      oSpan.innerHTML = 'Correo requerido';
      oSpan.style.display = "block";
      focusControl('cntLoginBody_txtEmail');
      return false;
   }

   // Formato de correo
   if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/.test(txtEmail) == false) {
      oSpan.innerHTML = 'Formato de correo incorrecto';
      oSpan.style.display = "block";
      focusControl('cntLoginBody_txtEmail');
      return false;
   }

   oSpan.style.display = "none";
   return true;
}
