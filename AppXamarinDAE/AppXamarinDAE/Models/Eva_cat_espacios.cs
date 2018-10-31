using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppXamarinDAE.Models
{
    public class Eva_cat_espacios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdEspacio { get; set; }
        public Int16 IdEdificio { get; set; }
        public string Clave { get; set; }
        public string DesEspacio { get; set; }
        public Int16 Prioridad { get; set; }
        public string Alias { get; set; }
        public Int16 RangoTiempoReserva { get; set; }
        public Int16 Capacidad { get; set; }
        public Cat_tipos_estatus IdTipoEstatus { get; set; }
        public Cat_estatus IdEstatus { get; set; }
        public string RefeUbicacion { get; set; }
        public string PermiteCruce { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
