
using Xamarin.Forms;

namespace Animations.CarouselViews
{
    public class TabItem : ObservableBase
    {
        public TabItem()
        {
            //Parameterless constructor required for xaml instantiation.
        }

        public TabItem(string headerText, View content)
        {
            _headerText = headerText;
            _content = content;
        }

        private string _headerText;
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }

        private View _content;
        public View Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private bool _isCurrent;
        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { SetProperty(ref _isCurrent, value); }
        }

        private Color _headerTextColor;
        public Color HeaderTextColor
        {
            get { return _headerTextColor; }
            set { SetProperty(ref _headerTextColor, value); }
        }

        private Color _headerSelectionUnderlineColor;
        public Color HeaderSelectionUnderlineColor
        {
            get { return _headerSelectionUnderlineColor; }
            set { SetProperty(ref _headerSelectionUnderlineColor, value); }
        }

        private double _headerSelectionUnderlineThickness;
        public double HeaderSelectionUnderlineThickness
        {
            get { return _headerSelectionUnderlineThickness; }
            set { SetProperty(ref _headerSelectionUnderlineThickness, value); }
        }

        private double _headerSelectionUnderlineWidth;
        public double HeaderSelectionUnderlineWidth
        {
            get { return _headerSelectionUnderlineWidth; }
            set { SetProperty(ref _headerSelectionUnderlineWidth, value); }
        }

        private double _headerTabTextFontSize;
        [Xamarin.Forms.TypeConverter(typeof(FontSizeConverter))]
        public double HeaderTabTextFontSize
        {
            get { return _headerTabTextFontSize; }
            set { SetProperty(ref _headerTabTextFontSize, value); }
        }

        private string _headerTabTextFontFamily;
        public string HeaderTabTextFontFamily
        {
            get { return _headerTabTextFontFamily; }
            set { SetProperty(ref _headerTabTextFontFamily, value); }
        }

        private FontAttributes _headerTabTextFontAttributes;
        public FontAttributes HeaderTabTextFontAttributes
        {
            get { return _headerTabTextFontAttributes; }
            set { SetProperty(ref _headerTabTextFontAttributes, value); }
        }
    }
}