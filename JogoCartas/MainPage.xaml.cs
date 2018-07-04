using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JogoCartas
{
    public partial class MainPage : ContentPage
    {
        private static String jokerAsset = "joker_card.jpg";

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnTapCard(object sender, EventArgs args)
        {
            ChangeImageTo((Image)sender, jokerAsset);
        }

        async void ChangeImageTo(Image image, String asset)
        {
            await Task.WhenAll(
                image.RotateYTo(90)
            );

            image.Source = asset;

            await Task.WhenAll(
                image.RotateYTo(360)
            );
        }
    }
}
