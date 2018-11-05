using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppXamarinDAE.Models
{
    public class Cat_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdEstatus { get; set; }
        public Int16 IdTipoEstatus { get; set; }
        public string Clave { get; set; }
        public string DesEstatus { get; set; }
    }
}
