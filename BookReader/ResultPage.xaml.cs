
namespace BookReader;

public partial class ResultPage : ContentPage
{
	public ResultPage()
	{
		InitializeComponent();
		lvResultList.ItemsSource = AddBoooks();

    }


	private List<Books> AddBoooks()
	{
		List<Books> list = new List<Books>();
		
		list.Add(new Books { Author = "Teszt1", Title = "Cim 1", Example = "Minta 1" });
        list.Add(new Books { Author = "Teszt2", Title = "Cim 2", Example = "Minta 2" });
        list.Add(new Books { Author = "Teszt3", Title = "Cim 3", Example = "Minta 3" });

		return list;
    }

	public class Books
	{
        public string Author { get; set; }
        public string Title { get; set; }
        public string Example { get; set; }
    }

    private void btOpen_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new ReaderPage());
    }
}