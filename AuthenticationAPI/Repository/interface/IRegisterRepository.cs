using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IRegisterRepository
    {
        bool Register(RegisterData user);

    }
}
