using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
   public class BPFuncionario : BPBase
   {

       #region "Operacion"

          protected ENTFuncionario _FuncionarioEntity;
          protected string _ErrorDescription;
          protected int _ErrorId;

          public string ErrorDescription
          {
             get
             {
                return _ErrorDescription;
             }
             set
             { _ErrorDescription = value; }
          }

          public int ErrorId
          {
             get { return _ErrorId; }
             set { _ErrorId = value; }
          }

          public ENTFuncionario FuncionarioEntity
          {
             get { return _FuncionarioEntity; }
             set { _FuncionarioEntity = value; }
          }

          public BPFuncionario()
          {
             _FuncionarioEntity = new ENTFuncionario();
          }

          /// <summary>
          /// Obtiene el listado de los funcionarios del área de visitadurias
          /// </summary>
          public DataSet SelectFuncionarioVistaduria()
          {
             string sConnectionString = string.Empty;
             DAFuncionario oDAFuncionario = new DAFuncionario();
             sConnectionString = sConnectionApplication;
             _FuncionarioEntity.ResultData = oDAFuncionario.SelectFuncionarioVistaduria(_FuncionarioEntity, sConnectionString);
             return _FuncionarioEntity.ResultData;
          }

          /// <summary>
          /// Obtiene el listado de los funcionarios del área de quejas
          /// </summary>
          public DataSet SelectFuncionarioQuejas()
          {
             string sConnectionString = string.Empty;
             DAFuncionario oDAFuncionario = new DAFuncionario();
             sConnectionString = sConnectionApplication;
             _FuncionarioEntity.ResultData = oDAFuncionario.SelectFuncionarioQuejas(_FuncionarioEntity, sConnectionString);
             return _FuncionarioEntity.ResultData;
          }

          /// <summary>
          /// Obtiene el listado de los funcionarios del área de seguimiento
          /// </summary>
          public DataSet SelectFuncionarioRecomendacion()
          {
             string sConnectionString = string.Empty;
             DAFuncionario oDAFuncionario = new DAFuncionario();
             sConnectionString = sConnectionApplication;
             _FuncionarioEntity.ResultData = oDAFuncionario.SelectFuncionarioRecomendacion(_FuncionarioEntity, sConnectionString);
             return _FuncionarioEntity.ResultData;
          }

          /// <summary>
          /// Obtiene el listado de los funcionarios para su búsqueda 
          /// </summary>
          public DataSet SelectFuncionarioBusqueda()
          {
              string sConnectionString = string.Empty;
              DAFuncionario oDAFuncionario = new DAFuncionario();
              sConnectionString = sConnectionApplication;
              _FuncionarioEntity.ResultData = oDAFuncionario.SelectFuncionarioBusqueda(_FuncionarioEntity, sConnectionString);
              return _FuncionarioEntity.ResultData;
          }



       #endregion

      
      ///<remarks>
      ///   <name>BPFuncionario.DeleteFuncionario</name>
      ///   <create>06-Abril-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Elimina un Funcionario liberando la asociación del usuario. El usuario no se elimina</summary>
      ///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse DeleteFuncionario(ENTFuncionario oENTFuncionario){
			DAFuncionario oDAFuncionario = new DAFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
            oENTResponse = oDAFuncionario.DeleteFuncionario(oENTFuncionario, this.sConnectionApplication, 0);

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
		///   <name>BPFuncionario.InsertFuncionario</name>
		///   <create>06-Abril-2014</create>
		///   <author>Ruben.Cobos</author>
		///</remarks>
		///<summary>Crea una nueva relación para un usuario y lo convierte en Funcionario</summary>
		///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para actualizar su información</param>
		///<returns>Una entidad de respuesta</returns>
		public ENTResponse InsertFuncionario(ENTFuncionario oENTFuncionario){
			DAFuncionario oDAFuncionario = new DAFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAFuncionario.InsertFuncionario(oENTFuncionario, this.sConnectionApplication, 0);

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
      ///   <name>BPFuncionario.SelectFuncionario</name>
      ///   <create>06-Abril-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Consulta el catálogo de Funcionarios</summary>
      ///<param name="oENTFuncionario">Entidad de Funcionario con los filtros necesarios para la consulta</param>
      ///<returns>Una entidad de respuesta</returns>
      public ENTResponse SelectFuncionario(ENTFuncionario oENTFuncionario){
         DAFuncionario oDAFuncionario = new DAFuncionario();
         ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAFuncionario.SelectFuncionario(oENTFuncionario, this.sConnectionApplication, 0);

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
      ///   <name>BPFuncionario.UpdateFuncionario</name>
      ///   <create>06-Abril-2014</create>
      ///   <author>Ruben.Cobos</author>
      ///</remarks>
      ///<summary>Actualiza la información de un Funcionario</summary>
      ///<param name="oENTFuncionario">Entidad de Funcionario con los parámetros necesarios para actualizar su información</param>
      ///<returns>Una entidad de respuesta</returns>
		public ENTResponse UpdateFuncionario(ENTFuncionario oENTFuncionario){
			DAFuncionario oDAFuncionario = new DAFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try{

				// Transacción en base de datos
				oENTResponse = oDAFuncionario.UpdateFuncionario(oENTFuncionario, this.sConnectionApplication, 0);

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
        ///   <name>BPcatEstatus.searchcatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstatus del sistema</summary>
        public ENTResponse searchDoctores(ENTFuncionario entFuncionario)
        {

            ENTResponse oENTResponse = new ENTResponse();
            try
            {
                // Consulta a base de datos
                DAFuncionario datacatEstatus = new DAFuncionario();
                oENTResponse = datacatEstatus.searchDoctores(entFuncionario);
                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }
                // Validación de mensajes de la BD
                oENTResponse.sMessage = oENTResponse.dsResponse.Tables[0].Rows[0]["sResponse"].ToString();
                if (oENTResponse.sMessage != "") { return oENTResponse; }
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            // Resultado
            return oENTResponse;

        }
   }
}
