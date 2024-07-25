using System;
using System.Collections.Generic;
using System.Text;

namespace Service.helper
{
    public class EncryptionService
    {
        private static EncryptionService _encryptionService;

        private EncryptionService() { }

        public static EncryptionService GetInstance()
        {
            if (_encryptionService == null)
            {
                _encryptionService = new EncryptionService();
            }
            return _encryptionService;
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
