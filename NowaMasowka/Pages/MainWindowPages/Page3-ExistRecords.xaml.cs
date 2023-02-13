
namespace NowaMasowka.Pages.MainWindowPages;

/// <summary>
/// Logika interakcji dla klasy Page3_ExistRecords.xaml
/// </summary>
public partial class Page3_ExistRecords : Page
{
    public Page3_ExistRecords()
    {
        InitializeComponent();
        Page3DataGrid.ItemsSource = RepositoryLists.listExistRecord;
    }

    private void Page3ClearButton_Click(object sender, RoutedEventArgs e)
    {
        RepositoryLists.listExistRecord.Clear();
        RepositoryLists.listExistRecord.Add(new IndeksExistRecord());
    }

    private void Page3DataGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
        {
            string tekst = Clipboard.GetText();

            List<string> clipboardList = Utils.FromClipboardToList(tekst, "\n");

            Utils.FromListToObject(clipboardList, RepositoryLists.listExistRecord);


            Page3DataGrid.ItemsSource = RepositoryLists.listExistRecord;
        }
    }
}
