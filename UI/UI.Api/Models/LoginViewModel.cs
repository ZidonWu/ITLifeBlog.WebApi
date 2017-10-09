using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Api.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool? BRes { get; set; }

        public string Ticket { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }    

    }
}