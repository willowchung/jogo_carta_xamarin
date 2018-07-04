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
        private static List<Image> allMyCards;
        private static String acesAsset = "a_card.jpg";
        private static String jokerAsset = "joker_card.jpg";
        private static String blankAsset = "back_card.jpg";
        private static Boolean isOnAnimation = false;
        private static Boolean wasBadLuck = false;
        private static int score = 0;
        private static int scoreRecord = 0;

        public MainPage()
        {
            InitializeComponent();
            allMyCards = new List<Image>() { leftCard, middleCard, rightCard };
        }   

        void OnTapCard(object sender, EventArgs args)
        {
            if (!isOnAnimation)
            {
                isOnAnimation = true;
                wasBadLuck = new Random().Next(3) == 0;
                ChangeImageTo((Image)sender, (wasBadLuck ? jokerAsset : acesAsset));

                score = wasBadLuck ? 0 : score + 1;
                scoreRecord = score > scoreRecord ? score : scoreRecord;

                labelResultado.Text = "Seu placar atual é: " + score;
                labelRecorde.Text = "Recorde: " + scoreRecord;
                EndOfMatch();
            }
        }

        async void ChangeImageTo(Image image, String asset)
        {
            await image.RotateYTo(90);
            image.Source = asset;
            await image.RotateYTo(360);
        }

        async void EndOfMatch()
        {
            await Task.Delay(3000); // Aguardar animacao terminar
            allMyCards.ForEach(c => ChangeImageTo(c, blankAsset));
            isOnAnimation = false;
        }

        public static async Task Sleep(int ms)
        {
            await Task.Delay(ms);
        }
    }
}
