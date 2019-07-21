using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Animations.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Animations.CustomRenderer;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(EditorNoUnderline), typeof(EditorNoUnderlineRenderer))]
namespace Animations.Droid.CustomRenderer
{
    public class EditorNoUnderlineRenderer:EditorRenderer
    {
        public EditorNoUnderlineRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                // cursor_shape is the xml file name which we defined above
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.cursor_shape);
            }
        }
    }
}