using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Test2.logic;
using Test2.model;
using System.Net.Http;

namespace Test2
{
    public partial class MainPage : ContentPage
    {
        public List<string> result { get; set; }
        public Offers off { get; set; }

        public MainPage()
        {
            InitializeComponent();
            byte[] xml = Data.GetAsync();
            Yml_catalog cat = Data.Parse(xml);
            off = cat.Shop.Offers;
            result = new List<string>();
            foreach (var offer in off.Offer)
            {
                result.Add(offer.Id);
            }
            ListView listView = new ListView();
            listView.ItemsSource = result;
            listView.ItemTapped += this.ToCommonPage;
            this.Content = new StackLayout { Children = { listView } };
        }

        private async void ToCommonPage(object sender, ItemTappedEventArgs e)
        {
            string id = e.Item.ToString();
            Offer offerClicked = off.Offer.FindLast(x => (x.Id == id));
            await Navigation.PushAsync(new Page1(offerClicked));
        }
    }
}
