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
        SKCanvasView c;
        TapGestureRecognizer tapRecognizer;


        public SkiasharpAnimation()
        {
            Grid g = new Grid();
            c = new SKCanvasView ();
            c.PaintSurface += OnPaintSurface;
            tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += OnTapped;

            c.GestureRecognizers.Add(tapRecognizer);

            Content = g;
            g.Children.Add(c);
          
            
        }

        protected void OnPaintSurface(Object o, SKPaintSurfaceEventArgs args)
        {
            var surface = args.Surface;
            var canvas = surface.Canvas;
            var info = args.Info;
            var height = info.Height;
            var width = info.Width;

            var rect = SKRect.Create( width / 2, height / 2, 20, 40);
            using(var paint = new SKPaint())
            {
                canvas.DrawRect(rect, paint);
                canvas.DrawText($"{height} X {width} ", width / 2, height / 2, paint);
            }
            
        }
        protected async void OnTapped(Object o, EventArgs args)
        {
            tapRecognizer.Tapped -= OnTapped;
            await c.RelRotateTo(360, 8000);
            tapRecognizer.Tapped += OnTapped;
        }
      
    }
}