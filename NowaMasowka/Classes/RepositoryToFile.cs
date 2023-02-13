
using System.Collections.ObjectModel;

namespace NowaMasowka.Classes;

internal class RepositoryToFile<T> : Repository<T> where T : IndeksBase, IIndeksToTxt
{

    public static void ToFile(ObservableCollection<T> coll, string path, string title) 
    {

        using var plik = new StreamWriter(path);
        if (coll.Count > 0)
        {
            plik.WriteLine(title);
            foreach (T i in coll)
            {
                plik.WriteLine(i.SaveToTxt());
            }
        }
    }

    public static void ToFileWithCount(ObservableCollection<T> coll, string path, string title)
    {

        using var plik = new StreamWriter(path);
        if (coll.Count > 0)
        {
            int count = 1;
            plik.WriteLine(title);
            foreach (T i in coll)
            {
                plik.WriteLine($"{count}\t"+i.SaveToTxt());
                count++;
            }
        }
    }





}
