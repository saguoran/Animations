using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkiaSharp;
using SkiaSharp.Views.Forms;

using Xamarin.Forms;

namespace Animations.animationDay1
{
    public class SkiasharpAnimation : ContentPage
    {
        
        
        
        public SkiasharpAnimation()
        {
            SKCanvasView c = new SKCanvasView();
            c.PaintSurface += OnPaintSurface;

            //var tapRecognizer = new TapGestureRecognizer();
            //tapRecognizer.Tapped += OnTapped;
            //c.GestureRecognizers.Add(tapRecognizer);

            Content = c;
        }

        protected void OnPaintSurface(Object o, SKPaintSurfaceEventArgs args)
        {
            var surface = args.Surface;
            var canvas = surface.Canvas;
            var info = args.Info;
            var height = info.Height;
            var width = info.Width;

            var rect = SKRect.Create(40, 40, 20, 40);
            using(var paint = new SKPaint())
                canvas.DrawRect(rect, paint);
            
        }
        //protected void OnTapped(Object o, EventArgs args)
        //{

        //}
    }
}