using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bazy_samochody
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EdycjaPage : ContentPage
    {
        Car Car { get; set; }
        public EdycjaPage(Car car)
        {
            InitializeComponent();
            Car = car;
            nameEntry.Text = car.Name;
            yearEntry.Text = car.Year.ToString();
            pictureEntry.Text = car.Picture;
        }

        private void Wroc_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Edytuj_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(yearEntry.Text) && !string.IsNullOrWhiteSpace(pictureEntry.Text))
            {
                Car.Name = nameEntry.Text;
                Car.Year = int.Parse(yearEntry.Text);
                Car.Picture = pictureEntry.Text;
                await App.Database.UpdateCarAsync(Car);
                await Navigation.PopAsync();
            }
        }
    }
}