using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using OISB2B.Helpers;

namespace OISB2B.PageModels
{
    class MainPageModel : FreshBasePageModel 
    {
        public string TitleBasic { get; set; } = UrlConstants.TitleBasic;
        public string KeyGenerated { get; set; } = Preferences.Get("TokenGenerated", string.Empty);
        public string UserAuthenticated { get; set; } = Preferences.Get("LoginUser", string.Empty);


    }
}
