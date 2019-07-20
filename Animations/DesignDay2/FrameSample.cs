using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Animations.DesignDay2
{
    public class FrameSample : ContentPage
    {
        public FrameSample()
        {
            Label header = new Label
            {
                Text = "Frame",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Frame frame = new Frame
            {
                BorderColor = Color.Accent,
                HasShadow = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "I've been framed!"
                }
            };

            // Build the page.
            Title = "Frame Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    frame
                }
            };
        }
    }
}