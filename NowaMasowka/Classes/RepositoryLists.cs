
using NowaMasowka.Classes.Page1Classes;
using NowaMasowka.Classes.Page2Classes;

namespace NowaMasowka.Classes;

internal static class RepositoryLists 
{
   //MainWindow Data Lists
   public static Repository<IndeksToUpload> listToUpload = new Repository<IndeksToUpload>();
   public static Repository<IndeksPriceList> listPriceList = new Repository<IndeksPriceList>();
   public static Repository<IndeksExistRecord> listExistRecord = new Repository<IndeksExistRecord>();
   public static Repository<IndeksExistSource> listExistSource = new Repository<IndeksExistSource>();
   //Window1 - Results Lists
   public static RepositoryToFile<IndeksNewRecord> listOfNewRecord = new RepositoryToFile<IndeksNewRecord>();
   public static RepositoryToFile<IndeksNewExistRecord> listOfNewExistRecord = new RepositoryToFile<IndeksNewExistRecord>();
   public static RepositoryToFile<IndeksNewSource> listOfNewSources = new RepositoryToFile<IndeksNewSource>();
   public static RepositoryToFile<IndeksNewSource> listOfNewSourcesWithDuplicates = new RepositoryToFile<IndeksNewSource>();
   public static RepositoryToFile<IndeksDeleteSource> listOfDeleteSource = new RepositoryToFile<IndeksDeleteSource>();
   
}
