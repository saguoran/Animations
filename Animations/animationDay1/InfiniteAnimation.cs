using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Animations.animationDay1
{
    public class InfiniteAnimation : ContentPage
    {
        readonly Label RotateLabel;
        bool isInfinite= false;
        TapGestureRecognizer tapRegonizer;

        private async Task RotaeElement()
        {
            while (isInfinite)
            {
                await RotateLabel.RelRotateTo(360, 10000);
            }
        }
        public InfiniteAnimation()
        {
            tapRegonizer = new TapGestureRecognizer();
            tapRegonizer.Tapped += async(o, args) => {
                isInfinite = !isInfinite;
                RotateLabel.BackgroundColor = Color.FromHex("#dd0000");               
                await Task.WhenAny(
                      RotaeElement()
                    );
                if(!isInfinite) ViewExtensions.CancelAnimations(RotateLabel);
            };

            RotateLabel = new Label
            {
                Text = "Infinite animation",
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.FromHex("#ccc"),
                GestureRecognizers = { tapRegonizer }
            };
            Content = new FlexLayout
            {
                Direction = FlexDirection.Column,
                JustifyContent = FlexJustify.Center,
                AlignContent = FlexAlignContent.Center,
                Children = {
                        RotateLabel
                    }
                
            };
        }
    }
}