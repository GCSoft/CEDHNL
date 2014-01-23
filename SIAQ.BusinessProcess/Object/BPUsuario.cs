/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPUsuario
' Autor: GCSoft - Web Project Creator BETA 1.0
' Fecha: 21-Octubre-2013
'
' Proposito:
'          Clase que modela la capa de reglas de negocio de la aplicación con métodos relacionados con el usuario
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Text;

// Referencias manuales
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;
using GCSoft.Utilities.Security;
using GCSoft.Utilities.Communication;
using System.Data;
using System.Web;

namespace SIAQ.BusinessProcess.Object
{

   public class BPUsuario : BPBase
   {

      ///<remarks>
      ///   <name>BPUsuario.InsertUsuario</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Actualiza la información de un usuario</summary>
      ///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertUsuario(ENTUsuario oENTUsuario){
         Mail utilMail = new Mail();
         Encryption utilEncryption = new Encryption();
         PasswordGenerator utilPasswordGenerator = new PasswordGenerator();
			
         DAUsuario oDAUsuario = new DAUsuario();
         ENTResponse oENTResponse = new ENTResponse();

         String sHTMLMessage = "";
         String sPassword = "";

			try{
				
            // Generar Password
            sPassword = utilPasswordGenerator.CreatePassword();

            // Encriptar el Password
            oENTUsuario.sPassword = utilEncryption.EncryptString(sPassword, false);

            // Validación de creación de password
            if (oENTUsuario.sPassword.Trim() == "") { throw (new Exception("Se generó una excepción al crear el usuario. Por favor intente de nuevo")); }

            // Transacción en base de datos
            oENTResponse = oDAUsuario.InsertUsuario(oENTUsuario, this.sConnectionApplication, 300);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
            if (oENTResponse.sMessage != "") { return oENTResponse; }

				// Configuración del correo
            sHTMLMessage = "" +
            "<html>" +
               "<head>" +
                  "<title>SIAQ - Bienvenido al sistema</title>" +
               "</head>" +
               "<body style='height:100%; margin:0px; padding:0px; width:100%;'>" +
                  "<div style='clear:both; height:90%; text-align:center; width:100%;'>" +
                     "<div style='height:80%; clear: both; margin:0px auto; position:relative; top:10%; width:90%;'>" +
                        "<table border='0px;' cellpadding='0' cellspacing='0' style='height:100%; width:100%;'>" +
                           "<tr>" +
                              "<td colspan='2' valign='middle' style='color:#549CC6; font-family:Arial; font-size:12px; font-weight:bold; text-align:left;'>SIAQ - Bienvenido al sistema</td>" +
                           "</tr>" +
                           "<tr><td colspan='3'><div style='border-bottom:1px solid #549CC6;'></div></td></tr>" +
                           "<tr style='height:10px'><td colspan='3'></td></tr>" +
                           "<tr>" +
                              "<td colspan='2' valign='top' style='font-family:Arial; font-size:12px;'>" +
                                 "El equipo de Logística le da la bienvenida al sistema de SIAQ. Los datos de acceso a la aplicación son los siguientes<br><br>" +
                                 "<table border='0px' cellpadding='0' cellspacing ='0' class='Text' style='height:100%; width:100%'>" +
                                    "<tr style='height:10px'><td></td></tr>" +
                                    "<tr>" +
                                       "<td style='text-align:left;'>" +
                                             "<b>Usuario:</b>&nbsp;" + oENTUsuario.sEmail +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='text-align:left;'>" +
                                             "<b>Password:</b>&nbsp;" + sPassword +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='font-family:Arial; font-size:12px; text-align:left;'>" +
                                             "<br>Puede acceder al sistema haciendo click <a href='" + this.sApplicationURL + "'>aqui</a>" +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='text-align:left;'>" +
                                          "<br><br>NOTA: Es recomendable que cambie su contraseña desde el menú Administración/Cambio de Contraseña." +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='font-family:Arial; font-size:12px; text-align:left;'>" +
                                          "<br><br><br>Gracias por utilizar nuestros servicios informáticos" +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='font-family:Arial; font-size:9px; text-align:center;'>" +
                                          "<br><br>Powered By GCSoft" +
                                       "</td>" +
                                    "</tr>" +
                                 "</table>" +
                              "</td>" +
                           "</tr>" +
                           "<tr style='height:20px'><td colspan='3'></td></tr>" +
                           "<tr style='height:20px'><td colspan='3'></td></tr>" +
                           "<tr style='height:1px'><td colspan='3' style='background:#000063 repeat-x;'></td></tr>" +
                           "<tr style='height:60px; vertical-align:top;'>" +
                              "<td colspan='2' style='font-family:Arial; font-size:10px; color: #180A3B; text-align:justify; vertical-align:middle;'>" +
                                 "Este correo electronico es confidencial y/o puede contener informacion privilegiada. Si usted no es su destinatario o no es alguna persona autorizada por este para recibir sus correos electronicos, NO debera usted utilizar, copiar, revelar, o tomar ninguna accion basada en este correo electronico o cualquier otra informacion incluida en el, favor de notificar al remitente de inmediato mediante el reenvio de este correo electronico y borrar a continuacion totalmente este correo electronico y sus anexos.<br/><br/>Nota: Los acentos y caracteres especiales fueron omitidos para su correcta lectura en cualquier medio electronico.<br/>" +
                              "</td>" +
                              "<td></td>" +
                           "</tr>" +
                           "<tr><td colspan='3'></td></tr>" +
                        "</table>" +
                     "</div>" +
                  "</div>" +
               "</body>" +
            "</html>";

				// Enviar correo
            utilMail.SendMail("SIAQ - Bienvenido al sistema", oENTUsuario.sEmail, "SIAQ - Bienvenido al sistema", sHTMLMessage);

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;

		}
	  
      ///<remarks>
      ///   <name>BPUsuario.SelectUsuario</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Usuarios</summary>
      ///<param name="oENTUsuario">Entidad de usuario con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectUsuario(ENTUsuario oENTUsuario){
         DAUsuario oDAUsuario = new DAUsuario();
         ENTResponse oENTResponse = new ENTResponse();

			try{

            // Transacción en base de datos
            oENTResponse = oDAUsuario.SelectUsuario(oENTUsuario, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
            if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;

		}
	  
      ///<remarks>
      ///   <name>BPUsuario.selectUsuario_Autenticacion</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Valida las credenciales de un usuario para verificar el acceso al sistema. Si las credenciales son válidas configura la sesión.</summary>
      ///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para consultar la información</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectUsuario_Autenticacion(ENTUsuario oENTUsuario){
         Authentication utilAuthentication = new Authentication();
         Encryption utilEncryption = new Encryption();

         DAUsuario oDAUsuario = new DAUsuario();
         ENTResponse oENTResponse = new ENTResponse();
         ENTSession oENTSession = new ENTSession();

         HttpContext oContext;
			
			try{
			
            // Encriptar el password
            oENTUsuario.sPassword = utilEncryption.EncryptString(oENTUsuario.sPassword, false);
				
            // Consulta a base de datos
            oENTResponse = oDAUsuario.SelectUsuario_Autenticacion(oENTUsuario, this.sConnectionApplication, 0);
				
            // Validación de error en consulta
            if ( oENTResponse.GeneratesException ) { return oENTResponse; }
				
            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
            if ( oENTResponse.sMessage != "" ) { return oENTResponse; }

				// Configurar de entidad de sesión
				oENTSession.idUsuario = int.Parse(oENTResponse.dsResponse.Tables[1].Rows[0]["idUsuario"].ToString());
            oENTSession.idArea = int.Parse(oENTResponse.dsResponse.Tables[1].Rows[0]["idArea"].ToString());
            oENTSession.idRol = int.Parse(oENTResponse.dsResponse.Tables[1].Rows[0]["idRol"].ToString());
				oENTSession.sEmail = oENTUsuario.sEmail;
				oENTSession.sNombre = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
				oENTSession.tblSubMenu = oENTResponse.dsResponse.Tables[2];
				oENTSession.tblMenu = oENTResponse.dsResponse.Tables[3];
				
				// Autenticar el usuario
				utilAuthentication.AuthenticateUser(oENTSession.sEmail, this.iSessionTimeout);
				oENTSession.TokenGenerado = true;
				
				// Variable de sesión con los datos del usuario
				oContext = HttpContext.Current;
				oContext.Session["oENTSession"] = oENTSession;
				
			}catch(Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;

      }

      ///<remarks>
      ///   <name>BPUsuario.SelectUsuario_RecuperaContrasena</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Recupera la contraseña de un usuario enviándola por correo electrónico</summary>
      ///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para consultar la información</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectUsuario_RecuperaContrasena(ENTUsuario oENTUsuario){
         Mail utilMail = new Mail();
         Encryption utilEncryption = new Encryption();

         DAUsuario oDAUsuario = new DAUsuario();
         ENTResponse oENTResponse = new ENTResponse();

         String sPassword = "";
         String sNombreUsuario = "";
         String sHTMLMessage = "";

         try
         {

            // Consulta a base de datos
            oENTResponse = oDAUsuario.SelectUsuario_RecuperaContrasena(oENTUsuario, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
            if (oENTResponse.sMessage != "") { return oENTResponse; }

            // Obtener el nombre de usuario y password
            sNombreUsuario = oENTResponse.dsResponse.Tables[1].Rows[0]["sNombre"].ToString();
            sPassword = utilEncryption.DecryptString(oENTResponse.dsResponse.Tables[1].Rows[0]["sPassword"].ToString(), false);

            // Configuración del correo
            sHTMLMessage = "" +
               "<html>" +
               "<head>" +
                  "<title>SIAQ - Recuperación de contraseña</title>" +
               "</head>" +
               "<body style='height:100%; margin:0px; padding:0px; width:100%;'>" +
                  "<div style='clear:both; height:90%; text-align:center; width:100%;'>" +
                     "<div style='height:80%; clear: both; margin:0px auto; position:relative; top:10%; width:90%;'>" +
                        "<table border='0px;' cellpadding='0' cellspacing='0' style='height:100%; width:100%;'>" +
                           "<tr>" +
                              "<td colspan='2' valign='middle' style='color:#549CC6; font-family:Arial; font-size:12px; font-weight:bold; text-align:left;'>SIAQ - Recuperación de contraseña</td>" +
                           "</tr>" +
						         "<tr><td colspan='3'><div style='border-bottom:1px solid #549CC6;'></div></td></tr>" +
                           "<tr style='height:10px'><td colspan='3'></td></tr>" +
                           "<tr>" +
                              "<td colspan='2' valign='top' style='font-family:Arial; font-size:12px;'>" +
                                 "Usted ha solicitado información de usuario al sistema SIAQ. Los datos de acceso a la aplicación son los siguientes<br><br>" +
                                 "<table border='0px' cellpadding='0' cellspacing ='0' class='Text' style='height:100%; width:100%'>" +
                                    "<tr style='height:10px'><td></td></tr>" +
                                    "<tr>" +
                                       "<td style='text-align:left;'>" +
                                             "<b>Usuario:</b>&nbsp;" + oENTUsuario.sEmail +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='text-align:left;'>" +
                                             "<b>Password:</b>&nbsp;" + sPassword +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='font-family:Arial; font-size:12px; text-align:left;'>" +
                                             "<br>Puede acceder al sistema haciendo click <a href='" + this.sApplicationURL + "'>aqui</a>" +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='font-family:Arial; font-size:12px; text-align:left;'>" +
                                          "<br><br><br>Gracias por utilizar nuestros servicios informáticos" +
                                       "</td>" +
                                    "</tr>" +
                                    "<tr>" +
                                       "<td style='font-family:Arial; font-size:9px; text-align:center;'>" +
                                          "<br><br>Powered By GCSoft" +
                                       "</td>" +
                                    "</tr>" +
                                 "</table>" +
                              "</td>" +
                           "</tr>" +
                           "<tr style='height:20px'><td colspan='3'></td></tr>" +
                           "<tr style='height:20px'><td colspan='3'></td></tr>" +
                           "<tr style='height:1px'><td colspan='3' style='background:#000063 repeat-x;'></td></tr>" +
                           "<tr style='height:60px; vertical-align:top;'>" +
                              "<td colspan='2' style='font-family:Arial; font-size:10px; color: #180A3B; text-align:justify; vertical-align:middle;'>" +
                                 "Este correo electronico es confidencial y/o puede contener informacion privilegiada. Si usted no es su destinatario o no es alguna persona autorizada por este para recibir sus correos electronicos, NO debera usted utilizar, copiar, revelar, o tomar ninguna accion basada en este correo electronico o cualquier otra informacion incluida en el, favor de notificar al remitente de inmediato mediante el reenvio de este correo electronico y borrar a continuacion totalmente este correo electronico y sus anexos.<br/><br/>Nota: Los acentos y caracteres especiales fueron omitidos para su correcta lectura en cualquier medio electronico.<br/>" +
                              "</td>" +
                              "<td></td>" +
                           "</tr>" +
						         "<tr><td colspan='3'></td></tr>" +
                        "</table>" +
                     "</div>" +
                  "</div>" +
               "</body>" +
            "</html>";

            // Enviar correo
            utilMail.SendMail("SIAQ - Recuperación de contraseña", oENTUsuario.sEmail, "SIAQ - Recuperación de contraseña", sHTMLMessage);

         }catch (Exception ex){
            oENTResponse.ExceptionRaised(ex.Message);
         }

         // Resultado
         return oENTResponse;

      }
	  
      ///<remarks>
      ///   <name>BPUsuario.UpdateUsuario</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Actualiza la información de un usuario</summary>
      ///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateUsuario(ENTUsuario oENTUsuario){
			DAUsuario oDAUsuario = new DAUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAUsuario.UpdateUsuario(oENTUsuario, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;

		}
		
		///<remarks>
		///   <name>BPUsuario.UpdateUsuario_ActualizaContrasena</name>
      ///   <create>21-Octubre-2013</create>
		///   <author>GCSoft - Web Project Creator BETA 1.0</author>
		///</remarks>
		///<summary>Actualiza la contraseña de un usuario</summary>
		///<param name="oENTUsuario">Entidad de usuario con los parámetros necesarios para actualizar la contraseña</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateUsuario_ActualizaContrasena(ENTUsuario oENTUsuario){
         Encryption utilEncryption = new Encryption();

         DAUsuario oDAUsuario = new DAUsuario();
         ENTResponse oENTResponse = new ENTResponse();


			try{

            // Encriptar el passwords
            oENTUsuario.sPassword = utilEncryption.EncryptString(oENTUsuario.sPassword, false);
            oENTUsuario.sOldPassword = utilEncryption.EncryptString(oENTUsuario.sOldPassword, false);

            // Transacción en base de datos
            oENTResponse = oDAUsuario.UpdateUsuario_ActualizaContrasena(oENTUsuario, this.sConnectionApplication, 0);

            // Validación de error en consulta
            if (oENTResponse.GeneratesException) { return oENTResponse; }

            // Validación de mensajes de la BD
            oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
            if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
            oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;

		}

      ///<remarks>
      ///   <name>BPUsuario.UpdateUsuario_Estatus</name>
      ///   <create>21-Octubre-2013</create>
      ///   <author>GCSoft - Web Project Creator BETA 1.0</author>
      ///</remarks>
      ///<summary>Activa/inactiva un Usuario</summary>
      ///<param name="oENTUsuario">Entidad de Usuario con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateUsuario_Estatus(ENTUsuario oENTUsuario){
			DAUsuario oDAUsuario = new DAUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
            oENTResponse = oDAUsuario.UpdateUsuario_Estatus(oENTUsuario, this.sConnectionApplication, 0);

				// Validación de error en consulta
				if (oENTResponse.GeneratesException) { return oENTResponse; }

				// Validación de mensajes de la BD
				oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
				if (oENTResponse.sMessage != "") { return oENTResponse; }

			}catch (Exception ex){
				oENTResponse.ExceptionRaised(ex.Message);
			}

			// Resultado
			return oENTResponse;
		}

   }

}
