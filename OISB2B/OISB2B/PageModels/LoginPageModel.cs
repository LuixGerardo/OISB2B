using FreshMvvm;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using OISB2B.Helpers;
using Xamarin.Essentials;
using OISB2B.Service;

namespace OISB2B.PageModels
{
    class LoginPageModel : FreshBasePageModel
    {
        public string UserEntry { get; set; }
        public string PassEntry { get; set; }
        public string LoginBtnText { get; set; } = "LOGIN";
        public string UserText { get; set; } = "Email or Username";
        public string PassText { get; set; } = "Password";

        string token = "";

        public Command GoToPageCommand { get; set; }

        public LoginPageModel()
        {
            GoToPageCommand = new Command(() =>
            {
                token = RestApi.Token(UserEntry, PassEntry);
                //token = await RestApi.Token2Async(UserEntry, PassEntry);
                Debug.WriteLine(token);
                //CoreMethods.PushPageModel<LoginPageModel>();
            });
        }
    }
}
