using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations.DesignDay2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TappedView2rdTry : ContentView
    {
        private static string selected;
        private static List<Note> notes = Note.NoteResource();
        public TappedView2rdTry()
        {
            InitializeComponent();
            var tapRecognizer = new TapGestureRecognizer();
            notes.ForEach(note =>
            {
                TabeContainer.Children.Add(new Label
                {
                    Text = note.Title,
                    WidthRequest = 200,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.Aqua,
                    Margin = new Thickness(0.5, 0),
                    ClassId = note.Id,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    GestureRecognizers = { tapRecognizer }
                }
                );
            });
            tapRecognizer.Tapped += (o, args) => {
                Label selectedLabel = TabeContainer.Children.Where(l => l.ClassId == selected).FirstOrDefault() as Label;
                selectedLabel.BackgroundColor = Color.Aqua;
                Label label = o as Label;
                selected = label.ClassId;
                label.BackgroundColor = Color.Accent;
                editorNoUnderline.Text = notes.Find(note => note.Id == label.ClassId).Detail;
            };
            selected = notes[0].Id;
            TabeContainer.Children[0].BackgroundColor = Color.Accent;
        }

        //hardcode function
    }
    public class Note
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




