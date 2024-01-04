using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BookReader.Models;
using Newtonsoft.Json;

namespace BookReader;

public partial class LoginPage : ContentPage
{

    public LoginPage()
	{
		InitializeComponent();
	}


    public object RefreshDataAsync(string UID, string PWD)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8083/api/User");

      
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        var obj = new {
            uid = UID,
            pwd = PWD
        };

        JsonContent _content = JsonContent.Create(obj);

        var response = client.PostAsync("http://localhost:8083/api/User", _content).Result;

         if (response.IsSuccessStatusCode)
            {
           
                var dataObjects = response.Content.ReadAsStringAsync().Result; 
                var userData = JsonConvert.DeserializeObject<User>(dataObjects);
                return userData;
            }
        else
            {
                return response.StatusCode;
            }
        
       
    }


    private void Button_Clicked(object sender, EventArgs e)
    {

        if ( RefreshDataAsync(tbUID.Text, tbPWD.Text) is User)
        {
            
                Navigation.PushAsync(new HomePage());
        }
        else
        {  
                DisplayAlert("Hiba", "A felhasználói név és jelszó nem megfelelõ!", "Ok");
        }
        
    }
}