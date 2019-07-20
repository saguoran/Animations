using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace Animations.DesignDay2
{
    public class SkiaControlDesign : ContentPage
    {
        public SkiaControlDesign()
        {
            Content = new StackLayout { Children = { new MySKcontentView { HeightRequest=60, WidthRequest=200} }, BackgroundColor=Color.FromHex("#080"),HorizontalOptions=LayoutOptions.Center, VerticalOptions=LayoutOptions.Center };
        }

    }
    public class MySKcontentView : ContentView
    {
        SKCanvasView skCanvasView;
        string SelectedColor = "#900";
        bool selected = false;
        public MySKcontentView()
        {
            skCanvasView = new SKCanvasView();
            skCanvasView.GestureRecognizers.Add(tapRecognizer);
            Content = new Grid{Children = {skCanvasView}};
            skCanvasView.PaintSurface += (o, args) =>
            {
                var canvas = args.Surface.Canvas;
                var info = args.Info;
                var height = info.Height;
                var width = info.Width;
                canvas.Clear();
                string text = "Electrocity";
                using (var paint = new SKPaint { TextAlign=SKTextAlign.Center, Color=selected?SKColor.Parse(SelectedColor) : SKColors.DarkGray})
                {
                    float textWidth = paint.MeasureText(text);
                    // text size is text height
                    float defaultTextSize = paint.TextSize;

                    paint.TextSize = 0.99f * info.Width * paint.TextSize / textWidth;

                    SKPoint point = new SKPoint(width / 2, height / 2 + paint.TextSize*0.4f);
                    canvas.DrawText(text, point , paint);

                    paint.Style = SKPaintStyle.Stroke;
                    paint.StrokeWidth = height * 0.2f;
                    canvas.DrawLine(0f, height, width, height, paint);
                }
            };
            tapRecognizer.Tapped += (o, args) => {
                selected = !selected;
                skCanvasView.InvalidateSurface();
            };
        }

        TapGestureRecognizer tapRecognizer = new TapGestureRecognizer();
        
    }
    public class RectangleTag
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        private SKRect skRectangle;
        public SKRect SKRectangle {
            get => SKRect.Create(X, Y, Width, Height);
            set { skRectangle = value; }
        }
        public float Paddding { get; set; }
    }
    public class RectangleTagText
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Text { get; set; }
        public float TextSize { get; set; }
    }
}