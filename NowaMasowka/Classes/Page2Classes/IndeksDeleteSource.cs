namespace NowaMasowka.Classes.Page2Classes;

internal class IndeksDeleteSource : IndeksBase, IIndeksToTxt
{
    public const string Title = "material\t" + "zaklad\t" + "dostawca";
    public const string Path = @"C:\LSMW_ERSA\listy źródeł\lista_zrodel_usuwanie.txt";



    public IndeksDeleteSource() { }


    public string SaveToTxt()
    {
        string result = $"{Indeks}\t{PlantNumber}\t{Supplier}";
        return result;
    }
}
