
namespace NowaMasowka.Pages.MainWindowPages;

/// <summary>
/// Logika interakcji dla klasy Page2_Pricelist.xaml
/// </summary>
public partial class Page2_Pricelist : Page
{
    public Page2_Pricelist()
    {
        InitializeComponent();
        Page2DataGrid.ItemsSource = RepositoryLists.listPriceList;
    }

    private void Page2ClearButton_Click(object sender, RoutedEventArgs e)
    {
        RepositoryLists.listPriceList.Clear();
        RepositoryLists.listPriceList.Add(new IndeksPriceList());
    }

    private void Page2DataGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
        {
            string tekst = Clipboard.GetText();

            List<string> clipboardList = Utils.FromClipboardToList(tekst, "\n");

            Utils.FromListToObject(clipboardList, RepositoryLists.listPriceList);


            Page2DataGrid.ItemsSource = RepositoryLists.listPriceList;
        }

    }
}
