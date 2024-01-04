
using BookReader.Models;

namespace BookReader;

public partial class ResultPage : ContentPage
{

    List<Book> _books;

	public ResultPage()
	{
		InitializeComponent();
		

    }

	public ResultPage(List<Book> books)
	{
        InitializeComponent();
        lvResultList.ItemsSource = books;
        _books = books;

    }
    

    private void btOpen_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        Grid listviewItem = (Grid)button.Parent;

        var _id = ((Label)listviewItem.Children[0]).Text;
        var _selectedRecord = _books.FirstOrDefault(b => b.Id == Int32.Parse(_id));


        Navigation.PushAsync(new ReaderPage(_selectedRecord.Example));
    }
}