using ORM_MySQL;
using Parcial2Dev.Modelo;
using Parcial2Dev.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Parcial2Dev.DAOs
{
    public class UsuarioDAO
    {
        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new UsuarioDAO();
            }

            return instancia;

        }

        public Usuario BuscarUsuario(string username, string password)
        {
            using (var context = new DB())
            {
                //Existe en la DB un usuario del form con este nombre y contraseña?
                return context.usuarios.SingleOrDefault(x => x.user == username && x.pass == password);
            }
            
        }

        public Serial buscarSerial(string serial)
        {
            using (var context = new DB())
            {
                return context.seriales.SingleOrDefault(s => s.nombreserial == serial);
            }
        }
        public Usuario getUsuarioporID(int id) //Para el Ajax
        {
            using (var context = new DB())
            {
                return context.usuarios.SingleOrDefault(x => x.id == id);
            }
        }
    }
}
