using CountryApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CountryApp
{
    public partial class MainPage : ContentPage
    {
        //private RestClient _client = new RestClient("http://localhost:58020/api");
        private RestClient _client = new RestClient("http://148.72.213.211:91/api");
        private RestClient _client2 = new RestClient("https://jsonplaceholder.typicode.com/");
        public MainPage()
        {
            InitializeComponent();
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            var username = emailEntry.Text;
            var password = passwordEntry.Text;
            bool isEmailEmpty = string.IsNullOrEmpty(username);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                await DisplayAlert("Failure", "Email or Paaword is empty!", "Ok");
            }
            else
            {
                //Navigation
                await Login(username, password);
                await Navigation.PushAsync(new HomePage());                
            }
        }

        private async Task<bool> Login(string username, string password)
        {
            try
            {
                var loginObj = new LoginModel()
                {
                    UserName = username,
                    Password = password
                };
                var url = "/Account/CheckLogin";
                RestRequest request = new RestRequest(url, Method.POST);
                request.AddJsonBody(loginObj);
                request.AddHeader("Content-type", "application/json; charset=UTF-8");
                var response = await _client.ExecuteAsync(request);

                //var postobj = new Post()
                //{
                //    Title = "New Post",
                //    Body = "A brand new post!",
                //    UserId = "1"
                //};
                //var url2 = "posts";
                //RestRequest request2 = new RestRequest(url2, Method.POST);
                //request2.AddJsonBody(postobj);
                //request2.AddHeader("Content-type", "application/json; charset=UTF-8");
                //var response2 = await _client2.ExecuteAsync(request2);

                //var request3 = new RestRequest(url2, Method.GET);
                //var response3 = await _client2.ExecuteAsync(request3);


                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
        }
    }
}
