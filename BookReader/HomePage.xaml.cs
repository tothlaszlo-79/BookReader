using System.Net.Http.Headers;
using System.Net.Http.Json;
using BookReader.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace BookReader;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		pGenre.ItemsSource = SetpGenreValue();
	}

	private List<string> SetpGenreValue()
	{
		List<string> _genreList = new List<string> {" ","Adult","Fantasy","Horror","Sci-fi","History" };
		return _genreList;
    }

    public object RefreshDataAsync(string Author, string Title, string Genre)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8083/api/Books");


        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        var obj = new
        {
            author = Author,
            title = Title,
            genre = Genre
        };

        JsonContent _content = JsonContent.Create(obj);

        var response = client.PostAsync("http://localhost:8083/api/Books", _content).Result;

        if (response.IsSuccessStatusCode)
        {

            var dataObjects = response.Content.ReadAsStringAsync().Result;
            var userData = JsonConvert.DeserializeObject<List<Book>>(dataObjects);
            return userData;
        }
        else
        {
            return response.StatusCode;
        }


    }

    public object GetAllDataAsync()
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:8083/api/Books");


        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        var response = client.GetAsync("http://localhost:8083/api/Books").Result;

        if (response.IsSuccessStatusCode)
        {

            var dataObjects = response.Content.ReadAsStringAsync().Result;
            var userData = JsonConvert.DeserializeObject<List<Book>>(dataObjects);
            return userData;
        }
        else
        {
            return response.StatusCode;
        }


    }



    private void btSearch_Clicked(object sender, EventArgs e)
    {

        string _mufaj = "";
        string _szerzo = "";
        string _cim = "";

        if (pGenre.SelectedIndex != -1)
        {
            _mufaj = pGenre.SelectedItem.ToString();

        }
        
        if (!string.IsNullOrEmpty(tbAuthor.Text))  _szerzo = tbAuthor.Text; 
        if (!string.IsNullOrEmpty(tbTitle.Text)) _cim = tbAuthor.Text;

        if (_szerzo == "" && _cim == "" && _mufaj == "")
        {
            var _all = GetAllDataAsync();
            if (_all is List<Book>)
            {
                Navigation.PushAsync(new ResultPage((List<Book>)_all));
            }
        }
        else
        {

            var result = RefreshDataAsync(_szerzo, _cim, _mufaj);
            if (result is List<Book>)
            {
                Navigation.PushAsync(new ResultPage((List<Book>)result));
            }

        }
        



    }
}