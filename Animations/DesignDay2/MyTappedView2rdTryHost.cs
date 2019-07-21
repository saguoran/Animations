using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Animations.DesignDay2
{
    public class MyTappedView2rdTryHost : ContentPage
    {
        [Obsolete]
        public MyTappedView2rdTryHost()
        {
            Content = new FlexLayout { Padding=new Thickness(10),Children = { new TappedView2rdTry() } };
            //Label label = new Label
            //{
            //    Text = "This is a very long label which I expect to scroll horizontally because it's in a ScrollView.",
            //    Font = Font.SystemFontOfSize(24),
            //};

            //this.Content = new ScrollView
            //{
            //    Content = label,
            //    //HorizontalOptions = LayoutOptions.Fill,
            //    Orientation = ScrollOrientation.Horizontal,
            //};
        }
    }
}