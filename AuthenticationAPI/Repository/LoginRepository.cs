using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MyDbContext _dbContext;

        public LoginRepository()
        {
            _dbContext = new MyDbContext();
        }
      

        public Usuarios GetUserByEmail(string email)
        {
            try
            {
                return _dbContext.Usuarios.Where(u => u.Email == email).FirstOrDefault();      
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
