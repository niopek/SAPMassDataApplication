
namespace NowaMasowka.Pages.MainWindowPages;

/// <summary>
/// Logika interakcji dla klasy Page4_ExistSource.xaml
/// </summary>
public partial class Page4_ExistSource : Page
{
    Window2_Tutorial? tutorialWindow;
    public Page4_ExistSource()
    {
        InitializeComponent();
        Page4DataGrid.ItemsSource = RepositoryLists.listExistSource;
    }
    private void Page4ClearButton_Click(object sender, RoutedEventArgs e)
    {
        RepositoryLists.listExistSource.Clear();
        RepositoryLists.listExistSource.Add(new IndeksExistSource());
    }

    private void Page4DataGrid_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
        {
            string tekst = Clipboard.GetText();

            List<string> clipboardList = Utils.FromClipboardToList(tekst, "\n");

            Utils.FromListToObject(clipboardList, RepositoryLists.listExistSource);


            Page4DataGrid.ItemsSource = RepositoryLists.listExistSource;
        }
    }

    private void Page4TutorialButton_Click(object sender, RoutedEventArgs e)
    {
        tutorialWindow = new();
        tutorialWindow.Show();
    }
}
