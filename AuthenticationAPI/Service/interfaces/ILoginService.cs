using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.interfaces
{
    public interface ILoginService
    {
        string Login(LoginData user);
    }
}
