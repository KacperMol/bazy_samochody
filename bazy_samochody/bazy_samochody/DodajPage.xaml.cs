using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bazy_samochody
{
    public partial class DodajPage : ContentPage
    {
        Car Car { get; set; }   
        public DodajPage()
        {
            InitializeComponent();   
        }
        private async void Dodaj_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(yearEntry.Text) && !string.IsNullOrWhiteSpace(pictureEntry.Text))
            {
                await App.Database.SaveCarAsync(new Car
                {
                    Name = nameEntry.Text,
                    Year = int.Parse(yearEntry.Text),
                    Picture = pictureEntry.Text 
                });

                nameEntry.Text = yearEntry.Text = string.Empty;
                await Navigation.PopAsync();  
            }

        }

        private void Wroc_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}