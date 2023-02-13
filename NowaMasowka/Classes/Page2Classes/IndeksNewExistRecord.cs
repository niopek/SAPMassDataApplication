namespace NowaMasowka.Classes.Page2Classes;

internal class IndeksNewExistRecord : IndeksBase, IIndeksToTxt
{
    public const string Title = "dostawca\tmaterial\tdz_zaop\tzaklad\tnr_u_dostawcy\twaluta\tczas_dostawy\tcena\tJC\tdata_od\tdata_do\tKraj_poch";
    public const string Path = @"C:\LSMW_ERSA\inforekordy\inf_nowy_okres.txt";
    public string? Price { get; set; }
    public string? Currency { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public string? UnitOfMeasure { get; set; }
    public string? CountryOfOrigin { get; set; }
    public string? PlatformNumber { get; set; }
    public string? DeliveryTime { get; set; }
    public IndeksNewExistRecord() { }

    public string SaveToTxt()
    {
        string result = $"000{Supplier}\t00000000000{Indeks}\t2014\t{PlantNumber}\t{PlatformNumber}\t{Currency}\t{DeliveryTime}\t{Price}\t{UnitOfMeasure}\t{DateFrom}\t{DateTo}\t{CountryOfOrigin}";
        return result;
    }

}
