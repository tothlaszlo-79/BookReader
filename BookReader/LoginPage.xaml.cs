namespace BookReader;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if(tbUID.Text == "admin" && tbPWD.Text == "admin")
		{
            Navigation.PushAsync(new HomePage());
		}
		else
		{
			DisplayAlert("Hiba", "A felhaszn�l�i n�v �s jelsz� nem megfelel�!","Ok");
		}
    }
}