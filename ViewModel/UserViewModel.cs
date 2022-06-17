using Intersel_Practica.Dto;
using Intersel_Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intersel_Practica.ViewModel
{
    public class UserViewModel
    {
        public IEnumerable<UserDto> Users { get; set; } = new List<UserDto>();
        public IEnumerable<Role> Roles { get; set; } = new List<Role>();
    }
}