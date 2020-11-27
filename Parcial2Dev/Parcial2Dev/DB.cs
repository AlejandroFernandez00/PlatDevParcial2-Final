using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Parcial2Dev.Modelo;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ORM_MySQL
{
    class DB : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Serial> seriales { get; set; }

        // Setea driver y connection string a usar
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("server=localhost;database=parcial2;user=root;password=;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            //Fluent API
            modelBuilder.Entity<Usuario>()
                .HasOne<Serial>(s => s.Seriales)
                .WithMany(g => g.Creador)
                .HasForeignKey(s => s.serializador_id);

        }

    }
}
