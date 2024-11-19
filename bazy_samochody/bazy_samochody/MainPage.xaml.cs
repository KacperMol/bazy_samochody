using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bazy_samochody
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetCarAsync();
        }

        private void Dodaj_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DodajPage());
        }

        private void Szczegoly_Clicked(object sender, EventArgs e)
        {
            var senderBindingContext = ((Button)sender).BindingContext;
            var car = (Car)senderBindingContext;
            DisplayAlert("Szczegóły samochodu", car.Name + ", " + car.Year + " Adres obrazka: " + car.Picture, "ok");
        }


        private void Edytuj_Clicked(object sender, EventArgs e)
        {
            var car = collectionView.SelectedItem as Car;
            if (car != null)
            {
                Navigation.PushAsync(new EdycjaPage(car));

            }
            else
            {
                DisplayAlert("Invalid", "Nigga! Select the item!", "OK");
            }
        }

        private async void Usun_Clicked(object sender, EventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                await App.Database.DeleteCarAsync((Car)collectionView.SelectedItem);
                collectionView.ItemsSource = await App.Database.GetCarAsync();
            }
            else
            {
                await DisplayAlert("Invalid", "Nigga! Select the item!", "OK");
            }
        }

        private void MenuItem_Szczegoly_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var car = menuItem.CommandParameter as Car;
            DisplayAlert("Szczegóły samochodu", car.Name + ", " + car.Year + " Adres obrazka: " + car.Picture, "ok");
        }

        private void collectionView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var car = collectionView.SelectedItem as Car;
            if (car != null)
            {
                Navigation.PushAsync(new EdycjaPage(car));

            }
            else
            {
                DisplayAlert("Invalid", "Nigga! Select the item!", "OK");
            }
        }
    }
}


