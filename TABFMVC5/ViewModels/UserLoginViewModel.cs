using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TABFMVC5.ViewModels
{
    public class UserLoginViewModel
    {
        public string username { get; set; }

        public string password { get; set; }
    }
}