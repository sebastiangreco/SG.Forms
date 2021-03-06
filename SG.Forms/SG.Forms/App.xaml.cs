﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SG.Forms.ViewModels;
using System.Threading.Tasks;
using SG.Forms.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SG.Forms
{
	public partial class App : Application
	{
		public bool UseMockServices { get; set; }

		public App ()
		{
			InitializeComponent();
			InitApp();
		}

		private void InitApp()
		{
			CoreUtility.ExecuteMethod("InitApp", delegate ()
			{
				Container.Track = new CoreTrack();
				ViewModelLocator.RegisterDependencies(UseMockServices);
				Container.SGApp = new SGApp();
			});
		}

        private Task InitNavigation()
        {
            return CoreUtility.ExecuteFunction<Task>("InitNavigation", delegate ()
            {
                var navigationService = ViewModelLocator.Resolve<INavigationService>();
                return navigationService.InitializeAsync();
            });
        }

        protected override async void OnStart ()
		{
            await CoreUtility.ExecuteMethodAsync("OnStart", async delegate ()
            {
                base.OnStart();
                await InitNavigation();
                base.OnResume();

            });
        }

		protected override void OnSleep ()
		{
            
        }

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
