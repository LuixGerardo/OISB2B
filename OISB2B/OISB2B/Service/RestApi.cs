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

namespace OISB2B.Service
{
    public static class RestApi 
    {
        public static string token= "";

        public static string Token(string UserEntry, string PassEntry)
        {
            string duid = "d09e9fb6-09b0-4bc9-92f0-ebe3634d648b";
            string dname = "Apple iPhone 11 Simulator (OIS Basic)";
            string db = "";
            string dversion = "";
            string dos = "";
            string deviceToken = "";
            string version = "";
            string v = "";

            dos = Device.RuntimePlatform == Device.iOS ? (Device.Idiom == TargetIdiom.Phone ? "iPhone" : "iPad") : (Device.Idiom == TargetIdiom.Phone ? "Android" : "Tablet");   // DeviceInfo.Name;
            dversion = DeviceInfo.VersionString;//DeviceInfo.Model;
            version = VersionTracking.CurrentVersion;// DeviceInfo.VersionString;

            //Anonymous Object
            var parameters = new
            {
                data = "id=" + UserEntry + "&pw=" + PassEntry
                + "&db=" + db + "&duid=" + duid + "&dname=" + dname + "&dversion=" + dversion
                + "&dos=" + dos + "&deviceToken=" + deviceToken + "&version=" + version + "&v=" + v
            };

            var json = JsonConvert.SerializeObject(parameters);
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                try
                {
                    var responseJson = client.UploadString(UrlConstants.GenerateKeyOIS, json);
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseJson);
                    token = responseObject.key.ToString();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }

            }
            return token;
        }

        public static async Task<string> Token2Async(string UserEntry, string PassEntry)
        {
            string duid = "d09e9fb6-09b0-4bc9-92f0-ebe3634d648b";
            string dname = "Apple iPhone 11 Simulator (OIS Basic)";
            string db = "";
            string dversion = "";
            string dos = "";
            string deviceToken = "";
            string version = "";
            string v = "";

            dos = Device.RuntimePlatform == Device.iOS ? (Device.Idiom == TargetIdiom.Phone ? "iPhone" : "iPad") : (Device.Idiom == TargetIdiom.Phone ? "Android" : "Tablet");   // DeviceInfo.Name;
            dversion = DeviceInfo.VersionString;//DeviceInfo.Model;
            version = VersionTracking.CurrentVersion;// DeviceInfo.VersionString;

            //Anonymous Object
            var parameters = new
            {
                data = "id=" + UserEntry + "&pw=" + PassEntry
                + "&db=" + db + "&duid=" + duid + "&dname=" + dname + "&dversion=" + dversion
                + "&dos=" + dos + "&deviceToken=" + deviceToken + "&version=" + version + "&v=" + v
            };

            HttpResponseMessage response = null;
            Uri RequestUri = new Uri(UrlConstants.GenerateKeyOIS);
            var json = JsonConvert.SerializeObject(parameters);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();

            response = await client.PostAsync(RequestUri, contentJSON);
            var responseJson = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseJson);
            token = responseObject.key.ToString();

            return token;
        }
        
    }

}
