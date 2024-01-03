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

    private void btSearch_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ResultPage());
    }
}