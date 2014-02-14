using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SIAQ.DataAccess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.BusinessProcess.Object
{
     public class BPVisita : BPBase
    {
            private int _ErrorId;                           // Número de error ocurrido
            private string _ErrorDescription;               // Descripción del error ocurrido
            protected ENTVisita _VisitaEntity;

         public ENTVisita ENTVisita
         {
             get {return _VisitaEntity;}
             set { _VisitaEntity = value; }
         }

         public BPVisita(){

             _ErrorId = 0;
             _ErrorDescription = string.Empty;
             _VisitaEntity = new ENTVisita();
         }

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
         public void GuardarVisita() {

             string ConnectionString = string.Empty;
             DAVisita DAVisita = new DAVisita();
             ConnectionString = sConnectionApplication;
             DAVisita.GuardarVisita(_VisitaEntity , ConnectionString);
             _ErrorId = DAVisita.ErrorId;
             _ErrorDescription = DAVisita.ErrorDescription;
         }

    }

}
