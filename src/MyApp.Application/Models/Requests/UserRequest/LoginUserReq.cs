using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Models.Requests.UserRequest
{
    public class LoginUserReq
    {
        [Required]
        public string Credential { get; set; }
        [Required]

        public string UserPassword { get; set; }






    }
    
}
