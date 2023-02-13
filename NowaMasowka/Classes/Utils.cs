
using System.Text.RegularExpressions;
using NowaMasowka.Classes.Page1Classes;

namespace NowaMasowka.Classes;

internal static class Utils
{
    internal static string? timeRecordFrom;
    internal static string? timeRecordTo;
    internal static string? timeRecordFromNoDots;
    internal static string? timeRecordToNoDots;
    public static string StringDateToNoDots(string s)
    {
        string tempString = "";
        foreach (char c in s)
        {
            if (Char.IsDigit(c))
            {
                tempString += c;
            }
        }
        s = tempString;
        return s;
    }

    public static List<string> FromClipboardToList(string clipboard, string splitBy)
    {
        List<string> listOfStrings = new List<string>();
        string[] splittedClipboard = Regex.Split(clipboard, splitBy);

        if (splittedClipboard.Count() > 0)
        {
            foreach (string s in splittedClipboard)
            {
                listOfStrings.Add(s);
            }
        }
        return listOfStrings;
    }

    public static string ClearEmptyCharsAndTabs(string text)
    {
        string tempString = "";
        foreach (char c in text)
        {
            if (c != ' ' && c != '\t' && c != '\n' && c != '\r')
            {
                tempString += c;
            }
        }
        text = tempString;
        return text;
    }
    public static List<string> ArrayToList(string[] array)
    {
        List<string> listOfStrings = new List<string>();
        if(array.Length > 0)
        {
            foreach (string s in array)
            {
                string tempS = Utils.ClearEmptyCharsAndTabs(s);
                
                    listOfStrings.Add(tempS);
                
            }
        }
        return listOfStrings;
        
    }

    public static void FromListToObject(List<string> list, Repository<IndeksToUpload> repository) 
    {
        foreach(string s in list)
        {
            string[] splitByTab = Regex.Split(s, "\t");
            List<string> listSplitByTab = ArrayToList(splitByTab);
            if (listSplitByTab.Count > 0)
            {

                switch (splitByTab.Count())
                {
                    case 0:
                        MessageBox.Show("Musisz coś skopiować");
                        break;
                    case 1:
                        RepositoryLists.listToUpload.Add(new IndeksToUpload() { Indeks = listSplitByTab[0] });
                        break;
                    case >=2:
                        RepositoryLists.listToUpload.Add(new IndeksToUpload() { Indeks = listSplitByTab[0], PlantNumber = listSplitByTab[1] });
                        break;
                }
            }

        }
    }

    public static void FromListToObject(List<string> list, Repository<IndeksPriceList> repository)
    {
        foreach (string s in list)
        {
            string[] splitByTab = Regex.Split(s, "\t");
            List<string> listSplitByTab = ArrayToList(splitByTab);

            if (listSplitByTab.Count > 0)
            {
                switch (splitByTab.Count())
                {
                    case 0:
                        MessageBox.Show("Musisz coś skopiować");
                        break;
                    case 1:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0] });
                        break;
                    case 2:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1] });
                        break;
                    case 3:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], Price = listSplitByTab[2] });
                        break;
                    case 4:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], Price = listSplitByTab[2], Currency = listSplitByTab[3] });
                        break;
                    case 5:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], Price = listSplitByTab[2], Currency = listSplitByTab[3], DeliveryTime = listSplitByTab[4] });
                        break;
                    case 6:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], Price = listSplitByTab[2], Currency = listSplitByTab[3], DeliveryTime = listSplitByTab[4], PlatformNumber = listSplitByTab[5] });
                        break;
                    case 7:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], Price = listSplitByTab[2], Currency = listSplitByTab[3], DeliveryTime = listSplitByTab[4], PlatformNumber = listSplitByTab[5], UnitOfMeasure = listSplitByTab[6] });
                        break;
                    case >=8:
                        RepositoryLists.listPriceList.Add(new IndeksPriceList() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], Price = listSplitByTab[2], Currency = listSplitByTab[3], DeliveryTime = listSplitByTab[4], PlatformNumber = listSplitByTab[5], UnitOfMeasure = listSplitByTab[6], CountryOfOrigin = listSplitByTab[7] });
                        break;

                }


            }

        }
    }
    public static void FromListToObject(List<string> list, Repository<IndeksExistRecord> repository)
    {
        foreach (string s in list)
        {
            string[] splitByTab = Regex.Split(s, "\t");
            List<string> listSplitByTab = ArrayToList(splitByTab);
            if (listSplitByTab.Count > 0)
            {

                switch (splitByTab.Count())
                {
                    case 0:
                        MessageBox.Show("Musisz coś skopiować");
                        break;
                    case 1:
                        RepositoryLists.listExistRecord.Add(new IndeksExistRecord() { Indeks = listSplitByTab[0] });
                        break;
                    case 2:
                        RepositoryLists.listExistRecord.Add(new IndeksExistRecord() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1] });
                        break;
                    case >= 3:
                        RepositoryLists.listExistRecord.Add(new IndeksExistRecord() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], PlantNumber = listSplitByTab[2] });
                        break;
                }
            }

        }
    }
    public static void FromListToObject(List<string> list, Repository<IndeksExistSource> repository)
    {
        foreach (string s in list)
        {
            string[] splitByTab = Regex.Split(s, "\t");
            List<string> listSplitByTab = ArrayToList(splitByTab);
            if (listSplitByTab.Count > 0)
            {

                switch (splitByTab.Count())
                {
                    case 0:
                        MessageBox.Show("Musisz coś skopiować");
                        break;
                    case 1:
                        RepositoryLists.listExistSource.Add(new IndeksExistSource() { Indeks = listSplitByTab[0] });
                        break;
                    case 2:
                        RepositoryLists.listExistSource.Add(new IndeksExistSource() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1] });
                        break;
                    case >= 3:
                        RepositoryLists.listExistSource.Add(new IndeksExistSource() { Indeks = listSplitByTab[0], Supplier = listSplitByTab[1], PlantNumber = listSplitByTab[2] });
                        break;
                }
            }

        }
    }

    public static bool IsRecordAlreadyInSystem(IndeksToUpload i, IndeksPriceList supplierInfo)
    {
        bool test = false;
        List<IndeksExistRecord> tempList = RepositoryLists.listExistRecord.Where(t => t.Indeks == i.Indeks).ToList();

        foreach (IndeksExistRecord record in tempList)
        {
            if (record.Indeks == i.Indeks && record.PlantNumber == i.PlantNumber && record.Supplier == supplierInfo.Supplier)
                test = true;
        }
        return test;
    }

    public static bool IsSourceAlreadyInSystem(IndeksToUpload i, IndeksPriceList supplierInfo)
    {
        bool test = false;
        List<IndeksExistSource> tempList = RepositoryLists.listExistSource.Where(t => t.Indeks == i.Indeks).ToList();
        foreach (IndeksExistSource record in tempList)
        {
            if (record.Indeks == i.Indeks && record.PlantNumber == i.PlantNumber && record.Supplier == supplierInfo.Supplier)
                test = true;
        }
        return test;
    }


  

}
