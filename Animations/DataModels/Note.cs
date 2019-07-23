using System.Collections.Generic;

namespace Animations.DataModels
{
    public class Note
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public static List<Note> Notes => NoteResource();
        public static List<Note> NoteResource()
        {
            List<Note> notes = new List<Note>();
            notes.Add(new Note { Id = "0", Title = "Tab 1", Detail = "LKjflaksdjfkljasdfdasfasd" });
            notes.Add(new Note { Id = "1", Title = "Tab 2", Detail = "gfgasgdadfasdfasdaksdjfkljasdfdasfasd" });
            notes.Add(new Note { Id = "2", Title = "Tab 3", Detail = "qewrretsdfdasfasdfasdasfasd" });
            notes.Add(new Note { Id = "3", Title = "Tab 4", Detail = "jyngjhgqewasdfrretsdfdasfasdfasdasfasd" });
            notes.Add(new Note { Id = "4", Title = "Tab 5", Detail = "asdfqasdfaewrretsdfdasfasdfasdasfasd" });
            return notes;
        }
    }
}
