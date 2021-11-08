using CountryApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCountryPage : ContentPage
    {
        private readonly RestClient _client = new RestClient("http://localhost:58020/api");
        public NewCountryPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            bool isNameEmpty = string.IsNullOrEmpty(countryEntry.Text);
            bool isCodeEmpty = string.IsNullOrEmpty(countryCode.Text);
            bool isLanguageEmpty = string.IsNullOrEmpty(countryLanguage.Text);
            bool isCurrencyempty = string.IsNullOrEmpty(countrycurrency.Text);

            if (isNameEmpty || isCodeEmpty || isLanguageEmpty || isCurrencyempty)
            {
                await DisplayAlert("Failure", "Name, Code, Language & currency are requied!", "Ok");
            }
            else
            {
                //Navigation
                await Navigation.PushAsync(new HomePage());
            }
        }

        private Country Create(string url)
        {
            var request = new RestRequest(url, Method.POST);
            var response = _client.Execute(request);
            return JsonConvert.DeserializeObject(response.Content) as Country;
        }
    }
}