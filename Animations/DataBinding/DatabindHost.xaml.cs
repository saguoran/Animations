using Animations.DataModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations.DataBinding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabindHost : ContentPage
    {
        static List<Note> text = Note.Notes;
        public static readonly List<string> li = Note.Notes.Select(n => n.Title).ToList();
        //DatabBinding1st d1 = new DatabBinding1st { TabSource = li };
        public DatabindHost()
        {
            InitializeComponent();
        }
    }
}