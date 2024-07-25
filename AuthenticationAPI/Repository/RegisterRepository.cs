using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly MyDbContext _dbcontext;

        public RegisterRepository()
        {
            _dbcontext = new MyDbContext();
        }

        public bool Register(RegisterData user)
        {
            try
            {
                Usuarios usuario = new Usuarios();
                usuario.Name = user.Name;
                usuario.Email = user.Email;
                usuario.Contraseña = user.Password;
                usuario.Dni = user.Dni;
                _dbcontext.Add(usuario);
                _dbcontext.SaveChanges();

                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            
        }
    }
}
