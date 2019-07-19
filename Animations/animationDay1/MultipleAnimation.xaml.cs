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
    public partial class MultipleAnimation : ContentPage
    {
        public MultipleAnimation()
        {
            InitializeComponent();
        }

        protected async void OnAsyncAnimation(Object o, EventArgs args)
        {
            await Task.WhenAny<bool>(
                 asyncAnimateLabel.RelRotateTo(100, 1000),
                 asyncAnimateLabel.RelScaleTo(0.5, 1000)
                );
        }

    }
}