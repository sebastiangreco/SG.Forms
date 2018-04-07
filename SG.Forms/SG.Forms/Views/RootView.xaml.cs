using SG.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SG.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootView : MasterDetailPage
    {
        public RootView()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            MessagingCenter.Unsubscribe<MenuViewModel>(this, MessageKeys.HideMenu);
            MessagingCenter.Subscribe<MenuViewModel>(this, MessageKeys.HideMenu, (sender) =>
            {
                IsPresented = false;
            });
        }
    }
}