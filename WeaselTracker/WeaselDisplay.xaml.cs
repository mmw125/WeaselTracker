using Hearthstone_Deck_Tracker.API;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Weasel
{
    public partial class WeaselDisplay : UserControl
    {
        internal Display _display = null;

        public WeaselDisplay()
        {
            InitializeComponent();
            UpdatePosition();
            _display = new Display("Weasels");
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
            this._display.Hide();
        }

        public void UpdatePlayerWeasels(int number)
        {
            this._display.UpdatePlayerNumber(number);
        }

        public void UpdateOpponnentWeasels(int number)
        {
            this._display.UpdateOpponentNumber(number);
        }

        private void Weasel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this._display.Show();
        }

        private void Weasel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this._display.Hide();
        }

        private void Weasel_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this._display.Show();
        }
    }
}
