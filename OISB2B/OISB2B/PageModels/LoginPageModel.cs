using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace OISB2B.PageModels
{
    class LoginPageModel : FreshBasePageModel
    {        
        public string User { get; set; } = "Email or Username";
        public string Pass { get; set; } = "Password";
        public string BtnLogin { get; set; } = "LOGIN";

    }
}
