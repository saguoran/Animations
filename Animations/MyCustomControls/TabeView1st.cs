using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Animations.MyCustomControls
{
    public class TabeView1st : ContentView
    {
        #region Component
        private static Frame frame;
        private static FlexLayout tabContainer;
        private static List<Label> tabLabels;
        private static Editor detail;
        private static List<string> tabs = Note.NoteResource().Select(n => n.Title).ToList();
        private static List<string> tabDetail = Note.NoteResource().Select(n => n.Detail).ToList();
        private static string selected;
        #endregion
        #region Bindable Properties
        #region Tab Properties
        ///
        ///Tabs source property
        ///
        public static readonly BindableProperty TabsSourceProperty =
            BindableProperty.Create("TabsSource", typeof(List<string>), typeof(TabeView1st), tabs);
        public List<string> TabsSource
        {
            get => GetValue(TabsSourceProperty) as List<string>;
            set { SetValue(TabsSourceProperty, value); }
        }
        #region Attached Properties

        public static readonly BindableProperty TextColorProperty =
                BindableProperty.CreateAttached("TextColor", typeof(bool), typeof(TabeView1st), false);
        public static bool GetTextColor(BindableObject view)
        {
            return (bool)view.GetValue(TextColorProperty);
        }
        public static void SetTextColor(BindableObject view, bool value)
        {
            view.SetValue(TextColorProperty, value);
        }


        public static readonly BindableProperty TextBackgroundColorProperty =
                BindableProperty.CreateAttached("BackgroundColor", typeof(bool), typeof(TabeView1st), false);
        public static bool GetBackgroundColor(BindableObject view)
        {
            return (bool)view.GetValue(TextBackgroundColorProperty);
        }
        public static void SetBackgroundColor(BindableObject view, bool value)
        {
            view.SetValue(TextBackgroundColorProperty, value);
        }


        public static readonly BindableProperty SelectedBackgroundColorProperty =
                BindableProperty.CreateAttached("BackgroundColor", typeof(bool), typeof(TabeView1st), false);
        public static bool GetSelectedBackgroundColor(BindableObject view)
        {
            return (bool)view.GetValue(TextBackgroundColorProperty);
        }
        public static void SetSelectedBackgroundColor(BindableObject view, bool value)
        {
            view.SetValue(TextBackgroundColorProperty, value);
        }
        #endregion

        ///
        ///Tab Text Color property
        ///
        public static readonly BindableProperty TabTextColorProperty =
           BindableProperty.Create("TabTextColor", typeof(string), typeof(TabeView1st), "#BDBEBF"); 
        public string TabTextColor
        {
            get => GetValue(TabTextColorProperty) as string;
            set { SetValue(TabTextColorProperty, value); }
        }
        ///
        ///Tab background Color property
        ///
        public static readonly BindableProperty TabBGColorProperty =
           BindableProperty.Create("TabBGColor", typeof(string), typeof(TabeView1st), "#F5F5F5");
        public string TabBGColor
        {
            get => GetValue(TabBGColorProperty) as string;
            set { SetValue(TabBGColorProperty, value); }
        }
        ///
        ///Tab Selected background Color property
        ///
        public static readonly BindableProperty TabSelectedBGColorProperty =
           BindableProperty.Create("TabSelectedBGColor", typeof(string), typeof(TabeView1st), "#F5F5F5");
        public string TabSelectedBGColor
        {
            get => (string)GetValue(TabSelectedBGColorProperty);
            set { SetValue(TabSelectedBGColorProperty, value); }
        }
 
        ///
        ///Tab Margin property
        ///
        public static readonly BindableProperty TabMarginProperty =
           BindableProperty.Create("TabMargin", typeof(float), typeof(TabeView1st), 1.0f);
        public float TabMargin
        {
            get => (float)GetValue(TabMarginProperty);
            set { SetValue(TabMarginProperty, value); }
        }
        ///
        ///Tab Width property
        ///
        public static readonly BindableProperty TabWidthProperty =
           BindableProperty.Create("TabWidth", typeof(float), typeof(TabeView1st), 170f);
        public float TabWidth
        {
            get => (float)GetValue(TabWidthProperty);
            set { SetValue(TabWidthProperty, value); }
        }

        #endregion
        ///
        ///Detail source property
        ///
        public static readonly BindableProperty DetailSrouceProperty =
           BindableProperty.Create("DetailSrouce", typeof(List<string>), typeof(TabeView1st), tabDetail);
        public List<string> DetailSrouce
        {
            get => GetValue(DetailSrouceProperty) as List<string>;
            set { SetValue(DetailSrouceProperty, value); }
        }
        #endregion
        public TabeView1st()
        {
            SelfInit();
            Content = frame;
        }
        private void SelfInit()
        {
            var tapRecognizer = new TapGestureRecognizer();
           
            tabContainer = new FlexLayout {
                BackgroundColor = Color.FromHex(TabSelectedBGColor),
                Padding = new Thickness(0,0,0, TabMargin*2)
            };

            tabLabels = new List<Label>();
            int i = 0;
            TabsSource.ForEach(t => {
                var label = new Label
                {
                    Text = t,
                    WidthRequest = TabWidth,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(TabMargin, 0),
                    ClassId = i.ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    GestureRecognizers = { tapRecognizer }
                };
                label.SetBinding(Label.TextColorProperty, new Binding("TextColor", source: this));
                label.SetBinding(BackgroundColorProperty, new Binding("TabBGColor", source: this));
                tabLabels.Add(label) ;
                tabContainer.Children.Add(label);
                i++;
            });

            tapRecognizer.Tapped += async (o, args) => {
                await detail.FadeTo(0, 100);
                Label selectedLabel = tabContainer.Children.Where(l => l.ClassId == selected).FirstOrDefault() as Label;
                selectedLabel.BackgroundColor = Color.FromHex(TabBGColor);
                selectedLabel.TextColor = Color.FromHex(TabTextColor);
                Label label = o as Label;
                selected = label.ClassId;
                label.BackgroundColor = Color.FromHex(TabSelectedBGColor);
                label.TextColor = Color.FromHex(TabBGColor);
                detail.Text = DetailSrouce[int.Parse(selected)];
                await detail.FadeTo(1, 100);
            };

            detail = new Editor { BackgroundColor = Color.Azure };
            FlexLayout.SetBasis(detail, new FlexBasis(0.9f, true));
            FlexLayout.SetGrow(detail, 1f);

            var scrollView = new ScrollView {
                Content = tabContainer,
                Orientation = ScrollOrientation.Horizontal
            };
            FlexLayout.SetBasis(scrollView, new FlexBasis(0.1f, true));

            frame = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                BorderColor = Color.FromHex(TabSelectedBGColor)
        };
            frame.Content = new FlexLayout {
                Direction = FlexDirection.Column,
                JustifyContent = FlexJustify.Start,
                Children = {
                    scrollView,
                    detail
                },
            };
            selected = "0";
            tabContainer.Children[0].BackgroundColor = Color.FromHex(TabSelectedBGColor);
            (tabContainer.Children[0] as Label).TextColor = Color.FromHex(TabBGColor);
        }
        private class Note
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Detail { get; set; }
            private static List<Note> Notes = new List<Note>();
            public static List<Note> NoteResource()
            {
                Notes.Add(new Note { Id = "0", Title = "Tab 1", Detail = "LKjflaksdjfkljasdfdasfasd" });
                Notes.Add(new Note { Id = "1", Title = "Tab 2", Detail = "gfgasgdadfasdfasdaksdjfkljasdfdasfasd" });
                Notes.Add(new Note { Id = "2", Title = "Tab 3", Detail = "qewrretsdfdasfasdfasdasfasd" });
                Notes.Add(new Note { Id = "3", Title = "Tab 4", Detail = "jyngjhgqewasdfrretsdfdasfasdfasdasfasd" });
                Notes.Add(new Note { Id = "4", Title = "Tab 5", Detail = "asdfqasdfaewrretsdfdasfasdfasdasfasd" });
                return Notes;
            }
        }
    }
}