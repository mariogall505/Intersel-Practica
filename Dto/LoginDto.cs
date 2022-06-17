using Intersel_Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intersel_Practica.Dto
{
    public class LoginDto
    {
        public ApplicationUser User { get; set; } = new ApplicationUser();
        public int Error { get; set; }
        public string DescError { get; set; }
    }
}