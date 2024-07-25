using Model;
using Service.interfaces;
using System;
using Repository;
using Service.helper;

namespace Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public bool Register(RegisterData user)
        {
            try
            {
                user.Password = EncryptionService.GetInstance().HashPassword(user.Password);
                return _registerRepository.Register(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
