using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parcial2Dev.Modelo
{
    // Asociación con tabla usuarios
    [Table("usuarios")]
    public class Usuario
    {
        // Marca que este atributo es la primary key
        [Key]
        // Define que se debe relacionar con la columna usuario_id de la tabla
        [Column("usuario_id")]
        public int id { get; set; }

        // Define que se debe relacionar con la columna nombre de la tabla
        [Column("user")]
        public string user { get; set; }

        // Define que se debe relacionar con la columna email de la tabla
        [Column("pass")]
        public string pass { get; set; }

        [Column("serial_id")]

        public int serializador_id {get;set;}

        public Serial Seriales { get; set; }
    }

}
