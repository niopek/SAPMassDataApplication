using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NowaMasowka.Classes.Page1Classes;
using NowaMasowka.Classes.Page2Classes;

namespace NowaMasowka.Classes
{
    internal static class IndeksToUploadDoStuff
    {

        public static void FillStep2Lists(Repository<IndeksToUpload> listToUpload)
        {
            // iterating in UploadList
            foreach (IndeksToUpload indeksToUpload in listToUpload)
            {
                // checking empty fields or unplanned null errors
               if (indeksToUpload.Indeks != null && indeksToUpload.Indeks != "" &&
                   indeksToUpload.PlantNumber != null && indeksToUpload.PlantNumber != "") 
                {
                    // creating temp PriceList for this IndekstoUpload
                    List<IndeksPriceList> indeksPriceListTemp = new();
                    indeksPriceListTemp = RepositoryLists.listPriceList.Where(i=> i.Indeks == indeksToUpload.Indeks).ToList();

                    // creating temp SystemExistSources for this IndeksToUpload
                    List<IndeksExistSource> indeksExistSourceTemp = new();
                    indeksExistSourceTemp = RepositoryLists.listExistSource.Where(i=>i.Indeks == indeksToUpload.Indeks && i.PlantNumber == indeksToUpload.PlantNumber).ToList();

                    // iterating in priceList if its > 0
                    if (indeksPriceListTemp.Count > 0)
                    {
                        foreach(IndeksPriceList priceRecord in indeksPriceListTemp)
                        {
                            // testing what is already in system (data provided by user)
                            bool isRecordInSystem = Utils.IsRecordAlreadyInSystem(indeksToUpload, priceRecord);
                            bool isSourceInSystem = Utils.IsSourceAlreadyInSystem(indeksToUpload, priceRecord);

                            // checking important data, cant go further if user didnt fill it
                            if (priceRecord.Supplier != null && priceRecord.Supplier != "" &&
                                priceRecord.Price != null && priceRecord.Price != "")
                            {
                                // fixing empty not important data for lazy users but needed from system
                                if (priceRecord.Currency == null || priceRecord.Currency.Length != 3) { priceRecord.Currency = "PLN"; }
                                if (priceRecord.UnitOfMeasure == null || priceRecord.UnitOfMeasure == "") { priceRecord.UnitOfMeasure = "1"; }
                                if (priceRecord.CountryOfOrigin == null || priceRecord.CountryOfOrigin.Length != 2) { priceRecord.CountryOfOrigin = "PL"; }
                                if (priceRecord.DeliveryTime == null || priceRecord.DeliveryTime == "") { priceRecord.DeliveryTime = "21"; }


                                // if no record in system then add to list of new records, if record exist then we will overwrite it in system
                                if (isRecordInSystem == false)
                                {
                                    var record = new IndeksNewRecord()
                                    {
                                        Indeks = indeksToUpload.Indeks,
                                        PlantNumber = indeksToUpload.PlantNumber,
                                        Supplier = priceRecord.Supplier,
                                        Price = priceRecord.Price,
                                        Currency = priceRecord.Currency,
                                        DateFrom = Utils.timeRecordFrom,
                                        DateTo = Utils.timeRecordTo,
                                        UnitOfMeasure = priceRecord.UnitOfMeasure,
                                        CountryOfOrigin = priceRecord.CountryOfOrigin,
                                        PlatformNumber = priceRecord.PlatformNumber,
                                        DeliveryTime = priceRecord.DeliveryTime
                                    };


                                    if (Repository<IndeksNewRecord>.CheckRecordIsIn(record, RepositoryLists.listOfNewRecord) == false)
                                    {
                                        RepositoryLists.listOfNewRecord.Add(record);
                                    }

                                }
                                else
                                {
                                    var record = new IndeksNewExistRecord()
                                    {
                                        Indeks = indeksToUpload.Indeks,
                                        PlantNumber = indeksToUpload.PlantNumber,
                                        Supplier = priceRecord.Supplier,
                                        Price = priceRecord.Price,
                                        Currency = priceRecord.Currency,
                                        DateFrom = Utils.timeRecordFrom,
                                        DateTo = Utils.timeRecordTo,
                                        UnitOfMeasure = priceRecord.UnitOfMeasure,
                                        CountryOfOrigin = priceRecord.CountryOfOrigin,
                                        PlatformNumber = priceRecord.PlatformNumber,
                                        DeliveryTime = priceRecord.DeliveryTime
                                    };


                                    if (Repository<IndeksNewExistRecord>.CheckRecordIsIn(record, RepositoryLists.listOfNewExistRecord) == false)
                                    {
                                        RepositoryLists.listOfNewExistRecord.Add(record);
                                    }

                                }
                                // if no source in system then add source
                                if (isSourceInSystem == false)
                                {
                                    var record = new IndeksNewSource() 
                                    {
                                        Indeks = indeksToUpload.Indeks,
                                        PlantNumber = indeksToUpload.PlantNumber,
                                        Supplier = priceRecord.Supplier,
                                        DateFrom = Utils.timeRecordFromNoDots,
                                        DateTo = Utils.timeRecordToNoDots
                                    };


                                    if (Repository<IndeksNewSource>.CheckRecordIsIn(record, RepositoryLists.listOfNewSources) == false)
                                    {
                                        RepositoryLists.listOfNewSources.Add(record);
                                    }

                                }

                                // anyway add to list with duplicates (if user want to delete and then upload only pricelist sources)

                                var record2 = new IndeksNewSource()
                                {
                                    Indeks = indeksToUpload.Indeks,
                                    PlantNumber = indeksToUpload.PlantNumber,
                                    Supplier = priceRecord.Supplier,
                                    DateFrom = Utils.timeRecordFromNoDots,
                                    DateTo = Utils.timeRecordToNoDots
                                };


                                if (Repository<IndeksNewSource>.CheckRecordIsIn(record2, RepositoryLists.listOfNewSourcesWithDuplicates) == false)
                                {
                                    RepositoryLists.listOfNewSourcesWithDuplicates.Add(record2);
                                }

                            }

                        }
                        // creating list of existing sources if user want to delete it ( no need to use it in system ) 
                        if (indeksExistSourceTemp.Count > 0)
                        {
                            foreach (IndeksExistSource indeksExistSource in indeksExistSourceTemp)
                            {
                                if (indeksExistSource.Indeks != null && indeksExistSource.Indeks != "" &&
                                   indeksExistSource.Supplier != null && indeksExistSource.Supplier != "" &&
                                   indeksExistSource.PlantNumber != null && indeksExistSource.PlantNumber != "")
                                {
                                    var record = new IndeksDeleteSource()
                                    {
                                        Indeks = indeksExistSource.Indeks,
                                        Supplier = indeksExistSource.Supplier,
                                        PlantNumber = indeksExistSource.PlantNumber
                                    };


                                    if (Repository<IndeksDeleteSource>.CheckRecordIsIn(record, RepositoryLists.listOfDeleteSource) == false)
                                    {
                                        RepositoryLists.listOfDeleteSource.Add(record);
                                    }

                                }
                            }
                        }
                    }


                }

            }
        }

      
    }
}
