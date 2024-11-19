using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using SalesRecordParserApi.Models;



namespace SalesRecordParserApi.Services
{
    public class DataLoaderService : IDataLoaderService
    {

        public List<Sale> GetSalesInformation()
        {
            using (var streamReader = new StreamReader("SalesRecords.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ",", Encoding = Encoding.UTF8 }))
                {
                    var records = csvReader.GetRecords<Sale>().ToList();
                    return records;

                }
            }
        }
    }
}
