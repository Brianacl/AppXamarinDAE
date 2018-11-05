using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppXamarinDAE.Models
{
    public class Cat_tipos_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoEstatus { get; set; }
        public string DesTipoEstatus { get; set; }
        public bool Activo { get; set; }
    }
}
