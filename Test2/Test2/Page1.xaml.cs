using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2.logic;
using Test2.model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Offer offerClicked { get; set; }
        public Page1(Offer offer)
        {
            offerClicked = new Offer();
            offerClicked = offer;
            string json = Data.JsonSerialize(offerClicked);
            InitializeComponent();
            
            Label text = new Label
            {
                Text = json,
                TextColor = Color.White
            };
            Button backButton = new Button
            {
                Text = "Назад",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            backButton.Clicked += BackButton_Click;

            this.Content = new StackLayout { Children = { text, backButton } };
        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}