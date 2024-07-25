using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ILoginRepository
    {
        Usuarios GetUserByEmail(string email);
    }
}
