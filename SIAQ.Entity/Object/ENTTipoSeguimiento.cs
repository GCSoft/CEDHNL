using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIAQ.Entity.Object
{
	public class ENTTipoSeguimiento : ENTBase
	{

		private int		_TipoSeguimientoId;	// Valor de TipoSeguimientoId
        private string	_Nombre;			// Valor de Nombre
        private string	_Descripcion;		// Valor de Descripcion


		// Constructor
		public ENTTipoSeguimiento()
        {
            _TipoSeguimientoId = 0;
            _Nombre = "";
            _Descripcion = "";
        }


		// Propiedades

        ///<remarks>
		///   <name>ENTTipoSeguimiento.TipoSeguimientoId</name>
        ///   <create>06-Jun-2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoSeguimientoId</summary>
        public int TipoSeguimientoId
        {
            get { return _TipoSeguimientoId; }
            set { _TipoSeguimientoId = value; }
        }

        ///<remarks>
		///   <name>ENTTipoSeguimiento.Nombre</name>
        ///   <create>06-Jun-2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Nombre</summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        ///<remarks>
		///   <name>ENTTipoSeguimiento.Descripcion</name>
        ///   <create>06-Jun-2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Descripcion</summary>
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

	}
}
