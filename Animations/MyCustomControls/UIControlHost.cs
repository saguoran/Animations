using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Animations.MyCustomControls;

namespace Animations.MyCustomControls
{
    public class UIControlHost : ContentPage
    {
        public UIControlHost()
        {
            Padding = new Thickness(10, 50);
            Content = new TabeView1st();
        }
    }
}