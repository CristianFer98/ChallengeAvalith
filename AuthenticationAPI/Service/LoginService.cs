using Model;
using Repository;
using Repository.Data;
using Service.helper;
using Service.interfaces;
using System;

namespace Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginService(ILoginRepository loginRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _loginRepository = loginRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public string Login(LoginData user)
        {
            try
            {
                Usuarios userCompare = _loginRepository.GetUserByEmail(user.Email);

                if (userCompare != null)
                {
                    bool passwordCompare = EncryptionService.GetInstance().VerifyPassword(userCompare.Contraseña, user.Password);

                    if (passwordCompare)
                    {
                        string Jwt = _jwtTokenGenerator.GenerateToken(userCompare);
                        return Jwt;
                    }

                }
                return string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
