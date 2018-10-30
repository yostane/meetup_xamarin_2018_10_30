using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonStarWars.ViewModels;

namespace MonStarWars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SWPage : ContentPage
    {
        public SWPage()
        {
            InitializeComponent();
            BindingContext = new SWViewModel();
        }
    }
}