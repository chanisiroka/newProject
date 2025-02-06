using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace securityLessonWebApi.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Role { get; set; }
        public string SurName { get; set; }

        public string GivenName { get; set; }
    }
}
