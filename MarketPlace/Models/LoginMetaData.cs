using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MarketPlace.Models
{
    public class LoginMetaData
    {

        [Required(ErrorMessage = "Email required!")]
        public string email { get; set; }


        [Required(ErrorMessage = "Password required!")]
        public string password { get; set; }

    }
}