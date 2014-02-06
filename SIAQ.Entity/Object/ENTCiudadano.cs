using System;
using System.Collections.Generic;
using System.Text;
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
        private string _PaisId;
        private string _EstadoId;
        private string _CiudadId;
        private string _ColoniaId;
        private string _Calle;

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
            _MedioComunicacionId = 0;
            _Nombre = "";
            _ApellidoPaterno = "";
            _ApellidoMaterno = "";
            _FechaNacimiento = System.DateTime.Now;
            _FechaIngreso = System.DateTime.Now;
            _PaisId = string.Empty;
            _EstadoId = string.Empty;
            _CiudadId = string.Empty;
            _ColoniaId = string.Empty;
            _Calle = string.Empty;

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

        public string PaisId
        {
            get { return _PaisId; }
            set { _PaisId = value; }
        }

        public string EstadoId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }

        public string CiudadId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }

        public string ColoniaId
        {
            get { return _EstadoId; }
            set { _EstadoId = value; }
        }


        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }
    }
}

