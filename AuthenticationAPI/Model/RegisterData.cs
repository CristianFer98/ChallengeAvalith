using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RegisterData
    {

        public string Name { get; set; }

        public string Dni { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
       
    }
}
