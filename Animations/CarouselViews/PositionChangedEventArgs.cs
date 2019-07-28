using System;

namespace Animations.CarouselViews
{
    public class PositionChangedEventArgs : EventArgs
    {
        public int NewPosition { get; set; }
        public int OldPosition { get; set; }
    }
}