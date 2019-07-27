using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animations.DataBinding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageGrid : ContentView
    {
        List<Image> imgs;
        Grid ImgContainer;
        ScrollView scrollView;
        private static int maxiumColumn = 5;
        public ImageGrid()
        {
            InitializeComponent();

            imgs = new List<Image>();
            ImgContainer = new Grid();
            scrollView = new ScrollView { Content = ImgContainer };

            LoadImages();
            ImgContainerReLayout();
            Content = ImgContainer;

        }
        private void LoadImages()
        {
            imgs.Add(new Image { Source = ImageSource.FromResource($"Animations.img.androidicon.png", typeof(ImageGrid).GetTypeInfo().Assembly) });
            int i = 8;
            while (i > 0)
            {
                var embeddedImage = new Image { Source = ImageSource.FromResource($"Animations.img.{i}.png", typeof(ImageGrid).GetTypeInfo().Assembly), BackgroundColor = Color.Snow };
                imgs.Add(embeddedImage);
                i -= 1;
            }
        }

        // function initialize the grid layout column and row, map images to grid layout.
        // 2 * 2 = 4 , 3 * 3 =9,...
        //maxium 5 * 5
        private void ImgContainerReLayout()
        {
            int count = imgs.Count;
            if (count < maxiumColumn * maxiumColumn)
            {
                maxiumColumn = (int)Math.Sqrt(count);
                for (int i = 0; i < maxiumColumn; i++)
                {
                    ImgContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    ImgContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                }
                ImgContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            else
            {
                for (int i = 0; i < maxiumColumn; i++)
                {
                    ImgContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    ImgContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                }
                for (int i = 0; i < count / maxiumColumn - maxiumColumn - 1; i++)
                {
                    ImgContainer.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                }
            }
            //add imgs to container
            int init = 0;
            int leftColumn = init;
            int rightColumn = leftColumn + 1;
            int topRow = init / maxiumColumn;
            int BottomRow = topRow + 1;
            imgs.ForEach(img => {
                // left, right, top, bottom, first two items (0, 1, 0, 1) (1, 2, 0, 1)
                ImgContainer.Children.Add(img, leftColumn, rightColumn, topRow, BottomRow);
                init++;
                leftColumn = init% maxiumColumn;
                rightColumn = leftColumn + 1;
                topRow = init  / maxiumColumn ;
                BottomRow = topRow + 1;
            });
        }
    }
}