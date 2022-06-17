using Intersel_Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intersel_Practica.Dto
{
    public class UserDto
    {
        public int ApplicationUserId { get; set; }
        public string UserName { get; set; }
        public string Rol { get; set; }
        public int Option { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int Error { get; set; }
        public string DescError { get; set; }

    }
}