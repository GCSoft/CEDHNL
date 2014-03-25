using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using SIAQ.Entity.Object;
namespace SIAQ.DataAccess.Object
{
    public class DAEstatus : DABase
    {
        Database dbs;
        protected int _ErrorId = 0;
        protected string _ErrorDescription = "";

        public int ErrorId
        {
            get { return _ErrorId; }
            set { _ErrorId = value; }
        }

        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }

        public DAEstatus()
        {
            dbs = DatabaseFactory.CreateDatabase("Conn");
        }
        ///<remarks>
        ///   <name>DAcatEstatus.searchcatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para obtener las catEstatus del sistema</summary>
        public ENTResponse searchcatEstatus(ENTEstatus entEstatus)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catEstatusSel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }
        ///<remarks>
        ///   <name>DAcatEstatus.insertcatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para insertar catEstatus del sistema</summary>
        public ENTResponse insertcatEstatus(ENTEstatus entEstatus)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                ds = dbs.ExecuteDataSet("catEstatusIns");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }
        ///<remarks>
        ///   <name>DAcatEstatus.updatecatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo que actualiza catEstatus del sistema</summary>
        public ENTResponse updatecatEstatus(ENTEstatus entEstatus)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catEstatusUpd");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }
        ///<remarks>
        ///   <name>DAcatEstatus.deletecatEstatus</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Metodo para eliminar de catEstatus del sistema</summary>
        public ENTResponse deletecatEstatus(ENTEstatus entEstatus)
        {
            ENTResponse oENTResponse = new ENTResponse();
            DataSet ds = new DataSet();
            // Transacción
            try
            {
                dbs.ExecuteDataSet("catEstatusDel");
                oENTResponse.dsResponse = ds;
            }
            catch (SqlException sqlEx)
            {
                oENTResponse.ExceptionRaised(sqlEx.Message);
            }
            catch (Exception ex)
            {
                oENTResponse.ExceptionRaised(ex.Message);
            }
            finally
            {
            }
            // Resultado
            return oENTResponse;

        }

        ///<remarks>
        ///   <name>DAcatEstatus.selectEstatusVisitaduria</name>
        ///   <create>25/MAR/2014</create>
        ///   <author>Jose.Gomez</author>
        ///</remarks>
        ///<summary>Metodo para obtener los estatus de visitadurías de catEstatus del sistema</summary>
        public DataSet selectEstatusVisitaduria(string sConnectionString)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(sConnectionString);
            SqlCommand Command;
            SqlDataAdapter DataAdapter;

            try
            {
                Command = new SqlCommand("catEstatusSelVisitadurias", con);
                Command.CommandType = CommandType.StoredProcedure;

                DataAdapter = new SqlDataAdapter(Command);

                con.Open();
                DataAdapter.Fill(ds);
                con.Close();

                return ds;
            }
            catch (SqlException ex)
            {
                _ErrorId = ex.Number;
                _ErrorDescription = ex.Message;

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                return ds;
            }
        }
    }
}
