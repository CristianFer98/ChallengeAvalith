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
                Usuarios userToCompare = _loginRepository.GetUserByEmail(user.Email);

                if (userToCompare != null)
                {
                    bool passwordCompare = EncryptionService.GetInstance().VerifyPassword(userToCompare.Contraseña, user.Password);

                    if (passwordCompare)
                    {
                        string Jwt = _jwtTokenGenerator.GenerateToken(userToCompare);
                        return Jwt;
                    }

                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
