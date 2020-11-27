using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parcial2Dev.Modelo
{
    [Table("serial")]
    public class Serial
    {
        
        // Marca que este atributo es la primary key
        [Key]
        // Define que se debe relacionar con la columna post_id de la tabla
        [Column("serial_id")]
        public int id { get; set; }

        // Define que se debe relacionar con la columna texto de la tabla
        [Column("nombreserial")]
        public string nombreserial { get; set; }

        // Relacion contra muchos usuarios
        // Relacion hecha con Fluent API en DB.cs
        public List<Usuario> Creador { get; set; }
       

    }

}
