using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations.animationDay1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationPage : ContentPage
    {
        public AnimationPage()
        {
            InitializeComponent();
        }
        protected async void OnLebalClicked(Object o, EventArgs e)
        {
           animateLabelTapRecognizer.Tapped -= OnLebalClicked;
           await animateLabel.RotateTo(360, 3000);
           animateLabel.Rotation = 0;
           animateLabelTapRecognizer.Tapped += OnLebalClicked;
        }
        protected async void OnTranslatingLebalClicked(Object o, EventArgs e)
        {
            translatingLabelRecognizer.Tapped -= OnTranslatingLebalClicked;

           //await translatingLabel.TranslateTo(200, 400,2000);
           await translatingLabel.RelRotateTo(300,2000);
           translatingLabel.TranslationX = 0;
           translatingLabel.TranslationY = 0;
            //translatingLabel.Rotation = 0;

            translatingLabelRecognizer.Tapped += OnTranslatingLebalClicked;
        }
        protected async void OnAnchorRotationLebalClicked(Object o, EventArgs e)
        {
            AnchorRotationRecognizer.Tapped -= OnAnchorRotationLebalClicked;

            AnchorRotation.Text = $"AnchorX: {AnchorRotation.AnchorX}  AnchorY: {AnchorRotation.AnchorY}";
            AnchorRotation.AnchorX -= 0.1;
            await AnchorRotation.RelRotateTo(300, 2000);
            AnchorRotation.TranslationX = 0;
            AnchorRotation.TranslationY = 0;
            //translatingLabel.Rotation = 0;

            AnchorRotationRecognizer.Tapped += OnAnchorRotationLebalClicked;
        }

        protected async void OnScaleLabelClicked(Object o, EventArgs e)
        {
            ScaleLabelTapRecognizer.Tapped -= OnScaleLabelClicked;
            await ScaleLabel.ScaleTo(2, 2000);
            ScaleLabel.Scale = 1;
            ScaleLabelTapRecognizer.Tapped += OnScaleLabelClicked;
        }
    }
}