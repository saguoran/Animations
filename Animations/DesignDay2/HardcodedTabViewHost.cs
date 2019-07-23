using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Animations.DesignDay2
{
    public class HardcodedTabViewHost : ContentPage
    {
        public HardcodedTabViewHost()
        {
            Content = new FlexLayout
                {
                    Margin = new Thickness(20),
                    Children = {new HardCodedTabView2rd()}    
                };
        }
    }
}