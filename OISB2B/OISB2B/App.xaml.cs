using FreshMvvm;
using OISB2B.PageModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OISB2B
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
            var navigationPage = new FreshNavigationContainer(page);
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
