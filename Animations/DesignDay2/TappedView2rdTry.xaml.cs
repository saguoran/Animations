using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations.DesignDay2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TappedView2rdTry : ContentView
    {
        Random rand = new Random();
        int padding = 3;
        public TappedView2rdTry()
        {
            InitializeComponent();
            //int i = 0;
            //int max = 20;
            //stackLayout.WidthRequest = max * 200 * 2 * 5;
            ////var stackLayout = new StackLayout {Orientation=StackOrientation.Horizontal};
            //while (i< max)
            //{
            //    int b = (int)rand.NextDouble()*10;
            //    string color = $"f{b}f";
            //    i += 1;
            //    var boxView = new BoxView
            //    {
            //        BackgroundColor = Color.FromHex(color),
            //        WidthRequest = 200,
            //        HeightRequest = 60,
            //        Margin = new Thickness(5, 0, 5, 0),
            //    };
            //    stackLayout.Children.Add(boxView);
            //}
            //scrollView.Content = stackLayout;
        }
    }
}