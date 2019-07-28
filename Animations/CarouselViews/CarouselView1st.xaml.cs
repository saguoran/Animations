using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Animations.DataModels;

namespace Animations.CarouselViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselView1st : ContentPage
    {
        private List<string> colors;
        public CarouselView1st()
        {
            InitializeComponent();
            //     colors = new List<string> {
            //        "White", "Snow", "Rose", "Pink", "Purple"
            //    };
            //    carouselView.ItemsSource = Note.NoteResource();
        }
    }
    //public delegate void PositionChangingEventHandler(object sender, PositionChangingEventArgs e);
    //public delegate void PositionChangedEventHandler(object sender, PositionChangedEventArgs e);
}