
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace NowaMasowka.Classes;

internal class Repository<T> : ObservableCollection<T> where T : IndeksBase
{


    public static bool CheckRecordIsIn(T item, Repository<T> repository)
    {
        bool test = false;
        List<T> tempList = repository.Where(t => t.Indeks == item.Indeks).ToList();

        foreach (T Item in repository)
        {
            if (Item.Indeks == item.Indeks && Item.PlantNumber == item.PlantNumber && Item.Supplier == item.Supplier)
                test = true;
        }

        return test;
    }

    

}
