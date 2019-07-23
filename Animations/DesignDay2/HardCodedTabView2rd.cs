using System;
using System.Collections.Generic;
using System.Linq;
using Animations.DataModels;

using Xamarin.Forms;

namespace Animations.DesignDay2
{
    public class HardCodedTabView2rd : ContentView
    {
        private static List<Note> notes = Note.NoteResource();
        #region Component
        private static Frame frame;
        private static FlexLayout tabContainer;
        private static List<Label> tabLabels;
        private static Editor detail;
        private static string selected;
        #endregion
        #region Bindable Properties
        #region Tab Properties
        public Color TabTextColor { get; set; } = Color.FromHex("#BDBEBF");
        public Color TabBGColor { get; set; } = Color.FromHex("#F5F5F5");
        public Color SelectedTextColor { get; set; } = Color.FromHex("#F5F5F5");
        public Color SelectedTextBGColor { get; set; } = Color.FromHex("#2F3A70");
        public float TabMargin { get; set; } = 1.0f;
        public float TabWidth { get; set; } = 170f;
        #endregion
        ///source properties
        public List<string> TabsSource { get; set; } = notes.Select(n => n.Title).ToList();
        public List<string> DetailSrouce { get; set; } = notes.Select(n => n.Detail).ToList();
        #endregion
        public HardCodedTabView2rd()
        {
            SelfInit();
            Content = frame;
        }
        private void SelfInit()
        {
            var tapRecognizer = new TapGestureRecognizer();

            tabContainer = new FlexLayout
            {
                BackgroundColor = SelectedTextBGColor,
                Padding = new Thickness(0, 0, 0, TabMargin * 2)
            };

            tabLabels = new List<Label>();
            int i = 0;
            TabsSource.ForEach(t =>
            {
                var label = new Label
                {
                    Text = t,
                    TextColor = TabTextColor,
                    WidthRequest = TabWidth,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = TabBGColor,
                    Margin = new Thickness(TabMargin, 0),
                    ClassId = i.ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    GestureRecognizers = { tapRecognizer }
                };
                tabLabels.Add(label);
                tabContainer.Children.Add(label);
                i++;
            });

            tapRecognizer.Tapped += async (o, args) =>
            {
                await detail.FadeTo(0, 100);
                Label selectedLabel = tabContainer.Children.Where(l => l.ClassId == selected).FirstOrDefault() as Label;
                selectedLabel.BackgroundColor = TabBGColor;
                selectedLabel.TextColor = TabTextColor;
                Label label = o as Label;
                selected = label.ClassId;
                label.BackgroundColor = SelectedTextBGColor;
                label.TextColor = SelectedTextColor;
                detail.Text = DetailSrouce[int.Parse(selected)];
                await detail.FadeTo(1, 100);
            };

            detail = new Editor { BackgroundColor = Color.Azure };
            FlexLayout.SetBasis(detail, new FlexBasis(0.9f, true));
            FlexLayout.SetGrow(detail, 1f);

            var scrollView = new ScrollView
            {
                Content = tabContainer,
                Orientation = ScrollOrientation.Horizontal
            };
            FlexLayout.SetBasis(scrollView, new FlexBasis(0.1f, true));

            frame = new Frame
            {
                Padding = new Thickness(1),
                HasShadow = true,
                BorderColor = Color.FromHex("#101A40")
            };
            frame.Content = new FlexLayout
            {
                Direction = FlexDirection.Column,
                JustifyContent = FlexJustify.Start,
                Children = {
                    scrollView,
                    detail
                },
            };
            selected = "0";
            tabContainer.Children[0].BackgroundColor = SelectedTextBGColor;
        }
    }
}