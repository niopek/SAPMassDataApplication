
using System.Text.RegularExpressions;

namespace NowaMasowka.Pages.MainWindowPages;

/// <summary>
/// Logika interakcji dla klasy Page1_ToUpload.xaml
/// </summary>
public partial class Page1_ToUpload : Page
{
    public Page1_ToUpload()
    {
        InitializeComponent();
        Page1DataGrid.ItemsSource = RepositoryLists.listToUpload;
    }

    private void Page1ClearButton_Click(object sender, RoutedEventArgs e)
    {
        RepositoryLists.listToUpload.Clear();
        RepositoryLists.listToUpload.Add(new IndeksToUpload());

    }

    private void Page1DataGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
        {
            string tekst = Clipboard.GetText();

            List<string> clipboardList = Utils.FromClipboardToList(tekst, "\n");

            Utils.FromListToObject(clipboardList, RepositoryLists.listToUpload);


            Page1DataGrid.ItemsSource = RepositoryLists.listToUpload;
        }
    }
}
