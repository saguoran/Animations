using System;
using Animations.Droid.CustomRenderer;
using Xamarin.Forms;
using Animations.CustomRenderer;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(EditorNoUnderline), typeof(EditorNoUnderlineRenderer))]
namespace Animations.Droid.CustomRenderer
{
    public class EditorNoUnderlineRenderer:EditorRenderer
    {
       
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control.TintColor = new UIColor(red: 0.20f, green: 0.20f, blue: 0.20f, alpha: 1.0f);
        }
    }
}