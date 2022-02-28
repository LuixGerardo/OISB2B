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
        #region Parameter
        public string UserEntry { get; set; } = "";
        public string PassEntry { get; set; } = "";
        public string LoginBtnText { get; set; } = "LOGIN";
        public string UserText { get; set; } = "Email or Username";
        public string PassText { get; set; } = "Password";
        public Command GoToPageCommand { get; set; }

        #endregion

        public LoginPageModel()
        {
            #region BtnLogin
            GoToPageCommand = new Command(() =>
            {
                string PreferenceTokenKey = Preferences.Get("TokenGenerated", string.Empty); //Token Preference

                if (UserEntry == string.Empty | PassEntry == string.Empty)
                {
                    Application.Current.MainPage.DisplayAlert("Error", "Required fields", "OK");
                }
                else
                {
                    if (PreferenceTokenKey == string.Empty)
                    {
                        PreferenceTokenKey = RestApi.Token(UserEntry, PassEntry);
                        //TokenKey = await RestApi.Token2Async(UserEntry, PassEntry);                          
                    }

                    if (PreferenceTokenKey != string.Empty)
                    {
                        string LoginUser = Preferences.Get("LoginUser", string.Empty); //LoginUser Preference
                        string LoginPass = Preferences.Get("LoginPass", string.Empty); //LoginPass Preference

                        var Status = RestApi.Servicio();
                        if (Status != null & UserEntry == LoginUser & PassEntry == LoginPass)
                        {
                            Application.Current.MainPage.DisplayAlert("Welcome", Status, "OK");
                            CoreMethods.PushPageModel<MainPageModel>();
                        }
                        else
                        {
                            Preferences.Clear();                            
                            Application.Current.MainPage.DisplayAlert("Error", "Invalid Credentials", "OK");
                        }
                    }
                }
            });
            #endregion
        }
    }
}