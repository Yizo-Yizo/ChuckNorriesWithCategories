using ChuckNorriesWithCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorriesWithCategories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public string[] Categories { get; set; }

        public CategoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var jokeGen = new JokeGenerator();

            Categories = await jokeGen.GetCategories();

            BindingContext = this;
        }

        //private async void Category_Clicked(object sender, ValueChangedEventArgs e)
        //{
        //    var jokeGenerator = new JokeGenerator.GetCategories();
        //    string joke = await jokeGenerator.GetCategories();
        //}

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var jokeGenerator = new JokeGenerator();
            string joke = await jokeGenerator.GetRandomCategoryJoke(e.Item.ToString());

            await DisplayAlert("Joke", joke, "OK");
        }
    }
}