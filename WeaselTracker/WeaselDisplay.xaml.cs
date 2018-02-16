using Hearthstone_Deck_Tracker.API;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Weasel
{
    public partial class WeaselDisplay : UserControl
    {
        public WeaselDisplay()
        {
            InitializeComponent();
            UpdatePosition();
            Hide();
        }

        public void UpdateNumber(int number)
        {
            this.textBlock.Text = number + "";
            UpdatePosition();
        }

        private double ScreenRatio => (4.0 / 3.0) / (Core.OverlayCanvas.Width / Core.OverlayCanvas.Height);
        public void UpdatePosition()
        {
            Canvas.SetRight(this, Hearthstone_Deck_Tracker.Helper.GetScaledXPos(5.0 / 100, (int)Core.OverlayCanvas.Width, ScreenRatio));
            Canvas.SetBottom(this, Core.OverlayCanvas.Height * 80 / 100);
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Hidden;
        }

        public void UpdatePlayerWeasels(int number)
        {

        }

        public void UpdateOpponnentWeasels(int number)
        {

        }
    }
}
