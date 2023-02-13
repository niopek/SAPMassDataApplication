namespace NowaMasowka.Classes.Page2Classes;

internal class IndeksNewRecord : IndeksBase, IIndeksToTxt
{
    public const string Title = "EIN0-INFNR\tEIN0-LIFNR\tEIN0-MATNR\tEIN0-EKORG\tEIN0-TYP\tEIN0-WERKS\tEINE-NORBM\tEINA-MEINS\tEINA-VABME\tEINA-UMREZ\tEINA-UMREN\tEINA-IDNLF\tEINA-MAHN1\tEINA-MAHN2\tEINA-MAHN3\tEINA-URZLA\tEINA-PUNEI\tEINE-WAERS\tEINE-APLFZ\tEINE-NETPR\tEINE-PEINH\tEINE-BPRME\tEINE-PRDAT\tEINE-BPUMZ\tEINE-BPUMN\tEINE-MWSKZ\tEINE-BSTAE\tEINE-INCO1\tEINE-INCO2\tEINE-IPRZK\tEINE-MHDRZ\tRM06I-SELKZ\tRM06I-LTEX1\tRM06I-LTEX2\tRM06I-LTEX3\tRM06I-LTEX4\tRM06I-LTEX5\tKONM-KSCHL\tKONP-KPEIN\tKONP-KONWA\tKONP-KMEIN\tKONM-DATBE\tKONM-DATBI\tKONM-KBETR";
    public const string Path = @"C:\LSMW_ERSA\inforekordy\info_main.txt";
    public string? Price { get; set; }
    public string? Currency { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public string? UnitOfMeasure { get; set; }
    public string? CountryOfOrigin { get; set; }
    public string? PlatformNumber { get; set; }
    public string? DeliveryTime { get; set; }

    public IndeksNewRecord() { }

    public string SaveToTxt()
    {
        string result = $"000{Supplier}\t00000000000{Indeks}\t2014\tS\t{PlantNumber}\t1\t\t\t\t\t{PlatformNumber}\t\t\t\t{CountryOfOrigin}\t\t{Currency}\t{DeliveryTime}\t{Price}\t{UnitOfMeasure}\t\t\t\t\t\t0001\t\t\t\t\t\t\t\t\t\t\t\t{UnitOfMeasure}\t\t\t{DateFrom}\t{DateTo}\t";
        return result;
    }

}
