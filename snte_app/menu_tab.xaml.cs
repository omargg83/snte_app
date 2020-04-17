using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace snte_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu_tab : Xamarin.Forms.TabbedPage
    {
        public menu_tab()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}