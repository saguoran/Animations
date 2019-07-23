using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Linq;
using Animations.DataModels;
using System.Threading.Tasks;
using Animations.DataBindingModel;

namespace Animations.DataBinding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataBind3rd : ContentView
    {
        List<Label> labels;
        List<Editor> editors;
        ObservableCollection<Product> products;
        ObservableCollection<string> tabs;
        ObservableCollection<string> details;
        TitleDetailMode model;
        TapGestureRecognizer tapGesture;

        private static int total;
        private static int Selected;
        private static double position;
        private int Prev { get; set; }
        private int Next { get; set; }

        private static readonly Color textColor = Color.LightGray;
        private static readonly Color BGColor = Color.Snow;
        private static readonly Color selectedTextColor = BGColor;
        private static readonly Color selectedBGColor = Color.Accent;

        Label labelModle;
        public DataBind3rd()
        {
            InitializeComponent();
            labels = new List<Label>();
            editors = new List<Editor>();
            model = new TitleDetailMode();
            tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnLabelClicked;

            total = 0;
            Selected = 0;
            position = 0;

            Init();
        }

        
        private Label GenerateLabel(string text) 
        {
            return new Label
            {
                Text = text,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = textColor,
                BackgroundColor = BGColor,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                WidthRequest = 200,
                Margin = new Thickness(1, 0),
                GestureRecognizers = { tapGesture }
            };
        }
        protected async void OnLabelClicked(Object o, EventArgs args)
        {
            (o as Label).BackgroundColor = selectedBGColor;
            (o as Label).TextColor = selectedTextColor;
            Label oldLabel = labels.Find(l => l.ClassId == Selected.ToString());
            oldLabel.BackgroundColor = BGColor;
            oldLabel.TextColor = textColor;

            Label newLabel =labels.Find(l=>(o as Label).ClassId==l.ClassId);

            int Iddistance = Selected - int.Parse(newLabel.ClassId) ;
            if (Iddistance!=0)
            {
                double distance = editors[0].Width * Iddistance;
                 position  += distance;
                await DetailContainer.TranslateTo(position, 0, 200);
                Selected = int.Parse(newLabel.ClassId);
            }
            

        }
        //<Editor BindingContext = "{x:Reference frame}"
        //                            WidthRequest="{Binding Width}"/>
        private Editor GenerateEditor(string text)
        {
            var editor = new Editor
            {
                Text = text,
                WidthRequest = 200,
                BindingContext = root,
            };
            editor.SetBinding(WidthRequestProperty, "Width", BindingMode.TwoWay);
            return editor;
        }

        private async void Init() {

            // Start a new task (this launches a new thread)
            await Task.Factory.StartNew(() =>
            {
                products = model.AllProducts;

                // Do some work on a background thread, allowing the UI to remain responsive
                // When the background work is done, continue with this code block
            }).ContinueWith(task =>
            {
                try
                {
                    BindingContext = products;
                    Container.BindingContext = model.Descriptions;
                    DetailContainer.BindingContext = model.Descriptions;
                    tabs = Container.BindingContext as ObservableCollection<string>;
                    details = DetailContainer.BindingContext as ObservableCollection<string>;
                    foreach (var i in tabs.Zip(details, Tuple.Create))
                    {
                        var label = GenerateLabel(i.Item1);
                        label.ClassId = total.ToString();
                        labels.Add(label);
                        Container.Children.Add(label);

                        var editor = GenerateEditor(i.Item2);
                        editor.ClassId = total.ToString();
                        editors.Add(editor);
                        DetailContainer.Children.Add(editor);
                        total++;
                    }

                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex);
                }
                (Container.Children[0] as Label).TextColor = selectedTextColor;
                (Container.Children[0] as Label).BackgroundColor = selectedBGColor;
                // the following forces the code in the ContinueWith block to be run on the
                // calling thread, often the Main/UI thread.
            }, TaskScheduler.FromCurrentSynchronizationContext());
            
        }
    }
}