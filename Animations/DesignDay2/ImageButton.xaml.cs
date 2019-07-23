using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations.DesignDay2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButton : ContentView
    {
        public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create("ButtonText", typeof(string), typeof(ImageButton), default(string));

        public string ButtonText {
            get { return GetValue(ButtonTextProperty) as string; }
            set { SetValue(ButtonTextProperty, value); }
        }

        public event EventHandler Clicked;

        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), null);

        public ICommand Command
        {
            get => GetValue(CommandProperty) as ICommand; 
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
                BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageButton), null);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty) as object;
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageButton), default(ImageSource));

        public ImageSource Source {
            get => GetValue(ImageSourceProperty) as ImageSource;
            set { SetValue(ImageSourceProperty, value); }
        }
        public ImageButton()
        {
            InitializeComponent();

            InnerLabel.SetBinding(Label.TextProperty, new Binding("ButtonText", source: this));
            InnerImage.SetBinding(Image.SourceProperty, new Binding("Source", source: this));
            
        }
    }
}