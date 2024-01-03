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
			DisplayAlert("Hiba", "A felhasználói név és jelszó nem megfelelõ!","Ok");
		}
    }
}