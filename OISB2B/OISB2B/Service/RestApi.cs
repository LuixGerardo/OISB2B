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
using System.Threading.Tasks;
using System.Web;
using System.Collections.ObjectModel;

namespace OISB2B.Service
{
    public static class RestApi 
    {
        public static string TokenKey = "";

        public static string Token(string UserEntry, string PassEntry)
        {
            #region Attributes 
            string Duid = "d09e9fb6-09b0-4bc9-92f0-ebe3634d648b";
            string Dname = "Apple iPhone 11 Simulator (OIS Basic)";
            string Db = "";
            string Dversion = "";
            string Dos = "";
            string DeviceToken = "";
            string Version = "";
            string V = "";

            Dos = Device.RuntimePlatform == Device.iOS ? (Device.Idiom == TargetIdiom.Phone ? "iPhone" : "iPad") : (Device.Idiom == TargetIdiom.Phone ? "Android" : "Tablet");   // DeviceInfo.Name;
            Dversion = DeviceInfo.VersionString;//DeviceInfo.Model;
            Version = VersionTracking.CurrentVersion;// DeviceInfo.VersionString;
            #endregion

            #region Parameters
            //Anonymous Object
            var Parameters = new
            {
                data = "id=" + UserEntry + "&pw=" + PassEntry
                + "&db=" + Db + "&duid=" + Duid + "&dname=" + Dname + "&dversion=" + Dversion
                + "&dos=" + Dos + "&deviceToken=" + DeviceToken + "&version=" + Version + "&v=" + V
            };
            #endregion

            #region Petition Post
            var Json = JsonConvert.SerializeObject(Parameters);
            using (var Client = new WebClient())
            {
                Client.Headers.Add("Content-Type", "application/json");
                try
                {
                    var ResponseJson = Client.UploadString(UrlConstants.GenerateKeyOIS, Json);
                    var ResponseObject = JsonConvert.DeserializeObject<dynamic>(ResponseJson);
                    TokenKey = ResponseObject.key.ToString();
                    TokenKey = HttpUtility.UrlEncode(TokenKey);

                    Preferences.Set("LoginUser", UserEntry); //Save Preference LoginUser
                    Preferences.Set("LoginPass", PassEntry); //Save Preference LoginPass

                    if (TokenKey == null)
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }

            }

            Preferences.Set("TokenGenerated", TokenKey); //Save Preference Token
            return TokenKey;
            #endregion
        }

        public static string Servicio()
        {
            var Client = new HttpClient();
            var Response = Client.GetStringAsync(UrlConstants.ServicioOIS + UrlConstants.LoginOIS + "?key=" + TokenKey).Result;
            var ResponseObject = JsonConvert.DeserializeObject<dynamic>(Response);
            try
            {
                var status = ResponseObject.Login.status.ToString();
                if (ResponseObject != null)
                {
                    if (status == "Logged In")
                    {
                        return status;
                    }
                }
            }
            catch { return null; }

            return null;
        }

        public static async Task<string> Token2Async(string UserEntry, string PassEntry)
        {
            #region Attributes 
            string Duid = "d09e9fb6-09b0-4bc9-92f0-ebe3634d648b";
            string Dname = "Apple iPhone 11 Simulator (OIS Basic)";
            string Db = "";
            string Dversion = "";
            string Dos = "";
            string DeviceToken = "";
            string Version = "";
            string V = "";

            Dos = Device.RuntimePlatform == Device.iOS ? (Device.Idiom == TargetIdiom.Phone ? "iPhone" : "iPad") : (Device.Idiom == TargetIdiom.Phone ? "Android" : "Tablet");   // DeviceInfo.Name;
            Dversion = DeviceInfo.VersionString;//DeviceInfo.Model;
            Version = VersionTracking.CurrentVersion;// DeviceInfo.VersionString;
            #endregion

            #region Parameters
            var Parameters = new //Anonymous Object
            {
                data = "id=" + UserEntry + "&pw=" + PassEntry
                + "&db=" + Db + "&duid=" + Duid + "&dname=" + Dname + "&dversion=" + Dversion
                + "&dos=" + Dos + "&deviceToken=" + DeviceToken + "&version=" + Version + "&v=" + V
            };
            #endregion

            #region Petition Post
            HttpResponseMessage Response = null;
            var Json = JsonConvert.SerializeObject(Parameters);
            var ContentJSON = new StringContent(Json, Encoding.UTF8, "application/json");
            var Client = new HttpClient();

            Response = await Client.PostAsync(UrlConstants.GenerateKeyOIS, ContentJSON);
            var ResponseJson = await Response.Content.ReadAsStringAsync();
            var ResponseObject = JsonConvert.DeserializeObject<dynamic>(ResponseJson);
            TokenKey = ResponseObject.key.ToString();
            TokenKey = HttpUtility.UrlEncode(TokenKey);

            Preferences.Set("LoginUser", UserEntry); //Save Preference LoginUser
            Preferences.Set("LoginPass", PassEntry); //Save Preference LoginPass

            if (TokenKey == null)
            {
                return null;
            }
            
            Preferences.Set("TokenGenerated", TokenKey); //Save Preference Token

            return TokenKey;
            #endregion
        }

    }

}
