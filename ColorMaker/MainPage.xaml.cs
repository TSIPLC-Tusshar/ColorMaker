using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string hexValue = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            btnGenerateRandonColor.BackgroundColor = color;
            frmContainer.BackgroundColor = color;
            mainStack.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHexColor.Text = hexValue;
        }

        private void btnGenerateRandonColor_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var randon = new Random();

            var color = Color.FromRgb(randon.Next(0, 255), randon.Next(0, 255), randon.Next(0, 255));

            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;

            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short);
            await toast.Show();
        }
    }

}
