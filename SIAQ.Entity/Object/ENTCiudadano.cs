using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SIAQ.Entity.Object
{
    public class ENTCiudadano : ENTBase
    {

        private int _CiudadanoId; // Valor de CiudadanoId
        private int _SexoId; // Valor de SexoId
        private int _EstadoCivilId; // Valor de EstadoCivilId
        private int _CiudadOrigenId; // Valor de CiudadOrigenId
        private int _NacionalidadId; // Valor de NacionalidadId
        private int _EscolaridadId; // Valor de EscolaridadId
        private int _IngresoEconomicoId; // Valor de IngresoEconomicoId
        private int _TipoViviendaId; // Valor de TipoViviendaId
        private int _MedioComunicacionId; // Valor de MedioComunicacionId
        private string _Nombre; // Valor de Nombre
        private string _ApellidoPaterno; // Valor de ApellidoPaterno
        private string _ApellidoMaterno; // Valor de ApellidoMaterno
        private DateTime _FechaNacimiento; // Valor de FechaNacimiento
        private DateTime _FechaIngreso; // Valor de FechaIngreso
        private DataSet _ResultData; //Otras propiedades
        private int _PaisId;
        private int _EstadoId;
        private int _CiudadId;
        private int _ColoniaId;
        private string _Calle;
        private string _CampoBusqueda;
        private int _SolicitudId;
        private int _TipoCiudadanoId;


        public ENTCiudadano()
        {
            _CiudadanoId = 0;
            _SexoId = 0;
            _EstadoCivilId = 0;
            _CiudadOrigenId = 0;
            _NacionalidadId = 0;
            _EscolaridadId = 0;
            _IngresoEconomicoId = 0;
            _TipoViviendaId = 0;
            _TipoCiudadanoId = 0;
            _MedioComunicacionId = 0;
            _Nombre = "";
            _SolicitudId = 0;
            _ApellidoPaterno = "";
            _ApellidoMaterno = "";
            _FechaNacimiento = System.DateTime.Now;
            _FechaIngreso = System.DateTime.Now;
            _PaisId = 0;
            _EstadoId = 0;
            _CiudadId = 0;
            _ColoniaId = 0;
            _Calle = string.Empty;
            _CampoBusqueda = string.Empty;

        }
        ///<remarks>
        ///   <name>Ciudadano.CiudadanoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CiudadanoId</summary>
        public int CiudadanoId
        {
            get { return _CiudadanoId; }
            set { _CiudadanoId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.SexoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna SexoId</summary>
        public int SexoId
        {
            get { return _SexoId; }
            set { _SexoId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.EstadoCivilId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EstadoCivilId</summary>
        public int EstadoCivilId
        {
            get { return _EstadoCivilId; }
            set { _EstadoCivilId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.CiudadOrigenId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna CiudadOrigenId</summary>
        public int CiudadOrigenId
        {
            get { return _CiudadOrigenId; }
            set { _CiudadOrigenId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.NacionalidadId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna NacionalidadId</summary>
        public int NacionalidadId
        {
            get { return _NacionalidadId; }
            set { _NacionalidadId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.EscolaridadId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna EscolaridadId</summary>
        public int EscolaridadId
        {
            get { return _EscolaridadId; }
            set { _EscolaridadId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.IngresoEconomicoId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna IngresoEconomicoId</summary>
        public int IngresoEconomicoId
        {
            get { return _IngresoEconomicoId; }
            set { _IngresoEconomicoId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.TipoViviendaId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna TipoViviendaId</summary>
        public int TipoViviendaId
        {
            get { return _TipoViviendaId; }
            set { _TipoViviendaId = value; }
        }

        public int TipoCiudadanoId
        {
            get { return _TipoCiudadanoId; }
            set { _TipoCiudadanoId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.MedioComunicacionId</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna MedioComunicacionId</summary>
        public int MedioComunicacionId
        {
            get { return _MedioComunicacionId; }
            set { _MedioComunicacionId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.Nombre</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna Nombre</summary>
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int SolicitudId
        {
            get { return _SolicitudId; }
            set { _SolicitudId = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.ApellidoPaterno</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ApellidoPaterno</summary>
        public string ApellidoPaterno
        {
            get { return _ApellidoPaterno; }
            set { _ApellidoPaterno = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.ApellidoMaterno</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna ApellidoMaterno</summary>
        public string ApellidoMaterno
        {
            get { return _ApellidoMaterno; }
            set { _ApellidoMaterno = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.FechaNacimiento</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaNacimiento</summary>
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
        ///<remarks>
        ///   <name>Ciudadano.FechaIngreso</name>
        ///   <create>27/ene/2014</create>
        ///   <author>Generador</author>
        ///</remarks>
        ///<summary>Obtiene/Asigna FechaIngreso</summary>
        public DateTime FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }

        public int PaisId
        {
            get { return _PaisId; }
            set { _PaisId = value; }
        }

        public int EstadoId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }

        public int CiudadId
        {
           get { return _CiudadId; }
           set { _CiudadId = value; }
        }

        public int ColoniaId
        {
           get { return _ColoniaId; }
           set { _ColoniaId = value; }
        }


        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }

        public string CampoBusqueda
        {
            get { return _CampoBusqueda; }
            set { _CampoBusqueda = value; }
        }

        ///     DataSet resultante de las busquedas en la base de datos
        /// </summary>
        public DataSet ResultData
        {
            get { return _ResultData; }
            set { _ResultData = value; }
        }
    }
}


