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
        [DisplayName("帳號")]
        public string username { get; set; }

        [DisplayName("密碼")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}