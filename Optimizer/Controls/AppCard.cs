using System;
using System.Windows.Forms;

namespace Optimizer
{
    public sealed partial class AppCard : UserControl
    {
        public AppCard()
        {
            InitializeComponent();
        }

        // Override the OnClick method
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            // Add your click event handling logic here
            // For example, you might want to raise a custom event
            OnAppCardClicked(EventArgs.Empty);
        }

        // Define a custom event to be raised when the card is clicked
        public event EventHandler AppCardClicked;

        // Method to raise the custom event
        public void OnAppCardClicked(EventArgs e)
        {
            AppCardClicked?.Invoke(this, e);
        }
    }
}