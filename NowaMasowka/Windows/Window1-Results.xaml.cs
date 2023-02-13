
namespace NowaMasowka.Windows;

/// <summary>
/// Logika interakcji dla klasy Window1_Results.xaml
/// </summary>
public partial class Window1_Results : Window
{
    Page1_NewRecords page1 = new();
    Page2_OverwriteRecords page2 = new();
    Page3_NewSource page3 = new();
    Page4_DeleteSource page4 = new();
    public Window1_Results()
    {
        InitializeComponent();
        page1.Window1Page1DataGrid.ItemsSource = RepositoryLists.listOfNewRecord;
        page2.Window1Page2DataGrid.ItemsSource = RepositoryLists.listOfNewExistRecord;
        page4.Window1Page4DataGrid.ItemsSource = RepositoryLists.listOfDeleteSource;
        Window1Frame.Content = page1;
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        RepositoryLists.listOfNewRecord.Clear();
        RepositoryLists.listOfNewExistRecord.Clear();
        RepositoryLists.listOfNewSources.Clear();
        RepositoryLists.listOfNewSourcesWithDuplicates.Clear();
        RepositoryLists.listOfDeleteSource.Clear();
    }

    private void Window1SaveFilesButton_Click(object sender, RoutedEventArgs e)
    {
        RepositoryToFile<IndeksNewRecord>.ToFileWithCount(RepositoryLists.listOfNewRecord, IndeksNewRecord.Path, IndeksNewRecord.Title);
        RepositoryToFile<IndeksNewExistRecord>.ToFile(RepositoryLists.listOfNewExistRecord, IndeksNewExistRecord.Path, IndeksNewExistRecord.Title);

        if(WithDouble.IsChecked == true)
        {
            RepositoryToFile<IndeksNewSource>.ToFile(RepositoryLists.listOfNewSourcesWithDuplicates, IndeksNewSource.Path, IndeksNewSource.Title);
        }else
        {
            RepositoryToFile<IndeksNewSource>.ToFile(RepositoryLists.listOfNewSources, IndeksNewSource.Path, IndeksNewSource.Title);
        }

        RepositoryToFile<IndeksDeleteSource>.ToFile(RepositoryLists.listOfDeleteSource, IndeksDeleteSource.Path, IndeksDeleteSource.Title);


        MessageBox.Show("Podmieniono pliki na dysku C - LSMW");
    }

    private void WithDouble_Checked(object sender, RoutedEventArgs e)
    {
        
        page3.Window1Page3DataGrid.ItemsSource = RepositoryLists.listOfNewSourcesWithDuplicates;
    }

    private void WithDouble_Unchecked(object sender, RoutedEventArgs e)
    {
        page3.Window1Page3DataGrid.ItemsSource = RepositoryLists.listOfNewSources;
    }

    private void LabelNewRecord_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Window1Frame.Content = page1;
    }

    private void LabelNewExistRecord_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Window1Frame.Content = page2;
    }

    private void LabelNewSource_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Window1Frame.Content = page3;
    }

    private void LabelDeleteSource_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Window1Frame.Content = page4;
    }
}
