namespace NowaMasowka.Classes.Page2Classes;

internal class IndeksNewSource : IndeksBase, IIndeksToTxt
{
    public const string Title = "EORD-MATNR\tEORD-WERKS\tEORD-VDATU\tEORD-BDATU\tEORD-LIFNR\tEORD-EBELN\tEORD-EBELP\tEORD-EKORG\tEORD-AUTET";
    public const string Path = @"C:\LSMW_ERSA\listy źródeł\listy_zrodel_item.txt";
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }

    public IndeksNewSource() { }

    public string SaveToTxt()
    {
        string result = $"00000000000{Indeks}\t{PlantNumber}\t{DateFrom}\t{DateTo}\t000{Supplier}\t\t\t2014\t1";
        return result;
    }


}
