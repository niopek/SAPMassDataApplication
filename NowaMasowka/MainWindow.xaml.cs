

using NowaMasowka.Classes;

namespace NowaMasowka;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    readonly Page1_ToUpload page1 = new();
    readonly Page2_Pricelist page2 = new();
    readonly Page3_ExistRecords page3 = new();
    readonly Page4_ExistSource page4 = new();
    Window1_Results? newWindow;
    public MainWindow()
    {
        InitializeComponent();
        MainDisplay.Content = page1;
        TextBoxDateFrom.Text = DateTime.Today.ToString("d");
        TextBoxDateTo.Text = DateTime.Today.AddYears(1).ToString("d");
    }

    private void MainWindowLabel1_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MainDisplay.Content = page1;

    }

    private void MainWindowLabel2_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MainDisplay.Content = page2;
    }

    private void MainWindowLabel3_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MainDisplay.Content = page3;
    }

    private void MainWindowLabel4_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MainDisplay.Content = page4;
    }

    private void FillButton_Click(object sender, RoutedEventArgs e)
    {
        Utils.timeRecordFrom = TextBoxDateFrom.Text;
        Utils.timeRecordTo = TextBoxDateTo.Text;
        Utils.timeRecordFromNoDots = Utils.StringDateToNoDots(Utils.timeRecordFrom);
        Utils.timeRecordToNoDots = Utils.StringDateToNoDots(Utils.timeRecordTo);

        IndeksToUploadDoStuff.FillStep2Lists(RepositoryLists.listToUpload);

        newWindow = new();
        newWindow.Show();
    }

}
